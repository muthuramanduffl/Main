using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hCustomizationTransaction
/// </summary>
public class Key2hCustomizationTransaction
{

    public int intFlatID { get; set; }
    public int intCDemandID { get; set; }
    public string strPaymentStatus { get; set; }

    public string strReceiptPDF { get; set; }
    public int intPaidAmount { get; set; }
    public string strPaymentMode { get; set; }
    public string strPaymentUpdatedBy { get; set; }
    public DateTime PaymentUpdatedDate { get; set; }


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
    #endregion  AddFlatCustomisationTransaction




    public int AddFlatCustomisationTransaction(Key2hCustomizationTransaction KCT)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomisationTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KCT.intFlatID));
                command.Parameters.Add(new SqlParameter("@CDemandID", KCT.intCDemandID));
                command.Parameters.Add(new SqlParameter("@ReceiptPDF", KCT.strReceiptPDF));
                command.Parameters.Add(new SqlParameter("@PaidAmount", KCT.intPaidAmount));
                command.Parameters.Add(new SqlParameter("@PaymentMode", KCT.strPaymentMode));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", "Paid"));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedDate", KCT.PaymentUpdatedDate));
                command.Parameters.Add(new SqlParameter("@RecAddedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", KCT.strPaymentUpdatedBy));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }
    

         public DataTable ViewAllFlatCustomisationTransaction(string ProID, string BlockID, string FlatID, string CTID, string CDemandID, string UpdatedBy)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomisationTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@CDemandID", string.IsNullOrWhiteSpace(CDemandID) ? (object)DBNull.Value : Convert.ToInt32(CDemandID)));
                command.Parameters.Add(new SqlParameter("@CTID", string.IsNullOrWhiteSpace(CTID) ? (object)DBNull.Value : Convert.ToInt32(CTID)));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", ""));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }





    public DataTable ViewCustomizationDemandTypeByFlatIDandAddedby(string FlatID, string CDemandID, string Addedby)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCustomizationDemandTypeByFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@CDemandID", string.IsNullOrWhiteSpace(CDemandID) ? (object)DBNull.Value : Convert.ToInt32(CDemandID)));
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


    public DataTable ViewFlatCustomisationTranListByFlIDandPBy(string FlatID, string updatedBy)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatCustomisationTransactionListByFlatIDandPUpdatedBy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", updatedBy));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
     public DataTable CalculatePaymentBalance(string FlatID,string DemandID, string updatedBy)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("CalculatePaymentBalance", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@CDemandID", string.IsNullOrWhiteSpace(DemandID) ? (object)DBNull.Value : Convert.ToInt32(DemandID)));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", updatedBy));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }


    public int DeleteIndivitualFlatCustomizationTransaction(string CTID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteIndivitualFlatCustomizationTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CTID", string.IsNullOrWhiteSpace(CTID) ? (object)DBNull.Value : Convert.ToInt32(CTID)));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    
    
    public int DeleteAllTransaction(string FlatID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteCustomizationTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }






}