using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_FlatQualityReport : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hFlat KF = new Key2hFlat();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientDashboardError CE = new ClientDashboardError();
    Key2hQualityReports KD = new Key2hQualityReports();
    ClientUsers CU = new ClientUsers();
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
            Userid = clientLoginId;
        }

        if (!IsPostBack)
        {
             try
            {
                if (Request.QueryString["QFID"] == null)
                {

                    Bindprojects();
                    Bindblock();
                    BindFlat();
                    divrptCustomers.Style.Add("Display", "none"); 
                    lblDisplaytext.Text = "Add Report";
                    ddlProName.Enabled = true;
                    ddlBlockNumber.Enabled = true;
                    ddlFlatNumber.Enabled = true;
                }
                else
                {
                    Bindprojects();
                    Bind(Convert.ToString(Request.QueryString["QFID"]));
                    divrptCustomers.Style.Add("Display", "none"); 
                    lblDisplaytext.Text = "Edit Flat Quality Report";
                    ddlProName.Attributes.Add("disabled", "true");
                    ddlBlockNumber.Attributes.Add("disabled", "true");
                    ddlFlatNumber.Attributes.Add("disabled", "true");
                }
            }
            catch (Exception ex)
            {
                CE.StoreExceptionMessage("flat-quality-report.aspx", "BindCity", ex.Message, "Not Fixed");
            }
        }
    }
    

    public void Bind(string ID)
    {
        try
        {
            DataTable dt = KD.ViewAllFlatQualityReports("", "", "", ID);
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "Bind", ex.Message, "Not Fixed");
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
                 divrptCustomers.Style.Add("Display", "none");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "Bindblock", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }

    public void BindCostDetails(int ID)
    {
        try
        {
            DataTable dt = KD.ViewFlatQualityReportbyFlatID(ID);
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "BindCostDetails", ex.Message, "Not Fixed");
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
            DataTable dt = KD.AlreadyExistFlatQualityReporttByProIDBlockIDFlatID(PID, BlockID, FlatID);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // if (dt.Rows[i]["CostLabelID"].ToString() == CostlabelID)
                    // {
                    //     isavail = true;
                    //     break;
                    // }
                }
            }

        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }

    [System.Web.Services.WebMethod]
    public static bool CheckProjectExistence(int project, int CostalID, int FlatID)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hQualityReports KD = new Key2hQualityReports();
        bool isavail = false;
        try
        {
            DataTable dt = KD.AlreadyExistFlatQualityReporttByProIDBlockIDFlatID(project, CostalID, FlatID);
            if (dt != null && dt.Rows.Count > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
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
                "   title: 'Flat quality report details has been cancelled as requested', " +
                "   confirmButtonText: 'OK', " +
                "   customClass: { " +
                "       confirmButton: 'handle-btn-success' " +
                "   } " +
                "}).then((result) => { " +
                "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
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
            DataTable dt = KC.AlreadyExistProjectdetails(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCustomerName.Text = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ApplicantFirstName"])) ? "N/A" : Convert.ToString(dt.Rows[0]["ApplicantFirstName"]);
                lblcustomernameerror.Text = "";
                divrptCustomers.Style.Add("Display", "block");
            }
            else
            {
                txtCustomerName.Text = "N/A";
                divrptCustomers.Style.Add("Display", "none");
                lblcustomernameerror.Text = "No customer for selected flat.";  //due out

            } 
            if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            {
                // BindCostLabel();
                BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));

            }
            else
            {
                divrptCustomers.Style.Add("Display", "none");
            }

        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }

    [System.Web.Services.WebMethod]
    public static string UpdateCustomer(string Title, int QFID, string costParameterName, string PDFName, string selectedValue)
    {
        string strret = string.Empty;
        int ret = 0;
        Key2hQualityReports KD = new Key2hQualityReports();
        ClientDashboardError CE = new ClientDashboardError();
        try
        {
            KD.Title = Convert.ToString(Title);
            KD.QFID = Convert.ToInt32(QFID);
            KD.PDFName = Convert.ToString(PDFName);
            KD.FlatID = Convert.ToInt32(selectedValue);
            KD.UpdatedBy = 1;

            ret = KD.UpdateFlatQualityReport(KD);
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "UpdateCustomer", ex.Message, "Not Fixed");
        }
        return strret;
    }

    [System.Web.Services.WebMethod]
    public static string DeleteCustomer(string costLabelID, string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            Key2hQualityReports KD = new Key2hQualityReports();
            ret = KD.DeleteFlatQualityReports(Convert.ToInt32(costLabelID), Convert.ToInt32(selectedValue));

            if (ret == 1)
            {
                strerror = "Row deleted successfully!";
            }
            else
            {
                strerror = "Row not deleted!";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
        }
        return strerror;
    }

    [WebMethod]
    public static int GetRowCount(string selectedValue)
    {
        ClientDashboardError CE = new ClientDashboardError();
        Key2hQualityReports KD = new Key2hQualityReports();
        int rowCount = 0;
        try
        {
            DataTable dt = KD.ViewFlatQualityReportbyFlatID(Convert.ToInt32(selectedValue));
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
            CE.StoreExceptionMessage("flat-quality-report.aspx", "GetRowCount", ex.Message, "Not Fixed");
        }
        return rowCount;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text)
            && string.IsNullOrEmpty(txtTitle.Text) && !flUpload.HasFile)
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
        else if (string.IsNullOrEmpty(txtTitle.Text))
        {
            labelerror = "Enter title";
        }
       
        if (string.IsNullOrEmpty(labelerror))
        {

            if (!Isalreadyexist(Convert.ToInt32(ddlProName.SelectedValue), Convert.ToInt32(ddlBlockNumber.SelectedValue), Convert.ToInt32(ddlFlatNumber.SelectedValue)))
            {
                int ret = 0;
                ret = AddFlatQualityReports();
                if (ret == 1)
                { 
                    BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));
                    txtTitle.Text = ""; 
                }
                else
                {
                    string script = string.Format(@" <script>
                    Swal.fire({{ 
                        title: 'Flat quality report details not added due to a server or network issue', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success' 
                        }} 
                    }}).then((result) => {{  
                            window.location.href = 'flat-quality-report.aspx';  
                    }});
                    </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                      "  title: 'The flat quality report details you’re trying to add already exists', " +
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
            "Swal.fire({ title: 'Validation Alert', text: '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
        divrptCustomers.Style.Add("Display", "block");
    }

    public int AddFlatQualityReports()
    {
        int rowaffected = 0;

        try
        {
            KD.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KD.BlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KD.FlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KD.Title = Convert.ToString(txtTitle.Text);
            KD.PDFName = Convert.ToString(flUpload.FileName);
            KD.AddedBy = 1;
            rowaffected = KD.AddFlatQualityReports(KD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "AddFlatQualityReports", ex.Message, "Not Fixed");
        }
        return rowaffected;
    }

    public int UpdateFlatQualityReport()
    {
        int rowaffected = 0;
        try
        {
            KD.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KD.BlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KD.FlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KD.Title = Convert.ToString(txtTitle.Text);
            KD.PDFName = Convert.ToString(flUpload.FileName);
            KD.UpdatedBy = 1;
            rowaffected = KD.UpdateFlatQualityReport(KD);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "UpdateFlatQualityReport", ex.Message, "Not Fixed");
        }
        return rowaffected;
    }
     
    public class QualityReport
    {
        public int QFID { get; set; }
        public string Title { get; set; }
        public string PDFName { get; set; }
    }

    [WebMethod]
    public static List<QualityReport> GetQualityReport(string selectedValue)
    {
        Key2hQualityReports KD = new Key2hQualityReports();
        ClientDashboardError CE = new ClientDashboardError();
        List<QualityReport> qualityreport = new List<QualityReport>();
        try
        {
            DataTable dt = KD.ViewFlatQualityReportbyFlatID(Convert.ToInt32(selectedValue));

            if (dt != null && dt.Rows.Count > 0)
            { 
                foreach (DataRow row in dt.Rows)
                {
                    QualityReport qualityreports = new QualityReport
                    {
                        QFID = Convert.ToInt32(row["QFID"]),
                        Title = Convert.ToString(row["Title"]),
                        PDFName = Convert.ToString(row["PDFName"])
                    };
                    qualityreport.Add(qualityreports);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("flat-quality-report.aspx", "UpdateCostdetails", ex.Message, "Not Fixed");
        }
        return qualityreport;
    }
}