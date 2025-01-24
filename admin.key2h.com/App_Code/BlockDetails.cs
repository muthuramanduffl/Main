using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BlockDetails
{
    public string ProjectName { get; set; }
    public string BlockNumber { get; set; }
    public int Status { get; set; }
    public DateTime AddedDate { get; set; }
    public string AddedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }

    // Constructor
    public BlockDetails(string projectName, string blockNumber, string addedBy)
    {
        ProjectName = projectName;
        BlockNumber = blockNumber;
        Status = 1; // Assuming 1 means active
        AddedDate = DateTime.Now;
        AddedBy = addedBy;
        UpdatedDate = null;
        UpdatedBy = null;
    }

    // Method to insert block details into the database
    public bool SaveToDatabase(string connectionString)
    {
        string insertQuery = "INSERT INTO BlockDetails (ProjectName, BlockNumber, Status, AddedDate, AddedBy, UpdatedDate, UpdatedBy) " +
                             "VALUES (@ProjectName, @BlockNumber, @Status, @AddedDate, @AddedBy, @UpdatedDate, @UpdatedBy)";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@ProjectName", ProjectName);
                    command.Parameters.AddWithValue("@BlockNumber", BlockNumber);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@AddedDate", AddedDate);
                    command.Parameters.AddWithValue("@AddedBy", AddedBy);
                    command.Parameters.AddWithValue("@UpdatedDate", (object)UpdatedDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UpdatedBy", (object)UpdatedBy ?? DBNull.Value);

                    // Open the connection and execute the query
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return true; // Successfully inserted
        }
        catch (Exception)
        {
            return false; // Error occurred
        }
    }
}
