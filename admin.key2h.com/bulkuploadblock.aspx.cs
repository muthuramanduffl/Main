using System;
using System.Collections.Generic;
using System.Data; 
using System.IO; 
using System.Web.UI;
using System.Web.UI.WebControls; 
using OfficeOpenXml;
 
public partial class Adminkeyhcombulkuploadblock : System.Web.UI.Page
{

    DataRow dr1;
    int existcount = 0;
    int emptyrow = 0;
    DataTable dt1 = new DataTable();
    DataRow dr2;
    int dublicate = 0;
    string strexistblockname = string.Empty; 
    Key2hProject k2 = new Key2hProject();
    Key2hProjectblock K2b = new Key2hProjectblock();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Bindprojects(); 
                btnSave.Text = "Submit";
                lbldisplaytext.Text = "Bulk Block Upload"; 
        } 
    }

    public void Bind(string id)
    { 
        DataTable DT = K2b.ViewAllBlock(id, "", ""); 
        if (DT.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(DT.Rows[0]["ProjectID"])))
            {
                ddlprojects.SelectedValue = Convert.ToString(DT.Rows[0]["ProjectID"]);
            }
        }
    }
     
    public void Bindprojects()
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
                        string filepath = System.Configuration.ConfigurationManager.AppSettings["uploadblock"]; 
                        string temppath = filepath.Trim() + @"\" + FluploadProjectScreen.PostedFile.FileName.Trim();
                        string savepath = Server.MapPath(temppath); 
                        FluploadProjectScreen.SaveAs(savepath); 
                        int rep = 0;
                        int isave = Import_To_Database(savepath);
                        if (isave > 0)
                        { 
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", 
                            "Swal.fire({ " +
                        "  title: 'Block details added successfully', " +
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
                            lblMesg.Text = lblMesg.Text +"Already exist records: " + strexistblockname + ".";
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
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Please upload only sheet of 150 rows at a time');</script>");
                        } 
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //stErrorText = "Upload only excel file";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Please upload valid excel file');</script>");
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
        int blocknameIndex = GetColumnIndex(lstHeader, "Blockname"); 
        // Validate blocknameIndex
        if (blocknameIndex == -1)
        {
            // Column "Blockname" not found, handle gracefully
            Page.ClientScript.RegisterStartupScript(
                this.GetType(),
                "Alert",
                "<script>alert('Block Name column is missing in the uploaded file.');</script>"
            );
            return iSave;
        } 
        string stblockname = string.Empty; 
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            // Get the value from the "Blockname" column
            stblockname = dt.Rows[i][lstHeader[blocknameIndex]] != null
                          ? dt.Rows[i][lstHeader[blocknameIndex]].ToString().Trim()
                          : string.Empty;

            if (!string.IsNullOrEmpty(stblockname))
            {
                // Check if the blockname already exists
                if (!Isalreadyexist(ddlprojects.SelectedValue, stblockname))
                {
                    K2b.ProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
                    K2b.Blocknumber = stblockname;
                    K2b.Status = true;
                    K2b.Addedby = "Admin"; 
                    int ret = K2b.Addblocks(K2b); 
                    if (ret > 0)
                        iSave++;
                }
                else
                {
                    strexistblockname += ", "+ stblockname;
                    dublicate++;
                }
            }
            else
            {
                // Optional: Handle empty row cases
                emptyrow++;
            }
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
             
        }
    }
     
    public bool Isalreadyexist(string PID, string Bname)
    {
        bool isavail = false;
        string strbname = string.Empty;
        DataTable dt = K2b.BlockAlreadyExistByProjectid(Convert.ToInt32(PID), Bname); 
        if (dt.Rows.Count > 0)
        { 
                isavail = true; 
        } 
        return isavail;
    }
     
    public void Clear()
    { 
        ddlprojects.SelectedValue = "";

    }

}