using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; 
using System.Data; 
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.Text;

public partial class adminkey2hcom_Specifications : System.Web.UI.Page
{
    DataRow dr1;
    int existcount = 0;
    int emptyrow = 0;
    DataTable dt1 = new DataTable();
    DataRow dr2;
    int dublicate = 0;
    string strexistblockname = string.Empty;
    ClientDashboardError CI = new ClientDashboardError();
    Key2hProject k2 = new Key2hProject();
    Key2hProjectSpecs K2s = new Key2hProjectSpecs(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindprojects();
            btnSave.Text = "Submit";
            lbldisplaytext.Text = "Specifications Bulk Upload";
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Upload the file');</script>"); 
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>alert('Upload only excel file');</script>");
                }
                if (string.IsNullOrEmpty(stErrorText))
                { 
                    // if (FluploadProjectScreen.HasFile)
                    // { 
                        string filepath = System.Configuration.ConfigurationManager.AppSettings["uploadblock"];
                        string temppath = filepath.Trim() + @"\" + FluploadProjectScreen.PostedFile.FileName.Trim();
                        string savepath = Server.MapPath(temppath); 
                        FluploadProjectScreen.SaveAs(savepath); 
                        int rep = 0;
                        DataTable dt = Import_To_Database(savepath); // Modified to return DataTable
                        if (dt != null && dt.Rows.Count > 0)
                        {
                    List<string> lstHeader = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName).ToList();
                            rep = SaveDetails(lstHeader, dt);
                        if (rep > 0)
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire({ " +
                            "  title: 'Specifications details added successfully', " +
                            "  icon: 'success', " +
                            "  allowOutsideClick: 'true', " +
                            "  customClass: { " +
                            "    icon: 'handle-icon-clr', " +
                            "    confirmButton: 'handle-btn-success' " +
                            "  } " +
                            "}).then((result) => { " +
                            "  window.location.href = '" + Request.Url.AbsolutePath + "'; " +
                            "});", true);

                            string html = GenerateHTML(dt);
                          ltDynamicContent.Text = html; 
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
    private DataTable Import_To_Database(string FilePath)
    {
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
                    List<string> lstHeader = new List<string>(); 
                    // Read header row and add columns to DataTable
                    for (int col = 1; col <= currentWorksheet.Dimension.End.Column; col++)
                    {
                        string columnName = currentWorksheet.Cells[i, col].Value != null 
                                            ? currentWorksheet.Cells[i, col].Value.ToString() 
                                            : string.Empty;
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            lstHeader.Add(columnName);
                            dt.Columns.Add(columnName);
                        }
                    } 
                    // Read data rows and add them to DataTable
                    for (int rowNumber = 2; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                    {
                        DataRow dr1 = dt.NewRow();
                        for (int col = 1; col <= currentWorksheet.Dimension.End.Column; col++)
                        {
                            object colValue = currentWorksheet.Cells[rowNumber, col].Value;
                            if (colValue != null)
                            {
                                dr1[lstHeader[col - 1]] = colValue.ToString();
                            }
                        }
                        dt.Rows.Add(dr1);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", 
            "<script>alert('Upload a valid Excel file');</script>");
    }

    return dt;
}

private string GenerateHTML(DataTable dt)
{
    StringBuilder sb = new StringBuilder(); 
    sb.Append("<div class='form-border margin-top20'>");
    sb.Append("<div class='form-title'><h3>View Details</h3></div>");
    sb.Append("<div class='row mx-0 margin-top20 mb-2'>");
    sb.Append("<div class='container mt-2'>");
    sb.Append("<div class='accordion' id='accordionExample'>"); 
    // Grouping rows by SpecificationTitle
    var groupedData = dt.AsEnumerable()
                        .GroupBy(row => row["SpecificationTitle"].ToString())
                        .Select(g => new
                        {
                            SpecificationTitle = g.Key,
                            Details = g.Select(row => row["SpecificationDetails"].ToString()).ToList()
                        }).ToList(); 
    int counter = 1; 
    // Loop through each grouped specification title
    foreach (var group in groupedData)
    {
        string specificationTitle = group.SpecificationTitle ?? "No Title";
        List<string> specificationDetails = group.Details; 
        // Accordion Item for each SpecificationTitle
        sb.Append("<div class='accordion-item'>");
        sb.Append("<h2 class='accordion-header' id='heading" + counter + "'>");
        sb.Append("<button class='accordion-button' type='button' data-bs-toggle='collapse' data-bs-target='#collapse" + counter + "' aria-expanded='" + (counter == 1 ? "true" : "false") + "' aria-controls='collapse" + counter + "'>");
        sb.Append(specificationTitle);
        sb.Append("</button>");
        sb.Append("</h2>");
        sb.Append("<div id='collapse" + counter + "' class='accordion-collapse collapse " + (counter == 1 ? "show" : "") + "' aria-labelledby='heading" + counter + "' data-bs-parent='#accordionExample'>");
        sb.Append("<div class='accordion-body'>"); 
        sb.Append("<ul>");
        foreach (var detail in specificationDetails)
        {
            sb.Append("<li>" + detail + "</li>");
        }
        sb.Append("</ul>"); 
        sb.Append("</div>");
        sb.Append("</div>");
        sb.Append("</div>"); 
        counter++;
    } 
    sb.Append("</div>");
    sb.Append("</div>");
    sb.Append("</div>");
    sb.Append("</div>");  
    return sb.ToString();
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
        int emptyRowCount = 0;
        int SpecificationTitleIndex = GetColumnIndex(lstHeader, "SpecificationTitle");
        int SpecificationContentIndex = GetColumnIndex(lstHeader, "SpecificationDetails"); 
        if (SpecificationTitleIndex == -1 || SpecificationContentIndex == -1)
        {
            // Column "Blockname" not found, handle gracefully
            Page.ClientScript.RegisterStartupScript(
                this.GetType(),
                "Alert",
                "<script>alert('Specification title column is missing in the uploaded file.');</script>"
            );
            return iSave;
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            // Get the value from the "Blockname" column
            string specificationTitle = dt.Rows[i][lstHeader[SpecificationTitleIndex]] != null
                          ? dt.Rows[i][lstHeader[SpecificationTitleIndex]].ToString().Trim()
                          : string.Empty;

            string specificationContent = dt.Rows[i][lstHeader[SpecificationContentIndex]] != null
                          ? dt.Rows[i][lstHeader[SpecificationContentIndex]].ToString().Trim()
                          : string.Empty;

            if (!string.IsNullOrEmpty(specificationTitle))
            {
                // Check if the blockname already exists
                // if (!Isalreadyexist(ddlprojects.SelectedValue, stblockname))
                // {
                    K2s.ProjectID = Convert.ToInt32(ddlprojects.SelectedValue);
                    K2s.SpecificationTitle = specificationTitle;
                    K2s.SpecificationDetails = specificationContent;
                    K2s.Status = true;
                    K2s.Addedby = "1"; 
                    int ret = K2s.AddSpecifications(K2s); 
                    if (ret > 0)
                        iSave++;
                // }
                // else
                // {
                //     strexistblockname += ", "+ stblockname;
                //     dublicate++;
                // }
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
        Clear();
        if (Request.QueryString["Projectid"] == null)
        { 
        }
        else
        { 
        }
    }
    
    public void Clear()
    { 
        Response.Redirect(Request.Url.AbsolutePath); 
    }
    protected void lkedit_Click(object sender, EventArgs e)
    {
         try
        {

        string filePath = System.Configuration.ConfigurationManager.AppSettings["SpecBulkUpload"];
            string fileName = "Specbulkupload.xlsx";
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
            }
        }
        catch (Exception ex)
        {
            CI.StoreExceptionMessage("add-specifications.aspx", "lkedit_Click", ex.Message, "Not Fixed");
        }
    }

}