using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_banner_master : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, photoMrkup;
    protected void Page_Load(object sender, EventArgs e)
    {

        pgTitle = Request.QueryString["action"] == "new" ? "Add Banner" : "Edit Banner";
        btnSave.Attributes.Add("onclick", "this.disabled=true;this.value='Processing';" + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
        btnDelete.Attributes.Add("onclick", "this.disabled=true;this.value='Processing';" + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
        btnCancel.Attributes.Add("onclick", "this.disabled=true;this.value='Processing';" + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null)
            {
                editbanner.Visible = true;
                viewbanner.Visible = false;

                if (Request.QueryString["action"] == "new")
                {
                    btnSave.Text = "Save Info";
                    btnDelete.Visible = false;

                }
                else
                {
                    btnSave.Text = "Modify Info";
                    btnDelete.Visible = true;
                    GetbannerData(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
            else
            {
                editbanner.Visible = false;
                viewbanner.Visible = true;
                //FillGrid();
            }
            lblId.Visible = false;
            FillGrid();
        }

    }


    private void FillGrid()
    {
        try
        {
            using (DataTable dtNews = c.GetDataTable("Select bannerId, imageName, displayOrder From BannerData Where delMark=0 Order By displayOrder ASC"))
            {
                gvbanner.DataSource = dtNews;
                gvbanner.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }

    protected void gvbanner_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = new Literal();
                litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"banner-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\" class=\"gAnch\" title=\"View / Edit\"></a>";

                Button btnUp = (Button)e.Row.FindControl("moveUp");
                if (e.Row.Cells[2].Text == "1")
                {
                    btnUp.Enabled = false;
                    btnUp.Attributes["style"] = "background:none;";
                }

                Button btnDown = (Button)e.Row.FindControl("moveDown");
                int maxOrd = Convert.ToInt32(c.returnAggregate("Select MAX(displayOrder) From BannerData Where delMark=0"));
                if (Convert.ToInt32(e.Row.Cells[2].Text) == maxOrd)
                {
                    btnDown.Visible = false;
                }


            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvbanner_RowDataBound", ex.Message.ToString());
            return;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtdisplay.Text = txtdisplay.Text.Trim().Replace("'", "");

            if (txtdisplay.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * marked fields are mandatory');", true);
                return;
            }
            if (!c.IsNumeric(txtdisplay.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Numric Value');", true);
                return;
            }

            int maxId = Request.QueryString["action"] == "new" ? c.NextId("BannerData", "bannerId") : Convert.ToInt32(lblId.Text);

            string fileName = "";

            if (fuImg.HasFile)
            {
                string fExt = Path.GetExtension(fuImg.FileName).ToString().ToLower();
                if (fExt == ".jpg" || fExt == ".png" || fExt == ".jpeg" || fExt == ".gif")
                {
                    fileName = "banner-image" + maxId + fExt;
                    fuImg.SaveAs(Server.MapPath("~/upload/bannerimages/") + fileName);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .png, .jpeg and .gif files are allowed');", true);
                    return;
                }
            }
            else
            {
                if (lblId.Text == "[New]")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select image to upload');", true);
                    return;
                }
            }
            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into BannerData(bannerId, displayOrder, delMark)Values(" + maxId + ", " + txtdisplay.Text + ", 0)");
                if (fuImg.HasFile)
                {
                    c.ExecuteQuery("Update BannerData Set imageName='" + fileName + "' Where bannerId=" + maxId);
                }
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Banner Added Successfully');", true);

            }
            else
            {
                c.ExecuteQuery("Update BannerData Set displayOrder=" + txtdisplay.Text + " Where bannerId=" + maxId);
                if (fuImg.HasFile)
                {
                    c.ExecuteQuery("Update BannerData Set imageName='" + fileName + "' Where bannerId=" + maxId);
                }
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Banner Updated Successfully');", true);
            }
            txtdisplay.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "waitAndMove('banner-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    private void GetbannerData(int bannerIdX)
    {
        try
        {
            using (DataTable dtNews = c.GetDataTable("Select * From BannerData Where bannerId=" + bannerIdX))
            {
                if (dtNews.Rows.Count > 0)
                {
                    DataRow row = dtNews.Rows[0];
                    lblId.Text = bannerIdX.ToString();

                    txtdisplay.Text = row["displayOrder"].ToString();


                    photoMrkup = "<img src=\"" + Master.rootPath + "upload/bannerimages/" + row["imageName"].ToString() + "\"style=\"width:200px;\" />";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid Banner Record selected');", true);
                    return;

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetbannerData", ex.Message.ToString());
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update BannerData Set delMark=1 Where bannerId=" + Convert.ToInt32(Request.QueryString["id"]));

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Banner Deleted Successfully');", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "waitAndMove('banner-master.aspx', 1000);", true);
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
        Response.Redirect("banner-master.aspx");
    }

    protected void gvbanner_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            if (e.CommandName == "Up")
            {
                int displayOrd = Convert.ToInt32(gRow.Cells[2].Text);
                int previouRow = Convert.ToInt32(gRow.Cells[0].Text);
                c.ExecuteQuery("Update BannerData Set displayOrder=" + displayOrd + " Where displayOrder=" + (displayOrd - 1));
                c.ExecuteQuery("Update BannerData Set displayOrder=" + (displayOrd - 1) + " Where bannerId=" + previouRow);
            }
            if (e.CommandName == "Down")
            {
                int displayOrd = Convert.ToInt32(gRow.Cells[2].Text);
                int previouRow = Convert.ToInt32(gRow.Cells[0].Text);
                c.ExecuteQuery("Update BannerData Set displayOrder=" + displayOrd + " Where displayOrder=" + (displayOrd + 1));
                c.ExecuteQuery("Update BannerData Set displayOrder=" + (displayOrd + 1) + " Where bannerId=" + previouRow);
            }
            FillGrid();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvbanner_RowCommand", ex.Message.ToString());
            return;
        }

    }

    protected void gvbanner_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvbanner.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}