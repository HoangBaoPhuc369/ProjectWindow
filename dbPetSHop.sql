USE [master]
GO
/****** Object:  Database [SHOPPET]    Script Date: 8/28/2021 9:03:54 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 8/28/2021 9:03:55 AM ******/
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
/****** Object:  Table [dbo].[Bill]    Script Date: 8/28/2021 9:03:55 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 8/28/2021 9:03:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CusId] [int] IDENTITY(1,1) NOT NULL,
	[CusName] [nvarchar](50) NOT NULL,
	[CusPhone] [varchar](50) NOT NULL,
	[CusAddr] [nvarchar](50) NOT NULL,
	[CusDOB] [date] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 8/28/2021 9:03:55 AM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 8/28/2021 9:03:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[EmpAddr] [nvarchar](50) NOT NULL,
	[EmpDOB] [date] NOT NULL,
	[EmpPhone] [varchar](50) NOT NULL,
	[EmpPass] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/28/2021 9:03:55 AM ******/
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

INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (6, CAST(N'2021-08-26' AS Date), N'anonymous', N'Phuc', 10000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (7, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 141000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (8, CAST(N'2021-08-27' AS Date), N'Lê Na', N'admin', 141000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (9, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 194000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (10, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'abc', 194000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (11, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 194200)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (12, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'abc', 194200)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (13, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 27000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (14, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 41000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (15, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 23000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (16, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'abc', 33000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (17, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'abc', 29000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (18, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 48000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (19, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 0)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (20, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 10000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (21, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 10000)
INSERT [dbo].[Bill] ([BillId], [Billdate], [CusName], [EmpName], [Total]) VALUES (22, CAST(N'2021-08-27' AS Date), N'Nguyễn Văn Tám', N'admin', 24200)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr], [CusDOB]) VALUES (2, N'Nguyễn Văn Tám', N'2312343212', N'Bình Định', CAST(N'1997-04-09' AS Date))
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr], [CusDOB]) VALUES (4, N'Lê Na', N'019231290', N'qeqweq', CAST(N'2021-08-24' AS Date))
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr], [CusDOB]) VALUES (5, N'33333333333', N'1111111', N'2222222', CAST(N'2021-08-24' AS Date))
INSERT [dbo].[Customer] ([CusId], [CusName], [CusPhone], [CusAddr], [CusDOB]) VALUES (6, N'111111111111', N'44444444444', N'666666666666', CAST(N'2021-08-24' AS Date))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Details] ON 

INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (1, N'Mmm', 1, 1000, 1000)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (2, N'Bengal', 2, 5000, 10000)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (3, N'Bengal', 2, 5000, 10000)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (4, N'PateDog', 1, 200, 200)
INSERT [dbo].[Details] ([ID], [Product], [Quanlity], [Price], [Total]) VALUES (5, N'Kitty', 2, 7000, 14000)
SET IDENTITY_INSERT [dbo].[Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (1, N'Hoàng Bảo Phúc', N'Phú Giáo', CAST(N'2001-02-07' AS Date), N'0971126942', N'12345')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (2, N'Nguyễn Văn A', N'TPHCM', CAST(N'2000-03-09' AS Date), N'097567345', N'1234')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (4, N'Hoàng Bảo ', N'dqklekqmwke', CAST(N'2021-08-24' AS Date), N'2812921390', N'uqoekqk')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (8, N'Nguyễn Văn B', N'cnjqnqe', CAST(N'2001-06-14' AS Date), N'18231', N'891239812')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (9, N'abc', N'bjqkwe', CAST(N'2021-08-24' AS Date), N'0971126942', N'123')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (10, N'haha', N'qưdcc', CAST(N'2021-08-24' AS Date), N'890', N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [EmpAddr], [EmpDOB], [EmpPhone], [EmpPass]) VALUES (11, N'haha', N'qưdcc', CAST(N'2021-08-24' AS Date), N'890', N'ac4deaa349c967349ae0e48d5ba1c473')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (1, N'Husky', N'Dog', 9000, 10)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (2, N'Corgi', N'Dog', 10000, 20)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (4, N'Bengal', N'Cat', 5000, 15)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (5, N'Kitty', N'Cat', 7000, 8)
INSERT [dbo].[Product] ([ProId], [ProName], [ProCate], [ProPrice], [ProQty]) VALUES (6, N'PateDog', N'Food', 200, 10)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [SHOPPET] SET  READ_WRITE 
GO
