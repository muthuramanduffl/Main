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

public partial class adminkey2hcom_AddCustomizationDemand : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientDashboardError CE = new ClientDashboardError();


    Key2hcustomizationWork KCZW = new Key2hcustomizationWork();
    Key2hcustomizationdemend KCZWD = new Key2hcustomizationdemend();
    ClientUsers CU = new ClientUsers();
    public static int CZWID;
    public static string Userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                BindAllDDl();
            }


            if (Request.QueryString["FlatID"] != null)
            {
                int flatIdValue = 0;
                if (int.TryParse(Request.QueryString["FlatID"], out flatIdValue))
                {
                    if (!IsPostBack)
                    {
                        BindFlatID(flatIdValue.ToString());
                    }
                    SetDropdownAttributes(true);
                }
                else
                {
                    // enka irunthu varuthu redirect url issue?
                    ShowAlertAndRedirect("URL is incorrect. please try again", "view-project.aspx");
                }
            }
            else
            {
                divrptCustomers.Style["Display"] = "none";
                lblDisplaytext.Text = "Add Customization";

                // SetDropdownAttributes(false);
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("view-customization-demend.aspx", "page load", ex.Message, "Not Fixed");
        }
    }
    // Helper Methods

    private void BindAllDDl()
    {
        Bindprojects();
        Bindblock();
        BindFlat();
        
        BindWorkProgress();
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

    public void BindFlatID(string ID)
    {
        try
        {
            DataTable dt = KCZWD.ViewAllFlatCustomerDemands("", "", ID, "", "", "");
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
            CE.StoreExceptionMessage("add-customization-demend.aspx", "Bind", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-customization-demend.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
                    BindFlat();
                    txtCustomerName.Text = "";
                    lblcustomernameerror.Text = "";
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                divrptCustomers.Style.Add("Display", "none");
                BindFlat();
                txtCustomerName.Text = "";
                lblcustomernameerror.Text = "";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    public static string BindWorkProgressname(string id)
    {
        Key2hcustomizationWork KCZW = new Key2hcustomizationWork();
        ClientDashboardError CE = new ClientDashboardError();
        string name = string.Empty;
        try
        {
            DataTable DT = KCZW.ViewCustomizationWorkProgressStatus(id);
            if (DT != null && DT.Rows.Count > 0)
            {
                name = DT.Rows[0]["WorkProgress"].ToString();
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "BindWorkProgressname", ex.Message, "Not Fixed");
        }
        return name;
    }
    public void BindWorkProgress()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                DataTable DT = KCZW.ViewAllFlatCustomisationWorksByFlatID(ddlFlatNumber.SelectedValue, Convert.ToString(Userid));
                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlWorkList.DataSource = DT;
                    ddlWorkList.DataTextField = "WorkTitle";
                    ddlWorkList.DataValueField = "CWID";
                    ddlWorkList.DataBind();
                    ddlWorkList.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlWorkList.Items.Clear();
                    ddlWorkList.Items.Insert(0, new ListItem("", ""));
                }
            }
            else
            {
                ddlWorkList.Items.Clear();
                ddlWorkList.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "BindWorkProgress", ex.Message, "Not Fixed");
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
                lblcustomernameerror.Text = "";
                BindWorkProgress();
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "BindFlat", ex.Message, "Not Fixed");
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["CWID"] == null)
        {
            Clear();
            //'Your action has been canceled.' 
        }

        else
        {
            Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                "   title: 'Customization details has been cancelled as requested', " +
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
            ddlWorkList.Items.Clear();
            ddlWorkList.Items.Insert(0, new ListItem("", ""));
        }
    }
    public void FlatFunction()
    {
        try
        {
            DataTable dt = KC.ViewAllflatBookingCustomerDetails(ddlProName.SelectedValue, ddlBlockNumber.SelectedValue, ddlFlatNumber.SelectedValue, "", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCustomerName.Text = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplicantFirstName"])) ? "N/A" : Convert.ToString(dt.Rows[0]["ApplicantFirstName"]);
                lblcustomernameerror.Text = "";
                divrptCustomers.Style.Add("Display", "block");
                BindCustomizationWorkList();
                BindWorkProgress();
            }
            else
            {

                txtCustomerName.Text = "N/A";
                divrptCustomers.Style.Add("Display", "none");
                lblcustomernameerror.Text = "Selected flat has no customer records";  //due out
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }
    public class CostDetail
    {
        public int CWID { get; set; }
        public string WorkTitle { get; set; }
        public string WorkStatus { get; set; }
        public string Amount { get; set; }
        public string PDFName { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {

        Key2hcustomizationdemend CWD = new Key2hcustomizationdemend();
        ClientDashboardError CE = new ClientDashboardError();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable dt = CWD.ViewAllFlatCustomisationDemandsByFIDandABy(selectedValue, Convert.ToString(Userid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CostDetail costDetail = new CostDetail
                        {
                            CWID = Convert.ToInt32(row["CWID"]),
                            WorkTitle = Convert.ToString(row["WorkTitle"]),
                            Amount = Convert.ToString(row["Amount"]),
                            PDFName = Convert.ToString(row["PDFName"])
                        };
                        costDetails.Add(costDetail);
                    }
                }
            }
            else
            {
                // no action
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    [WebMethod]
    public static string DeleteCustomisationDemands(string CDemandID, string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hcustomizationdemend CWD = new Key2hcustomizationdemend();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            ret = CWD.DeleteFlatCustomisationDemands(Convert.ToInt32(selectedValue), Convert.ToInt32(CDemandID));
            if (ret == 1)
            {
                strerror = "1";
            }
            else
            {
                strerror = "0";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
        }
        return strerror;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text)
            && !flDemandUpload.HasFile && string.IsNullOrEmpty(ddlWorkList.SelectedValue)
            && string.IsNullOrEmpty(txtAmount.Text))
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
        else if (!flDemandUpload.HasFile)
        {
            labelerror = "Upload demand file";
        }
        else if (string.IsNullOrEmpty(ddlWorkList.SelectedValue))
        {
            labelerror = "Select work list";
        }
        else if (string.IsNullOrEmpty(txtAmount.Text))
        {
            labelerror = "Enter amount";
        }
        if (string.IsNullOrEmpty(labelerror))
        {
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {
                if (!Isalreadyexist(ddlFlatNumber.SelectedValue, ddlWorkList.SelectedValue))
                {
                    DataTable dt = KCZWD.ViewAllFlatCustomisationDemandsByFIDandABy(ddlFlatNumber.SelectedValue, Userid);
                    if (dt != null && dt.Rows.Count < 10)
                    {
                        int ret = 0;
                        ret = AddData();
                        if (ret == 1)
                        {
                            ddlWorkList.SelectedIndex = 0;
                            txtAmount.Text = "";
                            ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "alert",
                             "Swal.fire({ " +
                             "  title: 'Customization demand added successfully', " +
                             "  icon: 'success', " +
                             "  customClass: { " +
                             "    icon: 'handle-icon-clr', " +
                             "    confirmButton: 'handle-btn-success' " +
                             "  } " +
                             "});", true);
                            divrptCustomers.Style.Add("Display", "block");
                            UpdatePanel9.Update();
                            BindCustomizationWorkList();
                        }
                        else
                        {
                            string script = string.Format(@" <script>
                         Swal.fire({{ 
                         title: 'Customization details not added due to a server or network issue', 
                         confirmButtonText: 'OK', 
                         customClass: {{ 
                            confirmButton: 'handle-btn-success' 
                         }} 
                         }}).then((result) => {{  
                            window.location.href = 'add-customization-work.aspx';  
                         }});
                         </script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                        }
                    }
                    else
                    {
                        //maximum limit 10
                        ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "alert",
                     "Swal.fire({ " +
                     "  title: 'You can upload a maximum of 10 customization demands only.', " +
                     "  confirmButtonText: 'OK'," +
                     "  customClass: { " +
                     "    icon: 'handle-icon-clr', " +
                     "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "});", true);
                        divrptCustomers.Style.Add("Display", "block");
                        UpdatePanel9.Update();
                        BindCustomizationWorkList();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "alert",
                           "Swal.fire({ " +
                             "  title: 'The customization demand details you’re trying to add already exists', " +
                             "  confirmButtonText: 'OK', " +
                              "  customClass: { " +
                               " confirmButton: 'handle-btn-success', " +
                               "  }" +
                             "});", true);
                    divrptCustomers.Style.Add("Display", "block");
                    UpdatePanel9.Update();
                    BindCustomizationWorkList();
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

    }

    public bool Isalreadyexist(string FlatID, string CWID)
    {
        bool isavail = false;
        DataTable dt = KCZWD.ViewAllFlatCustomerDemands("", "", FlatID, CWID, "", Userid);
        if (dt != null && dt.Rows.Count > 0)
        {
            isavail = true;
        }


        return isavail;
    }



    public void BindCustomizationWorkList()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                DataTable dt = KCZWD.ViewAllFlatCustomisationDemandsByFIDandABy(ddlFlatNumber.SelectedValue, Convert.ToString(Userid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    divrptCustomers.Style.Add("Display", "block");
                    rptCustomizationdemand.Visible = true;
                    rptCustomizationdemand.DataSource = dt;
                    rptCustomizationdemand.DataBind();
                }
                else
                {
                    divrptCustomers.Style.Add("Display", "none");
                    rptCustomizationdemand.Visible = false;
                }
            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
                rptCustomizationdemand.Visible = false;
            }
        }

        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "BindCustomizationWorkList", ex.Message, "Not Fixed");
        }
    }
    public int AddData()
    {
        int rowaffected = 0;
        try
        {

            KCZWD.intCWID = Convert.ToInt32(ddlWorkList.SelectedValue);
            KCZWD.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KCZWD.straddedBy = Userid;
            KCZWD.strPDFName = SaveFile(flDemandUpload, "CustomizationDemandDoc", ddlFlatNumber.SelectedValue);
            rowaffected = KCZWD.AddFlatCustomisationDemands(KCZWD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-demend.aspx", "AddCustomWorkdetails", ex.Message, "Not Fixed");
        }
        return rowaffected;
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
            CE.StoreExceptionMessage("add-customization-demend.aspx", "SaveFile", ex.Message, "Not Fixed");
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

    protected void ddlWorkList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlWorkList.SelectedValue))
        {
            DataTable dt = KCZW.ViewAllFlatCustomizationWorks("", "", "", ddlWorkList.SelectedValue, "");
            if (dt != null && dt.Rows.Count > 0)
            {
                txtAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                BindCustomizationWorkList();
            }
            else
            {
                txtAmount.Text = "";
            }
        }
    }
}