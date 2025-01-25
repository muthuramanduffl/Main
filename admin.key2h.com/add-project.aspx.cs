
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class adminkey2hcom_Addproject : System.Web.UI.Page
{
    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProject K2 = new Key2hProject();

    private static string clientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        int value = 0;
        string clientLoginId = CU.GetClientLoginID();
        if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
        {
            clientId = clientLoginId.Replace("clientid=", "");
        }
        else
        {
            Response.Redirect("index.aspx");
        }

        if (Request.QueryString["Projectid"] != null)
        {

            if (int.TryParse(Request.QueryString["Projectid"], out value))
            {
                //edit
                btnSave.Text = "Update";
                lbldisplaystatus.Text = "Edit Project";

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
                            window.location.href = 'view-project.aspx';   
                    }}); 
                    </script>");
                ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
            }
        }
        else
        {
            lbldisplaystatus.Text = "Add Project";
            btnSave.Text = "Submit";
            //add
        }
        if (!IsPostBack)
        {
            BindState();
            ddlstate.SelectedValue = "25";
            BindCity();
            Bind(Convert.ToInt32(value));


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
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat-booking.aspx", "BindState", ex.Message, "Not Fixed");
        }
    }

    public void Bind(int id)
    {
        try
        {
            DataTable dt = K2.ViewAllProjectsByid(id);
            //RequiredFieldValidator14.Visible = false;
            //RequiredFieldValidator15.Visible = false;
            viewproscreenbtn.Style["top"] = "5px";
            //   viewmapbtn.Style["top"] = "5px";
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectName"])))
                {
                    txtprojectname.Text = Convert.ToString(dt.Rows[0]["ProjectName"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Location"])))
                {
                    txtlocation.Text = Convert.ToString(dt.Rows[0]["Location"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Address"])))
                {
                    txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["State"])))
                {
                    ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                    BindCity();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["City"])))
                {
                    ddlcity.SelectedValue = Convert.ToString(dt.Rows[0]["City"]);

                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PostalCode"])))
                {
                    txtpostalcode.Text = Convert.ToString(dt.Rows[0]["PostalCode"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["GoogleMapLink"])))
                {
                    txtGooglemap.Text = Convert.ToString(dt.Rows[0]["GoogleMapLink"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BlockCount"])))
                {
                    txtnoofblocks.Text = Convert.ToString(dt.Rows[0]["BlockCount"]);
                    txtnoofblocks.ReadOnly = true;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FlatCount"])))
                {
                    txtflatsunits.Text = Convert.ToString(dt.Rows[0]["FlatCount"]);
                    txtflatsunits.ReadOnly = true;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["LandArea"])))
                {
                    txtlandarea.Text = Convert.ToString(dt.Rows[0]["LandArea"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["RERANumber"])))
                {
                    txtreranumber.Text = Convert.ToString(dt.Rows[0]["RERANumber"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Bhk"])))
                {
                    txtbhk.Text = Convert.ToString(dt.Rows[0]["Bhk"]);
                   
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SquareFeet"])))
                {
                    txtsqft.Text = Convert.ToString(dt.Rows[0]["SquareFeet"]);
                    
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Longitude"])))
                {
                    txtlongitude.Text = Convert.ToString(dt.Rows[0]["Longitude"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Latitude"])))
                {
                    txtlatitude.Text = Convert.ToString(dt.Rows[0]["Latitude"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectStatus"])))
                {
                    ddlProjectstatus.SelectedValue = Convert.ToString(dt.Rows[0]["ProjectStatus"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectDisplayStatus"])))
                {
                    bool istrue = Convert.ToBoolean(dt.Rows[0]["ProjectDisplayStatus"]);
                    if (istrue)
                    {
                        toggleActiveInactive.Checked = true;
                    }
                    else
                    {
                        toggleActiveInactive.Checked = false;
                    }
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectStatusPercentage"])))
                {
                    txtProjectstatus.Text = Convert.ToString(dt.Rows[0]["ProjectStatusPercentage"]);
                }
                // if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["LocationMap"])))
                // {
                //     hdnuploadlocationmap.Value = Convert.ToString(dt.Rows[0]["LocationMap"]);
                //     string filepath2 = System.Configuration.ConfigurationManager.AppSettings["GoogleMap"];
                //     string fullFilePath2 = Path.Combine(filepath2, hdnuploadlocationmap.Value);
                //     string fileUrl2 = fullFilePath2;
                //     string formattedImagePath2 = HttpUtility.JavaScriptStringEncode(fileUrl2);
                //     // Safely construct the script string
                //     string script2 = string.Format(
                //         "var srcmap = '{0}'; bindImageToPreviewlocationmap(srcmap);",
                //         formattedImagePath2
                //     );
                //     ClientScript.RegisterStartupScript(this.GetType(), "locationmap", script2, true);
                // }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BankName"])))
                {
                    txtBankname.Text = Convert.ToString(dt.Rows[0]["BankName"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["AccountName"])))
                {
                    txtaccountname.Text = Convert.ToString(dt.Rows[0]["AccountName"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IFSCNumber"])))
                {
                    txtifscnumber.Text = Convert.ToString(dt.Rows[0]["IFSCNumber"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BranchName"])))
                {
                    txtBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["AccountNumber"])))
                {
                    txtaccountnumber.Text = Convert.ToString(dt.Rows[0]["AccountNumber"]);
                }
                
            }
            else
            {
                string script = string.Format(@"
                <script>
                Swal.fire({{ 
                    title: 'No project details are available for the specified project ID', 
                    confirmButtonText: 'OK', 
                    customClass: {{ 
                        confirmButton: 'handle-btn-success' 
                    }} 
                }}).then((result) => {{  
                        window.location.href = 'add-project.aspx';  
                }});
                </script>");
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(txtprojectname.Text) && string.IsNullOrEmpty(txtlocation.Text) && string.IsNullOrEmpty(txtAddress.Text) && string.IsNullOrEmpty(ddlstate.SelectedValue) &&
            string.IsNullOrEmpty(ddlcity.SelectedValue) && string.IsNullOrEmpty(txtpostalcode.Text) && string.IsNullOrEmpty(txtnoofblocks.Text) && string.IsNullOrEmpty(txtflatsunits.Text) &&
            string.IsNullOrEmpty(txtlandarea.Text) && string.IsNullOrEmpty(txtreranumber.Text) && string.IsNullOrEmpty(ddlProjectstatus.SelectedValue) && string.IsNullOrEmpty(txtProjectstatus.Text))
        {
            labelerror = "Fill the mandatory field";
        }
        else if (string.IsNullOrEmpty(txtprojectname.Text))
        {
            labelerror = "Enter project name";
        }
        else if (string.IsNullOrEmpty(txtlocation.Text))
        {
            labelerror = "Enter location";
        }
        else if (string.IsNullOrEmpty(txtAddress.Text))
        {
            labelerror = "Enter address";
        }
        else if (string.IsNullOrEmpty(ddlstate.SelectedValue))
        {
            labelerror = "Select state";
        }
        else if (string.IsNullOrEmpty(ddlcity.SelectedValue))
        {
            labelerror = "select city";
        }
        else if (string.IsNullOrEmpty(txtpostalcode.Text))
        {
            labelerror = "Enter postal code";
        }
        //else if (string.IsNullOrEmpty(txtGooglemap.Text))
        //{
        //    labelerror = "Enter google map";
        //}
        else if (string.IsNullOrEmpty(txtnoofblocks.Text))
        {
            labelerror = "Enter no. of blocks";
        }
        else if (string.IsNullOrEmpty(txtflatsunits.Text))
        {
            labelerror = "Enter flats";
        }
        else if (string.IsNullOrEmpty(txtbhk.Text))
        {
            labelerror = "Enter BHK types";
        }
        else if (string.IsNullOrEmpty(txtsqft.Text))
        {
            labelerror = "Enter sq.ft range";
        }
        else if (string.IsNullOrEmpty(txtlandarea.Text))
        {
            labelerror = "Enter landarea";
        }
        else if (string.IsNullOrEmpty(txtreranumber.Text))
        {
            labelerror = "Enter RERA no.";
        }
        else if (string.IsNullOrEmpty(txtlatitude.Text))
        {
            labelerror = "Enter latitude";
        }
        else if (string.IsNullOrEmpty(txtlongitude.Text))
        {
            labelerror = "Enter longitude";
        }
        else if (string.IsNullOrEmpty(ddlProjectstatus.SelectedValue))
        {
            labelerror = "Select project status";
        }
        else if (string.IsNullOrEmpty(txtProjectstatus.Text))
        {
            labelerror = "Enter completion";
        }
        else if (string.IsNullOrEmpty(txtbhk.Text))
        {
            labelerror = "Enter BHK types";
        }
        else if (string.IsNullOrEmpty(txtsqft.Text))
        {
            labelerror = "Enter sq.ft range";
        }

        if (string.IsNullOrEmpty(labelerror))
        {
            if (!IsAlreadyexist(Convert.ToString(Request.QueryString["Projectid"]), txtprojectname.Text)) //Set the default client ID. But originally,got the ID based on login details.
            {
                if (Request.QueryString["Projectid"] == null)
                {
                    int ret = 0;
                    ret = AddData();
                    if (ret ==2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " +
                        "  title: 'Project details added successfully', " +
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
                        string script = string.Format(@"
                        <script>
                        Swal.fire({{ 
                            title: 'Project details couldn't be added due to a server or network issue. Please try again in some time!', 
                            confirmButtonText: 'OK', 
                            customClass: {{ 
                                confirmButton: 'handle-btn-success' 
                            }} 
                        }}).then((result) => {{  
                                window.location.href = 'add-project.aspx';  
                        }});
                        </script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                    }
                }
                else
                {
                    int ret = 0;
                    ret = UpdateData();
                    if (ret ==2)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                    "    title: 'Project details updated successfully', " +
                    "    icon: 'success', " +
                    "    allowOutsideClick: true, " +
                    "    customClass: { " +
                    "        confirmButton: 'handle-btn-success', " +
                    "        icon: 'handle-icon-clr' " +
                    "    } " +
                    "}).then((result) => { " +
                    "    if (result.isConfirmed) { " +
                    "        window.location.href = 'view-project.aspx'; " +
                    "    } " +
                    "});",
                    true);
                    }
                    else
                    {
                        string script = string.Format(@"
                    <script>
                        Swal.fire({{
                            title: 'Project details couldn't be updated due to a server or network issue. Please try again in some time!',
                            confirmButtonText: 'OK',
                            customClass: {{
                                confirmButton: 'handle-btn-success'
                            }}
                        }}).then((result) => {{ 
                                window.location.href = 'add-project.aspx?ProjectID={0}'; 
                        }});
                    </script>", Convert.ToString(Request.QueryString["Projectid"]));
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                     "Swal.fire({ " +
                      "  title: 'The project you’re trying to add already exists', " +
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
    }

    public bool IsAlreadyexist(string ProjectID, string Projectname)
    {
        bool isavail = false;
        try
        {
            int ret = K2.AlreadyExistProjectNamebyIDandName(ProjectID, Projectname, clientId);
            if (ret > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "IsAlreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }

    public int AddData()
    {
        //get login client id after pass this proberties
        int ret = 0;
        int projectId = 0;
        try
        {
            K2.ClientID = Convert.ToInt32(clientId);
            K2.ProjectName = txtprojectname.Text;
            K2.ProjectLogo = "";
            K2.Location = txtlocation.Text;
            K2.Address = txtAddress.Text;
            K2.State = Convert.ToInt32(ddlstate.SelectedValue);
            K2.City = Convert.ToInt32(ddlcity.SelectedValue);
            K2.PostalCode = Convert.ToInt32(txtpostalcode.Text);
            K2.GoogleMapLink = "";
            K2.BlockCount = Convert.ToInt32(txtnoofblocks.Text);
            K2.FlatCount = Convert.ToInt32(txtflatsunits.Text);
            K2.LandArea = txtlandarea.Text;
            K2.RERANumber = txtreranumber.Text;
            K2.ProjectStatus = Convert.ToInt32(ddlProjectstatus.Text);
            K2.ProjectDisplayStatus = toggleActiveInactive.Checked;
            K2.ProjectStatusPercentage = Convert.ToInt32(txtProjectstatus.Text);
            K2.SplashScreenImage = "";
            K2.LocationMap = SaveFile(Fileuploadlocationmap, "GoogleMap", txtprojectname.Text);
            K2.BankName = txtBankname.Text;
            K2.AccountName = txtaccountname.Text;
            K2.AccountNumber = txtaccountnumber.Text;
            K2.IFSCNumber = txtifscnumber.Text;
            K2.BranchName = txtBranch.Text;
            K2.AddedBy = clientId;//it set default 
            K2.BHK = txtbhk.Text;
            K2.Latitude = txtlatitude.Text;
            K2.Longitude = txtlongitude.Text;
            K2.Sqft = txtsqft.Text;
            //ret = K2.AddPROJECTS(K2);
            projectId = K2.AddPROJECTS(K2);

            if (projectId > 0)
            {
                // Assign ProjectID to K2
                K2.ProjectID = projectId;

                // Call AddProjectHomeScreen
                K2.AddProjectHomeScreen(K2);

                ret = projectId; // Optionally return the ProjectID as the result
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "AddData", ex.Message, "Not Fixed");
        }
        return projectId;
    }

    public int UpdateData()
    {
        int ret = 0;
        //get login client id after pass this proberties
        try
        {
            K2.ProjectID = Convert.ToInt32(hdnID.Value);
            K2.ProjectLogo = "";
            K2.ClientID = Convert.ToInt32(clientId);//i set default
            K2.ProjectName = txtprojectname.Text;
            K2.Location = txtlocation.Text;
            K2.Address = txtAddress.Text;
            K2.State = Convert.ToInt32(ddlstate.SelectedValue);
            K2.City = Convert.ToInt32(ddlcity.SelectedValue);
            K2.PostalCode = Convert.ToInt32(txtpostalcode.Text);
            K2.GoogleMapLink = txtGooglemap.Text;
            K2.BlockCount = Convert.ToInt32(txtnoofblocks.Text);
            K2.FlatCount = Convert.ToInt32(txtflatsunits.Text);
            K2.LandArea = txtlandarea.Text;
            K2.RERANumber = txtreranumber.Text;
            K2.ProjectStatus = Convert.ToInt32(ddlProjectstatus.Text);
            K2.ProjectDisplayStatus = toggleActiveInactive.Checked;
            K2.ProjectStatusPercentage = Convert.ToInt32(txtProjectstatus.Text);
            if (FluploadProjectScreen.HasFile)
            {
                K2.SplashScreenImage = "";
            }
            else
            {
                // K2.SplashScreenImage = hdnprojectscreen.Value;
                K2.SplashScreenImage = "";
            }
            if (Fileuploadlocationmap.HasFile)
            {
                K2.LocationMap = SaveFile(Fileuploadlocationmap, "GoogleMap", txtprojectname.Text);
                DataTable dt = K2.ViewAllProjectsByid(Convert.ToInt32(hdnID.Value));
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["LocationMap"])))
                    {
                        string strMap = Convert.ToString(dt.Rows[0]["LocationMap"]);
                        FileDelete(strMap, "GoogleMap");
                    }
                }
            }
            else
            {
                K2.LocationMap = hdnuploadlocationmap.Value;
            }
            K2.BHK = txtbhk.Text;
            K2.Sqft = txtsqft.Text;
            K2.BankName = txtBankname.Text;
            K2.AccountName = txtaccountname.Text;
            K2.AccountNumber = txtaccountnumber.Text;
            K2.IFSCNumber = txtifscnumber.Text;
            K2.BranchName = txtBranch.Text;
            K2.Latitude = txtlatitude.Text;
            K2.Longitude = txtlongitude.Text;
            K2.UpdatedBy = clientId;//i set default 
            ret = K2.UpdatePROJECTS(K2);
            if (ret > 0)
            {
                K2.ProjectID = Convert.ToInt32(hdnID.Value);
                ret += K2.UpdateProjectHomeScreen(K2);
            }

        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "UpdateData", ex.Message, "Not Fixed");
        }
        return ret;
    }

    public void FileDelete(string ImageName, string appkey)
    {
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
                CI.StoreExceptionMessage("add-project.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
    }

    public string SaveFile(FileUpload uploadedFile, string appkey, string Projectname)
    {
        int savefile = 0;
        string filename = string.Empty;
        try
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
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "SaveFile", ex.Message, "Not Fixed");
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
    }

    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

    [System.Web.Services.WebMethod]
    public static bool CheckProjectExistence(string ProjectID, string projectName)
    {
        ClientDashboardError CI = new ClientDashboardError();
        Key2hProject K2 = new Key2hProject();
        ClientUsers CU = new ClientUsers();
        bool exists = false;
        try
        {
            int ret = K2.AlreadyExistProjectNamebyIDandName(ProjectID, projectName, clientId);
            if (ret > 0)
            {
                exists = true;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-project.aspx", "CheckProjectExistence", ex.Message, "Not Fixed");
        }
        return exists;
    }
}