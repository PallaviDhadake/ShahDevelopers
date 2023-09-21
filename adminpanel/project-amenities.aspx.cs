using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminpanel_project_amenities : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillProjectList();
            proAmenities.Visible = false;
            plotAmenities.Visible = false;
        }
    }

    public void fillProjectList()
    {
        c.FillComboBox("projTitle", "projId", "ProjectData", "delMark=0", "projTitle", 0, ddrProject);
        c.FillComboBox("agName", "agId", "AmenityGroup", "delMark=0", "agName", 0, ddrOAmenities);
    }


    protected void ddrProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        showAmenities();
        gvAmenities.DataSource = null;
        gvAmenities.DataBind();
        ddrOAmenities.SelectedIndex = 0;
    }

    public void showAmenities()
    {
        try
        {

        
        int projType = Convert.ToInt32(c.GetReqData("ProjectData", "projCategory", "projId=" + ddrProject.SelectedValue));


            if (c.IsRecordExist("Select * From ProjectAmenitiesBasic Where projId=" + ddrProject.SelectedValue) == true)
            {

                DataTable dtAmenities = new DataTable();
                dtAmenities = c.GetDataTable("Select * From ProjectAmenitiesBasic Where projId=" + ddrProject.SelectedValue);
                DataRow amRow = dtAmenities.Rows[0];

                if (projType == 4)
                {
                    proAmenities.Visible = false;
                    plotAmenities.Visible = true;
                    OtherAmenities.Visible = false;

                    chkPlotRoads.Checked = (Convert.ToInt32(amRow["amPlotRoads"]) == 0) ? false : true;
                    chkPlotElec.Checked = (Convert.ToInt32(amRow["amPlotElec"]) == 0) ? false : true;
                    chkPlotWater.Checked = (Convert.ToInt32(amRow["amPlotWater"]) == 0) ? false : true;
                    chkPlotDrainage.Checked = (Convert.ToInt32(amRow["amPlotDrainage"]) == 0) ? false : true;
                    chkPlotGarden.Checked = (Convert.ToInt32(amRow["amPlotGarden"]) == 0) ? false : true;
                    chkPlotPlay.Checked = (Convert.ToInt32(amRow["amPlotPlay"]) == 0) ? false : true;
                    chkPlotStrLight.Checked = (Convert.ToInt32(amRow["amPlotStrLight"]) == 0) ? false : true;
                    chkPlotHarvest.Checked = (Convert.ToInt32(amRow["amPlotHarvest"]) == 0) ? false : true;
                }
                else
                {
                    proAmenities.Visible = true;
                    plotAmenities.Visible = false;
                    OtherAmenities.Visible = true;

                    chkLift.Checked = (Convert.ToInt32(amRow["amLift"]) == 0) ? false : true;
                    chkSecurity.Checked = (Convert.ToInt32(amRow["amSecurity"]) == 0) ? false : true;
                    chkPlayArea.Checked = (Convert.ToInt32(amRow["amPlayArea"]) == 0) ? false : true;
                    chkPowerBK.Checked = (Convert.ToInt32(amRow["amPowerBkp"]) == 0) ? false : true;
                    chkSwimmingPool.Checked = (Convert.ToInt32(amRow["amPool"]) == 0) ? false : true;
                    chkGymnasium.Checked = (Convert.ToInt32(amRow["amGym"]) == 0) ? false : true;
                    chkJoggingTrk.Checked = (Convert.ToInt32(amRow["amJogging"]) == 0) ? false : true;
                    chkInternet.Checked = (Convert.ToInt32(amRow["amInternet"]) == 0) ? false : true;
                    chkGarden.Checked = (Convert.ToInt32(amRow["amGarden"]) == 0) ? false : true;
                    chkLibrary.Checked = (Convert.ToInt32(amRow["amLibrary"]) == 0) ? false : true;
                    chkCommunityHall.Checked = (Convert.ToInt32(amRow["amCommHall"]) == 0) ? false : true;
                    chkInternalrd.Checked = (Convert.ToInt32(amRow["amIntrRoads"]) == 0) ? false : true;
                }
                btnSave.Text = "Modify";


            }
            else
            {
                if (projType == 4)
                {
                    proAmenities.Visible = false;
                    plotAmenities.Visible = true;
                    OtherAmenities.Visible = false;

                    chkPlotRoads.Checked = false;
                    chkPlotElec.Checked = false;
                    chkPlotWater.Checked = false;
                    chkPlotDrainage.Checked = false;
                    chkPlotGarden.Checked = false;
                    chkPlotPlay.Checked = false;
                    chkPlotStrLight.Checked = false;
                    chkPlotHarvest.Checked = false;
                }
                else
                {

                    proAmenities.Visible = true;
                    plotAmenities.Visible = false;
                    OtherAmenities.Visible = true;

                    chkLift.Checked = false;
                    chkSecurity.Checked = false;
                    chkPlayArea.Checked = false;
                    chkPowerBK.Checked = false;
                    chkSwimmingPool.Checked = false;
                    chkGymnasium.Checked = false;
                    chkJoggingTrk.Checked = false;
                    chkInternet.Checked = false;
                    chkGarden.Checked = false;
                    chkLibrary.Checked = false;
                    chkCommunityHall.Checked = false;
                    chkInternalrd.Checked = false;

                }
                btnSave.Text = "Save";
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "showAmenities", ex.Message.ToString());
            return;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int projType = Convert.ToInt32(c.GetReqData("ProjectData", "projCategory", "projId=" + ddrProject.SelectedValue));
            int[] arrAmenities = new int[12];
            if (projType == 4)
            {
                if (chkPlotDrainage.Checked == false && chkPlotElec.Checked == false && chkPlotGarden.Checked == false && chkPlotHarvest.Checked == false && chkPlotPlay.Checked == false && chkPlotRoads.Checked == false && chkPlotStrLight.Checked == false && chkPlotWater.Checked == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'No amenities selected');", true);
                    return;
                    
                }
                arrAmenities[0] = (chkPlotRoads.Checked == true) ? 1 : 0;
                arrAmenities[1] = (chkPlotElec.Checked == true) ? 1 : 0;
                arrAmenities[2] = (chkPlotWater.Checked == true) ? 1 : 0;
                arrAmenities[3] = (chkPlotDrainage.Checked == true) ? 1 : 0;
                arrAmenities[4] = (chkPlotGarden.Checked == true) ? 1 : 0;
                arrAmenities[5] = (chkPlotPlay.Checked == true) ? 1 : 0;
                arrAmenities[6] = (chkPlotStrLight.Checked == true) ? 1 : 0;
                arrAmenities[7] = (chkPlotHarvest.Checked == true) ? 1 : 0;

                if (c.IsRecordExist("Select * From ProjectAmenitiesBasic Where projId=" + ddrProject.SelectedValue) == true)
                {
                    //update
                    c.ExecuteQuery("Update ProjectAmenitiesBasic Set amPlotRoads=" + arrAmenities[0] + ", amPlotElec=" + arrAmenities[1] + ", amPlotWater=" + arrAmenities[2] + ", amPlotDrainage=" + arrAmenities[3] + ", amPlotGarden=" + arrAmenities[4] + ", amPlotPlay=" + arrAmenities[5] + ", amPlotStrLight=" + arrAmenities[6] + ", amPlotHarvest=" + arrAmenities[7] + " Where projId=" + ddrProject.SelectedValue);

                }
                else
                {
                    //insert
                    c.ExecuteQuery("Insert Into ProjectAmenitiesBasic (projId, amPlotRoads, amPlotElec, amPlotWater, amPlotDrainage, amPlotGarden, amPlotPlay, amPlotStrLight, amPlotHarvest ) Values (" + ddrProject.SelectedValue + ", " + arrAmenities[0] + ", " + arrAmenities[1] + ", " + arrAmenities[2] + ", " + arrAmenities[3] + ", " + arrAmenities[4] + ", " + arrAmenities[5] + ", " + arrAmenities[6] + ", " + arrAmenities[7] + ")");
                }

            }
            else
            {
                if (chkLift.Checked == false && chkSecurity.Checked == false && chkPlayArea.Checked == false && chkPowerBK.Checked == false && chkSwimmingPool.Checked == false && chkGymnasium.Checked == false && chkJoggingTrk.Checked == false && chkInternet.Checked == false && chkGarden.Checked == false && chkLibrary.Checked == false && chkCommunityHall.Checked == false && chkInternalrd.Checked == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'No amenities selected');", true);
                    return;
                }



                arrAmenities[0] = (chkLift.Checked == true) ? 1 : 0;
                arrAmenities[1] = (chkSecurity.Checked == true) ? 1 : 0;
                arrAmenities[2] = (chkPlayArea.Checked == true) ? 1 : 0;
                arrAmenities[3] = (chkPowerBK.Checked == true) ? 1 : 0;
                arrAmenities[4] = (chkSwimmingPool.Checked == true) ? 1 : 0;
                arrAmenities[5] = (chkGymnasium.Checked == true) ? 1 : 0;
                arrAmenities[6] = (chkJoggingTrk.Checked == true) ? 1 : 0;
                arrAmenities[7] = (chkInternet.Checked == true) ? 1 : 0;
                arrAmenities[8] = (chkGarden.Checked == true) ? 1 : 0;
                arrAmenities[9] = (chkLibrary.Checked == true) ? 1 : 0;
                arrAmenities[10] = (chkCommunityHall.Checked == true) ? 1 : 0;
                arrAmenities[11] = (chkInternalrd.Checked == true) ? 1 : 0;

                if (c.IsRecordExist("Select * From ProjectAmenitiesBasic Where projId=" + ddrProject.SelectedValue) == true)
                {
                    //update
                    c.ExecuteQuery("Update ProjectAmenitiesBasic Set amLift=" + arrAmenities[0] + ", amSecurity=" + arrAmenities[1] + ", amPlayArea=" + arrAmenities[2] + ", amPowerBkp=" + arrAmenities[3] + ", amPool=" + arrAmenities[4] + ", amGym=" + arrAmenities[5] + ", amJogging=" + arrAmenities[6] + ", amInternet=" + arrAmenities[7] + ", amGarden=" + arrAmenities[8] + ", amLibrary=" + arrAmenities[9] + ", amCommHall=" + arrAmenities[10] + ", amIntrRoads=" + arrAmenities[11] + " Where projId=" + ddrProject.SelectedValue);

                }
                else
                {
                    //insert
                    c.ExecuteQuery("Insert Into ProjectAmenitiesBasic (projId, amLift, amSecurity, amPlayArea, amPowerBkp, amPool, amGym, amJogging, amInternet, amGarden, amLibrary, amCommHall, amIntrRoads) Values (" + ddrProject.SelectedValue + ", " + arrAmenities[0] + ", " + arrAmenities[1] + ", " + arrAmenities[2] + ", " + arrAmenities[3] + ", " + arrAmenities[4] + ", " + arrAmenities[5] + ", " + arrAmenities[6] + ", " + arrAmenities[7] + ", " + arrAmenities[8] + ", " + arrAmenities[9] + ", " + arrAmenities[10] + ", " + arrAmenities[11] + ")");
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Amenities updated');", true);
            //errMsg = c.errNotification(1, "Amenities updated");


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    protected void ddrOAmenities_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtOtherAmn = new DataTable();
            dtOtherAmn = c.GetDataTable("Select a.aiId, a.aiName, b.projId From AmenityItems a Left Outer Join ProjectAmenities b On a.aiId=b.aiId AND b.projId=" + ddrProject.SelectedValue + " Where a.agId=" + ddrOAmenities.SelectedValue);

            gvAmenities.DataSource = dtOtherAmn;
            gvAmenities.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ddrOAmenities_SelectedIndexChanged", ex.Message.ToString());
            return;
        }
    }

   
    protected void gvAmenities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkValue = new CheckBox();
                chkValue = (CheckBox)e.Row.FindControl("CheckBox1");
                if (e.Row.Cells[2].Text == ddrProject.SelectedValue)
                {
                    chkValue.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvAmenities_RowDataBound", ex.Message.ToString());
            return;
        }
    }

    protected void cmdSaveOthr_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddrOAmenities.SelectedIndex == 0 || ddrProject.SelectedIndex == 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Project And Amenity Group');", true);
                return;
               
            }

            c.ExecuteQuery("Delete From ProjectAmenities Where projId=" + ddrProject.SelectedValue + " And agId=" + ddrOAmenities.SelectedValue);
            int i = 0;
            int maxId;
            CheckBox chkValue = new CheckBox();

            for (i = 0; i < gvAmenities.Rows.Count; i++)
            {
                chkValue = (CheckBox)gvAmenities.Rows[i].Cells[3].FindControl("CheckBox1");
                if (chkValue.Checked == true)
                {
                    maxId = c.NextId("ProjectAmenities", "paId");
                    c.ExecuteQuery("Insert Into ProjectAmenities (paId, projId, aiId, agId) Values (" + maxId + ", " + ddrProject.SelectedValue + ", " + gvAmenities.Rows[i].Cells[0].Text + ", " + ddrOAmenities.SelectedValue + ")");
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Amenity Data Updated');", true);
            //errMsg2 = c.errNotification(1, "Amenity Data Updated");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "cmdSaveOthr_Click", ex.Message.ToString());
            return;
        }
    }
}