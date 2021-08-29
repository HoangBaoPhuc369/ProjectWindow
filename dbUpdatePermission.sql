USE [master]
GO
/****** Object:  Database [SHOPPET]    Script Date: 8/29/2021 10:08:42 AM ******/
CREATE DATABASE [SHOPPET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SHOPPET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SHOPPET.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SHOPPET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SHOPPET_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SHOPPET] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SHOPPET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SHOPPET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SHOPPET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SHOPPET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SHOPPET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SHOPPET] SET ARITHABORT OFF 
GO
ALTER DATABASE [SHOPPET] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SHOPPET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SHOPPET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SHOPPET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SHOPPET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SHOPPET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SHOPPET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SHOPPET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SHOPPET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SHOPPET] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SHOPPET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SHOPPET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SHOPPET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SHOPPET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SHOPPET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SHOPPET] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SHOPPET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SHOPPET] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SHOPPET] SET  MULTI_USER 
GO
ALTER DATABASE [SHOPPET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SHOPPET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SHOPPET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SHOPPET] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SHOPPET] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SHOPPET] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SHOPPET] SET QUERY_STORE = OFF
GO
USE [SHOPPET]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[Billdate] [date] NOT NULL,
	[CusName] [nvarchar](50) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CusId] [int] IDENTITY(1,1) NOT NULL,
	[CusName] [nvarchar](50) NOT NULL,
	[CusPhone] [varchar](50) NOT NULL,
	[CusAddr] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[Quanlity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](50) NULL,
	[EmpAddr] [nvarchar](50) NULL,
	[EmpDOB] [date] NULL,
	[EmpPhone] [varchar](50) NULL,
	[EmpPass] [varchar](50) NULL,
	[EmpUser] [varchar](50) NULL,
	[Permission] [varchar](10) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/29/2021 10:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProId] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [nvarchar](50) NOT NULL,
	[ProCate] [varchar](20) NOT NULL,
	[ProPrice] [float] NOT NULL,
	[ProQty] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Username], [Password]) VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (1, CAST(N'2021-08-28' AS Date), N'SomeGuy', N'Phuc', 20000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (2, CAST(N'2021-08-28' AS Date), N'Lê Na', N'abc', 19000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (3, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'abc', 12000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (4, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'abc', 15000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (5, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 14000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (6, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 200)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (7, CAST(N'2021-08-28' AS Date), N'Lê Na', N'admin', 200)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (8, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 7000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (9, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 7000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (10, CAST(N'2021-08-28' AS Date), N'Lê Na', N'admin', 16000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (11, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 0)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (12, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 10000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (13, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 600)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (14, CAST(N'2021-08-28' AS Date), N'Lê Na', N'admin', 5000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (15, CAST(N'2021-08-28' AS Date), N'Nguyễn Văn Tám', N'admin', 1400)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (16, CAST(N'2021-08-28' AS Date), N'Lê Na', N'sayhellotomyfriend', 19000)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr]) VALUES (4, N'Lê Na', N'019231290', N'qeqweq')
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr]) VALUES (8, N'Hoang Bao Phuc', N'0971126942', N'Ap Le Trang')
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr]) VALUES (9, N'Nguyen Van A', N'097456123', N'TP HCM')
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr]) VALUES (10, N'Hoang Phi', N'097456987', N'Binh Duong')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Details] ON 

INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (1, N'Something', 3, 9000, 27000)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (2, N'Corgi', 1, 10000, 10000)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (3, N'Husky', 1, 9000, 9000)
SET IDENTITY_INSERT [dbo].[Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass], [EmpUser], [Permission]) VALUES (1, N'Bao Phuc', N'Phu Giao', CAST(N'2001-07-25' AS Date), N'0971126942', N'5258d0195b85c2b33efc7977f35d008c', N'sayhellotomyfriend', N'admin')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass], [EmpUser], [Permission]) VALUES (2, N'phuc hoang', N'no where', CAST(N'2021-08-24' AS Date), N'098567345', N'202cb962ac59075b964b07152d234b70', N'unknow', N'user')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass], [EmpUser], [Permission]) VALUES (3, N'ncjwewqem', N'somewhere', CAST(N'1994-02-08' AS Date), N'098456234', N'30cd2f99101cdd52cc5fda1e996ee137', N'abc', N'admin')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass], [EmpUser], [Permission]) VALUES (4, N'2lua', N'dusk', CAST(N'1991-07-23' AS Date), N'078456348', N'250cf8b51c773f3f8dc8b4be867a9a02', N'hello', N'user')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (1, N'Husky', N'Dog', 9000, 8)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (2, N'Corgi', N'Dog', 10000, 17)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (5, N'Kitty', N'Cat', 7000, 5)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (9, N'Bengal', N'Cat', 8000, 10)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [SHOPPET] SET  READ_WRITE 
GO
