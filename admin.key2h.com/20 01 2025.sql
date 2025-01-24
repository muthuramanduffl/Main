




select * from sys.tables
select * from tblClientDashboardIssues
truncate table tblClientDashboardIssues

select * from tblFlatCustomerBookingDetails
select * from tblProjects

update tblFlatCustomerBookingDetails set BankName='1' where FlatCustomerID='8'


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


sp_help tblProjects



sp_helptext UpdateProjects


Alter procedure Updateprojects  
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



sp_helptext AddFlatCustomerBookingDetails



Create table tblIndiaBankList (BankID int  identity(1,1)Primary key,BankName varchar(255),BankType varchar(50),IsStatus BIT,addedDate datetime)

Select * from tblIndiaBankList



Insert into tblIndiaBankList (BankName,BankType,IsStatus,addedDate) Values('State Bank of India','Public Sector Banks','1',Getdate()),
('Bank of Baroda','Public Sector Banks','1',Getdate()),
('Bank of India','Public Sector Banks','1',Getdate()),
('Bank of Maharashtra','Public Sector Banks','1',Getdate()),
('Central Bank of India','Public Sector Banks','1',Getdate()),
('Indian Bank','Public Sector Banks','1',Getdate()),
('Indian Overseas Bank','Public Sector Banks','1',Getdate()),
('Punjab & Sind Bank','Public Sector Banks','1',Getdate()),
('UCO Bank','Public Sector Banks','1',Getdate()),
('Union Bank of India','Public Sector Banks','1',Getdate()),
('Axis Bank','Private Sector Banks','1',Getdate()),
('Bandhan Bank','Private Sector Banks','1',Getdate()),
('CSB Bank','Private Sector Banks','1',Getdate()),
('City Union Bank','Private Sector Banks','1',Getdate()),
('DCB Bank','Private Sector Banks','1',Getdate()),
('Dhanlaxmi Bank','Private Sector Banks','1',Getdate()),
('Federal Bank','Private Sector Banks','1',Getdate()),
('HDFC Bank','Private Sector Banks','1',Getdate()),
('ICICI Bank','Private Sector Banks','1',Getdate()),
('IDBI Bank','Private Sector Banks','1',Getdate()),
('IDFC FIRST Bank','Private Sector Banks','1',Getdate()),
('IndusInd Bank','Private Sector Banks','1',Getdate()),
('Jammu & Kashmir Bank','Private Sector Banks','1',Getdate()),
('Karnataka Bank','Private Sector Banks','1',Getdate()),
('Karur Vysya Bank','Private Sector Banks','1',Getdate()),
('Kotak Mahindra Bank','Private Sector Banks','1',Getdate()),
('Nainital Bank','Private Sector Banks','1',Getdate()),
('RBL Bank','Private Sector Banks','1',Getdate()),
('South Indian Bank','Private Sector Banks','1',Getdate()),
('Tamilnad Mercantile Bank','Private Sector Banks','1',Getdate()),
('Yes Bank','Private Sector Banks','1',Getdate()),
('Andhra Pradesh Grameena Vikas Bank','Regional Rural Banks','1',Getdate()),
('Assam Gramin Vikash Bank','Regional Rural Banks','1',Getdate()),
('Chhattisgarh Rajya Gramin Bank','Regional Rural Banks','1',Getdate()),
('Karnataka Gramin Bank','Regional Rural Banks','1',Getdate()),
('Kerala Gramin Bank','Regional Rural Banks','1',Getdate()),
('Maharashtra Gramin Bank','Regional Rural Banks','1',Getdate()),
('Punjab Gramin Bank','Regional Rural Banks','1',Getdate()),
('Tamil Nadu Grama Bank','Regional Rural Banks','1',Getdate()),
('Uttar Bihar Gramin Bank','Regional Rural Banks','1',Getdate())






Create Procedure ViewAllIndiaBankList
As
Begin
Select BankID,BankName From tblIndiaBankList
End




sp_helptext ViewPaymentsheduleByFlatandPLID

Create Procedure ViewPaymentsheduleByFlatandPLID  
@FlatID int,  
@PaymentLabelID int  
As  
Begin  
Select * from tblCustomerPaymentSchedule where PaymentLabelID=@PaymentLabelID and FlatID=@FlatID  
End



sp_helptext ViewFlatCustomerDemandsByFlatID
  
Create Procedure ViewFlatCustomerDemandsByFlatID   
@FlatID int  
As  
Begin  
 Select * from tblFlatCustomerDemands  where FlatID=@FlatID  
End  