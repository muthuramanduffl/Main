
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;




public class Key2hCustomer
{


    public int intFlatCustomerID { get; set; }
    public int intProjectID { get; set; }
    public int intstrBlockID { get; set; }
    public int intFlatID { get; set; }
    public string strApplicantFirstName { get; set; }
    public string strApplicantLastName { get; set; }
    public string strCoapplicantFirstName { get; set; }
    public string strCoapplicantLastName { get; set; }
    public string strGender { get; set; }
    public string strEmailID { get; set; }

    public string strMobilenumber1 { get; set; }
    public string strMobilenumber2 { get; set; }
    public string strFatherorSpouseName { get; set; }
    public DateTime dtmDoB { get; set; }
    public string strWhatsappNumber { get; set; }
    public string strProfession { get; set; }
    public string strCompanyName { get; set; }
    public string strDesignation { get; set; }
    public string strCurrentAddress { get; set; }
    public string strPermanentAddress { get; set; }
    public string strResidentialStatus { get; set; }
    public string strCoapplicantRelationship { get; set; }
    public int intCityID { get; set; }
    public int intStateID { get; set; }
    public int intPincode { get; set; }
    public string strReference1 { get; set; }
    public string strReference2 { get; set; }
    public int intLeadSource { get; set; }
    public bool blLoanTakenStatus { get; set; }
    public string strBankName { get; set; }
    public string strApplicantPhoto { get; set; }
    public string strApplicantPAN { get; set; }
    public string strApplicantAadhar { get; set; }
    public string strCoApplicantPhoto { get; set; }
    public string strCoApplicantPAN { get; set; }
    public string strCoApplicantAadhar { get; set; }
    public string strPoAName { get; set; }
    public string strPoAAddress { get; set; }
    public string strPoAPAN { get; set; }
    public string strPoAAdhar { get; set; }
    public string strCoaGender { get; set; }
    public string strCoaEmailID { get; set; }
    public string strCoaMobilenumber1 { get; set; }
    public string strCoaMobilenumber2 { get; set; }
    public string strCoaWhatsappNumber { get; set; }
    public string strCoaResidentialStatus { get; set; }
    public string strCoaAddress { get; set; }
    public int IntCoaStateID { get; set; }
    public int IntCoaCityID { get; set; }
    public int IntCoaPinCode { get; set; }
    public DateTime DtCoDOB { get; set; }




    public DateTime dtmPoADOB { get; set; }
    public int intCRMID { get; set; }
    public bool blCustomerLoginStatus { get; set; }
    public string strBookingID { get; set; }
    public string FlatName { get; set; }
    public string ReferedBy { get; set; }


    public DateTime dtmBookingDate { get; set; }
    public int Amountpaid { get; set; }
    public int PaymentMode { get; set; }
    public string strBookingknowledgement { get; set; }
    public bool blCarparkAllocated { get; set; }
    public int intNumberofSlots { get; set; }
    public string strAllottedcarparkslotnumber { get; set; }
    public int intRegistrationcharges { get; set; }
    public DateTime dtmRegistrationDate { get; set; }
    public string strRegistrationOffice { get; set; }
    public string strAddedBy { get; set; }
    public string strUpdated { get; set; }

    public int intCustomerID { get; set; }
    public int introwsaffected { get; set; }

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


    public int AddCustomerBasicDetails(Key2hCustomer KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddCustomersBasicDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Gender", KC.strGender));
                command.Parameters.Add(new SqlParameter("@EmailID", KC.strEmailID));
                command.Parameters.Add(new SqlParameter("@Mobilenumber", KC.strMobilenumber1));
                command.Parameters.Add(new SqlParameter("@WhatsappNumber", KC.strWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@AddedBy", KC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));

                SqlParameter outputIdParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();
                KC.intCustomerID = (int)outputIdParam.Value;

            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return KC.intCustomerID;
    }


    public int UpdateCustomerBasicDetails(Key2hCustomer KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateCustomersBasicDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerID", KC.intCustomerID));
                command.Parameters.Add(new SqlParameter("@Gender", KC.strGender));
                command.Parameters.Add(new SqlParameter("@EmailID", KC.strEmailID));
                command.Parameters.Add(new SqlParameter("@Mobilenumber", KC.strMobilenumber1));
                command.Parameters.Add(new SqlParameter("@WhatsappNumber", KC.strWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.strUpdated));
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
    public int AddFlatCustomerBookingDetails(Key2hCustomer KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomerBookingDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerID", KC.intCustomerID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.intProjectID));
                command.Parameters.Add(new SqlParameter("@BlockID", KC.intstrBlockID));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.intFlatID));
                command.Parameters.Add(new SqlParameter("@ApplicantFirstName", KC.strApplicantFirstName));
                command.Parameters.Add(new SqlParameter("@ApplicantLastName", KC.strApplicantLastName));
                command.Parameters.Add(new SqlParameter("@CoapplicantFirstName", KC.strCoapplicantFirstName));
                command.Parameters.Add(new SqlParameter("@CoapplicantLastName", KC.strCoapplicantLastName));
                command.Parameters.Add(new SqlParameter("@CoaGender", KC.strCoaGender));
                command.Parameters.Add(new SqlParameter("@CoaEmailID", KC.strCoaEmailID));
                command.Parameters.Add(new SqlParameter("@CoaMobilenumber1", KC.strCoaMobilenumber1));
                command.Parameters.Add(new SqlParameter("@CoaMobilenumber2", KC.strCoaMobilenumber2));
                command.Parameters.Add(new SqlParameter("@CoaWhatsappNumber", KC.strCoaWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@CoaAddress", KC.strCoaAddress));
                command.Parameters.Add(new SqlParameter("@CoaResidentialStatus", KC.strCoaResidentialStatus));
                command.Parameters.Add(new SqlParameter("@CoaStateID", KC.IntCoaStateID));
                command.Parameters.Add(new SqlParameter("@CoaCityID", KC.IntCoaCityID));
                command.Parameters.Add(new SqlParameter("@CoaPinCode", KC.intPincode));               
                command.Parameters.Add(new SqlParameter("@Gender", KC.strGender));
                command.Parameters.Add(new SqlParameter("@EmailID", KC.strEmailID));
                command.Parameters.Add(new SqlParameter("@Mobilenumber1", KC.strMobilenumber1));
                command.Parameters.Add(new SqlParameter("@Mobilenumber2", KC.strMobilenumber2));
                command.Parameters.Add(new SqlParameter("@FatherorSpouseName", KC.strFatherorSpouseName));
                command.Parameters.Add(new SqlParameter("@DoB", KC.dtmDoB));
                command.Parameters.Add(new SqlParameter("@CoDOB", KC.DtCoDOB));
                command.Parameters.Add(new SqlParameter("@WhatsappNumber", KC.strWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@Profession", KC.strProfession));
                command.Parameters.Add(new SqlParameter("@CompanyName", KC.strCompanyName));
                command.Parameters.Add(new SqlParameter("@Designation", KC.strDesignation));
                command.Parameters.Add(new SqlParameter("@PermanentAddress", KC.strPermanentAddress));
                command.Parameters.Add(new SqlParameter("@CurrentAddress", KC.strCurrentAddress));
                command.Parameters.Add(new SqlParameter("@ResidentialStatus", KC.strResidentialStatus));
                command.Parameters.Add(new SqlParameter("@CoapplicantRelationship", KC.strCoapplicantRelationship));
                command.Parameters.Add(new SqlParameter("@CityID", KC.intCityID));
                command.Parameters.Add(new SqlParameter("@StateID", KC.intStateID));
                command.Parameters.Add(new SqlParameter("@Pincode", KC.intPincode));
                command.Parameters.Add(new SqlParameter("@Reference1", KC.strReference1));
                command.Parameters.Add(new SqlParameter("@Reference2", KC.strReference2));
                command.Parameters.Add(new SqlParameter("@LeadSource", KC.intLeadSource));
                command.Parameters.Add(new SqlParameter("@LoanTakenStatus", KC.blLoanTakenStatus));
                command.Parameters.Add(new SqlParameter("@BankName", KC.strBankName));
                command.Parameters.Add(new SqlParameter("@ApplicantPhoto", KC.strApplicantPhoto));
                command.Parameters.Add(new SqlParameter("@ApplicantPAN", KC.strApplicantPAN));
                command.Parameters.Add(new SqlParameter("@ApplicantAadhar", KC.strApplicantAadhar));
                command.Parameters.Add(new SqlParameter("@CoApplicantPhoto", KC.strCoApplicantPhoto));
                command.Parameters.Add(new SqlParameter("@CoApplicantPAN", KC.strCoApplicantPAN));
                command.Parameters.Add(new SqlParameter("@CoApplicantAadhar", KC.strCoApplicantAadhar));
                command.Parameters.Add(new SqlParameter("@PoAName", KC.strPoAName));
                command.Parameters.Add(new SqlParameter("@PoAAddress", KC.strPoAAddress));
                command.Parameters.Add(new SqlParameter("@PoAPAN", KC.strPoAPAN));
                command.Parameters.Add(new SqlParameter("@PoAAdhar", KC.strPoAAdhar));
                command.Parameters.Add(new SqlParameter("@PoADOB", KC.dtmPoADOB));
                command.Parameters.Add(new SqlParameter("@CRMID", KC.intCRMID));
                command.Parameters.Add(new SqlParameter("@CustomerLoginStatus", KC.blCustomerLoginStatus));
                command.Parameters.Add(new SqlParameter("@BookingDate", KC.dtmBookingDate));
                command.Parameters.Add(new SqlParameter("@Amountpaid", KC.Amountpaid));
                command.Parameters.Add(new SqlParameter("@PaymentMode", KC.PaymentMode));
                command.Parameters.Add(new SqlParameter("@Bookingknowledgement", KC.strBookingknowledgement));
                command.Parameters.Add(new SqlParameter("@CarparkAllocated", KC.blCarparkAllocated));
                command.Parameters.Add(new SqlParameter("@NumberofSlots", KC.intNumberofSlots));
                command.Parameters.Add(new SqlParameter("@Allottedcarparkslotnumber", KC.strAllottedcarparkslotnumber));
                command.Parameters.Add(new SqlParameter("@Registrationcharges", KC.intRegistrationcharges));
                command.Parameters.Add(new SqlParameter("@RegistrationDate", KC.dtmRegistrationDate));
                command.Parameters.Add(new SqlParameter("@RegistrationOffice", KC.strRegistrationOffice));
                command.Parameters.Add(new SqlParameter("@ReferedBy", KC.ReferedBy));
                command.Parameters.Add(new SqlParameter("@Addedby", KC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@AddedDate", Utility.IndianTime));
                command.Parameters.Add(new SqlParameter("@FlatName", KC.FlatName));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }
    public int UpdateFlatCustomerBookingDetails(Key2hCustomer KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("UpdateFlatCustomerBookingDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatCustomerID", KC.intFlatCustomerID));
                command.Parameters.Add(new SqlParameter("@CustomerID", KC.intCustomerID));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.intProjectID));
                command.Parameters.Add(new SqlParameter("@BlockID", KC.intstrBlockID));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.intFlatID));
                command.Parameters.Add(new SqlParameter("@ApplicantFirstName", KC.strApplicantFirstName));
                command.Parameters.Add(new SqlParameter("@ApplicantLastName", KC.strApplicantLastName));
                command.Parameters.Add(new SqlParameter("@CoapplicantFirstName", KC.strCoapplicantFirstName));
                command.Parameters.Add(new SqlParameter("@CoapplicantLastName", KC.strCoapplicantLastName));
                command.Parameters.Add(new SqlParameter("@Gender", KC.strGender));
                command.Parameters.Add(new SqlParameter("@EmailID", KC.strEmailID));
                command.Parameters.Add(new SqlParameter("@Mobilenumber1", KC.strMobilenumber1));
                command.Parameters.Add(new SqlParameter("@Mobilenumber2", KC.strMobilenumber2));
                command.Parameters.Add(new SqlParameter("@FatherorSpouseName", KC.strFatherorSpouseName));
                command.Parameters.Add(new SqlParameter("@DoB", KC.dtmDoB));
                command.Parameters.Add(new SqlParameter("@CoDOB", KC.DtCoDOB));
                command.Parameters.Add(new SqlParameter("@WhatsappNumber", KC.strWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@Profession", KC.strProfession));
                command.Parameters.Add(new SqlParameter("@CompanyName", KC.strCompanyName));
                command.Parameters.Add(new SqlParameter("@Designation", KC.strDesignation));
                command.Parameters.Add(new SqlParameter("@PermanentAddress", KC.strPermanentAddress));
                command.Parameters.Add(new SqlParameter("@CurrentAddress", KC.strCurrentAddress));
                command.Parameters.Add(new SqlParameter("@ResidentialStatus", KC.strResidentialStatus));
                command.Parameters.Add(new SqlParameter("@CoapplicantRelationship", KC.strCoapplicantRelationship));
                command.Parameters.Add(new SqlParameter("@CityID", KC.intCityID));
                command.Parameters.Add(new SqlParameter("@StateID", KC.intStateID));
                command.Parameters.Add(new SqlParameter("@Pincode", KC.intPincode));
                command.Parameters.Add(new SqlParameter("@Reference1", KC.strReference1));
                command.Parameters.Add(new SqlParameter("@Reference2", KC.strReference2));
                command.Parameters.Add(new SqlParameter("@LeadSource", KC.intLeadSource));
                command.Parameters.Add(new SqlParameter("@LoanTakenStatus", KC.blLoanTakenStatus));
                command.Parameters.Add(new SqlParameter("@BankName", KC.strBankName));
                command.Parameters.Add(new SqlParameter("@ApplicantPhoto", KC.strApplicantPhoto));
                command.Parameters.Add(new SqlParameter("@ApplicantPAN", KC.strApplicantPAN));
                command.Parameters.Add(new SqlParameter("@ApplicantAadhar", KC.strApplicantAadhar));
                command.Parameters.Add(new SqlParameter("@CoApplicantPhoto", KC.strCoApplicantPhoto));
                command.Parameters.Add(new SqlParameter("@CoApplicantPAN", KC.strCoApplicantPAN));
                command.Parameters.Add(new SqlParameter("@CoApplicantAadhar", KC.strCoApplicantAadhar));
                command.Parameters.Add(new SqlParameter("@CoaGender", KC.strCoaGender));
                command.Parameters.Add(new SqlParameter("@CoaEmailID", KC.strCoaEmailID));
                command.Parameters.Add(new SqlParameter("@CoaMobilenumber1", KC.strCoaMobilenumber1));
                command.Parameters.Add(new SqlParameter("@CoaMobilenumber2", KC.strCoaMobilenumber2));
                command.Parameters.Add(new SqlParameter("@CoaWhatsappNumber", KC.strCoaWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@CoaAddress", KC.strCoaAddress));
                command.Parameters.Add(new SqlParameter("@CoaResidentialStatus", KC.strCoaResidentialStatus));
                command.Parameters.Add(new SqlParameter("@CoaStateID", KC.IntCoaStateID));
                command.Parameters.Add(new SqlParameter("@CoaCityID", KC.IntCoaCityID));
                command.Parameters.Add(new SqlParameter("@CoaPinCode", KC.IntCoaPinCode));
                command.Parameters.Add(new SqlParameter("@PoAName", KC.strPoAName));
                command.Parameters.Add(new SqlParameter("@PoAAddress", KC.strPoAAddress));
                command.Parameters.Add(new SqlParameter("@PoAPAN", KC.strPoAPAN));
                command.Parameters.Add(new SqlParameter("@PoAAdhar", KC.strPoAAdhar));
                command.Parameters.Add(new SqlParameter("@PoADOB", KC.dtmPoADOB));
                command.Parameters.Add(new SqlParameter("@CRMID", KC.intCRMID));
                command.Parameters.Add(new SqlParameter("@CustomerLoginStatus", KC.blCustomerLoginStatus));
                command.Parameters.Add(new SqlParameter("@BookingDate", KC.dtmBookingDate));
                command.Parameters.Add(new SqlParameter("@Amountpaid", KC.Amountpaid));
                command.Parameters.Add(new SqlParameter("@PaymentMode", KC.PaymentMode));
                command.Parameters.Add(new SqlParameter("@Bookingknowledgement", KC.strBookingknowledgement));
                command.Parameters.Add(new SqlParameter("@CarparkAllocated", KC.blCarparkAllocated));
                command.Parameters.Add(new SqlParameter("@NumberofSlots", KC.intNumberofSlots));
                command.Parameters.Add(new SqlParameter("@Allottedcarparkslotnumber", KC.strAllottedcarparkslotnumber));
                command.Parameters.Add(new SqlParameter("@Registrationcharges", KC.intRegistrationcharges));
                command.Parameters.Add(new SqlParameter("@RegistrationDate", KC.dtmRegistrationDate));
                command.Parameters.Add(new SqlParameter("@RegistrationOffice", KC.strRegistrationOffice));
                command.Parameters.Add(new SqlParameter("@ReferedBy", KC.ReferedBy));
                command.Parameters.Add(new SqlParameter("@UpdatedBy", KC.strUpdated));
                command.Parameters.Add(new SqlParameter("@Updateddate", Utility.IndianTime));


                rowsAffected = command.ExecuteNonQuery();
            }
            cnn.Close();
        }
        catch (Exception ex)
        {
        }
        return rowsAffected;
    }






    public DataTable AlreadyExistProjectdetails(int pID, int BlockID, int FlatID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AlreadyexistFlatCustomerBookingDetailsByProjectIDAndBlockIDAndFlatID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectID", pID));
                command.Parameters.Add(new SqlParameter("@BlockID", BlockID));
                command.Parameters.Add(new SqlParameter("@FlatID", FlatID));

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable ViewAllFlatCustomerBookingDetailsByFlatCustomerID(int ID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatCustomerBookingDetailsByFlatCustomerID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatCustomerID", ID));


                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewBasicCustomerDetailsByMobilenumber(string Mobilenumber)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewBasicCustomerDetailsByMobilenumber", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Mobilenumber", Mobilenumber));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable ViewRMDetails(string AddedBy)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewRMDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable ViewAllflatBookingCustomerDetails(string strprID, string strblockID, string flatID, string strsearch, string strflatcustomerID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("ViewAllFlatBookingCustomerDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatID", string.IsNullOrWhiteSpace(flatID) ? (object)DBNull.Value : Convert.ToInt32(flatID)));
                command.Parameters.Add(new SqlParameter("@BlockID", string.IsNullOrWhiteSpace(strblockID) ? (object)DBNull.Value : Convert.ToInt32(strblockID)));
                command.Parameters.Add(new SqlParameter("@ProjectID", string.IsNullOrWhiteSpace(strprID) ? (object)DBNull.Value : Convert.ToInt32(strprID)));
                command.Parameters.Add(new SqlParameter("@FlatCustomerID", string.IsNullOrWhiteSpace(strflatcustomerID) ? (object)DBNull.Value : Convert.ToInt32(strflatcustomerID)));
                command.Parameters.Add(new SqlParameter("@strsearch", strsearch));
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public int DeleteFlatBookingCustomerDetailsBYFlatcustomerID(int strFlatID)
    {
        string connetionString = null;
        SqlConnection cnn;
        DataTable dt = new DataTable();
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("DeleteFlatBookingCustomerDetailsBYFlatcustomerID", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FlatCustomerID", strFlatID));
                rowsAffected = command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        return rowsAffected;
    }


    public int AddtblFlatCustomerBookingDetails(Key2hCustomer KC)
    {
        string connetionString = null;
        SqlConnection cnn;
        connetionString = GetSqlConnection();
        cnn = new SqlConnection(connetionString);
        int rowsAffected = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("AddFlatCustomerBookingDetails", cnn))
            {
                cnn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerID", KC.strGender));
                command.Parameters.Add(new SqlParameter("@ProjectID", KC.strEmailID));
                command.Parameters.Add(new SqlParameter("@BlockID", KC.strMobilenumber1));
                command.Parameters.Add(new SqlParameter("@FlatID", KC.strWhatsappNumber));
                command.Parameters.Add(new SqlParameter("@ApplicantFirstName", KC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@ApplicantLastName", KC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@CoapplicantFirstName", KC.strAddedBy));
                command.Parameters.Add(new SqlParameter("@CoapplicantLastName", KC.strAddedBy));
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








}