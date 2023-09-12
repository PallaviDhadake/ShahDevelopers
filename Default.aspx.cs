using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    
    public string currentyear;
    protected void Page_Load(object sender, EventArgs e)
    {
        c.ReturnHttp();
        currentyear = DateTime.Now.Year.ToString("");
    }
}