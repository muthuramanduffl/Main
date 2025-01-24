using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2htransaction
/// </summary>
public class Key2htransaction
{


    public int intDemandID { get; set; }
    public int intFlatID { get; set; }
    public string strPaymentStatus { get; set; }
    public DateTime PaymentUpdatedDate { get; set; }
    public string strPaymentUpdatedBy { get; set; }
    public int intProjectID { get; set; }
    public int intBlockNo { get; set; }
    public string strReceiptPDF { get; set; }
    public int intPaidamount { get; set; }
    public string strPaymentMode { get; set; }







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


    public DataTable AlreadyexisttransactionByDemandID(int DemandID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyexisttransactionByDemandID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DemandID", DemandID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }

        return dt;
    }


    public DataTable ViewDemandTypeByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewDemandTypeByFlatID", cnn))
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

    public DataTable ViewAllFlatCustomerTransactionByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomerTransactionByFlatID", cnn))
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


    public int AddFlatCustomerTransaction(Key2htransaction KT)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomerTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KT.intFlatID));
                command.Parameters.Add(new SqlParameter("@DemandID", KT.intDemandID));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", KT.strPaymentStatus));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedDate", KT.PaymentUpdatedDate));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", KT.strPaymentUpdatedBy));
                command.Parameters.Add(new SqlParameter("@ProjectID", KT.intProjectID));
                command.Parameters.Add(new SqlParameter("@BlockNo", KT.intBlockNo));
                command.Parameters.Add(new SqlParameter("@ReceiptPDF", KT.strReceiptPDF));
                command.Parameters.Add(new SqlParameter("@PaidAmount", KT.intPaidamount));
                command.Parameters.Add(new SqlParameter("@PaymentMode", KT.strPaymentMode));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }





    public DataTable ViewFilterFlatCustomerTransaction(string ProID, string Blockid, string FlatID,string transactionID)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFilterFlatCustomerTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ProID));
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));
                command.Parameters.Add(new SqlParameter("@BlockID", Blockid));
                command.Parameters.Add(new SqlParameter("@TransactionID", transactionID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }

        return dt;
    }




    public int DeleteFlatCustomerTransaction(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatCustomerTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", ID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    } 
    
    
    public int DeleteIndivitualFlatCustomerTransaction(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteIndivitualFlatCustomerTransaction", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TransactionID", ID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }



}