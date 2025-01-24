using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Key2hdemontDetails
/// </summary>
public class Key2hdemontDetails
{



    public int intdemontid { get; set; }
    public string StrPDF { get; set; }
    public string updatedby { get; set; }

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

    public DataTable ViewCustomerPaymentStagesByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCustomerPaymentStagesByFlatID", cnn))
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

    public int DeleteFlatCustomerDemandsByDemandID(int ID)
    {
        int Rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatCustomerDemandsByDemandID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DemandID", ID));
                Rowaffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }
        return Rowaffected;
    }
    public DataTable ViewFlatCustomerDemandsByFlatID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatCustomerDemandsByFlatID", cnn))
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
    public DataTable ViewFlatDemandPaymentLabelNameByPLID(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatDemandPaymentLabelNameByPLID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PaymentLabelID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    public DataTable ViewAllFlatDemandDetails(string ID, string PID, string BlockID, string FlatID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatDemandDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@DemandID", string.IsNullOrWhiteSpace(ID) ? (object)DBNull.Value : Convert.ToInt32(ID)));
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(PID) ? (object)DBNull.Value : Convert.ToInt32(PID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockNo", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }





    public int AddFlatCustomerDemands(int FlatID, int paymentID, string pdfname, int ProjectID, int Blockno, string AddedBy, string Paymentstatus, string Amount, int PSID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomerDemands", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));
                command.Parameters.Add(new SqlParameter("@PaymentLabelID", paymentID));
                command.Parameters.Add(new SqlParameter("@PDFName", pdfname));
                command.Parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                command.Parameters.Add(new SqlParameter("@Amount", Amount));
                command.Parameters.Add(new SqlParameter("@PSID", PSID));
                command.Parameters.Add(new SqlParameter("@BlockNo", Blockno));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", Paymentstatus));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }


    public int UpdateFlatCostDetails(int DemanID, string pdfname, string updatedby)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatCustomerDemandsPDF", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DemandID", DemanID));
                command.Parameters.Add(new SqlParameter("@PDFName", pdfname));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedBy", updatedby));
                command.Parameters.Add(new SqlParameter("@PaymentUpdatedDate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }



    public DataTable AlreadyExistFlatCustomerDemandsByPaymentLabelIDFlatID(int ID, int PaymentLabelID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistFlatCustomerDemandsByPaymentLabelIDFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", ID));
                command.Parameters.Add(new SqlParameter("@PaymentLabelID", PaymentLabelID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }






}