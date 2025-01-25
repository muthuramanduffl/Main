using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminkey2hcom_WhatsHappening : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    Key2hProjectSpecs KF = new Key2hProjectSpecs(); 
    ClientDashboardError CI= new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    DataTable dt1 = new DataTable();
    DataRow dr1; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            Bind();
        }
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
                rpruser.DataBind(); 
            }
            else
            {
                rpruser.Visible = false;
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-specifications.aspx", "Bind", ex.Message, "Not Fixed");
        }
    } 
    public string Bindprojectname(int Prid)
    {
        string strname = string.Empty;
        try
        {  
            DataTable dt = K2.ViewAllProjectsByid(Prid);
            if (dt.Rows.Count > 0)
            {
                strname = Convert.ToString(dt.Rows[0]["ProjectName"]);
            }
        }
        catch(Exception ex)
        {
            CI.StoreExceptionMessage("view-specifications.aspx", "Bindprojectname", ex.Message, "Not Fixed");
        }

        return strname;
    }

    public DataTable Get()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = KF.ViewProjectSpecifications();
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("view-specifications.aspx", "Get", ex.Message, "Not Fixed");
        }
        return dt;
    } 
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.CommandName == "Delete")
        {
            // try
            // {
                int ProjectID = Convert.ToInt32(e.CommandArgument); 
                KF.DeleteSpecificationsbyProjectID(ProjectID); 
            // }
            // catch (Exception ex)
            // {
            // }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                 "Swal.fire({ " +
                     "  title: 'Specifications content has been deleted as requested', " +
                     "  confirmButtonText: 'OK', " +  
                     "  customClass: { " +
                     "    confirmButton: 'handle-btn-success' " +
                     "  } " +
                     "}).then((result) => { " +
                     "    window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                     "});", true); 
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