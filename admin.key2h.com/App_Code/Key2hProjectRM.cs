using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;


/// <summary>
/// Summary description for Key2hProjectRM
/// </summary>
public class Key2hProjectRM
{

    public int ProjectID { get; set; }
    public int ClientID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string WhatsappNumber { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public string Salutation { get; set; }
    public string UserEmailId { get; set; }
    public string Phonenumber { get; set; }
    public int UserID { get; set; }
    public string AddedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string Photo { get; set; }
    public bool UserStatus { get; set; }
    public string LeadSourceName { get; set; }
    public bool LeadSourceStatus { get; set; }
    public int LeadID { get; set; }


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


    public int AddRMDetails(Key2hProjectRM K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddRMDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", K2.ClientID));
                command.Parameters.Add(new SqlParameter("@Username", K2.Username));
                command.Parameters.Add(new SqlParameter("@Whatsappnumber", K2.WhatsappNumber));
                command.Parameters.Add(new SqlParameter("@Gender", K2.Gender));
                command.Parameters.Add(new SqlParameter("@Salutation", K2.Salutation));
                command.Parameters.Add(new SqlParameter("@UserEmailId", K2.UserEmailId));
                command.Parameters.Add(new SqlParameter("@Role", K2.Role));
                command.Parameters.Add(new SqlParameter("@Phonenumber", K2.Phonenumber));
                command.Parameters.Add(new SqlParameter("@Name", K2.Name));
                command.Parameters.Add(new SqlParameter("@Password", K2.Password));
                command.Parameters.Add(new SqlParameter("@UserStatus", K2.UserStatus));
                command.Parameters.Add(new SqlParameter("@Photo", K2.Photo));

                command.Parameters.Add(new SqlParameter("@AddedBy", K2.AddedBy));
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

    public int UpdateRMDetails(Key2hProjectRM K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateRMDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RMID", K2.UserID));
                command.Parameters.Add(new SqlParameter("@Username", K2.Username));
                command.Parameters.Add(new SqlParameter("@Whatsappnumber", K2.WhatsappNumber));
                command.Parameters.Add(new SqlParameter("@Gender", K2.Gender));
                command.Parameters.Add(new SqlParameter("@Salutation", K2.Salutation));
                command.Parameters.Add(new SqlParameter("@UserEmailId", K2.UserEmailId));
                command.Parameters.Add(new SqlParameter("@Role", K2.Role));
                command.Parameters.Add(new SqlParameter("@Phonenumber", K2.Phonenumber));
                command.Parameters.Add(new SqlParameter("@Name", K2.Name));
                command.Parameters.Add(new SqlParameter("@Password", K2.Password));
                command.Parameters.Add(new SqlParameter("@UserStatus", K2.UserStatus));
                command.Parameters.Add(new SqlParameter("@Photo", K2.Photo));

                command.Parameters.Add(new SqlParameter("@UpdatedBy", K2.UpdatedBy));
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

    public DataTable ViewRMDetailbyRMID(int UserID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewRMDetailbyRMID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RMID", UserID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewAllRMDetails()
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllRMDetails", cnn))
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

    public DataTable ViewAllUserDetails()
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllUserDetails", cnn))
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

    public int DisableRMbyRMID(int UserID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DisableRMbyRMID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RMID", UserID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }

    public int AddLeadSource(Key2hProjectRM K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddLeadSource", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", K2.ClientID));
                command.Parameters.Add(new SqlParameter("@LeadSourceName", K2.LeadSourceName));
                command.Parameters.Add(new SqlParameter("@LeadSourceStatus", K2.LeadSourceStatus));
                command.Parameters.Add(new SqlParameter("@AddedBy", K2.AddedBy));
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

    public DataTable AlreadyExistsLeadSourceName(string LeadSourceName)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistsLeadSourceName", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LeadSourceName", LeadSourceName));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewAllLeadSources()
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllLeadSources", cnn))
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
    public int UpdateLeadSourceName(Key2hProjectRM K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateLeadSourceName", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LeadID", K2.LeadID));
                command.Parameters.Add(new SqlParameter("@LeadSourceName", K2.LeadSourceName));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }




    

}