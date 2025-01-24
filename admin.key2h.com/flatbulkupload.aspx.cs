using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;

public partial class AdminkeyhcomFlatbulkupload : System.Web.UI.Page
{ 
    DataRow dr1;
    int existcount = 0;
    int emptyrow = 0;
    DataTable dt1 = new DataTable();
    DataRow dr2;
    int dublicate = 0;
    string strexistblockname = string.Empty;
    Key2hFlat KF = new Key2hFlat();
    Key2hProjectblock KB = new Key2hProjectblock();
    Key2hProject K2 = new Key2hProject();
    ClientDashboardError CI = new ClientDashboardError();
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
            lbldisplaytext.Text = "Flat Bulk Upload";
            btnSave.Text = "Submit";
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
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "Bindprojects", ex.Message, "Not Fixed");
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
                    ddlBlockNumber.Items.Insert(0, new ListItem("", ""));
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
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "Bindblock", ex.Message, "Not Fixed");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        existcount = 0;
        emptyrow = 0;
        dublicate = 0;
        lblMesg.Text = "";
        string stErrorText = string.Empty;
        if (string.IsNullOrEmpty(FluploadProjectScreen.FileName))
        {
            stErrorText = "Upload the file";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Please upload the file');</script>");
        }
        if (string.IsNullOrEmpty(stErrorText))
        {
            if (FluploadProjectScreen.HasFile == true && FluploadProjectScreen.PostedFile != null)
            {
                string _fileExt = System.IO.Path.GetExtension(FluploadProjectScreen.FileName);
                if (string.Equals(_fileExt.ToLower(), ".xls") || string.Equals(_fileExt.ToLower(), ".xlsx"))
                {
                    stErrorText = "";
                }
                else
                {
                    stErrorText = "Upload only excel file";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Please upload only excel file');</script>");
                }
                if (string.IsNullOrEmpty(stErrorText))
                { 
                    if (FluploadProjectScreen.HasFile)
                    {
                        string filepath = System.Configuration.ConfigurationManager.AppSettings["FlatBulkUpload"];
                        string temppath = filepath.Trim() + @"\" + FluploadProjectScreen.PostedFile.FileName.Trim();
                        string savepath = Server.MapPath(temppath);
                        FluploadProjectScreen.SaveAs(savepath);
                        int rep = 0;
                        int isave = Import_To_Database(savepath);
                        if (isave > 0)
                        {
                            Clear();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire({ " +
                        "  title: 'Flat details added successfully', " +
                        "  icon: 'success', " +
                        "  customClass: { " +
                        "    icon: 'handle-icon-clr', " +
                        "    confirmButton: 'handle-btn-success' " +
                        "  } " +
                        "});", true);
                            rep = 1;
                        } 
                        if (dublicate != 0)
                        {
                            lblMesg.Text = lblMesg.Text + "Already exist records: " + strexistblockname + ".";
                            if (rep == 0)
                            {
                                rep = 1;
                            }
                        }
                    }
                }
            }
        }
    }
    private int Import_To_Database(string FilePath)
    {
        int iSave = 0;
        DataTable dt = new DataTable();
        try
        {
            var existingFile = new FileInfo(FilePath);
            using (var package = new ExcelPackage(existingFile))
            {
                ExcelWorkbook workBook = package.Workbook;

                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet currentWorksheet = workBook.Worksheets[1];
                        int i = 1;
                        int j = 1;
                        List<string> lstHeader = new List<string>();

                        for (int Column = 1; Column <= currentWorksheet.Dimension.End.Column; Column++)
                        {
                            object col1Header = currentWorksheet.Cells[i, Column].Value; 
                            if (col1Header != null)
                            {
                                lstHeader.Add(col1Header.ToString());
                                dt.Columns.Add(col1Header.ToString());
                            }
                        } 
                        for (int rowNumber = 2; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                        {
                            dr1 = dt.NewRow();
                            for (int Column = 1; Column <= currentWorksheet.Dimension.End.Column; Column++)
                            {
                                object col1Value = currentWorksheet.Cells[rowNumber, Column].Value;
                                if (col1Value != null)
                                { 
                                    dr1[lstHeader[Column - 1]] = col1Value.ToString(); 
                                }
                            }
                            dt.Rows.Add(dr1);
                        }

                        if (dt.Rows.Count <= 150)
                        {
                            iSave = SaveDetails(lstHeader, dt);
                        }
                        else
                        {
                            string script = "Swal.fire({{ title: 'Upload only for 150 rows at a time', confirmButtonText: 'OK',customClass: {{ confirmButton: 'handle-btn-success' }} }});";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                        } 
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "Import_To_Database", ex.Message, "Not Fixed");
        }
        return iSave;
    }
    public int GetColumnIndex(List<string> lstHedaer, string column)
    {
        int value = 0;
        if (lstHedaer != null && lstHedaer.Count > 0)
        {
            value = lstHedaer.FindIndex(i => i.TrimEnd() == column.Trim());
        }
        return value;
    }
    public int SaveDetails(List<string> lstHeader, DataTable dt)
    {
        HashSet<string> seenCandidateIDs = new HashSet<string>(); 
        int iSave = 0;
        int FlatNameIndex = 1;
        int FacingIndex = 1;
        int UDSIndex = 1;
        int UnitTypeIndex = 1;
        int SaleableAreaIndex = 1;
        int CarpetAreaIndex = 1;
        int BalconyIndex = 1;
        int WallareaIndex = 1;
        int CarparkingCountIndex = 1;
        int Carparkslot1Index = 1;
        int Carparkslot2Index = 1;
        int Carparkslot3lot1Index = 1;
        int FloorIndex = 1; 
        try
        {
            FloorIndex = GetColumnIndex(lstHeader, "FLOOR");
            FlatNameIndex = GetColumnIndex(lstHeader, "FLAT NAME");
            FacingIndex = GetColumnIndex(lstHeader, "FACING");
            UDSIndex = GetColumnIndex(lstHeader, "UDS");
            UnitTypeIndex = GetColumnIndex(lstHeader, "UNIT TYPE");
            SaleableAreaIndex = GetColumnIndex(lstHeader, "SALEABLE AREA SQUARE FEET");
            BalconyIndex = GetColumnIndex(lstHeader, "BALCONY SQUARE FEET");
            WallareaIndex = GetColumnIndex(lstHeader, "WALL AREA SQUARE FEET");
            CarpetAreaIndex = GetColumnIndex(lstHeader, "CARPET AREA");
            CarparkingCountIndex = GetColumnIndex(lstHeader, "CARPARKING COUNT");
            Carparkslot1Index = GetColumnIndex(lstHeader, "CARPARKING SLOT 1");
            Carparkslot2Index = GetColumnIndex(lstHeader, "CARPARKING SLOT 2");
            Carparkslot3lot1Index = GetColumnIndex(lstHeader, "CARPARKING SLOT 3");
             
            string stFlatName = string.Empty;
            string stFacing = string.Empty;
            string stUDS = string.Empty;

            string stUnitType = string.Empty;
            string stSaleableArea = string.Empty;
            string stCarpetArea = string.Empty;
            string stBalcony = string.Empty;
            string stWallarea = string.Empty;
            string stCarparkingCount = string.Empty;
            string stCarparkslot1 = string.Empty;
            string stCarparkslot2 = string.Empty;
            string stCarparkslot3 = string.Empty;
            string stFloorIndex = string.Empty; 
            string stblockname = string.Empty; 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                stFlatName = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[FlatNameIndex]].ToString()) ? dt.Rows[i][lstHeader[FlatNameIndex]].ToString().Trim() : string.Empty;
                stFacing = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[FacingIndex]].ToString()) ? dt.Rows[i][lstHeader[FacingIndex]].ToString().Trim() : string.Empty;
                stUDS = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[UDSIndex]].ToString()) ? dt.Rows[i][lstHeader[UDSIndex]].ToString().Trim() : string.Empty;
                stUnitType = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[UnitTypeIndex]].ToString()) ? dt.Rows[i][lstHeader[UnitTypeIndex]].ToString().Trim() : string.Empty;
                stSaleableArea = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[SaleableAreaIndex]].ToString()) ? dt.Rows[i][lstHeader[SaleableAreaIndex]].ToString().Trim() : string.Empty;
                stCarpetArea = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[CarpetAreaIndex]].ToString()) ? dt.Rows[i][lstHeader[CarpetAreaIndex]].ToString().Trim() : string.Empty;
                stBalcony = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[BalconyIndex]].ToString()) ? dt.Rows[i][lstHeader[BalconyIndex]].ToString().Trim() : string.Empty;
                stWallarea = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[WallareaIndex]].ToString()) ? dt.Rows[i][lstHeader[WallareaIndex]].ToString().Trim() : string.Empty;
                stCarparkingCount = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[CarparkingCountIndex]].ToString()) ? dt.Rows[i][lstHeader[CarparkingCountIndex]].ToString().Trim() : string.Empty;
                stCarparkslot1 = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[Carparkslot1Index]].ToString()) ? dt.Rows[i][lstHeader[Carparkslot1Index]].ToString().Trim() : string.Empty;
                stCarparkslot2 = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[Carparkslot2Index]].ToString()) ? dt.Rows[i][lstHeader[Carparkslot2Index]].ToString().Trim() : string.Empty;
                stCarparkslot3 = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[Carparkslot3lot1Index]].ToString()) ? dt.Rows[i][lstHeader[Carparkslot3lot1Index]].ToString().Trim() : string.Empty;
                stFloorIndex = !string.IsNullOrEmpty(dt.Rows[i][lstHeader[FloorIndex]].ToString()) ? dt.Rows[i][lstHeader[FloorIndex]].ToString().Trim() : string.Empty;

                if (!string.IsNullOrEmpty(stFlatName))
                { 
                    if (!Isalreadyexist(ddlProName.SelectedValue, ddlBlockNumber.SelectedValue, stFlatName))
                    { 
                        KF.ProjectID = Convert.ToInt32(ddlProName.SelectedValue);
                        KF.BlockID = Convert.ToInt32(ddlBlockNumber.SelectedValue);
                        KF.FlatName = Convert.ToString(stFlatName);
                        KF.Facing = stFacing;
                        KF.UDS = stUDS;
                        KF.UnitType = stUnitType;
                        KF.SaleableArea = stSaleableArea;
                        KF.CarpetArea = stCarpetArea; 
                        KF.Balcony = stBalcony;
                        KF.Wallarea = stWallarea;
                        KF.Floor = Convert.ToInt32(stFloorIndex);
                        KF.CarparkingCount = Convert.ToInt32(stCarparkingCount); 
                        KF.Carparkslot1 = stCarparkslot1;
                        KF.Carparkslot2 = stCarparkslot2;
                        KF.Carparkslot3 = stCarparkslot3; 
                        KF.FlatStatus = true;
                        KF.AddedBy = clientId;
                        int ret = 0;
                        ret = KF.AddFlatdetails(KF); 
                        if (ret > 0)
                            iSave++;
                    }
                    else
                    {
                        strexistblockname += ", " + stFlatName;
                        dublicate++;
                    }
                }
                else
                {
                    // Optional: Handle empty row cases
                    emptyrow++;
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "SaveDetails", ex.Message, "Not Fixed");
        } 
        return iSave;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblMesg.Text = "";
        Clear(); 
        if (Request.QueryString["BlockID"] == null)
        { 
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
            "   window.location.href = '" + Request.Url.AbsolutePath + "'; " +
            "});", true);
        }
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
                    if (Equals((Convert.ToString(dt.Rows[i]["FlatName"])).Replace(" ", "").ToLower(), Bname.Replace(" ", "").ToLower()))
                    {
                        isavail = true;
                    } 
                }
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "Isalreadyexist", ex.Message, "Not Fixed");
        } 
        return isavail;
    }
    public void Clear()
    {
        ddlProName.SelectedIndex = 0; 
        Bindblock();
    }
    protected void lkedit_Click(object sender, EventArgs e)
    {
        try
        { 
            string filePath = System.Configuration.ConfigurationManager.AppSettings["FlatBulkUpload"];
            string fileName = "FlatBulkUploadDoc.xlsx";
            string fullFilePath = Server.MapPath(Path.Combine(filePath, fileName));
            if (File.Exists(fullFilePath))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(fullFilePath);
                Response.End();
            }
            else
            {
                // Handle file not found scenario
                // You may display an error message or log the issue
                // Example: Response.Write("File not found.");
            }
        }
        catch(Exception ex)
        {
            CI.StoreExceptionMessage("Flatbulkupload.aspx", "lkedit_Click", ex.Message, "Not Fixed");
        }
    }
}