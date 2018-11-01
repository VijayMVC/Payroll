

IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceLogInsertUpdate')
   DROP PROCEDURE AttendanceLogInsertUpdate
   GO
   
CREATE PROCEDURE AttendanceLogInsertUpdate
(	  
		 @EmployeeIDS numeric,
		 @MachineNumber nvarchar(100),
		 @AttendanceDate Datetime,
		 @idwInOutMode integer
	--	 @IDSOut numeric OUTPUT 
)
AS
BEGIN


		Declare @IDS numeric,@ShiftName nvarchar(100),@DayOfTheWeek int
		SET @IDS=0
		set @IDS=ISNULL((Select top 1 IDS From AttendanceLog WHERE EmployeeIDS=@EmployeeIDS and CAST(FLOOR(CAST(AttendanceDate AS float)) AS DATETIME)=CAST(FLOOR(CAST(@AttendanceDate AS float)) AS DATETIME)),0)
 
       -- SET @ShiftName=isnull((Select a.ShiftName From Employees a INNER JOIN AttendanceLog b ON a.IDS=b.EmployeeIDS WHERE b.IDS=@IDS),'')
	   -- Set @DayOfTheWeek=isnull((Select datepart(dw,OTIn)  From AttendanceLog WHERE IDS=@IDS),0)
	   -- Set @OvertimeOutRule=(Select top 1 convert(varchar(20),OTOutRule, 8) from AttendanceRule WHERE DayOfTheWeek=@DayOfTheWeek and ShiftName=@ShiftName)


       IF @IDS=0 BEGIN
 
		  IF @idwInOutMode=0 and ISNULL((Select PunchIn From AttendanceLog WHERE IDS=@IDS),0)=0 BEGIN
		   		INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,PunchIn) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
          END
		  IF @idwInOutMode=1 and ISNULL((Select PunchOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN 
		 		INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,PunchOut) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
          END	
		  IF @idwInOutMode=2 and ISNULL((Select BreakOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN 
				INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,BreakOut) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
		  END	
		  IF @idwInOutMode=3 and ISNULL((Select BreakIn From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN
		   		INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,BreakIn) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
          END
		  IF @idwInOutMode=4 and ISNULL((Select OTIn From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN 
		  	    INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,OTIn) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
		  END
		  IF @idwInOutMode=5 and ISNULL((Select OTOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN 
		  		INSERT INTO AttendanceLog(EmployeeIDS,MachineNumber,AttendanceDate,OTOut) VALUES (@EmployeeIDS,@MachineNumber,@AttendanceDate,@AttendanceDate)
          END

	
	  END ELSE BEGIN 
	  	
		  IF @idwInOutMode=0 and ISNULL((Select PunchIn From AttendanceLog WHERE IDS=@IDS),0)=0 BEGIN UPDATE AttendanceLog SET PunchIn=@AttendanceDate WHERE IDS=@IDS  END
		  IF @idwInOutMode=1 and ISNULL((Select PunchOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN UPDATE AttendanceLog SET PunchOut=@AttendanceDate WHERE IDS=@IDS END	
		  IF @idwInOutMode=2 and ISNULL((Select BreakOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN UPDATE AttendanceLog SET BreakOut=@AttendanceDate WHERE IDS=@IDS END	
		  IF @idwInOutMode=3 and ISNULL((Select BreakIn From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN UPDATE AttendanceLog SET BreakIn=@AttendanceDate WHERE IDS=@IDS 	END
		  IF @idwInOutMode=4 and ISNULL((Select OTIn From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN UPDATE AttendanceLog SET OTIn=@AttendanceDate WHERE IDS=@IDS END
		  IF @idwInOutMode=5 and ISNULL((Select OTOut From AttendanceLog WHERE IDS=@IDS),0)=0  BEGIN UPDATE AttendanceLog SET OTOut=@AttendanceDate WHERE IDS=@IDS   END
	  END
				 
END
GO


 IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceLogSelect')
   DROP PROCEDURE AttendanceLogSelect
   GO
CREATE PROCEDURE AttendanceLogSelect
(
		 @EmployeeIDS numeric,		
		 @DateFrom datetime,
		 @DateTo datetime	 
)
AS
BEGIN
	Select a.IDS	 
	      ,a.EmployeeIDS
	     ,a.MachineNumber 
	     ,(Select lName +', '+ fName +' ' + mName From Employees WHERE IDS=a.EmployeeIDS) as Name
		 , DATENAME(dw,a.AttendanceDate) + ' ' + convert(varchar,  a.AttendanceDate , 107)  as [Date]
		 ,substring(convert(varchar(20), a.PunchIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.PunchIn, 9), 25, 2) as  [Punch-In] 
		 ,substring(convert(varchar(20), a.BreakOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.BreakOut, 9), 25, 2) as [Break-Out]
		 ,substring(convert(varchar(20), a.BreakIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.BreakIn, 9), 25, 2) as [Break-In]
		 ,substring(convert(varchar(20), a.PunchOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.PunchOut, 9), 25, 2) as [Punch-Out] 
		 ,substring(convert(varchar(20), a.OTIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.OTIn, 9), 25, 2) as [OT-In] 
		 ,substring(convert(varchar(20), a.OTOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.OTOut, 9), 25, 2) as [OT-Out] 
		 ,CONVERT(varchar, CAST(dbo.GetWorkDay(a.IDS,180) AS money), 1) as [Credit(Days)],CONVERT(varchar, CAST(dbo.GetWorkDayLateEO(a.IDS,180) AS money), 1) as [Late|EO]
	FROM AttendanceLog a WHERE a.EmployeeIDS=@EmployeeIDS 
		and (CAST(FLOOR(CAST(a.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  ORDER by a.AttendanceDate DESC				 
--Order By a.AttendanceDate DESC
END
GO

--SELECT DATENAME(dw,'09/23/2013') 

--FORMAT(EndOfDayRate, 'N', 'de-de') AS 'Numeric Format'

 IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceLogSelectAll')
   DROP PROCEDURE AttendanceLogSelectAll
   GO
   
CREATE PROCEDURE AttendanceLogSelectAll

AS
BEGIN
	Select a.IDS	 
	      ,a.EmployeeIDS
	     ,a.MachineNumber 
	     ,(Select lName +', '+ fName +' ' + mName From Employees WHERE IDS=a.EmployeeIDS) as Name
		 ,convert(varchar,  a.AttendanceDate , 107)  as [Date]
		 ,substring(convert(varchar(20), a.PunchIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.PunchIn, 9), 25, 2) as  [Punch-In] 
		 ,substring(convert(varchar(20), a.BreakOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.BreakOut, 9), 25, 2) as [Break-Out]
		 ,substring(convert(varchar(20), a.BreakIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.BreakIn, 9), 25, 2) as [Break-In]
		 ,substring(convert(varchar(20), a.PunchOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.PunchOut, 9), 25, 2) as [Punch-Out] 
		 ,substring(convert(varchar(20), a.OTIn, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.OTIn, 9), 25, 2) as [OT-In] 
		 ,substring(convert(varchar(20), a.OTOut, 9), 13, 5) + ' ' + substring(convert(varchar(30),a.OTOut, 9), 25, 2) as [OT-Out] 
	     ,CONVERT(varchar, CAST(dbo.GetWorkDay(a.IDS,180) AS money), 1) as [Credit(Days)],CONVERT(varchar, CAST(dbo.GetWorkDayLateEO(a.IDS,180) AS money), 1) as [Late|EO]
	FROM AttendanceLog a order By  a.AttendanceDate DESC, Name ASC
					 
END
GO


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
		 ,@IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO AttendanceRule (    
          PunchInRule 
         ,BreakOutRule 
         ,BreakInRule 
         ,PunchOutRule 
         ,OTInRule 
         ,OTOutRule 
		 ,LatePerMinutePenalty 
		 

	  )
						 
	VALUES ( 		 
	
         @PunchInRule 
         ,@BreakOutRule 
         ,@BreakInRule 
         ,@PunchOutRule 
         ,@OTInRule 
         ,@OTOutRule 
		 ,@LatePerMinutePenalty 

	)
	
	SELECT @IDSOut=IDENT_CURRENT('AttendanceRule')
				 
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
		 ,@LatePerMinutePenalty money
)
AS
BEGIN
	UPDATE AttendanceRule SET    
         PunchInRule= @PunchInRule
         ,BreakOutRule =@BreakOutRule
         ,BreakInRule =@BreakInRule
         ,PunchOutRule =@PunchOutRule
         ,OTInRule =@OTInRule
         ,OTOutRule =@OTOutRule
		 ,LatePerMinutePenalty =@LatePerMinutePenalty
	WHERE IDS=@IDS 	 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceRuleSelect')
   DROP PROCEDURE AttendanceRuleSelect
   GO
   
CREATE PROCEDURE AttendanceRuleSelect

AS
BEGIN
	Select top 1
	         IDS
			 ,PunchInRule 
			 ,BreakOutRule 
			 ,BreakInRule 
			 ,PunchOutRule 
			 ,OTInRule 
			 ,OTOutRule 
			 ,LatePerMinutePenalty 
	FROM AttendanceRule 
	
						 
END
GO
   
   
 IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeGetWorkedDays')
   DROP PROCEDURE EmployeeGetWorkedDays
   GO
CREATE PROCEDURE EmployeeGetWorkedDays
(
		 @EmployeeIDS numeric,		
		 @DateFrom datetime,
		 @DateTo datetime	 
)
AS
BEGIN
	Select 
		CONVERT(varchar, CAST( SUM( dbo.GetWorkDay(a.IDS,180)) AS money), 1) as Credit,
		CONVERT(varchar, CAST( SUM( dbo.GetWorkDayLateEO(a.IDS,180)) AS money), 1) as LateEO
		 
	FROM AttendanceLog a WHERE a.EmployeeIDS=@EmployeeIDS 
		and (CAST(FLOOR(CAST(a.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)) 					 
--Order By a.AttendanceDate DESC
END
GO

 IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeGetLateEO')
   DROP PROCEDURE EmployeeGetLateEO
   GO
CREATE PROCEDURE EmployeeGetLateEO
(
		 @EmployeeIDS numeric,		
		 @DateFrom datetime,
		 @DateTo datetime	 
)
AS
BEGIN
	Select 
		CONVERT(varchar, CAST( SUM( dbo.GetWorkDayLateEO(a.IDS,180)) AS money), 1) as Credit
		 
	FROM AttendanceLog a WHERE a.EmployeeIDS=@EmployeeIDS 
		and (CAST(FLOOR(CAST(a.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)) 					 
--Order By a.AttendanceDate DESC
END
GO

IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceInsert')
   DROP PROCEDURE AttendanceInsert
   GO

CREATE PROCEDURE AttendanceInsert
(
		  @EmployeeIDS numeric 
		 ,@AttDate datetime
         ,@PunchIn Datetime
         ,@BreakOut Datetime
         ,@BreakIn Datetime
         ,@PunchOut Datetime
         ,@OTIn Datetime
         ,@OTOut Datetime
         ,@PI int
         ,@BO int
         ,@BI int
         ,@PO int
         ,@OI int
         ,@OO int   
		 ,@IDSOut numeric OUTPUT
)
AS
BEGIN

	IF @PI=0 BEGIN SET @PunchIn=NULL END
	IF @BO=0 BEGIN SET @BreakOut=NULL  END
	IF @BI=0 BEGIN  SET @BreakIn=NULL  END
	IF @PO=0 BEGIN SET @PunchOut=NULL END
	IF @OI=0 BEGIN SET @OTIn=NULL END
	IF @OO=0 BEGIN SET @OTOut=NULL  END
	
	INSERT INTO AttendanceLog (    
	      EmployeeIDS
	     , MachineNumber
	     ,AttendanceDate 
         ,PunchIn 
         ,BreakOut
         ,BreakIn
         ,PunchOut
         ,OTIn 
         ,OTOut 
	  )
						 
	VALUES ( 		 
		  @EmployeeIDS
		  ,1
		 ,@AttDate
         ,@PunchIn 
         ,@BreakOut 
         ,@BreakIn 
         ,@PunchOut
         ,@OTIn 
         ,@OTOut
	)
	SELECT @IDSOut=IDENT_CURRENT('AttendanceLog')
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceUpdate')
   DROP PROCEDURE AttendanceUpdate
   GO
   
CREATE PROCEDURE AttendanceUpdate
(
		  @IDS numeric 
		 , @AttDate Datetime
         ,@PunchIn Datetime
         ,@BreakOut Datetime
         ,@BreakIn Datetime
         ,@PunchOut Datetime
         ,@OTIn Datetime
         ,@OTOut Datetime
         ,@PI int
         ,@BO int
         ,@BI int
         ,@PO int
         ,@OI int
         ,@OO int       
)
AS
BEGIN
    UPDATE AttendanceLog SET AttendanceDate =@AttDate WHERE IDS=@IDS
	IF @PI=1 BEGIN UPDATE AttendanceLog SET PunchIn=@PunchIn WHERE IDS=@IDS  END
	IF @BO=1 BEGIN UPDATE AttendanceLog SET BreakOut=@BreakOut WHERE IDS=@IDS  END
	IF @BI=1 BEGIN UPDATE AttendanceLog SET BreakIn=@BreakIn WHERE IDS=@IDS  END
	IF @PO=1 BEGIN UPDATE AttendanceLog SET PunchOut=@PunchOut WHERE IDS=@IDS  END
	IF @OI=1 BEGIN UPDATE AttendanceLog SET OTIn=@OTIn WHERE IDS=@IDS  END
	IF @OO=1 BEGIN UPDATE AttendanceLog SET OTOut =@OTOut WHERE IDS=@IDS  END

END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceEditSelect')
   DROP PROCEDURE AttendanceEditSelect
   GO
   
CREATE PROCEDURE AttendanceEditSelect
(
 @IDS numeric
)
AS
BEGIN
	Select top 1
	         IDS
	         ,AttendanceDate
			 ,PunchIn 
			 ,BreakOut 
			 ,BreakIn 
			 ,PunchOut
			 ,OTIn 
			 ,OTOut 

	FROM AttendanceLog WHERE IDS=@IDS
					 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='MyAttendanceRuleList')
   DROP PROCEDURE MyAttendanceRuleList
   GO

CREATE PROCEDURE MyAttendanceRuleList
(
@EmployeeIDS numeric
)
AS
BEGIN
 Declare @ShiftName nvarchar(100)
 SET @ShiftName=ISNULL((Select ShiftName From Employees WHERE IDS= @EmployeeIDS),'')
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
			
			 , substring(convert(varchar(20), PunchInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchInRule, 9), 25, 2) as  [Punch-In Rule] 
			   
			  ,substring(convert(varchar(20), BreakOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakOutRule, 9), 25, 2) as  [Break-Out Rule] 
			  ,substring(convert(varchar(20), BreakInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakInRule, 9), 25, 2) as  [Break-In Rule] 
			  ,substring(convert(varchar(20), PunchOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchOutRule, 9), 25, 2) as  [Punch-Out Rule] 
			  ,substring(convert(varchar(20), OTInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTInRule, 9), 25, 2) as  [OT-In Rule] 
			  ,substring(convert(varchar(20), OTOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTOutRule, 9), 25, 2) as  [OT-Out Rule] 
		     

	FROM AttendanceRule WHERE ShiftName =@ShiftName Order By ShiftName, DayOfTheWeek asc
	
						 
END
GO
   

   


IF EXISTS (SElECT name FROM sysobjects WHERE name='MyAttendanceRuleChange')
   DROP PROCEDURE MyAttendanceRuleChange
   GO

CREATE PROCEDURE MyAttendanceRuleChange
(
@EmployeeIDS numeric,
@DateFrom datetime,
@DateTo Datetime
)
AS
BEGIN

	Select    IDS,
			  DATENAME(dw,AttendanceDate) + ' ' + convert(varchar,  AttendanceDate , 107)  as [Date]
			  , substring(convert(varchar(20), PunchInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchInRule, 9), 25, 2) as  [Punch-In Rule] 
			  ,substring(convert(varchar(20), BreakOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakOutRule, 9), 25, 2) as  [Break-Out Rule] 
			  ,substring(convert(varchar(20), BreakInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),BreakInRule, 9), 25, 2) as  [Break-In Rule] 
			  ,substring(convert(varchar(20), PunchOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),PunchOutRule, 9), 25, 2) as  [Punch-Out Rule] 
			  ,substring(convert(varchar(20), OTInRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTInRule, 9), 25, 2) as  [OT-In Rule] 
			  ,substring(convert(varchar(20), OTOutRule, 9), 13, 5) + ' ' + substring(convert(varchar(30),OTOutRule, 9), 25, 2) as  [OT-Out Rule] 

	FROM AttendanceLog  WHERE EmployeeIDS=@EmployeeIDS and isnull(PunchInRule,'')<>'' and isnull(PunchOutRule,'')<>''
		and (CAST(FLOOR(CAST(AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  ORDER by AttendanceDate DESC				 
					 
END
GO
   

   
IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceShiftEditSelect')
   DROP PROCEDURE AttendanceShiftEditSelect
   GO
   
CREATE PROCEDURE AttendanceShiftEditSelect
(
 @IDS numeric
)
AS
BEGIN
	Select top 1
	         IDS
	         ,AttendanceDate
			 ,isnull(PunchInRule,'') as PunchIn 
			 ,isnull(BreakOutRule,'') as BreakOut 
			 ,isnull(BreakInRule,'') as BreakIn 
			 ,isnull(PunchOutRule,'') as PunchOut
			 ,isnull(OTInRule,'') as OTIn 
			 ,isnull(OTOutRule,'') as OTOut 

	FROM AttendanceLog WHERE IDS=@IDS
					 
END
GO




IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceShiftUpdate')
   DROP PROCEDURE AttendanceShiftUpdate
   GO
   
CREATE PROCEDURE AttendanceShiftUpdate
(
		  @IDS numeric 
		 , @AttDate Datetime
         ,@PunchIn Datetime
         ,@BreakOut Datetime
         ,@BreakIn Datetime
         ,@PunchOut Datetime
         ,@OTIn Datetime
         ,@OTOut Datetime
         ,@PI int
         ,@BO int
         ,@BI int
         ,@PO int
         ,@OI int
         ,@OO int       
)
AS
BEGIN
    UPDATE AttendanceLog SET AttendanceDate =@AttDate WHERE IDS=@IDS
	IF @PI=1 BEGIN UPDATE AttendanceLog SET PunchInRule=@PunchIn WHERE IDS=@IDS  END
	IF @BO=1 BEGIN UPDATE AttendanceLog SET BreakOutRule=@BreakOut WHERE IDS=@IDS  END
	IF @BI=1 BEGIN UPDATE AttendanceLog SET BreakInRule=@BreakIn WHERE IDS=@IDS  END
	IF @PO=1 BEGIN UPDATE AttendanceLog SET PunchOutRule=@PunchOut WHERE IDS=@IDS  END
	IF @OI=1 BEGIN UPDATE AttendanceLog SET OTInRule=@OTIn WHERE IDS=@IDS  END
	IF @OO=1 BEGIN UPDATE AttendanceLog SET OTOutRule =@OTOut WHERE IDS=@IDS  END

END
GO
