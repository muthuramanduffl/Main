using System;
using System.Data.SqlClient;
using System.Data;

using System.Web;





/// <summary>
/// Summary description for ClientUsers
/// </summary>
public class ClientUsers
{
    public string username { get; set; }
    public string password { get; set; }
    public object Request { get; private set; }




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





    public string GetClientLoginID()
    {
        string strClientID = string.Empty;
        try
        {

            HttpCookie LoginIDCookie = HttpContext.Current.Request.Cookies["clientid"];

            if (LoginIDCookie != null)
            {
                strClientID = LoginIDCookie.Value;
            }
        }
        catch
        {
        }
        return strClientID;
    }


    public string GetClientLoginEmailID()
    {
        string strClientID = string.Empty;
        try
        {

            HttpCookie EmailidCookie = HttpContext.Current.Request.Cookies["EmailID"];

            if (EmailidCookie != null)
            {
                strClientID = EmailidCookie.Value;
            }
        }
        catch
        {
        }
        return strClientID;
    }

    public string GetClientLoginUsername()
    {
        string strClientID = string.Empty;
        try
        {

            HttpCookie UsernameCookie = HttpContext.Current.Request.Cookies["Username"];

            if (UsernameCookie != null)
            {
                strClientID = UsernameCookie.Value;
            }
        }
        catch
        {
        }
        return strClientID;
    }

    public string GetClientRole()
    {
        string strRole = string.Empty;
        try
        {

            HttpCookie UsernameCookie = HttpContext.Current.Request.Cookies["Role"];

            if (UsernameCookie != null)
            {
                strRole = UsernameCookie.Value;
            }
        }
        catch
        {
        }
        return strRole;
    }





    public DataTable ViewValidClientUserLogin(ClientUsers CU)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewValidClientUserLogin", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", CU.username));
                command.Parameters.Add(new SqlParameter("@Password", CU.password));
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