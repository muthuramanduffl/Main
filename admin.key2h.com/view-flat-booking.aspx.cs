
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

public partial class adminkey2hcom_ViewFlatBooking : System.Web.UI.Page
{ 
    Key2hLeadSource LS = new Key2hLeadSource();
    DataTable dt1 = new DataTable();
    DataRow dr1;

    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProjectblock KB = new Key2hProjectblock();

    Key2hFlat KF = new Key2hFlat();
    Key2hProject K2 = new Key2hProject();
    Key2hCustomer KC = new Key2hCustomer(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlBindProject();
            Bindblock();
            Bind(); 
        }
    }
     
    public void ddlBindProject()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects(); 
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlprojectname.Items.Clear();
                ddlprojectname.DataSource = dt;
                ddlprojectname.DataTextField = "ProjectName";
                ddlprojectname.DataValueField = "ProjectID";
                ddlprojectname.DataBind();
                ddlprojectname.Items.Insert(0, new ListItem("All", "")); 
            }
            else
            {
                ddlprojectname.Items.Insert(0, new ListItem("All", ""));
                ddlprojectname.Items.Insert(2, new ListItem("No projects", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "ddlBindProject", ex.Message, "Not Fixed");            
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
     
    public string Bindproject(int ID)
    {
        string Project = string.Empty;
        try
        {
            DataTable dt = K2.ViewAllProjectsByid(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                Project = dt.Rows[0]["ProjectName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "Bindproject", ex.Message, "Not Fixed");
        } 
        return Project;
    }
     
    public string BindBlockname(int ID)
    {
        string Block = string.Empty;
        try
        {
            DataTable dt = KB.ViewAllBlock(Convert.ToString(ID), "", "");
            if (dt != null && dt.Rows.Count > 0)
            {
                Block = dt.Rows[0]["BlockName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "BindBlockname", ex.Message, "Not Fixed");
        } 
        return Block;
    }
    public string ViewFlatNameByFlatID(int ID)
    {
        string Block = string.Empty;
        try
        {
            DataTable dt = KF.ViewAllFlatByFlatID(Convert.ToInt32(ID));
            if (dt != null && dt.Rows.Count > 0)
            {
                Block = dt.Rows[0]["FlatName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "ViewFlatNameByFlatID", ex.Message, "Not Fixed");
        } 
        return Block;
    }
     
    public void Bind()
    {
        try
        {
            DataTable dt = Get();
            if (dt != null && dt.Rows.Count > 0)
            {
                rpruser.Visible = true;
                rpruser.DataSource = dt;
                Session["customer"] = dt.DefaultView;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block"); 
            }
            else
            {
                Session["customer"] = null;
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block !important");
                h5TotalNoCount.Style.Add("display", "none"); 
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "Bind", ex.Message, "Not Fixed");
        } 
    }
     
    public DataTable Get()
    { 
        DataTable dt = new DataTable();
        try
        {
            string projectid = string.Empty;
            string blockID = string.Empty;
            string FlatID = string.Empty;
            string strsearch = string.Empty; 
            string status = string.Empty; 
            if (!string.Equals(ddlprojectname.SelectedValue, ""))
            {
                projectid = ddlprojectname.SelectedValue;
            } 
            if (!string.Equals(ddlflatNumber.SelectedValue, ""))
            {
                FlatID = ddlflatNumber.SelectedValue;
            } 
            if (!string.Equals(ddlblocknumber.SelectedValue, ""))
            {
                blockID = ddlblocknumber.SelectedValue;
            } 
            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                strsearch = txtsearch.Text;
            }
            dt = KC.ViewAllflatBookingCustomerDetails(projectid, blockID, FlatID, strsearch, ""); 
            DataView dv = new DataView();
            dv = dt.DefaultView; 
            string filterExpression = string.Empty; 
            List<string> filterList = new List<string>(); 
            string strclientID = Convert.ToString(CU.GetClientLoginID().Replace("clientid=", "")); 
            if (!string.IsNullOrEmpty(strclientID))
            {
                if (!string.IsNullOrEmpty(filterExpression)) filterExpression += " AND ";
                filterExpression += "Addedby = '" + strclientID.Replace("'", "''") + "'";
            }  
            if (!string.IsNullOrEmpty(filterExpression))
            {
                dv.RowFilter = filterExpression; 
            }
            else
            {
                dv.RowFilter = string.Empty;
            } 
            if (dv.Count > 0)
            {
                dt = dv.ToTable();
            }
            else
            {
                dt = null;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "Get", ex.Message, "Not Fixed");
        } 
        return dt;
    }
     
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-flat-booking.aspx?FlatCustomerID=" + ID, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-flat-booking.aspx", "Edit repeater", ex.Message, "Not Fixed");
            }
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument); 
                int ret = 0; 
                ret = KC.DeleteFlatBookingCustomerDetailsBYFlatcustomerID(ID);
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                      "Swal.fire({ " +
                       "  title: 'Customer has been deleted ', " +
                       "  confirmButtonText: 'OK', " +
                       "  customClass: { " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                       "}).then((result) => { " +
                       "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                       "});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                      "Swal.fire({ " +
                      "  title: 'Your flat booking details not deleted. please try again', " + 
                      "  confirmButtonText: 'OK', " +
                       "  customClass: { " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                      "}).then((result) => { " +
                      "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                      "});", true);
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-flat-booking.aspx", "Delete repeater", ex.Message, "Not Fixed");
            } 
        }
        else if (e.CommandName == "btnexportindivitualrecords")
        {
            Session["IndivitiualrecordsexportbyFlatcustomerID"] = null;
            string ID = Convert.ToString(e.CommandArgument);
            DataTable dt = KC.ViewAllflatBookingCustomerDetails("", "", "", "", ID); 
            if (dt.Rows.Count > 0)
            {
                Session["IndivitiualrecordsexportbyFlatcustomerID"] = dt.DefaultView;
                DownloadToExcelIntivitualRecordsByflatcustomerID();
            }
            else
            {
                Session["IndivitiualrecordsexportbyFlatcustomerID"] = null;
            }
        }
    }
     
    protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        Bind();
    }
     
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojectname.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojectname.SelectedValue)); 
                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlblocknumber.Items.Clear();
                    ddlblocknumber.DataSource = DT;
                    ddlblocknumber.DataTextField = "BlockName";
                    ddlblocknumber.DataValueField = "BlockID";
                    ddlblocknumber.DataBind();
                    ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
                }
                else
                {
                    ddlblocknumber.Items.Clear();
                    ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
                    ddlblocknumber.Items.Insert(0, new ListItem("No Block name", ""));
                }
            }
            else
            {
                ddlblocknumber.Items.Clear();
                ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
     
    protected void ddlblocknumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        Bind();
    }
     
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlblocknumber.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlblocknumber.SelectedValue));

                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlflatNumber.Items.Clear(); 
                    ddlflatNumber.DataSource = DT;
                    ddlflatNumber.DataTextField = "FlatName";
                    ddlflatNumber.DataValueField = "FlatID";
                    ddlflatNumber.DataBind();
                    ddlflatNumber.Items.Insert(0, new ListItem("All", "")); 
                }
                else
                {
                    ddlflatNumber.Items.Clear();
                    ddlflatNumber.Items.Insert(0, new ListItem("All", ""));
                    ddlflatNumber.Items.Insert(0, new ListItem("No flat number", ""));
                }
            }
            else
            {
                ddlflatNumber.Items.Clear();
                ddlflatNumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "ddlblocknumber_SelectedIndexChanged", ex.Message, "Not Fixed");
        }
    }
     
    protected void ddflatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }

    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        Bind();
    }

    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        Clear();
        Bind();
    }
     
    public void DownloadToExcelIntivitualRecordsByflatcustomerID()
    {
        DataView LoanTable = new DataView();
        try
        {
            LoanTable = ((DataView)Session["IndivitiualrecordsexportbyFlatcustomerID"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = LoanTable.ToTable();
                dt1.Columns.Add("Sno");
                dt1.Columns.Add("Project Name");
                dt1.Columns.Add("Customer ID");
                dt1.Columns.Add("Block Number");
                dt1.Columns.Add("Flat no.");
                dt1.Columns.Add("Customer First Name");
                dt1.Columns.Add("Customer Last Name");
                dt1.Columns.Add("CoapplicantFirstName");
                dt1.Columns.Add("CoapplicantLastName");
                dt1.Columns.Add("Gender");
                dt1.Columns.Add("Email ID");
                dt1.Columns.Add("Mobile no.");
                dt1.Columns.Add("Mobilenumber2");
                dt1.Columns.Add("FatherorSpouseName");
                dt1.Columns.Add("DoB");
                dt1.Columns.Add("WhatsappNumber");
                dt1.Columns.Add("Profession");
                dt1.Columns.Add("CompanyName");
                dt1.Columns.Add("Designation");
                dt1.Columns.Add("CurrentAddress");
                dt1.Columns.Add("PermanentAddress");
                dt1.Columns.Add("ResidentialStatus");
                dt1.Columns.Add("CoapplicantRelationship");
                dt1.Columns.Add("CityID");
                dt1.Columns.Add("StateID");
                dt1.Columns.Add("Pincode");
                dt1.Columns.Add("Reference1");
                dt1.Columns.Add("Reference2");
                dt1.Columns.Add("LeadSource");
                dt1.Columns.Add("LoanTakenStatus");
                dt1.Columns.Add("ApplicantPhoto");
                dt1.Columns.Add("ApplicantPAN");
                dt1.Columns.Add("ApplicantAadhar");
                dt1.Columns.Add("CoApplicantPhoto");
                dt1.Columns.Add("CoApplicantPAN");
                dt1.Columns.Add("CoApplicantAadhar");
                dt1.Columns.Add("PoAName");
                dt1.Columns.Add("PoAAddress");
                dt1.Columns.Add("PoAPAN");
                dt1.Columns.Add("PoAAdhar");
                dt1.Columns.Add("PoADOB");
                dt1.Columns.Add("CRMID"); 
                dt1.Columns.Add("BookingDate");
                dt1.Columns.Add("Amountpaid");
                dt1.Columns.Add("PaymentMode");
                dt1.Columns.Add("Bookingknowledgement");
                dt1.Columns.Add("CarparkAllocated");
                dt1.Columns.Add("NumberofSlots");
                dt1.Columns.Add("Allottedcarparkslotnumber");
                dt1.Columns.Add("Registrationcharges");
                dt1.Columns.Add("RegistrationDate");
                dt1.Columns.Add("RegistrationOffice"); 
                dt1.Columns.Add("Added on");
                 
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                { 
                    dr1 = dt1.NewRow();
                    string sno = (i + 1).ToString();
                    dr1["Sno"] = sno;
                    dr1["Project Name"] = Bindproject(Convert.ToInt32(dt.Rows[i]["ProjectID"]));
                    dr1["Customer ID"] = dt.Rows[i]["CustomerID"].ToString();
                    dr1["Block Number"] = BindBlockname(Convert.ToInt32(dt.Rows[i]["BlockID"]));
                    dr1["Flat no."] = ViewFlatNameByFlatID(Convert.ToInt32(dt.Rows[i]["FlatID"]));
                    dr1["Customer First Name"] = dt.Rows[i]["ApplicantFirstName"].ToString();
                    dr1["Customer Last Name"] = dt.Rows[i]["ApplicantLastName"].ToString();
                    dr1["CoapplicantFirstName"] = dt.Rows[i]["CoapplicantFirstName"].ToString();
                    dr1["CoapplicantLastName"] = dt.Rows[i]["CoapplicantLastName"].ToString();
                    dr1["Gender"] = dt.Rows[i]["Gender"].ToString();
                    dr1["Email ID"] = dt.Rows[i]["EmailID"].ToString();
                    dr1["Mobile no."] = dt.Rows[i]["Mobilenumber1"].ToString();
                    dr1["Mobilenumber2"] = dt.Rows[i]["Mobilenumber2"].ToString();
                    dr1["FatherorSpouseName"] = dt.Rows[i]["FatherorSpouseName"].ToString();
                    DateTime dobdate = Convert.ToDateTime(dt.Rows[i]["DoB"]);
                    dr1["DoB"] = dobdate.ToString("dd/MM/yyyy");
                    dr1["WhatsappNumber"] = dt.Rows[i]["WhatsappNumber"].ToString();
                    dr1["Profession"] = dt.Rows[i]["Profession"].ToString();
                    dr1["CompanyName"] = dt.Rows[i]["CompanyName"].ToString();
                    dr1["Designation"] = dt.Rows[i]["Designation"].ToString();
                    dr1["CurrentAddress"] = dt.Rows[i]["Mobilenumber1"].ToString();
                    dr1["PermanentAddress"] = dt.Rows[i]["PermanentAddress"].ToString();
                    dr1["ResidentialStatus"] = dt.Rows[i]["ResidentialStatus"].ToString();
                    dr1["CoapplicantRelationship"] = dt.Rows[i]["CoapplicantRelationship"].ToString();
                    dr1["CityID"] = Bindcity(Convert.ToInt32(dt.Rows[i]["CityID"]));
                    dr1["StateID"] = BindState(Convert.ToInt32(dt.Rows[i]["StateID"]));
                    dr1["Pincode"] = dt.Rows[i]["Pincode"].ToString();
                    dr1["Reference1"] = dt.Rows[i]["Reference1"].ToString();
                    dr1["Reference2"] = dt.Rows[i]["Reference2"].ToString();
                    dr1["LeadSource"] = leadSourcename(Convert.ToInt32(dt.Rows[i]["LeadSource"]));
                    dr1["LoanTakenStatus"] = dt.Rows[i]["LoanTakenStatus"].ToString() == "0" || string.IsNullOrEmpty(dt.Rows[i]["LoanTakenStatus"].ToString()) ? "No" : "Yes";
                    dr1["ApplicantPhoto"] = dt.Rows[i]["ApplicantPhoto"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["ApplicantPhoto"].ToString()) ? "No" : "Yes";
                    dr1["ApplicantPAN"] = dt.Rows[i]["ApplicantPAN"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["ApplicantPAN"].ToString()) ? "No" : "Yes";
                    dr1["ApplicantAadhar"] = dt.Rows[i]["ApplicantAadhar"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["ApplicantAadhar"].ToString()) ? "No" : "yes";
                    dr1["CoApplicantPhoto"] = dt.Rows[i]["CoApplicantPhoto"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["CoApplicantPhoto"].ToString()) ? "No" : "Yes";
                    dr1["CoApplicantPAN"] = dt.Rows[i]["CoApplicantPAN"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["CoApplicantPAN"].ToString()) ? "No" : "Yes";
                    dr1["CoApplicantAadhar"] = dt.Rows[i]["CoApplicantAadhar"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["CoApplicantAadhar"].ToString()) ? "No" : "yes";
                    dr1["PoAName"] = dt.Rows[i]["PoAName"].ToString();
                    dr1["PoAAddress"] = dt.Rows[i]["PoAAddress"].ToString();
                    dr1["PoAPAN"] = dt.Rows[i]["PoAPAN"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["PoAPAN"].ToString()) ? "No" : "Yes";

                    DateTime paodatedtDate = Convert.ToDateTime(dt.Rows[i]["PoADOB"]);
                    dr1["PoADOB"] = paodatedtDate.ToString("dd/MM/yyyy");
                    dr1["PoAAdhar"] = dt.Rows[i]["PoAAdhar"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["PoAAdhar"].ToString()) ? "No" : "Yes";

                    dr1["CRMID"] = GetCRMD(dt.Rows[i]["CRMID"].ToString());
                     
                    DateTime BookingdtDate = Convert.ToDateTime(dt.Rows[i]["BookingDate"]);
                    dr1["BookingDate"] = BookingdtDate.ToString("dd/MM/yyyy");
                    dr1["Amountpaid"] = dt.Rows[i]["Amountpaid"].ToString();

                    dr1["PaymentMode"] = GetPaymentmode(dt.Rows[i]["PaymentMode"].ToString());
                    dr1["Bookingknowledgement"] = dt.Rows[i]["Bookingknowledgement"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["Bookingknowledgement"].ToString()) ? "No" : "Yes";
                     
                    dr1["CarparkAllocated"] = dt.Rows[i]["CarparkAllocated"].ToString();
                    dr1["NumberofSlots"] = dt.Rows[i]["NumberofSlots"].ToString();
                    dr1["Allottedcarparkslotnumber"] = dt.Rows[i]["Allottedcarparkslotnumber"].ToString();
                    dr1["Registrationcharges"] = dt.Rows[i]["Registrationcharges"].ToString();

                    DateTime regdtDate = Convert.ToDateTime(dt.Rows[i]["RegistrationDate"]);
                    dr1["RegistrationDate"] = regdtDate.ToString("dd/MM/yyyy");
                    dr1["RegistrationOffice"] = dt.Rows[i]["RegistrationOffice"].ToString();

                    DateTime dtDate = Convert.ToDateTime(dt.Rows[i]["Addeddate"]);
                    dr1["Added On"] = dtDate.ToString("dd/MM/yyyy");
                    dt1.Rows.Add(dr1);
                }
                ExportExcel(dt1);
            }
        }
        catch (Exception ex)
        {
        }
    }
     
    public string leadSourcename(int ID)
    {
        string strlread = string.Empty;

        DataTable dt = LS.ViewAllLeadsourceByLeadID(ID);
        if (dt != null && dt.Rows.Count > 0)
        {
            strlread = dt.Rows[0]["LeadSourceName"].ToString();
        } 
        return strlread;
    }
     
    public string Bindcity(int ID)
    {
        string city = string.Empty;
        try
        {
            DataTable dt = K2.ViewcityByCityid(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                city = dt.Rows[0]["CityName"].ToString();
            } 
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "Bindcity", ex.Message, "Not Fixed");
        }
        return city;
    }
     
    public string BindState(int ID)
    {
        string city = string.Empty;
        try
        {
            DataTable dt = K2.ViewstateByID(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                city = dt.Rows[0]["StateName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "BindState", ex.Message, "Not Fixed");
        }
        return city;
    }
     

    public string GetPaymentmode(string value)
    {
        string strtext = string.Empty;
        Dictionary<int, string> paymentMethods = new Dictionary<int, string>
    {
        { 1, "Credit Card" },
        { 2, "Debit Card" },
        { 3, "Net Banking" },
        { 4, "UPI" },
        { 5, "Wallets" },
        { 6, "Cash" },
        { 7, "Cheque" },
        { 8, "Demand Draft" },
        { 9, "NEFT" },
        { 10, "RTGS" },
        { 11, "IMPS" }
    }; 
        int paymentMethodValue;
        if (int.TryParse(value, out paymentMethodValue) && paymentMethods.ContainsKey(paymentMethodValue))
        { 
            strtext = paymentMethods[paymentMethodValue];
        }
        return strtext;
    }
     
    public string GetCRMD(string value)
    {
        string strtext = string.Empty;
        Dictionary<int, string> crmd = new Dictionary<int, string>
    {
        { 1, "Name1" },
        { 2, "name2" },
        { 3, "name3" }, 
    };

        int CRMvalue;
        if (int.TryParse(value, out CRMvalue) && crmd.ContainsKey(CRMvalue))
        { 
            strtext = crmd[CRMvalue];
        }
        return strtext;
    }
     
    protected void btnSubmitExport_Click(object sender, EventArgs e)
    {
        DataView LoanTable = new DataView();
        try
        {
            LoanTable = ((DataView)Session["customer"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DownloadToExcel();
            }
            else
            {
                string script = "<script src='https://cdn.jsdelivr.net/npm/sweetalert2@11'></script>" +
                                "<script>" +
                                "Swal.fire({" +
                                "title: 'No records found to export'," +
                                "confirmButtonText: 'OK'" +
                                "  customClass: { " +
                                "      confirmButton: 'handle-btn-success', " +
                                "  }" +
                                "});" +
                                "</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void DownloadToExcel()
    {
        DataView LoanTable = new DataView();
        try
        {
            LoanTable = ((DataView)Session["customer"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = LoanTable.ToTable();
                dt1.Columns.Add("Sno");
                dt1.Columns.Add("Project Name");
                dt1.Columns.Add("Customer ID");
                dt1.Columns.Add("Block Number");
                dt1.Columns.Add("Flat no.");
                dt1.Columns.Add("Customer Name");
                // dt1.Columns.Add("Display Status");
                dt1.Columns.Add("Email ID");
                dt1.Columns.Add("Mobile no.");
                dt1.Columns.Add("Added on");
                 
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr1 = dt1.NewRow();
                    string sno = (i + 1).ToString();
                    dr1["Sno"] = sno;
                    dr1["Project Name"] = Bindproject(Convert.ToInt32(dt.Rows[i]["ProjectID"]));
                    dr1["Customer ID"] = dt.Rows[i]["CustomerID"].ToString();
                    dr1["Block Number"] = BindBlockname(Convert.ToInt32(dt.Rows[i]["BlockID"]));
                    dr1["Flat no."] = ViewFlatNameByFlatID(Convert.ToInt32(dt.Rows[i]["FlatID"]));
                    dr1["Customer Name"] = dt.Rows[i]["ApplicantFirstName"].ToString();
                    dr1["Email ID"] = dt.Rows[i]["EmailID"].ToString();
                    dr1["Mobile no."] = dt.Rows[i]["Mobilenumber1"].ToString();
                    DateTime dtDate = Convert.ToDateTime(dt.Rows[i]["Addeddate"]);
                    dr1["Added On"] = dtDate.ToString("dd/MM/yyyy");
                    dt1.Rows.Add(dr1);
                }
                ExportExcel(dt1);
            }
        }
        catch (Exception ex)
        {
        }
    }
    void ExportExcel(DataTable dt)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=FlatBookingCustomerDetails_Details" + DateTime.Now.ToString("ddMMyyyy_hh:mm:ss") + ".xls");
        Response.ContentType = "application/ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                Response.Write(tab + dr[i].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End(); 
    }
     
    public void Clear()
    {
        txtsearch.Text = "";
        ddlprojectname.SelectedIndex = 0 ;
        Bindblock();
        BindFlat(); 
    }
     
}