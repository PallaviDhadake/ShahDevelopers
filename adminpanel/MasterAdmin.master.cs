using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminpanel_MasterAdmin : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        //ScriptManager1.Services.Add(new ServiceReference(rootPath + "WebServices/MedCareWebService.asmx"));

        if (Session["adminMaster"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
