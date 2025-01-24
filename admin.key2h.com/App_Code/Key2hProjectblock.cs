using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hProjectblock
/// </summary>
public class Key2hProjectblock
{


    public int ProjectID { get; set; }
    public int BlcokID { get; set; }
    public string Blocknumber { get; set; }
    public bool Status { get; set; }
    public string Addedby { get; set; }
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







    public int Addblocks(Key2hProjectblock K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddProjectBlock", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@BlockName", K2.Blocknumber));
                command.Parameters.Add(new SqlParameter("@BlockStatus", true));
                command.Parameters.Add(new SqlParameter("@AddedBy", K2.Addedby));
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

    public int Updateblock(Key2hProjectblock K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProjectBlock", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BlockID", K2.BlcokID));
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@BlockName", K2.Blocknumber));
                command.Parameters.Add(new SqlParameter("@BlockStatus", true));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", K2.Addedby));
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
    public int DeleteBlockbyID(int id)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteBlockbyID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BlockID", id));

                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }





    public DataTable ViewAllBlock(string ID, string status, string prID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllBlock", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(ID) ? (object)DBNull.Value : Convert.ToInt32(ID)));

                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(prID) ? (object)DBNull.Value : Convert.ToInt32(prID)));


               
                if (string.IsNullOrEmpty(status) || status == "All")
                {
                    command.Parameters.Add(new SqlParameter("@BlockStatus", DBNull.Value)); 
                }
                else
                {
                    if (status == "1")
                        command.Parameters.Add(new SqlParameter("@BlockStatus", Convert.ToBoolean(true)));
                    else
                        command.Parameters.Add(new SqlParameter("@BlockStatus", Convert.ToBoolean(false)));
                }
                


              
                // Execute the query
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            // Log exception (ex.Message) here
        }

        return dt;
    }

    public DataTable BlockAlreadyExistByProjectid(int ID,string Blackname)
    {

        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("BlockAlreadyExistByProjectid", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ID));
                command.Parameters.Add(new SqlParameter("@BlockName", Blackname));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }


        return dt;
    } 
    
    
    public DataTable ViewBlockbyProjectID(int ID)
    {

        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBlockbyProjectID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }


        return dt;
    }
    



    public int BlockCountGetByPIDandABy(string ProjectID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int ProID = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("BlockCountGetByPIDandABy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProjectID) ? (object)DBNull.Value : Convert.ToInt32(ProjectID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                ProID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return ProID;
    }



}