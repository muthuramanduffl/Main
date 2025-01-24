using System;
using System.Activities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Common;

/// <summary>
/// Summary description for Key2hProject
/// </summary>
public class Key2hProject
{

    public int ProjectID { get; set; }
    public int ClientID { get; set; }
    public string ProjectName { get; set; }
    public string ProjectLogo { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public int State { get; set; }
    public int City { get; set; }
    public int PostalCode { get; set; }
    public string GoogleMapLink { get; set; }
    public int BlockCount { get; set; }
    public int FlatCount { get; set; }
    public string LandArea { get; set; }
    public string RERANumber { get; set; }
    public int ProjectStatus { get; set; }
    public bool ProjectDisplayStatus { get; set; }
    public int ProjectStatusPercentage { get; set; }
    public string SplashScreenImage { get; set; }
    public string LocationMap { get; set; }
    public string BankName { get; set; }
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public string IFSCNumber { get; set; }
    public string BranchName { get; set; }
    public string AddedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string MessageContent { get; set; }
    public string Question { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string BHK { get; set; }
    public string Sqft { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string AddedDate { get; set; }
    public int ReferScreenID { get; set; }


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


    public int AddPROJECTS(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        int projectId = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddProjects", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", K2.ClientID));
                command.Parameters.Add(new SqlParameter("@ProjectName", K2.ProjectName));
                command.Parameters.Add(new SqlParameter("@ProjectLogo", K2.ProjectLogo));
                command.Parameters.Add(new SqlParameter("@Location", K2.Location));
                command.Parameters.Add(new SqlParameter("@Address", K2.Address));
                command.Parameters.Add(new SqlParameter("@State", K2.State));
                command.Parameters.Add(new SqlParameter("@City", K2.City));
                command.Parameters.Add(new SqlParameter("@PostalCode", K2.PostalCode));
                command.Parameters.Add(new SqlParameter("@GoogleMapLink", K2.GoogleMapLink));
                command.Parameters.Add(new SqlParameter("@BlockCount", K2.BlockCount));
                command.Parameters.Add(new SqlParameter("@FlatCount", K2.FlatCount));
                command.Parameters.Add(new SqlParameter("@LandArea", K2.LandArea));
                command.Parameters.Add(new SqlParameter("@RERANumber", K2.RERANumber));
                command.Parameters.Add(new SqlParameter("@ProjectStatus", K2.ProjectStatus));
                command.Parameters.Add(new SqlParameter("@ProjectDisplayStatus", K2.ProjectDisplayStatus));
                command.Parameters.Add(new SqlParameter("@ProjectStatusPercentage", K2.ProjectStatusPercentage));
                command.Parameters.Add(new SqlParameter("@SplashScreenImage", K2.SplashScreenImage));
                command.Parameters.Add(new SqlParameter("@LocationMap", K2.LocationMap));
                command.Parameters.Add(new SqlParameter("@BankName", K2.BankName));
                command.Parameters.Add(new SqlParameter("@AccountName", K2.AccountName));
                command.Parameters.Add(new SqlParameter("@AccountNumber", K2.AccountNumber));
                command.Parameters.Add(new SqlParameter("@IFSCNumber", K2.IFSCNumber));
                command.Parameters.Add(new SqlParameter("@BranchName", K2.BranchName));
                command.Parameters.Add(new SqlParameter("@Longitude", K2.Longitude));
                command.Parameters.Add(new SqlParameter("@Latitude", K2.Latitude));
                command.Parameters.Add(new SqlParameter("@BHKTypes", K2.BHK));
                command.Parameters.Add(new SqlParameter("@SquareFeetRange", K2.Sqft));
                command.Parameters.Add(new SqlParameter("@AddedBy", K2.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                SqlParameter outputId = new SqlParameter("@ProjectID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);


                command.ExecuteNonQuery();
                projectId = Convert.ToInt32(outputId.Value);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return projectId;

    }

    public int AddProjectHomeScreen(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddProjectHomeScreen", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@FlatCount", K2.FlatCount));
                command.Parameters.Add(new SqlParameter("@BHK", K2.BHK));
                command.Parameters.Add(new SqlParameter("@Sqft", K2.Sqft));
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




    public int UpdatePROJECTS(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProjects", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@ClientID", K2.ClientID));
                command.Parameters.Add(new SqlParameter("@ProjectName", K2.ProjectName));
                command.Parameters.Add(new SqlParameter("@ProjectLogo", K2.ProjectLogo));
                command.Parameters.Add(new SqlParameter("@Location", K2.Location));
                command.Parameters.Add(new SqlParameter("@Address", K2.Address));
                command.Parameters.Add(new SqlParameter("@State", K2.State));
                command.Parameters.Add(new SqlParameter("@City", K2.City));
                command.Parameters.Add(new SqlParameter("@PostalCode", K2.PostalCode));
                command.Parameters.Add(new SqlParameter("@GoogleMapLink", K2.GoogleMapLink));
                command.Parameters.Add(new SqlParameter("@BlockCount", K2.BlockCount));
                command.Parameters.Add(new SqlParameter("@FlatCount", K2.FlatCount));
                command.Parameters.Add(new SqlParameter("@LandArea", K2.LandArea));
                command.Parameters.Add(new SqlParameter("@RERANumber", K2.RERANumber));
                command.Parameters.Add(new SqlParameter("@ProjectStatus", K2.ProjectStatus));
                command.Parameters.Add(new SqlParameter("@ProjectDisplayStatus", K2.ProjectDisplayStatus));
                command.Parameters.Add(new SqlParameter("@ProjectStatusPercentage", K2.ProjectStatusPercentage));
                command.Parameters.Add(new SqlParameter("@SplashScreenImage", K2.SplashScreenImage));
                command.Parameters.Add(new SqlParameter("@LocationMap", K2.LocationMap));
                command.Parameters.Add(new SqlParameter("@BankName", K2.BankName));
                command.Parameters.Add(new SqlParameter("@AccountName", K2.AccountName));
                command.Parameters.Add(new SqlParameter("@AccountNumber", K2.AccountNumber));
                command.Parameters.Add(new SqlParameter("@IFSCNumber", K2.IFSCNumber));
                command.Parameters.Add(new SqlParameter("@BranchName", K2.BranchName));
                command.Parameters.Add(new SqlParameter("@Longitude", K2.Longitude));
                command.Parameters.Add(new SqlParameter("@Latitude", K2.Latitude));
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


    public int UpdateProjectHomeScreen(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProjectHomeScreen", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@BHK", K2.BHK));
                command.Parameters.Add(new SqlParameter("@Sqft", K2.Sqft));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", K2.UpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public DataTable ViewAllProjects(string ID, string status, string prstatus)
    {
        string connectionString = GetSqlConnection();
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("ViewAllProjects", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Handle ProjectID
                if (string.IsNullOrEmpty(ID) || ID == "All")
                {
                    command.Parameters.Add(new SqlParameter("@ProjectID", DBNull.Value)); // Pass NULL
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@ProjectID", Convert.ToInt32(ID)));
                }

                // Handle Status
                if (string.IsNullOrEmpty(status) || status == "All")
                {
                    command.Parameters.Add(new SqlParameter("@Status", DBNull.Value)); // Pass NULL
                }
                else
                {
                    if (status == "1")
                        command.Parameters.Add(new SqlParameter("@Status", Convert.ToBoolean(true)));
                    else
                        command.Parameters.Add(new SqlParameter("@Status", Convert.ToBoolean(false)));

                }

                // Handle ProjectStatus
                if (string.IsNullOrEmpty(prstatus) || prstatus == "All")
                {
                    command.Parameters.Add(new SqlParameter("@Projectstatus", DBNull.Value)); // Pass NULL
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@Projectstatus", Convert.ToInt32(prstatus)));
                }

                // Execute command and fill DataTable
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    cnn.Open();
                    da.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception for debugging
            Console.WriteLine("Error: " + ex.Message);
        }

        return dt;
    }


    public DataTable ViewAllProjectsByid(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectsByID", cnn))
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



    public DataTable ViewAllstate()
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllState", cnn))
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


    public DataTable ViewActiveprojects()
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewActiveprojects", cnn))
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


    public DataTable ViewstateByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewStateByStateID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StateID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewAllcityByStateid(int stateid)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllCityByStateID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@StateID", stateid));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewcityByCityid(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewCityByCityID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CityID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable AlreadyExistProjectNamebyClientID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistProjectNamebyClientID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClentID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public int AlreadyExistProjectNamebyIDandName(string ID, string projectname, string AddedBy)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int ret = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistProjectNamebyIDandName", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ID) ? (object)DBNull.Value : Convert.ToInt32(ID)));
                command.Parameters.Add(new SqlParameter("@ProjectName", projectname));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                ret = (int)command.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
        }
        return ret;
    }


    public int DeleteProjects(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteProjects", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }

    public DataTable ViewAllReferScreencontent(string ID)
    {
        string connectionString = GetSqlConnection();
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("ViewAllReferScreencontent", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Handle ProjectID
                if (string.IsNullOrEmpty(ID) || ID == "All")
                {
                    command.Parameters.Add(new SqlParameter("@ProjectID", DBNull.Value)); // Pass NULL
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@ProjectID", Convert.ToInt32(ID)));
                }

                // Execute command and fill DataTable
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    cnn.Open();
                    da.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception for debugging
            Console.WriteLine("Error: " + ex.Message);
        }

        return dt;
    }
    public int DeleteReferContentbyReferScreenID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteReferContentbyReferScreenID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ReferScreenID", ID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }

    public int AddReferScreenContent(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddReferScreenContent", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", K2.ClientID));
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@Image", K2.Image));
                command.Parameters.Add(new SqlParameter("@Question", K2.Question));
                command.Parameters.Add(new SqlParameter("@Content", K2.Content));
                command.Parameters.Add(new SqlParameter("@MessageContent", K2.MessageContent));
                command.Parameters.Add(new SqlParameter("@AddedBy", K2.AddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", K2.AddedDate));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }

    public int UpdateReferScreenContent(Key2hProject K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateReferScreenContent", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@ReferScreenID", K2.ReferScreenID));
                command.Parameters.Add(new SqlParameter("@Image", K2.Image));
                command.Parameters.Add(new SqlParameter("@Question", K2.Question));
                command.Parameters.Add(new SqlParameter("@Content", K2.Content));
                command.Parameters.Add(new SqlParameter("@MessageContent", K2.MessageContent));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }

    public DataTable AlreadyExistReferScreenbyProjectID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistReferScreenbyProjectID", cnn))
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

    public DataTable ViewReferScreenContentbyReferID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewReferScreenContentbyReferID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public int ProjectBlockCountGetByPIDandAby(string ProjectID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int ProID = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ProjectBlockCountGetByPIDandAby", cnn))
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