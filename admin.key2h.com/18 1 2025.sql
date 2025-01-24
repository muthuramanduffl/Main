
ALTER PROCEDURE ViewAllCostpaymentdetails  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,
    @searchBy NVARCHAR(200) = NULL,
    @AddedBy NVARCHAR(50) = NULL
AS    
BEGIN    
SELECT 
    b.ProjectID,        
    b.BlockID,            
    b.FlatID,             
    b.ApplicantFirstName, 
    b.ApplicantLastName,
    b.Mobilenumber1,
    b.AddedBy,
    CASE WHEN c.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasCostDetails,
    CASE WHEN s.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasPaymentSchedule,
    CASE WHEN d.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasDemands,
    CASE WHEN t.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasTransactions
FROM 
    tblFlatCustomerBookingDetails b
    LEFT JOIN tblFlatCostDetails c ON c.FlatID = b.FlatID
    LEFT JOIN tblCustomerPaymentSchedule s ON s.FlatID = b.FlatID
    LEFT JOIN tblFlatCustomerDemands d ON d.FlatID = b.FlatID
    LEFT JOIN tblFlatCustomerTransaction t ON t.FlatID = b.FlatID
WHERE 
    (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
    (@FlatID IS NULL OR @FlatID = '' OR b.FlatID = @FlatID) AND    
    (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID) AND
    (
        @searchBy IS NULL OR @searchBy = '' OR 
        b.Mobilenumber1 LIKE @searchBy + '%' OR 
        b.ApplicantFirstName = @searchBy
    ) AND
    (@AddedBy IS NULL OR @AddedBy = '' OR b.AddedBy = @AddedBy);
    END;











    --2nd

    ALTER PROCEDURE ViewAllCostpaymentdetails  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,
    @searchBy NVARCHAR(200) = NULL,
    @AddedBy NVARCHAR(50) = NULL
AS    
BEGIN    
    SELECT 
        b.ProjectID,        
        b.BlockID,            
        b.FlatID,             
        b.ApplicantFirstName, 
        b.ApplicantLastName,
        b.Mobilenumber1,
        b.AddedBy,
        CASE 
            WHEN EXISTS (SELECT 1 FROM tblFlatCostDetails c WHERE c.FlatID = b.FlatID) THEN 1 ELSE 0 
        END AS HasCostDetails,
        CASE 
            WHEN EXISTS (SELECT 1 FROM tblCustomerPaymentSchedule s WHERE s.FlatID = b.FlatID) THEN 1 ELSE 0 
        END AS HasPaymentSchedule,
        CASE 
            WHEN EXISTS (SELECT 1 FROM tblFlatCustomerDemands d WHERE d.FlatID = b.FlatID) THEN 1 ELSE 0 
        END AS HasDemands,
        CASE 
            WHEN EXISTS (SELECT 1 FROM tblFlatCustomerTransaction t WHERE t.FlatID = b.FlatID) THEN 1 ELSE 0 
        END AS HasTransactions
    FROM 
        tblFlatCustomerBookingDetails b
    WHERE 
        (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
        (@FlatID IS NULL OR @FlatID = '' OR b.FlatID = @FlatID) AND    
        (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID) AND
        (
            @searchBy IS NULL OR @searchBy = '' OR 
            b.Mobilenumber1 LIKE @searchBy + '%' OR 
            b.ApplicantFirstName = @searchBy
        ) AND
        (@AddedBy IS NULL OR @AddedBy = '' OR b.AddedBy = @AddedBy);
END;






EXEC ViewAllCostpaymentdetails  
    @ProjectID = '',         
    @FlatID = '',                  
    @BlockID = '',
    @searchBy = '',
    @AddedBy = NULL;




    ALTER PROCEDURE ViewAllCostpaymentdetails  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,
    @searchBy NVARCHAR(200) = NULL,
    @AddedBy NVARCHAR(50) = NULL
AS    
BEGIN    
  SELECT 
    b.ProjectID,
    b.BlockID,
    b.FlatID,
    b.ApplicantFirstName,
    b.ApplicantLastName,
    b.Mobilenumber1,
    b.AddedBy,
    CASE WHEN c.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasCostDetails,
    CASE WHEN s.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasPaymentSchedule,
    CASE WHEN d.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasDemands,
    CASE WHEN t.FlatID IS NOT NULL THEN 1 ELSE 0 END AS HasTransactions
FROM 
    tblFlatCustomerBookingDetails b
LEFT JOIN 
    tblFlatCostDetails c ON b.FlatID = c.FlatID
LEFT JOIN 
    tblCustomerPaymentSchedule s ON b.FlatID = s.FlatID
LEFT JOIN 
    tblFlatCustomerDemands d ON b.FlatID = d.FlatID
LEFT JOIN 
    tblFlatCustomerTransaction t ON b.FlatID = t.FlatID
WHERE 
    (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
    (@FlatID IS NULL OR @FlatID = '' OR b.FlatID = @FlatID) AND    
    (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID) AND
    (
        @searchBy IS NULL OR @searchBy = '' OR 
        b.Mobilenumber1 LIKE @searchBy + '%' OR 
        b.ApplicantFirstName = @searchBy
    ) AND
    (@AddedBy IS NULL OR @AddedBy = '' OR b.AddedBy = @AddedBy);

END;







select * from sys.tables
select * from tblClientDashboardIssues

truncate table tblClientDashboardIssues



sp_help tblFlatCostDetails
sp_help tblFlatCustomerBookingDetails


sp_helptext ViewprojectImageByprogressID


  
Alter Procedure ViewprojectImageByprogressID  
@progressID int  
As  
Begin  
  select * from tblProjectProgressImage where ProgressID=@progressID  order by ProgressImageID DESC
End




sp_helptext ViewProjectprojectID


Alter Procedure ViewProjectprojectID        
@ID int        
As        
Begin        
Select tblp.ProjectID,tblp.AddedBy,tblpi.* from tblProjectProgress  tblp  left join  tblProjectProgressImage   tblpi  on tblp.ProgressID=tblpi.ProgressID   where tblpi.ProgressID=@ID        order by tblpi.ProgressImageID DESC 
ENd  


sp_helptext AddFlatCustomerKYCDocs

CREATE Procedure AddFlatCustomerKYCDocs  
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
Insert into tblFlatCustomerKYCDocs

        (FlatID,ProjectID,SaleDeedDraft,SaleDeedFinal,SaleAgreementDraft,SaleAgreementFinal,AllotmentLetter,WelcomeLetter,DemandLetter,PaymentReceipt,Bill,PaymentSchedule,EBCard,HandingOverDocs,CCUpdation,NOCforHandover,OtherDocuments,BankDocuments,AddedBy,Addeddate)
Values(@FlatID,@ProjectID,@SaleDeedDraft,@SaleDeedFinal,@SaleAgreementDraft,@SaleAgreementFinal,@AllotmentLetter,@WelcomeLetter,@DemandLetter,@PaymentReceipt,@Bill,@PaymentSchedule,@EBCard,@HandingOverDocs,@CCUpdation,@NOCforHandover,@OtherDocuments,@BankDocuments,@AddedBy,@Addeddate)  
End


select * from tblFlatCustomerKYCDocs

