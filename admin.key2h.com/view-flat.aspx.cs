using System; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Data;
using System.Linq;
using System.Collections.Generic;
 
public partial class adminkey2hcom_flat : System.Web.UI.Page
{
    Key2hFlat KF = new Key2hFlat();
    Key2hProjectblock KB = new Key2hProjectblock();
    DataTable dt1 = new DataTable();
    DataRow dr1;

    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers(); 
    Key2hProject K2 = new Key2hProject();
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
            try
            {
                DataTable dt = K2.ViewActiveprojects();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddlprojects.DataSource = dt;
                    ddlprojects.DataTextField = "ProjectName";
                    ddlprojects.DataValueField = "ProjectID";
                    ddlprojects.DataBind();
                    ddlprojects.Items.Insert(0, new ListItem("All", "")); 
                }
                else
                {
                    ddlprojects.Items.Insert(0, new ListItem("All", ""));
                    ddlprojects.Items.Insert(2, new ListItem("No projects", ""));
                }
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-flat.aspx", "Page_Load", ex.Message, "Not Fixed");
            }
            Bind(0);
            Bindblock();
        }
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
            CI.StoreExceptionMessage("view-flat.aspx", "Bindcity", ex.Message, "Not Fixed");
        }
        return city;
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
            CI.StoreExceptionMessage("view-flat.aspx", "Bindproject", ex.Message, "Not Fixed");
        }
        return Project;
    }    
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojects.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojects.SelectedValue));
                if (DT.Rows.Count > 0)
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
                    ddlBlockName.Items.Insert(0, new ListItem("No block name", ""));
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
            CI.StoreExceptionMessage("view-flat.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
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
            CI.StoreExceptionMessage("view-flat.aspx", "BindBlockname", ex.Message, "Not Fixed");
        }
        return Block;
    }
    public void Bind(int pageIndex)
    {
        try {   
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
                Session["Flat"] = dt.DefaultView;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block");
                PopulatePager(totalRecords, pageIndex + 1, pageSize); 
            }
            else
            {
                Session["Flat"] = null;
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block !important");
                h5TotalNoCount.Style.Add("display", "none"); 
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }    
    public DataTable Get()
    { 
        DataTable dt = new DataTable();
        try
        {
            string projectid = string.Empty;
            string prostatus = string.Empty;
            string BlockID = string.Empty; 
            string status = string.Empty; 
            if (!string.Equals(ddlprojects.SelectedValue, "All"))
            {
                projectid = ddlprojects.SelectedValue;
            } 
            if (!string.Equals(ddlBlockName.SelectedValue, "All"))
            {
                BlockID = ddlBlockName.SelectedValue;
            } 

            dt = KF.ViewAllBflat(BlockID, status, prostatus, projectid);
            DataView dv = new DataView();
            dv = dt.DefaultView;
            string filterExpression = string.Empty;
            List<string> filterList = new List<string>();
            string strclientID = clientId;
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
            CI.StoreExceptionMessage("view-flat.aspx", "Get", ex.Message, "Not Fixed");
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
                Response.Redirect("add-flat.aspx?FlatID=" + ID, false);
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
                int ret = 0; 
                ret = KF.DeleteFlatbyflatID(ID);
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                       "Swal.fire({ " +
                       "  title: 'Flat has been deleted ', " +
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
        //   ddlprojects.SelectedIndex = 0;
        //  ddlprojectstatus.SelectedIndex = 0;
        ddlprojects.SelectedIndex = 0 ;
        Bindblock();
        Bind(0);
    }
    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
        Bindblock();
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
            LoanTable = ((DataView)Session["Flat"]);
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
            LoanTable = ((DataView)Session["Flat"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = LoanTable.ToTable();
                dt1.Columns.Add("Sno");
                dt1.Columns.Add("Project Name");
                dt1.Columns.Add("Block no.");
                dt1.Columns.Add("Flat no. / Unit no.");
                dt1.Columns.Add("Facing");
                dt1.Columns.Add("UDS");
                // dt1.Columns.Add("Display Status");
                dt1.Columns.Add("No. of Flats / Units");
                dt1.Columns.Add("Added on");
                 
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                { 
                    dr1 = dt1.NewRow();
                    string sno = (i + 1).ToString();
                    dr1["Sno"] = sno;
                    dr1["Project Name"] = Bindproject(Convert.ToInt32(dt.Rows[i]["ProjectID"]));
                    dr1["Block no."] = BindBlockname(Convert.ToInt32(dt.Rows[i]["BlockID"]));
                    dr1["Flat no. / Unit no."] = dt.Rows[i]["FlatName"].ToString();

                    dr1["Facing"] = dt.Rows[i]["Facing"].ToString();
                    dr1["UDS"] = dt.Rows[i]["UDS"].ToString();


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
        Response.AddHeader("content-disposition", "attachment; filename=Flat_Details" + DateTime.Now.ToString("ddMMyyyy_hh:mm:ss") + ".xls");
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
    protected void ddlBlockName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }
}