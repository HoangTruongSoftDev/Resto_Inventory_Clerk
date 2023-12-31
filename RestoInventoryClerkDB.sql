USE [RestoInventoryClerkDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/1/2023 9:49:47 AM ******/
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
/****** Object:  Table [dbo].[Inventories]    Script Date: 11/1/2023 9:49:47 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 11/1/2023 9:49:47 AM ******/
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
GO
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (1, N'Drumstick', 150, CAST(0.59 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (2, N'Wings', 160, CAST(0.19 AS Decimal(18, 2)), N'ea')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (3, N'Popcorn', 50, CAST(1.99 AS Decimal(18, 2)), N'lb')
INSERT [dbo].[Inventories] ([ItemId], [Name], [Quantity], [UnitPrice], [UnitOfMeasure]) VALUES (4, N'Lettuce', 15, CAST(2.99 AS Decimal(18, 2)), N'lb')
GO
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (1111, N'61B3226787D4AB7228D9D9421CBCE202E4B818B80AFF7F79A480FD228B2F3FCE:A05569408FD3A25902F4C5B1FF2926DF:100000:SHA256', N'Admin')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (222222, N'3AEBE0BF07A65F17C5A236AC0BFE11FC7D1A499F2517A375CC4FCCF0587D20BE:CA5B21B73BEFF2DA8F1C1DAD50C23252:100000:SHA256', N'Manager')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (333333, N'9EB3F83EC72881B3DB6635C96D6C4A3E70EDB9FC0835F49EC663D3D0CF4756F7:31E1DB4F10779A06B20AB7F40DF6B03D:100000:SHA256', N'Staff')
INSERT [dbo].[Users] ([UserId], [HashedPassword], [Position]) VALUES (555555, N'110D973E2859226802578FEDF896EF023E3274F727030A573CD424F680EDC799:4BD81B1EF852907D0CC80A66C391D3A6:100000:SHA256', N'Manager')
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
