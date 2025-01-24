


select * from sys.tables
select * from tblClientDashboardIssues

truncate table tblClientDashboardIssues


sp_helptext  ViewFlatBookingReferedby

sp_helptext AddFlatCustomerBookingDetails

alter Procedure AddFlatCustomerBookingDetails   
@CustomerID int,   
@ProjectID int,   
@BlockID int,  
@FlatID int,  
@ApplicantFirstName varchar(255),  
@ApplicantLastName varchar(255),  
@CoapplicantFirstName varchar(255),  
@CoapplicantLastName varchar(255),   
@Gender varchar(50),  
@EmailID varchar(255),   
@Mobilenumber1 varchar(20),  
@Mobilenumber2 varchar(20),  
@FatherorSpouseName varchar(255),  
@DoB datetime,   
@WhatsappNumber varchar(255),   
@Profession varchar(255),   
@CompanyName varchar(255),   
@Designation varchar(255),  
@CurrentAddress varchar(500),  
@PermanentAddress varchar(500),  
@ResidentialStatus varchar(50),  
@CoapplicantRelationship varchar(255),  
@CityID int,   
@StateID int,   
@Pincode int,   
@Reference1 varchar(255),  
@Reference2 varchar(255),  
@LeadSource int,   
@LoanTakenStatus Bit,   
@BankName nvarchar(255),   
@ApplicantPhoto nvarchar(500),  
@ApplicantPAN nvarchar(50),   
@ApplicantAadhar nvarchar(50),   
@CoApplicantPhoto nvarchar(500),  
@CoApplicantPAN nvarchar(50),   
@CoApplicantAadhar nvarchar(50),  
@PoAName varchar(255),   
@PoAAddress varchar(500),   
@PoAPAN varchar(50),  
@PoAAdhar varchar(50),  
@PoADOB datetime,   
@CRMID int,  
@CustomerLoginStatus Bit,  
@BookingDate Datetime,  
@Amountpaid int,  
@PaymentMode Int,   
@Bookingknowledgement nvarchar(255),   
@CarparkAllocated bit,  
@NumberofSlots int,   
@Allottedcarparkslotnumber nvarchar(255),  
@Registrationcharges int,  
@RegistrationDate Datetime,   
@RegistrationOffice nvarchar(225),  
@ReferedBy nvarchar(80),  
@Addeddate Datetime,   
@Addedby varchar(50),  
@FlatName varchar(256) As Begin     -- Insert into tblFlatCustomerBookingDetails      
Insert into tblFlatCustomerBookingDetails(CustomerID,  
ProjectID,      
BlockID,   
FlatID,   
ApplicantFirstName,   
ApplicantLastName,   
CoapplicantFirstName,    
CoapplicantLastName,     Gender,     EmailID,     Mobilenumber1,     Mobilenumber2,       
FatherorSpouseName,     DoB,      WhatsappNumber,     Profession,     CompanyName,     Designation,     CurrentAddress,     PermanentAddress,     ResidentialStatus,     CoapplicantRelationship,     CityID,     StateID,     Pincode,     Reference1,     Ref
erence2,     LeadSource,     LoanTakenStatus,     BankName,     ApplicantPhoto,     ApplicantPAN,     ApplicantAadhar,     CoApplicantPhoto,     CoApplicantPAN,     CoApplicantAadhar,     PoAName,     PoAAddress,     PoAPAN,     PoAAdhar,     PoADOB,     
  
CRMID,     CustomerLoginStatus,     BookingDate,     Amountpaid,     PaymentMode,     Bookingknowledgement,     CarparkAllocated,     NumberofSlots,     Allottedcarparkslotnumber,     Registrationcharges,     RegistrationDate,     RegistrationOffice,   ReferedBy,Addeddate,     Addedby     )        
Values(@CustomerID,     @ProjectID,     @BlockID,     @FlatID,     @ApplicantFirstName,     @ApplicantLastName,     @CoapplicantFirstName,     @CoapplicantLastName,     @Gender,     @EmailID,     @Mobilenumber1,     @Mobilenumber2,     @FatherorSpouseName
,     @DoB,      @WhatsappNumber,     @Profession,     @CompanyName,     @Designation,     @CurrentAddress,     @PermanentAddress,     @ResidentialStatus,     @CoapplicantRelationship,     @CityID,     @StateID,     @Pincode,     @Reference1,     @Reference2,     @LeadSource,     @LoanTakenStatus,     @BankName,     @ApplicantPhoto,     @ApplicantPAN,     @ApplicantAadhar,     @CoApplicantPhoto,     @CoApplicantPAN,     @CoApplicantAadhar,     @PoAName,     @PoAAddress,    
   @PoAPAN,     @PoAAdhar,     @PoADOB,     @CRMID,     @CustomerLoginStatus,     @BookingDate,     @Amountpaid,     @PaymentMode,     @Bookingknowledgement,     @CarparkAllocated,     @NumberofSlots,     @Allottedcarparkslotnumber,     @Registrationcharges,     @RegistrationDate,     @RegistrationOffice,    @ReferedBy, @Addeddate,     @Addedby     );      
   -- Update FlatLoginID using FlatID and @FlatName     
   Update tblFlatCustomerBookingDetails     Set FlatLoginID = @FlatName + CAST(FlatID AS NVARCHAR(50))   
   Where FlatID = @FlatID;  
   End 


sp_helptext ViewAllProjects


CREATE PROCEDURE ViewAllProjects            
    @ProjectID NVARCHAR(50) = NULL,  -- Changed to NVARCHAR to accept empty strings          
    @Status NVARCHAR(50) = NULL,          
    @Projectstatus INT = NULL          
AS          
BEGIN            
    SET NOCOUNT ON;            
            
    -- Convert empty strings to NULL    
    SET @ProjectID = CASE WHEN ISNULL(@ProjectID, '') = '' THEN NULL ELSE @ProjectID END;    
    SET @Status = CASE WHEN ISNULL(@Status, '') = '' THEN NULL ELSE @Status END;    
            
    -- Declare variables for dynamic SQL      
    DECLARE @SQL NVARCHAR(MAX);            
    DECLARE @ParameterDef NVARCHAR(MAX);            
            
    -- Define the parameter definition      
    SET @ParameterDef = '@ProjectID INT, @Status BIT, @Projectstatus INT';            
            
    -- Base query (always returns records if no parameters are provided)      
    SET @SQL = 'SELECT tp.*,TPS.BHK,TPS.SquareFeet FROM tblProjects tp inner join tblProjectHomeScreen TPS on tp.ProjectID=TPS.ProjectID    WHERE 1 = 1';            
            
    -- Add filters dynamically based on the presence of parameters      
    IF (@ProjectID IS NOT NULL)            
    BEGIN            
        SET @SQL = @SQL + ' AND ProjectID = @ProjectID';            
    END            
            
    IF (@Status IS NOT NULL)            
    BEGIN            
        SET @SQL = @SQL + ' AND ProjectDisplayStatus = @Status';            
    END            
            
    IF (@Projectstatus IS NOT NULL)            
    BEGIN            
        SET @SQL = @SQL + ' AND ProjectStatus = @Projectstatus';            
    END            
            
    -- Add an ORDER BY clause      
    SET @SQL = @SQL + ' ORDER BY AddedDate DESC';            
            
    -- Execute the dynamic SQL query      
    EXEC sp_executesql @SQL,           
        @ParameterDef,           
        @ProjectID = @ProjectID,           
        @Status = @Status,           
        @Projectstatus = @Projectstatus;            
END; 





sp_helptext UpdateProjectHomeScreen


CREATE Procedure UpdateProjectHomeScreen  
@ProjectID int,    
@BHK varchar(200),    
@Sqft varchar(200),      
@UpdatedBy varchar(256),    
@UpdatedDate datetime   
As  
Begin  
Update tblProjectHomeScreen set BHK=@BHK,SquareFeet=@Sqft,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate where ProjectID=@ProjectID  
End  





sp_helptext viewFlatCostDetailsByFlatID

 CREATE Procedure viewFlatCostDetailsByFlatID        
        @FlatID int        
        As        
        Begin        
        select tblcd.*,tblc.* from tblFlatCostDetails tblcd left join tblProjectCostLabels tblc on tblc.CostlabelID = tblcd.CostLabelID Where FlatID=@FlatID   Order By tblcd.AddedDate Desc,tblcd.CostID Desc    
        End




alter table tblFlatCustomerBookingDetails  
add CoaGender varchar(50),
CoaEmailID varchar(255),
CoaMobilenumber1  Varchar(20),
CoaMobilenumber2 Varchar(20),
CoaWhatsappNumber Varchar(20),
CoaAddress varchar(500),
CoaResidentialStatus varchar(50),
CoaStateID int,
CoaCityID int,
CoaPinCode int

alter table tblFlatCustomerBookingDetails  
add CoDOB Datetime




alter Procedure AddFlatCustomerBookingDetails   
@CustomerID int,   
@ProjectID int,   
@BlockID int,  
@FlatID int,  
@ApplicantFirstName varchar(255),  
@ApplicantLastName varchar(255),  
@CoapplicantFirstName varchar(255),  
@CoapplicantLastName varchar(255),   
@Gender varchar(50),  
@EmailID varchar(255),   
@Mobilenumber1 varchar(20),  
@Mobilenumber2 varchar(20),  
@FatherorSpouseName varchar(255),  
@DoB datetime,   
@WhatsappNumber varchar(255),   
@Profession varchar(255),   
@CompanyName varchar(255),   
@Designation varchar(255),  
@CurrentAddress varchar(500),  
@PermanentAddress varchar(500),  
@ResidentialStatus varchar(50),  
@CoapplicantRelationship varchar(255),  
@CityID int,   
@StateID int,   
@Pincode int,   
@Reference1 varchar(255),  
@Reference2 varchar(255),  
@LeadSource int,   
@LoanTakenStatus Bit,   
@BankName nvarchar(255),   
@ApplicantPhoto nvarchar(500),  
@ApplicantPAN nvarchar(50),   
@ApplicantAadhar nvarchar(50),   
@CoApplicantPhoto nvarchar(500),  
@CoApplicantPAN nvarchar(50),   
@CoApplicantAadhar nvarchar(50),  
@PoAName varchar(255),   
@PoAAddress varchar(500),   
@PoAPAN varchar(50),  
@PoAAdhar varchar(50),  
@PoADOB datetime,
@CoDOB Datetime,
@CRMID int,  
@CustomerLoginStatus Bit,  
@BookingDate Datetime,  
@Amountpaid int,  
@PaymentMode Int,   
@Bookingknowledgement nvarchar(255),   
@CarparkAllocated bit,  
@NumberofSlots int,   
@Allottedcarparkslotnumber nvarchar(255),  
@Registrationcharges int,  
@RegistrationDate Datetime,   
@RegistrationOffice nvarchar(225),  
@ReferedBy nvarchar(80),
@CoaGender varchar(50),
@CoaEmailID varchar(255),
@CoaMobilenumber1  Varchar(20),
@CoaMobilenumber2 Varchar(20),
@CoaWhatsappNumber Varchar(20),
@CoaAddress varchar(500),
@CoaResidentialStatus varchar(50),
@CoaStateID int,
@CoaCityID int,
@CoaPinCode int,
@Addeddate Datetime,   
@Addedby varchar(50),  
@FlatName varchar(256) As Begin     -- Insert into tblFlatCustomerBookingDetails      
Insert into tblFlatCustomerBookingDetails(CustomerID,  
ProjectID,      
BlockID,   
FlatID,   
ApplicantFirstName,   
ApplicantLastName,   
CoapplicantFirstName,    
CoapplicantLastName,     Gender,     EmailID,     Mobilenumber1,     Mobilenumber2,       
FatherorSpouseName,     DoB,      WhatsappNumber,     Profession,     CompanyName,     Designation,     CurrentAddress,     PermanentAddress,     ResidentialStatus,     CoapplicantRelationship,     CityID,     StateID,     Pincode,     Reference1,     Reference2,     LeadSource,     LoanTakenStatus,     BankName,     ApplicantPhoto,     ApplicantPAN,     ApplicantAadhar,     CoApplicantPhoto,     CoApplicantPAN,     CoApplicantAadhar,     PoAName,     PoAAddress,     PoAPAN,     PoAAdhar,     PoADOB,     
  
CRMID,     CustomerLoginStatus,     BookingDate,     Amountpaid,     PaymentMode,     Bookingknowledgement,     CarparkAllocated,     NumberofSlots,     Allottedcarparkslotnumber,     Registrationcharges,     RegistrationDate,     RegistrationOffice,   ReferedBy,         
CoaGender ,
CoaEmailID ,
CoaMobilenumber1  ,
CoaMobilenumber2 ,
CoaWhatsappNumber ,
CoaAddress ,
CoaResidentialStatus ,
CoaStateID ,
CoaCityID ,
CoaPinCode ,
CoDOB,




Addeddate,     Addedby     )        
Values(@CustomerID,     @ProjectID,     @BlockID,     @FlatID,     @ApplicantFirstName,     @ApplicantLastName,     @CoapplicantFirstName,     @CoapplicantLastName,     @Gender,     @EmailID,     @Mobilenumber1,     @Mobilenumber2,     @FatherorSpouseName
,     @DoB,      @WhatsappNumber,     @Profession,     @CompanyName,     @Designation,     @CurrentAddress,     @PermanentAddress,     @ResidentialStatus,     @CoapplicantRelationship,     @CityID,     @StateID,     @Pincode,     @Reference1,     @Reference2,     @LeadSource,     @LoanTakenStatus,     @BankName,     @ApplicantPhoto,     @ApplicantPAN,     @ApplicantAadhar,     @CoApplicantPhoto,     @CoApplicantPAN,     @CoApplicantAadhar,     @PoAName,     @PoAAddress,    
   @PoAPAN,     @PoAAdhar,     @PoADOB,     @CRMID,     @CustomerLoginStatus,     @BookingDate,     @Amountpaid,     @PaymentMode,     @Bookingknowledgement,     @CarparkAllocated,     @NumberofSlots,     @Allottedcarparkslotnumber,     @Registrationcharges,     @RegistrationDate,     @RegistrationOffice,    @ReferedBy, 
   @CoaGender ,
@CoaEmailID ,
@CoaMobilenumber1  ,
@CoaMobilenumber2 ,
@CoaWhatsappNumber ,
@CoaAddress ,
@CoaResidentialStatus ,
@CoaStateID ,
@CoaCityID ,
@CoaPinCode ,
@CoDOB,
   
   
   @Addeddate,     @Addedby     );      
   -- Update FlatLoginID using FlatID and @FlatName     
   Update tblFlatCustomerBookingDetails     Set FlatLoginID = @FlatName + CAST(FlatID AS NVARCHAR(50))   
   Where FlatID = @FlatID;  
   End 







         
Alter Procedure UpdateFlatCustomerBookingDetails    
    
@FlatCustomerID int,    
@CustomerID int,    
@ProjectID int,    
@BlockID int,    
@FlatID int,    
@ApplicantFirstName varchar(255),    
@ApplicantLastName varchar(255),    
@CoapplicantFirstName varchar(255),    
@CoapplicantLastName varchar(255),    
@Gender varchar(50),    
@EmailID varchar(255),    
@Mobilenumber1 varchar(20),    
@Mobilenumber2 varchar(20),    
@FatherorSpouseName varchar(255),    
@DoB datetime,    
@WhatsappNumber varchar(255),    
@Profession varchar(255),    
@CompanyName varchar(255),    
@Designation varchar(255),    
@CurrentAddress varchar(500),    
@PermanentAddress varchar(500),    
@ResidentialStatus varchar(50),    
@CoapplicantRelationship varchar(255),    
@CityID int,    
@StateID int,    
@Pincode int,    
@Reference1 varchar(255),    
@Reference2 varchar(255),    
@LeadSource int,    
@LoanTakenStatus Bit,    
@BankName nvarchar(255),    
@ApplicantPhoto nvarchar(500),    
@ApplicantPAN nvarchar(50),    
@ApplicantAadhar nvarchar(50),    
@CoApplicantPhoto nvarchar(500),    
@CoApplicantPAN nvarchar(50),    
@CoApplicantAadhar nvarchar(50),  
@CoaGender varchar(50),
@CoaEmailID varchar(255),
@CoaMobilenumber1  Varchar(20),
@CoaMobilenumber2 Varchar(20),
@CoaWhatsappNumber Varchar(20),
@CoaAddress varchar(500),
@CoaResidentialStatus varchar(50),
@CoaStateID int,
@CoaCityID int,
@CoaPinCode int,
@CoDOB Datetime,
@PoAName varchar(255),    
@PoAAddress varchar(500),    
@PoAPAN varchar(50),    
@PoAAdhar varchar(50),    
@PoADOB datetime,    
@CRMID int,    
@CustomerLoginStatus Bit,    
@BookingDate Datetime,    
@Amountpaid int,    
@PaymentMode Int,    
@Bookingknowledgement nvarchar(255),    
@CarparkAllocated bit,    
@NumberofSlots int,    
@Allottedcarparkslotnumber nvarchar(255),    
@Registrationcharges int,    
@RegistrationDate Datetime,    
@RegistrationOffice nvarchar(225),    
@ReferedBy nvarchar(80),    
@Updateddate Datetime,    
@UpdatedBy varchar(50)    
As    
Begin    
Update tblFlatCustomerBookingDetails set     
ProjectID=@ProjectID,    
BlockID=@BlockID,    
FlatID=@FlatID,    
ApplicantFirstName=@ApplicantFirstName,    
ApplicantLastName =@ApplicantLastName,    
CoapplicantFirstName=@CoapplicantFirstName,    
CoapplicantLastName=@CoapplicantLastName,    
Gender=@Gender,    
EmailID=@EmailID,    
Mobilenumber1=@Mobilenumber1,    
Mobilenumber2=@Mobilenumber2,    
FatherorSpouseName=@FatherorSpouseName,    
DoB=@DoB,    
CoDOB=@CoDOB,
WhatsappNumber=@WhatsappNumber,    
Profession=@Profession,    
CompanyName=@CompanyName,    
Designation=@Designation,    
CurrentAddress=@CurrentAddress,    
PermanentAddress=@PermanentAddress,    
ResidentialStatus=@ResidentialStatus,    
CoapplicantRelationship=@CoapplicantRelationship,    
CityID=@CityID,    
StateID=@StateID ,    
Pincode=@Pincode ,    
Reference1=@Reference1,    
Reference2=@Reference2,    
LeadSource=@LeadSource,    
LoanTakenStatus=@LoanTakenStatus,    
BankName=@BankName ,    
ApplicantPhoto=@ApplicantPhoto,    
ApplicantPAN=@ApplicantPAN ,    
ApplicantAadhar=@ApplicantAadhar ,    
CoApplicantPhoto=@CoApplicantPhoto ,    
CoApplicantPAN=@CoApplicantPAN ,    
CoApplicantAadhar=@CoApplicantAadhar ,    
PoAName=@PoAName,    
PoAAddress=@PoAAddress,    
PoAPAN=@PoAPAN,    
PoAAdhar=@PoAAdhar ,    
PoADOB=@PoADOB,    
CRMID=@CRMID,    
CustomerLoginStatus=@CustomerLoginStatus,    
BookingDate=@BookingDate,    
Amountpaid=@Amountpaid,    
PaymentMode=@PaymentMode,    
Bookingknowledgement=@Bookingknowledgement,    
CarparkAllocated=@CarparkAllocated ,    
NumberofSlots=@NumberofSlots ,    
Allottedcarparkslotnumber=@Allottedcarparkslotnumber,    
Registrationcharges=@Registrationcharges,    
RegistrationDate=@RegistrationDate,    
RegistrationOffice=@RegistrationOffice,  
ReferedBy=@ReferedBy,
CoaGender =@CoaGender,
CoaEmailID =@CoaEmailID,
CoaMobilenumber1 =@CoaMobilenumber1  ,
CoaMobilenumber2 =@CoaMobilenumber2 ,
CoaWhatsappNumber =@CoaWhatsappNumber ,
CoaAddress=@CoaAddress ,
CoaResidentialStatus=@CoaResidentialStatus ,
CoaStateID=@CoaStateID ,
CoaCityID=@CoaCityID ,
CoaPinCode=@CoaPinCode ,
Updateddate=@Updateddate,    
CustomerID =@CustomerID ,  
UpdatedBy=@UpdatedBy  where  FlatCustomerID=@FlatCustomerID      
End    



select * from tblFlatCustomerBookingDetails


Alter PROCEDURE [dbKey2h].[DeleteFlatCustomerTransaction]  
    @FlatID INT  
AS  
BEGIN  
    -- Delete from tblFlatCostDetails if FlatID exists
    IF EXISTS (SELECT 1 FROM tblFlatCostDetails WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCostDetails WHERE FlatID = @FlatID;
    END

    -- Delete from tblCustomerPaymentSchedule if FlatID exists
    IF EXISTS (SELECT 1 FROM tblCustomerPaymentSchedule WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblCustomerPaymentSchedule WHERE FlatID = @FlatID;
    END

    -- Delete from tblFlatCustomerDemands if FlatID exists
    IF EXISTS (SELECT 1 FROM tblFlatCustomerDemands WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCustomerDemands WHERE FlatID = @FlatID;
    END

    -- Delete from tblFlatCustomerTransaction if FlatID exists
    IF EXISTS (SELECT 1 FROM tblFlatCustomerTransaction WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCustomerTransaction WHERE FlatID = @FlatID;
    END
END;






sp_helptext ViewFilterCustomerPaymentSchedule


CREATE PROCEDURE ViewFilterCustomerPaymentSchedule    
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,            
    @PSID NVARCHAR(50) = NULL,          
    @BlockID NVARCHAR(50) = NULL            
AS    
BEGIN   
    -- Treat empty strings as NULL  
    SET @ProjectID = NULLIF(@ProjectID, '');  
    SET @FlatID = NULLIF(@FlatID, '');  
    SET @PSID = NULLIF(@PSID, '');  
    SET @BlockID = NULLIF(@BlockID, '');  
  
    WITH RankedDemands AS (    
        SELECT     
            f.FlatID,     
            f.PSID,    
            f.AddedBy,    
            p.ProjectID,    
            p.BlockID,  
            p.applicantFirstName,  
            ROW_NUMBER() OVER (PARTITION BY f.FlatID ORDER BY f.PSID) AS RowNum    
        FROM tblCustomerPaymentSchedule f  
        INNER JOIN tblFlatCustomerBookingDetails p ON f.FlatID = p.FlatID    
        WHERE     
            (@ProjectID IS NULL OR p.ProjectID = @ProjectID) AND    
            (@FlatID IS NULL OR f.FlatID = @FlatID) AND    
            (@PSID IS NULL OR f.PSID = @PSID) AND    
            (@BlockID IS NULL OR p.BlockID = @BlockID)    
    )    
    SELECT FlatID, ProjectID, BlockID, PSID, applicantFirstName, AddedBy    
    FROM RankedDemands    
    WHERE RowNum = 1;  -- Fetch only the first FlatID from each group  
END  


exec  ViewFilterCustomerPaymentSchedule           
    @FlatID = '19'


    select * from tblFlatCustomerBookingDetails where FlatID='19'



    
alter PROCEDURE [dbKey2h].[ViewAllFlatCustomizationWorks]  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,            
    @CWID NVARCHAR(50) = NULL,  
    @AddedBy nvarchar(50)=null  
AS    
BEGIN    
    WITH RankedDemands AS (    
        SELECT     
            r.FlatID,  
            r.WorkTitle,  
            r.WorkStatus,  
            r.Amount,  
            b.ProjectID,     
            b.BlockID,     
            r.CWID,    
            r.AddedBy, 
			r.AddedDate,
            b.ApplicantFirstName,  -- Include this column in the CTE  
            ROW_NUMBER() OVER (PARTITION BY r.FlatID, b.ProjectID, b.BlockID ORDER BY r.CWID) AS RowNum    
        FROM tblFlatCustomisationWorks r  
        LEFT JOIN tblFlatCustomerBookingDetails b  
            ON r.FlatID = b.FlatID  
        WHERE     
            (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
            (@FlatID IS NULL OR @FlatID = '' OR r.FlatID = @FlatID) AND    
            (@CWID IS NULL OR @CWID = '' OR r.CWID = @CWID) AND    
            (@AddedBy IS NULL OR @AddedBy = '' OR r.AddedBy = @AddedBy) AND    
            (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID)    
    )    
    SELECT   
    CWID,  
        FlatID,   
        ProjectID,   
        BlockID,   
        WorkTitle,  
        WorkStatus,  
        Amount,  
        AddedBy, 
		AddedDate,
        ApplicantFirstName  
    FROM RankedDemands  
    WHERE RowNum = 1 order by AddedDate Desc,CWID Desc;  -- Fetch only the first record    
END;




sp_helptext ViewAllFlatCustomerDemands


Alter PROCEDURE ViewAllFlatCustomerDemands  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,            
    @CWID NVARCHAR(50) = NULL,  
    @CDemandID NVARCHAR(50) = NULL,  
    @AddedBy NVARCHAR(50) = NULL  
AS    
BEGIN    
    WITH RankedDemands AS (    
        SELECT     
            r.FlatID,  
            r.PaymentStatus,  
            b.ProjectID,     
            b.BlockID,     
            r.CWID,   
            r.PDFName,  
            r.CDemandID,    
            r.AddedBy, 
            r.AddedDate,
            b.ApplicantFirstName,  
            ROW_NUMBER() OVER (  
                PARTITION BY r.FlatID  -- Group by FlatID  
                ORDER BY r.CWID DESC    -- Prioritize based on CWID (or another column)  
            ) AS RowNum    
        FROM tblFlatCustomisationDemands r  
        LEFT JOIN tblFlatCustomerBookingDetails b  
            ON r.FlatID = b.FlatID  
        WHERE     
            (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
            (@FlatID IS NULL OR @FlatID = '' OR r.FlatID = @FlatID) AND    
            (@CWID IS NULL OR @CWID = '' OR r.CWID = @CWID) AND    
            (@CDemandID IS NULL OR @CDemandID = '' OR r.CDemandID = @CDemandID) AND    
            (@AddedBy IS NULL OR @AddedBy = '' OR r.AddedBy = @AddedBy) AND    
            (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID)    
    )    
    SELECT  
        CDemandID,  
        CWID,  
        FlatID,   
        ProjectID,   
        BlockID,   
        PaymentStatus,  
        AddedBy,
        AddedDate,
        ApplicantFirstName  
    FROM RankedDemands  
    WHERE RowNum = 1 Order By AddedDate Desc, CDemandID Desc;  -- Fetch only the first record per FlatID    
END;  


select * from tblFlatCustomisationDemands 
select * from tblFlatCustomisationTransaction 




sp_helptext CalculatePaymentBalance
Alter Procedure CalculatePaymentBalance  
@PaymentUpdatedBy nvarchar(50),  
@CDemandID int,  
@FlatID int  
As  
Begin  
SELECT sum(TBCT.PaidAmount) As PaidAmount
FROM tblFlatCustomisationTransaction TBCT  
inner JOIN tblFlatCustomisationDemands TBLD ON TBLD.CDemandID = TBCT.CDemandID  
inner JOIN tblFlatCustomisationWorks TFW ON TBLD.CWID = TFW.CWID  
WHERE TBCT.PaymentUpdatedBy = @PaymentUpdatedBy  
  AND TBLD.CDemandID = @CDemandID  
  AND TBCT.FlatID = @FlatID  
  
End





exec CalculatePaymentBalance
@PaymentUpdatedBy='1',
@CDemandID='2',
@FlatID='2'



sp_helptext ViewFlatCustomisationTransactionListByFlatIDandPUpdatedBy


  
CREATE Procedure ViewFlatCustomisationTransactionListByFlatIDandPUpdatedBy      
@FlatID Int,    
@PaymentUpdatedBy nvarchar(50)    
As      
Begin      
Select TBCT.CTID,TBCT.FlatID,TBCT.CDemandID,TBCT.PaidAmount,TBCT.ReceiptPDF,TPM.PaymentMode,TBCT.PaymentUpdatedBy,TBCT.PaymentUpdatedDate,TFW.WorkTitle FROM tblFlatCustomisationTransaction TBCT   
Left Join tblFlatCustomisationDemands TBLD on TBLD.CDemandID=TBCT.CDemandID  
Left Join tblPaymentMode TPM on TBCT.PaymentMode = TPM.PaymentModeID  
left join tblFlatCustomisationWorks TFW on TBLD.CWID=TFW.CWID where TBCT.FlatID=@FlatID  and TBCT.PaymentUpdatedBy=@PaymentUpdatedBy  Order by TBCT.RecAddedDate Desc  
End

 exec ViewFlatCustomisationTransactionListByFlatIDandPUpdatedBy
 @FlatID='2',
 @PaymentUpdatedBy='1'



 select * from sys.tables







 Create PROCEDURE [dbKey2h].[DeleteCustomizationTransaction]  
    @FlatID INT  
AS  
BEGIN  
    IF EXISTS (SELECT 1 FROM tblFlatCustomisationWorks WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCustomisationWorks WHERE FlatID = @FlatID;
    END

    IF EXISTS (SELECT 1 FROM tblFlatCustomisationDemands WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCustomisationDemands WHERE FlatID = @FlatID;
    END

    IF EXISTS (SELECT 1 FROM tblFlatCustomisationTransaction WHERE FlatID = @FlatID)
    BEGIN
        DELETE FROM tblFlatCustomisationTransaction WHERE FlatID = @FlatID;
    END
END;



select * from sys.tables
select * from tblFlatCustomisationWorks
select * from tblFlatCustomisationDemands
select * from tblFlatCustomisationTransaction



Create Table tblFlatHouseFacing (FacingID int identity(1,1) primary key,Facing nvarchar(100),AddedDate Datetime)


insert into tblFlatHouseFacing (Facing,AddedDate)Values('East',Getdate()),('West',Getdate()),('North',Getdate()),('South',Getdate())

select * from tblFlatHouseFacing



Create table tblFlatUnitdType (UnitdID int Identity (1,1) primary key,UnitdType nvarchar(100),AddedDate Datetime)

Insert into tblFlatUnitdType (UnitdType,AddedDate) Values('1 BHK',GetDate()),('2 BHK',GetDate()),('2.5 BHK',GetDate()),('3 BHK',GetDate()),('4 BHK',GetDate()),('5 BHK',GetDate())


Create Procedure ViewUnitdType
As
Begin
Select * from tblFlatUnitdType
End


Create Procedure ViewFlatHouseFacing
As
Begin
Select * from tblFlatHouseFacing
End

