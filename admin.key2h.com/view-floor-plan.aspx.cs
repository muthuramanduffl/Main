using System; 
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class adminkey2hcom_ViewRM : System.Web.UI.Page
{
    Key2hFloorPlan KF = new Key2hFloorPlan();
    ClientdashboardIssue CI = new ClientdashboardIssue();
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
    DataTable dt1 = new DataTable();
    DataRow dr1; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind(); 
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
    public void Bind()
    {
        try
        {
            DataTable dt = Get();
            if (dt != null && dt.Rows.Count > 0)
            {
                rpruser.Visible = true;
                rpruser.DataSource = dt;
                lblcount.Text = Convert.ToString(dt.Rows.Count);
                rpruser.DataBind();
                DivNoDataFound.Style.Add("display", "none");
                h5TotalNoCount.Style.Add("display", "block"); 
            }
            else
            {
                rpruser.Visible = false;
                lblcount.Text = "0";
                DivNoDataFound.Style.Add("display", "block !important");
                h5TotalNoCount.Style.Add("display", "none");

            }
        }
        catch (Exception ex)
        {
            CI.Pagename = "view-floor-plan.aspx";
            CI.MethodOrFunctionname = "Bind";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        } 
    } 
    public DataTable Get()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = KF.ViewAllProjectFloorPlans();
        }
        catch (Exception ex)
        {
            CI.Pagename = "view-floor-plan.aspx";
            CI.MethodOrFunctionname = "Get";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
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
                Response.Redirect("add-floor-plan.aspx?ProjectID=" + ID, false);
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
                ret = KF.DeleteProjectFloorPlanbyProjectID(ID);
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                       "Swal.fire({ " +
                       "  title: 'Floor plan details has been deleted as requested ', " +
                       "  confirmButtonText: 'OK' " +
                       "  customClass: { " +
                       "    confirmButton: 'handle-btn-success' " +"  } " +
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

    protected string GetRowNo(string itemIndex)
    {
        return PageIndex > 1 ? (((PageIndex - 1) * 10) + Convert.ToInt32(itemIndex)).ToString() : itemIndex;
    }
    public int PageIndex
    {
        get { return ViewState["PageIndex"] != null ? (int)ViewState["PageIndex"] : 1; }
        set { ViewState["PageIndex"] = value; }
    }
       
}