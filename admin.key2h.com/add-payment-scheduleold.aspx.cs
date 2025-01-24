using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_AddPaymentSchedule : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientUsers CU = new ClientUsers();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hCostDetails KCD = new Key2hCostDetails();
    Key2hFlat KF = new Key2hFlat();
    ClientDashboardError CE = new ClientDashboardError();
    Key2hPaymentDetails KD = new Key2hPaymentDetails();
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
            Userid = clientLoginId;
        }
        if (!IsPostBack)
        { 
            if (Request.QueryString["PSID"] != null)
            { 
                Bindprojects();
                Bindblock();
                BindPaymentStage();
                divrptCustomers.Style.Add("Display", "none");
                txtGST.Text = "";
                txtNET.Text = "";
                txtPercentage.Text = "";
                txtsubAmount.Text = ""; 
                Bind(Convert.ToString(Request.QueryString["PSID"]));
                ddlProName.Attributes.Add("disabled", "true");
                ddlBlockNumber.Attributes.Add("disabled", "true");
                ddlFlatNumber.Attributes.Add("disabled", "true");
            }
            else
            { 
                Bindprojects();
                Bindblock();
                BindPaymentStage();
                divrptCustomers.Style.Add("Display", "none");
                txtGST.Text = "";
                txtNET.Text = "";
                txtPercentage.Text = "";
                txtsubAmount.Text = ""; 
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;
                ddlFlatNumber.Enabled = true;
            }
        }
    }
    public void Bind(string ID)
    {
        RequiredFieldValidator16.Visible = false;
        RequiredFieldValidator3.Visible = false;
        try
        {
            DataTable dt = KD.ViewFilterCustomerPaymentSchedule("", "", "", ID);
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
                    Flatfunction();
                } 
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void BindPaymentStage()
    {
        try
        {
            DataTable dt = KD.ViewProjectPaymentStages();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlPaymentStages.DataSource = dt;
                ddlPaymentStages.DataTextField = "PaymentLabel";
                ddlPaymentStages.DataValueField = "PID";
                ddlPaymentStages.DataBind();
                ddlPaymentStages.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "BindPaymentStage", ex.Message, "Not Fixed");
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
    public void BindSheduleList()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                DataTable dt = KD.ViewPaymentScheduleByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptsheduler.Visible = true;
                    rptsheduler.DataSource = dt;
                    rptsheduler.DataBind();
                    divrptCustomers.Style.Add("Display", "Block");
                }
                else
                {
                    rptsheduler.Visible = false;
                    divrptCustomers.Style.Add("Display", "none");
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "BindSheduleList", ex.Message, "Not Fixed");
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
            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
                }
                else
                {
                    ddlBlockNumber.Items.Clear();
                    ddlBlockNumber.Items.Insert(0, new ListItem("No block name", ""));
                    divrptCustomers.Style.Add("Display", "none");
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
                } 
            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        { 
        }
    }
    protected void ddlFlatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Flatfunction();
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "ddlFlatNumber_SelectedIndexChanged", ex.Message, "Not Fixed");
        }
    }
    public void Flatfunction()
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            DataTable dt = KC.AlreadyExistProjectdetails(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCustomerName.Text = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplicantFirstName"])) ? "N/A" : Convert.ToString(dt.Rows[0]["ApplicantFirstName"]);
                BindSheduleList();
                divDemandStages.Style.Add("display", "Block");
            }
            else
            {
                txtCustomerName.Text = "N/A";
                divrptCustomers.Style.Add("Display", "none");
                divDemandStages.Style.Add("display", "none");
            } 
            //BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            //divrptCustomers.Style.Add("Display", "block");
        }
        else
        {
            divrptCustomers.Style.Add("Display", "none");
            divDemandStages.Style.Add("display", "none");
            txtCustomerName.Text = "";
        }
        lblcostlabelcounterrormsg.Text = "";
        linkbtnclickhere.Style.Add("display", "none");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text) &&
            string.IsNullOrEmpty(ddlPaymentStages.SelectedValue) && string.IsNullOrEmpty(txtPercentage.Text) &&
            string.IsNullOrEmpty(txtsubAmount.Text) && string.IsNullOrEmpty(txtGST.Text) && string.IsNullOrEmpty(txtNET.Text))
        {
            labelerror = "Fill the mandatory field ";
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
        else if (string.IsNullOrEmpty(ddlPaymentStages.SelectedValue))
        {
            if (Request.QueryString["PSID"] == null)
            {
                labelerror = "Select payment stages";
            }
        }
        else if (string.IsNullOrEmpty(txtPercentage.Text))
        {
            if (Request.QueryString["PSID"] == null)
            {
                labelerror = "Enter percentage";
            }
        } 
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["PSID"] == null)
            {
                int ret = KCD.CheckFlatCostDetailsExistAllCostLabelParameterByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                if (ret != 2)
                {
                    if (ret == 1)
                    {
                        if (!Isalreadyexist(Convert.ToInt32(ddlFlatNumber.SelectedValue), Convert.ToInt32(ddlPaymentStages.SelectedValue)))
                        {
                            int ret1 = 0;
                            ret1 = AddFlatPaymentScheduleDetails();
                            if (ret1 == 1)
                            {
                                BindSheduleList();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                "Swal.fire({ " +
                                "  title: 'Payment schedule details added successfully', " +
                                "  icon: 'success', " +
                                "  customClass: { " +
                                "    icon: 'handle-icon-clr', " +
                                "    confirmButton: 'handle-btn-success' " +
                                "  } " +
                                "});", true);
                                ddlPaymentStages.SelectedIndex = 0;
                                txtPercentage.Text = "";
                                txtsubAmount.Text = "";
                                txtGST.Text = "";
                                txtNET.Text = "";
                            }
                            else
                            {
                                string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Payment schedule details couldn't be added due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-payment-schedule.aspx';  
                            }});
                            </script>");
                                ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                "Swal.fire({ " +
                                  "  title: 'The payment schedule details you’re trying to add already exists', " +
                                  "  confirmButtonText: 'OK', " +
                                   "  customClass: { " +
                                    " confirmButton: 'handle-btn-success', " +
                                    "  }" +
                                  "});", true);
                        }
                    }
                    else
                    {
                        lblcostlabelcounterrormsg.Text = "  Enter all cost details to proceeds with payment schedule.  ";
                        linkbtnclickhere.Style.Add("display", "block");
                    }
                }
                else
                {
                    string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Payment schedule details couldn't be calculate due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-payment-schedule.aspx';  
                            }});
                            </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                int ret = 0;
                DataTable dt = KD.ViewFilterCustomerPaymentSchedule("", "", "", "");
                if (dt.Rows.Count > 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                        "    title: 'Payment schedule details updated successfully', " +
                        "    icon: 'success', " +
                        "    allowOutsideClick: 'true', " +
                        "    customClass: { " +
                        "        confirmButton: 'handle-btn-success', " +
                        "        icon: 'handle-icon-clr' " +
                        "    } " +
                        "}).then((result) => { " +
                        "        window.location.href = 'view-payment-schedule.aspx'; " + 
                        "});",
                        true); 
                }
                else
                {
                    string script = string.Format(@"  <script>
                        Swal.fire({{
                            title: 'Payment schedule details couldn't be updated due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {{
                                confirmButton: 'handle-btn-success'
                            }}
                        }}).then((result) => {{
                                window.location.href = 'add-payment-schedule.aspx?FlatID={0}'; 
                        }});
                    </script>", Convert.ToString(Request.QueryString["FlatID"]));
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
        }
        else
        {
            //alert labelerror
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire('Validation Alert', '" + labelerror + " !', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
    }
    public bool Isalreadyexist(int FlatID, int LabelID)
    {
        bool isavail = false;

        string strbname = string.Empty;
        try
        {
            DataTable dt = KD.ViewPaymentsheduleByFlatandPLID(FlatID, LabelID);
            if (dt != null && dt.Rows.Count > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    public int AddFlatPaymentScheduleDetails()
    {
        int ret = 0;
        try
        {
            // Store values
            KD.SubAmount = Convert.ToInt32(txtsubAmount.Text);
            KD.FlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KD.PaymentLabelID = Convert.ToInt32(ddlPaymentStages.SelectedValue);
            KD.GST = Convert.ToInt32(txtGST.Text);
            KD.PaymentPercentage = txtPercentage.Text;
            KD.Amount = Convert.ToInt32(txtsubAmount.Text) + Convert.ToInt32(txtGST.Text);
            // Add to schedule
            KD.AddedBy =Userid;
            // Save details
            ret = KD.AddFlatPaymentScheduleDetails(KD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "AddFlatPaymentScheduleDetails", ex.Message, "Not Fixed");
        }
        return ret;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["Projectid"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //      "Swal.fire('Cancelled!', 'Your action has been canceled.', 'success');",
            //      true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                "   title: 'Payment schedule details has been cancelled as requested', " +
                "   confirmButtonText: 'OK', " +
                "   customClass: { " +
                "       confirmButton: 'handle-btn-success' " +
                "   } " +
                "}).then((result) => { " +
                "    window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                "});", true);
        }
    }
    public void Clear()
    { 
        Response.Redirect(Request.Url.AbsolutePath);
    }
    protected void txtPercentage_TextChanged(object sender, EventArgs e)
    {
        if (Page.IsPostBack && sender == txtPercentage)
        {
            CalculateAndSetValues();
        }
    }
    protected void calculateIcon_Click(object sender, EventArgs e)
    {
        CalculateAndSetValues();
    }
    private void CalculateAndSetValues()
    {
        if (!string.IsNullOrEmpty(ddlPaymentStages.SelectedValue) && !string.IsNullOrEmpty(txtPercentage.Text))
        {
            try
            {
                int ret = KCD.CheckFlatCostDetailsExistAllCostLabelParameterByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                if (ret != 2)
                {
                    if (ret == 1)
                    {
                        lblcostlabelcounterrormsg.Text = "";
                        int percentage = 0;
                        int flatnumber = Convert.ToInt32(ddlFlatNumber.SelectedValue);
                        if (!string.IsNullOrEmpty(txtPercentage.Text) &&
                            int.TryParse(txtPercentage.Text.Trim(), out percentage) &&
                            percentage > 0)
                        {
                            DataTable dt = KD.GetFlatCostDetailsByFlatID(flatnumber);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                lblpaymentstagesMessage.Text = "";
                                lblenterpercentageMessage.Text = "";
                                int a = KD.GetParameterCostofFlatID(flatnumber, "A");
                                int b = KD.GetParameterCostofFlatID(flatnumber, "B");
                                int d = KD.GetParameterCostofFlatID(flatnumber, "D");
                                int f = KD.GetParameterCostofFlatID(flatnumber, "F");
                                int g = KD.GetParameterCostofFlatID(flatnumber, "G");
                                int c = a + b;
                                int subtotal = c + f + g;
                                int SubAmount = (subtotal * percentage) / 100;
                                int GST = (d * percentage) / 100;
                                txtsubAmount.Text = SubAmount.ToString();
                                txtGST.Text = GST.ToString();
                                txtNET.Text = (SubAmount + GST).ToString();
                            }
                        }
                        else
                        {
                            lblenterpercentageMessage.Text = "Enter percentage";
                            txtPercentage.Focus();
                            ClearTextFields();
                        }
                    }
                    else
                    {
                        lblcostlabelcounterrormsg.Text = "Enter all cost details to proceeds with payment schedule.";
                        linkbtnclickhere.Style.Add("display","block");
                    }
                }
                else
                {
                    string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Payment schedule details couldn't be calculate due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-payment-schedule.aspx';  
                            }});
                            </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("add-payment-schedule.aspx", "CalculateAndSetValues", ex.Message, "Not Fixed");
            }
        }
        else
        {
            lblpaymentstagesMessage.Text = string.IsNullOrEmpty(ddlPaymentStages.SelectedValue) ? "Select payment stages" : "";
            lblenterpercentageMessage.Text = string.IsNullOrEmpty(txtPercentage.Text) ? "Enter percentage" : "";
            ClearTextFields();
        }
    }
    private void ClearTextFields()
    {
        txtsubAmount.Text = "";
        txtGST.Text = "";
        txtNET.Text = "";
        ddlProName.Enabled = true;
        ddlBlockNumber.Enabled = true;
        ddlFlatNumber.Enabled = true;
    }
    protected void ddlPaymentStages_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && !string.IsNullOrEmpty(ddlPaymentStages.SelectedValue))
        {
            if (!Isalreadyexist(Convert.ToInt32(ddlFlatNumber.SelectedValue), Convert.ToInt32(ddlPaymentStages.SelectedValue)))
            {
                lblpaymentstagesMessage.Text = "";
                BindSheduleList();
            }
            else
            {
                lblpaymentstagesMessage.Text = "Payment stages already exist";
                BindSheduleList();
            }
        }
        else
        {
            txtGST.Text = "";
            txtNET.Text = "";
            txtsubAmount.Text = "";
        }
    }
    [System.Web.Services.WebMethod]
    public static string DeleteShedulestages(string hdnPSID)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hPaymentDetails Ky = new Key2hPaymentDetails();
        string strisdelete = string.Empty;
        int ret = 0; 
        try
        {
            ret = Ky.DeleteShedulepaymentstages(Convert.ToInt32(hdnPSID)); 
            if (ret == 1)
            {
                strisdelete = "1";
            }
            else
            {
                strisdelete = "0";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "DeleteShedulestages", ex.Message, "Not Fixed");
        }
        return strisdelete;
    }
    public class CostDetail
    { 
        public int PSID { get; set; }
        public string PaymentStages { get; set; }
        public decimal Percentage { get; set; }
        public string Amount { get; set; }
        public string GST { get; set; }
        public string NET { get; set; }

    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hPaymentDetails KD = new Key2hPaymentDetails();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            DataTable dt = KD.ViewPaymentScheduleByFlatID(Convert.ToInt32(selectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CostDetail costDetail = new CostDetail
                    {
                        PSID = Convert.ToInt32(row["PSID"]),
                        PaymentStages = Convert.ToString(row["PaymentLabel"]),
                        Percentage = (Convert.ToInt32(row["PaymentPercentage"])),
                        Amount = Convert.ToString(row["Amount"]),
                        GST = Convert.ToString(row["GST"]),
                        NET = Convert.ToString(row["SubAmount"]) + Convert.ToString(row["GST"])
                    };
                    costDetails.Add(costDetail);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-schedule.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    protected void linkbtnclickhere_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue)) 
        {
            Response.Redirect("add-cost-details.aspx?FlatID="+ddlFlatNumber.SelectedValue);
        }
        else
        {
            lblcostlabelcounterrormsg.Text += "   Select Flat no.";
        }
    }
}