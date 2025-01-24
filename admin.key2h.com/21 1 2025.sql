



sp_helptext ViewAllLeadsource


Create Procedure ViewAllLeadsource  
  
as  
Begin  
select * from tblLeadSource    
End

Update tblLeadSource set LeadSourceName='Referal' where LeadID=10



select * from sys.tables
select * from tblFlatCustomerBookingDetails
select * from tblcustomerFlatBookingReferedby
select * from tblClientDashboardIssues
truncate table tblClientDashboardIssues

Delete tblFlatCustomerBookingDetails where FlatCustomerID in ('10','11')


Create Table tblcustomerFlatBookingReferedby(RefID int Identity(1,1) primary key,Referedby nvarchar(50),AddedDate Datetime) 

Insert into tblcustomerFlatBookingReferedby (Referedby,AddedDate)Values('Employee Referance',Getdate()),('Customer Referance',GetDate()),('Prospect Reference',GetDate())

alter table tblFlatCustomerBookingDetails  add ReferedBy nvarchar(80)


Create Procedure ViewFlatBookingReferedby
As
Begin
select * from tblcustomerFlatBookingReferedby
ENd




sp_helptext AddFlatCustomerBookingDetails

Alter Procedure AddFlatCustomerBookingDetails 
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
FatherorSpouseName,     DoB,      WhatsappNumber,     Profession,     CompanyName,     Designation,     CurrentAddress,     PermanentAddress,     ResidentialStatus,     CoapplicantRelationship,     CityID,     StateID,     Pincode,     Reference1,     Reference2,     LeadSource,     LoanTakenStatus,     BankName,     ApplicantPhoto,     ApplicantPAN,     ApplicantAadhar,     CoApplicantPhoto,     CoApplicantPAN,     CoApplicantAadhar,     PoAName,     PoAAddress,     PoAPAN,     PoAAdhar,     PoADOB,     
CRMID,     CustomerLoginStatus,     BookingDate,     Amountpaid,     PaymentMode,     Bookingknowledgement,     CarparkAllocated,     NumberofSlots,     Allottedcarparkslotnumber,     Registrationcharges,     RegistrationDate,     RegistrationOffice,   ReferedBy,Addeddate,     Addedby     )      
Values(@CustomerID,     @ProjectID,     @BlockID,     @FlatID,     @ApplicantFirstName,     @ApplicantLastName,     @CoapplicantFirstName,     @CoapplicantLastName,     @Gender,     @EmailID,     @Mobilenumber1,     @Mobilenumber2,     @FatherorSpouseName,     @DoB,      @WhatsappNumber,     @Profession,     @CompanyName,     @Designation,     @CurrentAddress,     @PermanentAddress,     @ResidentialStatus,     @CoapplicantRelationship,     @CityID,     @StateID,     @Pincode,     @Reference1,     @Reference2,     @LeadSource,     @LoanTakenStatus,     @BankName,     @ApplicantPhoto,     @ApplicantPAN,     @ApplicantAadhar,     @CoApplicantPhoto,     @CoApplicantPAN,     @CoApplicantAadhar,     @PoAName,     @PoAAddress,  
   @PoAPAN,     @PoAAdhar,     @PoADOB,     @CRMID,     @CustomerLoginStatus,     @BookingDate,     @Amountpaid,     @PaymentMode,     @Bookingknowledgement,     @CarparkAllocated,     @NumberofSlots,     @Allottedcarparkslotnumber,     @Registrationcharges,     @RegistrationDate,     @RegistrationOffice,    @ReferedBy, @Addeddate,     @Addedby     );    
   -- Update FlatLoginID using FlatID and @FlatName   
   Update tblFlatCustomerBookingDetails     Set FlatLoginID = @FlatName + CAST(FlatID AS NVARCHAR(50)) 
   Where FlatID = @FlatID;
   End 



   sp_helptext UpdateFlatCustomerBookingDetails


       
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
Updateddate=@Updateddate,    
CustomerID =@CustomerID ,  
UpdatedBy=@UpdatedBy  where  FlatCustomerID=@FlatCustomerID      
End    


use dbkey2h

sp_helptext UpdateProjects


  
alter procedure Updateprojects    
@ProjectID int,    
@ClientID int,    
@ProjectName varchar(200),    
@ProjectLogo varchar(200),    
@Location varchar(256),    
@Address varchar(256),    
@State int,    
@City int,    
@PostalCode int,    
@GoogleMapLink nvarchar(200),    
@BlockCount int,    
@FlatCount int,    
@LandArea varchar(256),    
@RERANumber nvarchar(512),    
@ProjectStatus int,    
@ProjectDisplayStatus bit,    
@ProjectStatusPercentage int,    
@SplashScreenImage nvarchar(512),    
@LocationMap varchar(256),    
@BankName varchar(256),    
@AccountName varchar(256),    
@AccountNumber nvarchar(50),    
@IFSCNumber varchar(256),    
@BranchName varchar(256),    
@Latitude nvarchar(512),  
@Longitude nvarchar(512),  
@UpdatedBy varchar(256),    
@UpdatedDate datetime    
As    
Begin    
Update tblProjects     
set    
ClientID=@ClientID,    
ProjectName=@ProjectName    
,ProjectLogo=@ProjectLogo,    
Location=@Location,    
Address=@Address,    
State=@State,    
City=@City,    
PostalCode=@PostalCode,    
GoogleMapLink=@GoogleMapLink,    
BlockCount=@BlockCount,    
FlatCount=@FlatCount,    
LandArea=@LandArea,    
RERANumber=@RERANumber,    
ProjectStatus=@ProjectStatus,    
ProjectDisplayStatus=@ProjectDisplayStatus,    
ProjectStatusPercentage=@ProjectStatusPercentage,    
SplashScreenImage=@SplashScreenImage,    
LocationMap=@LocationMap,    
BankName=@BankName,    
AccountName=@AccountName,    
AccountNumber=@AccountNumber,    
IFSCNumber=@IFSCNumber,    
BranchName=@BranchName,    
Longitude=@Longitude, 
Latitude=@Latitude,  
UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate  where ProjectID=@ProjectID    
End



sp_helptext AddProjects

Alter procedure AddProjects    
@ClientID int,    
@ProjectName varchar(200),    
@ProjectLogo varchar(200),    
@Location varchar(256),    
@Address varchar(256),    
@State int,    
@City int,    
@PostalCode int,    
@GoogleMapLink nvarchar(200),    
@BlockCount int,    
@FlatCount int,    
@LandArea varchar(256),    
@RERANumber nvarchar(512),    
@ProjectStatus int,    
@ProjectDisplayStatus bit,    
@ProjectStatusPercentage int,    
@SplashScreenImage nvarchar(512),    
@LocationMap varchar(256),    
@Latitude nvarchar(512),  
@Longitude nvarchar(512),  
@BankName varchar(256),    
@AccountName varchar(256),    
@AccountNumber nvarchar(50),    
@IFSCNumber varchar(256),    
@BranchName varchar(256),    
@AddedBy varchar(256),    
@AddedDate datetime, @ProjectID INT OUTPUT     
As    
Begin    
insert into tblProjects(ClientID,ProjectName,ProjectLogo,Location,Address,State,City,PostalCode,GoogleMapLink,BlockCount,FlatCount,LandArea,RERANumber,ProjectStatus,ProjectDisplayStatus,ProjectStatusPercentage,SplashScreenImage,LocationMap,BankName,AccountName,AccountNumber,IFSCNumber,BranchName,Latitude,Longitude,AddedBy,AddedDate) values(@ClientID,@ProjectName,@ProjectLogo,@Location,@Address,@State,@City,@PostalCode,@GoogleMapLink,@BlockCount,@FlatCount,@LandArea,@RERANumber,@ProjectStatus,@ProjectDisplayStatus,@ProjectStatusPercentage,@SplashScreenImage,@LocationMap,@BankName,@AccountName,@AccountNumber,@IFSCNumber,@BranchName,@Longitude,@Latitude,@AddedBy,@AddedDate) SET @ProjectID = SCOPE_IDENTITY();    
End    




sp_helptext AddProjectHomeScreen


CREATE procedure AddProjectHomeScreen  
@ProjectID int,  
@BHK varchar(200),  
@Sqft varchar(200),  
@FlatCount varchar(256),  
@AddedBy varchar(256),  
@AddedDate datetime  
As  
Begin  
insert into tblProjectHomeScreen(ProjectID,Apartments,Bhk,SquareFeet,AddedBy,AddedDate,Status) values(@ProjectID,@FlatCount,@BHK,@Sqft,@AddedBy,@AddedDate,1)  
End  



Alter Procedure UpdateProjectHomeScreen
@ProjectID int,  
@BHK varchar(200),  
@Sqft varchar(200),    
@UpdatedBy varchar(256),  
@UpdatedDate datetime 
As
Begin
Update tblProjectHomeScreen set BHK=@BHK,SquareFeet=@Sqft,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate where ProjectID=@ProjectID
End





sp_helptext ViewAllProjects

Alter PROCEDURE ViewAllProjects          
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





select * from tblProjects
select * from tblProjectHomeScreen

delete tblProjects where ProjectID='3'
delete tblProjectHomeScreen where ProjectID='3'


alter table tblProjects drop column BHKTypes ,SquareFeetRange





sp_helptext ViewAllFlatCostDetails

Alter PROCEDURE ViewAllFlatCostDetails    
    @ProjectID INT = NULL,         
    @FlatID INT = NULL,            
    @CostID INT = NULL,          
    @BlockID INT = NULL            
AS    
BEGIN    
    WITH RankedDemands AS (    
        SELECT     
            FlatID,     
            ProjectID,     
            BlockID,     
            CostID,  
            AddedDate,  
            AddedBy,    
            ROW_NUMBER() OVER (PARTITION BY FlatID, ProjectID, BlockID ORDER BY CostID) AS RowNum    
        FROM tblFlatCostDetails    
        WHERE     
            (@ProjectID IS NULL OR @ProjectID = '' OR ProjectID = @ProjectID) AND    
            (@FlatID IS NULL OR @FlatID = '' OR FlatID = @FlatID) AND    
            (@CostID IS NULL OR @CostID = '' OR CostID = @CostID) AND    
            (@BlockID IS NULL OR @BlockID = '' OR BlockID = @BlockID)    
    )    
    SELECT FlatID, ProjectID, BlockID, CostID, AddedBy    
    FROM RankedDemands    
    WHERE RowNum = 1 order By Addeddate Desc, CostID Desc;  -- Fetch only the first DemandID    
END    

exec ViewAllFlatCostDetails
 @FlatID='6',
 @ProjectID='2',
 @BlockID='3'
select * from tblFlatCostDetails



sp_helptext viewFlatCostDetailsByFlatID


 alter Procedure viewFlatCostDetailsByFlatID      
        @FlatID int      
        As      
        Begin      
        select tblcd.*,tblc.* from tblFlatCostDetails tblcd left join tblProjectCostLabels tblc on tblc.CostlabelID = tblcd.CostLabelID Where FlatID=@FlatID   Order By tblcd.AddedDate Desc,tblcd.CostID Desc  
        End


 select tblcd.*,tblc.* from tblFlatCostDetails tblcd left join tblProjectCostLabels tblc on tblc.CostlabelID = tblcd.CostLabelID    Order By tblcd.AddedDate Desc,tblcd.CostID Desc    

 select * from tblFlatCostDetails



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

select * from tblClientDashboardIssues


sp_helptext ViewAllflatBookingCustomerDetails

CREATE PROCEDURE ViewAllFlatBookingCustomerDetails      
    @ProjectID INT = NULL,          
    @BlockID INT = NULL,        
    @FlatID INT = NULL,      
    @strsearch NVARCHAR(60) = NULL,      
    @FlatCustomerID INT = NULL      
AS      
BEGIN      
    SET NOCOUNT ON;            
          
    DECLARE @SQL NVARCHAR(MAX);            
    DECLARE @ParameterDef NVARCHAR(MAX);            
          
    -- Define the parameter types correctly            
    SET @ParameterDef = '        
        @ProjectID INT,        
        @BlockID INT,        
        @FlatID INT,        
        @strsearch NVARCHAR(60),      
        @FlatCustomerID INT';            
          
    -- Base query            
    SET @SQL = 'SELECT TFCB.*,TF.FlatName FROM tblFlatCustomerBookingDetails TFCB inner join  tblFlat TF on TFCB.FlatID =TF.FlatID WHERE 1 = 1';            
          
    -- Add filters dynamically            
    IF (@ProjectID IS NOT NULL AND @ProjectID<> '')            
    BEGIN            
        SET @SQL = @SQL + ' AND TFCB.ProjectID = @ProjectID';            
    END            
          
    IF (@BlockID IS NOT NULL AND @BlockID <> '')            
    BEGIN            
        SET @SQL = @SQL + ' AND TFCB.BlockID = @BlockID';            
    END            
          
    IF (@FlatID IS NOT NULL AND @FlatID <> '')            
    BEGIN            
        SET @SQL = @SQL + ' AND TFCB.FlatID = @FlatID';            
    END            
          
    IF (@FlatCustomerID IS NOT NULL AND @FlatCustomerID <>'')            
    BEGIN            
        SET @SQL = @SQL + ' AND TFCB.FlatCustomerID = @FlatCustomerID';            
    END            
          
    IF (@strsearch IS NOT NULL AND @strsearch <> '')            
    BEGIN            
        SET @SQL = @SQL + ' AND (TFCB.Mobilenumber1 LIKE ''%' + @strsearch + '%'' OR TF.FlatName LIKE ''%' + @strsearch + '%'')';            
    END      
      
    -- Add ORDER BY clause            
    SET @SQL = @SQL + ' ORDER BY TFCB.AddedDate DESC';            
          
    -- Execute the dynamic query            
    EXEC sp_executesql @SQL,           
        @ParameterDef,           
        @ProjectID = @ProjectID,         
        @BlockID = @BlockID,        
        @FlatID = @FlatID,      
        @strsearch = @strsearch,      
        @FlatCustomerID = @FlatCustomerID;      
END      


exec ViewAllFlatBookingCustomerDetails 