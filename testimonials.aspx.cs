using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class testimonials : System.Web.UI.Page
{
    iClass c = new iClass();
    public string teststr;
    protected void Page_Load(object sender, EventArgs e)
    {

        TestimonialsMarkup();

    }


    private void TestimonialsMarkup()
    {
        try
        {
            using (DataTable dtnws = c.GetDataTable("select testId, testDate, testPerson, orgName, cityName, testComment from TestimonialData where delMark=0 Order By testDate desc, testId desc"))
            {
                if (dtnws.Rows.Count > 0)
                {
                    
                    StringBuilder strMarkup = new StringBuilder();
                    strMarkup.Append("<div class=\"masonry\">");
                    foreach (DataRow row in dtnws.Rows)
                    {
                        strMarkup.Append("<div class=\"item\" id=\"" + row["testId"] + "\">");
                        strMarkup.Append("<div class=\"card mb-3\">");
                        strMarkup.Append("<div class=\"card-header\">"+ row["orgName"].ToString() +"</div>");
                        strMarkup.Append("<div class=\"card-body\">");
                        strMarkup.Append("<blockquote class=\"blockquote mb-0\">");
                        strMarkup.Append("<p class=\"light line-ht-5 tiny\">"+row["testComment"] +"</p>");
                        strMarkup.Append("<footer class=\"blockquote-footer light line-ht-5 colorPrime semiBold mt-3\">" +row["testPerson"].ToString()+ "</footer>");

                        strMarkup.Append("</blockquote>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                    }
                    strMarkup.Append("</div>");
                    teststr = strMarkup.ToString();
                }
                else
                {
                    teststr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            teststr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }


}