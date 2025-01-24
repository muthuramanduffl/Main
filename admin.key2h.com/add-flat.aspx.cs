using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminkey2hcomaddflat : System.Web.UI.Page
{
    ClientDashboardError CI = new ClientDashboardError();
    Key2hFlat KF = new Key2hFlat();
    Key2hProjectblock KB = new Key2hProjectblock();
    Key2hProject K2 = new Key2hProject();
    ClientUsers CU = new ClientUsers();
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
            clientId = clientLoginId;
        }

        if (!IsPostBack)
        {
            Bindprojects();
            Bindblock();
            BindUnitdType();
            BindFacing();
            if (Request.QueryString["FlatID"] != null)
            {
                int value = 0;
                if (int.TryParse(Request.QueryString["FlatID"], out value))
                {
                    lbldisplaymsg.Text = " Edit Flat";
                    btnSave.Text = "Update";
                    Bind(Convert.ToInt32(Request.QueryString["FlatID"]));
                    ddlProName.Attributes.Add("disabled", "true");
                    ddlBlockNumber.Attributes.Add("disabled", "true");
                }
                else
                {
                    string script = string.Format(@"<script>
                        Swal.fire({{ 
                        title: 'URL is incorrect. please try again', 
                        confirmButtonText: 'OK', 
                        customClass: {{ 
                            confirmButton: 'handle-btn-success'  
                        }}
                        }}).then((result) => {{ 
                                window.location.href = 'view-flat.aspx'; 
                        }});
                    </script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                }
            }
            else
            {
                lbldisplaymsg.Text = " Add Flat";
                btnSave.Text = "Submit";
                ddlProName.Enabled = true;
                ddlBlockNumber.Enabled = true;

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
                //ddlProName.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "Bindprojects", ex.Message, "Not Fixed");
        }
    }


    public void BindUnitdType()
    {
        try
        {
            DataTable dt = KF.ViewUnitdType();
            if (dt.Rows.Count > 0)
            {
                ddlUnitType.DataSource = dt;
                ddlUnitType.DataTextField = "UnitdType";
                ddlUnitType.DataValueField = "UnitdID";
                ddlUnitType.DataBind();
                ddlUnitType.Items.Insert(0, new ListItem("", ""));
                //ddlProName.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "BindUnitdType", ex.Message, "Not Fixed");
        }
    }


    public void BindFacing()
    {
        try
        {
            DataTable dt = KF.ViewFlatHouseFacing();
            if (dt.Rows.Count > 0)
            {
                ddlfacing.DataSource = dt;
                ddlfacing.DataTextField = "Facing";
                ddlfacing.DataValueField = "FacingID";
                ddlfacing.DataBind();
                ddlfacing.Items.Insert(0, new ListItem("", ""));
                //ddlProName.SelectedValue = "18";
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "BindFacing", ex.Message, "Not Fixed");
        }
    }


    public void Bind(int id)
    {
        try
        {
            DataTable dt = KF.ViewAllBflat("", "", Convert.ToString(id), "");
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProjectID"])))
                {
                    ddlProName.SelectedValue = Convert.ToString(dt.Rows[0]["ProjectID"]);
                    Bindblock();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["BlockID"])))
                {
                    ddlBlockNumber.SelectedValue = Convert.ToString(dt.Rows[0]["BlockID"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FlatName"])))
                {
                    txtUnitNoFlatNo.Text = Convert.ToString(dt.Rows[0]["FlatName"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Facing"])))
                {
                    ddlfacing.SelectedValue = Convert.ToString(dt.Rows[0]["Facing"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["UDS"])))
                {
                    txtUDS.Text = Convert.ToString(dt.Rows[0]["UDS"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["UnitType"])))
                {
                    ddlUnitType.SelectedValue = Convert.ToString(dt.Rows[0]["UnitType"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SaleableArea"])))
                {
                    txtSaleableArea.Text = Convert.ToString(dt.Rows[0]["SaleableArea"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CarpetArea"])))
                {
                    txtCarpetArea.Text = Convert.ToString(dt.Rows[0]["CarpetArea"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Balcony"])))
                {
                    txtBalcony.Text = Convert.ToString(dt.Rows[0]["Balcony"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Wallarea"])))
                {
                    txtWallArea.Text = Convert.ToString(dt.Rows[0]["Wallarea"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Floor"])))
                {
                    ddlFloor.SelectedValue = Convert.ToString(dt.Rows[0]["Floor"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CarparkingCount"])))
                {
                    ddlNoOfCarParking.SelectedValue = Convert.ToString(dt.Rows[0]["CarparkingCount"]);
                    if (ddlNoOfCarParking.SelectedValue == "1")
                    {
                        divcarp1.Style.Add("display", "block");
                    }
                    else if (ddlNoOfCarParking.SelectedValue == "2")
                    {
                        divcarp1.Style.Add("display", "block");
                        divcarp2.Style.Add("display", "block");
                    }
                    else if (ddlNoOfCarParking.SelectedValue == "3")
                    {
                        divcarp1.Style.Add("display", "block");
                        divcarp2.Style.Add("display", "block");
                        divcarp3.Style.Add("display", "block");
                    }
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Carparkslot1"])))
                {
                    txtcarparking1.Text = Convert.ToString(dt.Rows[0]["Carparkslot1"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Carparkslot2"])))
                {
                    txtcarparking2.Text = Convert.ToString(dt.Rows[0]["Carparkslot2"]);
                }
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Carparkslot3"])))
                {
                    txtcarparking3.Text = Convert.ToString(dt.Rows[0]["Carparkslot3"]);
                }
                //if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FlatStatus"])))
                //{
                //    bool status = Convert.ToBoolean(dt.Rows[0]["FlatStatus"]);

                //    if (status == true)
                //    {
                //        toggleActiveInactive.Checked = true;
                //    }
                //    else
                //    {
                //        toggleActiveInactive.Checked = false;
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "Bind", ex.Message, "Not Fixed");
        }
    }
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindblock();
    }
    public void Bindblock()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlProName.SelectedValue))
            {
                DataTable DT = KB.ViewBlockbyProjectID(Convert.ToInt32(ddlProName.SelectedValue));
                if (DT.Rows.Count > 0)
                {
                    ddlBlockNumber.DataSource = DT;
                    ddlBlockNumber.DataTextField = "BlockName";
                    ddlBlockNumber.DataValueField = "BlockID";
                    ddlBlockNumber.DataBind();
                    ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    ddlBlockNumber.Items.Clear();
                    ddlBlockNumber.Items.Insert(0, new ListItem("No block name", ""));
                }
            }
            else
            {
                ddlBlockNumber.Items.Clear();
                ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void ddlBlockNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnitNoFlatNo.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string labelerror = string.Empty;
            if (string.IsNullOrEmpty(ddlProName.SelectedValue) && string.IsNullOrEmpty(ddlBlockNumber.SelectedValue) &&
                string.IsNullOrEmpty(txtUnitNoFlatNo.Text) && string.IsNullOrEmpty(ddlfacing.SelectedValue) &&
                string.IsNullOrEmpty(txtUDS.Text) && string.IsNullOrEmpty(ddlUnitType.SelectedValue) &&
                string.IsNullOrEmpty(txtSaleableArea.Text) && string.IsNullOrEmpty(txtCarpetArea.Text) &&
                string.IsNullOrEmpty(txtBalcony.Text) && string.IsNullOrEmpty(txtWallArea.Text) &&
                string.IsNullOrEmpty(ddlFloor.SelectedValue) && string.IsNullOrEmpty(ddlNoOfCarParking.SelectedValue))
            {
                labelerror = "Fill the mandatory field.";
            }
            else if (string.IsNullOrEmpty(ddlProName.SelectedValue))
            {
                labelerror = "Select project name";
            }
            else if (string.IsNullOrEmpty(ddlBlockNumber.SelectedValue))
            {
                labelerror = "Select block name";
            }
            else if (string.IsNullOrEmpty(txtUnitNoFlatNo.Text))
            {
                labelerror = "Enter flat no.";
            }
            else if (string.IsNullOrEmpty(ddlfacing.SelectedValue))
            {
                labelerror = "Select facing";
            }
            else if (string.IsNullOrEmpty(txtUDS.Text))
            {
                labelerror = "Enter UDS";
            }
            else if (string.IsNullOrEmpty(ddlUnitType.Text))
            {
                labelerror = "Select unit type";
            }
            else if (string.IsNullOrEmpty(txtSaleableArea.Text))
            {
                labelerror = "Enter saleable area";
            }
            else if (string.IsNullOrEmpty(txtCarpetArea.Text))
            {
                labelerror = "Enter carpet area";
            }
            else if (string.IsNullOrEmpty(txtBalcony.Text))
            {
                labelerror = "Enter balcony";
            }
            else if (string.IsNullOrEmpty(txtWallArea.Text))
            {
                labelerror = "Enter wall area";
            }
            else if (string.IsNullOrEmpty(ddlFloor.SelectedValue))
            {
                labelerror = "Select floor";
            }
            else if (string.IsNullOrEmpty(ddlNoOfCarParking.SelectedValue))
            {
                labelerror = "Select no. of car parking";
            }
            if (string.IsNullOrEmpty(labelerror))
            {
                if (Request.QueryString["FlatID"] == null)
                {
                    if (!Isalreadyexist(ddlProName.SelectedValue, ddlBlockNumber.SelectedValue, txtUnitNoFlatNo.Text))
                    {

                        int currentFlatCount = KF.FlatCountGetByPIDandABy(ddlProName.SelectedValue, ddlBlockNumber.SelectedValue, clientId);
                        int maxAllowedFlatCount = K2.ProjectBlockCountGetByPIDandAby(ddlProName.SelectedValue, clientId);

                        // Compare the values
                        if (currentFlatCount < maxAllowedFlatCount)
                        {
                            int ret = 0;
                            ret = AddData();
                            if (ret == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                             "Swal.fire({ " +
                                "  title: 'Flat added successfully', " +
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
                                string script = string.Format(@" <script>
                        Swal.fire({{ 
                            title: 'Flat details not added due to a server or network issue', 
                            confirmButtonText: 'OK', 
                            customClass: {{ 
                                confirmButton: 'handle-btn-success' 
                            }} 
                        }}).then((result) => {{  
                                window.location.href = 'add-flat.aspx';  
                        }});
                        </script>");
                                ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "Swal.fire({ " +
                              "  title: 'Can\\'t exceed more than " + maxAllowedFlatCount + " flat', " +
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
                              "  title: 'The flat you’re trying to add already exists', " +
                              "  confirmButtonText: 'OK', " +
                               "  customClass: { " +
                                "      confirmButton: 'handle-btn-success', " +
                                "  }" +
                              "});", true);
                    }
                }
                else
                {
                    int ret = 0;
                    ret = UpdateData();
                    if (ret == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                         "Swal.fire({ " +
                            "    title: 'Flat details updated successfully', " +
                            "    icon: 'success', " +
                            "    allowOutsideClick: 'true', " +
                            "    customClass: { " +
                            "        confirmButton: 'handle-btn-success', " +
                            "        icon: 'handle-icon-clr' " +
                            "    } " +
                            "}).then((result) => { " +
                            "        window.location.href = 'view-flat.aspx'; " +
                            "});", true);
                    }
                    else
                    {
                        string script = string.Format(@"  <script>
                        Swal.fire({{
                            title: 'Flat details not Updated due to a server or network issue',
                            confirmButtonText: 'OK',
                            customClass: {{
                                confirmButton: 'handle-btn-success'
                            }}
                        }}).then((result) => {{ 
                                window.location.href = 'add-flat.aspx?FlatID={0}'; 
                        }});
                    </script>", Convert.ToString(Request.QueryString["FlatID"]));
                        ClientScript.RegisterStartupScript(this.GetType(), "alertAndRedirect", script, false);
                    }
                }

            }
            else
            {
                //alert labelerror
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
           "Swal.fire({ title: 'Validation Alert', text: '" + labelerror + "!', customClass: { confirmButton: 'handle-btn-success' } });", true);
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "btnsubmit", ex.Message, "Not Fixed");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        if (Request.QueryString["FlatID"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //      "Swal.fire('Cancelled!', 'Your action has been canceled.', 'success');",
            //      true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            "Swal.fire({ " +
            "   title: 'Flat has been cancelled as requested', " +
            "   confirmButtonText: 'OK', " +
            "   customClass: { " +
            "       confirmButton: 'handle-btn-success' " +
            "   } " +
            "}).then((result) => { " +
            "       window.location.href = 'add-flat.aspx'; " +
            "});", true);
        }
    }
    public int AddData()
    {
        int ret = 0;
        try
        {
            KF.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KF.BlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KF.FlatName = Convert.ToString(txtUnitNoFlatNo.Text);
            KF.Facing = ddlfacing.SelectedValue;
            KF.UDS = txtUDS.Text;
            KF.UnitType = ddlUnitType.SelectedValue;
            KF.SaleableArea = txtSaleableArea.Text;
            KF.CarpetArea = txtCarpetArea.Text;
            KF.Balcony = txtBalcony.Text;
            KF.Wallarea = txtWallArea.Text;
            KF.Floor = Convert.ToInt32(ddlFloor.SelectedValue);
            KF.CarparkingCount = Convert.ToInt32(ddlNoOfCarParking.SelectedValue);
            if (ddlNoOfCarParking.SelectedValue == "1")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = "";
                KF.Carparkslot3 = "";
            }
            else if (ddlNoOfCarParking.SelectedValue == "2")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = txtcarparking2.Text;
                KF.Carparkslot3 = "";
            }
            else if (ddlNoOfCarParking.SelectedValue == "3")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = txtcarparking2.Text;
                KF.Carparkslot3 = txtcarparking3.Text;
            }
            KF.FlatStatus = true;
            KF.AddedBy = clientId;
            ret = KF.AddFlatdetails(KF);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "AddData", ex.Message, "Not Fixed");
        }
        return ret;
    }
    public int UpdateData()
    {
        int ret = 0;
        try
        {
            KF.FlatID = Convert.ToInt32(Request.QueryString["FlatID"]);
            KF.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
            KF.BlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
            KF.FlatName = Convert.ToString(txtUnitNoFlatNo.Text);
            KF.Facing = ddlfacing.SelectedValue;
            KF.UDS = txtUDS.Text;
            KF.UnitType = ddlUnitType.SelectedValue;
            KF.SaleableArea = txtSaleableArea.Text;
            KF.CarpetArea = txtCarpetArea.Text;

            KF.Balcony = txtBalcony.Text;
            KF.Wallarea = txtWallArea.Text;
            KF.Floor = Convert.ToInt32(ddlFloor.SelectedValue);
            KF.CarparkingCount = Convert.ToInt32(ddlNoOfCarParking.SelectedValue);
            if (ddlNoOfCarParking.SelectedValue == "1")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = "";
                KF.Carparkslot3 = "";
            }
            else if (ddlNoOfCarParking.SelectedValue == "2")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = txtcarparking2.Text;
                KF.Carparkslot3 = "";
            }
            else if (ddlNoOfCarParking.SelectedValue == "3")
            {
                KF.Carparkslot1 = txtcarparking1.Text;
                KF.Carparkslot2 = txtcarparking2.Text;
                KF.Carparkslot3 = txtcarparking3.Text;
            }
            KF.FlatStatus = true;
            KF.UpdatedBy = clientId;
            ret = KF.UpdateFlatdetails(KF);
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-flat.aspx", "UpdateData", ex.Message, "Not Fixed");
        }
        return ret;
    }
    public void Clear()
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
    public bool Isalreadyexist(string PID, string BlockID, string Bname)
    {
        bool isavail = false;
        string strbname = string.Empty;
        try
        {
            DataTable dt = KF.AlreadyExistFlat(Convert.ToInt32(PID), Convert.ToInt32(BlockID));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (isavail != true)
                    {
                        if (Equals((Convert.ToString(dt.Rows[i]["FlatName"])).Replace(" ", "").ToLower(), Bname.Replace(" ", "").ToLower()))
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
            CI.StoreExceptionMessage("add-flat.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        }
        return isavail;
    }
    [System.Web.Services.WebMethod]
    public static bool CheckProjectExistence(int projectName, int blockNumber, string txtflatno)
    {
        ClientDashboardError CI = new ClientDashboardError();
        Key2hFlat KF = new Key2hFlat();

        bool isavail = false;
        string strbname = string.Empty;
        try
        {
            DataTable dt = KF.AlreadyExistFlat(Convert.ToInt32(projectName), Convert.ToInt32(blockNumber));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (isavail != true)
                    {
                        if (Equals((Convert.ToString(dt.Rows[i]["FlatName"])).Replace(" ", "").ToLower(), txtflatno.Replace(" ", "").ToLower()))
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
            CI.StoreExceptionMessage("add-flat.aspx", "CheckProjectExistence", ex.Message, "Not Fixed");
        }
        return isavail;
    }
}