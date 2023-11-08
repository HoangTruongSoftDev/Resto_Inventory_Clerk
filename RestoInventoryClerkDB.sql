USE [master]
GO
/****** Object:  Database [RestoInventoryClerkDB]    Script Date: 11/8/2023 12:06:58 AM ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 11/8/2023 12:06:58 AM ******/
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
/****** Object:  Table [dbo].[Inventories]    Script Date: 11/8/2023 12:06:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[ItemId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitOfMeasure] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryHistories]    Script Date: 11/8/2023 12:06:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryHistories](
	[ItemId] [int] NOT NULL,
	[CurQuantity] [int] NOT NULL,
	[PreQuantity] [int] NOT NULL,
	[ChangeTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/8/2023 12:06:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[HashedPassword] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (222222, N'Truong', N'Pham', N'truong@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (333333, N'Nan', N'Zhou', N'nan@gmail.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (555555, N'Pargol Da', N'Pooo', N'Pargol@gmail.ca')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (666666, N'Tom', N'Berry', N'tom@yahoo.com')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Email]) VALUES (888888, N'Alice', N'Wang', N'alic.wang@gmail.com')
GO
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (1, N'Drumstick', 1, CAST(0.59 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (2, N'Wings', 1520, CAST(0.19 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (3, N'Popcorn', 45, CAST(1.99 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (5, N'Lettuce', 252, CAST(99.00 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (6, N'asd', 72, CAST(66.69 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (7, N'Spinach - Frozen', 60, CAST(81.59 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (8, N'Ecolab - Hobart Washarm End Cap', 243, CAST(64.31 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (9, N'Tomatoes - Vine Ripe, Yellow', 87, CAST(24.64 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (10, N'Beef - Tenderlion, Center Cut', 246, CAST(35.49 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (11, N'Butter - Salted, Micro', 39, CAST(49.51 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (12, N'Cake - Dulce De Leche', 198, CAST(34.80 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (13, N'Oil - Olive Bertolli', 30, CAST(11.85 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (14, N'Sprouts - Brussel', 153, CAST(94.31 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (15, N'Spring Roll Wrappers', 27, CAST(99.83 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (16, N'Cheese - Fontina', 165, CAST(55.80 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (17, N'Beets', 165, CAST(95.51 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (18, N'Squash - Pepper', 255, CAST(20.80 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (19, N'Syrup - Monin, Irish Cream', 171, CAST(90.24 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (20, N'fff', 3055, CAST(4.10 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (1111, N'parg', 0, CAST(1100.00 AS Decimal(18, 2)), N'lb')
GO
INSERT [dbo].[InventoryHistories] ([ItemId], [CurQuantity], [PreQuantity], [ChangeTime]) VALUES (2, 1600, 1601, CAST(N'2023-11-07T23:05:48.213' AS DateTime))
INSERT [dbo].[InventoryHistories] ([ItemId], [CurQuantity], [PreQuantity], [ChangeTime]) VALUES (2, 1570, 1590, CAST(N'2023-11-07T23:10:13.227' AS DateTime))
INSERT [dbo].[InventoryHistories] ([ItemId], [CurQuantity], [PreQuantity], [ChangeTime]) VALUES (2, 1520, 1570, CAST(N'2023-11-07T23:48:39.623' AS DateTime))
INSERT [dbo].[InventoryHistories] ([ItemId], [CurQuantity], [PreQuantity], [ChangeTime]) VALUES (3, 45, 46, CAST(N'2023-11-07T23:54:49.460' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (1111, N'61B3226787D4AB7228D9D9421CBCE202E4B818B80AFF7F79A480FD228B2F3FCE:A05569408FD3A25902F4C5B1FF2926DF:100000:SHA256', N'Admin')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (222222, N'3AEBE0BF07A65F17C5A236AC0BFE11FC7D1A499F2517A375CC4FCCF0587D20BE:CA5B21B73BEFF2DA8F1C1DAD50C23252:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (333333, N'9EB3F83EC72881B3DB6635C96D6C4A3E70EDB9FC0835F49EC663D3D0CF4756F7:31E1DB4F10779A06B20AB7F40DF6B03D:100000:SHA256', N'Staff')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (555555, N'110D973E2859226802578FEDF896EF023E3274F727030A573CD424F680EDC799:4BD81B1EF852907D0CC80A66C391D3A6:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (666666, N'451E2CEFEB8DA5EB01BDDDF8813378166EEC9055BC03F7DF630BD5649C7E0646:36870A1F95DABDF9F62F67A86559AECB:100000:SHA256', N'Staff')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (888888, N'B5A604EAC5A909FD908EEE2E98D318D3E57E62601BDF6D2E2190F3376B6C7D2D:A12091FC639A80152186C89E6773A94A:100000:SHA256', N'Manager')
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[InventoryHistories]  WITH CHECK ADD  CONSTRAINT [FK_InventoryHistories_Inventories] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Inventories] ([ItemId])
GO
ALTER TABLE [dbo].[InventoryHistories] CHECK CONSTRAINT [FK_InventoryHistories_Inventories]
GO
USE [master]
GO
ALTER DATABASE [RestoInventoryClerkDB] SET  READ_WRITE 
GO
