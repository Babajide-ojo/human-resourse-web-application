USE [master]
GO
/****** Object:  Database [RoleBasedAuth]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE DATABASE [RoleBasedAuth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoleBasedAuth', FILENAME = N'C:\Users\Oluwaseun\RoleBasedAuth.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RoleBasedAuth_log', FILENAME = N'C:\Users\Oluwaseun\RoleBasedAuth_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoleBasedAuth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoleBasedAuth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RoleBasedAuth] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RoleBasedAuth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoleBasedAuth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoleBasedAuth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RoleBasedAuth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoleBasedAuth] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RoleBasedAuth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RoleBasedAuth] SET  MULTI_USER 
GO
ALTER DATABASE [RoleBasedAuth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoleBasedAuth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoleBasedAuth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoleBasedAuth] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [RoleBasedAuth]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/2/2020 8:33:34 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyBranch]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[LocationName] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CompanyBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyInformation]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[OrganizationName] [nvarchar](max) NULL,
	[TaxId] [int] NOT NULL,
	[NumberOfEmployees] [int] NOT NULL,
	[RegistrationNumber] [nvarchar](max) NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Fax] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[PostalCode] [int] NOT NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Education]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employ]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Photograph] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[MaritalStatus] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[IdentityUserEmail] [nvarchar](max) NULL,
	[EmployeeId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Photograph] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[MaritalStatus] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeContactDetails]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeContactDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Mobile] [bigint] NOT NULL,
	[WorkTelephone] [bigint] NOT NULL,
	[Fax] [bigint] NOT NULL,
	[WorkEmail] [nvarchar](max) NULL,
	[OtherEmail] [nvarchar](max) NULL,
	[CountryId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City_or_state_or_province] [nvarchar](max) NULL,
	[PostalCode] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeContactDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeDependants]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDependants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Relationship] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeDependants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeEducations]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeEducations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Institute] [nvarchar](max) NULL,
	[Major] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[GPA] [decimal](18, 2) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeEducations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeEmergencyContacts]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeEmergencyContacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[HomeTelephone] [bigint] NOT NULL,
	[Mobile] [bigint] NOT NULL,
	[WorkTelephone] [bigint] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Relationship] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeEmergencyContacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeImmigrations]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeImmigrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[DocumentTypeId] [int] NOT NULL,
	[IssuedDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
	[DocumentNumber] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[EligibleReviewDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeImmigrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeJobs]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeJobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[JobTitlesId] [int] NOT NULL,
	[EmployementstatusId] [int] NULL,
	[EmploymentStatusId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[JobCategoriesId] [int] NOT NULL,
	[CompanyBranchId] [int] NOT NULL,
	[JoinedDate] [datetime2](7) NOT NULL,
	[ContractStartDate] [datetime2](7) NOT NULL,
	[ContractEndDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeJobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLanguages]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLanguages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
	[Competency] [nvarchar](max) NULL,
	[Fluency] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeLanguages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLicenses]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLicenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseId] [int] NOT NULL,
	[LicenseNumber] [int] NOT NULL,
	[IssuedDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeLicenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeMemberships]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeMemberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[MembershipId] [int] NOT NULL,
	[ReportingMethodId] [int] NULL,
	[ReportMethodId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeMemberships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSalaries]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSalaries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[payGradesId] [int] NULL,
	[PayGradeId] [int] NOT NULL,
	[PayFrequencyId] [int] NOT NULL,
	[Currency] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeSalaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSkills]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillId] [int] NOT NULL,
	[YearsOfExperience] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSubordinates]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSubordinates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ReportingMethod] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeSubordinates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSupervisors]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSupervisors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ReportingMethod] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeSupervisors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeWorkExperiences]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeWorkExperiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[JobTitle] [nvarchar](max) NULL,
	[From] [datetime2](7) NOT NULL,
	[To] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[EmployeeId] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeWorkExperiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployementStatus]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployementStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployementStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobCategories]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobTitles]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Membership]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Nationalities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayFrequency]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayFrequency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_PayFrequency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayGrades]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayGrades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Currency] [nvarchar](max) NULL,
	[MinimumSalary] [decimal](18, 2) NOT NULL,
	[MaximumSalary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PayGrades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relationship]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relationship](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Relationship] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportingMethod]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportingMethod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReportingMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skills]    Script Date: 9/2/2020 8:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeContactDetails_CountryId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeContactDetails_CountryId] ON [dbo].[EmployeeContactDetails]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeImmigrations_CountryId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeImmigrations_CountryId] ON [dbo].[EmployeeImmigrations]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeImmigrations_DocumentTypeId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeImmigrations_DocumentTypeId] ON [dbo].[EmployeeImmigrations]
(
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeJobs_CompanyBranchId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeJobs_CompanyBranchId] ON [dbo].[EmployeeJobs]
(
	[CompanyBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeJobs_DepartmentId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeJobs_DepartmentId] ON [dbo].[EmployeeJobs]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeJobs_EmployementstatusId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeJobs_EmployementstatusId] ON [dbo].[EmployeeJobs]
(
	[EmployementstatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeJobs_JobCategoriesId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeJobs_JobCategoriesId] ON [dbo].[EmployeeJobs]
(
	[JobCategoriesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeJobs_JobTitlesId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeJobs_JobTitlesId] ON [dbo].[EmployeeJobs]
(
	[JobTitlesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeMemberships_MembershipId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeMemberships_MembershipId] ON [dbo].[EmployeeMemberships]
(
	[MembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeMemberships_ReportingMethodId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeMemberships_ReportingMethodId] ON [dbo].[EmployeeMemberships]
(
	[ReportingMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeSalaries_PayFrequencyId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeSalaries_PayFrequencyId] ON [dbo].[EmployeeSalaries]
(
	[PayFrequencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeSalaries_payGradesId]    Script Date: 9/2/2020 8:33:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeSalaries_payGradesId] ON [dbo].[EmployeeSalaries]
(
	[payGradesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[EmployeeContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeContactDetails_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeContactDetails] CHECK CONSTRAINT [FK_EmployeeContactDetails_Country_CountryId]
GO
ALTER TABLE [dbo].[EmployeeImmigrations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeImmigrations_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeImmigrations] CHECK CONSTRAINT [FK_EmployeeImmigrations_Country_CountryId]
GO
ALTER TABLE [dbo].[EmployeeImmigrations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeImmigrations_DocumentType_DocumentTypeId] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeImmigrations] CHECK CONSTRAINT [FK_EmployeeImmigrations_DocumentType_DocumentTypeId]
GO
ALTER TABLE [dbo].[EmployeeJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeJobs_CompanyBranch_CompanyBranchId] FOREIGN KEY([CompanyBranchId])
REFERENCES [dbo].[CompanyBranch] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeJobs] CHECK CONSTRAINT [FK_EmployeeJobs_CompanyBranch_CompanyBranchId]
GO
ALTER TABLE [dbo].[EmployeeJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeJobs_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeJobs] CHECK CONSTRAINT [FK_EmployeeJobs_Department_DepartmentId]
GO
ALTER TABLE [dbo].[EmployeeJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeJobs_EmployementStatus_EmployementstatusId] FOREIGN KEY([EmployementstatusId])
REFERENCES [dbo].[EmployementStatus] ([Id])
GO
ALTER TABLE [dbo].[EmployeeJobs] CHECK CONSTRAINT [FK_EmployeeJobs_EmployementStatus_EmployementstatusId]
GO
ALTER TABLE [dbo].[EmployeeJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeJobs_JobCategories_JobCategoriesId] FOREIGN KEY([JobCategoriesId])
REFERENCES [dbo].[JobCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeJobs] CHECK CONSTRAINT [FK_EmployeeJobs_JobCategories_JobCategoriesId]
GO
ALTER TABLE [dbo].[EmployeeJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeJobs_JobTitles_JobTitlesId] FOREIGN KEY([JobTitlesId])
REFERENCES [dbo].[JobTitles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeJobs] CHECK CONSTRAINT [FK_EmployeeJobs_JobTitles_JobTitlesId]
GO
ALTER TABLE [dbo].[EmployeeMemberships]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeMemberships_Membership_MembershipId] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Membership] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeMemberships] CHECK CONSTRAINT [FK_EmployeeMemberships_Membership_MembershipId]
GO
ALTER TABLE [dbo].[EmployeeMemberships]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeMemberships_ReportingMethod_ReportingMethodId] FOREIGN KEY([ReportingMethodId])
REFERENCES [dbo].[ReportingMethod] ([Id])
GO
ALTER TABLE [dbo].[EmployeeMemberships] CHECK CONSTRAINT [FK_EmployeeMemberships_ReportingMethod_ReportingMethodId]
GO
ALTER TABLE [dbo].[EmployeeSalaries]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSalaries_PayFrequency_PayFrequencyId] FOREIGN KEY([PayFrequencyId])
REFERENCES [dbo].[PayFrequency] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeSalaries] CHECK CONSTRAINT [FK_EmployeeSalaries_PayFrequency_PayFrequencyId]
GO
ALTER TABLE [dbo].[EmployeeSalaries]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSalaries_PayGrades_payGradesId] FOREIGN KEY([payGradesId])
REFERENCES [dbo].[PayGrades] ([Id])
GO
ALTER TABLE [dbo].[EmployeeSalaries] CHECK CONSTRAINT [FK_EmployeeSalaries_PayGrades_payGradesId]
GO
USE [master]
GO
ALTER DATABASE [RoleBasedAuth] SET  READ_WRITE 
GO
