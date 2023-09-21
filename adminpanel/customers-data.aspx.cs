using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class adminpanel_customers_data : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Customers" : "Edit Customers";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                c.FillComboBox("ProjName", "ProjId", "ProjectsNew", "DelMark=0", "ProjName", 0, ddrProjId);

                if (Request.QueryString["action"] != null)
                {
                    editcust.Visible = true;
                    viewcust.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        chkbxrapid.Checked = true;
                        ddrProjId.Focus();
                       
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetCustData(Convert.ToInt32(Request.QueryString["id"]));

                        rapid.Visible = false;
                    }
                }
                else
                {
                    editcust.Visible = false;
                    viewcust.Visible = true;
                    FillGrid();
                }

               
                chkbxrapid.Checked = true;
            }
            lblId.Visible = false;
        }
        catch(Exception ex)
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
            using (DataTable dtNws = c.GetDataTable("Select a.CustID, Convert(varchar(20), a.CustJoinDate, 103) as CustJoinDate, a.FK_ProjectId, a.CustName, a.CustMobileNo, a.CustUserId, a.CustPassword, b.ProjName From CustomersData a Inner Join ProjectsNew b ON a.FK_ProjectId=b.ProjId Where a.DelMark=0 Order By a.CustID DESC"))
            {
                gvCust.DataSource = dtNws;
                gvCust.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvCust.UseAccessibleHeader = true;
                    gvCust.HeaderRow.TableSection = TableRowSection.TableHeader;
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


    public void GetCustData(int CustIdx)
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("select * from CustomersData where CustID=" + CustIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    lblId.Text = CustIdx.ToString();
                    txtEmail.Text =row["CustEmailId"].ToString();
                    txtMobile.Text = row["CustMobileNo"].ToString();
                    txtName.Text = row["CustName"].ToString();
                    txtPass.Text = row["CustPassword"].ToString();
                    txtPlotNum.Text = row["CustPlotNum"].ToString();
                    txtUserId.Text = row["CustUserId"].ToString();
                    ddrProjId.SelectedValue = row["FK_ProjectId"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetCustData", ex.Message.ToString());
            return;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int maxId;
            if (txtMobile.Text == "" || txtName.Text == "" || txtPass.Text == "" || txtPlotNum.Text == "" || ddrProjId.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }
            txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");
            txtMobile.Text = txtMobile.Text.Trim().Replace("'", "");
            txtName.Text = txtName.Text.Trim().Replace("'", "");
            txtPass.Text = txtPass.Text.Trim().Replace("'", "");
            txtPlotNum.Text = txtPlotNum.Text.Trim().Replace("'", "");

            maxId = c.NextId("CustomersData", "CustID");

            string userid = ddrProjId.SelectedValue + txtPlotNum.Text;

            //if (c.isRecordExist("Select  FK_ProjectId, CustPlotNum, CustMobileNo From CustomersData Where FK_ProjectId=" + ddrProjId.SelectedValue"  ))
            //{
            //    errMsg = c.errNotification(2, "Project Name Allready Exist");
            //    return;
            //}


            if (Request.QueryString["action"] == "new")
            {

                if (c.IsRecordExist("Select CustPlotNum, FK_ProjectId, CustMobileNo From CustomersData Where CustPlotNum='" + txtPlotNum.Text + "' AND CustMobileNo='" + txtMobile.Text + "' AND FK_ProjectId=" + ddrProjId.SelectedValue + ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Plot number and Project name already exist');", true);
                    return;

                    //errMsg = c.errNotification(2, "plot number and project name already exist");
                    //return;
                }

                c.ExecuteQuery("Insert Into CustomersData (CustID, FK_ProjectId, CustPlotNum, CustJoinDate, CustName, CustMobileNo, CustEmailId, CustUserId, CustPassword, DelMark) Values(" + maxId + ", '" + ddrProjId.SelectedValue + "', '" + txtPlotNum.Text + "', '" + DateTime.Now + "', '" + txtName.Text + "', '" + txtMobile.Text + "',  '" + txtEmail.Text + "', '" + userid + "', '" + txtPass.Text + "', 0)");

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Saved');", true);

                //errMsg = c.errNotification(1, "Record Saved");
            }
            else
            {
                if (c.IsRecordExist("Select CustPlotNum, FK_ProjectId, CustMobileNo From CustomersData Where CustPlotNum='" + txtPlotNum.Text + "' AND CustID!=" + Request.QueryString["id"] + " AND CustMobileNo='" + txtMobile.Text + "' AND FK_ProjectId=" + ddrProjId.SelectedValue + ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Plot number and Project name already exist');", true);
                    return;
                }

                chkbxrapid.Checked = false;

                c.ExecuteQuery("Update CustomersData Set FK_ProjectId='" + ddrProjId.SelectedValue + "', CustName='" + txtName.Text + "', CustMobileNo='" + txtMobile.Text + "', CustEmailId='" + txtEmail.Text + "', CustPassword='" + txtPass.Text + "', CustUserId='" + userid + "', CustPlotNum='" + txtPlotNum.Text + "' Where CustID=" + Request.QueryString["id"]);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Updated');", true);

                rapid.Visible = false;
            }
            if (chkbxrapid.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('customers-data.aspx', 2000);", true);
            }
            if (Request.QueryString["action"] == "new")
            {
                chkbxrapid.Checked = true;
                ddrProjId.Focus();
                txtName.Focus();
            }
            else
            {
                chkbxrapid.Checked = false;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('customers-data.aspx', 2000);", true);

            }

            txtPass.Text = txtPlotNum.Text = txtName.Text = txtMobile.Text = txtEmail.Text = "";
            ddrProjId.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("update CustomersData set DelMark=1 where CustID=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('customers-data.aspx', 2000);", true);
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
        Response.Redirect("customers-data.aspx");
    }



    protected void gvCust_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal myLtr = new Literal();
                myLtr = (Literal)e.Row.FindControl("litAnch");
                myLtr.Text = "<a href='customers-data.aspx?action=edit&id=" + e.Row.Cells[0].Text + "' class=\"gAnch\" ></a>";
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvCust_RowDataBound", ex.Message.ToString());
            return;
        }
    }
}