using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ReferralList : System.Web.UI.Page
{

    Key2hRefer LS = new Key2hRefer();

    ClientDashboardError CI = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    Key2hProjectblock KB = new Key2hProjectblock();

    Key2hFlat KF = new Key2hFlat();
    Key2hProject K2 = new Key2hProject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlBindProject(); 
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
                ddlprojectname.DataSource = dt;
                ddlprojectname.DataTextField = "ProjectName";
                ddlprojectname.DataValueField = "ProjectID";
                ddlprojectname.DataBind();
                ddlprojectname.Items.Insert(0, new ListItem("All", ""));
                ddlprojectname.SelectedValue = "18";
            }
            else
            {
                ddlprojectname.Items.Insert(0, new ListItem("", ""));
                ddlprojectname.Items.Insert(2, new ListItem("No Projects", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("referral-list.aspx", "ddlBindProject", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("referral-list.aspx", "Bindproject", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("referral-list.aspx", "BindBlockname", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("referral-list.aspx", "ViewFlatNameByFlatID", ex.Message, "Not Fixed");
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
            CI.StoreExceptionMessage("referral-list.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }

    public DataTable Get()
    { 
        DataTable dt = new DataTable();
        try
        {
            string projectid = string.Empty;
            string strsearch = string.Empty;

            if (!string.Equals(ddlprojectname.SelectedValue, ""))
            {
                projectid = ddlprojectname.SelectedValue;
            } 
            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                strsearch = txtsearch.Text;
            }
            dt = LS.ViewAllReferralList(projectid, strsearch); 
            DataView dv = new DataView();
            dv = dt.DefaultView; 
            string filterExpression = string.Empty; 
            List<string> filterList = new List<string>(); 
            string strclientID = Convert.ToString(CU.GetClientLoginID().Replace("clientid=", "")); 
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
            CI.StoreExceptionMessage("referral-list.aspx", "Get", ex.Message, "Not Fixed");
        }
        return dt;
    } 
    protected void ddlprojectname_SelectedIndexChanged(object sender, EventArgs e)
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
    public void Clear()
    {
        txtsearch.Text = "";
        ddlprojectname.SelectedIndex = 0;   
    }


}