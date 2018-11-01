 IF EXISTS (SElECT name FROM sysobjects WHERE name='DepartmentInsert')
   DROP PROCEDURE DepartmentInsert
   GO
   
CREATE PROCEDURE DepartmentInsert
(
		 
		 @IDS numeric ,
		 @Department nvarchar(300),
		 @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO Departments(Department) VALUES (@Department)
	SELECT @IDSOut=IDENT_CURRENT('Departments')
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='DepartmentUpdate')
   DROP PROCEDURE DepartmentUpdate
   GO
   
CREATE PROCEDURE DepartmentUpdate
(
		 @IDS numeric ,
		 @Department nvarchar(300)

)
AS
BEGIN
	UPDATE  Departments SET    
		 Department =@Department
  WHERE IDS=@IDS
						 
END

 IF EXISTS (SElECT name FROM sysobjects WHERE name='DepartmentSelect')
   DROP PROCEDURE DepartmentSelect
   GO
   
CREATE PROCEDURE DepartmentSelect
(
		 
		 @IDS numeric 
)
AS
BEGIN
	Select     
	     IDS,
		 Department
	FROM Departments WHERE IDS=@IDS
	
						 
END
GO


 IF EXISTS (SElECT name FROM sysobjects WHERE name='DepartmentSelectAll')
   DROP PROCEDURE DepartmentSelectAll
   GO
   
CREATE PROCEDURE DepartmentSelectAll

AS
BEGIN
	Select     
	     IDS,
		Department
	FROM Departments
	
						 
END
GO
