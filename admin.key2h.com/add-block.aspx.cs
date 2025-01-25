using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adminkeyhcomaddblock : System.Web.UI.Page
{

    Key2hProject k2 = new Key2hProject();
    Key2hProjectblock K2b = new Key2hProjectblock();
    ClientUsers CU = new ClientUsers();
    ClientDashboardError CE = new ClientDashboardError();
    public static string Userid;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string clientLoginId = CU.GetClientLoginID();
            if (!string.IsNullOrEmpty(clientLoginId) && clientLoginId.Contains("clientid="))
            {
                Userid = clientLoginId.Replace("clientid=", "");
            }
            else
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                Bindprojects();
                if (Request.QueryString["BlockID"] != null)
                {
                    lbldisplaytext.Text = "Edit Block";
                    btnSave.Text = "Update";
                    Bind(Convert.ToString(Request.QueryString["BlockID"]));
                    ddlprojects.Attributes.Add("disabled", "true");
                }
                else
                {
                    btnSave.Text = "Submit";
                    lbldisplaytext.Text = "Add Block";
                    ddlprojects.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "btnsubmit", ex.Message, "Not Fixed");
        }
    }

    public void Bind(string id)
    {
        try
        {
            DataTable DT = K2b.ViewAllBlock(id, "", "");
            if (DT.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DT.Rows[0]["ProjectID"])))
                {
                    ddlprojects.SelectedValue = Convert.ToString(DT.Rows[0]["ProjectID"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(DT.Rows[0]["BlockName"])))
                {
                    txtBlockNumber.Text = Convert.ToString(DT.Rows[0]["BlockName"]);
                }
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "bind", ex.Message, "Not Fixed");
        }
    }

    public void Bindprojects()
    {
        try
        {
            DataTable dt = k2.ViewActiveprojects();
            if (dt.Rows.Count > 0)
            {
                ddlprojects.DataSource = dt;
                ddlprojects.DataTextField = "ProjectName";
                ddlprojects.DataValueField = "ProjectID";
                ddlprojects.DataBind();
                ddlprojects.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Labelerror = string.Empty;
            if (string.IsNullOrEmpty(ddlprojects.SelectedValue) && string.IsNullOrEmpty(txtBlockNumber.Text))
            {
                Labelerror = "Fill all the field";
            }
            else if (string.IsNullOrEmpty(ddlprojects.SelectedValue))
            {
                Labelerror = "Select project";
            }
            else if (string.IsNullOrEmpty(txtBlockNumber.Text))
            {
                Labelerror = "Enter blocknumber";
            }
            if (string.IsNullOrEmpty(Labelerror))
            {
                if (Request.QueryString["BlockID"] == null)
                {
                    if (!Isalreadyexist(ddlprojects.SelectedValue, txtBlockNumber.Text))
                    {
                        int currentBlockCount = K2b.BlockCountGetByPIDandABy(ddlprojects.SelectedValue, Userid);
                        int maxAllowedBlockCount = k2.ProjectBlockCountGetByPIDandAby(ddlprojects.SelectedValue, Userid);

                        // Compare the values
                        if (currentBlockCount < maxAllowedBlockCount)
                        {
                            if (Addblock() == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                  "Swal.fire({ " +
                                    "  title: 'Block details added successfully', " +
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
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                    "Swal.fire({ " +
                                    "  title: 'Block details couldn't be added due to a server or network issue. Please try again in some time!', " +
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
                           "Swal.fire({ " +
                               "  title: 'Can\\'t exceed more than " + maxAllowedBlockCount + " block', " +
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
                             "Swal.fire({ " +
                              "  title: 'The block details you’re trying to add already exists', " +
                              "  confirmButtonText: 'OK', " +
                               "  customClass: { " +
                                "      confirmButton: 'handle-btn-success', " +
                                "  }" +
                              "});", true);
                    }
                }
                else
                {
                    if (Updateblock() == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire({ " +
                        "    title: 'Block details updated successfully', " +
                        "    icon: 'success', " +
                        "    allowOutsideClick: 'true', " +
                        "    customClass: { " +
                        "        confirmButton: 'handle-btn-success', " +
                        "        icon: 'handle-icon-clr' " +
                        "    } " +
                        "}).then((result) => { " +
                        "        window.location.href = 'view-block.aspx'; " +
                        "});",
                        true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire({ " +
                                "  title: 'Block details couldn't be updated due to a server or network issue. Please try again in some time!', " +
                               "  confirmButtonText: 'OK', " +
                               "  customClass: { " +
                                "      confirmButton: 'handle-btn-success', " +
                                "  }" +
                                "});", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ " +
                                "  title: '" + Labelerror + "', " +
                               "  confirmButtonText: 'OK', " +
                               "  customClass: { " +
                                "      confirmButton: 'handle-btn-success', " +
                                "  }" +
                                "});", true);
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "btnclick", ex.Message, "Not Fixed");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["BlockID"] == null)
        {
            //Your action has been canceled. 
        }
        else
        {
            string currentPath = Request.Url.AbsolutePath;
            Response.Redirect(currentPath);
        }
    }

    public bool Isalreadyexist(string PID, string Bname)
    {
        bool isavail = false;
        try
        {
            string strbname = string.Empty;
            DataTable dt = K2b.BlockAlreadyExistByProjectid(Convert.ToInt32(PID), Bname);
            if (dt.Rows.Count > 0)
            {
                isavail = true;
            }
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }

    public int Addblock()
    {
        int ret = 0;
        try
        {
            K2b.ProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
            K2b.Blocknumber = txtBlockNumber.Text;
            K2b.Addedby = Userid;
           
            ret = K2b.Addblocks(K2b);
        }
        catch (Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "Addblock", ex.Message, "Not Fixed");
        }
        return ret;
    }

    public int Updateblock()
    {
        int ret = 0;
        try
        {
            K2b.BlcokID = Convert.ToInt32(Request.QueryString["BlockID"]);
            K2b.ProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
            K2b.Blocknumber = txtBlockNumber.Text;
            K2b.Addedby = Userid;           
            ret = K2b.Updateblock(K2b);
        }
        catch(Exception ex)
        {
            CE.StoreExceptionMessage("add-block.aspx", "Updateblock", ex.Message, "Not Fixed");
        }
        return ret;
    }

    public void Clear()
    {
        ddlprojects.SelectedIndex = 0;
        txtBlockNumber.Text = "";
    }
}