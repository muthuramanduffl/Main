using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_AddCustomizationWork : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientDashboardError CE = new ClientDashboardError();


    Key2hcustomizationWork KCZW = new Key2hcustomizationWork();
    ClientUsers CU = new ClientUsers();
    public static int CZWID;
    public static string Userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Userid = "1";

            // string clientLoginId = CU.GetClientLoginID();
            // Userid = !string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid=")
            //     ? clientLoginId.Replace("clientid=", "")
            //     : clientLoginId;

            if (!IsPostBack)
            {
                BindAllDDl();
            }


            if (Request.QueryString["CWID"] != null)
            {
                int value = 0;
                if (int.TryParse(Request.QueryString["CWID"], out value))
                {
                    hdnCostID.Value = value.ToString();
                    Bind(value.ToString());
                    divrptCustomers.Style["Display"] = "none";
                    lblDisplaytext.Text = "Edit Customization";
                    SetDropdownAttributes(true);
                }
                else
                {
                    ShowAlertAndRedirect("URL is incorrect. please try again", "view-customization-work.aspx");
                }
            }
            // enka irunthu varuthu redirect url issue?
            else if (Request.QueryString["FlatID"] != null)
            {
                int flatIdValue = 0;
                if (int.TryParse(Request.QueryString["FlatID"], out flatIdValue))
                {
                    lblDisplaytext.Text = "Edit Customization";
                    BindFlatID(flatIdValue.ToString());
                    SetDropdownAttributes(true);
                }
                else
                {
                    // enka irunthu varuthu redirect url issue?
                    ShowAlertAndRedirect("URL is incorrect. please try again", "view-customization-work.aspx");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "BindCity", ex.Message, "Not Fixed");
        }
    }
    // Helper Methods

    private void BindAllDDl()
    {
        Bindblock();
        BindFlat();
        Bindprojects();
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
    public void Bind(string ID)
    {
        try
        {
            DataTable dt = KCZW.ViewAllFlatCustomizationWorks("", "", "", ID, "");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void BindFlatID(string ID)
    {
        try
        {
            DataTable dt = KCZW.ViewAllFlatCustomizationWorks("", "", ID, "", "");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "Bind", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-work.aspx", "Bindblock", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "BindWorkProgressname", ex.Message, "Not Fixed");
        }
        return name;
    }
    public void BindWorkProgress()
    {
        try
        {
            DataTable DT = KCZW.ViewCustomizationWorkProgressStatus("");
            if (DT != null && DT.Rows.Count > 0)
            {
                ddlWorkProgress.DataSource = DT;
                ddlWorkProgress.DataTextField = "WorkProgress";
                ddlWorkProgress.DataValueField = "WorkProgressID";
                ddlWorkProgress.DataBind();
                ddlWorkProgress.Items.Insert(0, new ListItem("", ""));
            }
            else
            {
                ddlWorkProgress.Items.Clear();
                ddlWorkProgress.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-work.aspx", "BindWorkProgress", ex.Message, "Not Fixed");
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
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-work.aspx", "BindFlat", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }
    public class CostDetail
    {
        public int CWID { get; set; }
        public string WorkTitle { get; set; }
        public string WorkStatus { get; set; }
        public string Amount { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {

        Key2hcustomizationWork CW = new Key2hcustomizationWork();
        ClientDashboardError CE = new ClientDashboardError();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable dt = CW.ViewAllFlatCustomisationWorksByFlatID(selectedValue, Convert.ToString(Userid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CostDetail costDetail = new CostDetail
                        {
                            CWID = Convert.ToInt32(row["CWID"]),
                            WorkTitle = Convert.ToString(row["WorkTitle"]),
                            WorkStatus = BindWorkProgressname(Convert.ToString(row["WorkStatus"])),
                            Amount = Convert.ToString(row["Amount"])
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    [WebMethod]
    public static string DeleteCustomizationWorksTitle(string CWID, string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hcustomizationWork CW = new Key2hcustomizationWork();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            ret = CW.DeleteFlatCustomizationWorksTitle(Convert.ToInt32(selectedValue), Convert.ToInt32(CWID));
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
            CE.StoreExceptionMessage("add-customization-work.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
        }
        return strerror;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text)
            && string.IsNullOrEmpty(txtWorkTitle.Text) && string.IsNullOrEmpty(ddlWorkProgress.SelectedValue)
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
        else if (string.IsNullOrEmpty(txtWorkTitle.Text))
        {
            labelerror = "Enter work title";
        }
        else if (string.IsNullOrEmpty(ddlWorkProgress.SelectedValue))
        {
            labelerror = "Select work progress";
        }
        else if (string.IsNullOrEmpty(txtAmount.Text))
        {
            labelerror = "Enter amount";
        }
        if (string.IsNullOrEmpty(labelerror))
        {
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {
                DataTable dt = KCZW.ViewAllFlatCustomisationWorksByFlatID (ddlFlatNumber.SelectedValue, Userid);
                if (dt != null && dt.Rows.Count < 10)
                {
                    int ret = 0;
                    ret = AddData();
                    if (ret == 1)
                    {
                        ddlWorkProgress.SelectedIndex = 0;
                        txtWorkTitle.Text = "";
                        txtAmount.Text = "";
                        ScriptManager.RegisterStartupScript(UpdatePanel9, UpdatePanel9.GetType(), "alert",
                         "Swal.fire({ " +
                         "  title: 'customization work added successfully', " +
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
                    "  title: 'You can upload a maximum of 10 customization works only.', " +
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
    public void BindCustomizationWorkList()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
            {
                DataTable dt = KCZW.ViewAllFlatCustomisationWorksByFlatID(ddlFlatNumber.SelectedValue, Convert.ToString(Userid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    divrptCustomers.Style.Add("Display", "block");
                    rpCustomization.Visible = true;
                    rpCustomization.DataSource = dt;
                    rpCustomization.DataBind();
                }
                else
                {
                    divrptCustomers.Style.Add("Display", "none");
                    rpCustomization.Visible = false;
                }
            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
                rpCustomization.Visible = false;
            }
        }

        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-work.aspx", "BindCustomizationWorkList", ex.Message, "Not Fixed");
        }
    }
    public int AddData()
    {
        int rowaffected = 0;
        try
        {
            KCZW.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KCZW.strWorkTitle = txtWorkTitle.Text;
            KCZW.strWorkStatus = ddlWorkProgress.SelectedValue;
            KCZW.strAmount = Convert.ToString(txtAmount.Text.Contains("₹") ? txtAmount.Text.Replace("₹", "") : txtAmount.Text);
            KCZW.strAddedBy = Userid;
            rowaffected = KCZW.AddCustomWorkdetails(KCZW);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-customization-work.aspx", "AddCustomWorkdetails", ex.Message, "Not Fixed");
        }
        return rowaffected;
    }
}