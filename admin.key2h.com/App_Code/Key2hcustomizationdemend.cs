using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hcustomizationdemend
/// </summary>
public class Key2hcustomizationdemend
{

    public int intFlatID { get; set; } 
    public int intCWID { get; set; } 
    public int intCDemandID { get; set; } 
    public string strPDFName { get; set; } 
    public string straddedBy { get; set; } 




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





    public int AddFlatCustomisationDemands(Key2hcustomizationdemend KCD)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomisationDemands", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KCD.intFlatID));
                command.Parameters.Add(new SqlParameter("@PDFName", KCD.strPDFName));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", "Unpaid"));
                command.Parameters.Add(new SqlParameter("@CWID", KCD.intCWID));
                command.Parameters.Add(new SqlParameter("@AddedBy", KCD.straddedBy));
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






    public DataTable ViewAllFlatCustomerDemands(string ProID, string BlockID, string FlatID, string CWID,string CDemandID, string AddedBy)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomerDemands", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@CDemandID", string.IsNullOrWhiteSpace(CDemandID) ? (object)DBNull.Value : Convert.ToInt32(CDemandID)));
                command.Parameters.Add(new SqlParameter("@CWID", string.IsNullOrWhiteSpace(CWID) ? (object)DBNull.Value : Convert.ToInt32(CWID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", string.IsNullOrWhiteSpace(AddedBy) ? (object)DBNull.Value : Convert.ToInt32(AddedBy)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    



    public DataTable ViewAllFlatCustomisationDemandsByFIDandABy(string FlatID, string Addedby)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomisationDemandsByFIDandABy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", Addedby));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    



    public int DeleteFlatCustomisationDemands(int flatID, int CWID)
    {
        int rowaffected = 0;
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatCustomisationDemands", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@CDemandID", CWID));
                command.Parameters.Add(new SqlParameter("@FlatID", flatID));
                rowaffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }

}