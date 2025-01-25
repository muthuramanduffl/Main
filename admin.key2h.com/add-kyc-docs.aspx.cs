using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Activities.Expressions;

public partial class adminkey2hcom_AddKYCDocs : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hProjectblock KB = new Key2hProjectblock();
    Key2hFlat KF = new Key2hFlat();
    ClientDashboardError CE = new ClientDashboardError();
    Key2hCustomer KC = new Key2hCustomer();
    ClientUsers cu = new ClientUsers();
    Key2hkycdocs KYC = new Key2hkycdocs();
    private static string cId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string clientLoginId = cu.GetClientLoginID();
            if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
            {
                cId = clientLoginId.Replace("clientid=", "");
            }
            else
            {
                Response.Redirect("index.aspx");
            }


            if (!IsPostBack)
            {

                Bindprojects();
                Bindblock();
            }

            if (Request.QueryString["DocID"] != null)
            {
                lblDisplaytext.Text = "Edit KYC docs";
                int value = 0;
                if (int.TryParse(Request.QueryString["DocID"], out value))
                {
                    //edit
                    if (!IsPostBack)
                    {
                        Bind(Convert.ToString(value));
                    }
                    hdnID.Value = Convert.ToString(value);
                }
                else
                {
                    string script = string.Format(@" 
                    <script> 
                    Swal.fire({{ 
                        title: ' URL is incorrect. please try again', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success'  
                        }} 
                    }}).then((result) => {{  
                            window.location.href = 'view-kyc-docs.aspx';   
                    }}); 
                    </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                lblDisplaytext.Text = "Add KYC docs";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "PageLoad", ex.Message, "Not Fixed");
        }
    }
    public void Bind(string id)
    {
        try
        {
            DataTable dt = KYC.ViewAllFlatCustomerKYCDocs("", "", "", id, cId);
            //RequiredFieldValidator14.Visible = false;
            // viewproscreenbtn.Style["top"] = "5px";
            //viewmapbtn.Style["top"] = "5px";
            if (dt.Rows.Count > 0)
            {


                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectID"])))
                {
                    string strddpro = Convert.ToString(dt.Rows[0]["ProjectID"]);
                    ddlProName.SelectedValue = strddpro;
                    Bindblock();
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BlockID"])))
                {
                    ddlBlockNumber.SelectedValue = Convert.ToString(dt.Rows[0]["BlockID"]);
                    BindFlat();
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FlatID"])))
                {
                    ddlFlatNumber.SelectedValue = Convert.ToString(dt.Rows[0]["FlatID"]);
                    FlatFunction();
                }


                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SaleDeedDraft"])))
                {
                    hdnFileUploadSaleDeedDraft.Value = Convert.ToString(dt.Rows[0]["SaleDeedDraft"]);
                    string applicantPhoto = dt.Rows[0]["SaleDeedDraft"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath 
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 0, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage0", script, true);
                
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SaleDeedFinal"])))
                {
                  




                    hdnFileUploadSaleDeedFinal.Value = Convert.ToString(dt.Rows[0]["SaleDeedFinal"]);
                    string applicantPhoto = dt.Rows[0]["SaleDeedFinal"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 1, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage1", script, true);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SaleAgreementDraft"])))
                {
                 
                    hdnFileUploadSaleAgreementDraft.Value = Convert.ToString(dt.Rows[0]["SaleAgreementDraft"]);
                    string applicantPhoto = dt.Rows[0]["SaleAgreementDraft"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 2, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage2", script, true);






                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SaleAgreementFinal"])))
                {
                    hdnFileUploadSaleAgreementFinal.Value = Convert.ToString(dt.Rows[0]["SaleAgreementFinal"]);
                    string applicantPhoto = dt.Rows[0]["SaleAgreementFinal"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 3, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage3", script, true);





                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["AllotmentLetter"])))
                {
                    hdnFileUploadAllotmentLetter.Value = Convert.ToString(dt.Rows[0]["AllotmentLetter"]);
                    string applicantPhoto = dt.Rows[0]["AllotmentLetter"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 4, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage4", script, true);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["WelcomeLetter"])))
                {
                    hdnFileUploadWelcomeLetter.Value = Convert.ToString(dt.Rows[0]["WelcomeLetter"]);
                    string applicantPhoto = dt.Rows[0]["WelcomeLetter"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 5, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage5", script, true);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DemandLetter"])))
                {
                    hdnFileUploadDemandLetter.Value = Convert.ToString(dt.Rows[0]["DemandLetter"]);
                    string applicantPhoto = dt.Rows[0]["DemandLetter"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 6, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage6", script, true);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PaymentReceipt"])))
                {         
                    hdnFileUploadPaymentReceipt.Value = Convert.ToString(dt.Rows[0]["PaymentReceipt"]);
                    string applicantPhoto = dt.Rows[0]["PaymentReceipt"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 7, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage7", script, true);


                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Bill"])))
                {
                    hdnFileUploadBill.Value = Convert.ToString(dt.Rows[0]["Bill"]);
                    string applicantPhoto = dt.Rows[0]["Bill"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 8, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage8", script, true);





                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PaymentSchedule"])))
                {
                    hdnFileUploadPaymentSchedule.Value = Convert.ToString(dt.Rows[0]["PaymentSchedule"]);
                    string applicantPhoto = dt.Rows[0]["PaymentSchedule"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 9, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage9", script, true);

                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EBCard"])))
                {
                    hdnFileUploadEBCard.Value = Convert.ToString(dt.Rows[0]["EBCard"]);
                    string applicantPhoto = dt.Rows[0]["EBCard"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 10, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage10", script, true);


                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["NOCforHandover"])))
                {
                    hdnFileUploadNOC.Value = Convert.ToString(dt.Rows[0]["NOCforHandover"]);
                    string applicantPhoto = dt.Rows[0]["NOCforHandover"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 11, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage11", script, true);

                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CCUpdation"])))
                {

                    hdnFileUploadCCUpdation.Value = Convert.ToString(dt.Rows[0]["CCUpdation"]);
                    string applicantPhoto = dt.Rows[0]["CCUpdation"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 12, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage12", script, true);

                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["HandingOverDocs"])))
                {
                    hdnFileUploadHandingOverDocuments.Value = Convert.ToString(dt.Rows[0]["HandingOverDocs"]);
                    string applicantPhoto = dt.Rows[0]["HandingOverDocs"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 14, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage14", script, true);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BankDocuments"])))
                {
                    hdnFileUploadBankDocuments.Value = Convert.ToString(dt.Rows[0]["BankDocuments"]);
                    string applicantPhoto = dt.Rows[0]["BankDocuments"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 13, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage13", script, true);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["OtherDocuments"])))
                {
                    hdnFileUploadOtherDocuments.Value = Convert.ToString(dt.Rows[0]["OtherDocuments"]);
                    string applicantPhoto = dt.Rows[0]["OtherDocuments"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["KYCDocs"];
                    string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);

                    // Determine the file extension to decide how to handle the file
                    string fileExtension = Path.GetExtension(fullFilePath).ToLower();
                    string fileType = fileExtension == ".pdf" ? "application/pdf" : "image/jpeg"; // Assuming it's an image for other extensions
                    string fileBase64 = string.Empty;

                    if (fileType == "application/pdf")
                    {
                        fileBase64 = fullFilePath;
                    }
                    else
                    {
                        byte[] fileBytes = File.ReadAllBytes(fullFilePath);
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    string formattedImagePath = fileType == "application/pdf"
                        ? fullFilePath
                        : string.Format("data:{0};base64,{1}", fileType, fileBase64);

                    string script = string.Format("bindImageToPreview('{0}', 15, '{1}');", formattedImagePath, fileType);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindImage15", script, true);
                }
            }
            else
            {
                string script = string.Format(@"
                <script>
                Swal.fire({{ 
                    title: 'No KYC details are available for the specified  ID', 
                    confirmButtonText: 'OK', 
                    customClass: {{ 
                        confirmButton: 'handle-btn-success' 
                    }} 
                }}).then((result) => {{  
                        window.location.href = 'add-kyc-docs.aspx';  
                }});
                </script>");
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "Bind", ex.Message, "Not Fixed");
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
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "Bindblock", ex.Message, "Not Fixed");
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
                }
            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("", ""));
                txtCustomerName.Text = "";
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }
    protected void ddlFlatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlFlatNumber.SelectedValue))
        {
            FlatFunction();
        }
        else
        {
            txtCustomerName.Text = "";
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
            }
            else
            {
                txtCustomerName.Text = "N/A";
                lblcustomernameerror.Text = "Selected flat has no customer records";  //due out
            }
            // if (string.IsNullOrEmpty(lblcustomernameerror.Text))
            // {
            //     BindCostLabel();
            //     BindCostDetails(Convert.ToInt32(ddlFlatNumber.SelectedValue));

            // }
            // else
            // {
            //     divrptCustomers.Style.Add("Display", "none");
            // } 
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-cost-details.aspx", "FlatFunction", ex.Message, "Not Fixed");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
            string.IsNullOrEmpty(ddlFlatNumber.SelectedValue) && string.IsNullOrEmpty(txtCustomerName.Text))
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
        //else if (string.IsNullOrEmpty(txtCustomerName.Text))
        //{
        //    labelerror = "Enter customer name";
        //}
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["DocID"] == null)
            {
                if (!KYC.CheckRecordExistsFlatCustomerKYCDocsByFlatIDandAddedBy(ddlFlatNumber.SelectedValue, cId))
                {
                    int ret = 0;
                    if (!FileUploadSaleDeedDraft.HasFile &&
    !FileUploadSaleDeedFinal.HasFile &&
    !FileUploadSaleAgreementDraft.HasFile &&
    !FileUploadSaleAgreementFinal.HasFile &&
    !FileUploadAllotmentLetter.HasFile &&
    !FileUploadWelcomeLetter.HasFile &&
    !FileUploadDemandLetter.HasFile &&
    !FileUploadPaymentReceipt.HasFile &&
    !FileUploadBill.HasFile &&
                     !FileUploadPaymentSchedule.HasFile &&
                    !FileUploadEBCard.HasFile &&
                   !FileUploadHandingOverDocuments.HasFile &&
                    !FileUploadCCUpdation.HasFile &&
                    !FileUploadNOC.HasFile &&
                    !FileUploadOtherDocuments.HasFile &&
                    !FileUploadBankDocuments.HasFile)
                    {
                        labelerror = "At least one file must be uploaded.";
                    }
                    if (string.IsNullOrEmpty(labelerror))
                    {
                        ret = AddData();
                        if (ret == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                         "Swal.fire({ " +
                            "  title: 'KYC docs details added successfully', " +
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
                            string script = string.Format(@" <script>
                            Swal.fire({{ 
                                title: 'KYC docs details couldn't be added due to a server or network issue. Please try again in some time!', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{   
                                    window.location.href = 'add-kyc-docs.aspx';  
                            }});
                            </script>");
                            ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", string.Format("Swal.fire('Validation Alert', '{0}', 'success');", labelerror.Replace("'", "\\'")), true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " +
                          "  title: 'The KYC docs details you’re trying to add already exists', " +
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
                ret = UpdateData();
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                        "    title: 'KYC docs details updated successfully', " +
                        "    icon: 'success', " +
                        "    allowOutsideClick: 'true', " +
                        "    customClass: { " +
                        "        confirmButton: 'handle-btn-success', " +
                        "        icon: 'handle-icon-clr' " +
                        "    } " +
                        "}).then((result) => { " +
                        "    window.location.href = 'view-kyc-docs.aspx'; " +
                        "});", true);
                }
                else
                {
                    string script = string.Format(@"  <script>
                        Swal.fire({
                            title: 'KYC docs details couldn't be updated due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {
                                confirmButton: 'handle-btn-success'
                            }
                        }).then((result) => { 
                                window.location.href = 'add-kyc-docs.aspx?FlatID={0}'; 
                        });
                    </script>", Convert.ToString(Request.QueryString["DocID"]));
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
        }
        else
        {
            //alert labelerror
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", string.Format("Swal.fire('Validation Alert', '{0}', 'success');", labelerror.Replace("'", "\\'")), true);

        }
    }
    public int AddData()
    {
        int ret = 0;
        try
        {
            KYC.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KYC.intProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KYC.strSaleDeedDraft = SaveFile(FileUploadSaleDeedDraft, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strSaleDeedFinal = SaveFile(FileUploadSaleDeedFinal, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strSaleAgreementDraft = SaveFile(FileUploadSaleAgreementDraft, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strSaleAgreementFinal = SaveFile(FileUploadSaleAgreementFinal, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strAllotmentLetter = SaveFile(FileUploadAllotmentLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strWelcomeLetter = SaveFile(FileUploadWelcomeLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strDemandLetter = SaveFile(FileUploadDemandLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strPaymentReceipt = SaveFile(FileUploadPaymentReceipt, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strBill = SaveFile(FileUploadBill, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strPaymentSchedule = SaveFile(FileUploadPaymentSchedule, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strEBCard = SaveFile(FileUploadEBCard, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strHandingOverDocs = SaveFile(FileUploadHandingOverDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strCCUpdation = SaveFile(FileUploadCCUpdation, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strNOCforHandover = SaveFile(FileUploadNOC, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strOtherDocuments = SaveFile(FileUploadOtherDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strBankDocuments = SaveFile(FileUploadBankDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            KYC.strAddedBy = cId;
            ret = KYC.AddDataFlatCustomerKYCDocs(KYC);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "AddData", ex.Message, "Not Fixed");
        }
        return ret;
    }
    public int UpdateData()
    {
        int ret = 0;
        try
        {
            KYC.intDocID = Convert.ToInt32(hdnID.Value);
            KYC.intFlatID = Convert.ToInt32(ddlFlatNumber.SelectedValue);
            KYC.intProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            if (FileUploadSaleDeedDraft.HasFile)
            {
                KYC.strSaleDeedDraft = SaveFile(FileUploadSaleDeedDraft, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strSaleDeedDraft = hdnFileUploadSaleDeedDraft.Value;
            }


            if (FileUploadSaleDeedFinal.HasFile)
            {
                KYC.strSaleDeedFinal = SaveFile(FileUploadSaleDeedFinal, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strSaleDeedFinal = hdnFileUploadSaleDeedFinal.Value;
            }



            if (FileUploadSaleAgreementDraft.HasFile)
            {
                KYC.strSaleAgreementDraft = SaveFile(FileUploadSaleAgreementDraft, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strSaleAgreementDraft = hdnFileUploadSaleAgreementDraft.Value;
            }


            if (FileUploadSaleAgreementFinal.HasFile)
            {
                KYC.strSaleAgreementFinal = SaveFile(FileUploadSaleAgreementFinal, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strSaleAgreementFinal = hdnFileUploadSaleAgreementFinal.Value;
            }


            if (FileUploadAllotmentLetter.HasFile)
            {
                KYC.strAllotmentLetter = SaveFile(FileUploadAllotmentLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strAllotmentLetter = hdnFileUploadAllotmentLetter.Value;
            }


            if (FileUploadWelcomeLetter.HasFile)
            {
                KYC.strWelcomeLetter = SaveFile(FileUploadWelcomeLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strWelcomeLetter = hdnFileUploadWelcomeLetter.Value;
            }

            if (FileUploadDemandLetter.HasFile)
            {
                KYC.strDemandLetter = SaveFile(FileUploadDemandLetter, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strDemandLetter = hdnFileUploadDemandLetter.Value;
            }


            if (FileUploadPaymentReceipt.HasFile)
            {
                KYC.strPaymentReceipt = SaveFile(FileUploadPaymentReceipt, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strPaymentReceipt = hdnFileUploadPaymentReceipt.Value;
            }



            if (FileUploadBill.HasFile)
            {
                KYC.strBill = SaveFile(FileUploadBill, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strBill = hdnFileUploadBill.Value;
            }

            if (FileUploadPaymentSchedule.HasFile)
            {
                KYC.strPaymentSchedule = SaveFile(FileUploadPaymentSchedule, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strPaymentSchedule = hdnFileUploadPaymentSchedule.Value;
            }



            if (FileUploadEBCard.HasFile)
            {
                KYC.strEBCard = SaveFile(FileUploadEBCard, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strEBCard = hdnFileUploadEBCard.Value;
            }


            if (FileUploadHandingOverDocuments.HasFile)
            {
                KYC.strHandingOverDocs = SaveFile(FileUploadHandingOverDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strHandingOverDocs = hdnFileUploadHandingOverDocuments.Value;
            }


            if (FileUploadCCUpdation.HasFile)
            {
                KYC.strCCUpdation = SaveFile(FileUploadCCUpdation, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strCCUpdation = hdnFileUploadCCUpdation.Value;
            }

            if (FileUploadNOC.HasFile)
            {
                KYC.strNOCforHandover = SaveFile(FileUploadNOC, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strNOCforHandover = hdnFileUploadNOC.Value;
            }

            if (FileUploadOtherDocuments.HasFile)
            {
                KYC.strOtherDocuments = SaveFile(FileUploadOtherDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strOtherDocuments = hdnFileUploadOtherDocuments.Value;
            }

            if (FileUploadBankDocuments.HasFile)
            {
                KYC.strBankDocuments = SaveFile(FileUploadBankDocuments, "KYCDocs", ddlFlatNumber.SelectedValue);
            }
            else
            {
                KYC.strBankDocuments = hdnFileUploadBankDocuments.Value;
            }
            KYC.strUpdatedBy = cId;
            ret = KYC.UpdateFlatCustomerKYCDocs(KYC);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "UpdateData", ex.Message, "Not Fixed");
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
            CE.StoreExceptionMessage("add-kyc-docs.aspx", "SaveFile", ex.Message, "Not Fixed");
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
                "   title: 'KYC docs details has been cancelled as requested', " +
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

}