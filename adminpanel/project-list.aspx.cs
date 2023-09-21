using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_project_list : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, projPhoto;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Projects Data" : "Edit Projects Data";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                c.FillComboBox("proTypeName", "proTypeId", "ProjectTypes", "", "proTypeName", 0, ddrProjType);

                
                if (Request.QueryString["action"] != null)
                {
                    editproj.Visible = true;
                    viewproj.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        addnew.Visible = false;
                       
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetProjectsData(Convert.ToInt32(Request.QueryString["id"]));
                        addnew.Visible = false;
                    }


                    if (Request.QueryString["action"] == "publish")
                    {
                        if (pubStatus(Convert.ToInt32(Request.QueryString["id"])) == true)
                        {
                            c.ExecuteQuery("Update ProjectData Set pubFlag=1 Where projId=" + Request.QueryString["id"]);
                            // errMsg = c.errNotification(1, "Project Published");
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Project Published');", true);

                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('project-list.aspx', 1000);", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Project data is insuffieient to publish(Basic info, Amenities or Gallery image are not provided)');", true);
                            return;

                            //errMsg = c.errNotification(2, "Project data is insuffieient to publish(Basic info, Amenities or Gallery image are not provided)");
                        }
                    }
                    else if (Request.QueryString["action"] == "unpublish")
                    {
                        c.ExecuteQuery("Update ProjectData Set pubFlag=0 Where projId=" + Request.QueryString["id"]);
                        // errMsg = c.errNotification(1, "Project Unpublished");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Project Unpublished');", true);

                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('project-list.aspx', 1000);", true);
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    editproj.Visible = false;
                    viewproj.Visible = true;
                    FillGrid();
                }
            }
            lblId.Visible = false;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }


    private void FillGrid()
    {
        try
        {
            using (DataTable dtProj = c.GetDataTable("Select a.projId, a.projTitle, b.proTypeName, a.cityName From ProjectData a Inner Join ProjectTypes b on a.projCategory=b.proTypeId"))
            {
                gvProject.DataSource = dtProj;
                gvProject.DataBind();

                if (dtProj.Rows.Count > 0)
                {
                    gvProject.UseAccessibleHeader = true;
                    gvProject.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }


    public void GetAllControls(ControlCollection ctrs)
    {
        foreach (Control c in ctrs)
        {
            if (c is System.Web.UI.WebControls.TextBox)
            {
                TextBox tt = c as TextBox;
                tt.Text = tt.Text.Trim().Replace("'", "");
            }
            if (c.HasControls())
            {
                GetAllControls(c.Controls);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllControls(this.Controls);
            //Empty Validations
            if (ddrProjType.SelectedIndex == 0 || ddrcomplstatus.SelectedIndex == 0 || txtProjTitle.Text == "" || txtProjInfo.Text=="" || txtEstbYear.Text=="" || txtCityName.Text=="" || txtBldArea.Text=="" || txtAddData.Text==""|| txtBuilding.Text=="" || txtConfig.Text=="" || txtLocation.Text=="" || txtMap.Text=="")
            { 
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            //Insert Update data
            int maxId = lblId.Text == "[New]" ? c.NextId("ProjectData", "projId") : Convert.ToInt32(lblId.Text);

            //DateTime appDate = DateTime.Now;
            //string[] arrDate = txtDate.Text.Split('/');
            //if (c.IsDate(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) == false)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Date');", true);
            //    return;
            //}
            //else
            //{
            //    appDate = Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]);
            //}

          


            string projectphoto = "";
            if (flpPhoto.HasFile)
            {
                string fExt = Path.GetExtension(flpPhoto.FileName).ToString().ToLower();

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    projectphoto = "project-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess(projectphoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                    return;

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Please select project photo to upload');", true);
                return;
            }

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into ProjectData (projId, projDate, projCategory, projStatus, projTitle, projInfo, estbYear, cityName, addressData, builtArea, possession, StartPrice, buildings, configData, locationImp, googleMap, pubFlag, delMark) Values (" + maxId + ", '" + DateTime.Now + "', '" + ddrProjType.SelectedValue + "', '" + ddrcomplstatus.SelectedValue + "', '" + txtProjTitle.Text + "', '" + txtProjInfo.Text + "', '" + txtEstbYear.Text + "', '" + txtCityName.Text + "', '" + txtAddData.Text + "', '" + txtBldArea.Text + "', '" + txtPossession.Text + "', '" + txtStrtPrice.Text + "', '" + txtBuilding.Text + "', '" + txtConfig.Text + "', '" + txtLocation.Text + "', '" + txtMap.Text + "', 0, 0)");
               
                if (flpPhoto.HasFile)
                {
                    c.ExecuteQuery("Update ProjectData Set projPhoto='" + projectphoto + "' where projId=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Project Information  Added');", true);
            }

            else
            {

                c.ExecuteQuery("Update ProjectData Set projCategory=" + ddrProjType.SelectedValue + ", projStatus=" + ddrcomplstatus.SelectedValue + ", projTitle='" + txtProjTitle.Text + "', projInfo='" + txtProjInfo.Text + "', estbYear='" + txtEstbYear.Text + "', cityName='" + txtCityName.Text + "', builtArea='" + txtBldArea.Text + "', possession='" + txtPossession.Text + "', addressData='" + txtAddData.Text + "', StartPrice='" + txtStrtPrice.Text + "', buildings='" + txtBuilding.Text + "', configData='" + txtConfig.Text + "', locationImp='" + txtLocation.Text + "', googleMap='" + txtMap.Text + "' Where projId=" + maxId);

                if (flpPhoto.HasFile)
                {
                    c.ExecuteQuery("Update ProjectData Set projPhoto='" + projectphoto + "' where projId=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Project Information Updated');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('project-list.aspx', 2000);", true);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    private void ImageUploadProcess(string projectphoto)
    {
        try
        {

            string origImgPath = "~/upload/projects/original/";
            string thumbImgPath = "~/upload/projects/thumb/";
            string normalImgPath = "~/upload/projects/";

            flpPhoto.SaveAs(Server.MapPath(origImgPath) + projectphoto);
            c.ImageOptimizer(projectphoto, origImgPath, normalImgPath, 800, true);
            c.ImageOptimizer(projectphoto, normalImgPath, thumbImgPath, 480, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + projectphoto);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("update ProjectData set delMark=1 where projId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('project-list.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("project-list.aspx");
    }

    protected void gvProject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"project-list.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";



                Literal ltStatus = new Literal();
                ltStatus = (Literal)e.Row.FindControl("litStatus");
                int getStatus;
                getStatus = Convert.ToInt32(c.GetReqData("ProjectData", "pubFlag", "projId=" + Convert.ToInt32(e.Row.Cells[0].Text)));


                if (getStatus == 0)
                {
                    ltStatus.Text = "<a href='project-list.aspx?id=" + e.Row.Cells[0].Text + "&action=publish' class='proInactive' >Publish</a>";

                    //ltStatus.Text = "<a href=\"#\" class=\"proInactive\">Publish</a>";
                }
                else
                {
                    ltStatus.Text = "<a href='project-list.aspx?id=" + e.Row.Cells[0].Text + "&action=unpublish' class='proActive' >Unpublish</a>";
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvProject_RowDataBound", ex.Message.ToString());
            return;
        }
    }


    public void GetProjectsData(int ProjIdx)
    {
        try
        {
            using (DataTable dtProject = c.GetDataTable("select * from ProjectData where projId=" + ProjIdx))
            {
                if (dtProject.Rows.Count > 0)
                {
                    DataRow row = dtProject.Rows[0];
                   // lblId.Text = ProjIdx.ToString();
                    txtAddData.Text = row["addressData"].ToString();
                    txtBldArea.Text = row["builtArea"].ToString();
                    txtBuilding.Text = row["buildings"].ToString();
                    txtCityName.Text = row["cityName"].ToString();
                    txtConfig.Text = row["configData"].ToString();
                    txtEstbYear.Text = row["estbYear"].ToString();
                    txtLocation.Text = row["locationImp"].ToString();
                    txtMap.Text = row["googleMap"].ToString();
                    txtPossession.Text = row["possession"].ToString();
                    txtProjInfo.Text = row["projInfo"].ToString();
                    txtProjTitle.Text = row["projTitle"].ToString();
                    txtStrtPrice.Text = row["StartPrice"].ToString();
                    ddrProjType.SelectedValue = row["projCategory"].ToString();
                    ddrcomplstatus.SelectedValue = row["projStatus"].ToString();
                   


                    if (row["projPhoto"] != DBNull.Value && row["projPhoto"] != null && row["projPhoto"].ToString() != "" && row["projPhoto"].ToString() != "no-photo.png")
                    {
                        projPhoto = "<img src=\"" + Master.rootPath + "upload/projects/thumb/" + row["projPhoto"].ToString() + "\" width=\"200\" />";
                    }
                   

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetNewsData", ex.Message.ToString());
            return;
        }
    }

    public bool pubStatus(int projIDX)
    {
        if (c.IsRecordExist("Select * From ProjectAmenitiesBasic Where projId=" + projIDX) == false)
        {
            return false;
        }
        if (c.IsRecordExist("Select pgId From ProjectGallery Where projId=" + projIDX) == false)
        {
            return false;
        }
        if (Convert.ToInt32(c.GetReqData("ProjectData", "projCategory", "projId=" + projIDX)) != 4)
        {
            if (c.IsRecordExist("Select paId From ProjectAmenities Where projId=" + projIDX) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }


    }

}