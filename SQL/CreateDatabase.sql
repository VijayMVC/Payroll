--IF EXISTS (SElECT name FROM sysobjects WHERE name='Employees')
--   DROP table Employees
--   GO
   

CREATE TABLE Employees
(       
		 IDS numeric IDENTITY(1,1)  NOT NULL PRIMARY KEY,
		 lName nvarchar(150),
		 fName nvarchar(150),
		 mName nvarchar(150),
		 AddressHome nvarchar(150) Default(''),
		 ContactNo nvarchar(150) Default(''),
		 DateOfBirth datetime,
		 DateOfEmployment datetime,
		 Department int,
 		 Gender int,
		 CivilStatus Int,
		 Position nvarchar(200) Default(''),
		 Salary money,
		 PersonImage image,
		 Unit int,
		 Stat int,
		 CONSTRAINT CK_lName CHECK (lName<>''),
		 CONSTRAINT CK_fName CHECK (fName<>''),
		 CONSTRAINT CK_mName CHECK (mName<>'')
)


Alter table Employees add SSSPrem money
Alter table Employees add PHICPrem money
Alter table Employees add PagIbigPrem money

Alter table Employees add SSSLoan money
Alter table Employees add PagIbigLoan money

Alter table Employees add Savings money
Alter table Employees add OTRate money
Alter table Employees add AttendanceRuleIDS numeric

Alter table Employees add ShiftName nvarchar(100)


--   IF EXISTS (SElECT name FROM sysobjects WHERE name='Machine')
--   DROP table Machine
--   GO 


CREATE TABLE Machine
(        
     IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
     MachineName nvarchar(100),
     MachineNumber nvarchar(100),
     PortNumber nvarchar(100),
     IPAddress nvarchar(100),
     BaudRate nvarchar(100),
     ComType nvarchar(100),
     Stat int,
	 CONSTRAINT M_MachineName CHECK (MachineName<>'')
 )
 
 --IF EXISTS (SElECT name FROM sysobjects WHERE name='AttendanceLog')
 --  DROP table AttendanceLog
 --  GO
   
CREATE TABLE AttendanceLog
(        
     IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
     EmployeeIDS numeric,
     MachineNumber nvarchar(100),
     AttendanceDate Datetime,
     PunchIn datetime,
     PunchOut datetime,
     BreakOut datetime,
     BreakIn datetime,
     OTIn datetime,
     OTOut datetime,
	 CONSTRAINT A_EmployeeIDS CHECK (EmployeeIDS>0)
 )
      
    Alter table AttendanceLog add PunchInRule Datetime default NULL
    Alter table AttendanceLog add  BreakOutRule Datetime default NULL
    Alter table AttendanceLog add  BreakInRule Datetime default NULL
    Alter table AttendanceLog add  PunchOutRule Datetime default NULL
    Alter table AttendanceLog add  OTInRule Datetime default NULL
    Alter table AttendanceLog add  OTOutRule Datetime default NULL
 

  CREATE TABLE AttendanceRuleParent
(
		  IDS numeric IDENTITY(1,1)  NOT NULL PRIMARY KEY
         ,DescriptionName nvarchar(100)

)
 
 CREATE TABLE AttendanceRule
(
		  IDS numeric IDENTITY(1,1)  NOT NULL PRIMARY KEY
         ,PunchInRule Datetime
         ,BreakOutRule Datetime
         ,BreakInRule Datetime
         ,PunchOutRule Datetime
         ,OTInRule Datetime
         ,OTOutRule Datetime
		 ,LatePerMinutePenalty money
		 
)

 Alter table AttendanceRule add IDSParent numeric
 Alter table AttendanceRule add DayNumber int
  Alter table AttendanceRule add DayOfTheWeek int
 Alter table AttendanceRule add ShiftName nvarchar(100)
 


CREATE TABLE Positions
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         Position nvarchar(1000),
		 CONSTRAINT P_Position CHECK (Position<>'')
 )
 
 CREATE TABLE Units
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         Unit nvarchar(1000),
		 CONSTRAINT P_Unit CHECK (Unit<>'')
 )
 
 --IF EXISTS (SElECT name FROM sysobjects WHERE name='Departments')
 --  DROP table Departments
 --  GO 
   
  CREATE TABLE Departments
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         Department nvarchar(300),
		 CONSTRAINT P_Departtment CHECK (Department<>'')
 )
 
  
CREATE TABLE Deductions
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         Deduction nvarchar(300),
         Amount money,
		 CONSTRAINT P_Deduction CHECK (Deduction<>'')
 )
 
 CREATE TABLE Incentives
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         AdditionalAmount nvarchar(300),
         Amount money,
		 CONSTRAINT P_AdditionalAmount CHECK (AdditionalAmount<>'')
 )
 
 
--IF EXISTS (SElECT name FROM sysobjects WHERE name='Payroll')
--   DROP table Payroll
--   GO 
   CREATE TABLE Payroll
(        IDS numeric IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         PayrollDate datetime,
		 DateFrom datetime,
		 DateTo Datetime,
		 Department numeric,
		 Remarks nvarchar(300),
		 CONSTRAINT P_PayrollsDateFrom CHECK (DateFrom<>NULL),
		 CONSTRAINT P_PayrollsDateTo CHECK (DateTo<>NULL),
		 
 )
 
--IF EXISTS (SElECT name FROM sysobjects WHERE name='PayrollEmployee')
--   DROP table PayrollEmployee
--   GO

  CREATE TABLE PayrollEmployee
(        IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
         EmployeeIDS numeric,
         PayrollIDS numeric,
         Department numeric,
         NoOfDays money,
         SalaryRate money,
         OTHours money,
         OTRate money,
         Incentives money,
         SSSPrem money,
		 PHICPrem money,
		 PagIbigPrem money,
		 SSSLoan money,
		 PagIbigLoan money,
		 CashAdvance money,
		 Savings money,
		 OtherDeduction money,
		 LateEO money,
		 LateEORate money,
CONSTRAINT P_PayrollsEmployeeIDS CHECK (EmployeeIDS>0),		 
CONSTRAINT P_PayrollsPayrollIDS CHECK (PayrollIDS>0)
	
 )
  
  IF EXISTS (SElECT name FROM sysobjects WHERE name='EmployeeTemplate')
   DROP table EmployeeTemplate
   GO

  
CREATE TABLE EmployeeTemplate
(         
     IDS Int IDENTITY(1,1)  NOT NULL PRIMARY KEY,
     UserID int,
     FingerID int,
     Template image,
     TmpLen int,
     Flag int
 )