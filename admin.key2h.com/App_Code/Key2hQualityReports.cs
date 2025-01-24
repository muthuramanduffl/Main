using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hQualityReports
/// </summary>
public class Key2hQualityReports
{

    public int QFID { get; set; }
    public int FlatID { get; set; }
    public int BlockID { get; set; }
    public int ProjectID { get; set; }
    public string Title { get; set; }
    public string PDFName { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int AddedBy { get; set; }
    public int UpdatedBy { get; set; }
    public int DisplayOrder {get; set;}

    #region GetSqlConnectionstring
    public string GetSqlConnection()
    {
        string connectionString = null;
        try
        {

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Key2h"].ConnectionString;

        }
        catch (Exception ex)
        {
        }
        return connectionString;
    }
    #endregion

    public int AddFlatQualityReports(Key2hQualityReports KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatQualityReports", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KC.FlatID));
                command.Parameters.Add(new SqlParameter("@BlockID", KC.BlockID));
                command.Parameters.Add(new SqlParameter("@Title", KC.Title));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.ProjectID));
                command.Parameters.Add(new SqlParameter("@PDFName", KC.PDFName));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }
    
    public int UpdateFlatQualityReportDetails(Key2hQualityReports KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatQualityReportDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@QFID", KC.QFID));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.FlatID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.ProjectID));
                command.Parameters.Add(new SqlParameter("@Title", KC.Title));
                command.Parameters.Add(new SqlParameter("@PDFName", KC.PDFName));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }

    public int UpdateFlatQualityReport(Key2hQualityReports KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatQualityReport", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add(new SqlParameter("@Title", KC.Title));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.FlatID));
                command.Parameters.Add(new SqlParameter("@QFID", KC.QFID));
                command.Parameters.Add(new SqlParameter("@PDFName", KC.PDFName));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }



    public DataTable ViewFlatQualityReportbyFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatQualityReportbyFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    } 
    
    
    public DataTable ViewAllFlatQualityReports(string ProID,string FlatID,string BlockID,string QFID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatQualityReports", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@QFID", string.IsNullOrWhiteSpace(QFID) ? (object)DBNull.Value : Convert.ToInt32(QFID)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
  
    public DataTable AlreadyExistFlatQualityReporttByProIDBlockIDFlatID(int ProID,int Title,int FlatID)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistFlatQualityReporttByProIDBlockIDFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ProID));
                command.Parameters.Add(new SqlParameter("@Title", Title));
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }

        return dt;
    } 
    
    public int DeleteAllFlatQualityReports(int flatID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteAllFlatQualityReports", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@FlatID", flatID));
                rowaffected =command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }
     public int DeleteFlatQualityReports(int QFID,int flatID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatQualityReports", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@QFID",QFID));
                command.Parameters.Add(new SqlParameter("@FlatID", flatID));
                rowaffected =command.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }

}