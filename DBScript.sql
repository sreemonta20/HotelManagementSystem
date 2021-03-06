USE [master]
GO
/****** Object:  Database [HMDBSREE]    Script Date: 12/30/2020 11:00:18 PM ******/
CREATE DATABASE [HMDBSREE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMDBSREE', FILENAME = N'D:\Personal Dev Work\HMS\Database\HMDBSREE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HMDBSREE_log', FILENAME = N'D:\Personal Dev Work\HMS\Database\HMDBSREE_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HMDBSREE] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMDBSREE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HMDBSREE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HMDBSREE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HMDBSREE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HMDBSREE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HMDBSREE] SET ARITHABORT OFF 
GO
ALTER DATABASE [HMDBSREE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HMDBSREE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HMDBSREE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HMDBSREE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HMDBSREE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HMDBSREE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HMDBSREE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HMDBSREE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HMDBSREE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HMDBSREE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HMDBSREE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HMDBSREE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HMDBSREE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HMDBSREE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HMDBSREE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HMDBSREE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HMDBSREE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HMDBSREE] SET RECOVERY FULL 
GO
ALTER DATABASE [HMDBSREE] SET  MULTI_USER 
GO
ALTER DATABASE [HMDBSREE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HMDBSREE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HMDBSREE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HMDBSREE] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HMDBSREE] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HMDBSREE', N'ON'
GO
ALTER DATABASE [HMDBSREE] SET QUERY_STORE = OFF
GO
USE [HMDBSREE]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HMDBSREE]
GO
/****** Object:  Table [dbo].[RoomServiceToCustomer]    Script Date: 12/30/2020 11:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomServiceToCustomer](
	[RoomServiceToCustID] [varchar](50) NOT NULL,
	[CustomerCode] [varchar](50) NOT NULL,
	[RoomCode] [varchar](50) NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[DepartureDate] [datetime] NULL,
	[TotalRoomRent] [float] NULL,
	[PurposeOfArrival] [varchar](100) NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomServiceToCustomer] PRIMARY KEY CLUSTERED 
(
	[RoomServiceToCustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RoomServiceToCustomerWiseDetails]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[RoomServiceToCustomerWiseDetails] 
As
Select RoomCode, DepartureDate, TotalRoomRent 
From RoomServiceToCustomer
Where DepartureDate <> ''

GO
/****** Object:  Table [dbo].[FoodServiceToCustomer]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodServiceToCustomer](
	[FoodServiceToCustID] [varchar](50) NOT NULL,
	[CustomerCode] [varchar](50) NOT NULL,
	[RoomCode] [varchar](50) NOT NULL,
	[FoodServiceName] [varchar](100) NOT NULL,
	[FoodPrice] [float] NOT NULL,
	[Quantity] [float] NOT NULL,
	[ServiceDate] [datetime] NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FoodServiceToCustomer] PRIMARY KEY CLUSTERED 
(
	[FoodServiceToCustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RoomServiceToCustomerWiseServiceIncomeSummery]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[RoomServiceToCustomerWiseServiceIncomeSummery] 
As
Select RoomCode,SUM(FoodPrice*Quantity) As Amount 
From FoodServiceToCustomer 
Group By RoomCode

GO
/****** Object:  View [dbo].[RoomServiceToCustomerWiseSummery]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[RoomServiceToCustomerWiseSummery] 
As
Select RoomCode,sum(TotalRoomRent) As TotalRoomRent 
From RoomServiceToCustomer 
Where DepartureDate <> '' group by RoomCode

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingCode] [varchar](50) NOT NULL,
	[RoomCode] [varchar](50) NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[BookingEndDate] [datetime] NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[Remark] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerCode] [varchar](50) NOT NULL,
	[UserCode] [varchar](50) NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[Address] [varchar](100) NULL,
	[ContactNo] [varchar](50) NULL,
	[EmailAddress] [varchar](100) NULL,
	[Remark] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodService]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodService](
	[FoodServiceCode] [varchar](50) NOT NULL,
	[FoodServiceName] [varchar](100) NOT NULL,
	[FSType] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_FoodService] PRIMARY KEY CLUSTERED 
(
	[FoodServiceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomService]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomService](
	[RoomCode] [varchar](50) NOT NULL,
	[RoomTypeCode] [varchar](50) NOT NULL,
	[RoomStatus] [varchar](20) NOT NULL,
 CONSTRAINT [PK_RoomService] PRIMARY KEY CLUSTERED 
(
	[RoomCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomTypeDetails]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTypeDetails](
	[RoomTypeCode] [varchar](50) NOT NULL,
	[RoomTypeName] [varchar](100) NOT NULL,
	[RoomCost] [float] NOT NULL,
 CONSTRAINT [PK_RoomTypeDetails] PRIMARY KEY CLUSTERED 
(
	[RoomTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceCode] [varchar](50) NOT NULL,
	[ServiceName] [varchar](100) NOT NULL,
	[ServiceType] [varchar](50) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserCode] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerCode], [UserCode], [CustomerName], [Address], [ContactNo], [EmailAddress], [Remark]) VALUES (N'CC-001', N'sree', N'Sreemonta bhowmik', N'Chittagong', N' +8801710480058', N'sreemonta.bhowmik@gmail.com', N'Tour')
INSERT [dbo].[Customer] ([CustomerCode], [UserCode], [CustomerName], [Address], [ContactNo], [EmailAddress], [Remark]) VALUES (N'CC-002', N'sree', N'Shrikanta bhowmik', N'Dhaka', N' +8801710480654', N'shri.bhowmik@gmail.com', N'Strudy')
INSERT [dbo].[Customer] ([CustomerCode], [UserCode], [CustomerName], [Address], [ContactNo], [EmailAddress], [Remark]) VALUES (N'CC-003', N'sree', N'john', N'dhaka', N' 0834374334', N'ss@gmail.com', N'study')
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS001', N'7-up', N'Drinks', 20)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS002', N'Beef Bhuna', N'Local', 80)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS003', N'Biscuit', N'Snacks', 10)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS004', N'Hilsha Fish', N'SeaFood', 100)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS005', N'Chicken Masala', N'Meat', 150)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS006', N'Coffee', N'Drinks', 15)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS007', N'Tea', N'Drinks', 10)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS008', N'Pabda Fish', N'SeaFood', 60)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS009', N'Rui Fish', N'SeaFood', 50)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS010', N'Nan Bread', N'Local', 10)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS011', N'Roti', N'Local', 5)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS012', N'Minarel Water', N'Drinks', 15)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS013', N'Mutton Biriyani', N'Local', 120)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS014', N'Plain Rice', N'Local', 15)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS015', N'Fried Rice', N'Local', 30)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS016', N'Coca Cola', N'Drinks', 33)
INSERT [dbo].[FoodService] ([FoodServiceCode], [FoodServiceName], [FSType], [Price]) VALUES (N'FS017', N'Pepsi', N'Drinks', 33)
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-001', N'CC-002', N'1004', N'Hilsha Fish', 100, 3, CAST(N'2015-08-12T17:49:03.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-002', N'CC-001', N'3001', N'Chicken Masala', 150, 4, CAST(N'2015-08-12T18:22:51.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-003', N'CC-002', N'2001', N'Chicken Masala', 150, 3, CAST(N'2015-08-12T18:24:30.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-004', N'CC-003', N'1001', N'Hilsha Fish', 100, 2, CAST(N'2015-09-30T23:46:32.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-005', N'CC-003', N'1001', N'Coffee', 15, 2, CAST(N'2015-09-30T23:46:32.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-006', N'CC-002', N'3001', N'Chicken Masala', 150, 5, CAST(N'2015-10-31T15:48:09.000' AS DateTime), N'Inactive')
INSERT [dbo].[FoodServiceToCustomer] ([FoodServiceToCustID], [CustomerCode], [RoomCode], [FoodServiceName], [FoodPrice], [Quantity], [ServiceDate], [Status]) VALUES (N'FSC-007', N'CC-002', N'3001', N'Pabda Fish', 60, 6, CAST(N'2015-10-31T15:48:28.000' AS DateTime), N'Inactive')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1001', N'DA001', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1002', N'DN002', N'Registered')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1003', N'SA003', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1004', N'SN004', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1005', N'SA003', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'1006', N'DN002', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'2001', N'DA001', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'2002', N'DN002', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'2003', N'SA003', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'2004', N'SN004', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'3001', N'DA001', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'3002', N'DN002', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'3003', N'SA003', N'Empty')
INSERT [dbo].[RoomService] ([RoomCode], [RoomTypeCode], [RoomStatus]) VALUES (N'3004', N'SN004', N'Empty')
INSERT [dbo].[RoomServiceToCustomer] ([RoomServiceToCustID], [CustomerCode], [RoomCode], [ArrivalDate], [DepartureDate], [TotalRoomRent], [PurposeOfArrival], [Status]) VALUES (N'RSC-001', N'CC-002', N'1004', CAST(N'2015-08-12T17:48:47.000' AS DateTime), CAST(N'2015-08-12T17:50:24.000' AS DateTime), 1000, N'Strudy', N'Inactive')
INSERT [dbo].[RoomServiceToCustomer] ([RoomServiceToCustID], [CustomerCode], [RoomCode], [ArrivalDate], [DepartureDate], [TotalRoomRent], [PurposeOfArrival], [Status]) VALUES (N'RSC-002', N'CC-001', N'3001', CAST(N'2015-08-12T18:22:41.000' AS DateTime), CAST(N'2015-08-12T18:22:55.000' AS DateTime), 4000, N'Tour', N'Inactive')
INSERT [dbo].[RoomServiceToCustomer] ([RoomServiceToCustID], [CustomerCode], [RoomCode], [ArrivalDate], [DepartureDate], [TotalRoomRent], [PurposeOfArrival], [Status]) VALUES (N'RSC-003', N'CC-002', N'2001', CAST(N'2015-08-12T18:24:20.000' AS DateTime), CAST(N'2015-08-12T18:24:35.000' AS DateTime), 4000, N'Strudy', N'Inactive')
INSERT [dbo].[RoomServiceToCustomer] ([RoomServiceToCustID], [CustomerCode], [RoomCode], [ArrivalDate], [DepartureDate], [TotalRoomRent], [PurposeOfArrival], [Status]) VALUES (N'RSC-004', N'CC-003', N'1001', CAST(N'2015-09-30T23:45:47.000' AS DateTime), CAST(N'2015-09-30T23:46:51.000' AS DateTime), 4000, N'study', N'Inactive')
INSERT [dbo].[RoomServiceToCustomer] ([RoomServiceToCustID], [CustomerCode], [RoomCode], [ArrivalDate], [DepartureDate], [TotalRoomRent], [PurposeOfArrival], [Status]) VALUES (N'RSC-005', N'CC-002', N'3001', CAST(N'2015-10-31T15:47:47.000' AS DateTime), CAST(N'2015-10-31T15:48:37.000' AS DateTime), 4000, N'Strudy', N'Inactive')
INSERT [dbo].[RoomTypeDetails] ([RoomTypeCode], [RoomTypeName], [RoomCost]) VALUES (N'DA001', N'Double (AC)', 4000)
INSERT [dbo].[RoomTypeDetails] ([RoomTypeCode], [RoomTypeName], [RoomCost]) VALUES (N'DN002', N'Double (Non AC)', 3000)
INSERT [dbo].[RoomTypeDetails] ([RoomTypeCode], [RoomTypeName], [RoomCost]) VALUES (N'SA003', N'Single (AC)', 2000)
INSERT [dbo].[RoomTypeDetails] ([RoomTypeCode], [RoomTypeName], [RoomCost]) VALUES (N'SN004', N'Single (Non AC)', 1000)
INSERT [dbo].[Service] ([ServiceCode], [ServiceName], [ServiceType]) VALUES (N'FS002', N'Food Service', N'FoodService')
INSERT [dbo].[Service] ([ServiceCode], [ServiceName], [ServiceType]) VALUES (N'MS003', N'Miscellaneous Service', N'MiscellaneousService')
INSERT [dbo].[Service] ([ServiceCode], [ServiceName], [ServiceType]) VALUES (N'RS001', N'Room Service', N'RoomService')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserCode], [Name], [FirstName], [LastName], [Email], [Address], [UserName], [Password], [UserType]) VALUES (3, N'sreemonta bhowmik', N'sreemonta', N'bhowmik', N'sreebhowmik@gmail.com', N'Mirpur 10', N'sree', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'User')
INSERT [dbo].[User] ([UserCode], [Name], [FirstName], [LastName], [Email], [Address], [UserName], [Password], [UserType]) VALUES (4, N'Anannya Rohine', N'Anannya', N'Rohine', N'anannya.rohine@gmail.com', N'Shankar,Dhanmondi', N'anu', N'526EB6A188B0543D12DA4E667A97A12C931D1340', N'Admin')
INSERT [dbo].[User] ([UserCode], [Name], [FirstName], [LastName], [Email], [Address], [UserName], [Password], [UserType]) VALUES (5, N'babu bhowmik', N'babu', N'bhowmik', N'srre@gmail.com', N'sdds', N'babu', N'526EB6A188B0543D12DA4E667A97A12C931D1340', N'User')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  StoredProcedure [dbo].[spAuthenticateUser]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spAuthenticateUser]
@UserName Varchar(100),
@Password Varchar(100)
AS
Begin
	Declare @Count int

	Select @Count= COUNT(UserName)
	From [User] Where UserName = @UserName And [Password] = @Password
	If(@Count=1)
	Begin
		Select 1 as ReturnCode
	End
	Else
	Begin
		Select -1 as ReturnCode
	End
End

GO
/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spRegisterUser]
--exec [spRegisterUser] 'user2','user2','user@gmail.com'
@Name Varchar(150),
@FirstName Varchar(50),
@LastName Varchar(50),
@Email Varchar(150),
@Address Varchar(200),
@UserName Varchar(50),
@Password Varchar(50),
@UserType Varchar(50)

AS
Begin
	Declare @Count int,
			@ReturnCode int

	Select @Count= COUNT(UserName)
	From [User] Where UserName = @UserName
	If @Count >0
	Begin
		Set @ReturnCode = -1
	End
	Else
	Begin
		Set @ReturnCode = 1
		INSERT INTO [User]
		VALUES(@Name, @FirstName, @LastName, @Email, @Address, @UserName, @Password, @UserType)
	End
	Select @ReturnCode as ReturnValue
End

GO
/****** Object:  StoredProcedure [dbo].[spRptCustomerHistoryByDate]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptCustomerHistoryByDate] '8/12/2015','8/12/2015'
--Exec [dbo].[spRptCustomerHistoryByDate] '',''
CREATE Procedure [dbo].[spRptCustomerHistoryByDate]
@DateFrom Date,
@DateTo Date
AS
Begin
		--If(ISNULL(@CustomerName,'') <> '' And ISDATE(@DateFrom) = 1 And ISDATE(@DateTo) = 1)
		If(IsNull(@DateFrom,'') <> '' And IsNull(@DateTo,'') <> '')
			Begin
			--Print 'A'
				With A As(
					Select RSC.CustomerCode, RSC.RoomCode, CONVERT(DateTime,CONVERT(Char(10),RSC.ArrivalDate,101)) As [ArDate], 
					CONVERT(DateTime,CONVERT(Char(10),RSC.DepartureDate,101)) As [DrDate], RSC.PurposeOfArrival
					From RoomServiceToCustomer RSC
				)
				Select C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate,  RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
					From Customer C
					Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
					Inner Join A on A.CustomerCode = C.CustomerCode
					Where A.ArDate>= @DateFrom And A.DrDate<= @DateTo
					Group By C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate, RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
			End
		Else
			Begin
			--Print 'A'
				With A As(
					Select RSC.CustomerCode, RSC.RoomCode, CONVERT(DateTime,CONVERT(Char(10),RSC.ArrivalDate,101)) As [ArDate], 
					CONVERT(DateTime,CONVERT(Char(10),RSC.DepartureDate,101)) As [DrDate], RSC.PurposeOfArrival
					From RoomServiceToCustomer RSC
				)
				Select C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate,  RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
					From Customer C
					Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
					Inner Join A on A.CustomerCode = C.CustomerCode
					Group By C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate, RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
			End
End

GO
/****** Object:  StoredProcedure [dbo].[spRptCustomerHistoryByName]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptCustomerHistoryByName] ''
--Exec [dbo].[spRptCustomerHistoryByName] 'Shrikanta bhowmik'
CREATE Procedure [dbo].[spRptCustomerHistoryByName]
@CustomerName varchar(100)
AS
Begin
		If(ISNULL(@CustomerName,'') <> '')
			Begin
			--Print 'A'
				With A As(
					Select RSC.CustomerCode, RSC.RoomCode, CONVERT(DateTime,CONVERT(Char(10),RSC.ArrivalDate,101)) As [ArDate], 
					CONVERT(DateTime,CONVERT(Char(10),RSC.DepartureDate,101)) As [DrDate], RSC.PurposeOfArrival
					From RoomServiceToCustomer RSC
				)
				Select C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate,  RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
					From Customer C
					Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
					Inner Join A on A.CustomerCode = C.CustomerCode
					Where C.CustomerName = @CustomerName
					Group By C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate, RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
			End
		Else
			Begin
				With A As(
					Select RSC.CustomerCode, RSC.RoomCode, CONVERT(DateTime,CONVERT(Char(10),RSC.ArrivalDate,101)) As [ArDate], 
					CONVERT(DateTime,CONVERT(Char(10),RSC.DepartureDate,101)) As [DrDate], RSC.PurposeOfArrival
					From RoomServiceToCustomer RSC
				)
				Select C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate,  RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
					From Customer C
					Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
					Inner Join A on A.CustomerCode = C.CustomerCode
					Group By C.CustomerCode, C.CustomerName, C.ContactNo, C.EmailAddress, C.[Address], 
					RSC.RoomCode, A.ArDate, A.DrDate, RSC.ArrivalDate, RSC.DepartureDate, RSC.PurposeOfArrival
			End
End

GO
/****** Object:  StoredProcedure [dbo].[spRptCustomerServices]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptCustomerServices] '1003','0003'
CREATE Procedure [dbo].[spRptCustomerServices]
@RoomCode Varchar(100),
@CustomerCode Varchar(100)
AS
Begin
	Select RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, (Select Max(RSC.DepartureDate)) As DepartureDate, FSC.FoodServiceName, 
	(Select Max(FSC.ServiceDate)) As ServiceDate,  FSC.FoodPrice, FSC.Quantity, (FSC.FoodPrice * FSC.Quantity) As Amount, RSC.TotalRoomRent
	From Customer C
	Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
	Inner Join FoodServiceToCustomer FSC On C.CustomerCode = FSC.CustomerCode
	
	Where RSC.RoomCode = @RoomCode And C.CustomerCode = @CustomerCode 
	and FSC.RoomCode = RSC.RoomCode and FSC.CustomerCode = RSC.CustomerCode
	Group By RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, RSC.DepartureDate, FSC.FoodServiceName, 
	FSC.ServiceDate,  FSC.FoodPrice, FSC.Quantity, RSC.TotalRoomRent
End

GO
/****** Object:  StoredProcedure [dbo].[spRptFoodServiceWiseIncomeSummary]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptFoodServiceWiseIncomeSummary] '8/12/2015','8/12/2015'
CREATE Procedure [dbo].[spRptFoodServiceWiseIncomeSummary]
@DateFrom Date,
@DateTo Date
AS
Begin
	If(IsNull(@DateFrom,'') <> '' And IsNull(@DateTo,'') <> '')
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate
		From RoomServiceToCustomer O
		),
		B As(
		Select P.RoomCode,(P.FoodPrice * P.Quantity) As Amount, P.[Status]
		From FoodServiceToCustomer P
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, B.RoomCode, B.Amount 
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Inner Join B On RS.RoomCode = B.RoomCode
		Where A.BillDate Between @DateFrom And @DateTo And B.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, B.RoomCode, B.Amount
	End
	Else
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate
		From RoomServiceToCustomer O
		),
		B As(
		Select P.RoomCode,(P.FoodPrice * P.Quantity) As Amount, P.[Status]
		From FoodServiceToCustomer P
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, B.RoomCode, B.Amount 
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Inner Join B On RS.RoomCode = B.RoomCode
		Where B.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, B.RoomCode, B.Amount 
	End
End

GO
/****** Object:  StoredProcedure [dbo].[spRptRoomServiceWiseIncomeDetails]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptRoomServiceWiseIncomeDetails] '8/12/2015','8/12/2015'
CREATE Procedure [dbo].[spRptRoomServiceWiseIncomeDetails]
@DateFrom Date,
@DateTo Date
AS
Begin
	If(IsNull(@DateFrom,'') <> '' And IsNull(@DateTo,'') <> '')
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate, O.TotalRoomRent, O.[Status]
		From RoomServiceToCustomer O
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Where A.BillDate Between @DateFrom And @DateTo And A.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent 
	End
	Else
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate, O.TotalRoomRent, O.[Status]
		From RoomServiceToCustomer O
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Where A.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent 
	End
	--Select RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, (Select Max(RSC.DepartureDate)) As DepartureDate, FSC.FoodServiceName, 
	--(Select Max(FSC.ServiceDate)) As ServiceDate,  FSC.FoodPrice, FSC.Quantity, (FSC.FoodPrice * FSC.Quantity) As Amount, RSC.TotalRoomRent
	--From Customer C
	--Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
	--Inner Join FoodServiceToCustomer FSC On C.CustomerCode = FSC.CustomerCode
	
	--Where RSC.RoomCode = @RoomCode And C.CustomerCode = @CustomerCode 
	--and FSC.RoomCode = RSC.RoomCode and FSC.CustomerCode = RSC.CustomerCode
	--Group By RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, RSC.DepartureDate, FSC.FoodServiceName, 
	--FSC.ServiceDate,  FSC.FoodPrice, FSC.Quantity, RSC.TotalRoomRent
End

GO
/****** Object:  StoredProcedure [dbo].[spRptRoomServiceWiseIncomeSummary]    Script Date: 12/30/2020 11:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Exec [dbo].[spRptRoomServiceWiseIncomeSummary] '8/12/2015','8/12/2015'
CREATE Procedure [dbo].[spRptRoomServiceWiseIncomeSummary]
@DateFrom Date,
@DateTo Date
AS
Begin
	If(IsNull(@DateFrom,'') <> '' And IsNull(@DateTo,'') <> '')
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate, O.TotalRoomRent, O.[Status]
		From RoomServiceToCustomer O
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.TotalRoomRent
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Where A.BillDate Between @DateFrom And @DateTo And A.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent 
	End
	Else
	Begin
		With A As(
		Select O.RoomCode, CONVERT(DateTime,CONVERT(Char(10),O.DepartureDate,101)) As BillDate, O.TotalRoomRent, O.[Status]
		From RoomServiceToCustomer O
		)
		Select RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.TotalRoomRent
		From RoomService RS
		Inner Join RoomTypeDetails RTD On RS.RoomTypeCode = RTD.RoomTypeCode
		Inner Join A On RS.RoomCode = A.RoomCode
		Where A.[Status] <> 'Active'
		Group By RS.RoomTypeCode, RTD.RoomTypeName, A.RoomCode, A.BillDate, A.TotalRoomRent 
	End
	--Select RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, (Select Max(RSC.DepartureDate)) As DepartureDate, FSC.FoodServiceName, 
	--(Select Max(FSC.ServiceDate)) As ServiceDate,  FSC.FoodPrice, FSC.Quantity, (FSC.FoodPrice * FSC.Quantity) As Amount, RSC.TotalRoomRent
	--From Customer C
	--Inner Join RoomServiceToCustomer RSC On C.CustomerCode = RSC.CustomerCode
	--Inner Join FoodServiceToCustomer FSC On C.CustomerCode = FSC.CustomerCode
	
	--Where RSC.RoomCode = @RoomCode And C.CustomerCode = @CustomerCode 
	--and FSC.RoomCode = RSC.RoomCode and FSC.CustomerCode = RSC.CustomerCode
	--Group By RSC.RoomCode, C.CustomerCode, C.CustomerName, RSC.ArrivalDate, RSC.DepartureDate, FSC.FoodServiceName, 
	--FSC.ServiceDate,  FSC.FoodPrice, FSC.Quantity, RSC.TotalRoomRent
End

GO
USE [master]
GO
ALTER DATABASE [HMDBSREE] SET  READ_WRITE 
GO
