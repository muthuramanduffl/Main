using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hFlatProgress
/// </summary>
public class Key2hFlatProgress
{

    public int intProjectID { get; set; }
    public int intFlatProgressID { get; set; }
    public int intFlatID { get; set; }
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






    public int AddFlatProgress(Key2hFlatProgress KFP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {

            using (SqlCommand command = new SqlCommand("AddFlatProgress", cnn))
            {
                cnn.Open();


                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", KFP.intProjectID));
                command.Parameters.Add(new SqlParameter("@FlatID", KFP.intFlatID));
                command.Parameters.Add(new SqlParameter("@Month", KFP.strMonth));
                command.Parameters.Add(new SqlParameter("@Year", KFP.stryear));
                command.Parameters.Add(new SqlParameter("@ThumbnailImage", KFP.strThumbnailimage));
                command.Parameters.Add(new SqlParameter("@Status", true));
                command.Parameters.Add(new SqlParameter("@AddedBy", KFP.strAddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));

                SqlParameter outputIdParam = new SqlParameter("@FlatProgressID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();
                KFP.intFlatProgressID = (int)outputIdParam.Value;

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return KFP.intFlatProgressID;
    }


    public int AddFlatProgressImage(Key2hFlatProgress KFP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {

            using (SqlCommand command = new SqlCommand("AddFlatProgressImage", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProgressID", KFP.intFlatProgressID));
                command.Parameters.Add(new SqlParameter("@ImageName", KFP.strImagename));
                command.Parameters.Add(new SqlParameter("@Content", KFP.strContent));
                command.Parameters.Add(new SqlParameter("@status", true));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }

    public int Updateflatprogress(Key2hFlatProgress KFP)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {

            using (SqlCommand command = new SqlCommand("Updateflatprogress", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatProgressID", KFP.intFlatProgressID));
                command.Parameters.Add(new SqlParameter("@ThumbnailImage", KFP.strThumbnailimage));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KFP.strUpdatedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedDate", Utility.IndianTime));
              rowsAffected=command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }


    public DataTable AlreadyExistFlatProgressByPIDandFIDandDate(int PID, int FID, string Month, int Year)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyExistFlatProgressByPIDandFIDandDate", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", PID));
                command.Parameters.Add(new SqlParameter("@FlatID", FID));
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


    public DataTable ViewFlatImageByprogressID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatImageByprogressID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatProgressID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(Dt);
            }


        }
        catch (Exception ex)
        {
        }
        return Dt;
    }


    public DataTable ViewFlatprojectID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        DataTable Dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatprojectID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(Dt);
            }


        }
        catch (Exception ex)
        {
        }
        return Dt;
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
            using (SqlCommand command = new SqlCommand("DeleteFlatprogressImagesByID", cnn))
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


     public int DeleteFlatProgressByProgressID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowaffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatProgressByProgressID", cnn))
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




    public DataTable ViewAllFlatProgress(string Year, string Month, string ProID, string BlockID ,string FlatID,string ProgressID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatProgress", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Month", Month));
                command.Parameters.Add(new SqlParameter("@Year", string.IsNullOrWhiteSpace(Year) ? (object)DBNull.Value : Convert.ToInt32(Year)));
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@FlatProgressID", string.IsNullOrWhiteSpace(ProgressID) ? (object)DBNull.Value : Convert.ToInt32(ProgressID)));
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


    public DataTable ViewFlatImageByprogressImageID(int ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();
        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatImageByprogressImageID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatProgressImageID", ProID));
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