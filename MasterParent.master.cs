using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterParent : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string rootPath, currentyear;
    protected void Page_Load(object sender, EventArgs e)
    {

        rootPath = c.ReturnHttp();
        currentyear = DateTime.Now.Year.ToString();
    }
}
