USE [master]
GO
/****** Object:  Database [AdvtManagement]    Script Date: 02/04/2022 16:33:50 ******/
CREATE DATABASE [AdvtManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdvtManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AdvtManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AdvtManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AdvtManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AdvtManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdvtManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdvtManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdvtManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdvtManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdvtManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdvtManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdvtManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdvtManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdvtManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdvtManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdvtManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdvtManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdvtManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdvtManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdvtManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdvtManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdvtManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdvtManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdvtManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdvtManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdvtManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdvtManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdvtManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdvtManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [AdvtManagement] SET  MULTI_USER 
GO
ALTER DATABASE [AdvtManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdvtManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdvtManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdvtManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AdvtManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AdvtManagement]
GO
/****** Object:  Table [dbo].[ADVERTISEMENT]    Script Date: 02/04/2022 16:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADVERTISEMENT](
	[Code] [varchar](100) NOT NULL,
	[Campaign_Code] [varchar](100) NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[Content_url] [varchar](500) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[Media_Code] [varchar](100) NULL,
 CONSTRAINT [PK_ADVERTISEMENT] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ADVT_STATUS_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADVT_STATUS_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ADVT_STATUS_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AGE_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AGE_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_AGE_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CAMPAIGN]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CAMPAIGN](
	[Code] [varchar](100) NOT NULL,
	[Request_id] [bigint] NOT NULL,
	[Department_Code] [varchar](100) NOT NULL,
	[Invoice_id] [bigint] NOT NULL,
	[Status] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CAMPAIGN] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CAMPAIGN_STATUS_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CAMPAIGN_STATUS_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_CAMPAIGN_STATUS_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CITY]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CITY](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[State_Code] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CITIES] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPANY](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Address] [varchar](500) NULL,
	[City_code] [varchar](100) NULL,
	[Head_Code] [varchar](100) NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_COUNTRIES] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[City_Code] [varchar](100) NULL,
	[Industry_Code] [varchar](100) NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPARTMENT](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Company_Code] [varchar](100) NOT NULL,
	[Head_Code] [varchar](100) NULL,
 CONSTRAINT [PK_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DISCUSSION]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DISCUSSION](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Advertisement_Code] [varchar](100) NOT NULL,
	[MeetingDate] [date] NOT NULL,
	[Details] [varchar](5000) NOT NULL,
 CONSTRAINT [PK_DISCUSSION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Department_Code] [varchar](100) NULL,
 CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FEEDBACK]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FEEDBACK](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Discussion_id] [bigint] NOT NULL,
	[Details] [varchar](1000) NOT NULL,
	[Incorporated] [bit] NOT NULL,
 CONSTRAINT [PK_FEEDBACK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INDUSTRY_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INDUSTRY_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_INDUSTRY_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INVOICE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICE](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[PaidAmount] [decimal](18, 0) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_INVOICE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MEDIA_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MEDIA_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MEDIA_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REGION_TYPE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[REGION_TYPE](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_REGION_TYPE] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REQUEST]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[REQUEST](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Industry_code] [varchar](100) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
	[Budget] [decimal](18, 0) NOT NULL,
	[Company_Code] [varchar](100) NOT NULL,
	[Age_code] [varchar](100) NULL,
	[Region_Code] [varchar](100) NULL,
 CONSTRAINT [PK_REQUEST] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SPECIALIST]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SPECIALIST](
	[Employee_Code] [varchar](100) NOT NULL,
	[Department_Code] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SPECIALIST] PRIMARY KEY CLUSTERED 
(
	[Employee_Code] ASC,
	[Department_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STATE]    Script Date: 02/04/2022 16:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STATE](
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Country_Code] [varchar](100) NOT NULL,
 CONSTRAINT [PK_STATES] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ADVERTISEMENT]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENT_ADVT_STATUS_TYPE] FOREIGN KEY([Status])
REFERENCES [dbo].[ADVT_STATUS_TYPE] ([Code])
GO
ALTER TABLE [dbo].[ADVERTISEMENT] CHECK CONSTRAINT [FK_ADVERTISEMENT_ADVT_STATUS_TYPE]
GO
ALTER TABLE [dbo].[ADVERTISEMENT]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENT_CAMPAIGN] FOREIGN KEY([Campaign_Code])
REFERENCES [dbo].[CAMPAIGN] ([Code])
GO
ALTER TABLE [dbo].[ADVERTISEMENT] CHECK CONSTRAINT [FK_ADVERTISEMENT_CAMPAIGN]
GO
ALTER TABLE [dbo].[ADVERTISEMENT]  WITH CHECK ADD  CONSTRAINT [FK_ADVERTISEMENT_MEDIA_TYPE] FOREIGN KEY([Media_Code])
REFERENCES [dbo].[MEDIA_TYPE] ([Code])
GO
ALTER TABLE [dbo].[ADVERTISEMENT] CHECK CONSTRAINT [FK_ADVERTISEMENT_MEDIA_TYPE]
GO
ALTER TABLE [dbo].[CAMPAIGN]  WITH CHECK ADD  CONSTRAINT [FK_CAMPAIGN_CAMPAIGN_STATUS_TYPE] FOREIGN KEY([Status])
REFERENCES [dbo].[CAMPAIGN_STATUS_TYPE] ([Code])
GO
ALTER TABLE [dbo].[CAMPAIGN] CHECK CONSTRAINT [FK_CAMPAIGN_CAMPAIGN_STATUS_TYPE]
GO
ALTER TABLE [dbo].[CAMPAIGN]  WITH CHECK ADD  CONSTRAINT [FK_CAMPAIGN_DEPARTMENT] FOREIGN KEY([Department_Code])
REFERENCES [dbo].[DEPARTMENT] ([Code])
GO
ALTER TABLE [dbo].[CAMPAIGN] CHECK CONSTRAINT [FK_CAMPAIGN_DEPARTMENT]
GO
ALTER TABLE [dbo].[CAMPAIGN]  WITH CHECK ADD  CONSTRAINT [FK_CAMPAIGN_INVOICE] FOREIGN KEY([Invoice_id])
REFERENCES [dbo].[INVOICE] ([Id])
GO
ALTER TABLE [dbo].[CAMPAIGN] CHECK CONSTRAINT [FK_CAMPAIGN_INVOICE]
GO
ALTER TABLE [dbo].[CAMPAIGN]  WITH CHECK ADD  CONSTRAINT [FK_CAMPAIGN_REQUEST] FOREIGN KEY([Request_id])
REFERENCES [dbo].[REQUEST] ([Id])
GO
ALTER TABLE [dbo].[CAMPAIGN] CHECK CONSTRAINT [FK_CAMPAIGN_REQUEST]
GO
ALTER TABLE [dbo].[CITY]  WITH CHECK ADD  CONSTRAINT [FK_CITIES_STATES] FOREIGN KEY([State_Code])
REFERENCES [dbo].[STATE] ([Code])
GO
ALTER TABLE [dbo].[CITY] CHECK CONSTRAINT [FK_CITIES_STATES]
GO
ALTER TABLE [dbo].[COMPANY]  WITH CHECK ADD  CONSTRAINT [FK_COMPANY_CITY] FOREIGN KEY([City_code])
REFERENCES [dbo].[CITY] ([Code])
GO
ALTER TABLE [dbo].[COMPANY] CHECK CONSTRAINT [FK_COMPANY_CITY]
GO
ALTER TABLE [dbo].[COMPANY]  WITH CHECK ADD  CONSTRAINT [FK_COMPANY_EMPLOYEE] FOREIGN KEY([Head_Code])
REFERENCES [dbo].[EMPLOYEE] ([Code])
GO
ALTER TABLE [dbo].[COMPANY] CHECK CONSTRAINT [FK_COMPANY_EMPLOYEE]
GO
ALTER TABLE [dbo].[CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_CUSTOMER_CITY] FOREIGN KEY([City_Code])
REFERENCES [dbo].[CITY] ([Code])
GO
ALTER TABLE [dbo].[CUSTOMER] CHECK CONSTRAINT [FK_CUSTOMER_CITY]
GO
ALTER TABLE [dbo].[CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_CUSTOMER_INDUSTRY_TYPE] FOREIGN KEY([Industry_Code])
REFERENCES [dbo].[INDUSTRY_TYPE] ([Code])
GO
ALTER TABLE [dbo].[CUSTOMER] CHECK CONSTRAINT [FK_CUSTOMER_INDUSTRY_TYPE]
GO
ALTER TABLE [dbo].[DEPARTMENT]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTMENT_COMPANY] FOREIGN KEY([Company_Code])
REFERENCES [dbo].[COMPANY] ([Code])
GO
ALTER TABLE [dbo].[DEPARTMENT] CHECK CONSTRAINT [FK_DEPARTMENT_COMPANY]
GO
ALTER TABLE [dbo].[DEPARTMENT]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTMENT_EMPLOYEE] FOREIGN KEY([Head_Code])
REFERENCES [dbo].[EMPLOYEE] ([Code])
GO
ALTER TABLE [dbo].[DEPARTMENT] CHECK CONSTRAINT [FK_DEPARTMENT_EMPLOYEE]
GO
ALTER TABLE [dbo].[DISCUSSION]  WITH CHECK ADD  CONSTRAINT [FK_DISCUSSION_ADVERTISEMENT] FOREIGN KEY([Advertisement_Code])
REFERENCES [dbo].[ADVERTISEMENT] ([Code])
GO
ALTER TABLE [dbo].[DISCUSSION] CHECK CONSTRAINT [FK_DISCUSSION_ADVERTISEMENT]
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_EMPLOYEE_DEPARTMENT] FOREIGN KEY([Department_Code])
REFERENCES [dbo].[DEPARTMENT] ([Code])
GO
ALTER TABLE [dbo].[EMPLOYEE] CHECK CONSTRAINT [FK_EMPLOYEE_DEPARTMENT]
GO
ALTER TABLE [dbo].[FEEDBACK]  WITH CHECK ADD  CONSTRAINT [FK_FEEDBACK_DISCUSSION] FOREIGN KEY([Discussion_id])
REFERENCES [dbo].[DISCUSSION] ([ID])
GO
ALTER TABLE [dbo].[FEEDBACK] CHECK CONSTRAINT [FK_FEEDBACK_DISCUSSION]
GO
ALTER TABLE [dbo].[REQUEST]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_AGE_TYPE] FOREIGN KEY([Age_code])
REFERENCES [dbo].[AGE_TYPE] ([Code])
GO
ALTER TABLE [dbo].[REQUEST] CHECK CONSTRAINT [FK_REQUEST_AGE_TYPE]
GO
ALTER TABLE [dbo].[REQUEST]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_COMPANY] FOREIGN KEY([Company_Code])
REFERENCES [dbo].[COMPANY] ([Code])
GO
ALTER TABLE [dbo].[REQUEST] CHECK CONSTRAINT [FK_REQUEST_COMPANY]
GO
ALTER TABLE [dbo].[REQUEST]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_INDUSTRY_TYPE] FOREIGN KEY([Industry_code])
REFERENCES [dbo].[INDUSTRY_TYPE] ([Code])
GO
ALTER TABLE [dbo].[REQUEST] CHECK CONSTRAINT [FK_REQUEST_INDUSTRY_TYPE]
GO
ALTER TABLE [dbo].[REQUEST]  WITH CHECK ADD  CONSTRAINT [FK_REQUEST_REGION_TYPE] FOREIGN KEY([Region_Code])
REFERENCES [dbo].[REGION_TYPE] ([Code])
GO
ALTER TABLE [dbo].[REQUEST] CHECK CONSTRAINT [FK_REQUEST_REGION_TYPE]
GO
ALTER TABLE [dbo].[SPECIALIST]  WITH CHECK ADD  CONSTRAINT [FK_SPECIALIST_DEPARTMENT] FOREIGN KEY([Department_Code])
REFERENCES [dbo].[DEPARTMENT] ([Code])
GO
ALTER TABLE [dbo].[SPECIALIST] CHECK CONSTRAINT [FK_SPECIALIST_DEPARTMENT]
GO
ALTER TABLE [dbo].[SPECIALIST]  WITH CHECK ADD  CONSTRAINT [FK_SPECIALIST_EMPLOYEE] FOREIGN KEY([Employee_Code])
REFERENCES [dbo].[EMPLOYEE] ([Code])
GO
ALTER TABLE [dbo].[SPECIALIST] CHECK CONSTRAINT [FK_SPECIALIST_EMPLOYEE]
GO
ALTER TABLE [dbo].[STATE]  WITH CHECK ADD  CONSTRAINT [FK_STATES_COUNTRIES] FOREIGN KEY([Country_Code])
REFERENCES [dbo].[COUNTRY] ([Code])
GO
ALTER TABLE [dbo].[STATE] CHECK CONSTRAINT [FK_STATES_COUNTRIES]
GO
USE [master]
GO
ALTER DATABASE [AdvtManagement] SET  READ_WRITE 
GO
