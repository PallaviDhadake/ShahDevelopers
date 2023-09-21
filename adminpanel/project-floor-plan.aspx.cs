using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
public partial class adminpanel_project_floor_plan : System.Web.UI.Page
{
    public iClass c = new iClass();
    public string fpGallery, rootPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            c.FillComboBox("projTitle", "projId", "ProjectData", "delMark=0", "projTitle", 0, ddrProject);

            if (Request.QueryString["delId"] != null)
            {
                int proId = Convert.ToInt32(c.GetReqData("ProjectFloorPlans", "projId", "fpId=" + Request.QueryString["delId"].ToString()));
                string imgName = c.GetReqData("ProjectFloorPlans", "fpImage", "fpId=" + Request.QueryString["delId"].ToString()).ToString();
                c.ExecuteQuery("Delete From ProjectFloorPlans Where fpId=" + Request.QueryString["delId"].ToString());

                string normalImgPath = "~/upload/projects/floorplan/";
                string thumbImgPath = "~/upload/projects/floorplan/thumb/";
                File.Delete(Server.MapPath(normalImgPath) + imgName);
                File.Delete(Server.MapPath(thumbImgPath) + imgName);

              //  errMsg = c.errNotification(1, "Floor Plan Deleted");

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Floor Plan Deleted');", true);

                Response.Redirect("project-floor-plan.aspx?proId=" + proId);
                showFloorPlan();
            }
            if (Request.QueryString["proId"] != null)
            {
                ddrProject.SelectedValue = Request.QueryString["proId"].ToString();
                showFloorPlan();
            }

        }
        lblId.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrProject.SelectedIndex == 0 || flpPhoto.HasFile==false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            //if (flpPhoto.FileName == "")
            //{
            //    errMsg = c.errNotification(2, "Select Image to upload");
            //    return;
            //}
            string fileExt;
            fileExt = Path.GetExtension(flpPhoto.FileName).ToLower();
            string imgName;
            int maxId = c.NextId("ProjectFloorPlans", "fpId");

            if (fileExt == ".jpg" || fileExt == ".png" || fileExt == ".jpeg")
            {
                imgName = "floorplan-" + maxId + fileExt;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only jpg, jpeg and png files are allowed');", true);
                return;
                
            }


            c.ExecuteQuery("Insert Into ProjectFloorPlans (fpId, projId, fpImage) Values (" + maxId + ", " + ddrProject.SelectedValue + ", '" + imgName + "')");
            ImageUploadProcess(imgName);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Floor Plan uploaded');", true);
           //errMsg = c.errNotification(1, "Floor Plan uploaded");
            showFloorPlan();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }

    }


    private void ImageUploadProcess(string nwsPhoto)
    {
        try
        {

            string origImgPath = "~/upload/projects/floorplan/original/";
            string thumbImgPath = "~/upload/projects/floorplan/";
            string normalImgPath = "~/upload/projects/floorplan/thumb/";

            flpPhoto.SaveAs(Server.MapPath(origImgPath) + nwsPhoto);
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

   
    public void showFloorPlan()
    {
        //string routePath = c.ReturnHttp(0);
        DataTable dtFPlans = new DataTable();
        dtFPlans = c.GetDataTable("Select fpId, fpImage From ProjectFloorPlans Where projId=" + ddrProject.SelectedValue);

        StringBuilder strFPGallery = new StringBuilder();

        foreach (DataRow fpRow in dtFPlans.Rows)
        {
            strFPGallery.Append("<div class=\"wrapper-floor\">");
            strFPGallery.Append("<div class=\"floor-plan pad_10\"><span></span><a href=\"project-floor-plan.aspx?delId=" + fpRow["fpId"].ToString() + "\"><img src=\"images/delImg.png\" class=\"delete\"/></a><img src=\"" + Master.rootPath + "upload/projects/floorplan/thumb/" + fpRow["fpImage"].ToString() + "\" class=\"floor-img100\"/></div>");
            strFPGallery.Append("</div>");
        }

        fpGallery = strFPGallery.ToString();
    }


    protected void ddrProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        showFloorPlan();
    }
}