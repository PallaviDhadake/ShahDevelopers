using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class contact_us : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtMsg.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
                //errMsg = c.errNotification(2, "All * marked fields are mendatory");
                //return;
            }
            if (c.EmailAddressCheck(txtEmail.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Email Address');", true);
                return;
            }
            if (c.ValidateMobile(txtPhone.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Mobile No.');", true);
                return;
            }
           
                txtName.Text = txtName.Text.Trim().Replace("'", "");
                txtPhone.Text = txtPhone.Text.Trim().Replace("'", "");
                txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");
                txtMsg.Text = txtMsg.Text.Trim().Replace("'", "");
                StringBuilder strMessage = new StringBuilder();

                // string[] arrUrl = Request.QueryString["projectId"].ToString().Split('-');
                //string[] arrUrl = Page.RouteData.Values["projectId"].ToString().Split('-');
                //int ProId = Convert.ToInt32(arrUrl[arrUrl.Length - 1]);
                //string projName = c.GetReqData("ProjectData", "projTitle", "projId=" + ProId).ToString();

                //strMessage.Append("<div>New Enquiry about " + projName + "</div>");
                strMessage.Append("<br/><br/>");
                strMessage.Append("<div><b>Name:<b> " + txtName.Text + "<div>");
                strMessage.Append("<br/>");
                strMessage.Append("<div><b>Phone:<b> " + txtPhone.Text + "<div>");
                strMessage.Append("<br/>");
                strMessage.Append("<div><b>Email:<b> " + txtEmail.Text + "<div>");
                strMessage.Append("<br/>");
                strMessage.Append("<div><b>Message:<b> " + txtMsg.Text + "<div>");
                strMessage.Append("<br/>");
                string msgDetails = strMessage.ToString();

                //c.sendMail("info@shahdevelopers.org", txtEmail.Text, msgDetails, "Enquiry for " + projName , "", true, "", "");
                // c.SendMail("info@shahdevelopers.org", "san.apshah@gmail.com", msgDetails, "Enquiry for " + projName, "aks.shah00@gmail.com", true, "", "");

                // c.SendMail("info@intellect-systems.com", " Samruddhi Cleaning Wares", "pallavidhadake20@gmail.com", strMessage.ToString(), "New Application at  Samruddhi Cleaning Wares", "", true, "", "");

                c.SendMail("info@shahdevelopers.org", "Shah Real Estate Developers", "san.apshah@gmail.com", strMessage.ToString(), "New Enquiry at Shah Developers", "", true, "", "");

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Enquiry submitted. We will contact you soon');", true);

                //errMsg = c.errNotification(1, "Enquiry submitted. We will contact you soon");
           
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }
}