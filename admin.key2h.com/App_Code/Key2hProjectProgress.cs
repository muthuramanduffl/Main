using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;




/// <summary>
/// Summary description for Key2hProjectProgress
/// </summary>
public class Key2hProjectProgress
{


    public int intProjectID { get; set; }
    public int intProgressID { get; set; }
    public int intDisplayOrder { get; set; }
    public string strMonth { get; set; }
    public string stryear { get; set; }
    public string strThumbnailimage { get; set; }
    public string strImagename { get; set; }
    public string strContent { get; set; }
    public bool blstatus { get; set; }
    public string strAddedBy { get; set; }
    public string strUpdatedBy { get; set; }



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


    public int AddProjrctProgress(Key2hProjectProgress KPP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {

            using (SqlCommand command = new SqlCommand("Addprojectprogress", cnn))
            {
                cnn.Open();


                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", KPP.intProjectID));
                command.Parameters.Add(new SqlParameter("@Month", KPP.strMonth));
                command.Parameters.Add(new SqlParameter("@Year", KPP.stryear));
                command.Parameters.Add(new SqlParameter("@ThumbnailImage", strThumbnailimage));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@AddedBy", strAddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));

                SqlParameter outputIdParam = new SqlParameter("@ProgressID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();
                KPP.intProgressID = (int)outputIdParam.Value;

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return KPP.intProgressID;
    }

    public int Updateprojectprogress(Key2hProjectProgress KPP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {

            using (SqlCommand command = new SqlCommand("Updateprojectprogress", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProgressID", KPP.intProgressID));
                command.Parameters.Add(new SqlParameter("@ThumbnailImage", KPP.strThumbnailimage));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KPP.strUpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime)); 
                command.ExecuteNonQuery();             
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return KPP.intProgressID;
    }

    public int AddProjrctProgressImages(Key2hProjectProgress KPP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            cnn.Open();
            using (SqlCommand command = new SqlCommand("Addprojectprogressimage", cnn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProgressID", KPP.intProgressID));
                command.Parameters.Add(new SqlParameter("@ImageName", KPP.strImagename));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@Content", KPP.strContent));
                command.Parameters.Add(new SqlParameter("@DisplayOrder", KPP.intDisplayOrder));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public DataTable ViewProjectprogressImagesByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectprogressImagesByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(Dt);
            }

            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return Dt;
    }

    public DataTable AlreadyExistProjectProgressByProjectIDandDate(int ID, string Month, int Year)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistProjectProgressByProjectIDandDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ID));
                command.Parameters.Add(new SqlParameter("@Month", Month));
                command.Parameters.Add(new SqlParameter("@year", Year));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(Dt);
            }
        }
        catch (Exception ex)
        {
        }
        return Dt;
    }

    public DataTable ViewProjectprogressByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectprogressByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(Dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return Dt;
    }


    public int UpdateProjectprogressImagesByID(List<Key2hProjectProgress> KPP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            cnn.Open();
            foreach (var PPImage in KPP)
            {
                using (SqlCommand command = new SqlCommand("UpdateProjectprogressImagesByID", cnn))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", PPImage.intProgressID));
                    command.Parameters.Add(new SqlParameter("@ImageName", PPImage.strImagename));
                    command.Parameters.Add(new SqlParameter("@Content", PPImage.strContent));
                    rowaffected += command.ExecuteNonQuery();
                }
            }

            if (rowaffected == KPP.Count)
                rowaffected = 1;
            else
                rowaffected = 0;


            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowaffected;
    }

    public int UpdateProjectprogressByID(int ID, string imagename)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProjectprogressByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                command.Parameters.Add(new SqlParameter("@ImageName", imagename));
                rowaffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowaffected;
    }



    public int DeleteProjectprogressImagesByID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteProjectprogressImagesByID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                rowaffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowaffected;
    }
    public int DeleteProjectProgressByProgressID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteProjectProgressByProgressID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProgressID", ID));
                rowaffected = command.ExecuteNonQuery();
            }

            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowaffected;
    }

    public DataTable ViewAllProjectProgress(string Year, string Month, string ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllProjectProgress", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Month", Month));
                command.Parameters.Add(new SqlParameter("@Year", string.IsNullOrWhiteSpace(Year) ? (object)DBNull.Value : Convert.ToInt32(Year)));
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {

        }

        return dt;
    }
    public DataTable ViewprojectImageByprogressID(int ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewprojectImageByprogressID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@progressID", ProID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }        
    public DataTable ViewProjectprojectID(int ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewProjectprojectID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ProID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }


     public DataTable ViewprojectImageByprogressImageID(int ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewprojectImageByprogressImageID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@progressImageID", ProID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
















}