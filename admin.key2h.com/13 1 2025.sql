select * from sys.tables
select * from tblClientUsers
select * from tblFlatCostDetails
select * from tblCustomerPaymentSchedule 
select * from tblFlatCustomerDemands
select * from tblFlatCustomerTransaction

Delete tblFlatCustomerTransaction where TransactionID='3'

select * from tblPaymentLabels
select * from tblProjectCostLabels


sp_helptext CustomerPaymentShedule

  
CREATE Procedure CustomerPaymentShedule  
@FlatID int,  
@AddedBy nvarchar(50)  
As  
Begin   
Delete tblCustomerPaymentSchedule  where FlatID=@FlatID and AddedBy=@AddedBy  
END


Alter PROCEDURE DeleteCustomerPaymentSchedule
    @FlatID INT,
    @AddedBy NVARCHAR(50)
AS
    BEGIN
        DELETE FROM tblCustomerPaymentSchedule
        WHERE FlatID = @FlatID AND AddedBy = @AddedBy
         DELETE FROM tblFlatCustomerDemands
        WHERE FlatID = @FlatID AND AddedBy = @AddedBy
END








use dbkey2h


Alter PROCEDURE CheckExistProjectCostLabelsParameterByCLID
    @CostLabelID INT,
    @AddedBy NVARCHAR(50)
AS
BEGIN
SELECT CASE
           WHEN EXISTS (
               SELECT 1 
               FROM tblProjectCostLabels 
               WHERE CostlabelID = @CostLabelID 
                 AND AddedBy = @AddedBy 
                 AND CostLabelID NOT IN ('1','3','6', '7', '8')
           ) THEN 0
           ELSE 1
END AS RecordStatus
End




 
 sp_help tblProjectCostLabels


 sp_helptext DeleteShedulepaymentstages

 Alter Procedure DeleteShedulepaymentstages  
@PSID Int  
As  
Begin  
Delete tblFlatCustomerDemands Where PSID=@PSID  
Delete tblCustomerPaymentSchedule Where PSID=@PSID  
End  


Create Procedure DeleteFlatCustomerDemands
As  
Begin  

Delete tblFlatCustomerDemands Where PSID=@PSID  
End  


Create Procedure ViewAvailtransactionReceiptByPSID
@PSID int,
@AddedBy nvarchar(50)
As
Begin
select tbd.*,tct.* from tblFlatCustomerDemands tbd inner join tblFlatCustomerTransaction tct on tbd.DemandID=tct.DemandID where tbd.PSID=@PSID AND tct.PaymentUpdatedBy=@AddedBy
End

exec ViewAvailtransactionReceiptByPSID
@PSID='3',
@AddedBy='1'