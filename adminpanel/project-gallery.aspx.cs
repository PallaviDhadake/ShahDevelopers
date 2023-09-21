using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
public partial class adminpanel_project_gallery : System.Web.UI.Page
{
    iClass c = new iClass();
    public string projGallery;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            c.FillComboBox("projTitle", "projId", "ProjectData", "delMark=0", "projTitle", 0, ddrProject);
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["delId"] != null)
            {
                int proId = Convert.ToInt32(c.GetReqData("ProjectGallery", "projId", "pgId=" + Request.QueryString["delId"].ToString()));
                string imgName = c.GetReqData("ProjectGallery", "pgImage", "pgId=" + Request.QueryString["delId"].ToString()).ToString();
                c.ExecuteQuery("Delete From ProjectGallery Where pgId=" + Request.QueryString["delId"].ToString());

                string normalImgPath = "~/upload/projects/gallery/";
                string thumbImgPath = "~/upload/projects/gallery/thumb/";
                File.Delete(Server.MapPath(normalImgPath) + imgName);
                File.Delete(Server.MapPath(thumbImgPath) + imgName);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Image Deleted');", true);
                //errMsg = c.errNotification(1, "Image Deleted");
                Response.Redirect("project-gallery.aspx?proId=" + proId);
                showGallery();
            }
            if (Request.QueryString["proId"] != null)
            {
                ddrProject.SelectedValue = Request.QueryString["proId"].ToString();
                showGallery();
            }
        }
        lblId.Visible = false;
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrProject.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Project Name');", true);
                return;
                //errMsg = c.errNotification(2, "Select Project Name");
                //return;
            }

            if (flpPhoto.FileName == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Image to upload');", true);
               // errMsg = c.errNotification(2, "Select Image to upload");
                return;
            }
            string fileExt;
            fileExt = Path.GetExtension(flpPhoto.FileName).ToLower();
            string imgName;
            int maxId = c.NextId("ProjectGallery", "pgId");

            if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".jpeg")
            {
                imgName = "pro-gallery-" + maxId + fileExt;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only jpg, jpeg and png files are allowed');", true);
                //errMsg = c.errNotification(2, "Only jpg, jpeg and png files are allowed");
                return;
            }


            c.ExecuteQuery("Insert Into ProjectGallery (pgId, projId, pgImage) Values (" + maxId + ", " + ddrProject.SelectedValue + ", '" + imgName + "')");
            ImageUploadProcess(imgName);
           // errMsg = c.errNotification(1, "Image uploaded");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Image uploaded');", true);
            showGallery();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }


    private void ImageUploadProcess(string imgName)
    {
        try
        {

            string origImgPath = "~/upload/projects/gallery/original/";
            string thumbImgPath = "~/upload/projects/gallery/";
            string normalImgPath = "~/upload/projects/gallery/thumb/";

            flpPhoto.SaveAs(Server.MapPath(origImgPath) + imgName);
            c.ImageOptimizer(imgName, origImgPath, normalImgPath, 800, true);
            c.ImageOptimizer(imgName, normalImgPath, thumbImgPath, 480, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + imgName);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }

    public void showGallery()
    {
        //string routePath = c.returnHttp(0);
        DataTable dtFPlans = new DataTable();
        dtFPlans = c.GetDataTable("Select pgId, pgImage From ProjectGallery Where projId=" + ddrProject.SelectedValue);

        StringBuilder strProjGallery = new StringBuilder();

        foreach (DataRow fpRow in dtFPlans.Rows)
        {
            strProjGallery.Append("<div class=\"wrapper-floor\">");
            strProjGallery.Append("<div class=\"floor-plan pad_10\"><span></span><a href=\"project-gallery.aspx?delId=" + fpRow["pgId"].ToString() + "\"><img src=\"images/delImg.png\" class=\"delete\"/></a><img src=\"" + Master.rootPath + "upload/projects/gallery/thumb/" + fpRow["pgImage"].ToString() + "\" class=\"floor-img100\"/></div>");
            strProjGallery.Append("</div>");
        }

        projGallery = strProjGallery.ToString();
    }


    protected void ddrProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        showGallery();
    }
}