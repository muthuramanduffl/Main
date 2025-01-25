using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_AddCostDetails : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientDashboardError CE = new ClientDashboardError();
    Key2hCostDetails KD = new Key2hCostDetails();
    ClientUsers CU = new ClientUsers();
    Key2hAllFilesNew KNFN = new Key2hAllFilesNew();
    public static int CID;
    public static string Userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            Userid = clientLoginId.Replace("clientid=", "");
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            try
            {

                Bindprojects();
                if (Request.QueryString["CostID"] != null)
                {
                    hdnCostID.Value = Convert.ToString(Request.QueryString["CostID"]);
                    Bind(Convert.ToString(Request.QueryString["CostID"]));
                    divrptCustomers.Style.Add("Display", "none");
                    //btnSave.Text = "Update";
                    lblDisplaytext.Text = " Edit Cost Details";
                    ddlProName.Attributes.Add("disabled", "true");
                    ddlBlockNumber.Attributes.Add("disabled", "true");
                    ddlFlatNumber.Attributes.Add("disabled", "true");
                }
                else if (Request.QueryString["FlatID"] != null)
                {
                    BindFlatID(Convert.ToString(Request.QueryString["FlatID"]));
                    ddlProName.Attributes.Add("disabled", "true");
                    ddlBlockNumber.Attributes.Add("disabled", "true");
                    ddlFlatNumber.Attributes.Add("disabled", "true");
                    lblDisplaytext.Text = " Edit Cost Details";
                }
                else
                {
                    Bindblock();
                    BindFlat();
                    BindCostLabel();
                    divrptCustomers.Style.Add("Display", "none");
                    //btnSave.Text = "Submit";
                    lblDisplaytext.Text = " Add Cost Details";
                    ddlProName.Enabled = true;
                    ddlBlockNumber.Enabled = true;
                    ddlFlatNumber.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("add-cost-details.aspx", "BindCity", ex.Message, "Not Fixed");
            }
        }
    }
    public void Bind(string ID)
    {
        try
        {
            DataTable dt = KD.ViewAllFlatCostDetails("", "", "", ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["ProjectID"].ToString()) && dt.Rows[0]["ProjectID"] != null)
                {

                    ddlProName.SelectedValue = dt.Rows[0]["ProjectID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["BlockID"].ToString()) && dt.Rows[0]["BlockID"] != null)
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["FlatID"].ToString()) && dt.Rows[0]["FlatID"] != null)
                {
                    BindFlat();
                    ddlFlatNumber.SelectedValue = dt.Rows[0]["FlatID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["FlatID"].ToString()) && dt.Rows[0]["FlatID"] != null)
                {
                    BindFlat();
                    ddlFlatNumber.SelectedValue = dt.Rows[0]["FlatID"].ToString();
                    FlatFunction();
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void BindFlatID(string ID)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = KC.ViewAllflatBookingCustomerDetails("", "", ID, "", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["ProjectID"].ToString()) && dt.Rows[0]["ProjectID"] != null)
                {
                    ddlProName.SelectedValue = dt.Rows[0]["ProjectID"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["BlockID"].ToString()) && dt.Rows[0]["BlockID"] != null)
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockID"].ToString();
                }
                else if (!string.IsNullOrEmpty(dt.Rows[0]["BlockNo"].ToString()) && dt.Rows[0]["BlockNo"] != null)
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockNo"].ToString();  // Use BlockNo here
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["FlatID"].ToString()) && dt.Rows[0]["FlatID"] != null)
                {
                    BindFlat();
                    ddlFlatNumber.SelectedValue = dt.Rows[0]["FlatID"].ToString();
                    FlatFunction();
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Bind Flat ID", ex.Message, "Not Fixed");
        }
    }
    public void BindCostLabel()
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            try
            {
                DataTable dt = KD.ViewProjectCostLabels();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlCostLabel.DataSource = dt;
                    ddlCostLabel.DataTextField = "CostParameterName";
                    ddlCostLabel.DataValueField = "CostLabelID";
                    ddlCostLabel.DataBind();
                    ddlCostLabel.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlCostLabel.Items.Clear();
                    ddlCostLabel.Items.Insert(0, new ListItem("", ""));
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("add-cost-details.aspx", "BindCostLabel", ex.Message, "Not Fixed");
            }
        }
        else
        {
            ddlCostLabel.Items.Clear();
            ddlCostLabel.Items.Insert(0, new ListItem("", ""));
        }
    }
    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt.Rows.Count > 0)
            {
                ddlProName.DataSource = dt;
                ddlProName.DataTextField = "ProjectName";
                ddlProName.DataValueField = "ProjectID";
                ddlProName.DataBind();
                ddlProName.Items.Insert(0, new ListItem("", ""));
                ddlProName.SelectedValue = "18";
            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bindblock();
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlProName.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlProName.SelectedValue));

                if (DT.Rows.Count > 0)
                {
                    ddlBlockNumber.DataSource = DT;
                    ddlBlockNumber.DataTextField = "BlockName";
                    ddlBlockNumber.DataValueField = "BlockID";
                    ddlBlockNumber.DataBind();
                    ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                    txtCustomerName.Text = "";
                    lblcustomernameerror.Text = "";
                }
                else
                {
                    ddlBlockNumber.Items.Clear();
                    ddlBlockNumber.Items.Insert(0, new ListItem("No block name", ""));
                    divrptCustomers.Style.Add("Display", "none");
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                    txtCustomerName.Text = "";
                    lblcustomernameerror.Text = "";
                    divbtngonext.Style.Add("display", "none");
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                divrptCustomers.Style.Add("Display", "none");


                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                lblcustomernameerror.Text = "";
                divbtngonext.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlBlockNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
    }
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlBlockNumber.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlBlockNumber.SelectedValue));

                if (DT.Rows.Count > 0)
                {
                    ddlFlatNumber.DataSource = DT;
                    ddlFlatNumber.DataTextField = "FlatName";
                    ddlFlatNumber.DataValueField = "FlatID";
                    ddlFlatNumber.DataBind();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                    ddlFlatNumber.Items.Insert(1, new ListItem("No Flat number", ""));
                    divrptCustomers.Style.Add("Display", "none");
                    divbtngonext.Style.Add("display", "none");
                }
            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                divrptCustomers.Style.Add("Display", "none");
                lblcustomernameerror.Text = "";
                divbtngonext.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }
    public void BindCostDetails(int ID)
    {
        try
        {
            DataTable dt = KD.viewFlatCostDetails(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptCustomers.Visible = true;
                rptCustomers.DataSource = dt;
                rptCustomers.DataBind();
                divrptCustomers.Style.Add("Display", "block");
            }
            else
            {
                rptCustomers.Visible = false;
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "BindCostDetails", ex.Message, "Not Fixed");
        }
    }
    protected string GetRowNo(string itemIndex)
    {
        return PageIndex > 1 ? (((PageIndex - 1) * 10) + Convert.ToInt32(itemIndex)).ToString() : itemIndex;
    }
    public int PageIndex
    {
        get { return ViewState["PageIndex"] != null ? (int)ViewState["PageIndex"] : 1; }
        set { ViewState["PageIndex"] = value; }
    }
    public bool Isalreadyexist(int PID, int BlockID, int FlatID)
    {
        bool isavail = false;
        try
        {
            DataTable dt = KD.AlreadyExistFlatCostByProIDBlockIDFlatID(PID, BlockID, FlatID);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CostLabelID"].ToString() == ddlCostLabel.SelectedValue)
                    {
                        isavail = true;
                        break;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["CostID"] == null)
        {
            Clear();
            //'Your action has been canceled.' 
        }
        else
        {
            Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                "   title: 'Cost details has been cancelled ', " +
                "   confirmButtonText: 'OK', " +
                "   customClass: { " +
                "       confirmButton: 'handle-btn-success' " +
                "   } " +
                "}).then((result) => { " +
                "     window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                "});", true);
        }
    }
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
    protected void ddlFlatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            FlatFunction();

        }
        else
        {
            divrptCustomers.Style.Add("Display", "block");
            txtCustomerName.Text = "";
            divrptCustomers.Style.Add("Display", "none");
            lblcustomernameerror.Text = "";
            divbtngonext.Style.Add("display", "none");
        }
    }
    public void FlatFunction()
    {
        try
        {
            DataTable dt = KC.AlreadyExistProjectdetails(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCustomerName.Text = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplicantFirstName"])) ? "N/A" : Convert.ToString(dt.Rows[0]["ApplicantFirstName"]);
                lblcustomernameerror.Text = "";
                divrptCustomers.Style.Add("Display", "block");
                int count = KNFN.ExistCostLabelParameterFlatcostDetailsByCIDandAddedby(ddlFlatNumber.SelectedValue, Userid);
                if (count == 5)
                {
                    divbtngonext.Style.Add("display", "inline");
                }
            }
            else
            {
                txtCustomerName.Text = "N/A";
                divrptCustomers.Style.Add("Display", "none");
                lblcustomernameerror.Text = "Selected flat has no customer records";  //due out
            }
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {
                BindCostLabel();
                BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));

            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }
    [System.Web.Services.WebMethod]
    public static string UpdateCustomer(string costLabelID, string costParameterName, string cost, string selectedValue)
    {
        string strret = string.Empty;
        int ret = 0;
        Key2hCostDetails KD = new Key2hCostDetails();
        ClientDashboardError CE = new ClientDashboardError();
        try
        {
            KD.intCostLabelID = Convert.ToInt32(costLabelID);
            KD.intCost = Convert.ToInt32(cost.Contains("₹") ? cost.Replace("₹", "") : cost);
            KD.intFlatID = Convert.ToInt32(selectedValue);
            KD.strUpdatedBy = Userid;
            ret = KD.UpdateFlatCost(KD);
            if (ret == 1)
            {
                strret = "Row updated successfully!";
            }
            else
            {
                strret = "Row not updated!";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "UpdateCustomer", ex.Message, "Not Fixed");
        }
        return strret;
    }
    [System.Web.Services.WebMethod]
    public static bool CheckExistProjectCostLabelsParameter(string costLabelID)
    {
        bool isavail = false;
        ClientDashboardError CE = new ClientDashboardError();
        Key2hAllFilesNew KNFN = new Key2hAllFilesNew();
        ClientUsers CU = new ClientUsers();
        Key2hPaymentDetails PD = new Key2hPaymentDetails();
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            Userid = clientLoginId.Replace("clientid=", "");
        }
        else
        {
            Userid = clientLoginId;
        }
        if (KNFN.CheckExistProjectCostLabelsParameter(costLabelID, Userid))
        {
            isavail = true;
        }
        return isavail;
    }
    [System.Web.Services.WebMethod]
    public static string DeleteCustomer(string costLabelID, string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hAllFilesNew KNFN = new Key2hAllFilesNew();
        ClientUsers CU = new ClientUsers();
        Key2hPaymentDetails PD = new Key2hPaymentDetails();
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            Userid = clientLoginId.Replace("clientid=", "");
        }
        else
        {
            Userid = clientLoginId;
        }
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            Key2hCostDetails KD = new Key2hCostDetails();
            Key2htransaction KT = new Key2htransaction();
            if (!KNFN.CheckExistProjectCostLabelsParameter(costLabelID, Userid))
            {
                DataTable dt = KT.ViewAllFlatCustomerTransactionByFlatID(Convert.ToInt32(selectedValue));
                if (dt != null && dt.Rows.Count == 0)
                {
                    ret = KD.DeleteFlatCostDetails(Convert.ToInt32(costLabelID), Convert.ToInt32(selectedValue));
                    if (ret == 1)
                    {
                        strerror = "Cost details has been deleted";
                    }
                    else
                    {
                        strerror = "Row not deleted!";
                    }
                }
                else
                {
                    strerror = "Sorry, you can't delete as receipts have been sent to the customer.";
                }
            }
            else
            {
                DataTable dt = KT.ViewAllFlatCustomerTransactionByFlatID(Convert.ToInt32(selectedValue));
                if (dt != null && dt.Rows.Count == 0)
                {
                    KNFN.DeleteCustomerPaymentSchedule(selectedValue, Userid);
                    ret = KD.DeleteFlatCostDetails(Convert.ToInt32(costLabelID), Convert.ToInt32(selectedValue));
                    if (ret == 1)
                    {
                        strerror = "Cost details has been deleted";// error msg
                    }
                    else
                    {
                        strerror = "Row not deleted!";
                    }
                }
                else
                {
                    strerror = "Sorry, you can't delete as receipts have been sent to the customer.";
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
        }
        return strerror;
    }
    [WebMethod]
    public static int GetRowCount(string selectedValue, string Selectedddlproject, string selectedBlock)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hCostDetails KD = new Key2hCostDetails();
        int rowCount = 0;
        try
        {
            DataTable dt = KD.ViewAllFlatCostDetails(Selectedddlproject, selectedValue, selectedBlock, "");
            if (dt != null && dt.Rows.Count > 0)
            {
                rowCount = dt.Rows.Count;
            }
            else
            {
                rowCount = 0;
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "GetRowCount", ex.Message, "Not Fixed");

        }
        return rowCount;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text))
        {
            labelerror = "Fill the mandatory field.";
        }
        else if (string.IsNullOrEmpty(ddlProName.SelectedValue))
        {
            labelerror = "Select project name";
        }
        else if (string.IsNullOrEmpty(ddlBlockNumber.SelectedValue))
        {
            labelerror = "Select block no.";
        }
        else if (string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            labelerror = "Select flat no.";
        }
        else if (string.IsNullOrEmpty(txtCustomerName.Text))
        {
            labelerror = "Enter customer name";
        }
        else if (string.IsNullOrEmpty(ddlCostLabel.SelectedValue))
        {
            labelerror = "Select cost label";
        }
        else if (string.IsNullOrEmpty(txtCost.Text))
        {
            labelerror = "Enter cost";
        }
        if (string.IsNullOrEmpty(labelerror))
        {
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {

                if (!Isalreadyexist(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue)))
                {
                    int ret = 0;
                    ret = AddCostdetails();
                    if (ret == 1)
                    {
                        BindCostLabel();
                        BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                        ddlCostLabel.SelectedIndex = 0;
                        txtCost.Text = "";
                        int count = KNFN.ExistCostLabelParameterFlatcostDetailsByCIDandAddedby(ddlFlatNumber.SelectedValue, Userid);
                        if (count == 5)
                        {
                            divbtngonext.Style.Add("display", "inline");
                        }
                        ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "alert",
                           "Swal.fire({ " +
                           "  title: 'Cost details added successfully', " +
                           "  icon: 'success', " +
                           "  customClass: { " +
                           "    icon: 'handle-icon-clr', " +
                           "    confirmButton: 'handle-btn-success' " +
                           "  } " +
                           "});", true);
                    }
                    else
                    {
                        string script = string.Format(@" <script>
                    Swal.fire({{ 
                        title: 'Cost details couldn't be added due to a server or network issue. Please try again in some time!', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success' 
                        }} 
                    }}).then((result) => {{  
                            window.location.href = 'add-cost-details.aspx';  
                    }});
                    </script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " +
                          "  title: 'The cost details you’re trying to add already exists', " +
                          "  confirmButtonText: 'OK', " +
                           "  customClass: { " +
                            "      confirmButton: 'handle-btn-success', " +
                            "  }" +
                          "});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
               "Swal.fire('Validation Alert', '" + lblcustomernameerror.Text + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
           "Swal.fire('Validation Alert', '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
        divrptCustomers.Style.Add("Display", "block");
    }
    public int AddCostdetails()
    {
        int rowaffected = 0;
        try
        {
            KD.intProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KD.intBlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KD.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KD.intCostLabelID = Convert.ToInt32(ddlCostLabel.SelectedValue);
            KD.intCost = Convert.ToInt32(txtCost.Text.Contains("₹") ? txtCost.Text.Replace("₹", "") : txtCost.Text);
            KD.strAddedBy = Userid;
            rowaffected = KD.AddFlatCostDetails(KD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "AddCostdetails", ex.Message, "Not Fixed");
        }
        return rowaffected;
    }
    public int UpdateCostdetails()
    {
        int rowaffected = 0;
        try
        {
            KD.intProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KD.intBlockID = Convert.ToInt32(ddlProName.SelectedValue);
            KD.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KD.intCostLabelID = Convert.ToInt32(ddlCostLabel.SelectedValue);
            KD.intCost = Convert.ToInt32(txtCost.Text.Contains("₹") ? txtCost.Text.Replace("₹", "") : txtCost.Text);
            KD.strUpdatedBy = Userid;
            rowaffected = KD.UpdateFlatCostDetails(KD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "UpdateCostdetails", ex.Message, "Not Fixed");
        }
        return rowaffected;
    }
    protected void ddlCostLabel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Isalreadyexist(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue)))
        {
            if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                divrptCustomers.Style.Add("Display", "block");
                lblprojectValidationMessage.Text = "";
            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        else
        {
            lblprojectValidationMessage.Text = "Cost label already exist";
            divrptCustomers.Style.Add("Display", "none");
        }
    }
    public class CostDetail
    {
        public int CostLabelID { get; set; }
        public string CostParameterName { get; set; }
        public decimal Cost { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {
        Key2hCostDetails KD = new Key2hCostDetails();
        ClientDashboardError CE = new ClientDashboardError();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            DataTable dt = KD.viewFlatCostDetails(Convert.ToInt32(selectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CostDetail costDetail = new CostDetail
                    {
                        CostLabelID = Convert.ToInt32(row["CostLabelID"]),
                        CostParameterName = Convert.ToString(row["CostParameterName"]),
                        Cost = Convert.ToDecimal(row["Cost"])
                    };
                    costDetails.Add(costDetail);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "UpdateCostdetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-payment-schedule.aspx?FlatID=" + ddlFlatNumber.SelectedValue + "");
    }
}