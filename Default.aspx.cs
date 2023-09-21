using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    
    public string currentyear, rootPath, photogalimg, bannerstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        c.ReturnHttp();
        currentyear = DateTime.Now.Year.ToString("");

        BannerImages();
    }




    private void BannerImages()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dtBanner = c.GetDataTable("select  bannerId, imageName, displayOrder from BannerData where delMark=0 order by displayOrder"))
            {
                if (dtBanner.Rows.Count > 0)
                {
                    string className = "";
                    int i = 0;

                    strMarkup.Append("<div class=\"carousel-inner\">");
                    foreach (DataRow row in dtBanner.Rows)
                    {
                        i++;
                        if (i == 1)
                        {
                            className = "active";
                        }
                        else
                        {
                            className = "";
                        }
                        if (c.IsRecordExist("Select bannerId From BannerData Where BannerID=" + row["bannerId"].ToString() + ""))
                        {

                            strMarkup.Append("<div class=\"carousel-item " + className + "\">");
                            if (row["imageName"] != DBNull.Value && row["imageName"].ToString() != "" && row["imageName"].ToString() != "no-photo.png" && row["imageName"] != null)
                            {

                                strMarkup.Append("<img src=\"" + rootPath + "upload/bannerimages/" + row["imageName"].ToString() + "\" alt=\"" + row["imageName"].ToString() + "\" class=\"img-fluid w-100\" />");

                            }
                            else
                            {
                                strMarkup.Append("<img src=\"images/banner1.jpg\" class=\"img-fluid w-100 \">");
                            }
                            strMarkup.Append("</div>");
                        }
                    }
                    strMarkup.Append("</div>");
                    bannerstr = strMarkup.ToString();
                }
                else
                {
                    //strMarkup.Append("<di class=\"item\">");
                    bannerstr = "<img src=\"images/banner1.jpg\" class=\"img-fluid w-100\">";
                    //strMarkup.Append("</div>");
                }
            }
        }
        catch (Exception ex)
        {
            bannerstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    public string GetNewsData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 6 newsId, newsDate, newsTitle, newsInfo, readCount, newsPhoto from NewsData where delMark=0 order by newsId DESC"))
            {
                string className = "";
                int i = 0;
                if (dttest.Rows.Count > 0)
                {
                    strMarkup.Append("<div class=\"carousel-inner\" data-aos=\"fade-right\" data-aos-duration=\"1000\">");

                    foreach (DataRow row in dttest.Rows)
                    {
                        if (c.IsRecordExist("Select newsId From NewsData Where newsId=" + row["newsId"].ToString() + ""))
                        {

                            i++;

                            if (i == 1)
                            {
                                className = "active";
                            }
                            else
                            {
                                className = "";
                            }

                            strMarkup.Append("<div class=\"carousel-item " + className + "\">");
                            strMarkup.Append("<div class=\"p-3\">");
                            strMarkup.Append("<div class=\"row\">");


                                strMarkup.Append("<div class=\"col-xl-6\">");
                                strMarkup.Append("<div class=\"row bg-white g-0\">");

                                strMarkup.Append("<div class=\"col-md-4\">");
                                if (c.IsRecordExist("select newsId from NewsData where newsPhoto='" + row["newsPhoto"].ToString() + "'"))
                                {

                                    strMarkup.Append("<img src=\"" + rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" class=\"w-100 h-100 img-fluid p-0\"/>");

                                }
                                else
                                {
                                    //strMarkup.Append("<img src=\"images/icons/view-anch.png\" class=\"me-2\"/>");
                                    strMarkup.Append("<img src=\"images/shah-defult-news.jpg\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                strMarkup.Append("</div>");

                                strMarkup.Append("<div class=\"col-md-8 shadow\">");
                                strMarkup.Append("<div class=\"p-3\">");
                                string nUrl = rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());
                                string nwsTitle = row["newsTitle"].ToString().Length >= 28 ? row["newsTitle"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                                strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack\">" + nwsTitle + "</a>");
                                strMarkup.Append("<span class=\"space5\"></span>");
                                DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                                strMarkup.Append("<span class=\"fst-italic clrGrey\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                                string nwsDesc = row["newsInfo"].ToString().Length >= 170 ? row["newsInfo"].ToString().Substring(0, 170) + "..." : row["newsInfo"].ToString();
                                strMarkup.Append("<p class=\"light clrmediumgrey line-ht-5 mt-2\">" + nwsDesc + "</p>");
                                strMarkup.Append("<hr />");
                                strMarkup.Append("<img src=\"images/icons/view-anch.png\" class=\"me-2\"/><span class=\"clrGrey me-3\">" + row["readCount"].ToString() + "</span> <span class=\"clrGrey me-2\">By - Admin | Shah Developers</span><a href=\"" + nUrl + "\"><img src=\"images/icons/arr-right.png\" /></a>");
                                //strMarkup.Append("")
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");

                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");


                                //Col another markup
                                strMarkup.Append("<div class=\"col-xl-6\">");
                                strMarkup.Append("<div class=\"row bg-white g-0\">");

                                strMarkup.Append("<div class=\"col-md-4\">");
                                if (c.IsRecordExist("select newsId from NewsData where newsPhoto='" + row["newsPhoto"].ToString() + "'"))
                                {

                                    strMarkup.Append("<img src=\"" + rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" class=\"w-100 h-100 img-fluid p-0\"/>");

                                }
                                else
                                {

                                    strMarkup.Append("<img src=\"images/shah-defult-news.jpg\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                strMarkup.Append("</div>");
                                strMarkup.Append("<div class=\"col-md-8 shadow\">");
                                strMarkup.Append("<div class=\"p-3\">");
                                string nUrl1 = rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());
                                string nwsTitle1 = row["newsTitle"].ToString().Length >= 28 ? row["newsTitle"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                                strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack\">" + nwsTitle + "</a>");
                                strMarkup.Append("<span class=\"space5\"></span>");
                                DateTime nDate1 = Convert.ToDateTime(row["newsDate"]);
                                strMarkup.Append("<span class=\"fst-italic clrGrey\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                                string nwsDesc1 = row["newsInfo"].ToString().Length >= 170 ? row["newsInfo"].ToString().Substring(0, 170) + "..." : row["newsInfo"].ToString();
                                strMarkup.Append("<p class=\"light clrmediumgrey line-ht-5 mt-2\">" + nwsDesc + "</p>");
                                strMarkup.Append("<hr />");
                                strMarkup.Append("<img src=\"images/icons/view-anch.png\" class=\"me-2\"/><span class=\"clrGrey me-3\">" + row["readCount"].ToString() + "</span> <span class=\"clrGrey me-2\">By - Admin | Shah Developers</span><a href=\"" + nUrl + "\"><img src=\"images/icons/arr-right.png\" /></a>");
                                //strMarkup.Append("")
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                           

                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");

                        }
                    }
                    strMarkup.Append("</div>");
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }




    public string GetNewsData1()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 6 newsId, newsDate, newsTitle, newsInfo, readCount, newsPhoto from NewsData where delMark=0 order by newsId DESC"))
            {
                int i = 0;
                if (dttest.Rows.Count > 0)
                {
                    strMarkup.Append("<div class=\"carousel-inner\" data-aos=\"fade-right\" data-aos-duration=\"1000\">");

                    foreach (DataRow row in dttest.Rows)
                    {
                        if (c.IsRecordExist("Select newsId From NewsData Where newsId=" + row["newsId"].ToString() + ""))
                        {
                            i++;

                            // Determine the class name for active item
                            string className = (i == 1) ? "active" : "";

                            // Start of the carousel item
                            strMarkup.Append("<div class=\"carousel-item " + className + "\">");
                            strMarkup.Append("<div class=\"p-3\">");
                            strMarkup.Append("<div class=\"row\">");

                            // Determine which column the content should go into
                            if (i % 2 == 1)
                            {
                                // Column 1 Markup
                                strMarkup.Append("<div class=\"col-xl-6\">");
                                strMarkup.Append("<div class=\"row bg-white g-0\">");
                                strMarkup.Append("<div class=\"col-md-4\">");
                                if (c.IsRecordExist("select newsId from NewsData where newsPhoto='" + row["newsPhoto"].ToString() + "'"))
                                {
                                    strMarkup.Append("<img src=\"" + rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                else
                                {
                                    strMarkup.Append("<img src=\"images/shah-defult-news.jpg\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                strMarkup.Append("</div>");

                                // ... Rest of the column 1 markup

                                strMarkup.Append("<div class=\"col-md-8 shadow\">");
                                strMarkup.Append("<div class=\"p-3\">");
                                string nUrl = rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());
                                string nwsTitle = row["newsTitle"].ToString().Length >= 28 ? row["newsTitle"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                                strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack\">" + nwsTitle + "</a>");
                                strMarkup.Append("<span class=\"space5\"></span>");
                                DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                                strMarkup.Append("<span class=\"fst-italic clrGrey\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                                string nwsDesc = row["newsInfo"].ToString().Length >= 170 ? row["newsInfo"].ToString().Substring(0, 170) + "..." : row["newsInfo"].ToString();
                                strMarkup.Append("<p class=\"light clrmediumgrey line-ht-5 mt-2\">" + nwsDesc + "</p>");
                                strMarkup.Append("<hr />");
                                strMarkup.Append("<img src=\"images/icons/view-anch.png\" class=\"me-2\"/><span class=\"clrGrey me-3\">" + row["readCount"].ToString() + "</span> <span class=\"clrGrey me-2\">By - Admin | Shah Developers</span><a href=\"" + nUrl + "\"><img src=\"images/icons/arr-right.png\" /></a>");
                                //strMarkup.Append("")
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                // Close the column 1 markup
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                            }
                            else
                            {
                                // Column 2 Markup
                                strMarkup.Append("<div class=\"col-xl-6\">");
                                strMarkup.Append("<div class=\"row bg-white g-0\">");
                                strMarkup.Append("<div class=\"col-md-4\">");
                                if (c.IsRecordExist("select newsId from NewsData where newsPhoto='" + row["newsPhoto"].ToString() + "'"))
                                {
                                    strMarkup.Append("<img src=\"" + rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                else
                                {
                                    strMarkup.Append("<img src=\"images/shah-defult-news.jpg\" class=\"w-100 h-100 img-fluid p-0\"/>");
                                }
                                strMarkup.Append("</div>");

                                strMarkup.Append("<div class=\"col-md-8 shadow\">");
                                strMarkup.Append("<div class=\"p-3\">");
                                string nUrl = rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());
                                string nwsTitle = row["newsTitle"].ToString().Length >= 28 ? row["newsTitle"].ToString().Substring(0, 39) + "..." : row["newsTitle"].ToString();
                                strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium line-ht-5 mb-2 newstitle text-decoration-none colorBlack\">" + nwsTitle + "</a>");
                                strMarkup.Append("<span class=\"space5\"></span>");
                                DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                                strMarkup.Append("<span class=\"fst-italic clrGrey\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                                string nwsDesc = row["newsInfo"].ToString().Length >= 170 ? row["newsInfo"].ToString().Substring(0, 170) + "..." : row["newsInfo"].ToString();
                                strMarkup.Append("<p class=\"light clrmediumgrey line-ht-5 mt-2\">" + nwsDesc + "</p>");
                                strMarkup.Append("<hr />");
                                strMarkup.Append("<img src=\"images/icons/view-anch.png\" class=\"me-2\"/><span class=\"clrGrey me-3\">" + row["readCount"].ToString() + "</span> <span class=\"clrGrey me-2\">By - Admin | Shah Developers</span><a href=\"" + nUrl + "\"><img src=\"images/icons/arr-right.png\" /></a>");
                                //strMarkup.Append("")
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                                // Close the column 2 markup
                                strMarkup.Append("</div>");
                                strMarkup.Append("</div>");
                            }

                            // Close the row and carousel item
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</div>");
                        }
                    }

                    // Close the carousel-inner div
                    strMarkup.Append("</div>");
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }



    public string GetTestData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 3 testId, testDate, testPerson, cityName, testComment from TestimonialData where delMark=0 order by testId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {

                    foreach (DataRow row in dttest.Rows)
                    {

                        if (c.IsRecordExist("Select testId From TestimonialData Where testId=" + row["TestId"].ToString() + ""))
                        {

                            strMarkup.Append("<div class=\"col-lg-4\"  data-aos=\"fade-right\"  data-aos-duration=\"1000\">");

                            strMarkup.Append("<a href=\"testimonials#"+row["testId"].ToString()+"\" class=\"txtDecNo colorBlack\">");
                            strMarkup.Append("<div class=\"p-3\">");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            DateTime nDate = Convert.ToDateTime(row["testDate"]);
                            strMarkup.Append("<span class=\"clrGrey light small\">"+nDate.ToString("dd.MM.yyyy")+"</span>");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            strMarkup.Append("<h4 class=\"semiBold semiMedium eventheading\">"+row["testPerson"].ToString()+"</h4>");
                            strMarkup.Append("<span class=\"clrGrey small\">Happy Buyer</span>");
                            strMarkup.Append("<hr />");
                            string testdesc = row["testComment"].ToString().Length >= 171 ? row["testComment"].ToString().Substring(0, 171) + "..." : row["testComment"].ToString();
                            strMarkup.Append("<a href=\"testimonials#" + row["testId"].ToString() + "\" class=\"semiBold fontRegular text-decoration-none colorBlack readevnt\">Read More <img src=\"images/icons/rght-icon.png\" class=\"ms-2\"/></a>");
                            strMarkup.Append("</div>");
                            strMarkup.Append("</a>");
                            strMarkup.Append("</div>");
                        }
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }



    public string GetPhotoGal()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 4 pgId, pgImage from ProjectGallery order by pgId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {
                    //strMarkup.Append("<div class=\"col-md-6\" data-aos=\"zoom-in\" data-aos-duration=\"1000\">");
                    foreach (DataRow row in dttest.Rows)
                    {
                        strMarkup.Append("<div class=\"col-md-6\" data-aos=\"zoom-in\" data-aos-duration=\"1000\">");
                        strMarkup.Append("<a href=\""+rootPath+ "upload/projects/gallery/" + row["pgImage"].ToString()+ "\" data-fancybox=\"group2\">");
                        strMarkup.Append("<img src=\"" + rootPath + "upload/projects/gallery/thumb/" + row["pgImage"].ToString() + "\" class=\"img-fluid\" style=\"width:400px; height:250px;\">");
                        strMarkup.Append("</a>");
                        strMarkup.Append("</div>");

                        //photogalimg = strMarkup.Append("<img src=\"" + rootPath + "upload/projects/gallery/" + row["pgImage"].ToString() + "\"/>").ToString();
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }


    public string GetTopProjects()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select TOP 3 projId, projTitle, projInfo, projPhoto, addressData, builtArea, StartPrice  from ProjectData order by projId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {
                    //strMarkup.Append("<div class=\"col-md-6\" data-aos=\"zoom-in\" data-aos-duration=\"1000\">");
                    foreach (DataRow row in dttest.Rows)
                    {

                        strMarkup.Append("<div class=\"col-lg-4\" data-aos=\"fade-down\" data-aos-easing=\"linear\" data-aos-duration=\"1500\" id=\"top1\">");
                        strMarkup.Append("<div class=\"image-zoom\" style=\"height:210px;\">");
                        strMarkup.Append("<img src=\"" + rootPath + "upload/projects/thumb/" + row["projPhoto"].ToString() + "\" class=\"img-fluid shadow\">");
                        strMarkup.Append("</div>");

                        strMarkup.Append("<div class=\"p-4 bg-white shadow\">");
                        strMarkup.Append("<p class=\"semiBold semiMedium colorPrime mb-2 projtitle\">"+row["projTitle"].ToString() +"</p>");
                        strMarkup.Append("<p class=\"clrGrey light mb-2\"><b class=\"semiBold\">Address :</b>" + row["addressData"].ToString() + "</p>");
                        strMarkup.Append("<p class=\"clrGrey light mb-2\"><b class=\"semiBold\">Saleable Area :</b>"+row["builtArea"].ToString() +"</p>");
                        strMarkup.Append("<p class=\"clrGrey light mb-2\"><b class=\"semiBold\">Price :</b>" + row["StartPrice"].ToString() + "</p>");

                        string projinfo = row["projInfo"].ToString().Length >= 102 ? row["projInfo"].ToString().Substring(0, 102) + "..." : row["projInfo"].ToString();

                        strMarkup.Append("<p class=\"light clrmediumgrey line-ht-5 mt-2\">"+ projinfo + "</p>");
                        strMarkup.Append("<a href=\"projects\" class=\"text-decoration-none\">View More <ims src=\"images/icons/nws-slide-arr-nxt.png\" class=\"ms-3\"/></a>");
                        strMarkup.Append("</div>");
                        //strMarkup.Append("<a href=\"" + rootPath + "upload/projects/gallery/" + row["pgImage"].ToString() + "\" data-fancybox=\"group2\">");
                       
                        //strMarkup.Append("</a>");

                        
                        strMarkup.Append("</div>");

                        //photogalimg = strMarkup.Append("<img src=\"" + rootPath + "upload/projects/gallery/" + row["pgImage"].ToString() + "\"/>").ToString();
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

}