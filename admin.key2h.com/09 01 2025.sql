

select * from sys.tables
select * from tblClientUsers
select * from tblClientDashboardIssues
select * from tblProjects
select * from tblFlat
select * from tblFlatNotifications
select * from tblProjectBlock where ProjectID='53'   1 2

UPDATE tblFlatNotifications SET Title='Customisation Payments' WHERE FNID=7;

update tblFlatNotifications set ReadStatus='0'





53


truncate table tblClientDashboardIssues

Alter Procedure ViewRMDetails
@AddedBy nvarchar(50)
As
Begin
Select * from tblClientUsers where ClientID =@AddedBy
End



sp_help tblClientUsers  


Create Procedure AlreadyExistProjectNamebyIDandName  
@ProjectID int,  
@ProjectName nvarchar(512)  
as    
Begin    
   SELECT COUNT(1)  
            FROM tblprojects  
            WHERE ProjectName = @ProjectName  
            AND (@ProjectID IS NULL OR ProjectID !=@ProjectID)  
End




Sp_helptext AddFlatCustomerBookingDetails

  
CREATE Procedure AddFlatCustomerBookingDetails  
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
@Addeddate Datetime,  
@Addedby varchar(50)  
  
As  
Begin  
Insert into tblFlatCustomerBookingDetails(CustomerID,  
ProjectID,  
BlockID,  
FlatID,  
ApplicantFirstName,  
ApplicantLastName ,  
CoapplicantFirstName,  
CoapplicantLastName,  
Gender,  
EmailID,  
Mobilenumber1,  
Mobilenumber2,  
FatherorSpouseName,  
DoB,   
WhatsappNumber,  
Profession,  
CompanyName,  
Designation,  
CurrentAddress,  
PermanentAddress,  
ResidentialStatus,  
CoapplicantRelationship,  
CityID,  
StateID ,  
Pincode ,  
Reference1,  
Reference2,  
LeadSource,  
LoanTakenStatus,  
BankName ,  
ApplicantPhoto,  
ApplicantPAN ,  
ApplicantAadhar ,  
CoApplicantPhoto ,  
CoApplicantPAN ,  
CoApplicantAadhar ,  
PoAName,  
PoAAddress,  
PoAPAN,  
PoAAdhar ,  
PoADOB ,  
CRMID ,  
CustomerLoginStatus ,  
BookingDate,  
Amountpaid,  
PaymentMode,  
Bookingknowledgement,  
CarparkAllocated ,  
NumberofSlots ,  
Allottedcarparkslotnumber,  
Registrationcharges,  
RegistrationDate,  
RegistrationOffice,  
Addeddate,  
Addedby  
) Values(@CustomerID,  
@ProjectID,  
@BlockID,  
@FlatID,  
@ApplicantFirstName,  
@ApplicantLastName ,  
@CoapplicantFirstName,  
@CoapplicantLastName,  
@Gender,  
@EmailID,  
@Mobilenumber1,  
@Mobilenumber2,  
@FatherorSpouseName,  
@DoB,   
@WhatsappNumber,  
@Profession,  
@CompanyName,  
@Designation,  
@CurrentAddress,  
@PermanentAddress,  
@ResidentialStatus,  
@CoapplicantRelationship,  
@CityID,  
@StateID ,  
@Pincode ,  
@Reference1,  
@Reference2,  
@LeadSource,  
@LoanTakenStatus,  
@BankName ,  
@ApplicantPhoto,  
@ApplicantPAN ,  
@ApplicantAadhar ,  
@CoApplicantPhoto ,  
@CoApplicantPAN ,  
@CoApplicantAadhar ,  
@PoAName,  
@PoAAddress,  
@PoAPAN,  
@PoAAdhar ,  
@PoADOB ,  
@CRMID ,  
@CustomerLoginStatus ,  
@BookingDate,  
@Amountpaid,  
@PaymentMode,  
@Bookingknowledgement,  
@CarparkAllocated ,  
@NumberofSlots ,  
@Allottedcarparkslotnumber,  
@Registrationcharges,  
@RegistrationDate,  
@RegistrationOffice,  
@Addeddate,  
@Addedby  
)  
  
End  






Create Procedure ProjectBlockCountGetByPIDandAby
@ProjectID int,
@AddedBy nvarchar(50)
As
Begin
select BlockCount from tblProjects where ProjectID=@ProjectID and AddedBy=@AddedBy
End

exec BlockCountGetByPIDandABy 
@ProjectID='44',
@AddedBy='1'


drop procedure BlockCountGetBy

Create Procedure BlockCountGetByPIDandABy
@ProjectID int,
@AddedBy nvarchar(50)
As
Begin
select Count(BlockID) from tblProjectBlock where ProjectID=@ProjectID and AddedBy=@AddedBy
End


exec ProjectBlockCountGetByPIDandAby 
@ProjectID='44',
@AddedBy='1'


Alter Procedure FlatCountGetByPIDandABy
@ProjectID int,
@BlockID int,
@AddedBy nvarchar(50)
As
Begin
select Count(FlatID) from tblFlat where ProjectID=@ProjectID and BlockID=@BlockID and AddedBy=@AddedBy
End




exec FlatCountGetByPIDandABy 
@ProjectID='54',
@BlockID='72',
@AddedBy='1'






select * from tblFlat


select *  from tblProjects where ProjectID='53'and AddedBy='1'
select *  from tblProjectBlock where ProjectID='53'and AddedBy='1'

select * from tblFlat where ProjectID='54' and BlockID='72'  and AddedBy='1'

delete tblFlat where ProjectID='54'


sp_helptext AlreadyExistProjectNamebyIDandName

  
Alter Procedure AlreadyExistProjectNamebyIDandName  
@ProjectID int,  
@ProjectName nvarchar(512),
@AddedBy nvarchar(50)
as    
Begin    
   SELECT COUNT(1)  
            FROM tblprojects  
            WHERE ProjectName = @ProjectName  
            AND (@ProjectID IS NULL OR ProjectID !=@ProjectID) AND  AddedBy=@AddedBy
End    