using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ViewflatProgress : System.Web.UI.Page
{

    ClientDashboardError CI = new ClientDashboardError();
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
    Key2hFlatProgress KFP = new Key2hFlatProgress();
    Key2hFlat KF = new Key2hFlat();
    Key2hProjectblock KB = new Key2hProjectblock();
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
            Bindprojects();
            Bindblock();
            BindFlat();
            Bind(0);
        }
    }
    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt!=null && dt.Rows.Count > 0)
            {
                ddlprojects.DataSource = dt;
                ddlprojects.DataTextField = "ProjectName";
                ddlprojects.DataValueField = "ProjectID";
                ddlprojects.DataBind();
                ddlprojects.Items.Insert(0, new ListItem("All", ""));
                //ddlprojects.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("view-flat-progress.aspx", "Bindproject", ex.Message, "Not Fixed");
        }
        return Project;
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
            CI.StoreExceptionMessage("view-flat-progress.aspx", "ViewFlatNameByFlatID", ex.Message, "Not Fixed");
        }

        return Block;
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
            CI.StoreExceptionMessage("view-flat-progress.aspx", "BindBlockname", ex.Message, "Not Fixed");
        }

        return Block;
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
                rpruser.DataBind();
                PopulatePager(totalRecords, pageIndex + 1, pageSize);
                lblcount.Text = "Total no. of Count : " + Convert.ToString(dt.Rows.Count);
                rptPager.Visible = true;
                DivNoDataFound.Style.Add("display", "none");
            }
            else
            {

                rpruser.Visible = false;
                rptPager.Visible = false;
                DivNoDataFound.Style.Add("display", "block");
                lblcount.Text = "";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "Bind", ex.Message, "Not Fixed");

        }
        UpdatePanel5.Update();
        UpdatePanel4.Update();
    }
    public DataTable Get()
    {
        DataTable dt = new DataTable();

        string projectid = string.Empty;
        string Flatid = string.Empty;
        string Blockid = string.Empty;
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
            if (!string.Equals(ddlBlockName.SelectedValue, "All"))
            {
                Blockid = ddlBlockName.SelectedValue;
            }


            if (!string.Equals(ddlFlatNumber.SelectedValue, "All"))
            {
                Flatid = ddlFlatNumber.SelectedValue;
            }

            if (!string.Equals(ddlyear.SelectedValue, "All"))
            {
                year = ddlyear.SelectedValue;
            }
            dt = KFP.ViewAllFlatProgress(year, month, projectid, Blockid, Flatid, "");
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
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "Get", ex.Message, "Not Fixed");
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
                Response.Redirect("add-flat-progress.aspx?FlatProgressID=" + ID, false);
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
                DataTable dt = KFP.ViewAllFlatProgress("", "", "", "", "", Convert.ToString(ID));
                if (dt != null && dt.Rows.Count > 0)
                {

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FlatProgressThumbnailimage"])))
                    {
                        string strlogo = Convert.ToString(dt.Rows[0]["FlatProgressThumbnailimage"]);
                        FileDelete(strlogo, "FlatProgressThumbnailimage");
                    }
                }

                DataTable dt1 = KFP.ViewFlatprojectID(ID);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dt1.Rows[i]["ImageName"])))
                        {
                            string imagename = Convert.ToString(dt1.Rows[i]["ImageName"]);
                            FileDelete(imagename, "FlatProgressimage");
                        }
                    }
                }



                if (KFP.DeleteFlatProgressByProgressID(ID) >= 0)
                {
                    ScriptManager.RegisterStartupScript(
                      UpdatePanel5,
                      UpdatePanel5.GetType(),
                      "alert",
                      "Swal.fire({ " +
                      "  title: 'Payment transaction details have been deleted', " +
                      "  confirmButtonText: 'OK', " +
                      "  customClass: { " +
                      "    confirmButton: 'handle-btn-success' " +
                      "  } " +
                      "});",
                       true
                       );
                    UpdatePanel5.Update();
                }
                else
                {
                   


                    ScriptManager.RegisterStartupScript(
                    UpdatePanel5,
                    UpdatePanel5.GetType(),
                    "alert",
                    "Swal.fire({ " +
                     "  title: 'The record could not be deleted. Please try again.', " +
                      "  confirmButtonText: 'OK', " +
                     "  customClass: { " +
                      "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "}).then((result) => { " +
                      "  if (result.isConfirmed) { " +
                    "    window.location = 'view-flat-progress.aspx'; " +
                    "  } " +
                    "});",
                     true
                     );
                    UpdatePanel5.Update();
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

        Bind(0);
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
                CI.StoreExceptionMessage("view-flat-progress.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
    }
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        BindFlat();
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
    protected void ddlBlockName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        Bind(0);
    }
    protected void ddlFlatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }
    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        ddlprojects.SelectedIndex = 0;
        Bindblock();
        BindFlat();
        ddlyear.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        Bind(0);
        UpdatePanel5.Update();
        UpdatePanel4.Update();
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojects.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojects.SelectedValue));
                if (DT!=null && DT.Rows.Count > 0)
                {
                    ddlBlockName.DataSource = DT;
                    ddlBlockName.DataTextField = "BlockName";
                    ddlBlockName.DataValueField = "BlockID";
                    ddlBlockName.DataBind();
                    ddlBlockName.Items.Insert(0, new ListItem("All", ""));
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
                ddlBlockName.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlBlockName.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlBlockName.SelectedValue));
                if (DT!=null && DT.Rows.Count > 0)
                {
                    ddlFlatNumber.DataSource = DT;
                    ddlFlatNumber.DataTextField = "FlatName";
                    ddlFlatNumber.DataValueField = "FlatID";
                    ddlFlatNumber.DataBind();
                    ddlFlatNumber.Items.Insert(0, new ListItem("All", ""));

                }
                else
                {
                    ddlFlatNumber.Items.Clear();
                    ddlFlatNumber.Items.Insert(0, new ListItem("All", ""));
                    ddlFlatNumber.Items.Insert(1, new ListItem("No Flat number", ""));
                }
            }
            else
            {
                ddlFlatNumber.Items.Clear();
                ddlFlatNumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            KFP.intFlatProgressID = Convert.ToInt32(hdnProgressID.Value);
            KFP.strThumbnailimage = SaveFileorg(FileUpload1, "FlatProgressThumbnailimage");
            KFP.strUpdatedBy = clientId;
            KFP.Updateflatprogress(KFP);
            Bind(0);
            ScriptManager.RegisterStartupScript(
             UpdatePanel9,
             UpdatePanel9.GetType(),
             "alert",
             "Swal.fire({ " +
             "  title: 'Thumbnail image updated successfully!', " +
             "  confirmButtonText: 'OK', " +
             "  customClass: { " +
             "    confirmButton: 'handle-btn-success' " +
             "  } " +
             "}).then((result) => { " +
             "  if (result.isConfirmed) { " +
             "    Swal.close(); " + "  } " +
             "});",
             true
             );
            UpdatePanel9.Update();
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-progress.aspx", "btnUpload_Click", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("view-flat-progress.aspx", "SaveFileorg", ex.Message, "Not Fixed");
        }
        return filename.Contains(" ") ? filename.Replace(" ", "") : filename;
    }


}