
IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeInsert')
   DROP PROCEDURE EmployeeInsert
   GO
   
CREATE PROCEDURE EmployeeInsert
(	 
		 @IDS numeric ,
		 @lName nvarchar(150),
		 @fName nvarchar(150),
		 @mName nvarchar(150),
		 @AddressHome nvarchar(150),
		 @ContactNo nvarchar(150),
		 @DateOfBirth datetime,
		 @DateOfEmployment datetime,
 		 @Gender int,
		 @CivilStatus Int,
		 @Position nvarchar(200),
		 @Department int,
		 @Salary money,
		 @PersonImage image,
		 @Unit int,
		 @Stat int,
		 @SSSPrem money,
		 @PHICPrem money,
		 @PagIbigPrem money,
		 @SSSLoan money,
		 @PagIbigLoan money,
		 @Savings money,
		 @OTRate money,
		 @ShiftName nvarchar(100),
		 @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO Employees (    
		 lName ,
		 fName ,
		 mName,
		 AddressHome  ,
		 ContactNo ,
		 DateOfBirth ,
		 DateOfEmployment,
 		 Gender ,
		 CivilStatus ,
		 Position,
		 Department,
		 Salary ,
	     PersonImage ,
		 Unit ,
		 Stat,
		 SSSPrem ,
		 PHICPrem ,
		 PagIbigPrem ,
		 SSSLoan ,
		 PagIbigLoan ,
		 Savings,
		 OTRate,
		 ShiftName
	  )
						 
	VALUES ( 		 
		 @lName ,
		 @fName ,
		 @mName,
		 @AddressHome  ,
		 @ContactNo ,
		 @DateOfBirth ,
		 @DateOfEmployment,
 		 @Gender ,
		 @CivilStatus ,
		 @Position,
		 @Department ,
		 @Salary ,
	  	 @PersonImage ,
		 @Unit ,
		 @Stat ,
		 @SSSPrem ,
		 @PHICPrem ,
		 @PagIbigPrem ,
		 @SSSLoan ,
		 @PagIbigLoan ,
		 @Savings,
		 @OTRate,
		 @ShiftName
	)
	
	SELECT @IDSOut=IDENT_CURRENT('Employees')
				 
END
GO

IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeTemplateInsert')
   DROP PROCEDURE EmployeeTemplateInsert
   GO
   
CREATE PROCEDURE EmployeeTemplateInsert
(	 
     @IDS Int,
     @UserID int,
     @FingerID int,
     @Template image,
     @TmpLen int,
     @Flag int,
     @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO EmployeeTemplate (    
     UserID ,
     FingerID ,
     Template ,
     TmpLen ,
     Flag  
	  )
						 
	VALUES ( 		 
     @UserID ,
     @FingerID ,
     @Template ,
     @TmpLen ,
     @Flag  	)
	
	SELECT @IDSOut=IDENT_CURRENT('EmployeeTemplate')
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeTemplateUpdate')
   DROP PROCEDURE EmployeeTemplateUpdate
   GO
   
CREATE PROCEDURE EmployeeTemplateUpdate
(	 
     @IDS Int,
     @UserID int,
     @FingerID int,
     @Template image,
     @TmpLen int,
     @Flag int
)
AS
BEGIN
	Update EmployeeTemplate SET    
     UserID=@UserID ,
     FingerID =@FingerID,
     Template=@Template ,
     TmpLen =@TmpLen,
     Flag=@Flag  
    WHERE IDS=@IDS
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeUpdate')
   DROP PROCEDURE EmployeeUpdate
   GO
   
CREATE PROCEDURE EmployeeUpdate
(
		 @IDS numeric ,
		 @lName nvarchar(150),
		 @fName nvarchar(150),
		 @mName nvarchar(150),
		 @AddressHome nvarchar(150) ,
		 @ContactNo nvarchar(150) ,
		 @DateOfBirth datetime,
		 @DateOfEmployment datetime,
 		 @Gender int,
		 @CivilStatus Int,
		 @Position nvarchar(200),
		 @Department int,
		 @Salary money,
	     @PersonImage image,
		 @Unit int,
		 @Stat int,
		 @SSSPrem money,
		 @PHICPrem money,
		 @PagIbigPrem money,
		 @SSSLoan money,
		 @PagIbigLoan money,
		 @Savings money,
		 @OTRate money,
		 @ShiftName nvarchar(100)
)
AS
BEGIN
	UPDATE  Employees SET    
		 lName =@lName,
		 fName=@fName ,
		 mName=@mName,
		 AddressHome=@AddressHome  ,
		 ContactNo=@ContactNo ,
		 DateOfBirth=@DateOfBirth ,
		 DateOfEmployment=@DateOfEmployment,
 		 Gender=@Gender ,
		 CivilStatus= @CivilStatus,
		 Position=@Position,
		 Department=@Department,
		 Salary =@Salary,
		 PersonImage=@PersonImage ,
		 Unit =@Unit,
		 Stat=@Stat ,
		 SSSPrem=@SSSPrem ,
		 PHICPrem=@PHICPrem ,
		 PagIbigPrem =@PagIbigPrem,
		 SSSLoan= @SSSLoan,
		 PagIbigLoan=@PagIbigLoan,
		 Savings=@Savings,
		 OTRate=@OTRate,
		 ShiftName=@ShiftName
		  
  WHERE IDS=@IDS
						 
END


  
  IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeSelect')
   DROP PROCEDURE EmployeeSelect
   GO 
CREATE PROCEDURE EmployeeSelect
(	 
	@IDS numeric 
)
AS
BEGIN
	Select     
	     IDS,
		 lName ,
		 fName ,
		 mName,
		 AddressHome  ,
		 ContactNo ,
		 DateOfBirth ,
		 DateOfEmployment,
 		 Gender ,
		 CivilStatus ,
		 Department,
		 Position,
		 Salary ,
		 Unit ,
		 SSSPrem ,
		 PHICPrem ,
		 PagIbigPrem ,
		 SSSLoan ,
		 PagIbigLoan,
		 Savings,
		 PersonImage,
		 Stat,
		 OTRate,
		 ShiftName
	FROM Employees WHERE IDS=@IDS						 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeSelectAll')
   DROP PROCEDURE EmployeeSelectAll
   GO
   
CREATE PROCEDURE EmployeeSelectAll

AS
BEGIN
	Select     
	     a.IDS,
		 a.lName as [Last Name],
		 a.fName as [First Name] ,
		 a.mName as [Middle Name],
		 a.AddressHome  as Address,
		 a.ContactNo ,
		 a.DateOfBirth as [Date of Birth],
		 a.DateOfEmployment as [Date of Employment],
		 (Select top 1 Department From Departments WHERE IDS=a.Department) as Department,
 		 CASE a.Gender  WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' END as Gender,
 		 CASE a.CivilStatus 
 		 WHEN 0 THEN 'Single'
 		 WHEN 1 THEN 'Married'
 		 WHEN 2 THEN 'Annulled'
 		 WHEN 3 THEN 'Widowed'
		 END as [Civil Status]  ,
		 a.Position,
		 a.Salary ,
	    
		 CASE a.Unit WHEN 0 THEN 'Hourly' WHEN 1 THEN 'Daily' WHEN 2 THEN 'Weekly' WHEN 3 THEN 'Monthly' END as Unit,
		
		 a.SSSPrem ,
		 a.PHICPrem ,
		 a.PagIbigPrem ,
		 a.SSSLoan ,
		 a.PagIbigLoan   ,
		 a.Savings,
		 a.OTRate,
		 a.ShiftName,
--		  a.PersonImage ,
		  Case a.Stat WHEN 0 THEN 'Inactive' WHEN 1 THEN 'Active' END as Status
	FROM Employees a  WHERE a.Stat=1 Order By a.lname
					 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeSelectAllCbo')
   DROP PROCEDURE EmployeeSelectAllCbo
   GO
   
CREATE PROCEDURE EmployeeSelectAllCbo

AS
BEGIN
	Select     
	     IDS,
		 lname + ', '+ fname as FullName

	FROM Employees WHERE Stat=1 Order By lname
					 
END
GO
