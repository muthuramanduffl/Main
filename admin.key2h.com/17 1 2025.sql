

sp_helptext CheckFlatCostDetailsExistAllCostLabelParameterByFlatID

CREATE Procedure CheckFlatCostDetailsExistAllCostLabelParameterByFlatID  
@FlatID int  
As  
Begin  
SELECT   
    CASE   
        WHEN NOT EXISTS (  
            SELECT CostLabelID  
            FROM (  
                SELECT CostLabelID  
                FROM tblProjectCostLabels  
                WHERE Parameter IN ('A', 'B', 'G', 'D', 'F')  
            ) AS TempCostLabels  
            EXCEPT  
            SELECT CostLabelID  
            FROM tblFlatCostDetails  
            WHERE FlatID = @FlatID  
        ) THEN 1   
        ELSE 0   
    END AS IsMatch;  
End  


sp_helptext ViewPaymentScheduleByFlatID

  
CREATE Procedure ViewPaymentScheduleByFlatID  
@FlatID int    
As    
Begin    
select tbs.*,tpl.PaymentLabel from tblCustomerPaymentSchedule tbs left join tblPaymentLabels TPL on tbs.PaymentLabelID =TPL.PID where FlatID=@FlatID  
End  


exec ViewPaymentScheduleByFlatID 
@FlatID='2'


sp_helptext ViewFlatCustomerDemandsByFlatID

  
Create Procedure ViewFlatCustomerDemandsByFlatID   
@FlatID int  
As  
Begin  
 Select * from tblFlatCustomerDemands  where FlatID=@FlatID  
End  



<!-- Update Icon -->
<i class="upd-img bi bi-pencil-square b5-icon-et-upd" data-bs-toggle="tooltip" title="Update"></i>

<!-- View Icon -->
<i class="view-img bi bi-eye b5-icon-et-view" data-bs-toggle="tooltip" title="View"></i>
