using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminpanel_project_documents : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, url;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add News" : "Edit News";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                c.FillComboBox("ProjName", "projId", "ProjectsNew", "DelMark=0", "ProjName", 0, ddrProject);

               // c.fillComboBox("ProjName", "ProjId", "ProjectsNew", "", ddrProjId);

                if (Request.QueryString["action"] != null)
                {
                    editNews.Visible = true;
                    viewNews.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        // txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        //  btnRemove.Visible = false;
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetDocData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
                else
                {
                    editNews.Visible = false;
                    viewNews.Visible = true;
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
            using (DataTable dtNws = c.GetDataTable("Select a.ProDocID, a.FK_ProjectId, a.ProDocName, a.ProDocUrl, b.ProjName From ProjectDocs a Inner Join ProjectsNew b ON a.FK_ProjectId=b.ProjId Where a.DelMark=0"))
            {
                gvDoc.DataSource = dtNws;
                gvDoc.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvDoc.UseAccessibleHeader = true;
                    gvDoc.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            if (txtDoc.Text == "" || txtDocUrl.Text == "" || ddrProject.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            //Insert Update data
            int maxId = lblId.Text == "[New]" ? c.NextId("ProjectDocs", "ProDocID") : Convert.ToInt32(lblId.Text);

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

            //DateTime cDate = DateTime.Now;
            //string currentDate = cDate.ToString("yyyy-MM-dd HH:mm:ss.fff");


            //string nwsPhoto = "";
            //if (fuImage.HasFile)
            //{
            //    string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();

            //    if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
            //    {
            //        nwsPhoto = "news-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
            //        ImageUploadProcess(nwsPhoto);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
            //        return;

            //    }
            //}

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into ProjectDocs (ProDocID, FK_ProjectId, ProDocName, ProDocUrl, DelMark) Values(" + maxId + ", '" + ddrProject.SelectedValue + "', '" + txtDoc.Text + "', '" + txtDocUrl.Text + "', 0)");
              
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Document  Added');", true);
            }

            else
            {
                c.ExecuteQuery("Update ProjectDocs Set FK_ProjectId='" + ddrProject.SelectedValue + "', ProDocName = '" + txtDoc.Text + "', ProDocUrl = '" + txtDocUrl.Text + "' Where ProDocID=" + maxId);


                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Document  Updated');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('project-documents.aspx', 2000);", true);

            txtDoc.Text = txtDocUrl.Text = "";
            ddrProject.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    public void GetDocData(int ProjIdx)
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("select * from ProjectDocs where ProDocID=" + ProjIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    lblId.Text = ProjIdx.ToString();
                    txtDoc.Text = row["ProDocName"].ToString();
                    txtDocUrl.Text = row["ProDocUrl"].ToString();
                    ddrProject.SelectedValue = row["FK_ProjectId"].ToString();



                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetDocData", ex.Message.ToString());
            return;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("update ProjectDocs set delMark=1 where ProDocID=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('news-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("project-documents.aspx");
    }


    protected void gvDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"project-documents.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";


                url = c.GetReqData("ProjectDocs", "ProDocUrl", "ProDocID=" + e.Row.Cells[0].Text).ToString();

                Literal mydoc = new Literal();
                mydoc = (Literal)e.Row.FindControl("litDoc");
                mydoc.Text = "<a href='" + url +"' class=\"\" target=\"_blank\">Visit Link</a>";

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvDoc_RowDataBound", ex.Message.ToString());
            return;
        }
    }
}