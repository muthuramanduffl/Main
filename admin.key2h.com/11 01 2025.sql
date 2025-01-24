use LocalDbKey2h


Select * from sys.tables
Select * from tblClientDashboardIssues





sp_Helptext ViewRMDetails


  
CREATE Procedure ViewRMDetails  
@AddedBy nvarchar(50)  
As  
Begin  
Select * from tblClientUsers where ClientID =@AddedBy  
End


sp_helptext ViewPaymentsheduleByFlatandPLID

Create Procedure ViewPaymentsheduleByFlatandPLID  
@FlatID int,  
@PaymentLabelID int  
As  
Begin  
Select * from tblCustomerPaymentSchedule where PaymentLabelID=@PaymentLabelID and FlatID=@FlatID  
End


Alter Procedure CustomerPaymentShedule
@FlatID int,
@AddedBy nvarchar(50)
As
Begin

Delete tblCustomerPaymentSchedule  where FlatID=@FlatID and AddedBy=@AddedBy

END


select * from    tblCustomerPaymentSchedule where FlatID=42


sp_helptext ViewAllFlatCustomerTransactionByFlatID

Alter Procedure ViewAllFlatCustomerTransactionByFlatID  
@FlatID int  
As  
Begin  
SELECT   
    tblct.TransactionID,  
    tblct.PaymentUpdatedBy,  
    tblct.PaymentUpdatedDate,  
    tbldemand.ProjectID,  
    tbldemand.BlockNo,  
    tblct.FlatID,  
    tblct.PaymentStatus,  
    tblct.ReceiptPDF,  
    tblct.PaidAmount,  
    tblct.PaymentMode,  
    tbldemand.PaymentLabelID,  
    payment.PaymentLabel    
FROM   
    tblFlatCustomerDemands tbldemand  
INNER JOIN   
    tblFlatCustomerTransaction tblct   
    ON tbldemand.DemandID = tblct.DemandID  
INNER JOIN   
    tblPaymentLabels payment   
    ON tbldemand.PaymentLabelID = payment.PID where tblct.FlatID=@FlatID  order by PaymentUpdatedDate Desc
End  


exec ViewAllFlatCustomerTransactionByFlatID 
@FlatID='44'


select * from tblFlatCustomerTransaction where @FlatID


sp_helptext   ViewAllFlatCostDetails

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
    WHERE RowNum = 1 order By Addeddate Desc;  -- Fetch only the first DemandID  
END  
  

  select * from tblFlatCostDetails where FLatID='49'

  select * from tblflat 




  exec ViewAllFlatCostDetails  
    @ProjectID ='',       
    @FlatID ='49',          
    @CostID ='',        
    @BlockID ='' 



    sp_helptext viewFlatCostDetailsByFlatID


      
  Alter Procedure viewFlatCostDetailsByFlatID    
        @FlatID int    
        As    
        Begin    
        select tblcd.*,tblc.* from tblFlatCostDetails tblcd left join tblProjectCostLabels tblc on tblc.CostlabelID = tblcd.CostLabelID Where FlatID=@FlatID   Order By tblcd.AddedDate Desc  
        End


        exec viewFlatCostDetailsByFlatID 
        @FlatID=49