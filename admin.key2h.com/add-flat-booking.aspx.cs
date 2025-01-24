
using System;
using System.Data;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;


public partial class adminkey2hcom_AddFlatBooking : System.Web.UI.Page
{
    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProject K2 = new Key2hProject();
    Key2hCustomer C = new Key2hCustomer();
    Key2hProjectblock KB = new Key2hProjectblock();
    Key2hFlat KF = new Key2hFlat();
    Key2hLeadSource KLS = new Key2hLeadSource();
    Key2hAllFilesNew KFN = new Key2hAllFilesNew();
    private static string[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
    private static string[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

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
            BindAllBankName();
            BindLeadReferdBy();
            BindState();
            ddlstate.SelectedValue = "25";
            ddlCoState.SelectedValue = "25";
            BindCity();
            BindCoCity();
            Bindprojects();
            Bindblock();
            BindLeadSource();
            BindViewRMDetails(clientId);

            if (Request.QueryString["FlatCustomerID"] != null)
            {
                int value = 0;
                if (int.TryParse(Request.QueryString["FlatCustomerID"], out value))
                {
                    lblDisplay.Text = "Edit Flat Booking";
                    btnSave.Text = "Update";
                    Bind(Convert.ToInt32(value));
                }
                else
                {
                    string script = string.Format(@" <script>Swal.fire({{ 
                        title: ' URL is incorrect. please try again', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success'  
                        }} 
                    }}).then((result) => {{  
                            window.location.href = 'view-flat-booking.aspx';  
                    }}); </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                lblDisplay.Text = "Add Flat Booking";
                btnSave.Text = "Submit";
            }
        }
    }
    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt.Rows.Count > 0)
            {
                ddlprojectname.DataSource = dt;
                ddlprojectname.DataTextField = "ProjectName";
                ddlprojectname.DataValueField = "ProjectID";
                ddlprojectname.DataBind();
                ddlprojectname.Items.Insert(0, new ListItem("", ""));
                //ddlprojectname.Items.Insert(1, new ListItem("Selected", ""));
                //ddlprojectname.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    public void BindViewRMDetails(string clientId)
    {
        try
        {

            DataTable dt = C.ViewRMDetails(clientId);
            if (dt.Rows.Count > 0)
            {
                ddlcrmname.DataSource = dt;
                ddlcrmname.DataTextField = "Name";
                ddlcrmname.DataValueField = "UserID";
                ddlcrmname.DataBind();
                ddlcrmname.Items.Insert(0, new ListItem("", ""));
                //ddlprojectname.Items.Insert(1, new ListItem("Selected", ""));
                //ddlprojectname.SelectedValue = "18";
            }

        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    public void BindLeadSource()
    {
        try
        {
            DataTable dt = KLS.ViewAllLeadSource();
            if (dt.Rows.Count > 0)
            {
                ddlLeadSource.DataSource = dt;
                ddlLeadSource.DataTextField = "LeadSourceName";
                ddlLeadSource.DataValueField = "LeadID";
                ddlLeadSource.DataBind();
                ddlLeadSource.Items.Insert(0, new ListItem("", ""));
                //ddlLeadSource.Items.Insert(1, new ListItem("Selected", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindLeadSource", ex.Message, "Not Fixed");
        }
    }
    public void BindLeadReferdBy()
    {
        try
        {
            DataTable dt = KFN.ViewFlatBookingReferedby();
            if (dt.Rows.Count > 0)
            {
                ddlReference.DataSource = dt;
                ddlReference.DataTextField = "Referedby";
                ddlReference.DataValueField = "RefID";
                ddlReference.DataBind();
                ddlReference.Items.Insert(0, new ListItem("", ""));
                //ddlLeadSource.Items.Insert(1, new ListItem("Selected", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindLeadReferdBy", ex.Message, "Not Fixed");
        }
    }
    public void Bind(int ID)
    {

        viewpflphoto.Style["top"] = "5px";
        DivAadhar.Style["top"] = "5px";
        DivPan.Style["top"] = "5px";
        //com-applicant
        viewpflphoto2.Style["top"] = "5px";
        divaadhar2.Style["top"] = "5px";
        divcoappliantpan.Style["top"] = "5px";

        //power of attorney

        divpaaadhar.Style["top"] = "5px";
        divpapan.Style["top"] = "5px";

        //booking knowledgment
        div1.Style["top"] = "5px";

        try
        {
            DataTable dt = C.ViewAllFlatCustomerBookingDetailsByFlatCustomerID(ID);

            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["CustomerID"].ToString()) && dt.Rows[0]["CustomerID"] != null)
                {
                    C.intFlatCustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                    hdncustomerID.Value = dt.Rows[0]["CustomerID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["ProjectID"].ToString()) && dt.Rows[0]["ProjectID"] != null)
                {
                    ddlprojectname.SelectedValue = dt.Rows[0]["ProjectID"].ToString();
                    Bindblock();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["BlockID"].ToString()) && dt.Rows[0]["BlockID"] != null)
                {
                    ddlblocknumber.SelectedValue = dt.Rows[0]["BlockID"].ToString();
                    BindFlat();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["FlatID"].ToString()) && dt.Rows[0]["FlatID"] != null)
                {
                    ddlflatNumber.SelectedValue = dt.Rows[0]["FlatID"].ToString();

                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["ApplicantFirstName"].ToString()) && dt.Rows[0]["ApplicantFirstName"] != null)
                {
                    txtapplicationname.Text = dt.Rows[0]["ApplicantFirstName"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["ApplicantLastName"].ToString()) && dt.Rows[0]["ApplicantLastName"] != null)
                {
                    txtapplicationlastname.Text = dt.Rows[0]["ApplicantLastName"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoapplicantFirstName"].ToString()) && dt.Rows[0]["CoapplicantFirstName"] != null)
                {
                    txtCoapplicantFirstName.Text = dt.Rows[0]["CoapplicantFirstName"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoapplicantLastName"].ToString()) && dt.Rows[0]["CoapplicantLastName"] != null)
                {
                    txtCoapplicantLastName.Text = dt.Rows[0]["CoapplicantLastName"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Gender"].ToString()) && dt.Rows[0]["Gender"] != null)
                {
                    ddlgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    //ddlgender.Enabled = false;
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Mobilenumber1"].ToString()) && dt.Rows[0]["Mobilenumber1"] != null)
                {
                    txtmobilenumber1.Text = dt.Rows[0]["Mobilenumber1"].ToString();
                    //txtmobilenumber1.ReadOnly = true;
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["WhatsappNumber"].ToString()) && dt.Rows[0]["WhatsappNumber"] != null)
                {
                    txtwhatsappnumber.Text = dt.Rows[0]["WhatsappNumber"].ToString();
                    //txtwhatsappnumber.ReadOnly = true;
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Mobilenumber1"].ToString()) && dt.Rows[0]["Mobilenumber1"] != null)
                {
                    txtmobilenumber1.Text = dt.Rows[0]["Mobilenumber1"].ToString();
                    //txtmobilenumber1.ReadOnly = true;
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["EmailID"].ToString()) && dt.Rows[0]["EmailID"] != null)
                {
                    txtEmailid.Text = dt.Rows[0]["EmailID"].ToString();
                    //txtEmailid.ReadOnly = true;
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Mobilenumber2"].ToString()) && dt.Rows[0]["Mobilenumber2"] != null)
                {
                    txtmobilenumber2.Text = dt.Rows[0]["Mobilenumber2"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["FatherorSpouseName"].ToString()) && dt.Rows[0]["FatherorSpouseName"] != null)
                {
                    txtFatherORSpouseName.Text = dt.Rows[0]["FatherorSpouseName"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["DoB"].ToString()) && dt.Rows[0]["DoB"] != null)
                {
                    DateTime DB = Convert.ToDateTime(dt.Rows[0]["DoB"]);
                    txtdateofbirth.Text = DB.ToString("dd-MM-yyyy");
                    if (DB != DateTime.MinValue && DB != new DateTime(1753, 1, 1))
                    {
                        txtdateofbirth.Text = DB.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtdateofbirth.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Profession"].ToString()) && dt.Rows[0]["Profession"] != null)
                {
                    txtprofession.Text = dt.Rows[0]["Profession"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CompanyName"].ToString()) && dt.Rows[0]["CompanyName"] != null)
                {
                    txtcompanyname.Text = dt.Rows[0]["CompanyName"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Designation"].ToString()) && dt.Rows[0]["Designation"] != null)
                {
                    txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CurrentAddress"].ToString()) && dt.Rows[0]["CurrentAddress"] != null)
                {
                    txtCurrentResidingAddress.Text = dt.Rows[0]["CurrentAddress"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["PermanentAddress"].ToString()) && dt.Rows[0]["PermanentAddress"] != null)
                {
                    txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["ResidentialStatus"].ToString()) && dt.Rows[0]["ResidentialStatus"] != null)
                {
                    ddlResidentialStatus.SelectedValue = dt.Rows[0]["ResidentialStatus"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoapplicantRelationship"].ToString()) && dt.Rows[0]["CoapplicantRelationship"] != null)
                {
                    ddlRelationshipwithCoApplicant.SelectedValue = dt.Rows[0]["CoapplicantRelationship"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["StateID"].ToString()) && dt.Rows[0]["StateID"] != null)
                {
                    ddlstate.SelectedValue = dt.Rows[0]["StateID"].ToString();
                    BindCity();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaGender"].ToString()) && dt.Rows[0]["CoaGender"] != null)
                {
                    ddlCoGender.SelectedValue = dt.Rows[0]["CoaGender"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaEmailID"].ToString()) && dt.Rows[0]["CoaEmailID"] != null)
                {
                    txtCoaEmailID.Text = dt.Rows[0]["CoaEmailID"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaMobilenumber1"].ToString()) && dt.Rows[0]["CoaMobilenumber1"] != null)
                {
                    txtcoatxtmobilenumber1.Text = dt.Rows[0]["CoaMobilenumber1"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaMobilenumber2"].ToString()) && dt.Rows[0]["CoaMobilenumber2"] != null)
                {
                    txtcoatxtmobilenumber2.Text = dt.Rows[0]["CoaMobilenumber2"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaWhatsappNumber"].ToString()) && dt.Rows[0]["CoaWhatsappNumber"] != null)
                {
                    txtCoaWhatsappNo.Text = dt.Rows[0]["CoaWhatsappNumber"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaAddress"].ToString()) && dt.Rows[0]["CoaAddress"] != null)
                {
                    txtcoaAddress.Text = dt.Rows[0]["CoaAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaResidentialStatus"].ToString()) && dt.Rows[0]["CoaResidentialStatus"] != null)
                {
                    ddlCoaResidentialStatus.SelectedValue = dt.Rows[0]["CoaResidentialStatus"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaStateID"].ToString()) && dt.Rows[0]["CoaStateID"] != null)
                {
                    ddlCoState.SelectedValue = dt.Rows[0]["CoaStateID"].ToString();
                    BindCoCity();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaCityID"].ToString()) && dt.Rows[0]["CoaCityID"] != null)
                {
                    ddlCoaCity.SelectedValue = dt.Rows[0]["CoaCityID"].ToString();

                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoaPinCode"].ToString()) && dt.Rows[0]["CoaPinCode"] != null)
                {
                    txtCoaPincode.Text = dt.Rows[0]["CoaPinCode"].ToString();

                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["CoDOB"].ToString()) && dt.Rows[0]["CoDOB"] != null)
                {
                    DateTime DB = Convert.ToDateTime(dt.Rows[0]["CoDOB"]);
                    txtCoDOB.Text = DB.ToString("dd-MM-yyyy");
                    if (DB != DateTime.MinValue && DB != new DateTime(1753, 1, 1))
                    {
                        txtCoDOB.Text = DB.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtCoaPincode.Text = "";
                    }

                }




                if (!string.IsNullOrEmpty(dt.Rows[0]["CityID"].ToString()) && dt.Rows[0]["CityID"] != null)
                {
                    ddlcity.SelectedValue = dt.Rows[0]["CityID"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Pincode"].ToString()) && dt.Rows[0]["Pincode"] != null)
                {
                    txtpostalcode.Text = dt.Rows[0]["Pincode"].ToString();
                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["Reference2"].ToString()) && dt.Rows[0]["Reference2"] != null)
                {
                    txtreference2.Text = dt.Rows[0]["Reference2"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["LoanTakenStatus"].ToString()) && dt.Rows[0]["LoanTakenStatus"] != null)
                {
                    bool blloanstatus = Convert.ToBoolean(dt.Rows[0]["LoanTakenStatus"]);
                    if (blloanstatus == true)
                    {
                        ddloantaken.SelectedValue = "1";
                        Divbankname.Style.Add("Display", "block");
                    }
                    else
                    {
                        ddloantaken.SelectedValue = "0";
                        Divbankname.Style.Add("Display", "none");
                    }
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["BankName"].ToString()) && dt.Rows[0]["BankName"] != null)
                {
                    ddlbankname.SelectedValue = dt.Rows[0]["BankName"].ToString();
                }


                // Applicant Photo
                if (!string.IsNullOrEmpty(dt.Rows[0]["ApplicantPhoto"].ToString()) && dt.Rows[0]["ApplicantPhoto"] != null)
                {
                    RequiredFieldValidator21.Visible = false;
                    hdnApplicantPhoto.Value = dt.Rows[0]["ApplicantPhoto"].ToString();
                    string applicantPhoto = dt.Rows[0]["ApplicantPhoto"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["ApplicantPhoto"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);
                    string fileUrl = ResolveUrl(fullFilePath);
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("window.bindImageToPreviewphoto('{0}', 0, 'photo1');", formattedImagePath);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindApplicantPhoto", script, true);






                }

                // Co-Applicant Photo
                if (!string.IsNullOrEmpty(dt.Rows[0]["CoApplicantPhoto"].ToString()) && dt.Rows[0]["CoApplicantPhoto"] != null)
                {
                    RequiredFieldValidator24.Visible = false;
                    hdnCoApplicantPhoto.Value = dt.Rows[0]["CoApplicantPhoto"].ToString();
                    string coApplicantPhoto = dt.Rows[0]["CoApplicantPhoto"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["CoApplicantPhoto"];
                    string fullFilePath = Path.Combine(filepath.Trim(), coApplicantPhoto);
                    string fileUrl = ResolveUrl(fullFilePath);
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("window.bindImageToPreviewphoto('{0}', 0, 'photo2');", formattedImagePath);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindCoApplicantPhoto", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["ApplicantPAN"].ToString()) && dt.Rows[0]["ApplicantPAN"] != null)
                {
                    RequiredFieldValidator22.Visible = false;
                    hdnApplicantPAN.Value = dt.Rows[0]["ApplicantPAN"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["ApplicantPAN"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnApplicantPAN.Value); // Corrected to hdnApplicantPAN
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 1);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage1", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["ApplicantAadhar"].ToString()) && dt.Rows[0]["ApplicantAadhar"] != null)
                {

                    RequiredFieldValidator23.Visible = false;
                    hdnApplicantAadhar.Value = dt.Rows[0]["ApplicantAadhar"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["ApplicantAadhar"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnApplicantAadhar.Value); // Corrected to hdnApplicantAadhar
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 0);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage2", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoApplicantPAN"].ToString()) && dt.Rows[0]["CoApplicantPAN"] != null)
                {

                    RequiredFieldValidator26.Visible = false;
                    hdnCoApplicantPAN.Value = dt.Rows[0]["CoApplicantPAN"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["CoApplicantPAN"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnCoApplicantPAN.Value); // Corrected to hdnCoApplicantPAN
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 3);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage3", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["CoApplicantAadhar"].ToString()) && dt.Rows[0]["CoApplicantAadhar"] != null)
                {

                    RequiredFieldValidator25.Visible = false;

                    hdnCoApplicantAadhar.Value = dt.Rows[0]["CoApplicantAadhar"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["CoApplicantAadhar"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnCoApplicantAadhar.Value); // Corrected to hdnCoApplicantAadhar
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 2);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage4", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["PoAPAN"].ToString()) && dt.Rows[0]["PoAPAN"] != null)
                {
                    hdnPAPAN.Value = dt.Rows[0]["PoAPAN"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["PAPAN"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnPAPAN.Value); // Corrected to hdnPAPAN
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 4);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage5", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["PoAAdhar"].ToString()) && dt.Rows[0]["PoAAdhar"] != null)
                {
                    hdnPAAadhar.Value = dt.Rows[0]["PoAAdhar"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["PAAadhar"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnPAAadhar.Value); // Corrected to hdnPAAadhar
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 5);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage6", script, true);
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Bookingknowledgement"].ToString()) && dt.Rows[0]["Bookingknowledgement"] != null)
                {
                    hdnBookingknowledgement.Value = dt.Rows[0]["Bookingknowledgement"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["Bookingknowledgement"];
                    string fullFilePath = Path.Combine(filepath.Trim(), hdnBookingknowledgement.Value); // Corrected to hdnBookingknowledgement
                    string fileUrl = fullFilePath;
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("bindImageToPreview('{0}', 6);", fileUrl); // Use unique script name
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage7", script, true);
                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["PoAName"].ToString()) && dt.Rows[0]["PoAName"] != null)
                {
                    txtNamePowerofattorney.Text = dt.Rows[0]["PoAName"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["PoAAddress"].ToString()) && dt.Rows[0]["PoAAddress"] != null)
                {
                    txtaddresspowerofattorney.Text = dt.Rows[0]["PoAAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["PoADOB"].ToString()) && dt.Rows[0]["PoADOB"] != null)
                {
                    DateTime poaDob = Convert.ToDateTime(dt.Rows[0]["PoADOB"]);
                    txtPAdate.Text = poaDob.ToString("dd-MM-yyyy");
                    if (poaDob != DateTime.MinValue && poaDob != new DateTime(1753, 1, 1))
                    {
                        txtPAdate.Text = poaDob.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtPAdate.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["CRMID"].ToString()) && dt.Rows[0]["CRMID"] != null)
                {
                    ddlcrmname.SelectedValue = dt.Rows[0]["CRMID"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["BookingDate"].ToString()) && dt.Rows[0]["BookingDate"] != null)
                {
                    DateTime dtbd = Convert.ToDateTime(dt.Rows[0]["BookingDate"]);
                    txtBookingdate.Text = dtbd.ToString("dd-MM-yyyy");
                    if (dtbd != DateTime.MinValue && dtbd != new DateTime(1753, 1, 1))
                    {
                        txtBookingdate.Text = dtbd.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtBookingdate.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Amountpaid"].ToString()) && dt.Rows[0]["Amountpaid"] != null)
                {
                    txtamountpaid.Text = dt.Rows[0]["Amountpaid"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["PaymentMode"].ToString()) && dt.Rows[0]["PaymentMode"] != null)
                {
                    ddlpaymentmode.SelectedValue = dt.Rows[0]["PaymentMode"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["PaymentMode"].ToString()) && dt.Rows[0]["PaymentMode"] != null)
                {
                    ddlpaymentmode.SelectedValue = dt.Rows[0]["PaymentMode"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["NumberofSlots"].ToString()) && dt.Rows[0]["NumberofSlots"] != null)
                {
                    txtnoofslots.Text = dt.Rows[0]["NumberofSlots"].ToString();
                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["CarparkAllocated"].ToString()) && dt.Rows[0]["CarparkAllocated"] != null)
                {
                    bool blcar = Convert.ToBoolean(dt.Rows[0]["CarparkAllocated"]);
                    if (blcar == true)
                    {
                        ddlcarparkallotted.SelectedValue = "1";
                    }
                    else
                    {
                        ddlcarparkallotted.SelectedValue = "0";
                    }
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["Allottedcarparkslotnumber"].ToString()) && dt.Rows[0]["Allottedcarparkslotnumber"] != null)
                {
                    string slotNumbers = dt.Rows[0]["Allottedcarparkslotnumber"].ToString();
                    string[] slots = slotNumbers.Split(',')
                                                .Where(s => !string.IsNullOrEmpty(s.Trim()))
                                                .ToArray();
                    if (slots.Length > 0)
                    {
                        txtallottedcarparkslotnumber1.Text = slots[0].Trim();
                    }
                    if (slots.Length > 1)
                    {
                        txtallottedcarparkslotnumber2.Text = slots[1].Trim();
                    }
                    if (slots.Length > 2)
                    {
                        txtallottedcarparkslotnumber3.Text = slots[2].Trim();
                    }

                    string txtnoofslotsValue = txtnoofslots.Text;  // Get the value from txtnoofslots

                    ClientScript.RegisterStartupScript(
                        this.GetType(),
                        "callJsFunction",
                        string.Format("toggleSlotsVisibility(document.getElementById('{0}'))", txtnoofslots.ClientID),
                        true
                    );
                }


                if (!string.IsNullOrEmpty(dt.Rows[0]["Registrationcharges"].ToString()) && dt.Rows[0]["Registrationcharges"] != null)
                {
                    txtregistrationcharges.Text = dt.Rows[0]["Registrationcharges"].ToString();
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["RegistrationDate"].ToString()) && dt.Rows[0]["RegistrationDate"] != null)
                {
                    DateTime dtRD = Convert.ToDateTime(dt.Rows[0]["RegistrationDate"]);
                    txtRegistrationdate.Text = dtRD.ToString("dd-MM-yyyy");

                    if (dtRD != DateTime.MinValue && dtRD != new DateTime(1753, 1, 1))
                    {
                        txtRegistrationdate.Text = dtRD.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtRegistrationdate.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["RegistrationOffice"].ToString()) && dt.Rows[0]["RegistrationOffice"] != null)
                {
                    txtregistrationoffice.Text = dt.Rows[0]["RegistrationOffice"].ToString();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["LeadSource"].ToString()) && dt.Rows[0]["LeadSource"] != null)
                {
                    string Leadsource = dt.Rows[0]["LeadSource"].ToString();
                    ddlLeadSource.SelectedValue = Leadsource;

                    if (Leadsource == "10")
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ReferedBy"].ToString()) && dt.Rows[0]["ReferedBy"] != null)
                        {
                            ddlReference.SelectedValue = dt.Rows[0]["ReferedBy"].ToString();
                            divreferenceby.Style.Add("display", "Block");
                            ClientScript.RegisterStartupScript(this.GetType(), "triggerDdlChange", string.Format(";document.getElementById('{0}').onchange();", ddlReference.ClientID), true);
                            if (!string.IsNullOrEmpty(dt.Rows[0]["Reference1"].ToString()) && dt.Rows[0]["Reference1"] != null)
                            {
                                DivRef1.Style.Add("display", "Block");
                                txtreference1.Text = dt.Rows[0]["Reference1"].ToString();
                            }
                        }
                        else
                        {
                            ddlReference.SelectedIndex = 0;
                        }
                    }
                    else
                    {

                    }
                }
                if (!string.IsNullOrEmpty(txtmobilenumber1.Text) && !string.IsNullOrEmpty(txtwhatsappnumber.Text))
                {
                    if (txtmobilenumber1.Text== txtwhatsappnumber.Text)
                    {
                        chkSameaswhatsapp.Checked = true;
                    }
                    else
                    {
                        chkSameaswhatsapp.Checked = false;
                    }
                    
                }
                if (!string.IsNullOrEmpty(txtcoatxtmobilenumber1.Text) && !string.IsNullOrEmpty(txtCoaWhatsappNo.Text))
                {
                    if (txtcoatxtmobilenumber1.Text== txtCoaWhatsappNo.Text)
                    {
                        chkSameasWhatsapp1.Checked = true;
                    }
                    else
                    {
                        chkSameasWhatsapp1.Checked = false;
                    }
                    
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(txtapplicationname.Text) && string.IsNullOrEmpty(txtCoapplicantFirstName.Text) && string.IsNullOrEmpty(ddlgender.SelectedValue)
           && string.IsNullOrEmpty(txtFatherORSpouseName.Text) && string.IsNullOrEmpty(txtEmailid.Text)
            && string.IsNullOrEmpty(txtmobilenumber1.Text) && string.IsNullOrEmpty(ddlRelationshipwithCoApplicant.SelectedValue) && string.IsNullOrEmpty(txtdateofbirth.Text) && string.IsNullOrEmpty(txtwhatsappnumber.Text) && string.IsNullOrEmpty(txtprofession.Text)
        && string.IsNullOrEmpty(txtPermanentAddress.Text)
            && string.IsNullOrEmpty(ddlResidentialStatus.SelectedValue) && string.IsNullOrEmpty(ddlstate.SelectedValue) && string.IsNullOrEmpty(ddlcity.SelectedValue)
            && string.IsNullOrEmpty(txtpostalcode.Text) && string.IsNullOrEmpty(txtreference1.Text) &&
            string.IsNullOrEmpty(ddlLeadSource.SelectedValue) && !flPhoto.HasFile && !FluploadAadhar.HasFile && !FluploadPan.HasFile
            && !flPhoto2.HasFile && !FluploadAadhar2.HasFile && string.IsNullOrEmpty(ddlprojectname.SelectedValue)
            && string.IsNullOrEmpty(ddlblocknumber.SelectedValue) && string.IsNullOrEmpty(ddlflatNumber.Text))
        {
            labelerror = "Fill the mandatory field.because all are not required field.";
        }
        else if (string.IsNullOrEmpty(txtapplicationname.Text))
        {
            labelerror = "Enter applicant first name";
        }
        else if (string.IsNullOrEmpty(txtCoapplicantFirstName.Text))
        {
            labelerror = "Enter co-applicant first name";
        }
        else if (string.IsNullOrEmpty(ddlgender.SelectedValue))
        {
            labelerror = "Select gender";
        }
        else if (string.IsNullOrEmpty(txtFatherORSpouseName.Text))
        {
            labelerror = "Enter father or spouse name";
        }
        else if (string.IsNullOrEmpty(txtmobilenumber1.Text))
        {
            labelerror = "Enter mobile no.";
        }
        else if (string.IsNullOrEmpty(txtdateofbirth.Text))
        {
            labelerror = "Select date of birth";
        }
        else if (string.IsNullOrEmpty(txtwhatsappnumber.Text))
        {
            labelerror = "Enter whatsapp no.";
        }
        else if (string.IsNullOrEmpty(txtprofession.Text))
        {
            labelerror = "Enter profession";
        }
        else if (string.IsNullOrEmpty(txtPermanentAddress.Text))
        {
            labelerror = "Enter permanent address";
        }
        else if (string.IsNullOrEmpty(ddlResidentialStatus.SelectedValue))
        {
            labelerror = "Select residential status";
        }
        else if (string.IsNullOrEmpty(ddlstate.SelectedValue))
        {
            labelerror = "Select state";
        }
        else if (string.IsNullOrEmpty(ddlcity.SelectedValue))
        {
            labelerror = "Select city";
        }
        else if (string.IsNullOrEmpty(txtpostalcode.Text))
        {
            labelerror = "Enter postal code";
        }
        //else if (string.IsNullOrEmpty(txtreference1.Text))
        //{
        //    labelerror = "Enter reference 1";
        //}
        else if (string.IsNullOrEmpty(ddlRelationshipwithCoApplicant.SelectedValue))
        {
            labelerror = "Select relationship with co-applicant";
        }
        else if (string.IsNullOrEmpty(ddlLeadSource.SelectedValue))
        {
            labelerror = "Select lead source";
        }
        else if (string.IsNullOrEmpty(ddlprojectname.SelectedValue))
        {
            labelerror = "Select project name";
        }
        else if (string.IsNullOrEmpty(ddlblocknumber.SelectedValue))
        {
            labelerror = "Select block name";
        }
        else if (string.IsNullOrEmpty(ddlflatNumber.Text))
        {
            labelerror = "Select flat no.";
        }
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["FlatCustomerID"] == null)
            {
                if (!IsAlreadyexist(Convert.ToInt32(ddlprojectname.SelectedValue), Convert.ToInt32(ddlblocknumber.SelectedValue), Convert.ToInt32(ddlflatNumber.SelectedValue))) //Set the default client ID. But originally,got the ID based on login details.
                {
                    int ret = 0;
                    ret = AddData();
                    if (ret > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                  "Swal.fire({ " +
                    "  title: 'Customer flat booking done sucessfully.', " +
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
                        string script1 = @"
                            <script>
                            Swal.fire({
                            title: 'Flat booking Details couldn\'t be added due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {
                            confirmButton: 'handle-btn-success'
                            }
                            });
                            </script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script1, false);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                           "Swal.fire({ " +
                          "  title: 'The flat booking you’re trying to add already exists', " +
                          "  confirmButtonText: 'OK', " +
                           "  customClass: { " +
                            "      confirmButton: 'handle-btn-success', " +
                            "  }" +
                          "});", true);
                }
            }
            else
            {
                int ret = 0;
                ret = UpdateData();
                if (ret == 2)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                    "    title: 'Flat booking details updated successfully', " +
                    "    icon: 'success', " +
                    "    allowOutsideClick: 'true', " +
                    "    customClass: { " +
                    "        confirmButton: 'handle-btn-success', " +
                    "        icon: 'handle-icon-clr' " +
                    "    } " +
                    "}).then((result) => { " +
                    "        window.location.href = 'view-flat-booking.aspx'; " +
                    "});",
                    true);
                }
                else
                {
                    string script = string.Format(@"<script> 
                    Swal.fire({{
                        title: 'Flat booking details not Updated due to a server or network issue',
                        confirmButtonText: 'OK',
                        customClass: {{
                            confirmButton: 'handle-btn-success'
                        }}
                    }}).then((result) => {{ window.location.href = 'add-flat-booking.aspx?FlatCustomerID={0}'; 
                    }});
                    </script>", Convert.ToString(Request.QueryString["FlatCustomerID"]));
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
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlstate.SelectedValue))
        {
            BindCity();
        }
        else
        {
            ddlcity.Items.Clear();
            ddlcity.Items.Insert(0, new ListItem("", ""));
            ddlcity.Items.Insert(1, new ListItem("Select State", ""));
        }
    }

    protected void ddlCoState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlCoState.SelectedValue))
        {
            BindCoCity();
        }
        else
        {
            ddlCoaCity.Items.Clear();
            ddlCoaCity.Items.Insert(0, new ListItem("", ""));
            ddlCoaCity.Items.Insert(1, new ListItem("Select State", ""));
        }
    }


    public void BindCity()
    {
        if (!string.IsNullOrEmpty(ddlstate.SelectedValue))
        {
            try
            {
                DataTable dt = K2.ViewAllcityByStateid(Convert.ToInt32(ddlstate.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    ddlcity.DataSource = dt;
                    ddlcity.DataTextField = "CityName";
                    ddlcity.DataValueField = "CityID";
                    ddlcity.DataBind();
                    ddlcity.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlcity.Items.Clear();
                    ddlcity.Items.Insert(0, new ListItem("", ""));
                    ddlcity.Items.Insert(1, new ListItem("Select State", ""));
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("add-flat-booking.aspx", "BindCity", ex.Message, "Not Fixed");
            }
        }
        else
        {
            ddlcity.Items.Clear();
            ddlcity.Items.Insert(0, new ListItem("", ""));
            ddlcity.Items.Insert(1, new ListItem("Select State", ""));
        }
    }
    public void BindCoCity()
    {
        if (!string.IsNullOrEmpty(ddlCoState.SelectedValue))
        {
            try
            {
                DataTable dt = K2.ViewAllcityByStateid(Convert.ToInt32(ddlCoState.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    ddlCoaCity.DataSource = dt;
                    ddlCoaCity.DataTextField = "CityName";
                    ddlCoaCity.DataValueField = "CityID";
                    ddlCoaCity.DataBind();
                    ddlCoaCity.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlCoaCity.Items.Clear();
                    ddlCoaCity.Items.Insert(0, new ListItem("", ""));
                    ddlCoaCity.Items.Insert(1, new ListItem("Select State", ""));
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("add-flat-booking.aspx", "BindCity", ex.Message, "Not Fixed");
            }
        }
        else
        {
            ddlCoaCity.Items.Clear();
            ddlCoaCity.Items.Insert(0, new ListItem("", ""));
            ddlCoaCity.Items.Insert(1, new ListItem("Select State", ""));
        }
    }

    public void BindState()
    {

        try
        {
            DataTable dt = K2.ViewAllstate();
            if (dt.Rows.Count > 0)
            {
                ddlstate.DataSource = dt;
                ddlstate.DataTextField = "StateName";
                ddlstate.DataValueField = "StateID";
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("", ""));


                ddlCoState.DataSource = dt;
                ddlCoState.DataTextField = "StateName";
                ddlCoState.DataValueField = "StateID";
                ddlCoState.DataBind();
                ddlCoState.Items.Insert(0, new ListItem("", ""));

            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindState", ex.Message, "Not Fixed");
        }
    }

    public void BindAllBankName()
    {
        try
        {
            DataTable dt = KFN.ViewAllIndiaBankList();
            if (dt.Rows.Count > 0)
            {
                ddlbankname.DataSource = dt;
                ddlbankname.DataTextField = "BankName";
                ddlbankname.DataValueField = "BankID";
                ddlbankname.DataBind();
                ddlbankname.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindAllBankName", ex.Message, "Not Fixed");
        }
    }


    public int AddData()
    {
        int customerID = 0;
        int ret = 0;
        try
        {
            if (!BasicdetailsAlreadyexist(txtmobilenumber1.Text))
            {
                C.strGender = ddlgender.SelectedValue;
                C.strEmailID = txtEmailid.Text;
                C.strMobilenumber1 = txtmobilenumber1.Text;
                C.strWhatsappNumber = txtwhatsappnumber.Text;
                C.strAddedBy = clientId;
                customerID = C.AddCustomerBasicDetails(C);
            }
            else
            {


                DataTable dt = C.ViewBasicCustomerDetailsByMobilenumber(txtmobilenumber1.Text);
                if (dt.Rows.Count > 0)
                {
                    customerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                }
                //selecte basicdetailsby mobilenumber 
            }

            if (customerID != 0)
            {
                DateTime parsedDate;
                string dateFormat = "dd-MM-yyyy";

                C.intCustomerID = customerID;
                C.intProjectID = Convert.ToInt32(ddlprojectname.SelectedValue);
                C.intstrBlockID = Convert.ToInt32(ddlblocknumber.SelectedValue);
                C.intFlatID = Convert.ToInt32(ddlflatNumber.SelectedValue);
                C.strApplicantFirstName = txtapplicationname.Text;
                C.strApplicantLastName = txtapplicationlastname.Text;
                C.strCoapplicantFirstName = txtCoapplicantFirstName.Text;
                C.strCoapplicantLastName = txtCoapplicantLastName.Text;
                C.strGender = ddlgender.SelectedValue;
                C.strEmailID = txtEmailid.Text;
                C.strMobilenumber1 = txtmobilenumber1.Text;
                C.strMobilenumber2 = txtmobilenumber2.Text;
                C.strFatherorSpouseName = txtFatherORSpouseName.Text;
                C.FlatName = ddlflatNumber.SelectedItem.Text;


                if (DateTime.TryParseExact(txtdateofbirth.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmDoB = parsedDate;
                }
                else
                {
                    C.dtmDoB = new DateTime(1753, 1, 1);
                }
                C.strWhatsappNumber = txtwhatsappnumber.Text;
                C.strProfession = txtprofession.Text;
                C.strCompanyName = txtcompanyname.Text;
                C.strDesignation = txtDesignation.Text;
                C.strCurrentAddress = txtCurrentResidingAddress.Text;
                C.strPermanentAddress = txtPermanentAddress.Text;
                C.strResidentialStatus = ddlResidentialStatus.SelectedValue;
                C.strCoapplicantRelationship = ddlRelationshipwithCoApplicant.SelectedValue;
                C.intCityID = Convert.ToInt32(ddlcity.SelectedValue);
                C.intStateID = Convert.ToInt32(ddlstate.SelectedValue);
                C.intPincode = Convert.ToInt32(txtpostalcode.Text);



                C.strCoaGender = ddlCoGender.SelectedValue;



                if (DateTime.TryParseExact(txtCoDOB.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.DtCoDOB = parsedDate;
                }
                else
                {
                    C.DtCoDOB = new DateTime(1753, 1, 1);
                }
                C.strCoaEmailID = txtCoaEmailID.Text;
                C.strCoaMobilenumber1 = txtcoatxtmobilenumber1.Text;
                C.strCoaMobilenumber2 = txtcoatxtmobilenumber2.Text;
                C.strCoaWhatsappNumber = txtCoaWhatsappNo.Text;
                C.strCoaAddress = txtcoaAddress.Text;
                C.strCoaResidentialStatus = ddlCoaResidentialStatus.Text;
                C.IntCoaStateID = Convert.ToInt32(ddlCoState.SelectedValue);
                C.IntCoaCityID = Convert.ToInt32(ddlCoaCity.SelectedValue);
                C.IntCoaPinCode = Convert.ToInt32(txtCoaPincode.Text);





                C.strReference2 = txtreference2.Text;
                C.intLeadSource = Convert.ToInt32(ddlLeadSource.SelectedValue);
                if (ddlLeadSource.SelectedValue == "10")
                {
                    C.ReferedBy = ddlReference.SelectedValue;
                    C.strReference1 = txtreference1.Text;
                }
                else
                {
                    C.ReferedBy = "";
                    C.strReference1 = "";
                }
                C.blLoanTakenStatus = ddloantaken.SelectedValue == "0" ? false : true;
                C.strBankName = ddlbankname.SelectedValue;



                C.strApplicantPhoto = SaveFile(flPhoto, "ApplicantPhoto", ddlprojectname.SelectedItem.Text);
                C.strApplicantAadhar = SaveFile(FluploadAadhar, "ApplicantAadhar", ddlprojectname.SelectedItem.Text);
                C.strApplicantPAN = SaveFile(FluploadPan, "ApplicantPAN", ddlprojectname.SelectedItem.Text);

                C.strCoApplicantPhoto = SaveFile(flPhoto2, "CoApplicantPhoto", ddlprojectname.SelectedItem.Text);
                C.strCoApplicantAadhar = SaveFile(FluploadAadhar2, "CoApplicantAadhar", ddlprojectname.SelectedItem.Text);
                C.strCoApplicantPAN = SaveFile(FluploadPan2, "CoApplicantPAN", ddlprojectname.SelectedItem.Text);

                C.strPoAPAN = SaveFile(fluPAPAN, "PAPAN", ddlprojectname.SelectedItem.Text);
                C.strPoAAdhar = SaveFile(flPAAadhar, "PAAadhar", ddlprojectname.SelectedItem.Text);
                C.strBookingknowledgement = SaveFile(fluBookingAcknowledgement, "Bookingknowledgement", ddlprojectname.SelectedItem.Text);

                if (!string.Equals(ddlcarparkallotted.SelectedValue, "0"))
                {
                    C.blCarparkAllocated = ddlcarparkallotted.SelectedValue == "0" ? false : true;
                    if (!string.IsNullOrEmpty(txtnoofslots.Text))
                    {
                        if (string.Equals(txtnoofslots.Text, "1"))
                        {

                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text;
                        }
                        else if (string.Equals(txtnoofslots.Text, "2"))
                        {

                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text + "," + txtallottedcarparkslotnumber2.Text;
                        }
                        else if (string.Equals(txtnoofslots.Text, "3"))
                        {
                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text + "," + txtallottedcarparkslotnumber2.Text + "," + txtallottedcarparkslotnumber3.Text;
                        }
                        else
                        {

                            C.intNumberofSlots = 0;
                            C.strAllottedcarparkslotnumber = "";
                        }
                    }
                    else
                    {
                        C.intNumberofSlots = 0;
                        C.strAllottedcarparkslotnumber = "0";
                    }
                }
                else
                {


                    C.intNumberofSlots = 0;
                    C.strAllottedcarparkslotnumber = "";

                }

                if (!string.IsNullOrEmpty(txtregistrationcharges.Text.Trim('₹')))
                {

                    C.intRegistrationcharges = Convert.ToInt32(
                        txtregistrationcharges.Text.Contains("₹")
                            ? txtregistrationcharges.Text.Replace("₹", "")
                            : txtregistrationcharges.Text
                    );
                }
                else
                {
                    C.intRegistrationcharges = 0;
                }


                if (DateTime.TryParseExact(txtRegistrationdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmRegistrationDate = parsedDate;
                }
                else
                {
                    C.dtmRegistrationDate = new DateTime(1753, 1, 1);
                }


                if (DateTime.TryParseExact(txtBookingdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmBookingDate = parsedDate;
                }
                else
                {
                    C.dtmBookingDate = new DateTime(1753, 1, 1);
                }
                if (DateTime.TryParseExact(txtPAdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmPoADOB = parsedDate;
                }
                else
                {
                    C.dtmPoADOB = new DateTime(1753, 1, 1);
                }

                C.strPoAName = txtNamePowerofattorney.Text;
                C.strPoAAddress = txtaddresspowerofattorney.Text;
                C.strRegistrationOffice = txtregistrationoffice.Text;

                C.strAddedBy = clientId;

                if (!string.IsNullOrEmpty(txtamountpaid.Text.Trim('₹')))
                {
                    C.Amountpaid = Convert.ToInt32(
                        txtamountpaid.Text.Contains("₹")
                            ? txtamountpaid.Text.Replace("₹", "")
                            : txtamountpaid.Text
                    );
                }
                else
                {
                    C.Amountpaid = 0;
                }
                if (!string.IsNullOrEmpty(ddlcrmname.SelectedValue))
                {
                    C.intCRMID = Convert.ToInt32(ddlcrmname.SelectedValue);
                }
                else
                {
                    C.intCRMID = 0;
                }

                if (!string.IsNullOrEmpty(ddlpaymentmode.SelectedValue))
                {
                    C.PaymentMode = Convert.ToInt32(ddlpaymentmode.SelectedValue);
                }
                else
                {
                    C.PaymentMode = Convert.ToInt32(0);
                }

                ret = C.AddFlatCustomerBookingDetails(C);
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "AddData", ex.Message, "Not Fixed");
        }

        return ret;
    }
    public int UpdateData()
    {
        int ret = 0;
        int customerId = 0;
        try
        {
            if (!string.IsNullOrEmpty(hdncustomerID.Value) && hdncustomerID.Value != "0" && int.TryParse(hdncustomerID.Value, out customerId))
            {
                C.intCustomerID = customerId;
            }
            else
            {
                // Script to show the SweetAlert popup and redirect
                string script = @"
                 <script>
                 Swal.fire({{
                 title: 'The Customer ID is either null or zero. Please try again',  
                 confirmButtonText: 'OK',
                    customClass: {{
                                    confirmButton: 'handle-btn-success'
                                }}
                 }}).then((result) => {{
                 window.location.href = 'view-flat-booking.aspx'; 
                }});
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
            }


            C.strGender = ddlgender.SelectedValue;
            C.strEmailID = txtEmailid.Text;
            C.strMobilenumber1 = txtmobilenumber1.Text;
            C.strWhatsappNumber = txtwhatsappnumber.Text;
            C.strUpdated = clientId;

            ret = C.UpdateCustomerBasicDetails(C);


            if (ret == 1)
            {

                DateTime parsedDate;
                string dateFormat = "dd-MM-yyyy";

                C.intFlatCustomerID = Convert.ToInt32(Request.QueryString["FlatCustomerID"]);
                C.intCustomerID = Convert.ToInt32(hdncustomerID.Value);//\hdn;
                C.intProjectID = Convert.ToInt32(ddlprojectname.SelectedValue);
                C.intstrBlockID = Convert.ToInt32(ddlblocknumber.SelectedValue);
                C.intFlatID = Convert.ToInt32(ddlflatNumber.SelectedValue);
                C.strApplicantFirstName = txtapplicationname.Text;
                C.strApplicantLastName = txtapplicationlastname.Text;
                C.strCoapplicantFirstName = txtCoapplicantFirstName.Text;
                C.strCoapplicantLastName = txtCoapplicantLastName.Text;
                C.strGender = ddlgender.SelectedValue;
                C.strEmailID = txtEmailid.Text;
                C.strMobilenumber1 = txtmobilenumber1.Text;
                C.strMobilenumber2 = txtmobilenumber2.Text;
                C.strFatherorSpouseName = txtFatherORSpouseName.Text;


                if (DateTime.TryParseExact(txtdateofbirth.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmDoB = parsedDate;
                }
                else
                {
                    C.dtmDoB = new DateTime(1753, 1, 1);
                }

                C.strWhatsappNumber = txtwhatsappnumber.Text;
                C.strProfession = txtprofession.Text;
                C.strCompanyName = txtcompanyname.Text;
                C.strDesignation = txtDesignation.Text;
                C.strCurrentAddress = txtCurrentResidingAddress.Text;
                C.strPermanentAddress = txtPermanentAddress.Text;
                C.strResidentialStatus = ddlResidentialStatus.SelectedValue;
                C.strCoapplicantRelationship = ddlRelationshipwithCoApplicant.SelectedValue;
                C.intCityID = Convert.ToInt32(ddlcity.SelectedValue);
                C.intStateID = Convert.ToInt32(ddlstate.SelectedValue);
                C.intPincode = Convert.ToInt32(txtpostalcode.Text);
                C.strReference1 = txtreference1.Text;
                C.strReference2 = txtreference2.Text;
                C.intLeadSource = Convert.ToInt32(ddlLeadSource.SelectedValue);
                if (ddlLeadSource.SelectedValue == "10")
                {
                    C.ReferedBy = ddlReference.SelectedValue;
                    C.strReference1 = txtreference1.Text;
                }
                else
                {
                    C.ReferedBy = "";
                    C.strReference1 = "";
                }
                C.blLoanTakenStatus = ddloantaken.SelectedValue == "0" ? false : true;
                C.strBankName = ddlbankname.SelectedValue;


                C.strCoaGender = ddlCoGender.SelectedValue;



                if (DateTime.TryParseExact(txtCoDOB.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.DtCoDOB = parsedDate;
                }
                else
                {
                    C.DtCoDOB = new DateTime(1753, 1, 1);
                }
                C.strCoaEmailID = txtCoaEmailID.Text;
                C.strCoaMobilenumber1 = txtcoatxtmobilenumber1.Text;
                C.strCoaMobilenumber2 = txtcoatxtmobilenumber2.Text;
                C.strCoaWhatsappNumber = txtCoaWhatsappNo.Text;
                C.strCoaAddress = txtcoaAddress.Text;
                C.strCoaResidentialStatus = ddlCoaResidentialStatus.Text;
                C.IntCoaStateID = Convert.ToInt32(ddlCoState.SelectedValue);
                C.IntCoaCityID = Convert.ToInt32(ddlCoaCity.SelectedValue);
                C.IntCoaPinCode = Convert.ToInt32(txtCoaPincode.Text);





                if (flPhoto.HasFile)
                {
                    C.strApplicantPhoto = SaveFile(flPhoto, "ApplicantPhoto", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strApplicantPhoto = hdnApplicantPhoto.Value;
                }


                if (FluploadAadhar.HasFile)
                {
                    C.strApplicantAadhar = SaveFile(FluploadAadhar, "ApplicantAadhar", ddlprojectname.SelectedItem.Text);

                }
                else
                {
                    C.strApplicantAadhar = hdnApplicantAadhar.Value;
                }


                if (FluploadPan.HasFile)
                {
                    C.strApplicantPAN = SaveFile(FluploadPan, "ApplicantPAN", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strApplicantPAN = hdnApplicantPAN.Value;
                }



                if (flPhoto2.HasFile)
                {
                    C.strCoApplicantPhoto = SaveFile(flPhoto2, "CoApplicantPhoto", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strCoApplicantPhoto = hdnCoApplicantPhoto.Value;
                }


                if (FluploadAadhar2.HasFile)
                {
                    C.strCoApplicantAadhar = SaveFile(FluploadAadhar2, "CoApplicantAadhar", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strCoApplicantAadhar = hdnCoApplicantAadhar.Value;
                }


                if (FluploadPan2.HasFile)
                {
                    C.strCoApplicantPAN = SaveFile(FluploadPan2, "CoApplicantPAN", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strCoApplicantPAN = hdnCoApplicantPAN.Value;
                }


                if (fluPAPAN.HasFile)
                {
                    C.strPoAPAN = SaveFile(fluPAPAN, "PAPAN", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strPoAPAN = hdnPAPAN.Value;
                }

                if (flPAAadhar.HasFile)
                {
                    C.strPoAAdhar = SaveFile(flPAAadhar, "PAAadhar", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strPoAAdhar = hdnPAAadhar.Value;
                }


                if (fluBookingAcknowledgement.HasFile)
                {
                    C.strBookingknowledgement = SaveFile(fluBookingAcknowledgement, "Bookingknowledgement", ddlprojectname.SelectedItem.Text);
                }
                else
                {
                    C.strBookingknowledgement = hdnBookingknowledgement.Value;
                }


                if (!string.Equals(ddlcarparkallotted.SelectedValue, "0"))
                {
                    C.blCarparkAllocated = ddlcarparkallotted.SelectedValue == "0" ? false : true;
                    if (!string.IsNullOrEmpty(txtnoofslots.Text))
                    {
                        if (string.Equals(txtnoofslots.Text, "1"))
                        {

                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text;
                        }
                        else if (string.Equals(txtnoofslots.Text, "2"))
                        {

                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text + "," + txtallottedcarparkslotnumber2.Text;
                        }
                        else if (string.Equals(txtnoofslots.Text, "3"))
                        {
                            C.intNumberofSlots = Convert.ToInt32(txtnoofslots.Text);
                            C.strAllottedcarparkslotnumber = txtallottedcarparkslotnumber1.Text + "," + txtallottedcarparkslotnumber2.Text + "," + txtallottedcarparkslotnumber3.Text;
                        }
                        else
                        {

                            C.intNumberofSlots = 0;
                            C.strAllottedcarparkslotnumber = "";
                        }
                    }
                    else
                    {
                        C.intNumberofSlots = 0;
                        C.strAllottedcarparkslotnumber = "0";
                    }
                }
                else
                {

                    C.intNumberofSlots = 0;
                    C.strAllottedcarparkslotnumber = "";

                }

                if (string.IsNullOrEmpty(txtregistrationcharges.Text))
                {
                    C.intRegistrationcharges = Convert.ToInt32(txtregistrationcharges.Text.Contains("₹") ? txtregistrationcharges.Text.Replace("₹", "") : txtregistrationcharges.Text);
                }
                else
                {
                    C.intRegistrationcharges = 0;
                }


                if (DateTime.TryParseExact(txtRegistrationdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmRegistrationDate = parsedDate;
                }
                else
                {
                    C.dtmRegistrationDate = new DateTime(1753, 1, 1);
                }

                if (DateTime.TryParseExact(txtBookingdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmBookingDate = parsedDate;
                }
                else
                {
                    C.dtmBookingDate = new DateTime(1753, 1, 1);
                }
                if (DateTime.TryParseExact(txtPAdate.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    C.dtmPoADOB = parsedDate;
                }
                else
                {
                    C.dtmPoADOB = new DateTime(1753, 1, 1);
                }
                C.strPoAName = txtNamePowerofattorney.Text;
                C.strPoAAddress = txtaddresspowerofattorney.Text;
                C.strRegistrationOffice = txtregistrationoffice.Text;

                C.strUpdated = Convert.ToString(CU.GetClientLoginID().Replace("clientid=", ""));

                if (!string.IsNullOrEmpty(ddlcrmname.SelectedValue))
                {
                    C.intCRMID = Convert.ToInt32(ddlcrmname.SelectedValue);
                }
                else
                {
                    C.intCRMID = 0;
                }
                if (!string.IsNullOrEmpty(txtamountpaid.Text))
                {
                    C.Amountpaid = Convert.ToInt32(txtamountpaid.Text.Contains("₹") ? txtamountpaid.Text.Replace("₹", "") : txtamountpaid.Text);
                }
                else
                {
                    C.Amountpaid = 0;
                }

                if (!string.IsNullOrEmpty(ddlpaymentmode.SelectedValue))
                {
                    C.PaymentMode = Convert.ToInt32(ddlpaymentmode.SelectedValue);
                }
                else
                {
                    C.PaymentMode = Convert.ToInt32(0);
                }

                ret += C.UpdateFlatCustomerBookingDetails(C);
            }
            else
            {

                // Placeholder customerId for the script int placeholderCustomerId = 123; // Use an actual placeholder value if needed // Script to show the SweetAlert popup and redirect

                string script = string.Format(@" <script> Swal.fire({{ title: 'Flat booking details are not updated. please try again',  confirmButtonText: 'OK',
                    customClass: {{ confirmButton: 'handle-btn-success' }}
                    }}).then((result) => {{ window.location.href = 'add-flat-booking.aspx?FlatCustomerID={0}'; }}); </script>", Convert.ToString(Request.QueryString["FlatCustomerID"]));
                ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
            }

        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "UpdateData", ex.Message, "Not Fixed");
        }

        return ret;
    }
    public bool IsAlreadyexist(int Project, int BlockID, int FlatID)
    {
        bool isavail = false;
        try
        {
            DataTable dt = C.AlreadyExistProjectdetails(Project, BlockID, FlatID);
            if (dt.Rows.Count > 0 && isavail != true)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "IsAlreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    public bool BasicdetailsAlreadyexist(string number)
    {

        bool isavail = false;
        try
        {
            DataTable dt = C.ViewBasicCustomerDetailsByMobilenumber(number);
            if (dt.Rows.Count > 0 && isavail != true)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BasicdetailsAlreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    [System.Web.Services.WebMethod]
    public static object CheckProjectExistence(int project, int BlockID, int FlatID)
    {
        ClientDashboardError CI = new ClientDashboardError();
        Key2hCustomer C = new Key2hCustomer();
        Key2hFlat KF = new Key2hFlat();

        bool exists = false;
        string Slotcount = "0";
        string slotName = string.Empty;
        string slotName2 = string.Empty;
        string slotName3 = string.Empty;

        try
        {
            DataTable dt = C.AlreadyExistProjectdetails(Convert.ToInt32(project), Convert.ToInt32(BlockID), Convert.ToInt32(FlatID));
            if (dt != null && dt.Rows.Count > 0)
            {
                exists = true;
            }

            if (!exists)
            {
                DataTable dT = KF.ViewAllFlatByFlatID(Convert.ToInt32(FlatID));
                if (dT != null && dT.Rows.Count > 0)
                {
                    object carParkingCount = dT.Rows[0]["CarparkingCount"];
                    Slotcount = carParkingCount != DBNull.Value ? carParkingCount.ToString() : "0";
                    slotName = (!string.IsNullOrEmpty(dT.Rows[0]["Carparkslot1"].ToString()) ? dT.Rows[0]["Carparkslot1"].ToString() : "");
                    slotName2 = (!string.IsNullOrEmpty(dT.Rows[0]["Carparkslot2"].ToString()) ? dT.Rows[0]["Carparkslot2"].ToString() : "");
                    slotName3 = (!string.IsNullOrEmpty(dT.Rows[0]["Carparkslot3"].ToString()) ? dT.Rows[0]["Carparkslot3"].ToString() : "");
                }
                else
                {
                    Slotcount = "0";
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "CheckProjectExistence", ex.Message, "Not Fixed");
        }

        return new { exists, Slotcount, slotName, slotName2, slotName3 };
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
            CI.StoreExceptionMessage("add-flat-booking.aspx", "SaveFile", ex.Message, "Not Fixed");
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
    public static string AmttowordConversion(string stAmt)
    {
        if (!string.IsNullOrEmpty(stAmt))
        {
            double loanamt = Convert.ToDouble(stAmt);
            string number = ConvertAmount(loanamt);
            return number;
        }
        else
        {
            return "";
        }
    }
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["FlatCustomerID"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //      "Swal.fire('Cancelled!', 'Your action has been canceled.', 'success');",
            //      true); 
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({ " +
            "   title: 'Flat booking has been cancelled as requested', " +
            "   confirmButtonText: 'OK', " +
            "   customClass: { " +
            "       confirmButton: 'handle-btn-success' " +
            "   } " +
            "}).then((result) => { " +
            "       window.location.href = 'view-flat-booking.aspx'; " +
            "});", true);

        }
    }
    protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojectname.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojectname.SelectedValue));

                if (DT.Rows.Count > 0)
                {
                    ddlblocknumber.DataSource = DT;
                    ddlblocknumber.DataTextField = "BlockName";
                    ddlblocknumber.DataValueField = "BlockID";
                    ddlblocknumber.DataBind();
                    ddlblocknumber.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlblocknumber.Items.Clear();
                    ddlblocknumber.Items.Insert(0, new ListItem("No block name", ""));
                }
            }
            else
            {
                ddlblocknumber.Items.Clear();
                ddlblocknumber.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlblocknumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
    }
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlblocknumber.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlblocknumber.SelectedValue));

                if (DT.Rows.Count > 0)
                {
                    ddlflatNumber.DataSource = DT;
                    ddlflatNumber.DataTextField = "FlatName";
                    ddlflatNumber.DataValueField = "FlatID";
                    ddlflatNumber.DataBind();
                    ddlflatNumber.Items.Insert(0, new ListItem("", ""));

                }
                else
                {
                    ddlflatNumber.Items.Clear();
                    ddlflatNumber.Items.Insert(0, new ListItem("", ""));
                    ddlflatNumber.Items.Insert(1, new ListItem("No Flat number", ""));
                }
            }
            else
            {
                ddlflatNumber.Items.Clear();
                ddlflatNumber.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }


}