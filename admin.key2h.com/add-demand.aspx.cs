using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


public partial class adminkey2hcom_AddDemand : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientDashboardError CE = new ClientDashboardError();
    Key2hdemontDetails Kdemand = new Key2hdemontDetails();
    Key2hPaymentDetails KPD = new Key2hPaymentDetails();
    ClientUsers CU = new ClientUsers();
    private static string clientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            clientId = clientLoginId.Replace("clientid=", "");
        }
        else
        {
            clientId = clientLoginId;
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["DemandID"] == null && Request.QueryString["FlatID"] == null)
            {
                Bindprojects();
                Bindblock();
                lblDisplayText.Text = "Add Demand";
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
                divDemandList.Style.Add("Display", "none");
                ClearSession();
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;
                ddlFlatNumber.Enabled = true;
            }
            else if (Request.QueryString["FlatID"] != null)
            {
                Bindprojects();
                Bindblock();
                lblDisplayText.Text = "Edit Demand";
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
                divDemandList.Style.Add("Display", "none");
                ClearSession();
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;
                ddlFlatNumber.Enabled = true;
                BindFltID(Request.QueryString["FlatID"]);
            }
            else
            {
                Bindprojects();
                Bindblock();
                lblDisplayText.Text = "Edit Demand";
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
                divDemandList.Style.Add("Display", "none");
                ClearSession();
                ddlProName.Attributes.Add("disabled", "true");
                ddlBlockNumber.Attributes.Add("disabled", "true");
                ddlFlatNumber.Attributes.Add("disabled", "true");
                Bind(Convert.ToString(Request.QueryString["DemandID"]));
            }
        }
    }
    public void Bind(string ID)
    {
        try
        {
            DataTable dt = Kdemand.ViewAllFlatDemandDetails(ID, "", "", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["ProjectID"].ToString()) && dt.Rows[0]["ProjectID"] != null)
                {
                    ddlProName.SelectedValue = dt.Rows[0]["ProjectID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["BlockNo"].ToString()) && dt.Rows[0]["BlockNo"] != null)
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockNo"].ToString();
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
            CE.StoreExceptionMessage("add-demand.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void BindFltID(string ID)
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
                if (dt.Columns.Contains("BlockNo") && !string.IsNullOrEmpty(dt.Rows[0]["BlockNo"].ToString()))
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockNo"].ToString();
                }
                else if (dt.Columns.Contains("BlockID") && !string.IsNullOrEmpty(dt.Rows[0]["BlockID"].ToString()))
                {
                    Bindblock();
                    ddlBlockNumber.SelectedValue = dt.Rows[0]["BlockID"].ToString();
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
            CE.StoreExceptionMessage("add-demand.aspx", "Bind", ex.Message, "Not Fixed");
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
                //ddlProName.SelectedValue = "18";
            }
            else
            {
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
                divDemandList.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    public string BindDemandPaymentLabelName(int LID)
    {
        string StrLabelName = string.Empty;
        try
        {
            DataTable Dt = Kdemand.ViewFlatDemandPaymentLabelNameByPLID(LID);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                StrLabelName = Dt.Rows[0]["PaymentLabel"].ToString();
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "BindDemandPaymentLabelName", ex.Message, "Not Fixed");
        }
        return StrLabelName;
    }
    public void BindDemandDetails(int ID)
    {
        try
        {
            DataTable dt = Kdemand.ViewFlatCustomerDemandsByFlatID(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptDemandList.Visible = true;
                rptDemandList.DataSource = dt;
                rptDemandList.DataBind();
                divDemandList.Style.Add("Display", "block");
            }
            else
            {
                rptDemandList.Visible = false;
                divDemandList.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "BindDemandDetails", ex.Message, "Not Fixed");
        }
    }
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
        ClearSession();
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
                    lbldoesnotexist.Text = "";
                    divDemandStages.Style.Add("display", "none");
                    txtCustomerName.Text = "";
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlBlockNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        ClearSession();
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
                    lbldoesnotexist.Text = "";
                    divDemandStages.Style.Add("display", "none");
                }
                else
                {
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                    ddlFlatNumber.Items.Insert(1, new ListItem("No Flat number", ""));
                    //divrptCustomers.Style.Add("Display", "none");
                    lbldoesnotexist.Text = "";
                    divDemandStages.Style.Add("display", "none");
                }
            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "none");
                // divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }
    protected void ddlFlatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearSession();
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            FlatFunction();
        }
        else
        {
            ddlPaymentStages.Items.Clear();
            txtCustomerName.Text = "";
            lbldoesnotexist.Text = "";
            divDemandStages.Style.Add("display", "none");
            divDemandList.Style.Add("display", "none");
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
                lbldoesnotexist.Text = "";
                divDemandStages.Style.Add("display", "block");

            }
            else
            {
                txtCustomerName.Text = "N/A";
                divDemandList.Style.Add("Display", "none");
                divDemandStages.Style.Add("display", "none");
                divDemandList.Style.Add("display", "none");
                lbldoesnotexist.Text = "Selected flat has no customer records";

            }
            BindPaymentStages();
            BindDemandDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            VisibleGobtn();
            // divDemandList.Style.Add("Display", "none");
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }
    public void BindPaymentStages()
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            try
            {
                DataTable dt = Kdemand.ViewCustomerPaymentStagesByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlPaymentStages.DataSource = dt;
                    ddlPaymentStages.DataTextField = "PaymentLabel";
                    ddlPaymentStages.DataValueField = "PID";
                    ddlPaymentStages.DataBind();
                    ddlPaymentStages.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlPaymentStages.Items.Clear();
                    ddlPaymentStages.Items.Insert(0, new ListItem("", ""));
                    divDemandList.Style.Add("Display", "none");
                    divDemandStages.Style.Add("display", "none");
                    divDemandList.Style.Add("display", "none");
                    lbldoesnotexist.Text = "Payment setup incomplete. Add a schedule first.";
                    linkbtnGoPS.Style.Add("Display", "none");
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("add-demand.aspx", "BindPaymentStages", ex.Message, "Not Fixed");
            }
        }
        else
        {
            ddlPaymentStages.Items.Clear();
            ddlPaymentStages.Items.Insert(0, new ListItem("", ""));
            divDemandList.Style.Add("Display", "none");
            divDemandStages.Style.Add("display", "none");
            divDemandList.Style.Add("display", "none");
            lbldoesnotexist.Text = "";
        }
    }
    public bool Isalreadyexist(string FlatID, string PaymentLabelID)
    {
        bool isavail = false;
        if (!string.IsNullOrEmpty(FlatID) && !string.IsNullOrEmpty(PaymentLabelID))
        {
            try
            {
                DataTable dt = Kdemand.AlreadyExistFlatCustomerDemandsByPaymentLabelIDFlatID(Convert.ToInt32(FlatID), Convert.ToInt32(PaymentLabelID));
                if (dt != null && dt.Rows.Count > 0)
                {
                    isavail = true;
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("add-demand.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
            }
        }
        return isavail;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
    protected void ddlPaymentStages_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Isalreadyexist(ddlFlatNumber.SelectedValue, ddlPaymentStages.SelectedValue))
        {
            lblprojectValidationMessage.Text = "";

        }
        else
        {
            lblprojectValidationMessage.Text = "Payment stages already exist";
        }
        BindDemandDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
        VisibleGobtn();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ProID"] = ddlProName.SelectedValue;
            Session["FlatID"] = ddlFlatNumber.SelectedValue;
            Session["BlockID"] = ddlBlockNumber.SelectedValue;
            Session["ddlstages"] = ddlPaymentStages.SelectedValue;
            RestoreSessionValues();
            FlatFunction();
            string labelerror = string.Empty;
            if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
                string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text) &&
                string.IsNullOrEmpty(ddlPaymentStages.SelectedValue) && !flDemandUpload.HasFile)
            {
                labelerror = "Fill the mandatory field";
            }
            else if (string.IsNullOrEmpty(ddlProName.SelectedValue))
            {
                labelerror = "Select project name";
            }
            else if (string.IsNullOrEmpty(ddlBlockNumber.SelectedValue))
            {
                labelerror = "Select block name";
            }
            else if (string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                labelerror = "Select flat no.";
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                labelerror = "Enter customer name";
            }
            else if (string.IsNullOrEmpty(ddlPaymentStages.SelectedValue))
            {
                labelerror = "Select payment stages";
            }
            string paymentstage = ddlPaymentStages.SelectedItem.Text;
            if (string.IsNullOrEmpty(labelerror))
            {
                if (Request.QueryString["ProjectID"] == null)
                {
                    if (!Isalreadyexist(ddlFlatNumber.SelectedValue, ddlPaymentStages.SelectedValue))
                    {
                        int ret = 0;
                        ret = AddedData();
                        if (ret == 1)
                        {
                            BindDemandDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                            BindPaymentStages();

                            lbldoesnotexist.Text = "";
                            divDemandStages.Style.Add("display", "block");
                            divDemandList.Style.Add("display", "block");
                            string title = "Demands";
                            string message = "Demand for " + paymentstage + " has been updated. Please check it out.";
                            string fcm_token = GetFCMTokenByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));

                            // Add Notification to tblFlatNotifications
                            AddNotificationToFlat(Convert.ToInt32(ddlFlatNumber.SelectedValue), title, message);
                            // Call the SendNotificationToUser API to send the notification
                            string notificationSent = CallSendNotificationToUserAPI(fcm_token, title, message);

                            if (!string.IsNullOrEmpty(notificationSent) && notificationSent.Contains("\"success\":true"))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                "Swal.fire({ " + "  title: 'Demand details added & <br> Notification sent successfully!', " +
                                "  icon: 'success', " + "  allowOutsideClick: 'true', " + "  customClass: { " + "    icon: 'handle-icon-clr', " +
                                "    confirmButton: 'handle-btn-success' " + "  } " + "}).then((result) => { " + "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                                "});", true);
                            }
                            ddlPaymentStages.SelectedIndex = 0;
                            VisibleGobtn();
                        }
                        else
                        {
                            string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Demand details couldn't be added due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-demand.aspx'; 
                            }});
                            </script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire({ " +
                              "  title: 'The demand details you’re trying to add already exists', " +
                              "  confirmButtonText: 'OK', " +
                               "  customClass: { " +
                                " confirmButton: 'handle-btn-success', " +
                                "  }" +
                              "});", true);
                    }
                }
                else
                {
                    int ret = 0;
                    //ret = UpdateData();
                    if (ret == 1)
                    {
                        Clear();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                         "Swal.fire({ " +
                            "    title: 'Demand details updated successfully', " +
                            "    icon: 'success', " +
                            "    allowOutsideClick: 'true', " +
                            "    customClass: { " +
                            "        confirmButton: 'handle-btn-success', " +
                            "        icon: 'handle-icon-clr' " +
                            "    } " +
                            "}).then((result) => { " +
                            "        window.location.href = 'view-demand.aspx'; " +
                            "});",
                            true);
                    }
                    else
                    {
                        string script = string.Format(@"  <script>
                        Swal.fire({{
                            title: 'Demand details couldn't be updated due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {{
                                confirmButton: 'handle-btn-success'
                            }}
                        }}).then((result) => {{
                                window.location.href = 'add-demand.aspx?FlatID={0}'; 
                        }});
                    </script>", Convert.ToString(Request.QueryString["FlatID"]));
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire('Validation Alert', '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "btnAdd_Click", ex.Message, "Not Fixed");
        }
    }
    public string GetSqlConnection()
    {
        string connectionString = null;
        try
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Key2h"].ConnectionString;
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "GetSqlConnection", ex.Message, "Not Fixed");
        }
        return connectionString;
    }
    private string GetFCMTokenByFlatID(int flatId)
    {
        string connectionString = GetSqlConnection(); // Fixed variable name
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT TokenID FROM tblFlatCustomerBookingDetails WHERE FlatID = @FlatID", cnn))
            {
                cmd.Parameters.AddWithValue("@FlatID", flatId);
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }
    }
    private string CallSendNotificationToUserAPI(string fcmToken, string title, string message)
    {
        string apiUrl = "https://dbadmin.key2h.com/api/broadcasts/sendtouser"; // Replace with your API URL
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string username = ConfigurationManager.AppSettings["ApiUsername"];
                string password = ConfigurationManager.AppSettings["ApiPassword"];
                string authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create the request data object
                var requestData = new
                {
                    fcm_token = fcmToken,
                    title = title,
                    message = message
                };

                // Serialize the request data using JavaScriptSerializer
                var serializer = new JavaScriptSerializer();
                string jsonData = serializer.Serialize(requestData);

                // Send POST request with the serialized JSON data
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Log the API response for debugging
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    // Return the response for further handling
                    return apiResponse;
                }
                else
                {
                    string errorMessage = "Error: {response.StatusCode} - {response.ReasonPhrase}";
                    // Show error message in the label
                    lblError.Text = errorMessage;
                    return errorMessage;
                }
            }
        }
        catch (Exception ex)
        {
            string exceptionMessage = "Exception: {ex.Message}";
            // Show exception message in the label
           // lblError.Text = exceptionMessage;
            return exceptionMessage;
        }
    }
    private void AddNotificationToFlat(int flatId, string title, string message)
    {
        string connectionString = GetSqlConnection(); // Fixed variable name
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO tblFlatNotifications (FlatID, Title, Message, CreatedDate, ReadStatus, ListStatus) VALUES (@FlatID, @Title, @Message, @CreatedDate,  @ReadStatus, @ListStatus)", cnn))
            {
                cmd.Parameters.AddWithValue("@FlatID", flatId);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Message", message);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ReadStatus", false);
                cmd.Parameters.AddWithValue("@ListStatus", true);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public int AddedData()
    {
        string Amount = string.Empty;
        int PID = 0;
        int ret = 0;
        try
        {
            DataTable dt = KPD.ViewPaymentsheduleByFlatandPLID(Convert.ToInt32(ddlFlatNumber.SelectedValue), Convert.ToInt32(ddlPaymentStages.SelectedValue));
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                Amount = dt.Rows[0]["Amount"].ToString();
                PID = Convert.ToInt32(dt.Rows[0]["PSID"]);
                string filename = string.Empty;
                filename = SaveFile(flDemandUpload, "DemandPDF", ddlFlatNumber.SelectedValue);
                ret = Kdemand.AddFlatCustomerDemands(Convert.ToInt32(ddlFlatNumber.SelectedValue), Convert.ToInt32(ddlPaymentStages.SelectedValue), filename, Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), clientId, "UnPaid", Amount, PID);
            }
            else
            {
                string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'No flat payment details found. Add a payment schedule first.', 
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
            CE.StoreExceptionMessage("add-demand.aspx", "AddedDate", ex.Message, "Not Fixed");
        }
        return ret;
    }
    public string SaveFile(FileUpload uploadedFile, string appkey, string Projectname)
    {
        int savefile = 0;
        string filename = string.Empty;
        try
        {
            string filepath = System.Configuration.ConfigurationManager.AppSettings[appkey];
            string fileName = Path.GetFileName(uploadedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            filename = GenerateFileName(Projectname.Trim(), fileExtension).Trim('-');
            string temppath = filepath.Trim() + @"\" + filename.Trim().Replace(" ", "");
            string savepath = Server.MapPath(temppath);
            uploadedFile.SaveAs(savepath);
            savefile = 1;
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "SaveFile", ex.Message, "Not Fixed");
        }
        return filename.Contains(" ") ? filename.Replace(" ", "") : filename;
    }
    public string GenerateFileName(string Projectname, string fileExtension)
    {
        string randomString = GenerateRandomString(4);
        string newFileName = Projectname + randomString + fileExtension;
        return newFileName;
    }
    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var randomBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }
        var result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = chars[randomBytes[i] % chars.Length];
        }
        return new string(result);
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            string struserid = string.Empty;
            try
            {
            }
            catch (Exception ex)
            {
                // CI.StoreExceptionMessage("edit-project-Progress.aspx", "Repeater1_ItemCommand Save", ex.Message, "Not Fixed");
            }
        }
        if (e.CommandName == "Delete")
        {
        }
    }
    private void RestoreSessionValues()
    {
        if (Session["ProID"] != null)
        {
            ddlProName.SelectedValue = Session["ProID"].ToString();
        }
        if (Session["FlatID"] != null)
        {
            ddlFlatNumber.SelectedValue = Session["FlatID"].ToString();
        }
        if (Session["BlockID"] != null)
        {
            ddlBlockNumber.SelectedValue = Session["BlockID"].ToString();
        }
        if (Session["ddlstages"] != null)
        {
            ddlPaymentStages.SelectedValue = Session["ddlstages"].ToString();
        }
    }
    private void ClearSession()
    {
        if (Session["ProID"] != null)
        {
            Session["ProID"] = null;
        }
        if (Session["FlatID"] != null)
        {
            Session["FlatID"] = null;
        }
        if (Session["BlockID"] != null)
        {
            Session["BlockID"] = null;
        }
        if (Session["ddlstages"] != null)
        {
            Session["ddlstages"] = null;
        }
    }
    protected void LinkButton1_Click(object sender, CommandEventArgs e1)
    {
        try
        {
            for (int i = 0; i < rptDemandList.Items.Count; i++)
            {
                RepeaterItem item = rptDemandList.Items[i];
                FileUpload Fileupload = item.FindControl("uploadThumbnailImg") as FileUpload;
                HiddenField IdHiddenField = item.FindControl("hdnid") as HiddenField;
                HiddenField HiddenFieldPDF = item.FindControl("HiddenFieldPDF") as HiddenField;
                if (IdHiddenField != null)
                {
                    string Id = IdHiddenField.Value;
                    string Iddemond = Convert.ToString(e1.CommandArgument);
                    if (Id == Iddemond)
                    {
                        int ret = 0;
                        if (Fileupload.HasFile)
                        {
                            string filename = SaveFile(Fileupload, "DemandPDF", ddlFlatNumber.SelectedValue);
                            ret = Kdemand.UpdateFlatCostDetails(Convert.ToInt32(IdHiddenField.Value), filename, clientId);
                            if (ret == 1)
                            {
                            }
                        }
                        else
                        {
                            string filename = HiddenFieldPDF.Value;
                            ret = Kdemand.UpdateFlatCostDetails(Convert.ToInt32(IdHiddenField.Value), filename, clientId);
                            if (ret == 1)
                            {
                            }
                        }
                        BindDemandDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                        FlatFunction();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "LinkButton1_Click", ex.Message, "Not Fixed");
        }
    }
    public class CostDetail
    {

        public int Cost { get; set; }
        public string PaymentLabelID { get; set; }
        public string DemandID { get; set; }
        public string PDFName { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hdemontDetails Kdemand = new Key2hdemontDetails();
        List<CostDetail> costDetails = new List<CostDetail>();

        try
        {
            DataTable dt = Kdemand.ViewFlatCustomerDemandsByFlatID(Convert.ToInt32(selectedValue));

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CostDetail costDetail = new CostDetail
                    {
                        PaymentLabelID = BindDemandLabelName(Convert.ToInt32(row["PaymentLabelID"])),
                        DemandID = Convert.ToString(row["DemandID"]),
                        PDFName = Convert.ToString(row["PDFName"])
                    };
                    costDetails.Add(costDetail);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    public static string BindDemandLabelName(int LID)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hdemontDetails Kdemand = new Key2hdemontDetails();
        string StrLabelName = string.Empty;
        try
        {
            DataTable Dt = Kdemand.ViewFlatDemandPaymentLabelNameByPLID(LID);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                StrLabelName = Dt.Rows[0]["PaymentLabel"].ToString();
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "BindDemandLabelName", ex.Message, "Not Fixed");
        }
        return StrLabelName;
    }
    [System.Web.Services.WebMethod]
    public static string DeleteDemand(string demandID, string Selected)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hdemontDetails Kdemand = new Key2hdemontDetails();
        Key2htransaction KT = new Key2htransaction();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            DataTable dt = KT.ViewFilterFlatCustomerTransaction("", "", Selected, "");
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    ret = Kdemand.DeleteFlatCustomerDemandsByDemandID(Convert.ToInt32(demandID));
                    if (ret == 1)
                    {
                        strerror = "Demand details has been deleted";
                    }
                    else
                    {
                        strerror = "Demand details has been not deleted";
                    }
                }
                else
                {
                    strerror = "Sorry, you can't delete as receipts have been sent to the customer.";
                }
            }
            else
            {    
                strerror = "Sorry, you can't delete this due to a server or network issue.";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-demand.aspx", "DeleteDemand", ex.Message, "Not Fixed");
        }
        return strerror;
    }
    [WebMethod]
    public static int GetRowCount(string selectedValue, string ddlproject, string ddlblock)
    {
        int rowCount = 0;
        ClientDashboardError CE = new ClientDashboardError();
        Key2hdemontDetails Kdemand = new Key2hdemontDetails();
        try
        {
            DataTable dt = Kdemand.ViewAllFlatDemandDetails("", ddlproject, ddlblock, selectedValue);
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
            CE.StoreExceptionMessage("add-demand.aspx", "GetRowCount", ex.Message, "Not Fixed");

        }
        return rowCount;
    }
    protected void linkbtnGoPS_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            Response.Redirect("add-payment-schedule.aspx?FlatID=" + ddlFlatNumber.SelectedValue);
        }
        else
        {
            lbldoesnotexist.Text = "Select flat";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-payment-transaction.aspx?FlatID=" + ddlFlatNumber.SelectedValue);
    }
    public void VisibleGobtn()
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            DataTable Demand = Kdemand.ViewFlatCustomerDemandsByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            DataTable DT = KPD.ViewPaymentScheduleByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            if (DT != null && Demand != null)
            {
                hdntotalpaymentShedule.Value = Convert.ToString(DT.Rows.Count);
                if (Demand.Rows.Count >= DT.Rows.Count)
                {
                    divbtngonext.Style.Add("display", "inline-Block");
                }
                else
                {
                    divbtngonext.Style.Add("display", "none");
                }
            }
            else
            {
                divbtngonext.Style.Add("display", "none");
            }
        }
        else
        {
            divbtngonext.Style.Add("display", "none");
        }
    }
}