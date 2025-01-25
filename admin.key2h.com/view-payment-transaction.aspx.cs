using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ViewPaymentTransaction : System.Web.UI.Page
{ 
    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProjectblock KB = new Key2hProjectblock();
    Key2hFlat KF = new Key2hFlat();
    Key2hProject K2 = new Key2hProject();
    Key2htransaction KT = new Key2htransaction();
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
            ddlBindProject();
            Bindblock();
            Bind(0); 
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
    public void ddlBindProject()
    {
        try
        {
            DataTable dt = K2.ViewAllProjects("All", "All", "All");
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlprojectname.DataSource = dt;
                ddlprojectname.DataTextField = "ProjectName";
                ddlprojectname.DataValueField = "ProjectID";
                ddlprojectname.DataBind();
                ddlprojectname.Items.Insert(0, new ListItem("All", "")); 
            }
            else
            {
                ddlprojectname.Items.Insert(0, new ListItem("All", ""));
                ddlprojectname.Items.Insert(2, new ListItem("No projects", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "ddlBindProject", ex.Message, "Not Fixed");
        }
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
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "Bindproject", ex.Message, "Not Fixed");
        }
        return Project;
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
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "BindBlockname", ex.Message, "Not Fixed");
        }
        return Block;
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
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "ViewFlatNameByFlatID", ex.Message, "Not Fixed");
        } 
        return Block;
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
                //Session["customer"] = dt.DefaultView;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                PopulatePager(totalRecords, pageIndex + 1, pageSize);
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block"); 
            }
            else
            {
                // Session["customer"] = null;
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block !important");
                h5TotalNoCount.Style.Add("display", "none"); 
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    public DataTable Get()
    {
        DataTable dt = new DataTable();
        try
        {
            string projectid = string.Empty;
            string blockID = string.Empty;
            string FlatID = string.Empty; 
            if (!string.Equals(ddlprojectname.SelectedValue, ""))
            {
                projectid = ddlprojectname.SelectedValue;
            }
            if (!string.Equals(ddflatNumber.SelectedValue, ""))
            {
                FlatID = ddflatNumber.SelectedValue;
            }
            if (!string.Equals(ddlblocknumber.SelectedValue, ""))
            {
                blockID = ddlblocknumber.SelectedValue;
            }
            dt = KT.ViewFilterFlatCustomerTransaction(projectid, blockID, FlatID, "");
            DataView dv = new DataView();
            dv = dt.DefaultView;
            string filterExpression = string.Empty;
            List<string> filterList = new List<string>();
            string strclientID = clientId;
            if (!string.IsNullOrEmpty(strclientID))
            {
                if (!string.IsNullOrEmpty(filterExpression)) filterExpression += " AND ";
                filterExpression += "PaymentUpdatedBy = '" + strclientID.Replace("'", "''") + "'";
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
        }
        return dt;
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    { 
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("LinkButton2");
            if (btnDelete != null)
            {
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btnDelete);
            } 
        }
        if (e.CommandName == "Edit")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-payment-transaction.aspx?TransactionID=" + ID, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-Payment-transaction.aspx", "Repeater1_ItemCommand Edit", ex.Message, "Not Fixed");
            }
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                int ret = 0;
                HiddenField hdn = (HiddenField)e.Item.FindControl("HiddenField2");
                if (hdn != null)
                {
                    DataTable dt=KT.ViewFilterFlatCustomerTransaction("","","",hdn.Value);
                    if(dt!=null && dt.Rows.Count > 0)
                    {
                        DeleteFile(Convert.ToString(dt.Rows[0]["ReceiptPDF"]),"TransactionReceipt");
                    }
                }
                ret = KT.DeleteFlatCustomerTransaction(ID); 
                if (ret > 1)
                {
                    ScriptManager.RegisterStartupScript(
                    UpdatePanel5,
                    UpdatePanel5.GetType(),
                    "alert",
                    "Swal.fire({ " +
                     "  title: 'Payment transaction details has been deleted ', " +
                      "  confirmButtonText: 'OK', " +
                     "  customClass: { " +
                      "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "}).then((result) => { " +
                    "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                    "});",
                     true
                     );
                    UpdatePanel5.Update(); 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                      "Swal.fire({ " +
                       "  title: 'Payment transaction details has been not deleted ', " +
                       "  confirmButtonText: 'OK', " +
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
                CI.StoreExceptionMessage("view-Payment-transaction.aspx", "Repeater1_ItemCommand Delete", ex.Message, "Not Fixed");
            }
        }
    }


    public void DeleteFile(string Filename,string appkey)
    {
        string filepath = System.Configuration.ConfigurationManager.AppSettings[appkey];
        string fullFilePath = Path.Combine(filepath, Filename);
        if (File.Exists(fullFilePath))
        {
            File.Delete(fullFilePath);
            //Console.WriteLine("File deleted successfully.");
        }
        else
        {
           // Console.WriteLine("File not found in the folder.");
        }
    }
     
    protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        Bind(0);
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlprojectname.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlprojectname.SelectedValue));

                if (DT != null && DT.Rows.Count > 0)
                {
                    ddlblocknumber.DataSource = DT;
                    ddlblocknumber.DataTextField = "BlockName";
                    ddlblocknumber.DataValueField = "BlockID";
                    ddlblocknumber.DataBind();
                    ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
                }
                else
                {
                    ddlblocknumber.Items.Clear();
                    ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
                    ddlblocknumber.Items.Insert(0, new ListItem("No block name", ""));
                }
            }
            else
            {
                ddlblocknumber.Items.Clear();
                ddlblocknumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlblocknumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        Bind(0);
    }
    public void BindFlat()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlblocknumber.SelectedValue))
            {
                DataTable DT = KF.ViewAllflatByBlockID(Convert.ToInt32(ddlblocknumber.SelectedValue));

                if (DT != null && DT.Rows.Count > 0)
                {
                    ddflatNumber.DataSource = DT;
                    ddflatNumber.DataTextField = "FlatName";
                    ddflatNumber.DataValueField = "FlatID";
                    ddflatNumber.DataBind();
                    ddflatNumber.Items.Insert(0, new ListItem("All", ""));

                }
                else
                {
                    ddflatNumber.Items.Clear();
                    ddflatNumber.Items.Insert(0, new ListItem("All", ""));
                    ddflatNumber.Items.Insert(1, new ListItem("No flat number", ""));
                }
            }
            else
            {
                ddflatNumber.Items.Clear();
                ddflatNumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-Payment-transaction.aspx", "BindFlat", ex.Message, "Not Fixed");
        }
    }
    protected void ddflatNumber_SelectedIndexChanged(object sender, EventArgs e)
    { 
        Bind(0);
    }
    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        Clear();
        Bind(0);
    }
    public void Clear()
    {
        ddlprojectname.SelectedIndex = 0;
        Bindblock();
        BindFlat(); 
    }
}