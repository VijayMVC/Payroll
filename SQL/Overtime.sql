CREATE FUNCTION dbo.GetWorkDayOvertime(@IDS numeric) RETURNS money
AS
BEGIN

   -- Declare @IDS numeric
	
	Declare @OvertimeInRule time,@OvertimeOutRule time, @OTIn time ,@OTOut time
	Declare @OvertimeIn time,@OvertimeOut time, @WorkTime money, @WorkHaftTime money
	--set @IDS=938

	Set @OvertimeInRule=(Select top 1 convert(varchar(20), OTInRule, 8) from AttendanceRule)
	Set @OvertimeOutRule=(Select top 1 convert(varchar(20),OTOutRule, 8) from AttendanceRule)


 
	Set @OvertimeIn =(Select convert(varchar(20),OTIn, 8) From AttendanceLog WHERE IDS=@IDS) 
	Set @OvertimeOut =(Select convert(varchar(20),OTOut, 8) From AttendanceLog WHERE IDS=@IDS) 
	

 SET @WorkTime=0
 
	--MORNING
	  IF @OvertimeIn<= @OvertimeInRule BEGIN SET @OTIn=@OvertimeInRule END
	  ELSE BEGIN   SET @OTIn=@OvertimeIn END

	  
	  IF @OvertimeOut >= @OvertimeOutRule BEGIN SET @OTOut=@OvertimeOutRule END
	  ELSE BEGIN   SET @OTOut=@OvertimeOut END

     SET @WorkTime=(select DATEDIFF(hour,@OTIn,@OTOut))
     SET @WorkHaftTime=(select DATEDIFF(MINUTE ,@OTIn,@OTOut))-(@WorkTime*60)
     IF @WorkHaftTime>=30 BEGIN SET @WorkTime=@WorkTime+0.5  END
	  --AFTERNOON


 RETURN @WorkTime
 
END