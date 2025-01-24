
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
using System.Web.Services;

public partial class adminkey2hcomaddflatprogress : System.Web.UI.Page
{

    ClientDashboardError CI = new ClientDashboardError();
    Key2hFlatProgress KFP = new Key2hFlatProgress();
    Key2hProjectProgress KPP = new Key2hProjectProgress();
    Key2hProject K2 = new Key2hProject();
    Key2hProjectblock KB = new Key2hProjectblock();
    ClientUsers CU = new ClientUsers();
    Key2hFlat KF = new Key2hFlat();
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
        if (Request.QueryString["FlatProgressID"] != null)
        {
            if (!IsPostBack)
            {
                Bindprojects();
                int value = 0;
                if (int.TryParse(Request.QueryString["FlatProgressID"], out value))
                {
                    lbldisplaymsg.Text = " Edit Flat Progress";
                    btnadd.Text = "Submit";
                    ddlprojects.Attributes.Add("disabled", "true");
                    ddlFlatNumbers.Attributes.Add("disabled", "true");
                    ddlBlockName.Attributes.Add("disabled", "true");
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
                            if (result.isConfirmed) {{
                                window.location.href = 'view-project-progress.aspx';
                            }}
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
                lbldisplaymsg.Text = " Add Flat Progress";
                btnadd.Text = "Submit";
            }
        }

    }
    public void Bind(int ID)
    {
        try
        {
            DataTable dt = KFP.ViewAllFlatProgress("", "", "", "", "", Convert.ToString(ID));
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
                    Bindblock();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["BlockID"].ToString()) && dt.Rows[0]["BlockID"] != null)
                {
                    ddlBlockName.SelectedValue = Convert.ToString(dt.Rows[0]["BlockID"]);
                    BindFlat();
                }

                if (!string.IsNullOrEmpty(dt.Rows[0]["FlatID"].ToString()) && dt.Rows[0]["FlatID"] != null)
                {
                    ddlFlatNumbers.SelectedValue = Convert.ToString(dt.Rows[0]["FlatID"]);
                }
            }
            RequiredFieldValidator4.Visible = false;
            BindThumnailimage();
            BindFlatImageList();
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojects.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojects.SelectedValue));
                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlBlockName.DataSource = DT;
                    ddlBlockName.DataTextField = "BlockName";
                    ddlBlockName.DataValueField = "BlockID";
                    ddlBlockName.DataBind();
                    ddlBlockName.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlBlockName.Items.Clear();
                    ddlBlockName.Items.Insert(0, new ListItem("No Block number", ""));
                }
            }
            else
            {
                ddlBlockName.Items.Clear();
                ddlBlockName.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlBlockName.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlBlockName.SelectedValue));
                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlFlatNumbers.DataSource = DT;
                    ddlFlatNumbers.DataTextField = "FlatName";
                    ddlFlatNumbers.DataValueField = "FlatID";
                    ddlFlatNumbers.DataBind();
                    ddlFlatNumbers.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlFlatNumbers.Items.Clear();
                    ddlFlatNumbers.Items.Insert(0, new ListItem("", ""));
                    ddlFlatNumbers.Items.Insert(1, new ListItem("No Flat number", ""));
                }
            }
            else
            {
                ddlFlatNumbers.Items.Clear();
                ddlFlatNumbers.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "BindFlat", ex.Message, "Not Fixed");
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
                //ddlprojectname.Items.Insert(1, new ListItem("Selected", ""));
                ddlprojects.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlprojects.SelectedValue) && string.IsNullOrEmpty(ddlmonth.SelectedValue) && string.IsNullOrEmpty(ddlBlockName.SelectedValue) && string.IsNullOrEmpty(ddlBlockName.SelectedValue) &&
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
        else if (string.IsNullOrEmpty(ddlBlockName.SelectedValue))
        {
            labelerror = "Select block name";
        }
        else if (string.IsNullOrEmpty(ddlFlatNumbers.SelectedValue))
        {
            labelerror = "Select flat number";
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
            DataTable dt = KFP.ViewFlatImageByprogressID(ProgressID);
            if (dt != null && dt.Rows.Count < 10)
            {
                int ret = 1;
                ret = AddData();
                if (ret == 1)
                {
                    //Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                     "  title: 'Flat progress added successfully', " +
                     "  icon: 'success', " +
                     "  customClass: { " +
                     "    icon: 'handle-icon-clr', " +
                     "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "});", true);

                    txtContent.Text = "";

                }
            }
            else
            {
                string script = @"<script>
                  Swal.fire({
                  title: 'Flat progress image maximum 10.',
                  confirmButtonText: 'OK',
                  customClass: { confirmButton: 'handle-btn-success' }
                  });
                  </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalNotification", script, false);
                txtContent.Text = "";
                BindThumnailimage();
            }
        }
        else
        {
            //alert labelerror
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({title: ' " + labelerror + " is required for upload', confirmButtonText: 'OK', customClass: { confirmButton: 'handle-btn-success' }});", true);
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
            if (!Alreadyexistflatprogress(Convert.ToInt32(ddlprojects.SelectedValue), Convert.ToInt32(ddlFlatNumbers.SelectedValue), ddlmonth.SelectedValue, Convert.ToInt32(ddlyear.SelectedValue)))
            {
                RequiredFieldValidator4.Visible = false;
                KFP.intProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
                KFP.intFlatID = Convert.ToInt32(ddlFlatNumbers.SelectedValue);
                KFP.strMonth = ddlmonth.SelectedValue;
                KFP.stryear = ddlyear.SelectedValue;
                KFP.strThumbnailimage = SaveFileorg(uploadThumbnailImg, "FlatProgressThumbnailimage");
                KFP.strAddedBy = clientId;
                ProgressID = KFP.AddFlatProgress(KFP); ;
                if (ProgressID != 0)
                {
                    BindThumnailimage();
                    ret = AddFlatimage();
                }
            }
            else
            {
                divviewthumnail.Style["top"] = "-3px";
                divthumnailfield.Style.Add("display", "none");
                BindThumnailimage();
                ret = AddFlatimage();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "AddData", ex.Message, "Not Fixed");
        }
        return ret;
    }
    public int AddFlatimage()
    {
        int ret = 0;
        try
        {
            if (ProgressID != 0)
            {
                KFP.intFlatProgressID = ProgressID;
                KFP.strImagename = SaveFileorg(fileUpload, "FlatProgressimage");
                KFP.strContent = txtContent.Text;
                KFP.intDisplayOrder = 1;
                ret = KFP.AddFlatProgressImage(KFP);
                if (ret == 1)
                {
                    BindThumnailimage();
                    BindFlatImageList();
                    txtContent.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "AddFlatimage", ex.Message, "Not Fixed");
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
        ddlprojects.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        ddlyear.SelectedIndex = 0;
        txtContent.Text = "";
        RequiredFieldValidator4.Visible = true;

        //BindCity();
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
    public bool Alreadyexistflatprogress(int proID, int flatID, string Month, int Year)
    {
        bool isavail = false;
        try
        {
            DataTable dt = KFP.AlreadyExistFlatProgressByPIDandFIDandDate(proID, flatID, Month, Year);
            if (dt != null && dt.Rows.Count > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "Alreadyexistflatprogress", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("add-flat-progress.aspx", "CheckProjectExistence", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
        DDlchangeFunction();
    }
    protected void ddlblocknumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        DDlchangeFunction();
    }
    protected void ddlFlatNumbers_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlchangeFunction();
    }
    public void DDlchangeFunction()
    {
        if (!string.IsNullOrEmpty(ddlprojects.SelectedValue) && !string.IsNullOrEmpty(ddlBlockName.SelectedValue) && !string.IsNullOrEmpty(ddlFlatNumbers.SelectedValue) && !string.IsNullOrEmpty(ddlmonth.SelectedValue) && !string.IsNullOrEmpty(ddlyear.SelectedValue))
        {
            BindThumnailimage();
        }
        else
        {
            RequiredFieldValidator4.Visible = true;
            divthumnailfield.Style.Add("display", "block");
            divviewthumnail.Style.Add("display", "none");
            divflatprogressimages.Style.Add("Display", "none");
        }
    }
    public void BindThumnailimage()
    {
        if (!string.IsNullOrEmpty(ddlprojects.SelectedValue) && !string.IsNullOrEmpty(ddlBlockName.SelectedValue) && !string.IsNullOrEmpty(ddlFlatNumbers.SelectedValue) && !string.IsNullOrEmpty(ddlmonth.SelectedValue) && !string.IsNullOrEmpty(ddlyear.SelectedValue))
        {
            try
            {
                DataTable dt = KFP.AlreadyExistFlatProgressByPIDandFIDandDate(Convert.ToInt32(ddlprojects.SelectedValue), Convert.ToInt32(ddlFlatNumbers.SelectedValue), ddlmonth.SelectedValue, Convert.ToInt32(ddlyear.SelectedValue));
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ThumbnailImage"].ToString()) && dt.Rows[0]["ThumbnailImage"] != null)
                    {
                        string applicantPhoto = dt.Rows[0]["ThumbnailImage"].ToString();
                        string filepath = System.Configuration.ConfigurationManager.AppSettings["FlatProgressThumbnailimage"];
                        string fullFilePath = Path.Combine(filepath.Trim(), applicantPhoto);
                        string fileUrl = ResolveUrl(fullFilePath);
                        string formattedImagePath = HttpUtility.JavaScriptStringEncode(fileUrl);
                        string script = string.Format("window.bindImageToPreviewphoto('{0}', 0, 'photo1');", formattedImagePath);
                        //  ClientScript.RegisterStartupScript(this.GetType(), "bindApplicantPhoto", script, true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "bindApplicantPhoto", script, true);
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FlatProgressID"].ToString()) && dt.Rows[0]["FlatProgressID"] != null)
                    {
                        ProgressID = Convert.ToInt32(dt.Rows[0]["FlatProgressID"]);
                    }
                    divviewthumnail.Style["top"] = "5px";
                    divthumnailfield.Style.Add("display", "none");
                    RequiredFieldValidator4.Visible = false;
                    BindFlatImageList();
                }
                else
                {
                    ProgressID = 0;
                    RequiredFieldValidator4.Visible = true;
                    divthumnailfield.Style.Add("display", "block");
                    divviewthumnail.Style.Add("display", "none");
                    divflatprogressimages.Style.Add("Display", "none");
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("add-flat-progress.aspx", "BindThumnailimage", ex.Message, "Not Fixed");
            }
        }
        else
        {
            RequiredFieldValidator4.Visible = true;
            divthumnailfield.Style.Add("display", "block");
            divviewthumnail.Style.Add("display", "none");
            divflatprogressimages.Style.Add("Display", "none");
        }
    }
    public void BindFlatImageList()
    {
        try
        {
            DataTable dt = KFP.ViewFlatImageByprogressID(ProgressID);
            if (dt != null && dt.Rows.Count > 0)
            {
                divflatprogressimages.Style.Add("Display", "block");
                rpflatprogressimages.Visible = true;
                rpflatprogressimages.DataSource = dt;
                rpflatprogressimages.DataBind();
            }
            else
            {
                divflatprogressimages.Style.Add("Display", "none");
                rpflatprogressimages.Visible = false;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-progress.aspx", "BindFlatImageList", ex.Message, "Not Fixed");
        }
    }
    public class CostDetail
    {
        public int ProgressImageID { get; set; }
        public int FlatProgressID { get; set; }
        public string Content { get; set; }
        public string ImageName { get; set; }
    }
    [WebMethod]
    public static List<CostDetail> GetCostDetails(string selectedValue)
    {
        Key2hFlatProgress KFP = new Key2hFlatProgress();
        ClientDashboardError CE = new ClientDashboardError();
        List<CostDetail> costDetails = new List<CostDetail>();
        try
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataTable dt = KFP.ViewFlatprojectID(Convert.ToInt32(selectedValue));
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
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CostDetail costDetail = new CostDetail
                        {
                            ProgressImageID = Convert.ToInt32(row["FlatProgressImageID"]),
                            FlatProgressID = Convert.ToInt32(row["FlatProgressID"]),
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
            CE.StoreExceptionMessage("add-flat-progress.aspx", "GetCostDetails", ex.Message, "Not Fixed");
        }
        return costDetails;
    }
    [System.Web.Services.WebMethod]
    public static string DeleteCustomer(string FlatProgressImageID)
    {
        Key2hFlatProgress KFP = new Key2hFlatProgress();
        ClientDashboardError CE = new ClientDashboardError();
        string strerror = string.Empty;
        int ret = 0;
        try
        {
            Key2hCostDetails KD = new Key2hCostDetails();

            DataTable dt1 = KFP.ViewFlatImageByprogressImageID(Convert.ToInt32(FlatProgressImageID));
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                
                    if (!string.IsNullOrEmpty(Convert.ToString(dt1.Rows[0]["ImageName"])))
                    {
                        string imagename = Convert.ToString(dt1.Rows[0]["ImageName"]);
                        FileDelete(imagename, "FlatProgressimage");
                    }
                
            }

            ret = KFP.DeleteProjectprogressImagesByID(Convert.ToInt32(FlatProgressImageID));
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
            CE.StoreExceptionMessage("add-flat-progress.aspx", "DeleteCustomer", ex.Message, "Not Fixed");
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
                CE.StoreExceptionMessage("add-flat-progress.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
    }
}