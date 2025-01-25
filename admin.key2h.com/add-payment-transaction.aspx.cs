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

public partial class adminkey2hcom_AddPaymentTransaction : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientUsers CU = new ClientUsers();
    ClientDashboardError CI = new ClientDashboardError();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2htransaction KT = new Key2htransaction();
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
            Response.Redirect("index.aspx");
        }
        if (Request.QueryString["TransactionID"] == null && Request.QueryString["FlatID"] == null)
        {
            if (!IsPostBack)
            {
                Bindprojects();
                Bindblock();
                BindFlat();
                btnSave.Text = "Submit";
                lbldisplayText.Text = "Add Payment Transaction";
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;
                ddlFlatNumber.Enabled = true;
            }
        }
        else if (Request.QueryString["FlatID"] != null)
        {
            if (!IsPostBack)
            {
                Bindprojects();
                Bindblock();
                BindFlat();
                btnSave.Text = "Submit";
                lbldisplayText.Text = "Edit Payment Transaction";
                BindFlat(Convert.ToString(Request.QueryString["FlatID"]));
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;
                ddlFlatNumber.Enabled = true;
            }
        }

        else
        {
            if (!IsPostBack)
            {
                Bindprojects();
                Bindblock();
                BindFlat();
                btnSave.Text = "Submit";
                lbldisplayText.Text = "Edit Payment Transaction";
                Bind(Convert.ToString(Request.QueryString["TransactionID"]));
                ddlProName.Attributes.Add("disabled", "true");
                ddlBlockNumber.Attributes.Add("disabled", "true");
                ddlFlatNumber.Attributes.Add("disabled", "true");
            }
        }
    }

    public void Bind(string ID)
    {
        try
        {
            DataTable dt = KT.ViewFilterFlatCustomerTransaction("", "", "", ID);
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
                    FlatFunction();
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-Payment-transaction.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void BindFlat(string ID)
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
            CI.StoreExceptionMessage("add-Payment-transaction.aspx", "Bind", ex.Message, "Not Fixed");
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
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-payment-transaction.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
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
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-payment-transaction.aspx", "Bindblock", ex.Message, "Not Fixed");
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
                    lbldoesnotexist.Text = "";
                }
                else
                {
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                    ddlFlatNumber.Items.Insert(1, new ListItem("No Flat number", ""));
                    lbldoesnotexist.Text = "";
                }

            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
                lbldoesnotexist.Text = "";
                lblDemandTypeMessage.Text = "";
                divtransactionList.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-payment-transaction.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text) &&
            string.IsNullOrEmpty(ddlDemandType.SelectedValue) && !flPaymentTransactionUpload.HasFile &&
            string.IsNullOrEmpty(txtAmount.Text) && string.IsNullOrEmpty(ddlPaymentMode.SelectedValue) &&
            string.IsNullOrEmpty(txtDate.Text))
        {
            labelerror = "Fill the mandatory field";
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
        else if (string.IsNullOrEmpty(ddlDemandType.SelectedValue))
        {
            labelerror = "Select demand type";
        }
        else if (string.IsNullOrEmpty(txtAmount.Text))
        {
            labelerror = "Enter amount";
        }
        else if (string.IsNullOrEmpty(ddlPaymentMode.SelectedValue))
        {
            labelerror = "Select payment mode";
        }
        else if (string.IsNullOrEmpty(txtDate.Text))
        {
            labelerror = "Select date";
        }
        string paymentstage = ddlDemandType.SelectedItem.Text;
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["TransactionID"] == null)
            {
                int ret = 0;
                ret = AddData();
                if (ret == 1)
                {
                    divtransactionList.Style.Add("Display", "Block");
                    BindtransactionList(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                    string title = "Transactions ";
                    string message = "Receipt for the payment of demand - " + paymentstage + " has been uploaded. Please check it out.";
                    string fcm_token = GetFCMTokenByFlatID(Convert.ToInt32(ddlFlatNumber.SelectedValue));

                    // Add Notification to tblFlatNotifications
                    AddNotificationToFlat(Convert.ToInt32(ddlFlatNumber.SelectedValue), title, message);
                    // Call the SendNotificationToUser API to send the notification
                    string notificationSent = CallSendNotificationToUserAPI(fcm_token, title, message);

                    if (!string.IsNullOrEmpty(notificationSent) && notificationSent.Contains("\"success\":true"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " + "  title: 'Payment transaction details added & <br> Notification sent successfully!', " +
                        "  icon: 'success', " + "  allowOutsideClick: 'true', " + "  customClass: { " + "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " + "  } " + "}).then((result) => { " + "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                        "});", true);
                    }

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    // "Swal.fire({ " +
                    //     "  title: 'Payment transaction details added successfully', " +
                    //     "  icon: 'success', " +
                    //     "  allowOutsideClick: 'true', " +
                    //     "  customClass: { " +
                    //     "    icon: 'handle-icon-clr', " +
                    //     "    confirmButton: 'handle-btn-success' " +
                    //     "  } " +
                    //     "}).then((result) => { " +
                    //     "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                    //     "});", true);
                }
                else
                {
                    string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Payment transaction details couldn't be added due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-payment-transaction.aspx'; 
                            }});
                            </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                int ret = 0;
                ret = AddData();
                if (ret == 1)
                {
                    divtransactionList.Style.Add("Display", "Block");
                    BindtransactionList(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                        "  title: 'Payment transaction details added successfully', " +
                        "  icon: 'success', " +
                        "  allowOutsideClick: 'true', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "}).then((result) => { " +
                        "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                        "});", true);
                }
                else
                {
                    string script = string.Format(@"  <script>
                        Swal.fire({{
                            title: 'Payment transaction details couldn't be updated due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {{
                                confirmButton: 'handle-btn-success'
                            }}
                        }}).then((result) => {{
                                window.location.href = 'add-payment-transaction.aspx?FlatID={0}'; 
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
            "Swal.fire('Validation Alert', '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
    }

    public int AddData()
    {
        int ret = 0;
        DateTime parsedDate;
        string dateFormat = "dd-MM-yyyy";
        try
        {
            KT.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KT.intDemandID = Convert.ToInt32(ddlDemandType.SelectedValue);
            KT.strPaymentStatus = "Paid";
            if (DateTime.TryParseExact(txtDate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                KT.PaymentUpdatedDate = parsedDate;
            }
            else
            {
                KT.PaymentUpdatedDate = new DateTime(1753, 1, 1);
            }
            KT.strPaymentUpdatedBy = clientId;
            KT.intBlockNo = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KT.strReceiptPDF = SaveFile(flPaymentTransactionUpload, "TransactionReceipt", ddlFlatNumber.SelectedValue);
            KT.intPaidamount = Convert.ToInt32(txtAmount.Text.Contains("₹") ? txtAmount.Text.Replace("₹", "") : txtAmount.Text);
            KT.strPaymentMode = ddlPaymentMode.SelectedValue;
            ret = KT.AddFlatCustomerTransaction(KT);
        }
        catch (Exception ex)
        {
        }
        return ret;
    }
    public string SaveFile(FileUpload uploadedFile, string appkey, string Projectname)
    {
        int savefile = 0;
        string filename = string.Empty;
        try
        {
            if (uploadedFile.HasFile)
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
            else
            {
                filename = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-payment-transaction.aspx", "SaveFile", ex.Message, "Not Fixed");
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
        var byteArray = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(byteArray);
        }
        var randomString = new char[length];
        for (int i = 0; i < length; i++)
        {
            randomString[i] = chars[byteArray[i] % chars.Length];
        }
        return new string(randomString);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["TransactionID"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //      "Swal.fire('Cancelled!', 'Your action has been canceled.', 'success');",
            //      true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                "   title: 'Payment transaction details has been cancelled as requested', " +
                "   confirmButtonText: 'OK', " +
                "   customClass: { " +
                "       confirmButton: 'handle-btn-success' " +
                "   } " +
                "}).then((result) => { " +
                "   if (result.isConfirmed) { " +
                "     window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                "   } " +
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
            ddlDemandType.Items.Clear();
            txtCustomerName.Text = "";
            lbldoesnotexist.Text = "";
            divtransactionList.Style.Add("display", "none");
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
                BindDemandType(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                divtransactionList.Style.Add("Display", "Block");
                BindtransactionList(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            }
            else
            {
                txtCustomerName.Text = "N/A";
                divtransactionList.Style.Add("Display", "none");
                lbldoesnotexist.Text = "Selected flat has no customer records";
                divtransactionList.Style.Add("Display", "Block");
                BindtransactionList(Convert.ToInt32(ddlFlatNumber.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-demand.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }

    public void BindDemandType(int FlatID)
    {
        DataTable dt = KT.ViewDemandTypeByFlatID(FlatID);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (dt.Rows.Count > 0)
            {
                ddlDemandType.DataSource = dt;
                ddlDemandType.DataTextField = "PaymentLabel";
                ddlDemandType.DataValueField = "DemandID";
                ddlDemandType.DataBind();
                ddlDemandType.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                ddlDemandType.Items.Clear();
                ddlDemandType.Items.Insert(0, new ListItem("", ""));
            }
        }
    }

    public void BindtransactionList(int FlatID)
    {
        try
        {
            DataTable dt = KT.ViewAllFlatCustomerTransactionByFlatID(FlatID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptransactionList.Visible = true;
                rptransactionList.DataSource = dt;
                rptransactionList.DataBind();
                divtransactionList.Style.Add("Display", "block");
            }
            else
            {
                rptransactionList.Visible = false;
                divtransactionList.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-payment-transaction.aspx", "BindDemandList", ex.Message, "Not Fixed");
        }
    }

    protected void ddlDemandType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlDemandType.SelectedValue))
        {

        }
    }

    [System.Web.Services.WebMethod]
    public static string DeleteTransaction(string hdnTrasactionID)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2htransaction KT = new Key2htransaction();
        string strisdelete = string.Empty;
        int ret = 0;
        try
        {
            ret = KT.DeleteIndivitualFlatCustomerTransaction(Convert.ToInt32(hdnTrasactionID));
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
            CE.StoreExceptionMessage("add-payment-transaction.aspx", "DeleteTransaction", ex.Message, "Not Fixed");
        }
        return strisdelete;
    }

    public class Transaction
    {
        public int TransactionID { get; set; }
        public string PaymentLabel { get; set; }
        public string ReceiptPDF { get; set; }
    }
    [WebMethod]
    public static List<Transaction> GetCostDetails(string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2htransaction KT = new Key2htransaction();
        List<Transaction> Transaction = new List<Transaction>();
        try
        {
            DataTable dt = KT.ViewAllFlatCustomerTransactionByFlatID(Convert.ToInt32(selectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Transaction TRN = new Transaction
                    {
                        TransactionID = Convert.ToInt32(row["TransactionID"]),
                        PaymentLabel = Convert.ToString(row["PaymentLabel"]),
                        ReceiptPDF = Convert.ToString(row["ReceiptPDF"]),
                    };
                    Transaction.Add(TRN);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-payment-transaction.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return Transaction;
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
            // Log the exception or handle it
            Console.WriteLine(ex.Message); // or log it to a file or monitoring system
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
                    //lblError.Text = errorMessage;
                    return errorMessage;
                }
            }
        }
        catch (Exception ex)
        {
            string exceptionMessage = "Exception: {ex.Message}";
            // Show exception message in the label
            //lblError.Text = exceptionMessage;
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

}