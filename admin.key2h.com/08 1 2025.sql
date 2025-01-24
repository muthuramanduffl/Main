

select * from sys.tables 
select * from tblProjects
select * from tblFlatCustomerKYCDocs
select * from tblClientUsers

Alter table tblFlatCustomerKYCDocs add UpdatedBy nvarchar(100),UpdatedDate DateTime

sp_help tblFlatCustomerKYCDocs


Alter Procedure AddFlatCustomerKYCDocs
@FlatID int,
@ProjectID int,
@SaleDeedDraft nvarchar(512),
@SaleDeedFinal nvarchar(512),
@SaleAgreementDraft nvarchar(512),
@SaleAgreementFinal nvarchar(512),
@AllotmentLetter nvarchar(512),
@WelcomeLetter nvarchar(512),
@DemandLetter nvarchar(512),
@PaymentReceipt nvarchar(512),
@Bill nvarchar(512),
@PaymentSchedule nvarchar(512),
@EBCard nvarchar(512),
@HandingOverDocs nvarchar(512),
@CCUpdation nvarchar(512),
@NOCforHandover nvarchar(512),
@OtherDocuments nvarchar(512),
@BankDocuments nvarchar(512),
@AddedBy nvarchar(100),
@Addeddate Datetime
As
Begin
Insert into tblFlatCustomerKYCDocs(FlatID,ProjectID,SaleDeedDraft,SaleDeedFinal,SaleAgreementDraft,SaleAgreementFinal,AllotmentLetter,WelcomeLetter,DemandLetter,PaymentReceipt,Bill,PaymentSchedule,EBCard,HandingOverDocs,CCUpdation,NOCforHandover,OtherDocuments,BankDocuments,AddedBy,Addeddate) Values(@FlatID,@ProjectID,@SaleDeedDraft,@SaleDeedFinal,@SaleAgreementDraft,@SaleAgreementFinal,@AllotmentLetter,@WelcomeLetter,@DemandLetter,@PaymentReceipt,@Bill,@PaymentSchedule,@EBCard,@HandingOverDocs,@CCUpdation,@NOCforHandover,@OtherDocuments,@BankDocuments,@AddedBy,@Addeddate)
End


Create Procedure UpdateFlatCustomerKYCDocs
@DocID int,
@FlatID int,
@ProjectID int,
@SaleDeedDraft nvarchar(512),
@SaleDeedFinal nvarchar(512),
@SaleAgreementDraft nvarchar(512),
@SaleAgreementFinal nvarchar(512),
@AllotmentLetter nvarchar(512),
@WelcomeLetter nvarchar(512),
@DemandLetter nvarchar(512),
@PaymentReceipt nvarchar(512),
@Bill nvarchar(512),
@PaymentSchedule nvarchar(512),
@EBCard nvarchar(512),
@HandingOverDocs nvarchar(512),
@CCUpdation nvarchar(512),
@NOCforHandover nvarchar(512),
@OtherDocuments nvarchar(512),
@BankDocuments nvarchar(512),
@UpdatedBy nvarchar(100),
@UpdatedDate DateTime
As
Begin
Update tblFlatCustomerKYCDocs set FlatID=@FlatID,ProjectID=@ProjectID,SaleDeedDraft=@SaleDeedDraft,SaleDeedFinal=@SaleDeedFinal,SaleAgreementDraft=@SaleAgreementDraft,SaleAgreementFinal=@SaleAgreementFinal,AllotmentLetter=@AllotmentLetter,WelcomeLetter=@WelcomeLetter,DemandLetter=@DemandLetter,PaymentReceipt=@PaymentReceipt,Bill=@Bill,PaymentSchedule=@PaymentSchedule,EBCard=@EBCard,HandingOverDocs=@HandingOverDocs,CCUpdation=@CCUpdation,NOCforHandover=@NOCforHandover,OtherDocuments=@OtherDocuments,BankDocuments=@BankDocuments,UpdatedBy=@UpdatedBy,UpdatedDate=@UpdatedDate where DocID=@DocID
End













CREATE PROCEDURE CheckRecordExistsFlatCustomerKYCDocsByFlatIDandAddedBy
    @FlatID INT,
    @AddedBy nvarchar(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM tblFlatCustomerKYCDocs WHERE FlatID = @FlatID and AddedBy=@AddedBy)
        SELECT CAST(1 AS BIT) AS ExistsFlag -- True
    ELSE
        SELECT CAST(0 AS BIT) AS ExistsFlag -- False
END


exec CheckRecordExistsFlatCustomerKYCDocsByFlatIDandAddedBy
@FlatID='44',
@AddedBy ='1'

update tblFlatCustomerKYCDocs set AddedBy='1' where DociD='3'

select * from tblFlatCustomerKYCDocs




Alter Procedure DeleteKYCByDocID
@DocID int,
@AddedBy nvarchar(50)
As
Begin
delete tblFlatCustomerKYCDocs where DocID=@DocID and Addedby=@AddedBy
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
    SET @SQL = 'SELECT * FROM tblProjects WHERE 1 = 1';          
          
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




Alter PROCEDURE ViewAllFlatCustomerKYCDocs          
@AddedBy varchar(50)=null,
@ProjectID int=Null,
@BlockID int=Null,
@FlatID int=Null,
@DocID int=Null
AS        
BEGIN          
    SET NOCOUNT ON;          
            
    DECLARE @SQL NVARCHAR(MAX);          
    DECLARE @ParameterDef NVARCHAR(MAX);          
             
    SET @ParameterDef = '@ProjectID INT, @AddedBy INT, @BlockID INT,@FlatID INT,@DocID INT';          
           
    SET @SQL = 'SELECT tblk.*,tbfc.blockID,tbfc.ApplicantFirstName FROM tblFlatCustomerKYCDocs tblK  Inner Join tblFlatCustomerBookingDetails tbfc on tblk.FlatID=tbfc.FlatID    WHERE 1 = 1';          
            
    IF (@ProjectID IS NOT NULL And @ProjectID<>'')          
    BEGIN          
        SET @SQL = @SQL + ' AND tblk.ProjectID = @ProjectID';          
    END          
                           
    IF (@BlockID IS NOT NULL and @BlockID<>'')          
    BEGIN          
        SET @SQL = @SQL + ' AND tbfc.BlockID = @BlockID';          
    END    
    
    IF (@FlatID IS NOT NULL and @FlatID<>'')          
    BEGIN          
        SET @SQL = @SQL + ' AND tblk.FlatID = @FlatID';          
    END          

    IF (@AddedBy IS NOT NULL and @AddedBy<>'')          
    BEGIN          
        SET @SQL = @SQL + ' AND tblk.AddedBy = @AddedBy';          
    END  

    IF (@DocID IS NOT NULL and @DocID<>'')          
    BEGIN          
        SET @SQL = @SQL + ' AND tblk.DocID = @DocID';          
    END          
             
    SET @SQL = @SQL + ' ORDER BY tblk.AddedDate DESC';          
          
  
    EXEC sp_executesql @SQL,         
        @ParameterDef,         
        @ProjectID = @ProjectID,         
        @AddedBy=@AddedBy,
        @BlockID =@BlockID,
        @FlatID=@FlatID,
        @DocID=@DocID
END;  


exec ViewAllFlatCustomerKYCDocs   
@AddedBy ='',
@ProjectID ='',
@BlockID ='',
@FlatID ='',
@DocID =''





select * from tblFlatCustomerBookingDetails
select * from tblFlatCustomerKYCDocs


Alter table tblFlatCustomerKYCDocs add BankDocuments nvarchar(512)


sp_help tblFlatCustomerBookingDetails
sp_help tblFlatCustomerKYCDocs


