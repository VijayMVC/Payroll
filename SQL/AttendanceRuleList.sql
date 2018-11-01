
IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleInsert')
   DROP PROCEDURE AttendanceRuleInsert
   GO

CREATE PROCEDURE AttendanceRuleInsert
(
		  @IDS numeric
         ,@PunchInRule Datetime
         ,@BreakOutRule Datetime
         ,@BreakInRule Datetime
         ,@PunchOutRule Datetime
         ,@OTInRule Datetime
         ,@OTOutRule Datetime
		 ,@LatePerMinutePenalty money
		 ,@ShiftName nvarchar(100)
		 ,@DayOfTheWeek Int
		 ,@IDSOut numeric OUTPUT
)
AS
BEGIN
  
  IF NOT EXISTS((Select IDS From AttendanceRule WHERE ShiftName=@ShiftName and DayOfTheWeek=@DayOfTheWeek)) BEGIN
	INSERT INTO AttendanceRule (    
          PunchInRule 
         ,BreakOutRule 
         ,BreakInRule 
         ,PunchOutRule 
         ,OTInRule 
         ,OTOutRule 
		 ,ShiftName
		 ,DayOfTheWeek
		 ,LatePerMinutePenalty 
		 

	  )
						 
	VALUES ( 		 
	
         @PunchInRule 
         ,@BreakOutRule 
         ,@BreakInRule 
         ,@PunchOutRule 
         ,@OTInRule 
         ,@OTOutRule 
		 ,@ShiftName
		 ,@DayOfTheWeek
		 ,@LatePerMinutePenalty 

	)
	
	SELECT @IDSOut=IDENT_CURRENT('AttendanceRule')
END
ELSE BEGIN
  SELECT @IDSOut=0
  RAISERROR('Shift Exist', 16, 1)
END
				 
END
GO

IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleUpdate')
   DROP PROCEDURE AttendanceRuleUpdate
   GO
   
CREATE PROCEDURE AttendanceRuleUpdate
(
		 
		  @IDS numeric 
         ,@PunchInRule Datetime
         ,@BreakOutRule Datetime
         ,@BreakInRule Datetime
         ,@PunchOutRule Datetime
         ,@OTInRule Datetime
         ,@OTOutRule Datetime
		 ,@ShiftName nvarchar(100)
		 ,@DayOfTheWeek Int
		 ,@LatePerMinutePenalty money
)
AS
BEGIN

 -- IF NOT EXISTS((Select IDS From AttendanceRule WHERE ShiftName=@ShiftName and DayOfTheWeek=@DayOfTheWeek)) BEGIN

  		UPDATE AttendanceRule SET    
			 PunchInRule= @PunchInRule
			 ,BreakOutRule =@BreakOutRule
			 ,BreakInRule =@BreakInRule
			 ,PunchOutRule =@PunchOutRule
			 ,OTInRule =@OTInRule
			 ,OTOutRule =@OTOutRule
			 ,ShiftName=@ShiftName
			 ,DayOfTheWeek=@DayOfTheWeek
			 ,LatePerMinutePenalty =@LatePerMinutePenalty
		WHERE IDS=@IDS 
    
	--END
	--ELSE BEGIN
	-- RAISERROR('Shift Exist', 16, 1)
	--END
			 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleSelect')
   DROP PROCEDURE AttendanceRuleSelect
   GO  
CREATE PROCEDURE AttendanceRuleSelect
(
  @IDS numeric
)
AS
BEGIN
	Select top 1
	         IDS
			 ,ShiftName
			 , DayOfTheWeek
			 ,PunchInRule 
			 ,BreakOutRule 
			 ,BreakInRule 
			 ,PunchOutRule 
			 ,OTInRule 
			 ,OTOutRule 
			 ,LatePerMinutePenalty 
			 
	FROM AttendanceRule WHERE IDS=@IDS
	
						 
END
GO
   

IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleSelectList')
   DROP PROCEDURE AttendanceRuleSelectList
   GO

CREATE PROCEDURE AttendanceRuleSelectList

AS
BEGIN

	Select 
	          IDS
			 ,ShiftName
			 
			 ,Case DayOfTheWeek 
			   WHEN 0 THEN 'Sunday' 
			   WHEN 1 THEN 'Monday' 
			   WHEN 2 THEN 'Tuesday' 
			   WHEN 3 THEN 'Wenesday' 
			   WHEN 4 THEN 'Thursday' 
			   WHEN 5 THEN 'Friday' 
			   WHEN 6 THEN 'Saturday' 
			   End as DayOfTheWeeks
			 
			 	,substring(convert(varchar(20), PunchInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchInRule, 9), 25, 2) as  [Punch-In Rule] 
			 	,substring(convert(varchar(20), BreakOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakOutRule, 9), 25, 2) as  [Break-Out Rule] 
			 	,substring(convert(varchar(20), BreakInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakInRule, 9), 25, 2) as  [Break-In Rule] 
			 	,substring(convert(varchar(20), PunchOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchOutRule, 9), 25, 2) as  [Punch-Out Rule] 
			 	,substring(convert(varchar(20), OTInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTInRule, 9), 25, 2) as  [OT-In Rule] 
			 	,substring(convert(varchar(20), OTOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTOutRule, 9), 25, 2) as  [OT-Out Rule] 
		        ,LatePerMinutePenalty 
			 
	FROM AttendanceRule Order By ShiftName, DayOfTheWeek asc
	
						 
END
GO
   
   
IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleCBOSelect')
   DROP PROCEDURE AttendanceRuleCBOSelect
   GO  
CREATE PROCEDURE AttendanceRuleCBOSelect

AS
BEGIN
	Select DISTINCT ShiftName 	
	FROM AttendanceRule 
						 
END
GO



IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeSelectAllNoShift')
   DROP PROCEDURE EmployeeSelectAllNoShift
   GO
   
CREATE PROCEDURE EmployeeSelectAllNoShift

AS
BEGIN
	Select     
	     IDS,
		 lname + ', '+ fname as FullName

	FROM Employees WHERE Stat=1 and isnull(ShiftName,'') =''  Order By lname
					 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeSelectByShift')
   DROP PROCEDURE EmployeeSelectByShift
   GO
   
CREATE PROCEDURE EmployeeSelectByShift
(
   @ShiftName nvarchar(100)
)
AS
BEGIN
	Select     
	     IDS,
		 lname + ', '+ fname as FullName,isnull(ShiftName,'') as ShiftName
	FROM Employees WHERE Stat=1 and isnull(ShiftName,'') =@ShiftName Order By lname
					 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='UpdateEmployeeShift')
   DROP PROCEDURE UpdateEmployeeShift
   GO
   
CREATE PROCEDURE UpdateEmployeeShift
(
  @EmployeeID numeric,
   @ShiftName nvarchar(100)
)
AS
BEGIN
	      Update Employees SET ShiftName =@ShiftName WHERE IDS =@EmployeeID
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='RemoveByEmployeeFromShift')
   DROP PROCEDURE RemoveByEmployeeFromShift
   GO
   
CREATE PROCEDURE RemoveByEmployeeFromShift
(
  @EmployeeID numeric
)
AS
BEGIN
	      Update Employees SET ShiftName ='' WHERE IDS =@EmployeeID
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='RemoveAllEmployeeFromShift')
   DROP PROCEDURE RemoveAllEmployeeFromShift
   GO
   
CREATE PROCEDURE RemoveAllEmployeeFromShift
(
   @ShiftName nvarchar(100)
)
AS
BEGIN
	      Update Employees SET ShiftName ='' WHERE ShiftName =@ShiftName
				 
END
GO



