using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ViewProjectProgress : System.Web.UI.Page
{ 
    ClientDashboardError CI = new ClientDashboardError();
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
    Key2hProjectProgress KPP = new Key2hProjectProgress();
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
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            Bindprojects();
            Bind(0);
        }
    }

    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt.Rows.Count > 0)
            {
                ddlprojects.DataSource = dt;
                ddlprojects.DataTextField = "ProjectName";
                ddlprojects.DataValueField = "ProjectID";
                ddlprojects.DataBind();
                ddlprojects.Items.Insert(0, new ListItem("All", "")); 
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("View-project-Progress.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
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
        } 
        return Project;
    } 
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        PageIndex = pageIndex;
        this.Bind(pageIndex - 1);
        Session["SessionPageIndex"] = pageIndex;
    } 
    private void PopulatePager(int recordCount, int currentPage, int PageSize)
    {
        double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0 && pageCount > 1)
        {
            // pages.Add(new ListItem("<<", "1", currentPage > 1));
            if (currentPage != 1 && currentPage > 1)
            {
                pages.Add(new ListItem("Previous", (currentPage - 1).ToString()));
            }
            if (pageCount < 4)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else if (currentPage < 4)
            {
                for (int i = 1; i <= 4; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
            }
            else if (currentPage > pageCount - 4)
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
                for (int i = currentPage - 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }
            else
            {
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
                for (int i = currentPage - 2; i <= currentPage + 2; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("...", (currentPage).ToString(), true));
            }
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("next", (currentPage + 1).ToString()));
            }
            //pages.Add(new ListItem(">>", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
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

    public void Bind(int pageIndex)
    {
        try
        {
            if (pageIndex == 0)
                PageIndex = 1;
            DataTable dt = Get();

            if (dt != null && dt.Rows.Count > 0)
            {
                int totalRecords = dt.Rows.Count;
                int pageSize = 10;
                int startRow = pageIndex * pageSize;
                rpruser.Visible = true;
                rpruser.DataSource = dt.AsEnumerable().Skip(startRow).Take(pageSize).CopyToDataTable();
                Session["Projects"] = dt.DefaultView;
                rpruser.DataBind();
                PopulatePager(totalRecords, pageIndex + 1, pageSize);
                lblcount.Text = "Total no. of Count : " + Convert.ToString(dt.Rows.Count);
                rptPager.Visible = true;
                DivNoDataFound.Style.Add("display", "none");
            }
            else
            {
                Session["Projects"] = null;
                rpruser.Visible = false;
                rptPager.Visible = false;
                DivNoDataFound.Style.Add("display", "block");
                lblcount.Text = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "Bind", ex.Message, "Not Fixed");
        }
        UpdatePanel4.Update();
        UpdatePanel5.Update();
    }
    public DataTable Get()
    {
        DataTable dt = new DataTable(); 
        string projectid = string.Empty;
        string month = string.Empty;
        string year = string.Empty;  
        try
        {
            if (!string.Equals(ddlmonth.SelectedValue, "All"))
            {
                month = ddlmonth.SelectedValue;
            }
            if (!string.Equals(ddlprojects.SelectedValue, "All"))
            {
                projectid = ddlprojects.SelectedValue;
            } 
            if (!string.Equals(ddlyear.SelectedValue, "All"))
            {
                year = ddlyear.SelectedValue;
            } 
            dt = KPP.ViewAllProjectProgress(year, month, projectid);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project-progress.aspx", "Get", ex.Message, "Not Fixed");
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
                Response.Redirect("add-project-progress.aspx?ProgressID=" + ID, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
            }
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument); 
                DataTable dt = KPP.ViewProjectprogressByID(ID);
                if (dt != null && dt.Rows.Count > 0)
                { 
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ThumbnailImage"])))
                    {
                        string strlogo = Convert.ToString(dt.Rows[0]["ThumbnailImage"]);
                        FileDelete(strlogo, "ProjectProgressThumbnailimage");
                    } 
                }

                DataTable dt1= KPP.ViewProjectprogressImagesByID(ID);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dt1.Rows[i]["ImageName"])))
                        {
                            string imagename = Convert.ToString(dt1.Rows[i]["ImageName"]);
                            FileDelete(imagename, "ProgressImages");
                        }
                    }
                }

                if (KPP.DeleteProjectProgressByProgressID(ID) >0)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "alert",
 "Swal.fire({ " +
 "  title: 'Project progress details has been deleted', " +
 "  confirmButtonText: 'OK', " +
 "  customClass: { " +
 "    confirmButton: 'handle-btn-success' " +
 "  } " +
 "}).then((result) => { " +
 "    window.location.href = '" + Request.Url.AbsolutePath + "'; " +
 "});", true);
                    UpdatePanel5.Update();
                }
                else
                {               
                    ScriptManager.RegisterStartupScript(UpdatePanel5, UpdatePanel5.GetType(), "alert",
                   "Swal.fire({ " +
                   "  title: 'The record could not be deleted. Please try again.', " +
                   "  confirmButtonText: 'OK' " +
                   "  customClass: { " +
                   "    confirmButton: 'handle-btn-success' " +
                   "  } " +
                   "}).then((result) => { " +
                   "    window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                   "});", true);
                  
                }
            }
            catch (Exception ex)
            {
            } 
        }

        if (e.CommandName == "EditThumbnail")
        {
            try
            {
                string progressID = Convert.ToString(e.CommandArgument);
                hdnProgressID.Value = progressID;
                // Trigger modal to open using display block from code-behind
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", "openModal();", true);
            }
            catch (Exception ex)
            {
            }
        } 
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
                CI.StoreExceptionMessage("view-project-progress.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
    }
     
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }
     
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }

    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }
     
    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        ddlprojects.SelectedIndex = 0;
        ddlyear.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        Bind(0);
        UpdatePanel4.Update();
        UpdatePanel5.Update();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            KPP.intProgressID = Convert.ToInt32(hdnProgressID.Value);
            KPP.strThumbnailimage = SaveFileorg(FileUpload1, "ProjectProgressThumbnailimage");
            KPP.strUpdatedBy = clientId;
            KPP.Updateprojectprogress(KPP);
            Bind(0);
            ScriptManager.RegisterStartupScript(
             UpdatePanel9,
             UpdatePanel9.GetType(),
             "alert",
             "Swal.fire({ " +
             "  title: 'Thumbnail image for project progress has been successfully updated!', " +
             "  confirmButtonText: 'OK', " +
             "  customClass: { " +
             "    confirmButton: 'handle-btn-success' " +
             "  } " +
             "}).then((result) => { " +
             "  if (result.isConfirmed) { " +
             "    Swal.close(); " +     "  } " +
             "});",
             true
             );
            UpdatePanel9.Update();
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project-progress.aspx", "btnUpload_Click", ex.Message, "Not Fixed");
        }
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

    public string SaveFileorg(FileUpload uploadedFile, string appkey)
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
                filename = GenerateFileName(ddlprojects.SelectedValue.Trim(), fileExtension).Trim('-');
                string temppath = filepath.Trim() + @"\" + filename.Trim().Replace(" ", "");
                string savepath = Server.MapPath(temppath);
                uploadedFile.SaveAs(savepath);
                savefile = 1;
            }
            else
            {
                return filename = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project-progress.aspx", "SaveFileorg", ex.Message, "Not Fixed");
        }
        return filename.Contains(" ") ? filename.Replace(" ", "") : filename;
    }
}