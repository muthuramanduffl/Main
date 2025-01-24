using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Key2hFlat
/// </summary>
public class Key2hFlat
{

    public int FlatID { get; set; }
    public int BlockID { get; set; }
    public int ProjectID { get; set; }
    public string FlatName { get; set; }
    public string Facing { get; set; }
    public string UDS { get; set; }
    public string UnitType { get; set; }
    public string SaleableArea { get; set; }

    public string CarpetArea { get; set; }
    public string Balcony { get; set; }
    public string Wallarea { get; set; }
    public string CommonArea { get; set; }
    public int CarparkingCount { get; set; }
    public string Carparkslot1 { get; set; }
    public string Carparkslot2 { get; set; }
    public string Carparkslot3 { get; set; }
    public string AddedBy { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool FlatStatus { get; set; }
    public int Floor { get; set; }


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




    public int AddFlatdetails(Key2hFlat FL)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("addFlatdetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BlockID", FL.BlockID));
                command.Parameters.Add(new SqlParameter("@ProjectID", FL.ProjectID));
                command.Parameters.Add(new SqlParameter("@FlatName", FL.FlatName));
                command.Parameters.Add(new SqlParameter("@Facing", FL.Facing));
                command.Parameters.Add(new SqlParameter("@UDS", FL.UDS));
                command.Parameters.Add(new SqlParameter("@UnitType", FL.UnitType));
                command.Parameters.Add(new SqlParameter("@SaleableArea", FL.SaleableArea));
                command.Parameters.Add(new SqlParameter("@CarpetArea", FL.CarpetArea));
                command.Parameters.Add(new SqlParameter("@Balcony", FL.Balcony));
                command.Parameters.Add(new SqlParameter("@Wallarea", FL.Wallarea));

                command.Parameters.Add(new SqlParameter("@CarparkingCount", FL.CarparkingCount));
                command.Parameters.Add(new SqlParameter("@Carparkslot1", FL.Carparkslot1));
                command.Parameters.Add(new SqlParameter("@Carparkslot2", FL.Carparkslot2));
                command.Parameters.Add(new SqlParameter("@Carparkslot3", FL.Carparkslot3));
                command.Parameters.Add(new SqlParameter("@FlatStatus", FL.FlatStatus));
                command.Parameters.Add(new SqlParameter("@Floor", FL.Floor));
                command.Parameters.Add(new SqlParameter("@AddedBy", FL.AddedBy));
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


    public int UpdateFlatdetails(Key2hFlat FL)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatdetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", FL.FlatID));
                command.Parameters.Add(new SqlParameter("@BlockID", FL.BlockID));
                command.Parameters.Add(new SqlParameter("@ProjectID", FL.ProjectID));
                command.Parameters.Add(new SqlParameter("@FlatName", FL.FlatName));
                command.Parameters.Add(new SqlParameter("@Facing", FL.Facing));
                command.Parameters.Add(new SqlParameter("@UDS", FL.UDS));
                command.Parameters.Add(new SqlParameter("@UnitType", FL.UnitType));
                command.Parameters.Add(new SqlParameter("@SaleableArea", FL.SaleableArea));
                command.Parameters.Add(new SqlParameter("@CarpetArea", FL.CarpetArea));
                command.Parameters.Add(new SqlParameter("@Balcony", FL.Balcony));
                command.Parameters.Add(new SqlParameter("@Wallarea", FL.Wallarea));
                command.Parameters.Add(new SqlParameter("@CarparkingCount", FL.CarparkingCount));
                command.Parameters.Add(new SqlParameter("@Carparkslot1", FL.Carparkslot1));
                command.Parameters.Add(new SqlParameter("@Carparkslot2", FL.Carparkslot2));
                command.Parameters.Add(new SqlParameter("@Carparkslot3", FL.Carparkslot3));
                command.Parameters.Add(new SqlParameter("@FlatStatus", FL.FlatStatus));
                command.Parameters.Add(new SqlParameter("@Floor", FL.Floor));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", FL.UpdatedBy));
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



    public DataTable AlreadyExistFlat(int pID, int BlockID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("FlatAlreadyExist", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", pID));
                command.Parameters.Add(new SqlParameter("@BlockID", BlockID));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }




    public DataTable ViewAllBflat(string BID, string Flatstatus, string FID, string ProID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllProjectFlat", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FID) ? (object)DBNull.Value : Convert.ToInt32(FID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BID) ? (object)DBNull.Value : Convert.ToInt32(BID)));
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProID) ? (object)DBNull.Value : Convert.ToInt32(ProID)));

                if (string.IsNullOrEmpty(Flatstatus) || Flatstatus == "All")
                {
                    command.Parameters.Add(new SqlParameter("@FlatStatus", DBNull.Value));
                }
                else
                {
                    if (Flatstatus == "1")
                        command.Parameters.Add(new SqlParameter("@FlatStatus", Convert.ToBoolean(true)));
                    else
                        command.Parameters.Add(new SqlParameter("@FlatStatus", Convert.ToBoolean(false)));
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }
    public DataTable ViewAllflatByBlockID(int BID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatByBlockID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BlockID", BID));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    public DataTable ViewAllFlatByFlatID(int FID)
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatByFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", FID));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }
      
    
    public DataTable ViewUnitdType()
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewUnitdType", cnn))
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
    
    
    public DataTable ViewFlatHouseFacing()
    {
        string connectionString = GetSqlConnection();
        SqlConnection cnn = new SqlConnection(connectionString);
        DataTable dt = new DataTable();

        try
        {
            using (SqlCommand command = new SqlCommand("ViewFlatHouseFacing", cnn))
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






    public int DeleteFlatbyflatID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;

        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatbyflatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", ID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }
    



    public int FlatCountGetByPIDandABy(string ProjectID,string BLockID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int ProID = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("FlatCountGetByPIDandABy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(ProjectID) ? (object)DBNull.Value : Convert.ToInt32(ProjectID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BLockID) ? (object)DBNull.Value : Convert.ToInt32(BLockID)));
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