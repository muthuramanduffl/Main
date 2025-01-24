using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hPaymentDetails
/// </summary>
public class Key2hPaymentDetails
{
    public int CostID { get; set; }
    public int FlatID { get; set; }
    public int CostLabelID { get; set; }
    public int Cost { get; set; }
    public string AddedBy { get; set; }
    public int UpdatedBy { get; set; }
    public int ProjectID { get; set; }
    public int SubAmount { get; set; }
    public int GST { get; set; }
    public int Amount { get; set; }
    public int PSID { get; set; }
    public int PaymentLabelID { get; set; }
    public string PaymentPercentage { get; set; }

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

    public int AddFlatPaymentScheduleDetails(Key2hPaymentDetails KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatPaymentScheduleDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KC.FlatID));
                command.Parameters.Add(new SqlParameter("@PaymentLabelID", KC.PaymentLabelID));
                command.Parameters.Add(new SqlParameter("@Amount", KC.Amount));
                command.Parameters.Add(new SqlParameter("@SubAmount", KC.SubAmount));
                command.Parameters.Add(new SqlParameter("@GST", KC.GST));
                command.Parameters.Add(new SqlParameter("@PaymentPercentage", KC.PaymentPercentage));
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

    public int DeleteShedulepaymentstages(int PSID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteShedulepaymentstages", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PSID", PSID));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }


    public DataTable ViewProjectPaymentStages()
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectPaymentStages", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public DataTable GetFlatCostDetailsByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("GetFlatCostDetailsByFlatID", cnn))
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


    public DataTable ViewCostPaymentStagesByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCostPaymentStagesByFlatID", cnn))
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



    public DataTable ViewPaymentScheduleByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPaymentScheduleByFlatID", cnn))
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



    public DataTable ViewPaymentsheduleByFlatandPLID(int FlatID, int LabelID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewPaymentsheduleByFlatandPLID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));
                command.Parameters.Add(new SqlParameter("@PaymentLabelID", LabelID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }

        return dt;
    }


    public int GetParameterCostofFlatID(int ID, string Parameter)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable dt = new DataTable();
        int value = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("GetParameterCostofFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", ID));
                command.Parameters.Add(new SqlParameter("@Parameter", Parameter));
                var result = command.ExecuteScalar();

                // Check if the result is DBNull.Value or null
                var singleValue = result != DBNull.Value && result != null ? (int)result : 0;


                // Assign the single value
                value = singleValue;  // No need to check DBNull.Value again
                cnn.Close();


            }
        }
        catch (Exception ex)
        {
        }

        return value;

    }




    public DataTable ViewFilterCustomerPaymentSchedule(string ProID, string FlatID, string BlockID, string PSID)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFilterCustomerPaymentSchedule", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@PSID", string.IsNullOrWhiteSpace(PSID) ? (object)DBNull.Value : Convert.ToInt32(PSID)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public int CustomerPaymentShedule(string flatID, string AddedBy)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("CustomerPaymentShedule", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(flatID) ? (object)DBNull.Value : Convert.ToInt32(flatID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                rowaffected = command.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }
}