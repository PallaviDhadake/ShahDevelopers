using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.IO;
public partial class projects : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, projstr, pgHeader, actclass, actclass1, actclass2, actclass3;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //HtmlMeta tag = new HtmlMeta();
            //tag.Name = "description";
            //tag.Content = "Exclusive Real Estate commercial & residential projects, Land development construction company in Sangli, Pune Maharashtra.";
            //Header.Controls.Add(tag);
            //Page.Header.DataBind();

            //  ShowProjects();

            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Page.RouteData.Values["protype"].ToString()))
                {
                    ShowProjects();
                }
                //else
                //{
                //    string[] arrLinks = Page.RouteData.Values["protype"].ToString().Split('-');
                //    GetprojDetails(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
                //}
            }

        }
        catch(Exception ex)
        {
            projstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

       // Form1.Action = Request.RawUrl; //To maintain actual virtual url status on Postback Event
        //if (!IsPostBack)
        //{
        //    ShowProjects();
        //}

    }


    public void ShowProjects()
    {
        try
        {
            DataTable dtProjects = new DataTable();
            string strQuery = "";
            int proStatus = 0;

            if (Request.QueryString != null)
            {
                if (Page.RouteData.Values["protype"].ToString() == "land-developement")
                {
                    pgHeader = "Land Development Projects";
                    proData.Visible = true;
                    proInfra.Visible = false;
                    compProj.Visible = false;
                    actclass = "active show";
                    if (ddrProjStatus.SelectedIndex != 0)
                    {
                        strQuery = "Select a.projId, a.projTitle, a.cityName, a.projInfo, a.builtArea, a.configData, a.projPhoto, b.proTypeName From ProjectData a Inner Join ProjectTypes b on a.projCategory=b.proTypeId Where projCategory=4 And a.projStatus=" + ddrProjStatus.SelectedValue + " And delMark=0 And pubFlag=1";
                    }
                    else
                    {
                        strQuery = "Select a.projId, a.projTitle, a.cityName, a.projInfo, a.builtArea, a.configData, a.projPhoto, b.proTypeName From ProjectData a Inner Join ProjectTypes b on a.projCategory=b.proTypeId Where projCategory=4 And delMark=0 And pubFlag=1 ";
                    }

                }
                else if (Page.RouteData.Values["protype"].ToString() == "construction")
                {
                    pgHeader = "Construction Projects";
                    proData.Visible = true;
                    compProj.Visible = false;
                    proInfra.Visible = false;
                    actclass = "";
                    actclass1 = "active show";
                    if (ddrProjStatus.SelectedIndex != 0)
                    {
                        strQuery = "Select a.projId, a.projTitle, a.cityName, a.projInfo, a.configData, a.projPhoto, a.builtArea, b.proTypeName From ProjectData a Inner Join ProjectTypes b on a.projCategory=b.proTypeId Where projCategory In (1,2,3) And a.projStatus=" + ddrProjStatus.SelectedValue + " And delMark=0 And pubFlag=1 ";
                    }
                    else
                    {
                        strQuery = "Select a.projId, a.projTitle, a.cityName, a.projInfo, a.configData, a.projPhoto, a.builtArea, b.proTypeName From ProjectData a Inner Join ProjectTypes b on a.projCategory=b.proTypeId Where projCategory In (1,2,3) And delMark=0 And pubFlag=1 ";
                    }

                }
                else if (Page.RouteData.Values["protype"].ToString() == "infrastructure")
                {
                    pgHeader = "Infrastructure Projects";
                    actclass = "";
                    actclass2 = "active show";
                    compProj.Visible = false;
                    proData.Visible = false;
                    proInfra.Visible = true;

                }
                else if (Page.RouteData.Values["protype"].ToString() == "completed")
                {
                    pgHeader = "Completed Projects";
                    actclass = "";
                    actclass3 = "active show";
                    proData.Visible = false;
                    proInfra.Visible = false;
                    compProj.Visible = true;

                }
            }

            //If condition of land development and infrastructure

            if (Page.RouteData.Values["protype"].ToString() != "infrastructure" && Page.RouteData.Values["protype"].ToString() != "completed")
            {

                using (DataTable dtProj = c.GetDataTable(strQuery))
                {
                    if (dtProj.Rows.Count > 0)
                    {

                        StringBuilder strMarkup = new StringBuilder();
                        foreach (DataRow row in dtProj.Rows)
                        {
                            strMarkup.Append("<div class=\"col-lg-6 g-0 mb-3\" id=\"" + row["projId"] + "\">");
                            strMarkup.Append("<div class=\"p-3\">");
                            strMarkup.Append("<div class=\"row g-0 border\">");
                            strMarkup.Append("<div class=\"col-md-6\">");
                            strMarkup.Append("<div class=\"p-3\">");

                          string url = row["proTypeName"].ToString().ToLower().Replace(" ", "-") + "-in-" + row["cityName"].ToString().ToLower().Replace(" ", "-") + "-" + row["projTitle"].ToString().ToLower().Replace(" ", "-") + "-" + row["projId"].ToString();

                            url = "/project-listings/" + c.UrlGenerator(url);

                            //string nUrl = Master.rootPath + "projects/" + c.UrlGenerator(row["projTitle"].ToString().ToLower() + "-" + row["projId"].ToString());

                            string projTitle = row["projTitle"].ToString().Length >= 21 ? row["projTitle"].ToString().Substring(0, 21) + "..." : row["projTitle"].ToString();

                            strMarkup.Append("<a href=\""+ url +"\" class=\"semiBold semiMedium mb-2 colorPrime text-decoration-none\">" + projTitle + "</a>");

                            strMarkup.Append("<p class=\"light clrGrey mb-1\">" + row["configData"].ToString() + " | " + row["cityName"].ToString() + "</p>");

                            strMarkup.Append("<p class=\"light line-ht-5 mb-4\"> Area of Land - " + row["builtArea"].ToString() + "</p>");

                            strMarkup.Append("<a href=\"" + url + "\" class=\"btnviewproj\">View Project</a>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("<div class=\"col-md-6\">");

                            strMarkup.Append("<img src=\"" + Master.rootPath + "/upload/projects/thumb/" + row["projPhoto"].ToString() + " \" alt=\"" + row["projTitle"].ToString() + " \"  class=\"img-fluid w-100 h-100\" >");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        projstr = strMarkup.ToString();
                    }
                    else
                    {
                        projstr = "<span class=\"infoClr\">No Projects Uploaded..Come back later</span>";
                    }
                }
            }
        }
        catch(Exception ex)
        {
            projstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    protected void ddrProjStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ShowProjects();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }


}