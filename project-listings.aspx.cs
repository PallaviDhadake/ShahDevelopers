using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
public partial class project_listings : System.Web.UI.Page
{
    iClass c = new iClass();
    public string plotstr, plotammenities, projstr, photogal, document;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] arrLinks = Page.RouteData.Values["projectId"].ToString().Split('-');
            ProBasicData(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
            GetprojAmmenities(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
            GetprojPhotos(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
            GetprojPlotlayout(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
           // GetprojDocuments(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));
        }

    }


    public void ProBasicData(int projIdx)
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select projId, projTitle, projInfo, projPhoto, cityName, StartPrice, builtArea, configData, addressData, brouchure, googleMap from ProjectData where delMark=0 And projId=" + projIdx + " order by projId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {

                    foreach (DataRow row in dttest.Rows)
                    {
                        strMarkup.Append("<div class=\"\">");

                        strMarkup.Append("<p class=\"colorPrime semiBold large\">" + row["projTitle"].ToString() + "</p>");

                        if (row["projPhoto"] != DBNull.Value && row["projPhoto"].ToString() != "" && row["projPhoto"].ToString() != "no-photo.png" && row["projPhoto"] != null)
                        {
                            strMarkup.Append("<img src=\"" + Master.rootPath + "/upload/projects/"+row["projPhoto"].ToString()+"\" class=\"img-fluid border shadow mb-3\"/>");
                        }

                        strMarkup.Append("<span class=\"semiBold Regular\">Area of Land : <span class=\"light\">" + row["builtArea"].ToString() + " " + row["configData"].ToString() + "</span>");


                        strMarkup.Append("<div class=\"row\">");
                        strMarkup.Append("<div class=\"\">");
                        strMarkup.Append("<div class=\"\">");
                        strMarkup.Append("<p class=\"semiBold semiMedium mb-3 mt-3 text-decoration-underline\">Location Advantages<p>");
                        strMarkup.Append("<span class=\"Regular\">Address : </span>");

                        strMarkup.Append("<span class=\"light line-ht-5 mt-2 mb-2\">" + row["addressData"].ToString() + "</span>");
                        strMarkup.Append("<span class=\"space10\"></span>");
                        strMarkup.Append("<span class=\"Regular\">Saleable Area : </span>");

                        strMarkup.Append("<span class=\"light line-ht-5 mt-2\">" + row["builtArea"].ToString() + "</span>");
                        strMarkup.Append("<span class=\"space10\"></span>");
                        strMarkup.Append("<span class=\"Regular\">Price : </span>");

                        strMarkup.Append("<span class=\"light line-ht-5 mt-2\">" + row["StartPrice"].ToString() + "</span>");

                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");

                        //strMarkup.Append("<div class=\"col-md-6\">");
                        //strMarkup.Append("<div class=\"p-3\">");
                        //strMarkup.Append("<p class=\"semiBold semiMedium mb-3\">Plot Layout<p>");



                        //strMarkup.Append("</div>");
                        //strMarkup.Append("</div>");

                        strMarkup.Append("</div>");

                        //strMarkup.Append("<a href=\"testimonials#" + row["testId"].ToString() + "\" class=\"txtDecNo colorBlack\">");
                        //strMarkup.Append("<div class=\"p-3\">");
                        //strMarkup.Append("<span class=\"space10\"></span>");
                        //DateTime nDate = Convert.ToDateTime(row["testDate"]);
                        //strMarkup.Append("<span class=\"clrGrey light small\">" + nDate.ToString("dd.MM.yyyy") + "</span>");
                        //strMarkup.Append("<span class=\"space10\"></span>");
                        //strMarkup.Append("<h4 class=\"semiBold semiMedium eventheading\">" + row["testPerson"].ToString() + "</h4>");
                        //strMarkup.Append("<span class=\"clrGrey small\">Happy Buyer</span>");
                        //strMarkup.Append("<hr />");
                        //string testdesc = row["testComment"].ToString().Length >= 171 ? row["testComment"].ToString().Substring(0, 171) + "..." : row["testComment"].ToString();
                        //strMarkup.Append("<a href=\"testimonials#" + row["testId"].ToString() + "\" class=\"semiBold fontRegular text-decoration-none colorBlack readevnt\">Read More <img src=\"images/icons/rght-icon.png\" class=\"ms-2\"/></a>");
                        //strMarkup.Append("</div>");
                        //strMarkup.Append("</a>");
                        //strMarkup.Append("</div>");

                        // LatLong of Google Maps
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "initialize('" + row["googleMap"].ToString() + "');", true);
                        strMarkup.Append("</div>");

                        if (row["brouchure"] != DBNull.Value && row["brouchure"].ToString() != "")
                        {
                            document = "<a href=\"" + Master.rootPath + "/upload/projects/brouchure/" + row["brouchure"].ToString() + "\" class=\"text-decoration-none pdfLink\" title=\"Download Brouchure\" class=\"downBrouchure\" target=\"_blank\"  >Download Brouchure</a>";
                             
                        }
                        else
                        {
                            document = "<a href=\"#\" title=\"Download Brouchure pdfLink\" class=\"downBrouchure\" >Download Brouchure</a>";
                        }

                    }
                    projstr = strMarkup.ToString();

                   
                }
                else
                {
                    projstr= "Noting to display";
                }
            }
        }
        catch (Exception ex)
        {
            projstr = ex.Message.ToString();
        }
    }



    private void GetprojPlotlayout(int projIdx)
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable drplot = c.GetDataTable("Select * From ProjectFloorPlans Where projId=" + projIdx))
            {
                if (drplot.Rows.Count > 0)
                {
                    foreach (DataRow row in drplot.Rows)
                    {
                        strMarkup.Append("<div class=\"container\">");

                        strMarkup.Append("<p class=\"semiBold medium text-decoration-underline mb-4\">Plot Layout</p>");

                        if (row["fpImage"] != DBNull.Value && row["fpImage"].ToString() != "" && row["fpImage"].ToString() != "no-photo.png" && row["fpImage"] != null)
                        {
                            strMarkup.Append("<img src=\"" + Master.rootPath + "/upload/projects/floorplan/"+row["fpImage"].ToString()+" \" alt=\"floor plan image\" class=\"img-fluid\"/>");
                        }
                        strMarkup.Append("</div>");

                    }
                    plotstr = strMarkup.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            plotstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    private void GetprojAmmenities(int projIdx)
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable drplot = c.GetDataTable("Select * From ProjectAmenitiesBasic Where projId=" + projIdx))
            {
                if (drplot.Rows.Count > 0)
                {
                    foreach (DataRow row in drplot.Rows)
                    {
                        strMarkup.Append("<div class=\"container text-center\">");
                        strMarkup.Append("<div class=\"row gy-4\">");
                       

                        if (row["amIntrRoads"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"images/icons/international-tar-road.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium mt-2\">Internal Tar Roads</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotElec"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+ Master.rootPath + "/images/icons/electricity.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Electricity</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotWater"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"/images/icons/water-suppy.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Water Supply</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotDrainage"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+ Master.rootPath + "/images/icons/drainage.png" + "\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Drainage</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotGarden"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"/images/icons/landscape-garden.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Landscaped Gardens</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotPlay"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"/images/icons/play-garden.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Children's Play Park</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotStrLight"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"/images/icons/street-light.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Street Light</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                        if (row["amPlotHarvest"].ToString() == "1")
                        {
                            strMarkup.Append("<div class=\"col-md-3\">");
                            strMarkup.Append("<div class=\"p-2 border border-primary bg-white shadow\">");
                            strMarkup.Append("<img src=\""+Master.rootPath+"/images/icons/rainwater-harvesting.png\" class=\"img-fluid mt-3\"/>");
                            strMarkup.Append("<p class=\"semiBold semiMedium\">Rainwater Harvesting</p>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }

                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");

                    }
                    plotammenities = strMarkup.ToString();
                }
                else
                {
                    plotammenities = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            plotammenities = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void GetprojPhotos(int projIdx)
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable drplot = c.GetDataTable("Select * From ProjectGallery Where projId=" + projIdx))
            {
                if (drplot.Rows.Count > 0)
                {

                    foreach (DataRow row in drplot.Rows)
                    {

                        
                       strMarkup.Append("<div class=\"col-md-4\">");
                        //strMarkup.Append("<span class=\"large\">Demo</span>");
                        if (row["pgImage"] != DBNull.Value && row["pgImage"].ToString() != "" && row["pgImage"].ToString() != "no-photo.png" && row["pgImage"] != null)
                        {
                            strMarkup.Append("<a href=\"" + Master.rootPath + "/upload/projects/gallery/" + row["pgImage"].ToString() + "\" data-fancybox=\"group3\">");
                            strMarkup.Append("<img src=\"" + Master.rootPath + "/upload/projects/gallery/thumb/" + row["pgImage"].ToString() + "\" class=\"img-fluid\" />");
                            strMarkup.Append("</a>");
                        }
                        strMarkup.Append("</div>");
                        

                    }
                    photogal = strMarkup.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            photogal = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


    //private void GetprojDocuments(int projIdx)
    //{
    //    try
    //    {
    //        StringBuilder strMarkup = new StringBuilder();
    //        using (DataTable drplot = c.GetDataTable("Select * From ProjectDocs Where FK_ProjectId=" + projIdx))
    //        {
    //            if (drplot.Rows.Count > 0)
    //            {

    //                foreach (DataRow row in drplot.Rows)
    //                {

    //                        strMarkup.Append("<a href=\"" + Master.rootPath + "/upload/projects/brouchure/"+row["ProDocUrl"].ToString() +"\" target=\"_blank\" class=\"pdfAnch\">Document Brouchure</a>");
    //                        //strMarkup.Append("</a>");

    //                }
    //                document = strMarkup.ToString();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        document = c.ErrNotification(3, ex.Message.ToString());
    //        return;
    //    }
    //}


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtcity.Text == "")
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
        try
        {
            txtName.Text = txtName.Text.Trim().Replace("'", "");
            txtPhone.Text = txtPhone.Text.Trim().Replace("'", "");
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");
            txtcity.Text = txtcity.Text.Trim().Replace("'", "");
            StringBuilder strMessage = new StringBuilder();

           // string[] arrUrl = Request.QueryString["projectId"].ToString().Split('-');
            string[] arrUrl = Page.RouteData.Values["projectId"].ToString().Split('-');
            int ProId = Convert.ToInt32(arrUrl[arrUrl.Length - 1]);
            string projName = c.GetReqData("ProjectData", "projTitle", "projId=" + ProId).ToString();

            strMessage.Append("<div>New Enquiry about " + projName + "</div>");
            strMessage.Append("<br/><br/>");
            strMessage.Append("<div><b>Name:<b> " + txtName.Text + "<div>");
            strMessage.Append("<br/>");
            strMessage.Append("<div><b>Phone:<b> " + txtPhone.Text + "<div>");
            strMessage.Append("<br/>");
            strMessage.Append("<div><b>Email:<b> " + txtEmail.Text + "<div>");
            strMessage.Append("<br/>");
            strMessage.Append("<div><b>City:<b> " + txtcity.Text + "<div>");
            strMessage.Append("<br/>");
            string msgDetails = strMessage.ToString();

            //c.sendMail("info@shahdevelopers.org", txtEmail.Text, msgDetails, "Enquiry for " + projName , "", true, "", "");
            // c.SendMail("info@shahdevelopers.org", "san.apshah@gmail.com", msgDetails, "Enquiry for " + projName, "aks.shah00@gmail.com", true, "", "");

           // c.SendMail("info@intellect-systems.com", " Samruddhi Cleaning Wares", "pallavidhadake20@gmail.com", strMessage.ToString(), "New Application at  Samruddhi Cleaning Wares", "", true, "", "");

            c.SendMail("info@shahdevelopers.org", "Shah Real Estate Developers", "san.apshah@gmail.com", strMessage.ToString(), "New Enquiry at Shah Developers", "", true, "", "");

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Enquiry submitted. We will contact you soon');", true);

            //errMsg = c.errNotification(1, "Enquiry submitted. We will contact you soon");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }
}