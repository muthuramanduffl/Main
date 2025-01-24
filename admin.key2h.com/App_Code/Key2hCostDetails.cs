using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Key2hCostDetails
/// </summary>
public class Key2hCostDetails
{



    public int intCostID { get; set; }
    public int intFlatID { get; set; }
    public int intBlockID { get; set; }
    public int intCostLabelID { get; set; }
    public int intCost { get; set; }
    public string strAddedBy { get; set; }
    public string strUpdatedBy { get; set; }
    public int intProjectID { get; set; }

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







    public int AddFlatCostDetails(Key2hCostDetails KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCostDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", KC.intFlatID));
                command.Parameters.Add(new SqlParameter("@BlockID", KC.intBlockID));
                command.Parameters.Add(new SqlParameter("@CostLabelID", KC.intCostLabelID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.intProjectID));
                command.Parameters.Add(new SqlParameter("@Cost", KC.intCost));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@addedBy", strAddedBy));
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
    public int UpdateFlatCostDetails(Key2hCostDetails KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatCostDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CostID", KC.intCostID));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.intFlatID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.intProjectID));
                command.Parameters.Add(new SqlParameter("@CostLabelID", KC.intCostLabelID));
                command.Parameters.Add(new SqlParameter("@Cost", KC.intCost));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.strUpdatedBy));
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
    public int UpdateFlatCost(Key2hCostDetails KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatCost", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@CostLabelID", KC.intCostLabelID));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.intFlatID));
                command.Parameters.Add(new SqlParameter("@Cost", KC.intCost));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.strUpdatedBy));
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
    public DataTable viewFlatCostDetails(int ID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("viewFlatCostDetailsByFlatID", cnn))
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
    public DataTable ViewAllFlatCostDetails(string ProID, string FlatID, string BlockID, string CostID)
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCostDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@CostID", string.IsNullOrWhiteSpace(CostID) ? (object)DBNull.Value : Convert.ToInt32(CostID)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    public DataTable ViewProjectCostLabels()
    {
        DataTable dt = new DataTable();

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectCostLabels", cnn))
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
    public DataTable AlreadyExistFlatCostByProIDBlockIDFlatID(int ProID, int Blockid, int FlatID)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistFlatCostByProIDBlockIDFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ProID));
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));
                command.Parameters.Add(new SqlParameter("@BlockID", Blockid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
        }

        return dt;
    }
    public int DeleteAllFlatCostDetails(int flatID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteAllFlatCostDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@FlatID", flatID));
                rowaffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }
    public int CheckFlatCostDetailsExistAllCostLabelParameterByFlatID(int flatID)
    {
        int value = 0;
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("CheckFlatCostDetailsExistAllCostLabelParameterByFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@FlatID", flatID));
                var result = command.ExecuteScalar();
                var Count = result != DBNull.Value && result != null ? (int)result : 2;// is default value
                value = Count;
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
        }

        return value;
    }
    public int DeleteFlatCostDetails(int CostID, int flatID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatCostDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@CostID", CostID));
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