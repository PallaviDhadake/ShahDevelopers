using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class adminpanel_project_brochure : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            c.FillComboBox("projTitle", "projId", "ProjectData", "delMark=0", "projTitle", 0, ddrProject);
        }
        lblId.Visible = false;
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrProject.SelectedIndex == 0)
            {
                //errMsg = c.errNotification(2, "Select Project name");
                //return;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Project name');", true);
                return;
            }
            if (flpBrochure.FileName == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Brouchure file');", true);
                return;
                //errMsg = c.errNotification(2, "Select Brouchure file");
                //return;
            }


            string fileExt;
            fileExt = Path.GetExtension(flpBrochure.FileName).ToLower();

            string fileName;

            if (fileExt == ".pdf")
            {
                fileName = "pro-brouchure-" + ddrProject.SelectedValue + fileExt;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .pdf files are allowed');", true);
                return;
                //errMsg = c.errNotification(2, "Only .pdf files are allowed");
                //return;
            }
            if (flpBrochure.PostedFile.ContentLength > 5000000)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'File too large. Maximum 5 MB allowed');", true);
                return;
                //errMsg = c.errNotification(2, "File too large. Maximum 5 MB allowed");
                //return;
            }


            c.ExecuteQuery("Update ProjectData Set brouchure='" + fileName + "' Where projId=" + ddrProject.SelectedValue);

            string brouchurePath = "~/upload/projects/brouchure/";
            flpBrochure.SaveAs(Server.MapPath(brouchurePath) + fileName);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Brouchure uploaded');", true);

            //errMsg = c.errNotification(1, "Brouchure uploaded");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnupload_Click", ex.Message.ToString());
            return;
        }

    }

    protected void btnremove_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrProject.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select project to delete its brouchure');", true);
                return;
                //errMsg = c.errNotification(2, "Select project to delete its brouchure");
                //return;
            }



            string fileName;
            if (c.GetReqData("ProjectData", "brouchure", "projId=" + ddrProject.SelectedValue) != null)
            {
                fileName = c.GetReqData("ProjectData", "brouchure", "projId=" + ddrProject.SelectedValue).ToString();
                if (fileName == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Brouchure does not exist');", true);
                    return;
                    //errMsg = c.errNotification(2, "Brouchure does not exist");
                    //return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Brouchure does not exist');", true);
                return;
                //errMsg = c.errNotification(2, "Brouchure does not exist");
                //return;
            }

            //string fileName = c.getReqData("ProjectData","brouchure","projId=" + ddrSProject.SelectedValue).ToString() ;
            string brouchurePath = "~/upload/projects/brouchure/";
            c.ExecuteQuery("Update ProjectData Set brouchure='' Where projId=" + ddrProject.SelectedValue);
            File.Delete(Server.MapPath(brouchurePath) + fileName);

           // errMsg = c.errNotification(1, "Brouchure Deleted");

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Brouchure Deleted');", true);


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnremove_Click", ex.Message.ToString());
            return;
        }
    }
}