   select * from tblFlatCustomisationTransaction where flatID='44'


   

Create Procedure CalculatePaymentBalance
@PaymentUpdatedBy nvarchar(50),
@CDemandID int,
@FlatID int
As
Begin
SELECT TOP 1 TBCT.PaidAmount
FROM tblFlatCustomisationTransaction TBCT
inner JOIN tblFlatCustomisationDemands TBLD ON TBLD.CDemandID = TBCT.CDemandID
inner JOIN tblFlatCustomisationWorks TFW ON TBLD.CWID = TFW.CWID
WHERE TBCT.PaymentUpdatedBy = @PaymentUpdatedBy
  AND TBLD.CDemandID = @CDemandID
  AND TBCT.FlatID = @FlatID
ORDER BY TBCT.RecAddedDate DESC;
End


Alter Procedure ViewFlatCustomisationTransactionListByFlatIDandPUpdatedBy    
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
@FlatID='44',
@PaymentUpdatedBy='1'