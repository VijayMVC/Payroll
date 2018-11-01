ALTER FUNCTION dbo.GetWorkDay(@IDS numeric,@minutesAllowed int) RETURNS money
AS
BEGIN

	--Declare @IDS numeric
	Declare @PunchInRule time,@BreakOutRule time,@BreakInRule time,@PunchOutRule time, @AMIn time ,@AMOut time, @PMIn time, @PMOut time
	Declare @PunchIn time,@BreakOut time,@BreakIn time,@PunchOut time, @WorkDay money
	--set @IDS=203
	Set @PunchInRule=(Select top 1 convert(varchar(20), PunchInRule, 8) from AttendanceRule)
	Set @BreakOutRule=(Select top 1 convert(varchar(20),BreakOutRule, 8) from AttendanceRule)
	Set @BreakInRule=(Select top 1 convert(varchar(20), BreakInRule, 8) from AttendanceRule)
	Set @PunchOutRule=(Select top 1 convert(varchar(20),PunchOutRule, 8) from AttendanceRule)

	Set @PunchIn=(Select convert(varchar(20),PunchIn, 8) From AttendanceLog WHERE IDS=@IDS) 
	Set @BreakOut=(Select convert(varchar(20),BreakOut, 8) From AttendanceLog WHERE IDS=@IDS) 
	Set @BreakIn =(Select convert(varchar(20),BreakIn, 8) From AttendanceLog WHERE IDS=@IDS) 
	Set @PunchOut =(Select convert(varchar(20),PunchOut, 8) From AttendanceLog WHERE IDS=@IDS) 
	
    SET @WorkDay=0
	--MORNING
	  IF @PunchIn<= @PunchInRule BEGIN SET @AMIn=@PunchInRule END
	  ELSE BEGIN   SET @AMIn=@PunchIn END
	  IF @BreakOut >= @BreakOutRule BEGIN SET @AMOut=@BreakOutRule END
	  ELSE BEGIN   SET @AMOut=@BreakOut END
	 
     IF (select DATEDIFF(minute,@AMIn,@AMOut))>=@minutesAllowed BEGIN    SET @WorkDay=@WorkDay+0.5 END
	  --AFTERNOON

	  IF @BreakIn <= @BreakInRule BEGIN SET @PMIn=@BreakInRule END
	  ELSE BEGIN   SET @PMIn=@BreakIn END
	  IF @PunchOut >= @PunchOutRule BEGIN SET @PMOut=@PunchOutRule END
	  ELSE BEGIN   SET @PMOut=@PunchOut END
	  
     IF (select DATEDIFF(minute,@PMIn,@PMOut))>=@minutesAllowed BEGIN SET @WorkDay=@WorkDay+0.5 END
	 
 RETURN @WorkDay
 
END