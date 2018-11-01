

IF EXISTS (SElECT name FROM sysobjects WHERE name='MachineInsert')
   DROP PROCEDURE MachineInsert
   GO
 
 
CREATE PROCEDURE MachineInsert
(
		 
         @IDS numeric ,
         @MachineName nvarchar(100),
         @MachineNumber nvarchar(100),
         @PortNumber nvarchar(100),
         @IPAddress nvarchar(100),
         @BaudRate nvarchar(100),
         @ComType nvarchar(100),
         @Stat int,
		 @IDSOut numeric OUTPUT
)
AS
BEGIN
	INSERT INTO Machine (    
         MachineName,
         MachineNumber ,
         PortNumber,
         IPAddress,
         BaudRate,
         ComType,
		 Stat 
	  )
						 
	VALUES ( 		 
         @MachineName,
         @MachineNumber ,
         @PortNumber,
         @IPAddress,
         @BaudRate,
         @ComType,
		 @Stat 
	)
	
	SELECT @IDSOut=IDENT_CURRENT('Machine')
				 
END
GO

IF EXISTS (SElECT name FROM sysobjects WHERE name='MachineUpdate')
   DROP PROCEDURE MachineUpdate
   GO
   
CREATE PROCEDURE MachineUpdate
(
		 
         @IDS numeric ,
         @MachineName nvarchar(100),
         @MachineNumber nvarchar(100),
         @PortNumber nvarchar(100),
         @IPAddress nvarchar(100),
         @BaudRate nvarchar(100),
         @ComType nvarchar(100),
         @Stat int
)
AS
BEGIN
	UPDATE Machine SET    
         MachineName=@MachineName,
         MachineNumber=@MachineNumber,
         PortNumber=@PortNumber,
         IPAddress=@IPAddress,
         BaudRate=@BaudRate,
         ComType=@ComType,
		 Stat =@Stat
	WHERE IDS=	@IDS 	 
END
GO


 IF EXISTS (SElECT name FROM sysobjects WHERE name='MachineSelect')
   DROP PROCEDURE MachineSelect
   GO
   
CREATE PROCEDURE MachineSelect
(
		 
		 @IDS numeric 
)
AS
BEGIN
	Select  IDS, 
         MachineName,
         MachineNumber,
         PortNumber,
         IPAddress,
         BaudRate,
         ComType,
		 Stat 
	FROM Machine WHERE IDS=@IDS
	
						 
END
GO

 IF EXISTS (SElECT name FROM sysobjects WHERE name='MachineSelectDefault')
   DROP PROCEDURE MachineSelectDefault
   GO
   
CREATE PROCEDURE MachineSelectDefault

AS
BEGIN
	Select Top 1 IDS, 
         MachineName,
         MachineNumber,
         PortNumber,
         IPAddress,
         BaudRate,
         ComType,
		 Stat 
	FROM Machine 
	
						 
END
GO


 IF EXISTS (SElECT name FROM sysobjects WHERE name='MachineSelectAll')
   DROP PROCEDURE MachineSelectAll
   GO
   
CREATE PROCEDURE MachineSelectAll

AS
BEGIN
	Select IDS,    
         MachineName,
         MachineNumber,
         PortNumber,
         IPAddress,
         BaudRate
         ComType,
		Case Stat WHEN 0 THEN 'Inactive' WHEN 1 THEN 'Active' END as Status 
	FROM Machine
	
						 
END
GO
