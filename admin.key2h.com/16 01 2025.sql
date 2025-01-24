Create Procedure ExistCostLabelParameterFlatcostDetailsByCIDandAddedby
    @FlatID INT,  
    @AddedBy NVARCHAR(50) 
As
Begin
  SELECT Count(*)  
               FROM tblFlatCostDetails   
               WHERE FlatID = @FlatID   
                 AND AddedBy = @AddedBy   
                 AND CostLabelID IN ('1','3','6', '7', '8')
End


exec   

@FlatID='2',
@AddedBy='1'




  select * from tblFlatCostDetails where  FlatID='2' 



  sp_helptext DeleteShedulepaymentstages

   CREATE Procedure DeleteShedulepaymentstages    
@PSID Int    
As    
Begin    
Delete tblFlatCustomerDemands Where PSID=@PSID    
Delete tblCustomerPaymentSchedule Where PSID=@PSID    
End 


select * from tblCustomerPaymentSchedule