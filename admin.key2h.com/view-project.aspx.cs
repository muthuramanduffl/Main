using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;

public partial class adminkey2hcom_ViewProjects : System.Web.UI.Page
{
    DataTable dt1 = new DataTable();
    DataRow dr1;
    ClientDashboardError CI = new ClientDashboardError();
    Key2hProject K2 = new Key2hProject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProjects();
            Bind(0);
        }
    }



    public void BindProjects()
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
                //ddlprojects.SelectedValue = "18";
                //DataTable dt1 = K2.ViewAllProjectsByid(Convert.ToInt32(18));
                //if (dt1.Rows.Count > 0)
                //{
                //    if (!string.IsNullOrEmpty(Convert.ToString(dt1.Rows[0]["ProjectStatus"])))
                //    {
                //        ddlprojectstatus.SelectedValue = Convert.ToString(dt1.Rows[0]["ProjectStatus"]);
                //    }
                //}
            }
            else
            {
                ddlprojects.Items.Insert(0, new ListItem("", ""));
                ddlprojects.Items.Insert(2, new ListItem("No Projects", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "pageload", ex.Message, "Not Fixed");
        }
    }

    public string Bindcity(int ID)
    {
        string city = string.Empty;
        try
        {
            DataTable dt = K2.ViewcityByCityid(ID);
            if (dt.Rows.Count > 0)
            {
                city = dt.Rows[0]["CityName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "Bindcity", ex.Message, "Not Fixed");
        }
        return city;
    }

    public string BindState(int ID)
    {
        string city = string.Empty;
        try
        {
            DataTable dt = K2.ViewstateByID(ID);
            if (dt.Rows.Count > 0)
            {
                city = dt.Rows[0]["StateName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "BindState", ex.Message, "Not Fixed");
        }
        return city;
    }

    public void Bind(int pageIndex)
    {
        try
        {
            if (pageIndex == 0)
                PageIndex = 1;
            DataTable dt = Get();
           
            if (dt!=null && dt.Rows.Count > 0)
            {
                int totalRecords = dt.Rows.Count;
                int pageSize = 10;
                int startRow = pageIndex * pageSize;
                rpruser.Visible = true;
                rpruser.DataSource = dt.AsEnumerable().Skip(startRow).Take(pageSize).CopyToDataTable();
                Session["Projects"] = dt.DefaultView;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                PopulatePager(totalRecords, pageIndex + 1, pageSize);
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block");
            }
            else
            {
                Session["Projects"] = null;
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block");
                h5TotalNoCount.Style.Add("display", "none");

            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }

    public DataTable Get()
    {
        DataTable dt = new DataTable();
        string projectid = string.Empty;
        string prostatus = string.Empty;
        string status = string.Empty;
        try
        {
            if (!string.Equals(ddlprojectstatus.SelectedValue, "All"))
            {
                prostatus = ddlprojectstatus.SelectedValue;
            }
            if (!string.Equals(ddlprojects.SelectedValue, "All"))
            {
                projectid = ddlprojects.SelectedValue;
            }
            dt = K2.ViewAllProjects(projectid, status, prostatus);
            
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-project.aspx", "Get", ex.Message, "Not Fixed");
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
                Response.Redirect("add-project.aspx?ProjectID=" + ID, false);
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
                DataTable dt = K2.ViewAllProjectsByid(ID);
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectLogo"])))
                    {
                        String strlogo = Convert.ToString(dt.Rows[0]["ProjectLogo"]);
                        FileDelete(strlogo, "Logo");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SplashScreenImage"])))
                    {
                        string strscreenimage = Convert.ToString(dt.Rows[0]["SplashScreenImage"]);
                        FileDelete(strscreenimage, "ProjectScreen");
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["LocationMap"])))
                    {
                        string strMap = Convert.ToString(dt.Rows[0]["LocationMap"]);
                        FileDelete(strMap, "GoogleMap");
                    }
                }
                K2.DeleteProjects(ID);
            }
            catch (Exception ex)
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
             "Swal.fire({ " +
             "  title: 'Project has been deleted as requested', " +
             "  confirmButtonText: 'OK' " +
             "  customClass: { " +
            "    confirmButton: 'handle-btn-success' " +
            "  } " +
             "}).then((result) => { " +
             "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
             "});", true);
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
                CI.StoreExceptionMessage("view-project.aspx", "FileDelete", e.Message, "Not Fixed");
            }
        }
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

    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        Bind(0);
    }

    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        ddlprojects.SelectedIndex = 0;
        //DataTable dt1 = K2.ViewAllProjectsByid(Convert.ToInt32(18));
        //if (dt1.Rows.Count > 0)
        //{
        //    if (!string.IsNullOrEmpty(Convert.ToString(dt1.Rows[0]["ProjectStatus"])))
        //    {
        //        ddlprojectstatus.SelectedValue = Convert.ToString(dt1.Rows[0]["ProjectStatus"]);
        //    }
        //}
        ddlprojectstatus.SelectedIndex = 0;
        Bind(0);
    }

    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
        ddlprojectstatus.SelectedIndex = 0;
    }

    protected void ddlprojectstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }

    protected void btnSubmitExport_Click(object sender, EventArgs e)
    {
        DataView LoanTable = new DataView();
        try
        {
            LoanTable = ((DataView)Session["ProjecTs"]);
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
            LoanTable = ((DataView)Session["Projects"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = LoanTable.ToTable();
                dt1.Columns.Add("Sno");
                dt1.Columns.Add("Project Name");
                dt1.Columns.Add("Location");
                dt1.Columns.Add("Address");
                dt1.Columns.Add("State");
                dt1.Columns.Add("City");
                dt1.Columns.Add("No. of Blocks");
                dt1.Columns.Add("No. of Flats / Units");
                dt1.Columns.Add("Added On");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr1 = dt1.NewRow();
                    string sno = (i + 1).ToString();
                    dr1["Sno"] = sno;
                    dr1["Project Name"] = dt.Rows[i]["ProjectName"].ToString();
                    dr1["Location"] = dt.Rows[i]["Location"].ToString();
                    dr1["Address"] = dt.Rows[i]["Address"].ToString();
                    dr1["State"] = BindState(Convert.ToInt32(dt.Rows[i]["State"]));
                    dr1["City"] = Bindcity(Convert.ToInt32(dt.Rows[i]["City"]));
                    dr1["No. of Blocks"] = dt.Rows[i]["BlockCount"].ToString();
                    dr1["No. of Flats / Units"] = dt.Rows[i]["FlatCount"].ToString();
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
        Response.AddHeader("content-disposition", "attachment; filename=ProjectsDetails" + DateTime.Now.ToString("ddMMyyyy_hh:mm:ss") + ".xls");
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

}