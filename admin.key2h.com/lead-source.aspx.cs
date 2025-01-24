using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminkey2hcomleadsource : System.Web.UI.Page
{
    Key2hProject K2 = new Key2hProject();
    ClientdashboardIssue CI = new ClientdashboardIssue();
    ClientUsers CU = new ClientUsers();
    Key2hProjectRM KF = new Key2hProjectRM();
    DataTable dt1 = new DataTable();
    DataRow dr1; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind(); 
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
            CI.Pagename = "lead-source.aspx";
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
            dt = KF.ViewAllLeadSources();
        }
        catch (Exception ex)
        {
            CI.Pagename = "lead-source.aspx";
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
                SetControlsInRepeater(Convert.ToString(e.CommandArgument));
                //PT.DeleteprductdetailsByID(Convert.ToString(e.CommandArgument));
            }
            catch (Exception ex)
            {
            }
        }
        if (e.CommandName == "Save")
        {
            try
            {
                foreach (RepeaterItem item in rpruser.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        TextBox txtLeadSourceName = item.FindControl("txtLeadSourceName") as TextBox;
                        LinkButton btnSave = item.FindControl("btnSave") as LinkButton;
                        LinkButton editButton = item.FindControl("Editbtn") as LinkButton;
                        HiddenField IdHiddenField = item.FindControl("HiddenField2") as HiddenField;
                        if (IdHiddenField != null)
                        {
                            string Id = IdHiddenField.Value;
                            if (Id == Convert.ToString(e.CommandArgument))
                            { 
                                if (txtLeadSourceName.ReadOnly == false)
                                {
                                    KF.LeadID = Convert.ToInt32(Id);
                                    KF.LeadSourceName = txtLeadSourceName.Text;
                                }
                                else
                                {
                                    KF.LeadID = Convert.ToInt32(Id);
                                    KF.LeadSourceName = "";
                                } 
                                int RET = 0;
                                RET = KF.UpdateLeadSourceName(KF); 
                                if (RET == 1)
                                {
                                    if (txtLeadSourceName != null)
                                    {
                                        txtLeadSourceName.ReadOnly = true;
                                        txtLeadSourceName.Focus();
                                    } 
                                    if (btnSave != null)
                                    {
                                        btnSave.Enabled = false;
                                        btnSave.Visible = false;
                                    }
                                    if (editButton != null)
                                    {
                                        editButton.Enabled = true;
                                        editButton.Visible = true;
                                    }
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "Swal.fire({ " +
                                        "  title: 'Lead source added successfully', " +
                                        "  icon: 'success', " +
                                        "  allowOutsideClick: 'true', " +
                                        "  customClass: { " +
                                        "    icon: 'handle-icon-clr', " +
                                        "    confirmButton: 'handle-btn-success' " +
                                        "  } " +
                                        "}).then((result) => { " +
                                        "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                                        "});", true);
                                    Bind(); 
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CI.Pagename = "lead-source.aspx";
                CI.MethodOrFunctionname = "Edit LeadSource Name";
                CI.ErrrMsg = ex.Message.ToString();
                CI.IssueStatus = "Not Fixed";
                CI.AddClientdashboardissues(CI);
            } 
            Bind();
        }
    }

    protected void SetControlsInRepeater(string targetId)
    {
        foreach (RepeaterItem item in rpruser.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                // Find the controls inside the repeater item
                LinkButton btnSave = item.FindControl("btnSave") as LinkButton;
                LinkButton editButton = item.FindControl("Editbtn") as LinkButton;
                TextBox txtLeadSourceName = item.FindControl("txtLeadSourceName") as TextBox;

                // Assuming you have a HiddenField containing the product ID
                HiddenField IdHiddenField = item.FindControl("HiddenField1") as HiddenField;
                if (IdHiddenField != null)
                {
                    string Id = IdHiddenField.Value;
                    if (Id == targetId)
                    { 
                        if (txtLeadSourceName != null)
                        {
                            if (txtLeadSourceName.Text != "-")
                            { 
                                txtLeadSourceName.ReadOnly = false;
                            }
                            else
                            {
                                if (txtLeadSourceName != null)
                                {
                                    txtLeadSourceName.ReadOnly = true;
                                }
                            }
                        }
                        if (btnSave != null)
                        {
                            btnSave.Enabled = true;
                            btnSave.Visible = true;
                            btnSave.Focus(); 
                        }
                        if (editButton != null)
                        {
                            editButton.Enabled = false;
                            editButton.Visible = false; 
                        } 
                    }
                    txtLeadSourceName.Focus(); 
                }
            }
        }
    }
     
    protected void btnSave_Click(object sender, EventArgs e)
    { 
        string labelerror = string.Empty; 
        if (string.IsNullOrEmpty(txtLeadSource.Text))
        {
            labelerror = "Enter all the fields";
        }
        else 
        {  
        }   
        if (string.IsNullOrEmpty(labelerror))
        {
            if(!Isalreadyexist(txtLeadSource.Text))
            {
                int ret = 0;
                ret = AddLeadSource();
                if (ret == 1)
                {
                    Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                        "  title: 'Lead Source added successfully', " +
                        "  icon: 'success', " +
                        "  allowOutsideClick: 'true', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "}).then((result) => { " +
                        "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                        "});", true);
                    Bind();
                }
            }
            else 
            {
                labelerror = "Lead source already exists";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "Swal.fire({ " +
                          "  title: 'The lead source you’re trying to add already exists', " +
                          "  confirmButtonText: 'OK', " +
                           "  customClass: { " +
                            "      confirmButton: 'handle-btn-success', " +
                            "  }" +
                    "});", true); 
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", 
            "Swal.fire({ title: 'Validation Alert', text: '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
        }
    }
    public bool Isalreadyexist(string LeadSourceName)
    {
        bool isavail = false;
        string strleadname = string.Empty;
        try
        {
            DataTable dt = KF.AlreadyExistsLeadSourceName(LeadSourceName); 
            if (dt.Rows.Count > 0)
            { 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (isavail != true)
                    {
                        if (Equals((Convert.ToString(dt.Rows[i]["LeadSourceName"])).Replace(" ", "").ToLower(), LeadSourceName.Replace(" ", "").ToLower()))
                        {
                            isavail = true;
                            break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CI.Pagename = "lead-source.aspx";
            CI.MethodOrFunctionname = "Isalreadyexist";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        }
        return isavail;
    }
     
    public int AddLeadSource()
    { 
        int ret = 0;
        try
        {
            KF.LeadSourceName = txtLeadSource.Text;
            KF.LeadSourceStatus = true;
            KF.AddedBy = Convert.ToString(CU.GetClientLoginID().Replace("clientid=", ""));
            KF.ClientID = Convert.ToInt32(CU.GetClientLoginID().Replace("clientid=", ""));
            ret = KF.AddLeadSource(KF);
        }
        catch (Exception ex)
        {
            CI.Pagename = "lead-source.aspx";
            CI.MethodOrFunctionname = "AddLeadSource";
            CI.ErrrMsg = ex.Message.ToString();
            CI.IssueStatus = "Not Fixed";
            CI.AddClientdashboardissues(CI);
        }
        return ret;
    }
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear(); 
    } 
    public void Clear()
    {  
        txtLeadSource.Text = "";   
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