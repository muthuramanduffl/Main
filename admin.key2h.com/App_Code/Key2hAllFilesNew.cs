using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hAllFilesNew
/// </summary>
public class Key2hAllFilesNew
{

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



    public bool CheckExistProjectCostLabelsParameter(string CostLabelID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        bool exists = false;
        try
        {
            using (SqlCommand command = new SqlCommand("CheckExistProjectCostLabelsParameterByCLID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CostLabelID", string.IsNullOrWhiteSpace(CostLabelID) ? (object)DBNull.Value : Convert.ToInt32(CostLabelID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                exists = Convert.ToBoolean(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return exists;
    }

    public bool ViewAvailtransactionReceipt(string PSID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        bool exists = false;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAvailtransactionReceiptByPSID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PSID", string.IsNullOrWhiteSpace(PSID) ? (object)DBNull.Value : Convert.ToInt32(PSID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                exists = Convert.ToBoolean(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return exists;
    }


    public DataTable ViewAllCostpaymentdetails(string PID, string BID, string FID, string SearchBy, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllCostpaymentdetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(PID) ? (object)DBNull.Value : Convert.ToInt32(PID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FID) ? (object)DBNull.Value : Convert.ToInt32(FID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BID) ? (object)DBNull.Value : Convert.ToInt32(BID)));
                command.Parameters.Add(new SqlParameter("@searchBy", string.IsNullOrWhiteSpace(SearchBy) ? (object)DBNull.Value : Convert.ToInt32(SearchBy)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                SqlDataAdapter DA = new SqlDataAdapter(command);
                DA.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable ViewAllIndiaBankList()
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllIndiaBankList", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(command);
                DA.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewFlatBookingReferedby()
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatBookingReferedby", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(command);
                DA.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public int ExistCostLabelParameterFlatcostDetailsByCIDandAddedby(string FlatID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int exists = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ExistCostLabelParameterFlatcostDetailsByCIDandAddedby", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                exists = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return exists;
    }

    public int DeleteCustomerPaymentSchedule(string CostLabelID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int ret = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteCustomerPaymentSchedule", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(CostLabelID) ? (object)DBNull.Value : Convert.ToInt32(CostLabelID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                ret = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return ret;
    }



}