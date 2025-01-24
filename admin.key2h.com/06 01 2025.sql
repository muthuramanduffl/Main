
-- add data
select * from tblprojects  WHERE ProjectName = 'New project vel planners'
            AND (null IS NULL OR ProjectID !='' )



--update data, id passed to check already exist. project id changed, but old project name 

select * from tblprojects  WHERE ProjectName = 'New project vel planners'
            AND ('50' IS NULL OR ProjectID !='50' )


            select * from tblprojects  WHERE   ProjectID ='50' 

           NewprojectvelplannersYnvf.jpg
           Newprojectvelplannersk6nR.jpg





select * from sys.tables



Create Procedure Alreadyexistsqlapproach
@ProjectID int,
@ProjectName nvarchar(512)
As
Begin
    SELECT COUNT(1)
            FROM tblprojects
            WHERE ProjectName = 'New project vel planners'
            AND ('50' IS NULL OR ProjectID !='50')
End


sp_help tblprojects 


sp_helptext AlreadyExistProjectNamebyClientID


Create Procedure AlreadyExistProjectNamebyClientID  
@ClentID int  
as  
Begin  
 select * from tblProjects Where ClientID=@ClentID  
End  




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




select * from sys.tables
select * from tblProjectBlock
select * from tblFlat
