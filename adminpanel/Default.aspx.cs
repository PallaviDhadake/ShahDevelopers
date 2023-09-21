using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminpanel_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        cmdSign.Attributes.Add("onclick", "this.disabled=true;this.value='Processing...';" + ClientScript.GetPostBackEventReference(cmdSign, null) + ";");
        txtUserName.Focus();
        if (!IsPostBack)
        {
            if (Session["adminMaster"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
    }

    protected void cmdSign_Click(object sender, EventArgs e)
    {
        try
        {
            txtUserName.Text = txtUserName.Text.Trim().Replace("'", "");
            txtPwd.Text = txtPwd.Text.Trim().Replace("'", "");

            if (txtUserName.Text == "" || txtPwd.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter UserName & Password.');", true);

                return;
            }
            if (!c.IsRecordExist("Select userID From Users Where userName='" + txtUserName.Text + "'"))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid UserName Entered, Try Again.');", true);

                return;
            }
            //else if (c.GetReqData("Users", "userPwd", "userName='" + txtUserName.Text.Trim() + "'").ToString() != txtPwd.Text)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Wrong Password Entered. Try Again.');", true);

            //    return;
            //}
            else
            {
                Session["adminMaster"] = txtUserName.Text;
                Response.Redirect("Dashboard.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "cmdSign_Click", ex.Message.ToString());
            return;
        }
    }
}
