using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hcustomizationWork
/// </summary>
public class Key2hcustomizationWork
{



    public int intFlatID { get; set; }


    public int intCWID { get; set; }
    public string strAddedBy { get; set; }
    public string strUpdatedBy { get; set; }
    public string strAmount { get; set; }
    public string strWorkTitle { get; set; }
    public string strWorkStatus { get; set; }



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


    public int AddCustomWorkdetails(Key2hcustomizationWork KW)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddCustomWorkdetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KW.intFlatID));
                command.Parameters.Add(new SqlParameter("@WorkTitle", KW.strWorkTitle));
                command.Parameters.Add(new SqlParameter("@WorkStatus", KW.strWorkStatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", KW.strAddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@Amount", KW.strAmount));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }



    public DataTable ViewAllFlatCustomizationWorks(string ProID, string BlockID, string FlatID, string CWID, string AddedBy)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomizationWorks", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
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


    public DataTable ViewAllFlatCustomisationWorksByFlatID(string FlatID, string Addedby)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomisationWorksByFlatID", cnn))
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
    
    
    public DataTable ViewCustomizationWorkProgressStatus(string id)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCustomizationWorkProgressStatus", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;                
                command.Parameters.Add(new SqlParameter("@ID", string.IsNullOrWhiteSpace(id) ? (object)DBNull.Value : Convert.ToInt32(id)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }




    public int DeleteFlatCustomizationWorksTitle(int flatID, int CWID)
    {
        int rowaffected = 0;
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatCustomizationWorksTitle", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@CWID", CWID));
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