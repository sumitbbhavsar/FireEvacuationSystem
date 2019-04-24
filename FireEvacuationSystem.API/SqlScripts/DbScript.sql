/****** Object:  StoredProcedure [dbo].[UpdateEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateEmployeeRoutes]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateEmployee]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateBlockRoutes]
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[InsertEmployeeRoutes]
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[InsertEmployee]
GO
/****** Object:  StoredProcedure [dbo].[InsertBlockRoute]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[InsertBlockRoute]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeRoutesByEmployeeId]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetEmployeeRoutesByEmployeeId]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetEmployeeById]
GO
/****** Object:  StoredProcedure [dbo].[GetBlockRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetBlockRoutesById]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAllEmployeeRoutes]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAllEmployee]
GO
/****** Object:  StoredProcedure [dbo].[GetAllBlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[GetAllBlockRoutes]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[DeleteEmployeeRoutesById]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeById]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[DeleteEmployeeById]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBlockRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[DeleteBlockRoutesById]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeRoutes]') AND type in (N'U'))
ALTER TABLE [dbo].[EmployeeRoutes] DROP CONSTRAINT IF EXISTS [FK_EmployeeRoutes_Routes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeRoutes]') AND type in (N'U'))
ALTER TABLE [dbo].[EmployeeRoutes] DROP CONSTRAINT IF EXISTS [FK_EmployeeRoutes_Employees]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP TABLE IF EXISTS [dbo].[Employees]
GO
/****** Object:  Table [dbo].[EmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP TABLE IF EXISTS [dbo].[EmployeeRoutes]
GO
/****** Object:  Table [dbo].[BlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP TABLE IF EXISTS [dbo].[BlockRoutes]
GO
/****** Object:  Database [FireEvacuationSystem]    Script Date: 4/22/2019 2:33:30 PM ******/
DROP DATABASE IF EXISTS [FireEvacuationSystem]
GO
/****** Object:  Database [FireEvacuationSystem]    Script Date: 4/22/2019 2:33:30 PM ******/
CREATE DATABASE [FireEvacuationSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FireEvacuationSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FireEvacuationSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FireEvacuationSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FireEvacuationSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FireEvacuationSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FireEvacuationSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FireEvacuationSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FireEvacuationSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FireEvacuationSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FireEvacuationSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FireEvacuationSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [FireEvacuationSystem] SET  MULTI_USER 
GO
ALTER DATABASE [FireEvacuationSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FireEvacuationSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FireEvacuationSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FireEvacuationSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FireEvacuationSystem] SET DELAYED_DURABILITY = DISABLED 
GO
/****** Object:  Table [dbo].[BlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlockRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[StartX] [decimal](7, 2) NOT NULL,
	[EndX] [decimal](7, 2) NOT NULL,
	[StartY] [decimal](7, 2) NOT NULL,
	[EndY] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[X] [decimal](7, 2) NOT NULL,
	[Y] [decimal](7, 2) NOT NULL,
	[NearByRouteId] [int] NOT NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_EmployeeRoutes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeRoutes]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoutes_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeRoutes] CHECK CONSTRAINT [FK_EmployeeRoutes_Employees]
GO
ALTER TABLE [dbo].[EmployeeRoutes]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoutes_Routes] FOREIGN KEY([NearByRouteId])
REFERENCES [dbo].[BlockRoutes] ([Id])
GO
ALTER TABLE [dbo].[EmployeeRoutes] CHECK CONSTRAINT [FK_EmployeeRoutes_Routes]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBlockRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteBlockRoutesById]
@Id INT
AS
BEGIN		
	Declare @lId INT= @Id
		
	DELETE  FROM BlockRoutes WHERE Id =@lId
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeById]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployeeById]
@Id INT
AS
BEGIN		
	Declare @lId INT= @Id
		
	DELETE  FROM Employees WHERE ID =@lId
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployeeRoutesById]
@Id INT
AS
BEGIN		
	Declare @lId INT= @Id
		
	DELETE  FROM EmployeeRoutes WHERE ID =@lId
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllBlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllBlockRoutes]		 
AS

BEGIN	

    SELECT 
	Id
	,Name
	,StartX	
	,EndX
	,StartY
	,EndY From BlockRoutes
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllEmployee]		 
AS

BEGIN	

    SELECT Id,Name From Employees 
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllEmployeeRoutes]		 
AS

BEGIN	

 select 
	temp.Id,
	temp.EmployeeId,
	temp.X,
	temp.Y,
	temp.NearByRouteId,
	temp.TimeStamp,
	e.Name as EmployeeName,
	br.Name as BlockName 
	from 
	
	(SELECT *, ROW_NUMBER() OVER(Partition by EmployeeId ORDER BY Id DESC) AS rawnu from EmployeeRoutes ) temp
	INNER JOIN  Employees e
	ON e.Id=temp.EmployeeId
	INNER JOIN BlockRoutes br
	ON br.Id=temp.NearByRouteId
	where temp.rawnu=1
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetBlockRoutesById]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetBlockRoutesById 1

CREATE PROCEDURE [dbo].[GetBlockRoutesById]	
	 @Id INT   
AS

BEGIN

	Declare @lId INT = @Id
	
	SET NOCOUNT ON;

    SELECT 
	Id
	,Name
	,StartX
	,EndX
	,StartY
	,EndY From BlockRoutes WHERE Id=@lId
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeeById]	
	 @Id INT   
AS

BEGIN

	Declare @lId INT = @Id
	
	SET NOCOUNT ON;

    SELECT Id,Name From Employees WHERE Id=@lId
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeRoutesByEmployeeId]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetBlockRoutesById 1

CREATE PROCEDURE [dbo].[GetEmployeeRoutesByEmployeeId]	
	 @EmployeeId INT   
AS

BEGIN

	Declare @lEmployeeId INT = @EmployeeId
	
	SET NOCOUNT ON;

    SELECT TOP 1
		 er.Id
		,er.EmployeeId
		,er.X
		,er.Y
		,er.NearByRouteId
		,TimeStamp
		,e.Name AS EmployeeName
		,br.Name AS BlockName 
	From EmployeeRoutes er 
	INNER JOIN  Employees e
	ON e.Id=er.EmployeeId
	INNER JOIN BlockRoutes br
	ON br.Id=er.NearByRouteId
	WHERE EmployeeId=@lEmployeeId ORDER BY er.ID DESC
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBlockRoute]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBlockRoute]
@Name Varchar(500),
@StartX decimal(7,2),
@EndX decimal(7,2),
@StartY decimal(7,2),
@EndY decimal(7,2)
AS
BEGIN	
	Declare @lname Varchar(500) = @Name
	Declare @lId INT

	
	INSERT INTO BlockRoutes (Name, StartX, EndX, StartY, EndY)  Values  (@lname, @StartX, @EndX, @StartY, @EndY)    
	SET @lid = SCOPE_IDENTITY() 

	SELECT * FROM  BlockRoutes WHERE Id =  @lId
END
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEmployee]
@Name Varchar(500)
AS
BEGIN	
	Declare @lname Varchar(500) = @Name
	Declare @lId INT

	
	INSERT INTO Employees (Name)  Values  (@lname)    
	SET @lid = SCOPE_IDENTITY() 

	SELECT * FROM  Employees WHERE ID =  @lId
END
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEmployeeRoutes]
@EmployeeId Int,
@X decimal(7,2),
@Y decimal(7,2),
@NearByRouteId Int

AS
BEGIN	
	Declare @lEmployeeId Int	=@EmployeeId 
	Declare @lX decimal(7,2)	=@X
	Declare @lY decimal(7,2)	=@Y
	Declare @lNearByRouteId Int	=@NearByRouteId
	Declare @lId Int
	
	INSERT INTO EmployeeRoutes (EmployeeId, X ,Y , NearByRouteId, TimeStamp)  Values  (@lEmployeeId, @lX ,@lY ,@lNearByRouteId, GETUTCDATE())    
	SET @lid = SCOPE_IDENTITY() 

	SELECT * FROM  EmployeeRoutes WHERE Id =  @lId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBlockRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateBlockRoutes]
@Id INT,
@Name Varchar(500),
@StartX decimal(7,2),
@EndX decimal(7,2),
@StartY decimal(7,2),
@EndY decimal(7,2)
AS
BEGIN	
	Declare @lname Varchar(500) = @Name	
	Declare @lId INT= @Id

	
	UPDATE BlockRoutes SET 
	Name = @lname, 
	StartX = @StartX, 
	EndX = @EndX, 
	StartY = @StartY, 
	EndY = @EndY
	WHERE Id =@lId

	SELECT * FROM  BlockRoutes WHERE Id =  @lId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
@Id INT,
@Name Varchar(500)
AS
BEGIN	
	Declare @lname Varchar(500) = @Name	
	Declare @lId INT= @Id

	
	UPDATE Employees SET Name=@lname WHERE ID =@lId

	SELECT * FROM  Employees WHERE ID =  @lId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeRoutes]    Script Date: 4/22/2019 2:33:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployeeRoutes]
@Id INT,
@EmployeeId INT,
@X decimal(7,2),
@Y decimal(7,2),
@NearByRouteId INT
AS
BEGIN	
Declare @lId INT				=@Id
Declare @lEmployeeId INT		=@EmployeeId 
Declare @lX decimal(7,2)		=@X 
Declare @lY decimal(7,2)		=@Y 
Declare @lNearByRouteId INT		=@NearByRouteId 

	
	UPDATE EmployeeRoutes 
	SET 	 
	 EmployeeId		=@lEmployeeId,
	 X 				=@lX, 
	 Y 				=@lY, 
	 NearByRouteId 	=@lNearByRouteId 	
	WHERE Id =@lId	 

	SELECT * FROM  EmployeeRoutes WHERE Id =  @lId
END
GO
ALTER DATABASE [FireEvacuationSystem] SET  READ_WRITE 
GO
