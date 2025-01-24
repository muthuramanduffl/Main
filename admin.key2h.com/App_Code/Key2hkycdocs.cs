using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Common;

/// <summary>
/// Summary description for Key2hkycdocs
/// </summary>
public class Key2hkycdocs
{

    public int intDocID { get; set; }
    public int intFlatID { get; set; }
    public int intProjectID { get; set; }
    public string strSaleDeedDraft { get; set; }
    public string strSaleDeedFinal { get; set; }
    public string strSaleAgreementDraft { get; set; }
    public string strSaleAgreementFinal { get; set; }
    public string strAllotmentLetter { get; set; }
    public string strWelcomeLetter { get; set; }
    public string strDemandLetter { get; set; }
    public string strPaymentReceipt { get; set; }
    public string strBill { get; set; }
    public string strPaymentSchedule { get; set; }
    public string strEBCard { get; set; }
    public string strHandingOverDocs { get; set; }
    public string strCCUpdation { get; set; }
    public string strNOCforHandover { get; set; }
    public string strOtherDocuments { get; set; }
    public string strBankDocuments { get; set; }
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



    public int AddDataFlatCustomerKYCDocs(Key2hkycdocs KYC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomerKYCDocs", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", KYC.intProjectID));
                command.Parameters.Add(new SqlParameter("@FlatID", KYC.intFlatID));
                command.Parameters.Add(new SqlParameter("@SaleDeedDraft", KYC.strSaleDeedDraft));
                command.Parameters.Add(new SqlParameter("@SaleDeedFinal", KYC.strSaleDeedFinal));
                command.Parameters.Add(new SqlParameter("@SaleAgreementDraft", KYC.strSaleAgreementDraft));
                command.Parameters.Add(new SqlParameter("@SaleAgreementFinal", KYC.strSaleAgreementFinal));
                command.Parameters.Add(new SqlParameter("@AllotmentLetter", KYC.strAllotmentLetter));
                command.Parameters.Add(new SqlParameter("@WelcomeLetter", KYC.strWelcomeLetter));
                command.Parameters.Add(new SqlParameter("@DemandLetter", KYC.strDemandLetter));
                command.Parameters.Add(new SqlParameter("@PaymentReceipt", KYC.strPaymentReceipt));
                command.Parameters.Add(new SqlParameter("@Bill", KYC.strBill));
                command.Parameters.Add(new SqlParameter("@PaymentSchedule", KYC.strPaymentSchedule));
                command.Parameters.Add(new SqlParameter("@EBCard", KYC.strEBCard));
                command.Parameters.Add(new SqlParameter("@HandingOverDocs", KYC.strHandingOverDocs));
                command.Parameters.Add(new SqlParameter("@CCUpdation", KYC.strCCUpdation));
                command.Parameters.Add(new SqlParameter("@NOCforHandover", KYC.strNOCforHandover));
                command.Parameters.Add(new SqlParameter("@OtherDocuments", KYC.strOtherDocuments));
                command.Parameters.Add(new SqlParameter("@BankDocuments", KYC.strBankDocuments));
                command.Parameters.Add(new SqlParameter("@AddedBy", KYC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@Addeddate", Utility.IndianTime));
                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;

    }

    public int UpdateFlatCustomerKYCDocs(Key2hkycdocs KYC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatCustomerKYCDocs", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DocID", KYC.intDocID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KYC.intProjectID));
                command.Parameters.Add(new SqlParameter("@FlatID", KYC.intFlatID));
                command.Parameters.Add(new SqlParameter("@SaleDeedDraft", KYC.strSaleDeedDraft));
                command.Parameters.Add(new SqlParameter("@SaleDeedFinal", KYC.strSaleDeedFinal));
                command.Parameters.Add(new SqlParameter("@SaleAgreementDraft", KYC.strSaleAgreementDraft));
                command.Parameters.Add(new SqlParameter("@SaleAgreementFinal", KYC.strSaleAgreementFinal));
                command.Parameters.Add(new SqlParameter("@AllotmentLetter", KYC.strAllotmentLetter));
                command.Parameters.Add(new SqlParameter("@WelcomeLetter", KYC.strWelcomeLetter));
                command.Parameters.Add(new SqlParameter("@DemandLetter", KYC.strDemandLetter));
                command.Parameters.Add(new SqlParameter("@PaymentReceipt", KYC.strPaymentReceipt));
                command.Parameters.Add(new SqlParameter("@Bill", KYC.strBill));
                command.Parameters.Add(new SqlParameter("@PaymentSchedule", KYC.strPaymentSchedule));
                command.Parameters.Add(new SqlParameter("@EBCard", KYC.strEBCard));
                command.Parameters.Add(new SqlParameter("@HandingOverDocs", KYC.strHandingOverDocs));
                command.Parameters.Add(new SqlParameter("@CCUpdation", KYC.strCCUpdation));
                command.Parameters.Add(new SqlParameter("@NOCforHandover", KYC.strNOCforHandover));
                command.Parameters.Add(new SqlParameter("@OtherDocuments", KYC.strOtherDocuments));
                command.Parameters.Add(new SqlParameter("@BankDocuments", KYC.strBankDocuments));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KYC.strUpdatedBy));
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






    public bool CheckRecordExistsFlatCustomerKYCDocsByFlatIDandAddedBy(string FlatID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        bool exists = false;
        try
        {
            using (SqlCommand command = new SqlCommand("CheckRecordExistsFlatCustomerKYCDocsByFlatIDandAddedBy", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                exists = Convert.ToBoolean(command.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {

        }
        return exists;
    }


    public DataTable ViewAllFlatCustomerKYCDocs(string PrID, string BlockID, string FlatID, string DocID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        bool exists = false;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomerKYCDocs", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(PrID) ? (object)DBNull.Value : Convert.ToInt32(PrID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(BlockID) ? (object)DBNull.Value : Convert.ToInt32(BlockID)));
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(FlatID) ? (object)DBNull.Value : Convert.ToInt32(FlatID)));
                command.Parameters.Add(new SqlParameter("@DocID", string.IsNullOrWhiteSpace(DocID) ? (object)DBNull.Value : Convert.ToInt32(DocID)));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                SqlDataAdapter Da = new SqlDataAdapter(command);
                Da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }




    public int DeleteKYCByDocID(int DocID, string AddedBy)
    {
        DataTable dt = new DataTable();
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteKYCByDocID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DocID", DocID));
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                rowAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowAffected;
    }

}