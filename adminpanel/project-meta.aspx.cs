using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminpanel_project_meta : System.Web.UI.Page
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtMeta.Value = txtMeta.Value.Trim().Replace("'", "");

            //txtMeta.Value = txtMeta.Value.Trim();
            if (ddrProject.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Project');", true);
                return;
                //errMsg = c.errNotification(2, "Select Project");
                //return;
            }
            if (txtMeta.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter meta description');", true);
                return;
                //errMsg = c.errNotification(2, "Enter meta description");
                //return;
            }

            c.ExecuteQuery("Update ProjectData Set metaData='" + txtMeta.Value + "' Where projId=" + ddrProject.SelectedValue);
            //errMsg = c.errNotification(1, "Meta description updated");

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Meta description updated');", true);

            txtMeta.Value = "";
            ddrProject.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    protected void ddrProject_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (c.GetReqData("ProjectData", "metaData", "projId=" + ddrProject.SelectedValue) != null)
            {
                txtMeta.Value = c.GetReqData("ProjectData", "metaData", "projId=" + ddrProject.SelectedValue).ToString();
            }
            else
            {
                txtMeta.Value = "";
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "setCount(" + (160- txtMeta.Value.Length ) + ");", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "setCount(" + (160 - txtMeta.Value.Length) + ");", true);
            //document.getElementById(indicator).innerHTML = CharLength - chars;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ddrProject_TextChanged", ex.Message.ToString());
            return;
        }
    }



}