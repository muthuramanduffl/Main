
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.EnterpriseServices;
using System.Diagnostics;
using System.Web.Services;

public partial class adminkey2hcomaddprojectprogress : System.Web.UI.Page
{
    ClientDashboardError CI = new ClientDashboardError();
    Key2hProjectProgress KPP = new Key2hProjectProgress();
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
    private static int ProgressID;

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
        if (Request.QueryString["ProgressID"] != null)
        {
            if (!IsPostBack)
            {
                Bindprojects();
                int value = 0;
                if (int.TryParse(Request.QueryString["ProgressID"], out value))
                {
                    lbldisplaymsg.Text = " Edit Project Progress";
                    btnadd.Text = "Submit";
                    ddlprojects.Attributes.Add("disabled", "true");
                    ddlmonth.Attributes.Add("disabled", "true");
                    ddlyear.Attributes.Add("disabled", "true");
                    Bind(value);
                }
                else
                {
                    string script = string.Format(@"<script>
                        Swal.fire({{ 
                        title: 'URL is incorrect. please try again', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success'  
                        }}
                        }}).then((result) => {{ 
                                window.location.href = 'view-project-progress.aspx'; 
                        }});
                    </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
        }
        else
        {
            if (!IsPostBack)
            {
                Bindprojects();
                lbldisplaymsg.Text = " Add Project Progress";
                btnadd.Text = "Submit";
            }
        }
    }

    public void Bind(int ID)
    {
        try
        {
            DataTable dt = KPP.ViewProjectprogressByID(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["Month"].ToString()) && dt.Rows[0]["Month"] != null)
                {
                    ddlmonth.SelectedValue = Convert.ToString(dt.Rows[0]["Month"]);
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Year"].ToString()) && dt.Rows[0]["Year"] != null)
                {
                    ddlyear.SelectedValue = Convert.ToString(dt.Rows[0]["Year"]);
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["ProjectID"].ToString()) && dt.Rows[0]["ProjectID"] != null)
                {
                    ddlprojects.SelectedValue = Convert.ToString(dt.Rows[0]["ProjectID"]);
                }
            }
            RequiredFieldValidator4.Visible = false;
            BindThumnailimage();
            BindProjectImageList();
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlprojects.DataSource = dt;
                ddlprojects.DataTextField = "ProjectName";
                ddlprojects.DataValueField = "ProjectID";
                ddlprojects.DataBind();
                ddlprojects.Items.Insert(0, new ListItem("", ""));
                ddlprojects.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlprojects.SelectedValue) && string.IsNullOrEmpty(ddlmonth.SelectedValue) &&
            string.IsNullOrEmpty(ddlyear.SelectedValue) && string.IsNullOrEmpty(txtContent.Text) && !uploadThumbnailImg.HasFile && !fileUpload.HasFile)
        {
            labelerror = "Fill the mandatory field.";
        }
        else if (string.IsNullOrEmpty(ddlprojects.SelectedValue))
        {
            labelerror = "Select project name";
        }
        else if (string.IsNullOrEmpty(ddlmonth.SelectedValue))
        {
            labelerror = "Select month";
        }
        else if (string.IsNullOrEmpty(ddlyear.SelectedValue))
        {
            labelerror = "Select year";
        }
        else if (string.IsNullOrEmpty(txtContent.Text))
        {
            labelerror = "Enter content";
        }
        else if (!fileUpload.HasFile)
        {
            labelerror = "Upload images";
        }
        else if (ProgressID == 0)
        {
            if (!uploadThumbnailImg.HasFile)
            {
                labelerror = "Upload thumbnail image";
            }
        }
        if (string.IsNullOrEmpty(labelerror))
        {
            DataTable dt = KPP.ViewprojectImageByprogressID(ProgressID);
            if (dt != null && dt.Rows.Count < 10)
            {
                int ret = 1;
                ret = AddData();
                if (ret == 1)
                {
                    //Clear();
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "alert",
                 "Swal.fire({ " +
                 "  title: 'Project progress added successfully', " +
                 "  icon: 'success', " +
                 "  customClass: { " +
                 "    icon: 'handle-icon-clr', " +
                 "    confirmButton: 'handle-btn-success' " +
                 "  } " +
                 "});", true);
                    UpdatePanel2.Update();
                    txtContent.Text = "";
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "alert",
                "Swal.fire({ " +
                "  title: 'You can upload a maximum of 10 images only', " +
                "  confirmButtonText: 'OK',"+
                "  customClass: { " +
                "    icon: 'handle-icon-clr', " +
                "    confirmButton: 'handle-btn-success' " +
                "  } " +
                "});", true);



               
                txtContent.Text = "";
                BindThumnailimage();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({title: ' " + labelerror + " !', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public int AddData()
    {
        int ret = 0;
        try
        {
            if (!Alreadyexistprojectprogress(Convert.ToInt32(ddlprojects.SelectedValue), ddlmonth.SelectedValue, Convert.ToInt32(ddlyear.SelectedValue)))
            {
                RequiredFieldValidator4.Visible = false;
                KPP.intProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
                KPP.strMonth = ddlmonth.SelectedValue;
                KPP.stryear = ddlyear.SelectedValue;
                KPP.strThumbnailimage = SaveFileorg(uploadThumbnailImg, "ProjectProgressThumbnailimage");
                KPP.strAddedBy = clientId;
                ProgressID = KPP.AddProjrctProgress(KPP);
                if (ProgressID != 0)
                {
                    BindThumnailimage();
                    ret=AddProjectimage();
                }
            }
            else
            {
                divviewthumnail.Style["top"] = "-3px";
                divthumnailfield.Style.Add("display", "none");
                BindThumnailimage();
               ret=AddProjectimage();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "AddData", ex.Message, "Not Fixed");
        }
        return ret;
    }

    public int AddProjectimage()
    {
        int ret = 0;
        try
        {
            if (ProgressID != 0)
            {
                KPP.intProgressID = ProgressID;
                KPP.strImagename = SaveFileorg(fileUpload, "ProgressImages");
                KPP.strContent = txtContent.Text;
                KPP.intDisplayOrder = 1;
                ret = KPP.AddProjrctProgressImages(KPP);
                if (ret == 1)
                {
                    BindThumnailimage();
                    BindProjectImageList();
                    txtContent.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "AddProjectimage", ex.Message, "Not Fixed");
        }
        return ret;
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
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
    public string SaveFileorg(FileUpload uploadedFile, string appkey)
    {
        int savefile = 0;
        string filename = string.Empty;
        try
        {
            string filepath = System.Configuration.ConfigurationManager.AppSettings[appkey];
            string fileName = Path.GetFileName(uploadedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            filename = GenerateFileName(ddlprojects.SelectedValue.Trim(), fileExtension).Trim('-');
            string temppath = filepath.Trim() + @"\" + filename.Trim().Replace(" ", "");
            string savepath = Server.MapPath(temppath);
            uploadedFile.SaveAs(savepath);
            savefile = 1;
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "SaveFileorg", ex.Message, "Not Fixed");
        }
        return filename.Replace(" ", "");
    }
    public bool Alreadyexistprojectprogress(int proID, string Month, int Year)
    {
        bool isavail = false;
        try
        {
            DataTable dt = KPP.AlreadyExistProjectProgressByProjectIDandDate(proID, Month, Year);
            if (dt != null && dt.Rows.Count > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "Alreadyexistprojectprogress", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    [System.Web.Services.WebMethod]
    public static bool CheckProjectExistence(int projectName, string month, int year)
    {
        ClientDashboardError CI = new ClientDashboardError();
        Key2hProjectProgress KPP = new Key2hProjectProgress();
        ClientUsers CU = new ClientUsers();
        bool isavail = false;
        try
        {
            DataTable dt = KPP.AlreadyExistProjectProgressByProjectIDandDate(projectName, month, year);
            if (dt != null && dt.Rows.Count > 0)
            {
                ProgressID = Convert.ToInt32(dt.Rows[0]["ProgressID"]);
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "CheckProjectExistence", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }

    public void DDlchangeFunction()
    {
        if (!string.IsNullOrEmpty(ddlprojects.SelectedValue) && !string.IsNullOrEmpty(ddlmonth.SelectedValue) && !string.IsNullOrEmpty(ddlyear.SelectedValue))
        {
            try
            {
                DataTable dt = KPP.AlreadyExistProjectProgressByProjectIDandDate(Convert.ToInt32(ddlprojects.SelectedValue), ddlmonth.SelectedValue, Convert.ToInt32(ddlyear.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    RequiredFieldValidator4.Visible = false;
                    divviewthumnail.Style["top"] = "-3px";
                    divviewthumnail.Style.Add("display", "block");
                    divthumnailfield.Style.Add("display", "none");
                    BindThumnailimage();
                    BindProjectImageList();
                }
                else
                {
                    RequiredFieldValidator4.Visible = true;
                    divthumnailfield.Style.Add("display", "block");
                    divviewthumnail.Style.Add("display", "none");
                    divProjectprogressimages.Style.Add("Display", "none");
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("add-project-progress.aspx", "DDlchangeFunction", ex.Message, "Not Fixed");
            }
        }
    }

    public void BindThumnailimage()
    {
        if (!string.IsNullOrEmpty(ddlprojects.SelectedValue) && !string.IsNullOrEmpty(ddlmonth.SelectedValue) && !string.IsNullOrEmpty(ddlyear.SelectedValue))
        {
            try
            {
                DataTable dt = KPP.AlreadyExistProjectProgressByProjectIDandDate(Convert.ToInt32(ddlprojects.SelectedValue), ddlmonth.SelectedValue, Convert.ToInt32(ddlyear.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ThumbnailImage"].ToString()) && dt.Rows[0]["ThumbnailImage"] != null)
                    {
                        string applicantPhoto = dt.Rows[0]["ThumbnailImage"].ToString();
                        string filepath = System.Configuration.ConfigurationManager.AppSettings["ProjectProgressThumbnailimage"];
                        string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);
                        string fileUrl = ResolveUrl(fullFilePath);
                        string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                        string script = string.Format("window.bindImageToPreviewphoto('{0}', 0, 'photo1');", formattedImagePath);
                        //  ClientScript.RegisterStartupScript(this.GetType(), "bindApplicantPhoto", script, true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "bindApplicantPhoto", script, true);
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ProgressID"].ToString()) && dt.Rows[0]["ProgressID"] != null)
                    {
                        ProgressID = Convert.ToInt32(dt.Rows[0]["ProgressID"]);
                    }
                }
                else
                {
                    ProgressID = 0;
                    RequiredFieldValidator4.Visible = true;
                    divthumnailfield.Style.Add("display", "block");
                    divviewthumnail.Style.Add("display", "none");
                    divProjectprogressimages.Style.Add("Display", "none");
                }
                divviewthumnail.Style["top"] = "0px";
                divthumnailfield.Style.Add("display", "none");
            }

            catch (Exception ex)
            {
                CI.StoreExceptionMessage("add-project-progress.aspx", "BindThumnailimage", ex.Message, "Not Fixed");
            }
        }
        else
        {
            //select ddl.
        }
    }
    public void BindProjectImageList()
    {
        try
        {

            DataTable dt = KPP.ViewprojectImageByprogressID(ProgressID);
            if (dt != null && dt.Rows.Count > 0)
            {
                divProjectprogressimages.Style.Add("Display", "block");
                rpProjectprogressimages.Visible = true;
                rpProjectprogressimages.DataSource = dt;
                rpProjectprogressimages.DataBind();
            }
            else
            {
                divProjectprogressimages.Style.Add("Display", "none");
                rpProjectprogressimages.Visible = false;
            }
        }

        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project-progress.aspx", "BindProjectImageList", ex.Message, "Not Fixed");
        }
    }

    public class CostDetail
    {
        public int ProgressImageID { get; set; }
        public int ProgressID { get; set; }
        public string Content { get; set; }
        public string ImageName { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {
        Key2hProjectProgress KPP = new Key2hProjectProgress();
        ClientDashboardError CE = new ClientDashboardError();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable dt = KPP.ViewProjectprojectID(Convert.ToInt32(selectedValue));
                DataView dv = new DataView();
                dv = dt.DefaultView;
                string filterExpression = string.Empty;
                List<string> filterList = new List<string>();
                string strclientID = clientId;
                if (!string.IsNullOrEmpty(strclientID))
                {
                    if (!string.IsNullOrEmpty(filterExpression)) filterExpression += " AND ";
                    filterExpression += "AddedBy = '" + strclientID.Replace("'", "''") + "'";
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
                if (dt!=null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CostDetail costDetail = new CostDetail
                        {
                            ProgressImageID = Convert.ToInt32(row["ProgressImageID"]),
                            ProgressID = Convert.ToInt32(row["ProgressID"]),
                            Content = Convert.ToString(row["Content"]),
                            ImageName = Convert.ToString(row["ImageName"])
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
            CE.StoreExceptionMessage("add-project-progress.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    [System.Web.Services.WebMethod]
    public static string DeleteCustomer(string ProgressImageID)
    {
        Key2hProjectProgress KPP = new Key2hProjectProgress();
        ClientDashboardError CE = new ClientDashboardError();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            Key2hCostDetails KD = new Key2hCostDetails();
            DataTable dt = KPP.ViewprojectImageByprogressImageID(Convert.ToInt32(ProgressImageID));
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ImageName"])))
                {
                    string strlogo = Convert.ToString(dt.Rows[0]["ImageName"]);
                    FileDelete(strlogo, "ProgressImages");
                }
            }
            ret = KPP.DeleteProjectprogressImagesByID(Convert.ToInt32(ProgressImageID));
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
            CE.StoreExceptionMessage("add-project-progress.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
        }
        return strerror;
    }
    public static void FileDelete(string ImageName, string appkey)
    {
        ClientDashboardError CE = new ClientDashboardError();
        string filePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings[appkey]);
        filePath += "//" + ImageName.Trim();
        if (System.IO.File.Exists(filePath))
        {
            try
            {
                System.IO.File.Delete(filePath);

            }
            catch (System.IO.IOException e)
            {
                CE.StoreExceptionMessage("add-project-progress.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }
}