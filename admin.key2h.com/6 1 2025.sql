 alter Procedure DeleteFlatCustomisationDemands
        @CDemandID int,  
        @FlatID int  
        As  
        Begin  
        Delete tblFlatCustomisationDemands where CDemandID=@CDemandID and FlatID=@FlatID  
        End


        
Alter Procedure ViewAllFlatCustomisationDemandsByFIDandABy
@FlatID int,
@AddedBy nvarchar(50)
As
Begin
select tfcd.CDemandID,tfcd.FlatID,tfcd.PDFName,tfcd.AddedDate,tfcd.AddedBy,tfcd.PaymentStatus,tfcd.CWID ,tfcw.WorkTitle,tfcw.Amount from tblFlatCustomisationDemands tfcd  left join tblFlatCustomisationWorks tfcw   on tfcd.CWID=tfcw.CWID  where tfcd.FlatID=@FlatID and tfcd.AddedBy=@AddedBy
End

use dbkey2h

exec ViewAllFlatCustomisationDemandsByFIDandABy

@FlatID='44',

@AddedBy='1'

select * from tblFlatCustomisationDemands where FlatID='44',CWID




ALTER PROCEDURE ViewAllFlatCustomerDemands
    @ProjectID NVARCHAR(50) = NULL,       
    @FlatID NVARCHAR(50) = NULL,                
    @BlockID NVARCHAR(50) = NULL,          
    @CWID NVARCHAR(50) = NULL,
    @CDemandID NVARCHAR(50) = NULL,
    @AddedBy NVARCHAR(50) = NULL
AS  
BEGIN  
    WITH RankedDemands AS (  
        SELECT   
            r.FlatID,
            r.PaymentStatus,
            b.ProjectID,   
            b.BlockID,   
            r.CWID, 
            r.PDFName,
            r.CDemandID,  
            r.AddedBy,  
            b.ApplicantFirstName,
            ROW_NUMBER() OVER (
                PARTITION BY r.FlatID  -- Group by FlatID
                ORDER BY r.CWID DESC    -- Prioritize based on CWID (or another column)
            ) AS RowNum  
        FROM tblFlatCustomisationDemands r
        LEFT JOIN tblFlatCustomerBookingDetails b
            ON r.FlatID = b.FlatID
        WHERE   
            (@ProjectID IS NULL OR @ProjectID = '' OR b.ProjectID = @ProjectID) AND  
            (@FlatID IS NULL OR @FlatID = '' OR r.FlatID = @FlatID) AND  
            (@CWID IS NULL OR @CWID = '' OR r.CWID = @CWID) AND  
            (@CDemandID IS NULL OR @CDemandID = '' OR r.CDemandID = @CDemandID) AND  
            (@AddedBy IS NULL OR @AddedBy = '' OR r.AddedBy = @AddedBy) AND  
            (@BlockID IS NULL OR @BlockID = '' OR b.BlockID = @BlockID)  
    )  
    SELECT
        CDemandID,
        CWID,
        FlatID, 
        ProjectID, 
        BlockID, 
        PaymentStatus,
        AddedBy, 
        ApplicantFirstName
    FROM RankedDemands
    WHERE RowNum = 1;  -- Fetch only the first record per FlatID  
END;
EXEC ViewAllFlatCustomerDemands  
    @ProjectID = '',       
    @FlatID = '',                
    @BlockID = '',          
    @CWID = '',
    @addedBy=''