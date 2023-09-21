using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class adminpanel_news_master : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, nwsPhoto, rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add News" : "Edit News";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    editNews.Visible = true;
                    viewNews.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        btnRemove.Visible = false;
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetNewsData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
                else
                {
                    editNews.Visible = false;
                    viewNews.Visible = true;
                    FillGrid();
                }
            }
            lblId.Visible = false;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }
    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select newsId, Convert(varchar(20), newsDate, 103) as newsDate, newsTitle, readCount From NewsData Where delMark=0 Order By newsDate DESC"))
            {
                gvNews.DataSource = dtNws;
                gvNews.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvNews.UseAccessibleHeader = true;
                    gvNews.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }
    public void GetAllControls(ControlCollection ctrs)
    {
        foreach (Control c in ctrs)
        {
            if (c is System.Web.UI.WebControls.TextBox)
            {
                TextBox tt = c as TextBox;
                tt.Text = tt.Text.Trim().Replace("'", "");
            }
            if (c.HasControls())
            {
                GetAllControls(c.Controls);
            }
        }
    }
    public void GetNewsData(int NwsIdx)
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("select * from NewsData where newsId=" + NwsIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    lblId.Text = NwsIdx.ToString();
                    txtDate.Text = Convert.ToDateTime(row["newsDate"]).ToString("dd/MM/yyyy");
                    txtNwsTitl.Text = row["newsTitle"].ToString();
                    txtNwsDesc.Text = row["newsInfo"].ToString();


                    if (row["newsPhoto"] != DBNull.Value && row["newsPhoto"] != null && row["newsPhoto"].ToString() != "" && row["newsPhoto"].ToString() != "no-photo.png")
                    {
                        nwsPhoto = "<img src=\"" + Master.rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" width=\"200\" />";
                        btnRemove.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetNewsData", ex.Message.ToString());
            return;
        }
    }

    private void ImageUploadProcess(string nwsPhoto)
    {
        try
        {

            string origImgPath = "~/upload/news/original/";
            string thumbImgPath = "~/upload/news/thumb/";
            string normalImgPath = "~/upload/news/";

            fuImage.SaveAs(Server.MapPath(origImgPath) + nwsPhoto);
            c.ImageOptimizer(nwsPhoto, origImgPath, normalImgPath, 800, true);
            c.ImageOptimizer(nwsPhoto, normalImgPath, thumbImgPath, 480, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + nwsPhoto);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update NewsData set newsPhoto='no-photo.png' where newsId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Removed');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('news-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllControls(this.Controls);
            //Empty Validations
            if (txtDate.Text == "" || txtNwsTitl.Text == "" || txtNwsDesc.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            //Insert Update data
            int maxId = lblId.Text == "[New]" ? c.NextId("NewsData", "newsId") : Convert.ToInt32(lblId.Text);

            DateTime appDate = DateTime.Now;
            string[] arrDate = txtDate.Text.Split('/');
            if (c.IsDate(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Date');", true);
                return;
            }
            else
            {
                appDate = Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]);
            }

            DateTime cDate = DateTime.Now;
            string currentDate = cDate.ToString("yyyy-MM-dd HH:mm:ss.fff");


            string nwsPhoto = "";
            if (fuImage.HasFile)
            {
                string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    nwsPhoto = "news-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess(nwsPhoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                    return;

                }
            }

            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert into NewsData(newsId, newsTitle, newsInfo, newsDate,  readCount, delMark )Values(" + maxId + ", '" + txtNwsTitl.Text + "', '" + txtNwsDesc.Text + "', '" + appDate + "', 0, 0)");
                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update NewsData Set newsPhoto='" + nwsPhoto + "' where newsId=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'News  Added');", true);
            }

            else
            {
                c.ExecuteQuery("Update NewsData set newsDate='" + appDate + "', newsTitle='" + txtNwsTitl.Text + "', newsInfo='" + txtNwsDesc.Text + "' where newsId=" + maxId);

                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update NewsData Set newsPhoto='" + nwsPhoto + "' where newsId=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'News  Updated');", true);
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('news-master.aspx', 2000);", true);

            txtDate.Text = txtNwsTitl.Text = txtNwsDesc.Text = "";
            fuImage.Visible = false;

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            c.ExecuteQuery("update NewsData set delMark=1 where newsId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('news-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("news-master.aspx");
    }
    protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"news-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvNews_RowDataBound", ex.Message.ToString());
            return;
        }
    }
}
