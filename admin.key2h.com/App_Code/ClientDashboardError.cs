
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientdashboardIssue
/// </summary>
public class ClientDashboardError
{

    public string Pagename { get; set; }
    public string MethodOrFunctionname { get; set; }
    public string ErrrMsg { get; set; }
    public string IssueStatus { get; set; }



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




    


    public void StoreExceptionMessage(string pagename,string MethodOrFunctionaName,string ExceptionErrormsg,string IssueStatus)
    {

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("Clientdashboardissues", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Pagename", pagename));
                command.Parameters.Add(new SqlParameter("@MethodOrFunctionname", MethodOrFunctionaName));
                command.Parameters.Add(new SqlParameter("@ErrrMsg", ExceptionErrormsg));
                command.Parameters.Add(new SqlParameter("@IssueStatus", IssueStatus));
                command.Parameters.Add(new SqlParameter("@Addeddate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {

        }

    }





}