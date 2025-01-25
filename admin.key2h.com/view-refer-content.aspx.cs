using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ViewReferContent : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    ClientDashboardError CI=new ClientDashboardError();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                }
                else
                {
                    ddlprojects.Items.Insert(0, new ListItem("", ""));
                    ddlprojects.Items.Insert(2, new ListItem("No Projects", ""));
                }
            }
            catch (Exception ex)
            {
            }
            Bind(0);
        }
    }

    public void Bind(int pageIndex)
    {
        try
        {
            if (pageIndex == 0)
                pageIndex = 1; 
            DataTable dt = Get();  
           
            if (dt.Rows.Count > 0)
            {
                int totalRecords = dt.Rows.Count;
                int pageSize = 10;
                int startRow = pageIndex * pageSize;
                rpruser.Visible = true;
                rpruser.DataSource = dt;
                Session["Projects"] = dt.DefaultView;
                rpruser.DataBind();
                PopulatePager(totalRecords, pageIndex + 1, pageSize);
                DivNoDataFound.Style.Add("display", "none"); 
            }
            else
            {
                Session["Projects"] = null;
                rpruser.Visible = false;
                DivNoDataFound.Style.Add("display", "block"); 
            }
        }
        catch (Exception ex)
        {
        }

    }
    public DataTable Get()
    {
        DataTable dt = new DataTable(); 
        string projectid = string.Empty;
        try
        {
            if (!string.Equals(ddlprojects.SelectedValue, "All"))
            {
                projectid = ddlprojects.SelectedValue;
            } 
            dt = K2.ViewAllReferScreencontent(projectid);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "ProjectName ASC";  
                dt = dv.ToTable(); 
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-refer-screen.aspx", "Get", ex.Message, "Not Fixed");
        } 
        return dt;
    } 
    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        Bind(0);
    } 
    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        //ddlprojects.SelectedValue = 0 ;
        //DataTable dt1 = K2.ViewAllProjectsByid(Convert.ToInt32(18));
        //if (dt1.Rows.Count > 0)
        //{ 
        //}
        Bind(0);
    }

    protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind(0);
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            try
            {
                 int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-refer-content.aspx?ID=" + ID, false);
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
                ret = K2.DeleteReferContentbyReferScreenID(ID);
                if (ret == 1)
                {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                 "Swal.fire({ " +
                 "  title: 'Refer content has been deleted as requested', " +
                 "  confirmButtonText: 'OK' " +
                 "  customClass: { " +
                "    confirmButton: 'handle-btn-success' " +
                "  } " +
                 "}).then((result) => { " +
                 "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                 "});", true);
                }
            }
            catch (Exception ex)
            {
            } 
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
            CI.StoreExceptionMessage("view-refer-content.aspx", "Bindproject", ex.Message, "Not Fixed");
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

}