

  sp_helptext ViewAllFlatCustomisationTransaction

select * from tblflat

ALTER PROCEDURE ViewAllCostpaymentdetails  
    @ProjectID NVARCHAR(50) = NULL,         
    @FlatID NVARCHAR(50) = NULL,                  
    @BlockID NVARCHAR(50) = NULL,
    @searchBy NVARCHAR(200) = NULL,
    @AddedBy NVARCHAR(50) = NULL
AS    
BEGIN    
    -- Result set for main booking details and existence checks
    SELECT 
        b.ProjectID,        
        b.BlockID,            
        b.FlatID,             
        b.ApplicantFirstName, 
        b.ApplicantLastName,
        b.Mobilenumber1,
        b.AddedBy,
        CASE 
            WHEN EXISTS (
                SELECT 1
                FROM tblFlatCostDetails c
                WHERE c.FlatID = b.FlatID
            ) THEN 1 ELSE 0 END AS HasCostDetails,
        CASE 
            WHEN EXISTS (
                SELECT 1
                FROM tblCustomerPaymentSchedule s
                WHERE s.FlatID = b.FlatID
            ) THEN 1 ELSE 0 END AS HasPaymentSchedule,
        CASE 
            WHEN EXISTS (
                SELECT 1
                FROM tblFlatCustomerDemands d
                WHERE d.FlatID = b.FlatID
            ) THEN 1 ELSE 0 END AS HasDemands,
        CASE 
            WHEN EXISTS (
                SELECT 1
                FROM tblFlatCustomerTransaction t
                WHERE t.FlatID = b.FlatID
            ) THEN 1 ELSE 0 END AS HasTransactions
    FROM 
        tblFlatCustomerBookingDetails b
    WHERE 
        (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND    
        (@FlatID IS NULL OR @FlatID = '' OR b.FlatID = @FlatID) AND    
        (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID) AND
        (
            @searchBy IS NULL OR @searchBy = '' OR 
            b.Mobilenumber1 LIKE @searchBy + '%' OR -- Matches phone numbers starting with @searchBy
            b.ApplicantFirstName = @searchBy
        ) AND
        (@AddedBy IS NULL OR @AddedBy = '' OR b.AddedBy = @AddedBy)
END;








EXEC ViewAllCostpaymentdetails  
    @ProjectID = '',         
    @FlatID = '',                  
    @BlockID = '',
    @searchBy = '',
    @AddedBy = NULL;




select * from tblFlatCostDetails where FlatID='3'
select * from  tblFlatCustomerBookingDetails
select * from  tblProjectBlock
select * from  sys.tables


sp_helptext ViewAllFlatBookingCustomerDetails


