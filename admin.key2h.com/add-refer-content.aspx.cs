using System;
using System.Data;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class adminkey2hcom_AddReferContent : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
    ClientdashboardIssue CE = new ClientdashboardIssue();
    ClientDashboardError CI = new ClientDashboardError();
    private static string clientId;
    private static string[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
    private static string[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

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
        if (!IsPostBack)
        {
            Bindprojects();
            if (Request.QueryString["ID"] != null)
            {
                int value = 0;
                if (int.TryParse(Request.QueryString["ID"], out value))
                {
                    lbldisplaymsg.Text = " Edit Refer Content";
                    btnSave.Text = "Update";
                    Bind(Convert.ToInt32(Request.QueryString["ID"]));
                    ddlProName.Attributes.Add("disabled", "true");
                }
                else
                {
                    string script = string.Format(@"<script> Swal.fire({{ title: ' URL is incorrect. please try again', 
                    confirmButtonText: 'OK', customClass: {{ confirmButton: 'handle-btn-success'  }}}}).then((result) => {{
                    window.location.href = 'view-refer-content.aspx';}}); </script>"); 
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false); 
                }
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
            CI.StoreExceptionMessage("add-refer-content.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }

    public void Bind(int id)
    { 
        try
        {
            DataTable dt = K2.ViewReferScreenContentbyReferID(id); 
            if (dt.Rows.Count > 0)
            { 
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectID"])))
                {
                    ddlProName.SelectedValue = Convert.ToString(dt.Rows[0]["ProjectID"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Question"])))
                {
                    txtQuestion.Text = Convert.ToString(dt.Rows[0]["Question"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Content"])))
                {
                    txtBriefContent.Text = Convert.ToString(dt.Rows[0]["Content"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MessageContent"])))
                {
                    txtMessageContent.Text = Convert.ToString(dt.Rows[0]["MessageContent"]);
                }
                // Refer Photo
                if (!string.IsNullOrEmpty(dt.Rows[0]["Image"].ToString()) && dt.Rows[0]["Image"] != null)
                {
                    RequiredFieldValidator2.Visible = false;
                    hdnImageUpload.Value = dt.Rows[0]["Image"].ToString();
                    string image = dt.Rows[0]["Image"].ToString();
                    string filepath = System.Configuration.ConfigurationManager.AppSettings["ReferScreen"];
                    string fullFilePath = Path.Combine(filepath.Trim(), image);
                    string fileUrl = ResolveUrl(fullFilePath);
                    string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                    string script = string.Format("window.bindImageToPreviewphoto('{0}', 0, 'photo1');", formattedImagePath);
                    ClientScript.RegisterStartupScript(this.GetType(), "bindApplicantPhoto", script, true);
                } 
            }
        }
        catch (Exception ex)
        {
            CE.Pagename = "add-refer-content.aspx";
            CE.MethodOrFunctionname = "Bind";
            CE.ErrrMsg = ex.Message.ToString();
            CE.IssueStatus = "Not Fixed";
            CE.AddClientdashboardissues(CE);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    { 
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && !FluploadImageUpload.HasFile &&
            string.IsNullOrEmpty(txtQuestion.Text) && string.IsNullOrEmpty(txtBriefContent.Text) &&
            string.IsNullOrEmpty(txtMessageContent.Text))
        {
            labelerror = "Fill the mandatory fields.";
        }
        else if (string.IsNullOrEmpty(ddlProName.SelectedValue))
        {
            labelerror = "Select project name";
        }
        else if (string.IsNullOrEmpty(txtQuestion.Text))
        {
            labelerror = "Enter question";
        }
        else if (string.IsNullOrEmpty(txtBriefContent.Text))
        {
            labelerror = "Enter brief content";
        }
        else if (string.IsNullOrEmpty(txtMessageContent.Text))
        {
            labelerror = "Enter message content";
        } 
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["ID"] == null)
            {
                //bool plavail = true;
                if (!IsAlreadyexist(Convert.ToInt32(ddlProName.SelectedValue)))
                {
                    int ret = 1;
                    ret = AddReferScreenContent();
                    if (ret == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                        "  title: 'Refer content added successfully', " +
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
                                title: 'Refer content details not added due to a server or network issue', 
                                confirmButtonText: 'OK', 
                                customClass: {{ 
                                    confirmButton: 'handle-btn-success' 
                                }} 
                            }}).then((result) => {{  
                                    window.location.href = 'add-refer-content.aspx';  
                            }});
                            </script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false); 
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " +
                          "  title: 'The refer content you’re trying to add already exists', " +
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
                ret = UpdateReferScreenContent();
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                    "    title: 'Refer content details updated successfully', " +
                    "    icon: 'success', " +
                    "    allowOutsideClick: 'true', " +
                    "    customClass: { " +
                    "        confirmButton: 'handle-btn-success', " +
                    "        icon: 'handle-icon-clr' " +
                    "    } " +
                    "}).then((result) => { " +
                    "        window.location.href = 'view-refer-content.aspx'; " + 
                    "});",
                    true); 
                }
                else
                {
                     string script = string.Format(@"<script>
                        Swal.fire({{
                            title: 'Refer Content details not updated due to a server or network issue', 
                            confirmButtonText: 'OK', 
                            customClass: {{ confirmButton: 'handle-btn-success' }} 
                        }}).then((result) => {{ 
                                window.location.href = 'add-refer-content.aspx?ID={0}';  
                        }});
                    </script>",
                     System.Web.HttpUtility.JavaScriptStringEncode(Convert.ToString(Request.QueryString["ID"]))); 
                    ClientScript.RegisterStartupScript(this.GetType(), "SwalNotification", script, false);
                }
            }

        }
        else
        {
            //alert labelerror
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //"Swal.fire('Validation Alert', '" + labelerror + "!.', 'success');", true);
        } 
    }

    public bool IsAlreadyexist(int Project)
    {
        bool isavail = false;
        try
        {
            DataTable dt = K2.AlreadyExistReferScreenbyProjectID(Project);
            if (dt.Rows.Count > 0 && isavail != true)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-refer-content.aspx", "IsAlreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }


    public int AddReferScreenContent()
    {
        int ret = 0;
        try
        {
            K2.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            K2.Image = SaveFile(FluploadImageUpload, "ReferScreen", ddlProName.SelectedItem.Text);
            K2.Question = txtQuestion.Text;
            K2.Content = txtBriefContent.Text;
            K2.MessageContent = txtMessageContent.Text;
            K2.AddedBy = clientId;
            K2.ClientID = Convert.ToInt32(clientId);
            DateTime addeddate = DateTime.Now;
            K2.AddedDate = addeddate.ToString("yyyy-MM-dd"); 
            ret = K2.AddReferScreenContent(K2);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-refer-content.aspx", "AddReferScreenContent", ex.Message, "Not Fixed");
        }
        return ret;
    }

    public int UpdateReferScreenContent()
    {
        int ret = 0;
        // try
        // {
            K2.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            K2.ReferScreenID = Convert.ToInt32(Request.QueryString["ID"]);
            if (FluploadImageUpload.HasFile)
            {
                K2.Image = SaveFile(FluploadImageUpload, "ReferScreen", ddlProName.SelectedItem.Text);
            }
            else
            {
                K2.Image  = hdnImageUpload.Value;
            }

            K2.Question = txtQuestion.Text;
            K2.Content = txtBriefContent.Text;
            K2.MessageContent = txtMessageContent.Text;
            
            ret = K2.UpdateReferScreenContent(K2);
        // }
        // catch (Exception ex)
        // {
        //     CI.StoreExceptionMessage("add-refer-content.aspx", "UpdateReferScreenContent", ex.Message, "Not Fixed");
        // }
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
            CI.StoreExceptionMessage("add-refer-content.aspx", "SaveFile", ex.Message, "Not Fixed");
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
        if (Request.QueryString["ProjectID"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //      "Swal.fire('Cancelled!', 'Your action has been canceled.', 'success');",
            //      true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({ " +
            "   title: 'Refer content has been cancelled as requested', " +
            "   confirmButtonText: 'OK', " +
            "   customClass: { " +
            "       confirmButton: 'handle-btn-success' " +
            "   } " +
            "}).then((result) => { " + 
            "       window.location.href = 'add-refer-content.aspx'; " + 
            "});", true);
        }
    }

    public void Clear()
    { 
        Response.Redirect(Request.Url.AbsolutePath); 
    }
     
}