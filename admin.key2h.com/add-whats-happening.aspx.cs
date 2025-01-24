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
    Key2hWhatshappening KF = new Key2hWhatshappening();
    ClientdashboardIssue CI = new ClientdashboardIssue();
    ClientDashboardError CE = new ClientDashboardError();
    ClientUsers CU = new ClientUsers();
    DataTable dt1 = new DataTable();
    DataRow dr1; 
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            Bindprojects();
            if (Request.QueryString["WHID"] != null)
            {
                int value = 0;
                if (int.TryParse(Request.QueryString["WHID"], out value))
                {
                    lbldisplaymsg.Text = " Edit What's Happening";
                    btnSave.Text = "Update";
                    BindWhatshappening(Convert.ToInt32(Request.QueryString["WHID"]));
                    ddlProName.Attributes.Add("disabled", "true");
                }
                else
                {
                    string script = string.Format(@"<script> Swal.fire({{ title: ' URL is incorrect. please try again', 
                    confirmButtonText: 'OK', customClass: {{ confirmButton: 'handle-btn-success'  }}}}).then((result) => {{
                    window.location.href = 'add-whats-happening.aspx';}}); </script>");

                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false); 
                }
            }
            else
            {
                lbldisplaymsg.Text = " Add What's Happening";
                btnSave.Text = "Submit"; 
            } 
        }
        
      
    }

    public void Bindprojects()
    {
        try
        {
            DataTable dt = K2.ViewActiveprojects();
            if (dt.Rows.Count > 0)
            {
                ddlProName.DataSource = dt;
                ddlProName.DataTextField = "ProjectName";
                ddlProName.DataValueField = "ProjectID";
                ddlProName.DataBind();
                ddlProName.Items.Insert(0, new ListItem("", "")); 
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-refer-content.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }
     public void BindWhatshappening(int id)
    { 
        try
        {
            DataTable dt = KF.ViewAllWhatshappeningbyWHID(id);

            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectID"])))
                {
                    ddlProName.SelectedValue = Convert.ToString(dt.Rows[0]["ProjectID"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Content"])))
                {
                    txtContent.Text = Convert.ToString(dt.Rows[0]["Content"]);
                } 
            }
        }
        catch (Exception ex)
        {
            CI.Pagename = "add-whats-happening.aspx";
            CI.MethodOrFunctionname = "BindWhatshappening";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    { 
        string labelerror = string.Empty;
        if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(txtContent.Text))
        {
            labelerror = "Fill all the filed";
        }
        else if (string.IsNullOrEmpty(ddlProName.SelectedValue))
        {
            labelerror = "Select project name";
        } 
        else if (string.IsNullOrEmpty(txtContent.Text))
        {
            labelerror = "Enter content";
        } 
        if (string.IsNullOrEmpty(labelerror))
        {
            if (Request.QueryString["WHID"] == null)
            { 
                int ret = 1;
                ret = AddWhatshappening();
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                 "Swal.fire({ " +
                        "  title: 'Whats happening details added successfully', " +
                        "  icon: 'success', " +
                        "  allowOutsideClick: 'true', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "}).then((result) => { " + 
                        "  window.location.href = '" + Request.Url.AbsolutePath + "'; " + 
                        "});", true);
                } 
            }
            else
            {
                int ret = 0;
                ret = UpdateWhatshappening();
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                   "Swal.fire({ " +
                    "    title: 'Whats happening details updated successfully', " +
                    "    icon: 'success', " +
                    "    allowOutsideClick: 'true', " +
                    "    customClass: { " +
                    "        confirmButton: 'handle-btn-success', " +  
                    "        icon: 'handle-icon-clr' " + 
                    "    } " +
                    "}).then((result) => { " + 
                    "        window.location.href = 'view-whats-happening.aspx'; " + 
                    "});",
                    true);  
                }
            }
        }
        else
        {
            //alert labelerror
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                   "Swal.fire('Validation Alert', '" + labelerror + "!','', customClass: { confirmButton: 'handle-btn-success' } });", true);
        } 
    }

    public int AddWhatshappening()
    { 
        int ret = 0;
        try
        {
            KF.Content = txtContent.Text;
            KF.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KF.DisplayStatus = true;
            KF.AddedBy = Convert.ToString(CU.GetClientLoginID().Replace("clientid=", ""));
            ret = KF.AddWhatshappening(KF);
        }
        catch (Exception ex)
        {
            CI.Pagename = "whats-happening.aspx";
            CI.MethodOrFunctionname = "AddWhatshappening";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        }
        return ret;
    }

    public int UpdateWhatshappening()
    { 
        int ret = 0;
        try
        {
            KF.WHID = Convert.ToInt32(Request.QueryString["WHID"]);
            KF.Content = txtContent.Text;
            ret = KF.UpdateWhatshappening(KF);
        }
        catch (Exception ex)
        {
            CI.Pagename = "whats-happening.aspx";
            CI.MethodOrFunctionname = "UpdateWhatshappening";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        }
        return ret;
    }
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["WHID"] == null)
        { 
        }
        else
        {
            // Cancelled 
        }
    }
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }

}