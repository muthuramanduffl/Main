using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_AddCustomizationTransaction : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientUsers CU = new ClientUsers();
    ClientDashboardError CI = new ClientDashboardError();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hCustomizationTransaction KWT = new Key2hCustomizationTransaction();

    private static string[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
    private static string[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    private static string clientId;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
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

            if (!IsPostBack)
            {
                BindAllDDl();
            }
            if (Request.QueryString["FlatID"] != null)
            {
                int flatIdValue = 0;
                if (int.TryParse(Request.QueryString["FlatID"], out flatIdValue))
                {
                    if (!IsPostBack)
                    {
                        Bind(flatIdValue.ToString());
                    }
                    SetDropdownAttributes(true);
                }
                else
                {
                    // enka irunthu varuthu redirect url issue?
                    ShowAlertAndRedirect("URL is incorrect. please try again", "view-customization-transaction.aspx");
                }
            }
            else
            {
                divtransactionList.Style["Display"] = "none";
                lbldisplayText.Text = "Add Customization";
                // SetDropdownAttributes(false);
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "page load", ex.Message, "Not Fixed");
        }

    }


    private void BindAllDDl()
    {
        Bindblock();
        BindFlat();
        Bindprojects();
        // BindWorkProgress();
    }
    private void SetDropdownAttributes(bool isDisabled)
    {
        ddlProName.Attributes["disabled"] = isDisabled ? "true" : null;
        ddlBlockNumber.Attributes["disabled"] = isDisabled ? "true" : null;
        ddlFlatNumber.Attributes["disabled"] = isDisabled ? "true" : null;
    }
    private void ShowAlertAndRedirect(string message, string redirectUrl)
    {
        string script = string.Format(@"
        <script>
        Swal.fire({{
            title: '{0}',
            confirmButtonText: 'OK',
            customClass: {{
                confirmButton: 'handle-btn-success'
            }}
        }}).then((result) => {{
            window.location.href = '{1}';
        }});
        </script>", message, redirectUrl);

        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
    }

    public void Bind(string ID)
    {
        try
        {
            DataTable dt = KWT.ViewAllFlatCustomisationTransaction("", "", ID, "", "", clientId);
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
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "Bind", ex.Message, "Not Fixed");
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
                //ddlProName.SelectedValue = "18";
            }
            else
            {
                Bindblock();
                BindFlat();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }

    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
        lblcustomernameerror.Text = "";
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
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "Bindblock", ex.Message, "Not Fixed");
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
                ddlDemandType.Items.Clear();
                txtAmount.Text = "";
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
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "BindFlat", ex.Message, "Not Fixed");
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
        if (string.IsNullOrEmpty(labelerror))
        {


            CalReminderAmount(txtAmount.Text.Contains("₹") ? txtAmount.Text.Replace("₹", "") : txtAmount.Text);
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {
                int ret = 0;
                ret = AddData();
                if (ret == 1)
                {
                    divtransactionList.Style.Add("Display", "Block");
                    BindtransactionList(ddlFlatNumber.SelectedValue);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                         "Swal.fire({ " +
                         "  title: 'Customization transaction details added successfully', " +
                         "  icon: 'success', " +
                        "  allowOutsideClick: 'true', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "});", true);
                    txtAmount.Text = "";
                    ddlDemandType.SelectedIndex = 0;
                    ddlPaymentMode.SelectedIndex = 0;
                    txtDate.Text = "";
                }
                else
                {
                    string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'Customization transaction couldn't be added due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-customization-transaction.aspx';  
                            }});
                            </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                //  lblcustomernameerror.Text 
                divtransactionList.Style.Add("Display", "Block");
                BindtransactionList(ddlFlatNumber.SelectedValue);
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
            KWT.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KWT.intCDemandID = Convert.ToInt32(ddlDemandType.SelectedValue);
            KWT.strPaymentStatus = "Paid";
            if (DateTime.TryParseExact(txtDate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                KWT.PaymentUpdatedDate = parsedDate;
            }
            else
            {
                KWT.PaymentUpdatedDate = new DateTime(1753, 1, 1);
            }
            KWT.strPaymentUpdatedBy = clientId;
            KWT.strReceiptPDF = SaveFile(flPaymentTransactionUpload, "CustomizationTransactionReceipt", ddlFlatNumber.SelectedValue);
            KWT.intPaidAmount = Convert.ToInt32(txtAmount.Text.Contains("₹") ? txtAmount.Text.Replace("₹", "") : txtAmount.Text);
            KWT.strPaymentMode = ddlPaymentMode.SelectedValue;
            ret = KWT.AddFlatCustomisationTransaction(KWT);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "AddData", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "SaveFile", ex.Message, "Not Fixed");
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
                "   title: 'Customization transaction details has been cancelled as requested', " +
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
            // divDemandStages.Style.Add("display", "none");
            divtransactionList.Style.Add("display", "none");
            txtAmount.Text = "";

        }
    }

    public void FlatFunction()
    {
        // Kdemand.AlreadyexisttransactionByDemandID(Convert.ToInt32(ddlDemandType.SelectedValue));
        try
        {
            DataTable dt = KC.AlreadyExistProjectdetails(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCustomerName.Text = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplicantFirstName"])) ? "N/A" : Convert.ToString(dt.Rows[0]["ApplicantFirstName"]);
                lbldoesnotexist.Text = "";
                BindDemandType(ddlFlatNumber.SelectedValue);
                divtransactionList.Style.Add("Display", "Block");
                BindtransactionList(ddlFlatNumber.SelectedValue);
            }
            else
            {
                txtCustomerName.Text = "N/A";
                divtransactionList.Style.Add("Display", "none");
                lbldoesnotexist.Text = "Selected flat has no customer records";
                divtransactionList.Style.Add("Display", "Block");
                BindtransactionList(ddlFlatNumber.SelectedValue);
            }
            // BindDemandDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-demand.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }

    public void BindDemandType(string FlatID)
    {
        try
        {
            DataTable dt = KWT.ViewCustomizationDemandTypeByFlatIDandAddedby(FlatID, "", clientId);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlDemandType.DataSource = dt;
                    ddlDemandType.DataTextField = "WorkTitle";
                    ddlDemandType.DataValueField = "CDemandID";
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
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "BindDemandType", ex.Message, "Not Fixed");
        }
    }

    public void BindtransactionList(string FlatID)
    {
        try
        {
            DataTable dt = KWT.ViewFlatCustomisationTranListByFlIDandPBy(FlatID, clientId);
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
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "BindtransactionList", ex.Message, "Not Fixed");
        }
    }

    public void CalReminderAmount(string txtAmt)
    {

        int amount = 0;
        try
        {
            if (int.TryParse(txtAmt, out amount))
            {
                if (amount != 0)
                {
                    DataTable dt = KWT.ViewCustomizationDemandTypeByFlatIDandAddedby(ddlFlatNumber.SelectedValue, ddlDemandType.SelectedValue, clientId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int estimateAmount = 0;
                        if (dt.Rows[0]["Amount"] != DBNull.Value)
                        {
                            estimateAmount = Convert.ToInt32(dt.Rows[0]["Amount"]);
                        }

                        DataTable dtpaidamount = KWT.CalculatePaymentBalance(ddlFlatNumber.SelectedValue, ddlDemandType.SelectedValue, clientId);
                        if (dtpaidamount != null && dtpaidamount.Rows.Count > 0)
                        {
                            int paidAmount = 0;
                            if (dtpaidamount.Rows[0]["PaidAmount"] != DBNull.Value)
                            {
                                paidAmount = Convert.ToInt32(dtpaidamount.Rows[0]["PaidAmount"]);
                            }
                            int difference = paidAmount - estimateAmount;

                            if (difference != 0 && estimateAmount > paidAmount)
                            {
                                if (estimateAmount < Convert.ToInt32(txtAmt))
                                    lblcustomernameerror.Text = "The amount should not exceed";
                                else
                                    lblcustomernameerror.Text = "";
                            }
                            else
                            {
                                lblcustomernameerror.Text = "The amount should not exceed";
                            }
                        }
                        else
                        {
                            lblcustomernameerror.Text = "";
                        }
                    }
                }
                else
                {
                    lblcustomernameerror.Text = "Please enter a valid numeric amount greater than 0.";
                }
            }
            else
            {
                lblcustomernameerror.Text = "Please enter a valid numeric amount greater than 0.";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "CalReminderAmount", ex.Message, "Not Fixed");
        }
    }

    protected void ddlDemandType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlDemandType.SelectedValue))
            {
                //enteredamount = Convert.ToInt32(txtAmount.Text);
                DataTable dt = KWT.ViewCustomizationDemandTypeByFlatIDandAddedby(ddlFlatNumber.SelectedValue, ddlDemandType.SelectedValue, clientId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int estimateAmount = 0;
                    if (dt.Rows[0]["Amount"] != DBNull.Value)
                    {
                        estimateAmount = Convert.ToInt32(dt.Rows[0]["Amount"]);
                    }

                    DataTable dtpaidamount = KWT.CalculatePaymentBalance(ddlFlatNumber.SelectedValue, ddlDemandType.SelectedValue, clientId);
                    if (dtpaidamount != null && dtpaidamount.Rows.Count > 0)
                    {
                        int paidAmount = 0;
                        if (dtpaidamount.Rows[0]["PaidAmount"] != DBNull.Value)
                        {
                            paidAmount = Convert.ToInt32(dtpaidamount.Rows[0]["PaidAmount"]);
                        }

                        if (estimateAmount >= paidAmount)
                        {
                            int difference = paidAmount - estimateAmount;
                            txtAmount.Text = difference.ToString().Trim('-');
                        }
                        else
                        {
                            txtAmount.Text = "";
                        }
                    }
                    else
                    {
                        txtAmount.Text = estimateAmount.ToString();
                    }
                }
                else
                {
                    txtAmount.Text = "0";
                }
            }
            else
            {
                txtAmount.Text = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-customization-transaction.aspx", "ddlDemandType_SelectedIndexChanged", ex.Message, "Not Fixed");
        }
    }
    [System.Web.Services.WebMethod]
    public static string DeleteTransaction(string CTID)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hCustomizationTransaction KWT = new Key2hCustomizationTransaction();
        string strisdelete = string.Empty;
        int ret = 0;
        try
        {
            ret = KWT.DeleteIndivitualFlatCustomizationTransaction(CTID);
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
            CE.StoreExceptionMessage("add-customization-transaction.aspx", "DeleteTransaction", ex.Message, "Not Fixed");
        }
        return strisdelete;
    }
    public class Transaction
    {
        public int CTID { get; set; }
        public string WorkTitle { get; set; }
        public string ReceiptPDF { get; set; }
        public string PaymentMode { get; set; }
        public string PaidAmount { get; set; }
        public string PaymentUpdatedDate { get; set; }
    }
    [WebMethod]
    public static List<Transaction> GetCostDetails(string selectedValue)
    {
        string cID = string.Empty;
        ClientDashboardError CE = new ClientDashboardError();
        Key2hCustomizationTransaction KWT = new Key2hCustomizationTransaction();
        List<Transaction> Transaction = new List<Transaction>();

        HttpCookie LoginIDCookie = HttpContext.Current.Request.Cookies["clientid"];


        if (LoginIDCookie != null && !string.IsNullOrEmpty(LoginIDCookie.Value))
        {
            cID = LoginIDCookie.Value.Contains("clientid=")
                ? LoginIDCookie.Value.Replace("clientid=", "")
                : LoginIDCookie.Value;
        }
        //else
        //{

        //    RedirectHelper.RedirectToPage(HttpContext.Current, "index.aspx");
        //}
        try
        {
            DataTable dt = KWT.ViewFlatCustomisationTranListByFlIDandPBy(selectedValue, cID);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Transaction TRN = new Transaction
                    {
                        CTID = Convert.ToInt32(row["CTID"]),
                        PaymentMode = Convert.ToString(row["PaymentMode"]),
                        WorkTitle = Convert.ToString(row["WorkTitle"]),
                        PaidAmount = Convert.ToString(row["PaidAmount"]),
                        ReceiptPDF = Convert.ToString(row["ReceiptPDF"]),
                        PaymentUpdatedDate = row["PaymentUpdatedDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["PaymentUpdatedDate"]).ToString("dd MM yyyy") : string.Empty
                    };
                    Transaction.Add(TRN);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-transaction.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return Transaction;
    }
    public static string ConvertAmount(double amount)
    {
        try
        {
            Int64 amount_int = (Int64)amount;
            Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
            if (amount_dec == 0)
            {
                return ConvertToWord(amount_int) + " Only.";
            }
            else
            {
                return ConvertToWord(amount_int) + " Point " + ConvertToWord(amount_dec) + " Only.";
            }
        }
        catch (Exception e)
        {
            // TODO: handle exception  
        }
        return "";
    }
    public static string ConvertToWord(Int64 i)
    {
        if (i < 20)
        {
            return units[i];
        }
        if (i < 100)
        {
            return tens[i / 10] + ((i % 10 > 0) ? " " + ConvertToWord(i % 10) : "");
        }
        if (i < 1000)
        {
            return units[i / 100] + " Hundred"
                    + ((i % 100 > 0) ? " And " + ConvertToWord(i % 100) : "");
        }
        if (i < 100000)
        {
            return ConvertToWord(i / 1000) + " Thousand "
            + ((i % 1000 > 0) ? " " + ConvertToWord(i % 1000) : "");
        }
        if (i < 10000000)
        {
            return ConvertToWord(i / 100000) + " Lakh "
                    + ((i % 100000 > 0) ? " " + ConvertToWord(i % 100000) : "");
        }
        if (i < 1000000000)
        {
            return ConvertToWord(i / 10000000) + " Crore "
                    + ((i % 10000000 > 0) ? " " + ConvertToWord(i % 10000000) : "");
        }
        return ConvertToWord(i / 1000000000) + " Arab "
                + ((i % 1000000000 > 0) ? " " + ConvertToWord(i % 1000000000) : "");
    }
    [WebMethod]
    public static string AmttowordConversion(string txtamt, string selectedValue, string demandID)
    {
        Key2hCustomizationTransaction KWT = new Key2hCustomizationTransaction();
        ClientDashboardError CE = new ClientDashboardError();
        string ret = string.Empty;
        string CID = string.Empty;
        try
        {

            HttpCookie LoginIDCookie = HttpContext.Current.Request.Cookies["clientid"];


            if (LoginIDCookie != null && !string.IsNullOrEmpty(LoginIDCookie.Value))
            {
                CID = LoginIDCookie.Value.Contains("clientid=")
                    ? LoginIDCookie.Value.Replace("clientid=", "")
                    : LoginIDCookie.Value;
            }

            double numericValue = 0;
            int estimateAmount = 0;

            if (!string.IsNullOrEmpty(txtamt))
            {
                if (double.TryParse(txtamt, out numericValue))
                {
                    DataTable dt = KWT.ViewCustomizationDemandTypeByFlatIDandAddedby(selectedValue, demandID, CID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Amount"] != DBNull.Value)
                        {
                            estimateAmount = Convert.ToInt32(dt.Rows[0]["Amount"]);
                        }
                        if (estimateAmount >= numericValue)
                        {
                            DataTable dtpaidamount = KWT.CalculatePaymentBalance(selectedValue, demandID, clientId);
                            if (dtpaidamount != null && dtpaidamount.Rows.Count > 0)
                            {
                                int paidAmount = 0;
                                if (dtpaidamount.Rows[0]["PaidAmount"] != DBNull.Value)
                                {
                                    paidAmount = Convert.ToInt32(dtpaidamount.Rows[0]["PaidAmount"]);
                                }
                                int difference = paidAmount - estimateAmount;
                                if (estimateAmount >= difference && difference != 0)
                                    ret = "";
                                else
                                    ret = "1";
                            }
                            else
                            {
                                ret = "";
                            }
                        }
                        else
                        {
                            ret = "1";
                        }
                    }
                    else
                    {
                        ret = "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
            double loanamt = Convert.ToDouble(txtamt);
            if (ret == "")
                ret = ConvertAmount(loanamt);

        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-transaction.aspx", "AmttowordConversion", ex.Message, "Not Fixed");
        }
        return ret;
    }

}
