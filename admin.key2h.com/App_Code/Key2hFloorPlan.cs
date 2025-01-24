
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hFloorPlan
/// </summary>
public class Key2hFloorPlan
{
    public int ProjectID { get; set; }
    public int FloorPlanID { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public bool Status { get; set; }

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

    public int AddProjectFloorPlan(Key2hFloorPlan K2)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddProjectFloorPlan", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", K2.ProjectID));
                command.Parameters.Add(new SqlParameter("@Title", K2.Title));
                command.Parameters.Add(new SqlParameter("@ImagePath", K2.ImagePath));
                command.Parameters.Add(new SqlParameter("@Status", K2.Status));
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

    public int UpdateProjectFloorPlan(Key2hFloorPlan K2)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        int rowsAffected = 0;

        try
        {
            using (SqlCommand command = new SqlCommand("UpdateProjectFloorPlan", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FloorPlanID", K2.FloorPlanID));
                command.Parameters.Add(new SqlParameter("@Title", K2.Title));
                command.Parameters.Add(new SqlParameter("@ImagePath", K2.ImagePath));
                SqlDataAdapter da = new SqlDataAdapter(command);
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {

        }

        return rowsAffected;
    }

    public DataTable ViewAllProjectFloorPlans()
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllProjectFloorPlans", cnn))
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

    public DataTable ViewAllProjectFloorPlansbyProjectID(int ProjectID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllProjectFloorPlansbyProjectID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", ProjectID));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    public int DeleteProjectFloorPlanbyFloorPlanID(int FloorPlanID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteProjectFloorPlanbyFloorPlanID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@FloorPlanID", FloorPlanID));
                rowaffected =command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }

    public int DeleteProjectFloorPlanbyProjectID(int ProjectID)
    {
        int rowaffected = 0;

        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteProjectFloorPlanbyProjectID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.Parameters.Add(new SqlParameter("@ProjectID", ProjectID));
                rowaffected =command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }

        return rowaffected;
    }


}