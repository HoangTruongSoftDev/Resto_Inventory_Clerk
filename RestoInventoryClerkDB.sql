USE [master]
GO
/****** Object:  Database [RestoInventoryClerkDB]    Script Date: 10/10/2023 12:14:44 AM ******/
CREATE DATABASE [RestoInventoryClerkDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestoInventoryClerkDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RestoInventoryClerkDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestoInventoryClerkDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RestoInventoryClerkDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RestoInventoryClerkDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestoInventoryClerkDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET  MULTI_USER 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestoInventoryClerkDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RestoInventoryClerkDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RestoInventoryClerkDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [RestoInventoryClerkDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RestoInventoryClerkDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/10/2023 12:14:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeeInformations] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 10/10/2023 12:14:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[ItemId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitOfMeasure] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/10/2023 12:14:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (444444, N'Thien', N'Nguyen', N'thien@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (555555, N'Hung', N'Buoi', N'hung@gmail.com')
GO
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (1, N'Drumstick', 150, CAST(0.59 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (2, N'Wings', 160, CAST(0.19 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (3, N'Popcorn', 50, CAST(1.99 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (4, N'Lettuce', 15, CAST(2.99 AS Decimal(18, 2)), N'lb')
GO
INSERT [dbo].[Users] ([UserId], [Password], [Position]) VALUES (1111, N'123', N'Admin')
INSERT [dbo].[Users] ([UserId], [Password], [Position]) VALUES (444444, N'123', N'Manager')
INSERT [dbo].[Users] ([UserId], [Password], [Position]) VALUES (555555, N'123', N'Staff')
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
USE [master]
GO
ALTER DATABASE [RestoInventoryClerkDB] SET  READ_WRITE 
GO
