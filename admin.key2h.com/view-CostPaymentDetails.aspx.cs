
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_CostPaymentDetails : System.Web.UI.Page
{
    Key2hLeadSource LS = new Key2hLeadSource();

    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProjectblock KB = new Key2hProjectblock();

    Key2hFlat KF = new Key2hFlat();
    Key2hProject K2 = new Key2hProject();
    Key2hCustomer KC = new Key2hCustomer();
    Key2hAllFilesNew KFN = new Key2hAllFilesNew();
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
            Bind();
        }
    }
    public void ddlBindProject()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlprojectname.Items.Clear();
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "ddlBindProject", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Bindproject", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "BindBlockname", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "ViewFlatNameByFlatID", ex.Message, "Not Fixed");
        }
        return Block;
    }
    public void Bind()
    {
        try
        {
            DataTable dt = Get();
            if (dt != null && dt.Rows.Count > 0)
            {
                rpruser.Visible = true;
                rpruser.DataSource = dt;
                Session["customer"] = dt.DefaultView;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block");
            }
            else
            {
                Session["customer"] = null;
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block !important");
                h5TotalNoCount.Style.Add("display", "none");
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Bind", ex.Message, "Not Fixed");
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
            string strsearch = string.Empty;
            string status = string.Empty;
            if (!string.Equals(ddlprojectname.SelectedValue, ""))
            {
                projectid = ddlprojectname.SelectedValue;
            }
            if (!string.Equals(ddlflatNumber.SelectedValue, ""))
            {
                FlatID = ddlflatNumber.SelectedValue;
            }
            if (!string.Equals(ddlblocknumber.SelectedValue, ""))
            {
                blockID = ddlblocknumber.SelectedValue;
            }
            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                strsearch = txtsearch.Text;
            }
            dt = KFN.ViewAllCostpaymentdetails(projectid, blockID, FlatID, strsearch, clientId);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Get", ex.Message, "Not Fixed");
        }
        return dt;
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "btnUpdateCost")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-cost-details.aspx?FlatID=" + ID, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Edit repeater", ex.Message, "Not Fixed");
            }
        }
        if (e.CommandName == "UpdateShedule")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-payment-schedule.aspx?FlatID=" + ID, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Edit repeater", ex.Message, "Not Fixed");
            }
        }
        if (e.CommandName == "UpdateDemand")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-demand.aspx?FlatID=" + ID , false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Edit repeater", ex.Message, "Not Fixed");
            }
        }
        if (e.CommandName == "UpdateUpdateTransaction")
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("add-payment-transaction.aspx?FlatID=" + ID , false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Edit repeater", ex.Message, "Not Fixed");
            }
        }
    }
    protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
        Bind();
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
                    ddlblocknumber.Items.Clear();
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
                    ddlblocknumber.Items.Insert(0, new ListItem("No Block name", ""));
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlblocknumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFlat();
        Bind();
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
                    ddlflatNumber.Items.Clear();
                    ddlflatNumber.DataSource = DT;
                    ddlflatNumber.DataTextField = "FlatName";
                    ddlflatNumber.DataValueField = "FlatID";
                    ddlflatNumber.DataBind();
                    ddlflatNumber.Items.Insert(0, new ListItem("All", ""));
                }
                else
                {
                    ddlflatNumber.Items.Clear();
                    ddlflatNumber.Items.Insert(0, new ListItem("All", ""));
                    ddlflatNumber.Items.Insert(0, new ListItem("No flat number", ""));
                }
            }
            else
            {
                ddlflatNumber.Items.Clear();
                ddlflatNumber.Items.Insert(0, new ListItem("All", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-flat-booking.aspx", "ddlblocknumber_SelectedIndexChanged", ex.Message, "Not Fixed");
        }
    }
    protected void ddflatNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }
    protected void lnkbtngo_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void lnkcancel_Click(object sender, EventArgs e)
    {
        Clear();
        Bind();
    }
    public string leadSourcename(int ID)
    {
        string strlread = string.Empty;

        DataTable dt = LS.ViewAllLeadsourceByLeadID(ID);
        if (dt != null && dt.Rows.Count > 0)
        {
            strlread = dt.Rows[0]["LeadSourceName"].ToString();
        }
        return strlread;
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
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "Bindcity", ex.Message, "Not Fixed");
        }
        return city;
    }
    public string BindState(int ID)
    {
        string city = string.Empty;
        try
        {
            DataTable dt = K2.ViewstateByID(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                city = dt.Rows[0]["StateName"].ToString();
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-CostPaymentDetails.aspx", "BindState", ex.Message, "Not Fixed");
        }
        return city;
    }
    public void Clear()
    {
        txtsearch.Text = "";
        ddlprojectname.SelectedIndex = 0;    
        Bindblock();
        BindFlat();
    }
}