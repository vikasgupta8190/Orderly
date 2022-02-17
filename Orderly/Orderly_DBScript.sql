USE [master]
GO
/****** Object:  Database [Orderly]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE DATABASE [Orderly]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Orderly', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Orderly.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Orderly_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Orderly_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Orderly] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Orderly].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Orderly] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Orderly] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Orderly] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Orderly] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Orderly] SET ARITHABORT OFF 
GO
ALTER DATABASE [Orderly] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Orderly] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Orderly] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Orderly] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Orderly] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Orderly] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Orderly] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Orderly] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Orderly] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Orderly] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Orderly] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Orderly] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Orderly] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Orderly] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Orderly] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Orderly] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Orderly] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Orderly] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Orderly] SET  MULTI_USER 
GO
ALTER DATABASE [Orderly] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Orderly] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Orderly] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Orderly] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Orderly] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Orderly] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Orderly] SET QUERY_STORE = OFF
GO
USE [Orderly]
GO
/****** Object:  User [sa-pc]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE USER [sa-pc] FOR LOGIN [sa-pc] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/17/2022 2:54:11 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsPortfolioSetup] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendars]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TokenId] [int] NOT NULL,
	[Stage] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[Goal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Calendars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PageUrl] [nvarchar](max) NULL,
	[IPAddress] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestmentDynamicDistributions]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestmentDynamicDistributions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TGE] [decimal](18, 2) NOT NULL,
	[Peroid] [decimal](18, 2) NULL,
	[TokenPercentage] [decimal](18, 2) NULL,
	[Lookup] [int] NULL,
	[InvestmentId] [int] NULL,
	[LookupDuration] [int] NULL,
 CONSTRAINT [PK_InvestmentDynamicDistributions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitorings]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitorings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncommingTokenNotificationEvent] [bit] NOT NULL,
	[TokenGenerationNotificationEvent] [bit] NOT NULL,
	[PortfolioMonitoringId] [int] NULL,
	[ShowInPortfolio] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Monitorings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonitoringTypes]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitoringTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Abbreviation] [nvarchar](max) NULL,
	[Icon] [nvarchar](max) NULL,
 CONSTRAINT [PK_MonitoringTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NetworkTokens]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NetworkTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[NetworkId] [int] NOT NULL,
	[CreatedOnDateTimeUTC] [datetime2](7) NOT NULL,
	[UpdatedOnDateTimeUTC] [datetime2](7) NOT NULL,
	[UserId] [int] NULL,
	[AllTimeHighValue] [decimal](18, 2) NULL,
	[AllTimeLowValue] [decimal](18, 2) NULL,
	[CurrentPriceUSD] [decimal](18, 2) NULL,
	[Price24HrsDifference] [decimal](18, 2) NULL,
	[IsNotificationSet] [bit] NULL,
	[IsShowInPortfolio] [bit] NULL,
	[Symbol] [nvarchar](max) NULL,
 CONSTRAINT [PK_NetworkTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OTCs]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OTCs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[TokenId] [int] NOT NULL,
	[TokenQty] [int] NOT NULL,
	[Lockup] [decimal](18, 2) NOT NULL,
	[Vesting] [decimal](18, 2) NOT NULL,
	[PricePerToken] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Currency] [nvarchar](max) NULL,
	[ContactDetails] [nvarchar](max) NULL,
	[TelegramUsername] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CreatedOnDateTimeUTC] [datetime2](7) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[IsArchive] [bit] NOT NULL,
 CONSTRAINT [PK_OTCs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortfolioMonitorings]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortfolioMonitorings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TokenId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[AddressAlias] [nvarchar](max) NULL,
	[MonitoringTypeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_PortfolioMonitorings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueuedEmails]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuedEmails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NOT NULL,
	[From] [nvarchar](max) NULL,
	[To] [nvarchar](max) NULL,
	[Bcc] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[FailedTries] [int] NOT NULL,
	[Sent] [bit] NOT NULL,
	[IsTGEMail] [bit] NOT NULL,
	[SentOn] [datetime2](7) NULL,
	[TriedToSendOn] [datetime2](7) NULL,
 CONSTRAINT [PK_QueuedEmails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedInvestmentDetails]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedInvestmentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvestmentId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SharedInvestmentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserContact]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[UserGroupId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserContactGroupMappings]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContactGroupMappings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_UserContactGroupMappings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedOnUTC] [datetime2](7) NOT NULL,
	[UpdatedOnUTC] [datetime2](7) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInvestments]    Script Date: 2/17/2022 2:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInvestments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[InvestmentGUID] [uniqueidentifier] NOT NULL,
	[InvestedAmount] [decimal](18, 2) NOT NULL,
	[InvestmentTransactionLink] [nvarchar](max) NULL,
	[VestingLockup] [decimal](18, 2) NOT NULL,
	[VestingTokenPercentage] [decimal](18, 2) NOT NULL,
	[VestingId] [int] NOT NULL,
	[DistributionTypeId] [int] NOT NULL,
	[InvestmentTypeId] [int] NOT NULL,
	[SaftFile] [nvarchar](max) NULL,
	[WebsiteLink] [nvarchar](max) NULL,
	[CreatedOnDateTimeUTC] [datetime2](7) NOT NULL,
	[UpdatedOnDateTimeUTC] [datetime2](7) NOT NULL,
	[MonitoringTypeId] [int] NOT NULL,
	[CustomLink] [nvarchar](max) NULL,
	[DistributionPortal] [nvarchar](max) NULL,
	[Sign] [nvarchar](max) NULL,
	[RefundAmount] [decimal](18, 2) NOT NULL,
	[ContactId] [int] NULL,
	[SaftPathSavedFileName] [nvarchar](max) NULL,
	[InvestedQuantity] [nvarchar](max) NULL,
	[TokenId] [int] NULL,
	[NumberOfToken] [int] NOT NULL,
	[SentAddressFrom] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserInvestments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211125044838_Identity', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211125110612_InvestmentDynamicDistributionTableAdded', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211129133549_AddedUserGroupAndUserContactTables', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211130060905_RenameColumnName', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211130062616_AddColumnInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211130065658_DomainRelationChanges', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211130065804_AddedBridgeTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211201114754_addNetworkIdColumnInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211202074033_AddRefundAmountColumnInInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211203051045_DropMonitoringTypeIndexFromUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211203063354_AddErrorLogTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211207124321_AddContactIdInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211208125823_addLockupDurationInDynamicDistribution', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211208130044_MakeInvestmentDynamicColumnNullable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211208132241_AddColumnUniqueSaftFileName', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211209063855_AddDistributionAndGroupTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211209100617_RemoveDistributionAndGroupTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211215095408_AddNetworkTokensTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211215115052_AddSharedInvestmentDetailTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211216100403_AddEtherValueColumnInInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211221092206_ModifiedColumnsInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211221132726_AddInvestmentTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211222054537_AddForeignKeyInInvestmentTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211222072435_MakeNullableColumnsInvestmentTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211229072556_RemoveInvestmentTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211229101017_AddMonitoringTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211230050552_AlterMonitoringTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103061613_AddCalendarTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103064033_AlterTableNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103075041_RenameTableCalenderColumn', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103115423_AddQueuedEmailsTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103122846_RenameColumnNameForTableQueuedEmail', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220103123256_AlterTableQueuedEmail', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220104125544_MakeUserIdNullableInNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220111064621_AddPriceColumnInNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220111065647_ChangePriceColumnNameInNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220111094531_ChangeDatatypePriceColumnInNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220112072848_DailyRateDiffInNetworkTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220118074451_AddNumberOfTokenInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220118131610_AddNotificationColumnInNetworkTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220125081649_addIsSetupPortfolioColumnInApplicationUserTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220131090401_AddSentAddressFromColumnInUserInvestmentTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220201124402_AddSymbolColumnInNetworkToken', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220204094317_ChangeColumnNameInNetworkTokenTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220204105541_AddOTCTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220207112030_AddedUserColumn', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220208090729_AddedIsDeletedColumnInOTCTable', N'5.0.9')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220208093408_UpdateIsDeletedColumnNameToIsArchiveInOTCTable', N'5.0.9')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (4, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (5, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (6, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (7, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (8, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (9, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (10, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (11, 7, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (12, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (13, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (14, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (15, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (16, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (17, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (18, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (19, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (20, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (21, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (22, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (23, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (24, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (25, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (26, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (27, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (28, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (29, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (30, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (31, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (32, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (33, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (34, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (35, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (36, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1017, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1018, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1019, 2, N'UserRole', N'Admin')
GO
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1020, 2, N'UserRole', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (2, N'testparam123@gmail.com', N'TESTPARAM123@GMAIL.COM', N'testparam123@gmail.com', N'TESTPARAM123@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEAttbdWsUmD8L7svhQLlCa8n5ioQbJnaA5M845gFrkSgRKvfL8CWsjlI0FZSuiSAzw==', N'UKXVTDV3GWSRUW36CFXFPDAMDCKK6BXK', N'815f808b-3454-4b76-82c3-cd5ed1ea0cac', NULL, 0, 0, NULL, 1, 0, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (3, N'test@grr.la', N'TEST@GRR.LA', N'test@grr.la', N'TEST@GRR.LA', 0, NULL, N'7QZW5YPXBLHOJHSBNBDK3CZR2ERCW5X4', N'8ad83dbe-e23d-4d0a-879a-5225732fb3fe', NULL, 0, 0, NULL, 1, 0, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (4, N'test1@grr.la', N'TEST1@GRR.LA', N'test1@grr.la', N'TEST1@GRR.LA', 1, N'AQAAAAEAACcQAAAAECUuRmFvw6lCumdmzDj7+wKND/E4onbbkPZYGkqC5SDzm8tSGqNv7RtWmA4ggbSYEA==', N'VA6BHFIN33C5E2RG6JE77MKRVMJ32SHE', N'eca4f950-9fd4-4a09-a769-f665d391add9', NULL, 0, 0, NULL, 1, 0, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (5, N'testnew@grr.la', N'TESTNEW@GRR.LA', N'testnew@grr.la', N'TESTNEW@GRR.LA', 1, N'AQAAAAEAACcQAAAAEIMYeaVD8p5ILTzNM39kb8KtaGRDJ6UdZioa5zkbsucyOQoJxYAlXwq7bGXeayHleg==', N'VESEIRFCM57MD5IZKA2X54HGIVOHJU3J', N'6091f688-622b-4818-80de-4a7db5a2ad67', NULL, 0, 0, NULL, 1, 0, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (6, N'test111@grr.la', N'TEST111@GRR.LA', N'test111@grr.la', N'TEST111@GRR.LA', 0, NULL, N'ESRCT632HPNMFSCWX24UPOHAGBQT5KZP', N'99450a13-e933-4b5d-9edc-2f54b70c32dd', NULL, 0, 0, NULL, 1, 0, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsPortfolioSetup]) VALUES (7, N'devtesting@grr.la', N'DEVTESTING@GRR.LA', N'devtesting@grr.la', N'DEVTESTING@GRR.LA', 1, N'AQAAAAEAACcQAAAAEKz6jGsDepHPu4SSiBYEL/PEeVOTR6bWOTD5uXwoH03fqSFegd9/3dUp773T34JhXw==', N'BLRNKY4Q7P3733V5JBQKJRF3YKTF62FL', N'76ecf7fb-ec09-462d-a194-24c7951842c9', NULL, 0, 0, NULL, 1, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Calendars] ON 
GO
INSERT [dbo].[Calendars] ([Id], [TokenId], [Stage], [Date], [Goal]) VALUES (1, 13, NULL, CAST(N'2022-02-05T04:59:32.2374584' AS DateTime2), CAST(8.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Calendars] ([Id], [TokenId], [Stage], [Date], [Goal]) VALUES (2, 13, NULL, CAST(N'2022-03-05T04:59:32.2374584' AS DateTime2), CAST(8.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Calendars] OFF
GO
SET IDENTITY_INSERT [dbo].[ErrorLog] ON 
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (1, N'Error', N'Cannot return null from an action method with a return type of ''Microsoft.AspNetCore.Mvc.IActionResult''.', N'   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.EnsureActionResultNotNull(ObjectMethodExecutor executor, IActionResult actionResult)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextExceptionFilterAsync>g__Awaited|25_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)', N'/Investment/Index', N'::1', CAST(N'2021-12-08T09:26:49.4545341' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (2, N'Error', N'Could not find a part of the path ''E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\wwwroot\SaftFiles\''.', N'   at System.IO.FileStream.ValidateFileHandle(SafeFileHandle fileHandle)
   at System.IO.FileStream.CreateFileOpenHandle(FileMode mode, FileShare share, FileOptions options)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options)
   at System.IO.File.ReadAllBytes(String path)
   at Orderly.Controllers.InvestmentController.DownloadSaftFile(Int32 id) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\InvestmentController.cs:line 181', N'/Investment/DownloadSaftFile?id=1', N'::1', CAST(N'2021-12-09T05:20:29.4543211' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (5, N'Error', N'Object reference not set to an instance of an object.', N'   at Orderly.Factories.Investment.InvestmentModelFactory.<>c.<GetByIdAndUserId>b__7_1(SharedInvestmentDetails x) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Factories\Investment\InvestmentModelFactory.cs:line 154
   at System.Linq.Enumerable.SelectListIterator`2.ToList()
   at Orderly.Factories.Investment.InvestmentModelFactory.GetByIdAndUserId(Int32 Id, Int32 userId) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Factories\Investment\InvestmentModelFactory.cs:line 154
   at Orderly.Controllers.InvestmentController.Edit(Int32 id) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\InvestmentController.cs:line 329', N'/edit-investment?id=28', N'::1', CAST(N'2021-12-16T07:20:54.8017204' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (9, N'Error', N'Error converting value "Invalid Address format" to type ''System.Collections.Generic.List`1[Orderly.Models.Portfolio.ContractResultModel]''. Path ''result'', line 1, position 65.', N'   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.EnsureType(JsonReader reader, Object value, CultureInfo culture, JsonContract contract, Type targetType)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.SetPropertyValue(JsonProperty property, JsonConverter propertyConverter, JsonContainerContract containerContract, JsonProperty containerProperty, JsonReader reader, Object target)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.PopulateObject(Object newObject, JsonReader reader, JsonObjectContract contract, JsonProperty member, String id)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateObject(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.Deserialize(JsonReader reader, Type objectType, Boolean checkAdditionalContent)
   at Newtonsoft.Json.JsonSerializer.DeserializeInternal(JsonReader reader, Type objectType)
   at Newtonsoft.Json.JsonSerializer.Deserialize(JsonReader reader, Type objectType)
   at Newtonsoft.Json.JsonConvert.DeserializeObject(String value, Type type, JsonSerializerSettings settings)
   at Newtonsoft.Json.JsonConvert.DeserializeObject[T](String value, JsonSerializerSettings settings)
   at Newtonsoft.Json.JsonConvert.DeserializeObject[T](String value)
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 71', N'/manage-tokens', N'::1', CAST(N'2021-12-22T05:51:48.9280692' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (11, N'Error', N'The instance of entity type ''InvestmentToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at Orderly.Repositories.EntityRepository`1.DeleteAllAsync(List`1 entities) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 40
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 90
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 87', N'/edit-token?id=5', N'::1', CAST(N'2021-12-22T07:16:29.6371762' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (12, N'Error', N'The instance of entity type ''NetworkToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at Orderly.Repositories.EntityRepository`1.UpdateAsync(T entity) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 63
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 68
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 87', N'/edit-token?id=5', N'::1', CAST(N'2021-12-22T07:16:39.4303622' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (13, N'Error', N'The instance of entity type ''InvestmentToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at Orderly.Repositories.EntityRepository`1.DeleteAllAsync(List`1 entities) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 40
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 90
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 87', N'/edit-token?id=5', N'::1', CAST(N'2021-12-22T07:25:56.3179528' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (14, N'Error', N'The instance of entity type ''InvestmentToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at Orderly.Repositories.EntityRepository`1.DeleteAllAsync(List`1 entities) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 40
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 90
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 87', N'/edit-token?id=5', N'::1', CAST(N'2021-12-22T07:30:15.4330811' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (15, N'Error', N'The instance of entity type ''InvestmentToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at Orderly.Repositories.EntityRepository`1.UpdateAsync(T entity) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 63
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 69
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 90', N'/edit-token?id=1', N'::1', CAST(N'2021-12-28T05:18:41.9681098' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (16, N'Error', N'The instance of entity type ''UserInvestment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at Orderly.Repositories.EntityRepository`1.UpdateAsync(T entity) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 63
   at Orderly.Services.Token.NetworkTokenService.AssociateTokenToInvestment(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 102
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 84
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 90', N'/edit-token?id=9', N'::1', CAST(N'2022-01-04T05:51:26.2640387' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (17, N'Error', N'The instance of entity type ''UserInvestment'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at Orderly.Repositories.EntityRepository`1.UpdateAsync(T entity) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 63
   at Orderly.Services.Token.NetworkTokenService.AssociateTokenToInvestment(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 103
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 84
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 90', N'/edit-token?id=9', N'::1', CAST(N'2022-01-04T06:01:54.4822670' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (20, N'Error', N'The instance of entity type ''NetworkToken'' cannot be tracked because another instance with the same key value for {''Id''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.', N'   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState entityState, Boolean acceptChanges, Boolean modifyProperties, Nullable`1 forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at Orderly.Repositories.EntityRepository`1.UpdateAsync(T entity) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Repositories\EntityRepository.cs:line 63
   at Orderly.Services.Token.NetworkTokenService.InsertOrUpdate(TokenManagementModel model) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 71
   at Orderly.Controllers.TokenManagementController.Index(TokenManagementModel tokenManagementModel) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\TokenManagementController.cs:line 91', N'/edit-token?id=13', N'::1', CAST(N'2022-01-05T06:34:29.2693747' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (1016, N'Error', N'Unable to cast object of type ''System.Double'' to type ''System.Decimal''.', N'   at Microsoft.Data.SqlClient.SqlBuffer.get_Decimal()
   at lambda_method1086(Closure , QueryContext , DbDataReader , ResultContext , SingleQueryResultCoordinator )
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Orderly.Services.Token.NetworkTokenService.GetAllByInvestmentId(Int32 investmentId) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 203
   at Orderly.Factories.Investment.InvestmentModelFactory.PrepareUserInvestmentModelAsync(Int32 userId, Int32 investmentId) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Factories\Investment\InvestmentModelFactory.cs:line 76
   at Orderly.Controllers.InvestmentController.Index() in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\InvestmentController.cs:line 78
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeInnerFilterAsync>g__Awaited|13_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextExceptionFilterAsync>g__Awaited|25_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)', N'/investment-manager', N'::1', CAST(N'2022-01-11T09:42:22.0737397' AS DateTime2), 2)
GO
INSERT [dbo].[ErrorLog] ([Id], [Type], [Message], [Description], [PageUrl], [IPAddress], [CreatedOn], [CreatedBy]) VALUES (1017, N'Error', N'Unable to cast object of type ''System.Double'' to type ''System.Decimal''.', N'   at Microsoft.Data.SqlClient.SqlBuffer.get_Decimal()
   at lambda_method1086(Closure , QueryContext , DbDataReader , ResultContext , SingleQueryResultCoordinator )
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Orderly.Services.Token.NetworkTokenService.GetAllByInvestmentId(Int32 investmentId) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly.Services\Token\NetworkTokenService.cs:line 203
   at Orderly.Factories.Investment.InvestmentModelFactory.PrepareUserInvestmentModelAsync(Int32 userId, Int32 investmentId) in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Factories\Investment\InvestmentModelFactory.cs:line 76
   at Orderly.Controllers.InvestmentController.Index() in E:\Projects\Sebastian\Orderly-Core\SourceCode\Orderly\Controllers\InvestmentController.cs:line 78
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeInnerFilterAsync>g__Awaited|13_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextExceptionFilterAsync>g__Awaited|25_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)', N'/investment-manager', N'::1', CAST(N'2022-01-11T09:42:47.4103136' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[ErrorLog] OFF
GO
SET IDENTITY_INSERT [dbo].[InvestmentDynamicDistributions] ON 
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1, CAST(49.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 11, 21, 2)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (2, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(63.00 AS Decimal(18, 2)), 16, 24, 2)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (3, CAST(1.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(37.00 AS Decimal(18, 2)), 16, 24, 2)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (4, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 20, 36, 2)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (5, CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 20, 36, 2)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1004, CAST(7.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), 1, 32, 1)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1005, CAST(7.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), 1, 32, 1)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1006, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), NULL, 1037, NULL)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1007, CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), NULL, 1037, NULL)
GO
INSERT [dbo].[InvestmentDynamicDistributions] ([Id], [TGE], [Peroid], [TokenPercentage], [Lookup], [InvestmentId], [LookupDuration]) VALUES (1008, CAST(1.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), NULL, 1037, NULL)
GO
SET IDENTITY_INSERT [dbo].[InvestmentDynamicDistributions] OFF
GO
SET IDENTITY_INSERT [dbo].[Monitorings] ON 
GO
INSERT [dbo].[Monitorings] ([Id], [IncommingTokenNotificationEvent], [TokenGenerationNotificationEvent], [PortfolioMonitoringId], [ShowInPortfolio], [UserId]) VALUES (1, 1, 1, 1, 0, 2)
GO
INSERT [dbo].[Monitorings] ([Id], [IncommingTokenNotificationEvent], [TokenGenerationNotificationEvent], [PortfolioMonitoringId], [ShowInPortfolio], [UserId]) VALUES (2, 1, 1, 6, 0, 2)
GO
INSERT [dbo].[Monitorings] ([Id], [IncommingTokenNotificationEvent], [TokenGenerationNotificationEvent], [PortfolioMonitoringId], [ShowInPortfolio], [UserId]) VALUES (3, 1, 1, 5, 0, 2)
GO
INSERT [dbo].[Monitorings] ([Id], [IncommingTokenNotificationEvent], [TokenGenerationNotificationEvent], [PortfolioMonitoringId], [ShowInPortfolio], [UserId]) VALUES (1002, 1, 1, 7, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Monitorings] OFF
GO
SET IDENTITY_INSERT [dbo].[MonitoringTypes] ON 
GO
INSERT [dbo].[MonitoringTypes] ([Id], [Type], [Abbreviation], [Icon]) VALUES (1, N'Etherum', N'ETH', N'<svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" class="crypto_icon"><circle cx="12" cy="12" r="12" fill="#ECEFF0"></circle><path d="M12.0011 4.23529L7.23529 12.1439L12.0011 9.9778V4.23529Z" fill="#8C8C8C"></path><path d="M12.0011 9.97781L7.23529 12.1439L12.0011 14.9618V9.97781Z" fill="#393939"></path><path d="M16.7678 12.1439L12.0011 4.23529V9.9778L16.7678 12.1439Z" fill="#343434"></path><path d="M12.0011 14.9618L16.7678 12.1439L12.0011 9.97781V14.9618Z" fill="#141414"></path><path d="M7.23529 13.0482L12.0011 19.7647V15.8643L7.23529 13.0482Z" fill="#8C8C8C"></path><path d="M12.0011 15.8643V19.7647L16.7705 13.0482L12.0011 15.8643Z" fill="#3C3C3B"></path></svg>')
GO
INSERT [dbo].[MonitoringTypes] ([Id], [Type], [Abbreviation], [Icon]) VALUES (2, N'BitCoin', N'BCT', N'<svg width="48" height="48" viewBox="0 0 48 48" fill="none" xmlns="http://www.w3.org/2000/svg')
GO
SET IDENTITY_INSERT [dbo].[MonitoringTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[NetworkTokens] ON 
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (1, N'Test Token', N'0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359', 1, CAST(N'2021-12-16T13:10:22.9229226' AS DateTime2), CAST(N'2022-02-04T08:15:32.5344251' AS DateTime2), 2, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (2, N'test', N'test address', 2, CAST(N'2021-12-17T07:21:01.3550479' AS DateTime2), CAST(N'2021-12-20T05:52:20.5079065' AS DateTime2), 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (5, N'New Token', N'0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359', 1, CAST(N'2021-12-22T07:01:37.2355221' AS DateTime2), CAST(N'2021-12-22T07:53:30.3183585' AS DateTime2), 2, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (6, N'rajan', N'0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359', 1, CAST(N'2021-12-22T10:19:37.9860737' AS DateTime2), CAST(N'2022-02-01T13:10:46.2224336' AS DateTime2), 2, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (7, N'BNB', N'0xB8c77482e45F1F44dE1745F52C74426C631bDD52', 1, CAST(N'2021-12-29T10:42:18.7668702' AS DateTime2), CAST(N'2022-02-01T13:09:02.4224728' AS DateTime2), 2, CAST(442.86 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(379.12 AS Decimal(18, 2)), CAST(18.36 AS Decimal(18, 2)), NULL, NULL, N'BNB')
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (8, N'new bs', N'0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48', 1, CAST(N'2021-12-29T13:04:15.4960816' AS DateTime2), CAST(N'2022-02-01T13:10:13.6716220' AS DateTime2), 2, CAST(1.00 AS Decimal(18, 2)), NULL, CAST(1.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, N'USDC')
GO
INSERT [dbo].[NetworkTokens] ([Id], [Name], [Address], [NetworkId], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [UserId], [AllTimeHighValue], [AllTimeLowValue], [CurrentPriceUSD], [Price24HrsDifference], [IsNotificationSet], [IsShowInPortfolio], [Symbol]) VALUES (13, N'Gods Unchained Cards', N'0x0e3a2a1f2146d86a604adc220b4967a898d7fe07', 1, CAST(N'2022-01-05T04:59:32.2374584' AS DateTime2), CAST(N'2022-02-01T13:09:35.3542350' AS DateTime2), 2, CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, N'CARD')
GO
SET IDENTITY_INSERT [dbo].[NetworkTokens] OFF
GO
SET IDENTITY_INSERT [dbo].[OTCs] ON 
GO
INSERT [dbo].[OTCs] ([Id], [Type], [TokenId], [TokenQty], [Lockup], [Vesting], [PricePerToken], [TotalAmount], [Currency], [ContactDetails], [TelegramUsername], [Email], [CreatedOnDateTimeUTC], [CreatedByUserId], [IsArchive]) VALUES (1, N'buy', 7, 2564, CAST(0.25 AS Decimal(18, 2)), CAST(0.25 AS Decimal(18, 2)), CAST(0.25 AS Decimal(18, 2)), CAST(641.00 AS Decimal(18, 2)), N'$', N'dd', N'rwar', N'nipundigitech@gmail.com', CAST(N'2022-02-04T09:42:55.3207245' AS DateTime2), 2, 1)
GO
INSERT [dbo].[OTCs] ([Id], [Type], [TokenId], [TokenQty], [Lockup], [Vesting], [PricePerToken], [TotalAmount], [Currency], [ContactDetails], [TelegramUsername], [Email], [CreatedOnDateTimeUTC], [CreatedByUserId], [IsArchive]) VALUES (2, N'buy', 5, 2651, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.59 AS Decimal(18, 2)), CAST(1564.09 AS Decimal(18, 2)), N'$', N'dd', N'rwar', N'nipundigitech@gmail.com', CAST(N'2022-02-07T09:46:39.4921403' AS DateTime2), 2, 1)
GO
INSERT [dbo].[OTCs] ([Id], [Type], [TokenId], [TokenQty], [Lockup], [Vesting], [PricePerToken], [TotalAmount], [Currency], [ContactDetails], [TelegramUsername], [Email], [CreatedOnDateTimeUTC], [CreatedByUserId], [IsArchive]) VALUES (3, N'buy', 13, 10, CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2022-02-09T06:35:32.9732321' AS DateTime2), 2, 0)
GO
INSERT [dbo].[OTCs] ([Id], [Type], [TokenId], [TokenQty], [Lockup], [Vesting], [PricePerToken], [TotalAmount], [Currency], [ContactDetails], [TelegramUsername], [Email], [CreatedOnDateTimeUTC], [CreatedByUserId], [IsArchive]) VALUES (4, N'sell', 8, 100, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(4.98 AS Decimal(18, 2)), CAST(498.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2022-02-09T06:40:40.2712522' AS DateTime2), 2, 0)
GO
INSERT [dbo].[OTCs] ([Id], [Type], [TokenId], [TokenQty], [Lockup], [Vesting], [PricePerToken], [TotalAmount], [Currency], [ContactDetails], [TelegramUsername], [Email], [CreatedOnDateTimeUTC], [CreatedByUserId], [IsArchive]) VALUES (5, N'sell', 2, 10, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(N'2022-02-09T06:44:01.3439891' AS DateTime2), 2, 0)
GO
SET IDENTITY_INSERT [dbo].[OTCs] OFF
GO
SET IDENTITY_INSERT [dbo].[PortfolioMonitorings] ON 
GO
INSERT [dbo].[PortfolioMonitorings] ([Id], [TokenId], [Address], [AddressAlias], [MonitoringTypeId], [UserId]) VALUES (1, 0, N'0x0e3a2a1f2146d86a604adc220b4967a898d7fe07', N'New', 1, 2)
GO
INSERT [dbo].[PortfolioMonitorings] ([Id], [TokenId], [Address], [AddressAlias], [MonitoringTypeId], [UserId]) VALUES (2, 0, N'0xbd6a40bb904aea5a49c59050b5395f7484a4203d', NULL, 1, 7)
GO
INSERT [dbo].[PortfolioMonitorings] ([Id], [TokenId], [Address], [AddressAlias], [MonitoringTypeId], [UserId]) VALUES (5, 0, N'0xbd6a40bb904aea5a49c59050b5395f7484a4203d', NULL, 1, 2)
GO
INSERT [dbo].[PortfolioMonitorings] ([Id], [TokenId], [Address], [AddressAlias], [MonitoringTypeId], [UserId]) VALUES (6, 0, N'0xbd6a40bb904aea5a49c59050b5395f7484a4203d', N'weewq', 2, 2)
GO
INSERT [dbo].[PortfolioMonitorings] ([Id], [TokenId], [Address], [AddressAlias], [MonitoringTypeId], [UserId]) VALUES (7, 0, N'0xf79a41D4D89f574EbBcA2f5653759eB78a91F3a6', N'address3', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[PortfolioMonitorings] OFF
GO
SET IDENTITY_INSERT [dbo].[QueuedEmails] ON 
GO
INSERT [dbo].[QueuedEmails] ([Id], [Priority], [From], [To], [Bcc], [Body], [Subject], [Token], [FailedTries], [Sent], [IsTGEMail], [SentOn], [TriedToSendOn]) VALUES (1, 1, N'testparam123@gmail.com', N'testparam123@gmail.com', NULL, N'Hi testparam123@gmail.com</br>New Gods Unchained Cards token is generated corresponding to this address 0x0e3a2a1f2146d86a604adc220b4967a898d7fe07', N'New Token Generated', N'0x0e3a2a1f2146d86a604adc220b4967a898d7fe07', 0, 1, 1, CAST(N'2022-01-05T06:02:20.4836803' AS DateTime2), CAST(N'2022-01-05T06:02:21.3155855' AS DateTime2))
GO
INSERT [dbo].[QueuedEmails] ([Id], [Priority], [From], [To], [Bcc], [Body], [Subject], [Token], [FailedTries], [Sent], [IsTGEMail], [SentOn], [TriedToSendOn]) VALUES (2, 1, N'testparam123@gmail.com', N'testparam123@gmail.com', NULL, N'Hi testparam123@gmail.com, </br></br>New Gods Unchained Cards token is generated corresponding to this address 0x0e3a2a1f2146d86a604adc220b4967a898d7fe07 Please click <a href="https://localhost:44337/TokenManagement/Index?Id=13">here</a> associate the token with any investment', N'New Token Generated', N'0x0e3a2a1f2146d86a604adc220b4967a898d7fe07', 0, 1, 1, CAST(N'2022-01-06T07:27:59.8887836' AS DateTime2), CAST(N'2022-01-06T07:28:00.3258812' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[QueuedEmails] OFF
GO
SET IDENTITY_INSERT [dbo].[SharedInvestmentDetails] ON 
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (1, 24, 20, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (2, 24, 21, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (5, 28, 3, CAST(10.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (6, 28, 20, CAST(15.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (7, 31, 3, CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (9, 33, 3, CAST(10.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (10, 33, 3, CAST(10.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (15, 35, 3, CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (1014, 32, 3, CAST(100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[SharedInvestmentDetails] ([Id], [InvestmentId], [ContactId], [Percentage]) VALUES (1015, 1037, 3, CAST(100.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[SharedInvestmentDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[UserContact] ON 
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (1, N'test Contact', N'test', NULL, 2)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (2, N'test Contact 2', N'test', NULL, 2)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (3, N'9 contact', N'0xfb6916095ca1df60bb79ce92ce3ea74c37c5d359', NULL, 2)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (20, N'Rajan', N'0xae45a8240147e6179ec7c9f92c5a18f9a97b3fca', NULL, 7)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (21, N'Ravi ', N'0x113c83f87ce44d6a1790ec3d3c4a5f1b5ba424c8', NULL, 7)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (22, N'Vikas', N'0x0d0707963952f2fba59dd06f2b425ace40b492fe', NULL, 7)
GO
INSERT [dbo].[UserContact] ([Id], [Name], [Address], [UserGroupId], [UserId]) VALUES (23, N'Sunil', N'0x95ad61b0a150d79219dcf64e1e6cc01f0b64c4ce', NULL, 7)
GO
SET IDENTITY_INSERT [dbo].[UserContact] OFF
GO
SET IDENTITY_INSERT [dbo].[UserContactGroupMappings] ON 
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (18, 2, 7)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (19, 20, 9)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (20, 20, 10)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (21, 20, 11)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (22, 21, 9)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (23, 21, 12)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (24, 22, 9)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (25, 22, 12)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (26, 23, 9)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (27, 23, 11)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (28, 23, 12)
GO
INSERT [dbo].[UserContactGroupMappings] ([Id], [ContactId], [GroupId]) VALUES (29, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[UserContactGroupMappings] OFF
GO
SET IDENTITY_INSERT [dbo].[UserGroup] ON 
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (1, N'Developer Group', CAST(N'2021-12-09T12:35:01.7464072' AS DateTime2), CAST(N'2021-12-09T12:35:01.7464722' AS DateTime2), 2)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (2, N'Developer Group 2', CAST(N'2021-12-09T12:35:32.8211211' AS DateTime2), CAST(N'2021-12-09T12:35:32.8211212' AS DateTime2), 2)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (7, N'Developer Group 4', CAST(N'2021-12-10T09:32:32.1718801' AS DateTime2), CAST(N'2021-12-10T09:32:32.1720588' AS DateTime2), 2)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (9, N'Dev Group', CAST(N'2021-12-13T13:05:33.7320927' AS DateTime2), CAST(N'2021-12-13T13:05:33.7320930' AS DateTime2), 7)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (10, N'Dev Group (PHP)', CAST(N'2021-12-13T13:06:03.6699267' AS DateTime2), CAST(N'2021-12-13T13:06:03.6699268' AS DateTime2), 7)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (11, N'Dev Group (Full Stack)', CAST(N'2021-12-13T13:06:16.8574175' AS DateTime2), CAST(N'2021-12-13T13:06:16.8574176' AS DateTime2), 7)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (12, N'Dev Group (.NET)', CAST(N'2021-12-13T13:06:25.4848371' AS DateTime2), CAST(N'2021-12-13T13:06:25.4848372' AS DateTime2), 7)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (13, N'Dev Group (Python)', CAST(N'2021-12-13T13:06:35.6824464' AS DateTime2), CAST(N'2021-12-13T13:06:35.6824465' AS DateTime2), 7)
GO
INSERT [dbo].[UserGroup] ([Id], [Name], [CreatedOnUTC], [UpdatedOnUTC], [UserId]) VALUES (14, N'Dev Group (ROR)', CAST(N'2021-12-13T13:06:45.6349120' AS DateTime2), CAST(N'2021-12-13T13:06:45.6349121' AS DateTime2), 7)
GO
SET IDENTITY_INSERT [dbo].[UserGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInvestments] ON 
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (1, 2, N'eac0010f-02e2-4193-9744-6d0e252a8c8a', CAST(18.09 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 0, 1, 1, N'sdsa', N'https://www.google.com', CAST(N'2021-12-07T13:10:17.8790533' AS DateTime2), CAST(N'2021-12-07T13:18:37.4992925' AS DateTime2), 1, N'clll', N'ghfghhffh', NULL, CAST(0.00 AS Decimal(18, 2)), 2, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (2, 2, N'05ceef76-2fd3-4c3f-a4a1-1f0464c9712e', CAST(17.99 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:23:23.4842709' AS DateTime2), CAST(N'2021-12-08T10:23:23.5546004' AS DateTime2), 1, N'cccccccccccc1', N'454454', N'new sign', CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (3, 2, N'01476442-f5e3-46c2-9cdf-9d6909f8fd61', CAST(17.98 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:35:57.2535719' AS DateTime2), CAST(N'2021-12-08T10:35:57.2883510' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'ghfghhffh', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (4, 2, N'f7e610bc-b1b1-45d0-a4a9-0ee4729c5fda', CAST(17.96 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:36:54.9296933' AS DateTime2), CAST(N'2021-12-08T10:36:54.9458700' AS DateTime2), 1, N'clll', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (5, 2, N'126e619c-fe82-4dca-a353-bc62ad28fc7d', CAST(17.93 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:38:08.0542856' AS DateTime2), CAST(N'2021-12-08T10:38:08.0699609' AS DateTime2), 1, N'ccccccccccccc', N'distribution portal', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (6, 2, N'e82acb7d-7835-42ba-bbd6-29c89ee727b2', CAST(17.79 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:41:20.4960600' AS DateTime2), CAST(N'2021-12-08T10:41:20.5121716' AS DateTime2), 1, N'dsdaasd', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (7, 2, N'34ea7fdf-bb15-4d6b-818b-c249d895efed', CAST(17.75 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:43:35.9065587' AS DateTime2), CAST(N'2021-12-08T10:43:35.9229108' AS DateTime2), 1, N'clll', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (8, 2, N'b80af3fb-e4b5-4390-bec8-72d6564691ce', CAST(17.76 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:49:19.3733008' AS DateTime2), CAST(N'2021-12-08T10:49:19.3885857' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd1', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (9, 2, N'a9dcc135-d350-455f-80f9-33994ffdb8ea', CAST(17.80 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:53:39.3583833' AS DateTime2), CAST(N'2021-12-08T10:53:39.3737636' AS DateTime2), 1, N'sdasd2342', N'454454', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (10, 2, N'3129562f-b608-4e71-95ba-858ed3ac21e8', CAST(17.75 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:55:27.7706133' AS DateTime2), CAST(N'2021-12-08T10:55:27.8066736' AS DateTime2), 1, N'cccccccccccc1', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (11, 2, N'c677d911-47e1-48a8-bc68-7da57d2fc5fa', CAST(17.75 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T10:58:26.9820585' AS DateTime2), CAST(N'2021-12-08T10:58:26.9977090' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (12, 2, N'f2ceb0a0-1da4-4143-b428-2bd6f4594988', CAST(17.75 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:00:20.2615154' AS DateTime2), CAST(N'2021-12-08T11:00:20.3536162' AS DateTime2), 1, N'ccccccccccccc', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (13, 2, N'2792594b-b3ad-44d1-a57c-ce89256e98d5', CAST(17.75 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:00:44.6181965' AS DateTime2), CAST(N'2021-12-08T11:00:44.6196846' AS DateTime2), 1, N'ccccccccccccc', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (14, 2, N'92e85894-20cd-44b2-ad75-52f41f76a8b6', CAST(17.73 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:02:12.5435800' AS DateTime2), CAST(N'2021-12-08T11:02:12.5600194' AS DateTime2), 1, N'dsdaasd', N'ghfghhffh', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (15, 2, N'f8eb1679-3197-4fb7-a861-7c59122bbba7', CAST(17.67 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:03:43.0133665' AS DateTime2), CAST(N'2021-12-08T11:03:43.0284690' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd1', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (16, 2, N'3bf5342b-51fc-4e3b-960f-22e5195b6264', CAST(17.68 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:11:27.5602019' AS DateTime2), CAST(N'2021-12-08T11:11:27.5754528' AS DateTime2), 1, N'clll', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (17, 2, N'ddebe95e-d6b7-4def-a5b2-78ef7528585a', CAST(17.73 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:20:52.8742604' AS DateTime2), CAST(N'2021-12-08T11:20:52.9043537' AS DateTime2), 1, N'sdasd2342', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, 8, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (18, 2, N'86c7d07e-e8aa-4bb9-838b-b32e04415dbc', CAST(17.68 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T11:29:12.3888851' AS DateTime2), CAST(N'2021-12-08T11:29:12.4225382' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'distribution portal', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (19, 2, N'bd2b6dc8-09f0-43df-be4e-61f86b69e3c2', CAST(17.71 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, N'View Placements20211208170342022..pdf', N'https://www.google.com', CAST(N'2021-12-08T11:33:36.7736480' AS DateTime2), CAST(N'2021-12-08T11:33:36.7889104' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (20, 2, N'2dccc016-d6f2-45fb-908f-d9eb9644d27d', CAST(17.82 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(1.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 6, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T13:05:07.0934006' AS DateTime2), CAST(N'2021-12-08T13:05:07.1654350' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 2, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (21, 2, N'1378c2de-814c-42c8-aaf4-7e7d33e86648', CAST(17.87 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 6, 1, NULL, N'https://www.google.com', CAST(N'2021-12-08T13:09:33.1513328' AS DateTime2), CAST(N'2021-12-08T13:09:33.2574477' AS DateTime2), 1, N'ccccccccccccc', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (22, 2, N'52ef5da6-da7f-4f7e-9ed7-473232e31c96', CAST(17.76 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 0, 6, 1, N'View Placements.pdf', N'https://www.google.com', CAST(N'2021-12-08T13:26:06.9846240' AS DateTime2), CAST(N'2021-12-08T13:26:07.0045050' AS DateTime2), 1, N'dsdaasd', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, N'View Placements20211208185611292.pdf', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (23, 7, N'6123b9f8-0f5d-4b79-b5b2-d92ed8f5d6fb', CAST(14.21 AS Decimal(18, 2)), N'0x9cb1683b512562980e7c0f809660351a3b03c96c398ba5b63c41a1315f450a22', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-13T09:44:05.7529957' AS DateTime2), CAST(N'2021-12-13T09:44:05.7720700' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', N'Dev', CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (24, 2, N'1fb74420-b584-444f-b992-4d1b35c9a37d', CAST(316.48 AS Decimal(18, 2)), N'0xf47bca974781a5ea070318ec20ded3adacb1af1cac3099e7ea6ee0839046c9a6', CAST(6.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 0, 6, 2, NULL, N'https://www.google.com', CAST(N'2021-12-16T06:00:13.8975656' AS DateTime2), CAST(N'2021-12-16T06:00:13.9161930' AS DateTime2), 1, N'test', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (25, 2, N'3bb973c0-4e95-46df-b13f-9337570a4958', CAST(16.50 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(8.00 AS Decimal(18, 2)), CAST(8.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2021-12-16T06:10:38.0520256' AS DateTime2), CAST(N'2021-12-16T06:10:38.1537730' AS DateTime2), 1, N'dsdaasd', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (26, 2, N'6d7db6ba-fdbe-40ce-b80a-5a404d19a327', CAST(16.54 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2021-12-16T06:16:14.9030961' AS DateTime2), CAST(N'2021-12-16T06:16:14.9737163' AS DateTime2), 1, N'ccccccccccccc', N'dddddddddddddd', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (27, 2, N'464e0034-e22c-486e-9130-7d261c6a0565', CAST(16.55 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2021-12-16T06:18:19.9168679' AS DateTime2), CAST(N'2021-12-16T06:18:20.0340802' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (28, 2, N'1e253aa5-4310-4fb1-817c-e4d92333b5be', CAST(16.55 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2021-12-16T06:38:57.0512037' AS DateTime2), CAST(N'2021-12-16T07:56:46.2884228' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'ghfghhffh', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (29, 2, N'7ae56227-821d-48d2-bafa-b5ae50392529', CAST(16.79 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(4.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), 0, 1, 1, N'View Placements (1).pdf', N'https://www.google.com', CAST(N'2021-12-16T10:07:36.3970837' AS DateTime2), CAST(N'2021-12-16T10:07:36.4315468' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, N'View Placements (1)20211216153738848.pdf', N'0.004140457814889074', NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (30, 2, N'8bd7e2e2-65fa-4392-965c-23ee47479f5b', CAST(16.77 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-16T10:21:15.4678253' AS DateTime2), CAST(N'2021-12-20T05:52:51.6149908' AS DateTime2), 1, N'dsdaasd', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (31, 2, N'98fd3c9e-dc65-4f14-b9c9-1aa45643beed', CAST(16.66 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-21T08:14:32.8137075' AS DateTime2), CAST(N'2021-12-21T08:14:32.8864497' AS DateTime2), 1, N'cccccccccccc1', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (32, 2, N'8543cbb6-59c3-44c4-a905-6a252b4f0374', CAST(16.64 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(4.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 0, 6, 1, NULL, N'https://www.google.com', CAST(N'2021-12-21T09:33:59.5380046' AS DateTime2), CAST(N'2022-01-11T09:47:18.5894205' AS DateTime2), 1, N'clll', N'dddddddddddddd1', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', 7, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (33, 2, N'926d43b3-4373-4bc9-90f0-70af1d730561', CAST(16.68 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(3.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2021-12-21T09:40:24.4548688' AS DateTime2), CAST(N'2021-12-21T09:40:24.4567036' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', NULL, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (34, 2, N'd3d4b30d-6342-40ac-ba3e-4897d321672e', CAST(16.62 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(4.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-22T09:54:03.9488501' AS DateTime2), CAST(N'2021-12-27T12:37:39.4974400' AS DateTime2), 1, N'cccccccccccc1', N'distribution portal', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', 1, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (35, 2, N'03ac5b4b-31db-43af-bf2f-12a59fd829a1', CAST(115.66 AS Decimal(18, 2)), N'0x2f6bbca5dec0eaf83e3d985d3733fbb2cc6faf5cf41f0b69b90ce24bd553f18e', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, NULL, N'https://www.google.com', CAST(N'2021-12-28T11:35:14.7816559' AS DateTime2), CAST(N'2021-12-29T09:16:08.4168920' AS DateTime2), 2, N'jkhkghkghkhkghjk', N'distribution portal', NULL, CAST(0.00 AS Decimal(18, 2)), 2, NULL, N'0.20937171927055886', 5, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (36, 2, N'9be61a9e-e969-48b6-a527-e0eecc10e13d', CAST(15.84 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 0, 6, 1, NULL, N'https://www.google.com', CAST(N'2022-01-03T12:43:58.2311319' AS DateTime2), CAST(N'2022-01-05T06:19:33.3500547' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', 13, 0, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (1036, 2, N'ebb7f1c5-e639-4e0c-849f-a7898dad3cc9', CAST(13.19 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 1, 2, NULL, N'https://www.google.com', CAST(N'2022-01-18T08:02:07.9395744' AS DateTime2), CAST(N'2022-01-18T08:02:34.2066114' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'dddddddddddddd12', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', 6, 4, NULL)
GO
INSERT [dbo].[UserInvestments] ([Id], [UserId], [InvestmentGUID], [InvestedAmount], [InvestmentTransactionLink], [VestingLockup], [VestingTokenPercentage], [VestingId], [DistributionTypeId], [InvestmentTypeId], [SaftFile], [WebsiteLink], [CreatedOnDateTimeUTC], [UpdatedOnDateTimeUTC], [MonitoringTypeId], [CustomLink], [DistributionPortal], [Sign], [RefundAmount], [ContactId], [SaftPathSavedFileName], [InvestedQuantity], [TokenId], [NumberOfToken], [SentAddressFrom]) VALUES (1037, 2, N'931c4b59-e8bb-4349-b1a8-858cbb449c42', CAST(12.85 AS Decimal(18, 2)), N'0x485f51edd6e24d50b8b474d3051cebece4127393e90aa93dea5255ba1ea384a2', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 6, 1, NULL, N'https://www.google.com', CAST(N'2022-02-09T08:17:45.0067895' AS DateTime2), CAST(N'2022-02-09T08:17:45.0804088' AS DateTime2), 1, N'jkhkghkghkhkghjk', N'ghfghhffh', NULL, CAST(0.00 AS Decimal(18, 2)), 1, NULL, N'0.004140457814889074', 2, 2, N'0xc00eebe4e2be29679781fc5fc350057ee8132bab')
GO
SET IDENTITY_INSERT [dbo].[UserInvestments] OFF
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Calendars_TokenId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_Calendars_TokenId] ON [dbo].[Calendars]
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvestmentDynamicDistributions_InvestmentId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvestmentDynamicDistributions_InvestmentId] ON [dbo].[InvestmentDynamicDistributions]
(
	[InvestmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Monitorings_PortfolioMonitoringId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Monitorings_PortfolioMonitoringId] ON [dbo].[Monitorings]
(
	[PortfolioMonitoringId] ASC
)
WHERE ([PortfolioMonitoringId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Monitorings_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_Monitorings_UserId] ON [dbo].[Monitorings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NetworkTokens_NetworkId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_NetworkTokens_NetworkId] ON [dbo].[NetworkTokens]
(
	[NetworkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NetworkTokens_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_NetworkTokens_UserId] ON [dbo].[NetworkTokens]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OTCs_TokenId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_OTCs_TokenId] ON [dbo].[OTCs]
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortfolioMonitorings_MonitoringTypeId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_PortfolioMonitorings_MonitoringTypeId] ON [dbo].[PortfolioMonitorings]
(
	[MonitoringTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortfolioMonitorings_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_PortfolioMonitorings_UserId] ON [dbo].[PortfolioMonitorings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SharedInvestmentDetails_ContactId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_SharedInvestmentDetails_ContactId] ON [dbo].[SharedInvestmentDetails]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SharedInvestmentDetails_InvestmentId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_SharedInvestmentDetails_InvestmentId] ON [dbo].[SharedInvestmentDetails]
(
	[InvestmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserContact_UserGroupId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserContact_UserGroupId] ON [dbo].[UserContact]
(
	[UserGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserContact_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserContact_UserId] ON [dbo].[UserContact]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserContactGroupMappings_ContactId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserContactGroupMappings_ContactId] ON [dbo].[UserContactGroupMappings]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserContactGroupMappings_GroupId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserContactGroupMappings_GroupId] ON [dbo].[UserContactGroupMappings]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserGroup_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserGroup_UserId] ON [dbo].[UserGroup]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserInvestments_ContactId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserInvestments_ContactId] ON [dbo].[UserInvestments]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserInvestments_MonitoringTypeId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserInvestments_MonitoringTypeId] ON [dbo].[UserInvestments]
(
	[MonitoringTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserInvestments_TokenId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserInvestments_TokenId] ON [dbo].[UserInvestments]
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserInvestments_UserId]    Script Date: 2/17/2022 2:54:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserInvestments_UserId] ON [dbo].[UserInvestments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPortfolioSetup]
GO
ALTER TABLE [dbo].[Monitorings] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[OTCs] ADD  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[OTCs] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsArchive]
GO
ALTER TABLE [dbo].[UserInvestments] ADD  DEFAULT ((0)) FOR [MonitoringTypeId]
GO
ALTER TABLE [dbo].[UserInvestments] ADD  DEFAULT ((0.0)) FOR [RefundAmount]
GO
ALTER TABLE [dbo].[UserInvestments] ADD  DEFAULT ((0)) FOR [NumberOfToken]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_NetworkTokens_TokenId] FOREIGN KEY([TokenId])
REFERENCES [dbo].[NetworkTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_NetworkTokens_TokenId]
GO
ALTER TABLE [dbo].[InvestmentDynamicDistributions]  WITH CHECK ADD  CONSTRAINT [FK_InvestmentDynamicDistributions_UserInvestments_InvestmentId] FOREIGN KEY([InvestmentId])
REFERENCES [dbo].[UserInvestments] ([Id])
GO
ALTER TABLE [dbo].[InvestmentDynamicDistributions] CHECK CONSTRAINT [FK_InvestmentDynamicDistributions_UserInvestments_InvestmentId]
GO
ALTER TABLE [dbo].[Monitorings]  WITH CHECK ADD  CONSTRAINT [FK_Monitorings_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Monitorings] CHECK CONSTRAINT [FK_Monitorings_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Monitorings]  WITH CHECK ADD  CONSTRAINT [FK_Monitorings_PortfolioMonitorings_PortfolioMonitoringId] FOREIGN KEY([PortfolioMonitoringId])
REFERENCES [dbo].[PortfolioMonitorings] ([Id])
GO
ALTER TABLE [dbo].[Monitorings] CHECK CONSTRAINT [FK_Monitorings_PortfolioMonitorings_PortfolioMonitoringId]
GO
ALTER TABLE [dbo].[NetworkTokens]  WITH CHECK ADD  CONSTRAINT [FK_NetworkTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[NetworkTokens] CHECK CONSTRAINT [FK_NetworkTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[NetworkTokens]  WITH CHECK ADD  CONSTRAINT [FK_NetworkTokens_MonitoringTypes_NetworkId] FOREIGN KEY([NetworkId])
REFERENCES [dbo].[MonitoringTypes] ([Id])
GO
ALTER TABLE [dbo].[NetworkTokens] CHECK CONSTRAINT [FK_NetworkTokens_MonitoringTypes_NetworkId]
GO
ALTER TABLE [dbo].[OTCs]  WITH CHECK ADD  CONSTRAINT [FK_OTCs_NetworkTokens_TokenId] FOREIGN KEY([TokenId])
REFERENCES [dbo].[NetworkTokens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OTCs] CHECK CONSTRAINT [FK_OTCs_NetworkTokens_TokenId]
GO
ALTER TABLE [dbo].[PortfolioMonitorings]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioMonitorings_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PortfolioMonitorings] CHECK CONSTRAINT [FK_PortfolioMonitorings_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PortfolioMonitorings]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioMonitorings_MonitoringTypes_MonitoringTypeId] FOREIGN KEY([MonitoringTypeId])
REFERENCES [dbo].[MonitoringTypes] ([Id])
GO
ALTER TABLE [dbo].[PortfolioMonitorings] CHECK CONSTRAINT [FK_PortfolioMonitorings_MonitoringTypes_MonitoringTypeId]
GO
ALTER TABLE [dbo].[SharedInvestmentDetails]  WITH CHECK ADD  CONSTRAINT [FK_SharedInvestmentDetails_UserContact_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[UserContact] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SharedInvestmentDetails] CHECK CONSTRAINT [FK_SharedInvestmentDetails_UserContact_ContactId]
GO
ALTER TABLE [dbo].[SharedInvestmentDetails]  WITH CHECK ADD  CONSTRAINT [FK_SharedInvestmentDetails_UserInvestments_InvestmentId] FOREIGN KEY([InvestmentId])
REFERENCES [dbo].[UserInvestments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SharedInvestmentDetails] CHECK CONSTRAINT [FK_SharedInvestmentDetails_UserInvestments_InvestmentId]
GO
ALTER TABLE [dbo].[UserContact]  WITH CHECK ADD  CONSTRAINT [FK_UserContact_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserContact] CHECK CONSTRAINT [FK_UserContact_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserContact]  WITH CHECK ADD  CONSTRAINT [FK_UserContact_UserGroup_UserGroupId] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[UserContact] CHECK CONSTRAINT [FK_UserContact_UserGroup_UserGroupId]
GO
ALTER TABLE [dbo].[UserContactGroupMappings]  WITH CHECK ADD  CONSTRAINT [FK_UserContactGroupMappings_UserContact_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[UserContact] ([Id])
GO
ALTER TABLE [dbo].[UserContactGroupMappings] CHECK CONSTRAINT [FK_UserContactGroupMappings_UserContact_ContactId]
GO
ALTER TABLE [dbo].[UserContactGroupMappings]  WITH CHECK ADD  CONSTRAINT [FK_UserContactGroupMappings_UserGroup_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroup] ([Id])
GO
ALTER TABLE [dbo].[UserContactGroupMappings] CHECK CONSTRAINT [FK_UserContactGroupMappings_UserGroup_GroupId]
GO
ALTER TABLE [dbo].[UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_UserGroup_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserGroup] CHECK CONSTRAINT [FK_UserGroup_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserInvestments]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestments_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserInvestments] CHECK CONSTRAINT [FK_UserInvestments_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserInvestments]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestments_MonitoringTypes_MonitoringTypeId] FOREIGN KEY([MonitoringTypeId])
REFERENCES [dbo].[MonitoringTypes] ([Id])
GO
ALTER TABLE [dbo].[UserInvestments] CHECK CONSTRAINT [FK_UserInvestments_MonitoringTypes_MonitoringTypeId]
GO
ALTER TABLE [dbo].[UserInvestments]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestments_NetworkTokens_TokenId] FOREIGN KEY([TokenId])
REFERENCES [dbo].[NetworkTokens] ([Id])
GO
ALTER TABLE [dbo].[UserInvestments] CHECK CONSTRAINT [FK_UserInvestments_NetworkTokens_TokenId]
GO
ALTER TABLE [dbo].[UserInvestments]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestments_UserContact_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[UserContact] ([Id])
GO
ALTER TABLE [dbo].[UserInvestments] CHECK CONSTRAINT [FK_UserInvestments_UserContact_ContactId]
GO
USE [master]
GO
ALTER DATABASE [Orderly] SET  READ_WRITE 
GO
