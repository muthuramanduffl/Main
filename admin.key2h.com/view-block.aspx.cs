using System;
using System.Collections.Generic; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Data;
using System.Linq;

public partial class adminkey2hcom_ViewBlock : System.Web.UI.Page
{ 
    DataTable dt1 = new DataTable();
    DataRow dr1; 
    Key2hProjectblock K2b = new Key2hProjectblock();
    Key2hProject K2 = new Key2hProject();
    ClientDashboardError CI = new ClientDashboardError(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind(0); 
            Bindblock();
        }
    }
     
    public void Bindblock()
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
     
    public string Bindcity(int ID)
    {
        string city = string.Empty;
        DataTable dt = K2.ViewcityByCityid(ID);
        if (dt.Rows.Count > 0)
        {
            city = dt.Rows[0]["CityName"].ToString();
        } 
        return city;
    }
     
    public string BindState(int ID)
    {
        string city = string.Empty;
        DataTable dt = K2.ViewstateByID(ID);
        if (dt.Rows.Count > 0)
        {
            city = dt.Rows[0]["StateName"].ToString();
        } 
        return city;
    }
     
    public void Bind(int pageIndex)
    {
        if (pageIndex == 0)
            PageIndex = 1;
        DataTable dt = Get();
        int totalRecords = dt.Rows.Count;
        int pageSize = 10;
        int startRow = pageIndex * pageSize;
        if (dt.Rows.Count > 0)
        {
            rpruser.Visible = true;
            rpruser.DataSource = dt.AsEnumerable().Skip(startRow).Take(pageSize).CopyToDataTable();
            Session["Blocks"] = dt.DefaultView;
            lblcount.Text = "Total no.of Blocks :"+ Convert.ToString(dt.Rows.Count);
            rpruser.DataBind();
            PopulatePager(totalRecords, pageIndex + 1, pageSize);
            DivNoDataFound.Style.Add("display", "none"); 
        }
        else
        {
            Session["Blocks"] = null;
            rpruser.Visible = false;
            lblcount.Text = "";
            DivNoDataFound.Style.Add("display", "block");
        } 
    }
     
    public string Bindprojectname(int Prid)
    {
        string strname = string.Empty;
       DataTable dt=K2.ViewAllProjectsByid(Prid);
        if (dt.Rows.Count>0)
        {
          strname= Convert.ToString(dt.Rows[0]["ProjectName"]);
        } 
        return strname;
    }

    public DataTable Get()
    { 
        string projectid = string.Empty;
         string prostatus = string.Empty; 
         string status = string.Empty; 
         if (!string.Equals(ddlstatus.SelectedValue, "All"))
        {
            prostatus = ddlstatus.SelectedValue;
        }
         if (!string.Equals(ddlprojects.SelectedValue, ""))
        {
            projectid = ddlprojects.SelectedValue;
        } 
        DataTable dt = K2b.ViewAllBlock("", prostatus, projectid); 
        return dt;
    }
     

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-block.aspx?BlockID=" + ID, false);
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
                K2b.DeleteBlockbyID(ID); 
            }
            catch (Exception ex)
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                 "Swal.fire({ " +
                     "  title: 'Block has been deleted as requested', " +
                     "  confirmButtonText: 'OK', " +  
                     "  customClass: { " +
                     "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "}).then((result) => { " +
                     " window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                     "});", true);

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
        ddlstatus.SelectedIndex = 0;
        ddlprojects.SelectedIndex = 0; 
        Bind(0);
    }

    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
    }

    protected void ddldisplaystatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
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
            LoanTable = ((DataView)Session["Blocks"]);
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
            LoanTable = ((DataView)Session["Blocks"]);
            if (LoanTable != null && LoanTable.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = LoanTable.ToTable();
                dt1.Columns.Add("Sno");
                dt1.Columns.Add("Project Name");
                dt1.Columns.Add("Block Name");                
                dt1.Columns.Add("Added On"); 
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                { 
                    dr1 = dt1.NewRow();
                    string sno = (i + 1).ToString();
                    dr1["Sno"] = sno;
                    dr1["Project Name"] = Bindprojectname(Convert.ToInt32(dt.Rows[i]["ProjectID"])) ;
                    dr1["Block Name"] = dt.Rows[i]["BlockName"].ToString();                   
                    DateTime dtDate = Convert.ToDateTime(dt.Rows[i]["Addeddate"]);
                    dr1["Added On"] = dtDate.ToString("dd/MMM/yyyy");
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
        Response.AddHeader("content-disposition", "attachment; filename=Blockdetails" + DateTime.Now.ToString("ddMMyyyy_hh:mm:ss") + ".xls");
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