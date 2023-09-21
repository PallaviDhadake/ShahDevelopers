using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;

public partial class news : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, nwsstr, bCrumbStr;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Page.RouteData.Values["newsId"].ToString()))
                {
                    NewsMarkup();
                }
                else
                {
                    string[] arrLinks = Page.RouteData.Values["newsId"].ToString().Split('-');
                    GetNewsDetails(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));

                }
            }
        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }



    private void NewsMarkup()
    {
        try
        {
            using (DataTable dtnws = c.GetDataTable("select newsId, newsDate, newsTitle, LEFT(newsInfo, 150) as newsInfo, newsPhoto from NewsData where delMark=0 Order By newsDate desc, newsId desc"))
            {
                if (dtnws.Rows.Count > 0)
                {
                    int ncount=1;
                    StringBuilder strMarkup = new StringBuilder();
                    foreach (DataRow row in dtnws.Rows)
                    {

                        if (c.IsRecordExist("Select newsId From NewsData where newsPhoto='" + row["newsPhoto"].ToString() + "'"))
                        {
                            strMarkup.Append("<div class=\"col-lg-4\">");
                            if (row["newsPhoto"] != DBNull.Value && row["newsPhoto"].ToString() != "" && row["newsPhoto"].ToString() != "no-photo.png" && row["newsPhoto"] != null)
                            {
                                strMarkup.Append("<img src=\"" + Master.rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + " \" alt=\"" + row["newsTitle"].ToString() + " \"  class=\"img-fluid\" >");

                            }
                            strMarkup.Append("</div>");
                        }
                        strMarkup.Append("<div class=\"col-lg-8\" id=\"" + row["newsId"] +"\">");
                        string nUrl = Master.rootPath + "news/" + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());

                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium colorPrime text-decoration-none\">" + row["newsTitle"].ToString() + "</a>");
                        strMarkup.Append("<span class=\"space5\"></span>");

                        DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                        strMarkup.Append("<span class=\"clrGrey fst-italic\">" + nDate.ToString("dd MMM yyyy") + "</span>");
                        strMarkup.Append("<span class=\"light clrGrey\">Shah Developers | " + nDate.ToString("dd/mm/yyyy") + "</span>");
                        strMarkup.Append("<span class=\"space5\"></span>");

                       string nwsData = row["newsInfo"].ToString().Length >= 300 ? row["newsInfo"].ToString().Substring(0, 300) + "..." : row["newsInfo"].ToString();

                        strMarkup.Append("<p class=\"fontRegular light line-ht-7 mb-2\">" + nwsData + "</p>");
                        strMarkup.Append("<a href=\""+ nUrl + "\" class=\"text-decoration-none\">Continue Reading...</a>");
                        
                        strMarkup.Append("</div>");

                        if (ncount < dtnws.Rows.Count)
                        {
                            strMarkup.Append("<span class=\"greyLine\"></span>");
                        }
                        ncount++;
                    }
                    nwsstr = strMarkup.ToString();
                }
                else
                {
                    nwsstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    private void GetNewsDetails(int NwsIdx)
    {
        try
        {
            c.ExecuteQuery("Update NewsData Set readCount=readCount+1 Where newsId=" + NwsIdx);
            using (DataTable dtNws = c.GetDataTable("Select * From NewsData Where newsId=" + NwsIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    StringBuilder strMarkup = new StringBuilder();

                    this.Title = row["newsTitle"].ToString() + "| Latest News, Events of Shah Developers.";

                    strMarkup.Append("<h2 class=\"pageH2 themeClrPrime mrg_B_5 capitalize\">" + row["newsTitle"].ToString() + "</h2>");
                    DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                    strMarkup.Append("<span class=\"newspost\">Admin | " + nDate.ToString("dd MMM yyyy") + "</span>");

                    //strMarkup.Append("<span class=\"space10\"></span>");
                    strMarkup.Append("<span class=\"semiMedium themeClrQtr fontRegular\">Total Views : " + row["readCount"].ToString() + "</span>");
                    //strMarkup.Append("<span class=\"space20\"></span>");

                    //Sharing Options
                    strMarkup.Append("<div class=\"a2a_kit a2a_kit_size_24 a2a_default_style\" >");
                    strMarkup.Append("<a class=\"a2a_dd\" href=\"https://www.addtoany.com/share\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_facebook\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_twitter\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_google_plus\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_pinterest\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_email\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_linkedin\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_reddit\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_stumbleupon\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_digg\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_tumblr\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_whatsapp\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_blogger_post\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_delicious\"></a>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("<script async src=\"https://static.addtoany.com/menu/page.js\"></script>");

                    //Add Page sharing links code here
                    strMarkup.Append("<div class=\"float_clear\"></div>");
                    //strMarkup.Append("<div class=\"space20\"></div>");

                    if (row["newsPhoto"] != DBNull.Value && row["newsPhoto"].ToString() != "" && row["newsPhoto"].ToString() != "no-photo.png" && row["newsPhoto"] != null)

                        strMarkup.Append("<img src=\"" + Master.rootPath + "/upload/news/" + row["newsPhoto"].ToString() + " \" alt=\"" + row["newsTitle"].ToString() + " \"  class=\"img-fluid\" >");

                    strMarkup.Append("<p class=\"paraTxt\">" + Regex.Replace(row["newsInfo"].ToString(), @"\r\n?|\n", "<br />") + "</p>");

                    nwsstr = strMarkup.ToString();
                    
                    strMarkup.Append("<div class=\"float_clear\">");
                }
            }

        }
        catch (Exception ex)
        {
            nwsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }

}