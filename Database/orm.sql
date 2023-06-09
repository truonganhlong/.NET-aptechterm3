USE [master]
GO
/****** Object:  Database [OnlineMobileRecharge]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE DATABASE [OnlineMobileRecharge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineMobileRecharge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OnlineMobileRecharge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineMobileRecharge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OnlineMobileRecharge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OnlineMobileRecharge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineMobileRecharge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineMobileRecharge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineMobileRecharge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineMobileRecharge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OnlineMobileRecharge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineMobileRecharge] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OnlineMobileRecharge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET RECOVERY FULL 
GO
ALTER DATABASE [OnlineMobileRecharge] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineMobileRecharge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineMobileRecharge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineMobileRecharge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineMobileRecharge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineMobileRecharge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineMobileRecharge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OnlineMobileRecharge', N'ON'
GO
ALTER DATABASE [OnlineMobileRecharge] SET QUERY_STORE = OFF
GO
USE [OnlineMobileRecharge]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[AvatarLink] [nvarchar](max) NULL,
	[TuneID] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[Disturb] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[AvatarLink] [nvarchar](max) NULL,
	[ServiceProviderID] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceID] [int] NULL,
	[ContentFB] [nvarchar](max) NULL,
	[StarRate] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Function]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[FunctionID] [int] IDENTITY(1,1) NOT NULL,
	[FunctionDescription] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FunctionGroup]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionGroup](
	[GroupID] [int] NOT NULL,
	[FunctionID] [int] NOT NULL,
 CONSTRAINT [PK_FunctionGroup] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUser](
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotifyContent] [nvarchar](200) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProviderID] [int] NOT NULL,
	[ServiceName] [nvarchar](500) NOT NULL,
	[ServiceDescription] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Status] [bit] NULL,
	[Days] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceContract]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceContract](
	[ServiceContractID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [PK_ServiceContract] PRIMARY KEY CLUSTERED 
(
	[ServiceContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceProvider]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceProvider](
	[ServiceProviderID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceProviderName] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ServiceProvider] PRIMARY KEY CLUSTERED 
(
	[ServiceProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceContractID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[PaymentID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CardNumber] [nvarchar](max) NULL,
	[Expiry] [nvarchar](max) NULL,
	[CVV] [nvarchar](max) NULL,
	[NameOnCard] [nvarchar](max) NULL,
	[TransferTime] [datetime2](7) NOT NULL,
	[Days] [int] NULL,
	[EndTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tune]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tune](
	[TuneID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Tune] PRIMARY KEY CLUSTERED 
(
	[TuneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Status] [bit] NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFunction]    Script Date: 5/17/2023 8:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFunction](
	[UserID] [int] NOT NULL,
	[FunctionID] [int] NOT NULL,
 CONSTRAINT [PK_UserFunction] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230506193439_Initial', N'3.1.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230509173240_UpdateDays', N'3.1.28')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230512190053_updatedatabseuser', N'3.1.28')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [Email], [Password], [Phone], [Fullname], [AvatarLink], [TuneID], [CreatedAt], [UpdatedAt], [Disturb]) VALUES (1, N'long.ta.1066@aptechlearning.edu.vn', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'0357715583', N'Truong Anh Long', N'~/Content/Images/anhlong2.png', NULL, CAST(N'2023-05-07T03:16:23.8216100' AS DateTime2), CAST(N'2023-05-17T17:11:54.3471911' AS DateTime2), 0)
INSERT [dbo].[Customer] ([CustomerID], [Email], [Password], [Phone], [Fullname], [AvatarLink], [TuneID], [CreatedAt], [UpdatedAt], [Disturb]) VALUES (2, N'lan@gmail.com', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'0953735281', N'Le Thi Anh Lan', N'~/Content/Images/anhlan.jpg', NULL, CAST(N'2023-05-17T17:20:14.9966486' AS DateTime2), CAST(N'2023-05-17T17:26:25.8712967' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Email], [Phone], [Fullname], [AvatarLink], [ServiceProviderID], [CreatedAt], [UpdatedAt], [Status]) VALUES (1, N'admin@gmail.com', N'0888888888', N'admin', N'~/Content/Images/anhlong.jpg', NULL, CAST(N'2023-05-10T00:32:40.2244449' AS DateTime2), CAST(N'2023-05-17T17:30:38.1708708' AS DateTime2), 1)
INSERT [dbo].[Employee] ([EmployeeID], [Email], [Phone], [Fullname], [AvatarLink], [ServiceProviderID], [CreatedAt], [UpdatedAt], [Status]) VALUES (11, N'test@gmail.com', N'0989898989', N'employee1', NULL, 1, CAST(N'2023-05-14T03:43:21.2836510' AS DateTime2), NULL, 1)
INSERT [dbo].[Employee] ([EmployeeID], [Email], [Phone], [Fullname], [AvatarLink], [ServiceProviderID], [CreatedAt], [UpdatedAt], [Status]) VALUES (13, N'demo@gmail.com', N'0953536276', N'employee2', NULL, 2, CAST(N'2023-05-17T12:03:13.1573310' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (1, 1, 1, N'This is good', 5, CAST(N'2023-05-07T02:34:39.0193536' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (2, 1, 1, N'This is perfect', 5, CAST(N'2023-05-07T02:34:39.0193536' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (3, 1, 9, N'this is good', NULL, CAST(N'2023-05-15T03:58:28.0385800' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (4, 1, 9, N'this is perfect', NULL, CAST(N'2023-05-15T04:03:41.9931460' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (5, 1, 9, N'this is useful', NULL, CAST(N'2023-05-15T04:06:42.0123398' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (6, 2, 2, N'this is good', NULL, CAST(N'2023-05-17T17:49:25.8440655' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (7, 2, 3, N'good', NULL, CAST(N'2023-05-17T17:49:43.4597569' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (8, 2, 10, N'perfect', NULL, CAST(N'2023-05-17T17:50:05.1025056' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (9, 2, 16, N'good', NULL, CAST(N'2023-05-17T17:50:19.2189165' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (10, 2, 17, N'awesome !!!', NULL, CAST(N'2023-05-17T17:50:29.9525263' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (11, 2, 18, N'perfect', NULL, CAST(N'2023-05-17T17:50:41.8929544' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (12, 2, 33, N'useful', NULL, CAST(N'2023-05-17T17:50:53.8105282' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (13, 2, 25, N'good', NULL, CAST(N'2023-05-17T17:51:04.9444045' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (14, 2, 26, N'useful', NULL, CAST(N'2023-05-17T17:51:15.5072341' AS DateTime2), NULL, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [ServiceID], [ContentFB], [StarRate], [CreatedAt], [UpdatedAt], [Status]) VALUES (15, 2, 35, N'perfect', NULL, CAST(N'2023-05-17T17:51:25.3846061' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Function] ON 

INSERT [dbo].[Function] ([FunctionID], [FunctionDescription], [Status]) VALUES (1, N'CRUD Service', 1)
INSERT [dbo].[Function] ([FunctionID], [FunctionDescription], [Status]) VALUES (2, N'RD Transactions', 1)
INSERT [dbo].[Function] ([FunctionID], [FunctionDescription], [Status]) VALUES (3, N'RD Customers', 1)
INSERT [dbo].[Function] ([FunctionID], [FunctionDescription], [Status]) VALUES (4, N'RD Employees', 1)
SET IDENTITY_INSERT [dbo].[Function] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([GroupID], [GroupName], [Status]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Group] ([GroupID], [GroupName], [Status]) VALUES (2, N'Employee', 1)
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
INSERT [dbo].[GroupUser] ([UserID], [GroupID]) VALUES (3, 1)
INSERT [dbo].[GroupUser] ([UserID], [GroupID]) VALUES (4, 2)
INSERT [dbo].[GroupUser] ([UserID], [GroupID]) VALUES (5, 2)
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentID], [PaymentType]) VALUES (1, N'Card')
INSERT [dbo].[Payment] ([PaymentID], [PaymentType]) VALUES (2, N'Paypal')
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (1, 1, N'TopUp', N'10000 VND', CAST(10000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (2, 1, N'TopUp', N'20000 VND', CAST(20000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (3, 1, N'TopUp', N'30000 VND', CAST(30000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (4, 1, N'TopUp', N'50000 VND', CAST(50000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (5, 1, N'TopUp', N'100000 VND', CAST(100000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (6, 1, N'TopUp', N'200000 VND', CAST(200000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (7, 1, N'TopUp', N'300000 VND', CAST(300000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (8, 1, N'TopUp', N'500000 VND', CAST(500000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (9, 1, N'Plan', N'ST60N (60GB/30days)', CAST(60000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (10, 1, N'Plan', N'ST90N (120GB/30days)', CAST(90000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (11, 1, N'Plan', N'V120N (120GB/30days & free call time < 20mins)', CAST(120000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (12, 1, N'Plan', N'V150N (180GB/30days & free call time < 20mins)', CAST(150000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (16, 2, N'TopUp', N'10000 VND', CAST(10000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (17, 2, N'TopUp', N'20000 VND', CAST(20000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (18, 2, N'TopUp', N'30000 VND', CAST(30000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (19, 2, N'TopUp', N'50000 VND', CAST(50000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (20, 2, N'TopUp', N'100000 VND', CAST(100000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (21, 2, N'TopUp', N'200000 VND', CAST(200000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (22, 2, N'TopUp', N'300000 VND', CAST(300000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (23, 2, N'TopUp', N'500000 VND', CAST(500000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (24, 1, N'Plan', N'ST10K (2GB/24h)', CAST(10000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (25, 3, N'TopUp', N'10000 VND', CAST(10000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (26, 3, N'TopUp', N'20000 VND', CAST(20000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (27, 3, N'TopUp', N'30000 VND', CAST(30000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (28, 3, N'TopUp', N'50000 VND', CAST(50000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (29, 3, N'TopUp', N'100000 VND', CAST(100000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (30, 3, N'TopUp', N'200000 VND', CAST(200000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (31, 3, N'TopUp', N'300000 VND', CAST(300000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (32, 3, N'TopUp', N'500000 VND', CAST(500000.00 AS Decimal(18, 2)), 1, NULL)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (33, 2, N'Plan', N'BM99 (120GB/30days & 1500mins call time)', CAST(100000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (34, 2, N'Plan', N'D160KPLUS (90GB/30days & free call time < 20mins)', CAST(160000.00 AS Decimal(18, 2)), 1, 30)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (35, 3, N'Plan', N'D5 (1GB/1days)', CAST(5000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (36, 3, N'Plan', N'D10 (4GB/1days)', CAST(10000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Service] ([ServiceID], [ServiceProviderID], [ServiceName], [ServiceDescription], [Price], [Status], [Days]) VALUES (37, 1, N'Plan', N'MI5S (1GB/1days)', CAST(5000.00 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceContract] ON 

INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (3, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (4, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (5, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (6, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (7, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (8, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (9, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (10, N'0888888888', 1, 16)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (11, N'0357715583', 2, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (12, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (13, N'0357715583', 2, 5)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (14, N'0357715583', 2, 6)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (15, N'0357715583', 1, 9)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (16, N'0357715583', 1, 1)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (17, N'0357715583', 1, 24)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (18, N'0357715583', 1, 37)
INSERT [dbo].[ServiceContract] ([ServiceContractID], [Phone], [CustomerID], [ServiceID]) VALUES (19, N'0357715583', 1, 1)
SET IDENTITY_INSERT [dbo].[ServiceContract] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceProvider] ON 

INSERT [dbo].[ServiceProvider] ([ServiceProviderID], [ServiceProviderName], [Link], [Status]) VALUES (1, N'Viettel', NULL, 1)
INSERT [dbo].[ServiceProvider] ([ServiceProviderID], [ServiceProviderName], [Link], [Status]) VALUES (2, N'Vinaphone', NULL, 1)
INSERT [dbo].[ServiceProvider] ([ServiceProviderID], [ServiceProviderName], [Link], [Status]) VALUES (3, N'Mobiphone', NULL, 1)
SET IDENTITY_INSERT [dbo].[ServiceProvider] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (1, 5, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'318318', N'test', N'test', N'truong anh long', CAST(N'2023-05-10T01:07:03.5378206' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (2, 6, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'321313', N'test', N'test', N'Truong Anh Long', CAST(N'2023-05-10T09:57:30.6915070' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (3, 7, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'231314', N'test', N'test', N'tal', CAST(N'2023-05-12T21:36:04.6921290' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (4, 8, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'321313', N'demo', N'demo', N'demo', CAST(N'2023-05-14T20:43:02.5727083' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (5, 9, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'3242442', N'12/2023', N'test', N'Test', CAST(N'2023-05-15T03:45:52.8858170' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (6, 10, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'3123213', N'4/2023', N'test', N'Test', CAST(N'2023-05-15T03:47:32.8674705' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (7, 11, 2, 2, CAST(10000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-05-17T17:21:31.5115516' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (8, 12, 1, 2, CAST(10000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-05-17T19:37:47.8170586' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (9, 13, 2, 1, CAST(100000.00 AS Decimal(18, 2)), N'21232131', N'2/2021', N'test', N'Test', CAST(N'2023-05-17T19:57:37.8727953' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (10, 14, 2, 2, CAST(200000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-05-17T19:57:53.9374600' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (11, 15, 1, 1, CAST(60000.00 AS Decimal(18, 2)), N'312331', N'12/2012', N'2321', N'Test', CAST(N'2023-05-17T19:58:51.9514076' AS DateTime2), 30, CAST(N'2023-06-16T19:58:51.9519068' AS DateTime2))
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (12, 16, 1, 1, CAST(10000.00 AS Decimal(18, 2)), N'31231', N'21/3312', N'2313', N'Test', CAST(N'2023-05-17T20:00:09.6320126' AS DateTime2), NULL, NULL)
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (13, 18, 1, 2, CAST(5000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-05-17T20:04:30.5207401' AS DateTime2), 1, CAST(N'2023-05-18T20:04:30.5225034' AS DateTime2))
INSERT [dbo].[Transaction] ([TransactionID], [ServiceContractID], [CustomerID], [PaymentID], [Price], [CardNumber], [Expiry], [CVV], [NameOnCard], [TransferTime], [Days], [EndTime]) VALUES (14, 19, 1, 2, CAST(10000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-05-17T20:04:42.7663443' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [EmployeeID], [Status], [Password], [Username]) VALUES (3, 1, 1, N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Admin')
INSERT [dbo].[User] ([UserID], [EmployeeID], [Status], [Password], [Username]) VALUES (4, 11, NULL, N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'test')
INSERT [dbo].[User] ([UserID], [EmployeeID], [Status], [Password], [Username]) VALUES (5, 13, NULL, N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'employee2')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserFunction] ([UserID], [FunctionID]) VALUES (3, 1)
INSERT [dbo].[UserFunction] ([UserID], [FunctionID]) VALUES (3, 2)
INSERT [dbo].[UserFunction] ([UserID], [FunctionID]) VALUES (3, 3)
INSERT [dbo].[UserFunction] ([UserID], [FunctionID]) VALUES (3, 4)
GO
/****** Object:  Index [IX_Customer_TuneID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_TuneID] ON [dbo].[Customer]
(
	[TuneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_ServiceProviderID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employee_ServiceProviderID] ON [dbo].[Employee]
(
	[ServiceProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Feedback_CustomerID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Feedback_CustomerID] ON [dbo].[Feedback]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Feedback_ServiceID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Feedback_ServiceID] ON [dbo].[Feedback]
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FunctionGroup_FunctionID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_FunctionGroup_FunctionID] ON [dbo].[FunctionGroup]
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupUser_UserID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_GroupUser_UserID] ON [dbo].[GroupUser]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notification_CustomerID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notification_CustomerID] ON [dbo].[Notification]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Service_ServiceProviderID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Service_ServiceProviderID] ON [dbo].[Service]
(
	[ServiceProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ServiceContract_CustomerID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_ServiceContract_CustomerID] ON [dbo].[ServiceContract]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ServiceContract_ServiceID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_ServiceContract_ServiceID] ON [dbo].[ServiceContract]
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transaction_CustomerID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaction_CustomerID] ON [dbo].[Transaction]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transaction_PaymentID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaction_PaymentID] ON [dbo].[Transaction]
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transaction_ServiceContractID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaction_ServiceContractID] ON [dbo].[Transaction]
(
	[ServiceContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_EmployeeID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_EmployeeID] ON [dbo].[User]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserFunction_FunctionID]    Script Date: 5/17/2023 8:24:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserFunction_FunctionID] ON [dbo].[UserFunction]
(
	[FunctionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ('2023-05-13T02:00:52.8055533+07:00') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Disturb]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('2023-05-13T02:00:52.7827529+07:00') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT ('2023-05-13T02:00:52.7934093+07:00') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Notification] ADD  DEFAULT ('2023-05-13T02:00:52.7964274+07:00') FOR [Time]
GO
ALTER TABLE [dbo].[Transaction] ADD  DEFAULT ('2023-05-13T02:00:52.8025525+07:00') FOR [TransferTime]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (N'') FOR [Username]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Tune_TuneID] FOREIGN KEY([TuneID])
REFERENCES [dbo].[Tune] ([TuneID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Tune_TuneID]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_ServiceProvider_ServiceProviderID] FOREIGN KEY([ServiceProviderID])
REFERENCES [dbo].[ServiceProvider] ([ServiceProviderID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_ServiceProvider_ServiceProviderID]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Service_ServiceID] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Service_ServiceID]
GO
ALTER TABLE [dbo].[FunctionGroup]  WITH CHECK ADD  CONSTRAINT [FK_FunctionGroup_Function_FunctionID] FOREIGN KEY([FunctionID])
REFERENCES [dbo].[Function] ([FunctionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FunctionGroup] CHECK CONSTRAINT [FK_FunctionGroup_Function_FunctionID]
GO
ALTER TABLE [dbo].[FunctionGroup]  WITH CHECK ADD  CONSTRAINT [FK_FunctionGroup_Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FunctionGroup] CHECK CONSTRAINT [FK_FunctionGroup_Group_GroupID]
GO
ALTER TABLE [dbo].[GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_GroupUser_Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupUser] CHECK CONSTRAINT [FK_GroupUser_Group_GroupID]
GO
ALTER TABLE [dbo].[GroupUser]  WITH CHECK ADD  CONSTRAINT [FK_GroupUser_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupUser] CHECK CONSTRAINT [FK_GroupUser_User_UserID]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_ServiceProvider_ServiceProviderID] FOREIGN KEY([ServiceProviderID])
REFERENCES [dbo].[ServiceProvider] ([ServiceProviderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_ServiceProvider_ServiceProviderID]
GO
ALTER TABLE [dbo].[ServiceContract]  WITH CHECK ADD  CONSTRAINT [FK_ServiceContract_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceContract] CHECK CONSTRAINT [FK_ServiceContract_Customer_CustomerID]
GO
ALTER TABLE [dbo].[ServiceContract]  WITH CHECK ADD  CONSTRAINT [FK_ServiceContract_Service_ServiceID] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceContract] CHECK CONSTRAINT [FK_ServiceContract_Service_ServiceID]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer_CustomerID]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Payment_PaymentID] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Payment_PaymentID]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_ServiceContract_ServiceContractID] FOREIGN KEY([ServiceContractID])
REFERENCES [dbo].[ServiceContract] ([ServiceContractID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_ServiceContract_ServiceContractID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Employee_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Employee_EmployeeID]
GO
ALTER TABLE [dbo].[UserFunction]  WITH CHECK ADD  CONSTRAINT [FK_UserFunction_Function_FunctionID] FOREIGN KEY([FunctionID])
REFERENCES [dbo].[Function] ([FunctionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFunction] CHECK CONSTRAINT [FK_UserFunction_Function_FunctionID]
GO
ALTER TABLE [dbo].[UserFunction]  WITH CHECK ADD  CONSTRAINT [FK_UserFunction_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFunction] CHECK CONSTRAINT [FK_UserFunction_User_UserID]
GO
USE [master]
GO
ALTER DATABASE [OnlineMobileRecharge] SET  READ_WRITE 
GO
