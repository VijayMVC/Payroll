
IF EXISTS (SElECT name FROM sysobjects WHERE name='GetInitialPayroll')
   DROP PROCEDURE GetInitialPayroll
   GO
   
CREATE PROCEDURE GetInitialPayroll
(	  
		  @DateFrom datetime
		 ,@DateTo Datetime
		 ,@Department numeric
		 ,@SSSPrem int
		 ,@PHICPrem int
		 ,@PagIbigPrem int
		 ,@SSSLoan int
		 ,@PagIbigLoan int
		 ,@Savings int
)
AS
BEGIN

Select  DISTINCT a.IDS as EmployeeIDS
       ,NULL as IDS 
       ,a.lname+ ', '+a.fname as Name
	   ,[Days Worked]=(Select SUM( dbo.GetWorkDay(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  					 
       , CASE isnull((Select SUM( dbo.GetWorkDay(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) 
		WHEN 0 THEN NULL ELSE a.Salary END  as Rate
       ,(Select SUM( dbo.GetWorkDayOvertime(c.IDS))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  as [OT Hour]
		
        ,CASE ISNULL((Select SUM( dbo.GetWorkDayOvertime(c.IDS))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) WHEN 0 THEN NULL ELSE a.OTRate END as  OTRate
       ,NULL  as Adjustment
	   ,NULL as [Gross Pay]					 
       , CASE @SSSPrem WHEN 1 THEN a.SSSPrem ELSE NULL END  as SSSPrem
	   , CASE @PHICPrem WHEN 1 THEN a.PHICPrem ELSE NULL END  as PHICPrem 
	   , CASE @PagIbigPrem WHEN 1 THEN a.PagIbigPrem ELSE NULL END as PagIbigPrem 
	   , CASE @SSSLoan WHEN 1 THEN a.SSSLoan ELSE NULL END as SSSLoan 
	   , CASE @PagIbigLoan WHEN 1 THEN a.PagIbigLoan ELSE NULL END as PagIbigLoan 
	   , CASE @Savings WHEN 1 THEN a.Savings ELSE NULL END as Savings 
	   , NULL as CashAdvance 
	   ,CASE isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) 
		WHEN 0 THEN NULL ELSE  
		isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) END as [Late|EO]
       
       ,CASE isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) WHEN 0 THEN NULL ELSE
       isnull((Select top 1 LatePerMinutePenalty From AttendanceRule),0) END as Penalty
	   ,NULL as OtherDeduction 
	   ,NULL as [Net Pay]

from Employees a  where a.Stat=1   and a.Department=@Department and
(Select SUM( dbo.GetWorkDay(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))
+ (Select SUM( dbo.GetWorkDayOvertime(c.IDS))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  >0
END


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollInsert')
   DROP PROCEDURE PayrollInsert
   GO
   
CREATE PROCEDURE PayrollInsert
(
		 
         @IDS numeric,
         @PayrollDate datetime,
		 @DateFrom datetime,
		 @DateTo Datetime,
		 @Department numeric,
		 @Remarks  nvarchar(300),
		 @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO Payroll(
         PayrollDate ,
		 DateFrom ,
		 DateTo ,
		 Department ,
		 Remarks ) 
	VALUES (
         @PayrollDate ,
		 @DateFrom ,
		 @DateTo ,
		 @Department ,
		 @Remarks )
		 
	SELECT @IDSOut=IDENT_CURRENT('Payroll')
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollUpdate')
   DROP PROCEDURE PayrollUpdate
   GO
   
CREATE PROCEDURE PayrollUpdate
(
         @IDS numeric,
         @PayrollDate datetime,
		 @DateFrom datetime,
		 @DateTo Datetime,
		 @Department numeric,
		 @Remarks  nvarchar(300)

)
AS
BEGIN
	UPDATE  Payroll SET    
		 PayrollDate=PayrollDate ,
		 DateFrom =DateFrom,
		 DateTo=DateTo ,
		 Department=Department ,
		 Remarks  =Remarks
  WHERE IDS=@IDS
						 
END

 IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollList')
   DROP PROCEDURE PayrollList
   GO
   
CREATE PROCEDURE PayrollList

AS
BEGIN
	Select  a.IDS,  
         a.PayrollDate ,
		 a.DateFrom ,
		 a.DateTo ,
		 (select Department From Departments WHERE IDS=a.Department) as Department,
		 a.Remarks 
	FROM Payroll a ORDER BY a.PayrollDate ASC
					 
END
GO

 IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollSelect')
   DROP PROCEDURE PayrollSelect
   GO
   
CREATE PROCEDURE PayrollSelect
(
		 
		 @IDS numeric 
)
AS
BEGIN
	Select IDS,  
         PayrollDate ,
		 DateFrom ,
		 DateTo ,
		 Department ,
		 Remarks 
	FROM Payroll WHERE IDS=@IDS
					 
END
GO





IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployeeInsert')
   DROP PROCEDURE PayrollEmployeeInsert
   GO
   
CREATE PROCEDURE PayrollEmployeeInsert
(	 
		 @IDS numeric  ,
         @EmployeeIDS numeric,
         @PayrollIDS numeric,
         @Department numeric,
         @NoOfDays money,
         @SalaryRate money,
         @OTHours money,
         @OTRate money,
         @Incentives money,
         @SSSPrem money,
		 @PHICPrem money,
		 @PagIbigPrem money,
		 @SSSLoan money,
		 @PagIbigLoan money,
		 @CashAdvance money,
		 @Savings money,
		 @OtherDeduction money,
		 @LateEO money,
		 @LateEORate money,
		 @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO PayrollEmployee (    
         EmployeeIDS ,
         PayrollIDS ,
         Department ,
         NoOfDays ,
         SalaryRate ,
         OTHours ,
         OTRate ,
         Incentives ,
         SSSPrem ,
		 PHICPrem ,
		 PagIbigPrem ,
		 SSSLoan ,
		 PagIbigLoan ,
		 CashAdvance ,
		 Savings ,
		 OtherDeduction ,
		 LateEO ,
		 LateEORate 
	  )
						 
	VALUES ( 		 
	     @EmployeeIDS ,
         @PayrollIDS ,
         @Department ,
         @NoOfDays ,
         @SalaryRate ,
         @OTHours ,
         @OTRate ,
         @Incentives ,
         @SSSPrem ,
		 @PHICPrem ,
		 @PagIbigPrem ,
		 @SSSLoan ,
		 @PagIbigLoan ,
		 @CashAdvance ,
		 @Savings ,
		 @OtherDeduction ,
		 @LateEO ,
		 @LateEORate
	)
	
	SELECT @IDSOut=IDENT_CURRENT('PayrollEmployee')
				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployeeUpdate')
   DROP PROCEDURE PayrollEmployeeUpdate
   GO
   
CREATE PROCEDURE PayrollEmployeeUpdate
(
		 @IDS numeric  ,
         @EmployeeIDS numeric,
         @PayrollIDS numeric,
         @Department numeric,
         @NoOfDays money,
         @SalaryRate money,
         @OTHours money,
         @OTRate money,
         @Incentives money,
         @SSSPrem money,
		 @PHICPrem money,
		 @PagIbigPrem money,
		 @SSSLoan money,
		 @PagIbigLoan money,
		 @CashAdvance money,
		 @Savings money,
		 @OtherDeduction money,
		 @LateEO money,
		 @LateEORate money
)
AS
BEGIN
	UPDATE  PayrollEmployee SET    
         EmployeeIDS= @EmployeeIDS,
         PayrollIDS= @PayrollIDS,
         Department=@Department ,
         NoOfDays =@NoOfDays,
         SalaryRate=@SalaryRate ,
         OTHours=@OTHours ,
         OTRate=@OTRate ,
         Incentives=@Incentives ,
         SSSPrem=@SSSPrem ,
		 PHICPrem =@PHICPrem,
		 PagIbigPrem=@PagIbigPrem ,
		 SSSLoan=@SSSLoan ,
		 PagIbigLoan=@PagIbigLoan ,
		 CashAdvance =@CashAdvance,
		 Savings=@Savings ,
		 OtherDeduction= @OtherDeduction,
		 LateEO=@LateEO ,
		 LateEORate =@LateEORate
  WHERE IDS=@IDS
						 
END


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployeeSelect')
   DROP PROCEDURE PayrollEmployeeSelect
   GO 
CREATE PROCEDURE PayrollEmployeeSelect
(	 
	@IDS numeric 
)
AS
BEGIN

Select  isnull(b.IDS,0) as IDS 
       ,b.EmployeeIDS
       ,(Select lname+ ', '+ fname  From Employees WHERE IDS=b.EmployeeIDS) as Name
	   , CASE WHEN b.NoOfDays=0 THEN NULL ELSE b.NoOfDays END as [Days Worked]					 
       ,CASE b.NoOfDays WHEN 0 THEN NULL ELSE  b.SalaryRate END   as Rate
       ,CASE WHEN b.OTHours=0 THEN NULL ELSE b.NoOfDays END as [OT Hour]
       ,CASE WHEN b.OTHours=0 THEN NULL ELSE b.OTRate END as OTRate
       ,CASE WHEN b.Incentives=0 THEN NULL ELSE b.Incentives END as Adjustment
	   ,(b.NoOfDays * isnull(b.SalaryRate,0))+(isnull(b.OTHours,0)*isnull(b.OTRate,0)) + ISNULL( b.Incentives,0) as [Gross Pay]					 
       ,CASE WHEN b.SSSPrem=0 THEN NULL ELSE b.SSSPrem END  as SSSPrem
	   ,CASE WHEN b.PHICPrem=0 THEN NULL ELSE b.PHICPrem END as PHICPrem 
	   ,CASE WHEN b.PagIbigPrem =0 THEN NULL ELSE b.PagIbigPrem END   as PagIbigPrem 
	   ,CASE WHEN b.SSSLoan=0 THEN NULL ELSE b.SSSLoan END  as SSSLoan 
	   ,CASE WHEN b.PagIbigLoan=0 THEN NULL ELSE b.PagIbigLoan END  as PagIbigLoan 
	   ,CASE WHEN b.Savings=0 THEN NULL ELSE b.Savings END as Savings 
	   ,CASE WHEN b.CashAdvance=0 THEN NULL ELSE b.CashAdvance END as CashAdvance 
	   ,CASE WHEN b.LateEO=0 THEN NULL ELSE b.LateEO END as [Late|EO]
       ,CASE WHEN b.LateEO=0 THEN NULL ELSE b.LateEORate END as Penalty
	   ,CASE WHEN b.OtherDeduction=0 THEN NULL ELSE b.OtherDeduction END as OtherDeduction 
	   ,((b.NoOfdays*isnull(b.SalaryRate,0))+(isnull(b.OTHours,0)*isnull(b.OTRate,0)) +  ISNULL( b.Incentives,0))
		- (isnull(b.SSSPrem,0)+isnull(b.PHICPrem,0) +isnull(b.PagIbigPrem,0) +isnull(b.SSSLoan,0) + isnull(b.PagIbigLoan,0) 
		+ isnull(b.CashAdvance,0) + isnull(b.Savings,0) + isnull(b.OtherDeduction,0)+(b.LateEO*b.LateEORate) ) as [Net Pay]
		 
from PayrollEmployee b  where PayrollIDS=@IDS  
				 				 
END
GO


 IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollSelectPrint')
   DROP PROCEDURE PayrollSelectPrint
   GO
   
CREATE PROCEDURE PayrollSelectPrint
(
		 
		 @IDS numeric 
)
AS
BEGIN
	Select a.IDS,  
         convert(varchar,  a.PayrollDate , 107) as PayrollDate ,
		 convert(varchar,  a.DateFrom , 107)  as DateFrom ,
		 convert(varchar,  a.DateTo , 107) as DateTo ,
		 (select Department From Departments WHERE IDS=a.Department) as Department ,
		 a.Remarks 
	FROM Payroll a WHERE IDS=@IDS
					 
END
GO

IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployeeSelectPrint')
   DROP PROCEDURE PayrollEmployeeSelectPrint
   GO 
CREATE PROCEDURE PayrollEmployeeSelectPrint
(	 
	@IDS numeric 
)
AS
BEGIN

Select  isnull(b.IDS,0) as IDS 
       ,b.EmployeeIDS
       ,(Select lname+ ', '+ fname  From Employees WHERE IDS=b.EmployeeIDS) as Name
	   , CASE WHEN b.NoOfDays=0 THEN NULL ELSE b.NoOfDays END as [Days Worked]					 
       ,CASE b.NoOfDays WHEN 0 THEN NULL ELSE  b.SalaryRate END   as Rate
       ,CASE WHEN b.OTHours=0 THEN NULL ELSE b.NoOfDays END as [OT Hour]
       ,CASE WHEN b.OTHours=0 THEN NULL ELSE b.OTRate END as OTRate 
       ,CASE WHEN b.Incentives=0 THEN NULL ELSE b.Incentives END as Adjustment
       ,(isnull(b.OTHours,0)*isnull(b.OTRate,0)) + ISNULL( b.Incentives,0) as Adj
	   ,(b.NoOfDays * isnull(b.SalaryRate,0))+(isnull(b.OTHours,0)*isnull(b.OTRate,0)) + ISNULL( b.Incentives,0) as [Gross Pay]					 
       ,CASE WHEN b.SSSPrem=0 THEN NULL ELSE b.SSSPrem END  as SSSPrem
	   ,CASE WHEN b.PHICPrem=0 THEN NULL ELSE b.PHICPrem END as PHICPrem 
	   ,CASE WHEN b.PagIbigPrem =0 THEN NULL ELSE b.PagIbigPrem END   as PagIbigPrem 
	   ,CASE WHEN b.SSSLoan=0 THEN NULL ELSE b.SSSLoan END  as SSSLoan 
	   ,CASE WHEN b.PagIbigLoan=0 THEN NULL ELSE b.PagIbigLoan END  as PagIbigLoan 
	   ,CASE WHEN b.Savings=0 THEN NULL ELSE b.Savings END as Savings 
	   ,CASE WHEN b.CashAdvance=0 THEN NULL ELSE b.CashAdvance END as CashAdvance 
	   ,CASE WHEN b.LateEO=0 THEN NULL ELSE b.LateEO END as [Late|EO]
       ,CASE WHEN b.LateEO=0 THEN NULL ELSE b.LateEORate END as Penalty
       ,CASE WHEN isnull(b.LateEO,0) *isnull(b.LateEORate,0) =0 THEN NULL ELSE isnull(b.LateEO,0) *isnull(b.LateEORate,0)  END as PenaltyAmount
	   ,CASE WHEN b.OtherDeduction=0 THEN NULL ELSE b.OtherDeduction END as OtherDeduction 
	   ,(isnull(b.SSSPrem,0)+isnull(b.PHICPrem,0) +isnull(b.PagIbigPrem,0) +isnull(b.SSSLoan,0) + isnull(b.PagIbigLoan,0) 
		+ isnull(b.CashAdvance,0) + isnull(b.Savings,0) + isnull(b.OtherDeduction,0)+(b.LateEO*b.LateEORate) )  as [Total Deduction]
	   ,((b.NoOfdays*isnull(b.SalaryRate,0))+(isnull(b.OTHours,0)*isnull(b.OTRate,0)) +  ISNULL( b.Incentives,0))
		- (isnull(b.SSSPrem,0)+isnull(b.PHICPrem,0) +isnull(b.PagIbigPrem,0) +isnull(b.SSSLoan,0) + isnull(b.PagIbigLoan,0) 
		+ isnull(b.CashAdvance,0) + isnull(b.Savings,0) + isnull(b.OtherDeduction,0)+(b.LateEO*b.LateEORate) ) as [Net Pay]
	 
from PayrollEmployee b  where PayrollIDS=@IDS 
				 				 
END
GO


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollSelectEmployee')
   DROP PROCEDURE PayrollSelectEmployee
   GO
   
CREATE PROCEDURE PayrollSelectEmployee
(	  
		  @DateFrom datetime
		 ,@DateTo Datetime
		 ,@Department numeric
		 ,@IDS numeric

)
AS
BEGIN

Select  DISTINCT a.IDS as EmployeeIDS

	   ,[Days Worked]=(Select SUM( dbo.GetWorkDay(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  					 
       , CASE isnull((Select SUM( dbo.GetWorkDay(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) 
		WHEN 0 THEN NULL ELSE a.Salary END  as Rate
       ,(Select SUM( dbo.GetWorkDayOvertime(c.IDS))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME))  as [OT Hour]
		
        ,CASE ISNULL((Select SUM( dbo.GetWorkDayOvertime(c.IDS))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) WHEN 0 THEN NULL ELSE a.OTRate END as  OTRate
 
	   ,CASE isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) 
		WHEN 0 THEN NULL ELSE  
		isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) END as [Late|EO]
       
       ,CASE isnull((Select SUM( dbo.GetWorkDayLateEO(c.IDS,180))  FROM AttendanceLog  c WHERE c.EmployeeIDS=a.IDS  
		and CAST(FLOOR(CAST(c.AttendanceDate AS float)) AS DATETIME)  BETWEEN CAST(FLOOR(CAST(@DateFrom AS float)) AS DATETIME) and CAST(FLOOR(CAST(@DateTo AS float)) AS DATETIME)),0) WHEN 0 THEN NULL ELSE
       isnull((Select top 1 LatePerMinutePenalty From AttendanceRule),0) END as Penalty


from Employees a  where a.Stat=1   and a.Department=@Department and a.IDS=@IDS

END


IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployeeDelete')
   DROP PROCEDURE PayrollEmployeeDelete
   GO
   
CREATE PROCEDURE PayrollEmployeeDelete
(	  

		 @IDS numeric

)
AS
BEGIN

Delete from PayrollEmployee where IDS=@IDS

END

