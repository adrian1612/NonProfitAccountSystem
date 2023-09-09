USE [master]
GO
/****** Object:  Database [dbNonProfitAccount]    Script Date: 10/09/2023 6:42:58 am ******/
CREATE DATABASE [dbNonProfitAccount]
GO
USE [dbNonProfitAccount]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Accounts_Proc]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tbl_Accounts_Proc]
@Type VARCHAR(50),
@Search VARCHAR(max) = null,
@ID int = null,
@AccountName varchar(5000) = null,
@AccountBday datetime = null,
@MedicaidDate datetime = null,
@AddressLine varchar(5000) = null,
@City varchar(5000) = null,
@State varchar(5000) = null,
@Zipcode varchar(5000) = null,
@PhoneHome varchar(5000) = null,
@Language varchar(5000) = null,
@HouseHoldIndicator varchar(5000) = null,
@Subscriber int = null,
@CountryCode varchar(5000) = null,
@NonProfitStaff varchar(5000) = null,
@CallAttemDateTime1 datetime = null,
@Comment1 varchar(5000) = null,
@CallAttemDateTime2 datetime = null,
@Comment2 varchar(5000) = null,
@CallAttemDateTime3 datetime = null,
@Comment3 varchar(5000) = null,
@HomeVisitAttempDate datetime = null,
@HomeVisitComment varchar(5000) = null,
@Unreachable bit = null,
@ACA bit = null,
@PersonalNotes varchar(5000) = null,
@Encoder int = null,
@Timestamp datetime = null
AS
BEGIN
IF @Type = 'Create'
BEGIN
INSERT INTO [tbl_Accounts]
([AccountName],[AccountBday],[MedicaidDate],[AddressLine],[City],[State],[Zipcode],[PhoneHome],[Language],[HouseHoldIndicator],[Subscriber],[CountryCode],[NonProfitStaff],[CallAttemDateTime1],[Comment1],[CallAttemDateTime2],[Comment2],[CallAttemDateTime3],[Comment3],[HomeVisitAttempDate],[HomeVisitComment],[Unreachable],[ACA],[PersonalNotes],[Encoder])
VALUES
(@AccountName,@AccountBday,@MedicaidDate,@AddressLine,@City,@State,@Zipcode,@PhoneHome,@Language,@HouseHoldIndicator,@Subscriber,@CountryCode,@NonProfitStaff,@CallAttemDateTime1,@Comment1,@CallAttemDateTime2,@Comment2,@CallAttemDateTime3,@Comment3,@HomeVisitAttempDate,@HomeVisitComment,@Unreachable,@ACA,@PersonalNotes,@Encoder)
INSERT INTO [tbl_Accounts_Log] ([itemID],[Description],[Encoder]) VALUES (IDENT_CURRENT('tbl_Accounts'), 'Added New Record', @Encoder)
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Update'
BEGIN
DECLARE @tempAccountName varchar(5000) = null,
@tempAccountBday datetime = null,
@tempMedicaidDate datetime = null,
@tempAddressLine varchar(5000) = null,
@tempCity varchar(5000) = null,
@tempState varchar(5000) = null,
@tempZipcode varchar(5000) = null,
@tempPhoneHome varchar(5000) = null,
@tempLanguage varchar(5000) = null,
@tempHouseHoldIndicator varchar(5000) = null,
@tempSubscriber int = null,
@tempCountryCode varchar(5000) = null,
@tempNonProfitStaff varchar(5000) = null,
@tempCallAttemDateTime1 datetime = null,
@tempComment1 varchar(5000) = null,
@tempCallAttemDateTime2 datetime = null,
@tempComment2 varchar(5000) = null,
@tempCallAttemDateTime3 datetime = null,
@tempComment3 varchar(5000) = null,
@tempHomeVisitAttempDate datetime = null,
@tempHomeVisitComment varchar(5000) = null,
@tempUnreachable bit = null,
@tempACA bit = null,
@tempPersonalNotes varchar(5000) = null,
@tempEncoder int = null,
@text VARCHAR(MAX) = ''

SELECT @tempAccountName = [AccountName],@tempAccountBday = [AccountBday], @MedicaidDate = [MedicaidDate],@tempAddressLine = [AddressLine],@tempCity = [City],@tempState = [State],@tempZipcode = [Zipcode],@tempPhoneHome = [PhoneHome],@tempLanguage = [Language],@tempHouseHoldIndicator = [HouseHoldIndicator],@tempSubscriber = [Subscriber],@tempCountryCode = [CountryCode],@tempNonProfitStaff = [NonProfitStaff],@tempCallAttemDateTime1 = [CallAttemDateTime1],@tempComment1 = [Comment1],@tempCallAttemDateTime2 = [CallAttemDateTime2],@tempComment2 = [Comment2],@tempCallAttemDateTime3 = [CallAttemDateTime3],@tempComment3 = [Comment3],@tempHomeVisitAttempDate = [HomeVisitAttempDate],@tempHomeVisitComment = [HomeVisitComment],@tempUnreachable = [Unreachable],@tempACA = [ACA],@tempPersonalNotes = [PersonalNotes],@tempEncoder = [Encoder] FROM tbl_Accounts WHERE ID = @ID

IF @AccountName != @tempAccountName --AccountName
BEGIN
SET @text += CONCAT('Updated AccountName From: ', @tempAccountName, ' To: ', @AccountName, CHAR(13))
END
IF @AccountBday != @tempAccountBday --AccountBday
BEGIN
SET @text += CONCAT('Updated AccountBday From: ', @tempAccountBday, ' To: ', @AccountBday, CHAR(13))
END
IF @AccountBday != @tempAccountBday --medicaid
BEGIN
SET @text += CONCAT('Updated medicaid From: ', @tempMedicaidDate, ' To: ', @MedicaidDate, CHAR(13))
END
IF @AddressLine != @tempAddressLine --AddressLine
BEGIN
SET @text += CONCAT('Updated AddressLine From: ', @tempAddressLine, ' To: ', @AddressLine, CHAR(13))
END
IF @City != @tempCity --City
BEGIN
SET @text += CONCAT('Updated City From: ', @tempCity, ' To: ', @City, CHAR(13))
END
IF @State != @tempState --State
BEGIN
SET @text += CONCAT('Updated State From: ', @tempState, ' To: ', @State, CHAR(13))
END
IF @Zipcode != @tempZipcode --Zipcode
BEGIN
SET @text += CONCAT('Updated Zipcode From: ', @tempZipcode, ' To: ', @Zipcode, CHAR(13))
END
IF @PhoneHome != @tempPhoneHome --PhoneHome
BEGIN
SET @text += CONCAT('Updated PhoneHome From: ', @tempPhoneHome, ' To: ', @PhoneHome, CHAR(13))
END
IF @Language != @tempLanguage --Language
BEGIN
SET @text += CONCAT('Updated Language From: ', @tempLanguage, ' To: ', @Language, CHAR(13))
END
IF @HouseHoldIndicator != @tempHouseHoldIndicator --HouseHoldIndicator
BEGIN
SET @text += CONCAT('Updated HouseHoldIndicator From: ', @tempHouseHoldIndicator, ' To: ', @HouseHoldIndicator, CHAR(13))
END
IF @Subscriber != @tempSubscriber --Subscriber
BEGIN
SET @text += CONCAT('Updated Subscriber From: ', @tempSubscriber, ' To: ', @Subscriber, CHAR(13))
END
IF @CountryCode != @tempCountryCode --CountryCode
BEGIN
SET @text += CONCAT('Updated CountryCode From: ', @tempCountryCode, ' To: ', @CountryCode, CHAR(13))
END
IF @NonProfitStaff != @tempNonProfitStaff --NonProfitStaff
BEGIN
SET @text += CONCAT('Updated NonProfitStaff From: ', @tempNonProfitStaff, ' To: ', @NonProfitStaff, CHAR(13))
END
IF @CallAttemDateTime1 != @tempCallAttemDateTime1 --CallAttemDateTime1
BEGIN
SET @text += CONCAT('Updated CallAttemDateTime1 From: ', @tempCallAttemDateTime1, ' To: ', @CallAttemDateTime1, CHAR(13))
END
IF @Comment1 != @tempComment1 --Comment1
BEGIN
SET @text += CONCAT('Updated Comment1 From: ', @tempComment1, ' To: ', @Comment1, CHAR(13))
END
IF @CallAttemDateTime2 != @tempCallAttemDateTime2 --CallAttemDateTime2
BEGIN
SET @text += CONCAT('Updated CallAttemDateTime2 From: ', @tempCallAttemDateTime2, ' To: ', @CallAttemDateTime2, CHAR(13))
END
IF @Comment2 != @tempComment2 --Comment2
BEGIN
SET @text += CONCAT('Updated Comment2 From: ', @tempComment2, ' To: ', @Comment2, CHAR(13))
END
IF @CallAttemDateTime3 != @tempCallAttemDateTime3 --CallAttemDateTime3
BEGIN
SET @text += CONCAT('Updated CallAttemDateTime3 From: ', @tempCallAttemDateTime3, ' To: ', @CallAttemDateTime3, CHAR(13))
END
IF @Comment3 != @tempComment3 --Comment3
BEGIN
SET @text += CONCAT('Updated Comment3 From: ', @tempComment3, ' To: ', @Comment3, CHAR(13))
END
IF @HomeVisitAttempDate != @tempHomeVisitAttempDate --HomeVisitAttempDate
BEGIN
SET @text += CONCAT('Updated HomeVisitAttempDate From: ', @tempHomeVisitAttempDate, ' To: ', @HomeVisitAttempDate, CHAR(13))
END
IF @HomeVisitComment != @tempHomeVisitComment --HomeVisitComment
BEGIN
SET @text += CONCAT('Updated HomeVisitComment From: ', @tempHomeVisitComment, ' To: ', @HomeVisitComment, CHAR(13))
END
IF @Unreachable != @tempUnreachable --Unreachable
BEGIN
SET @text += CONCAT('Updated Unreachable From: ', @tempUnreachable, ' To: ', @Unreachable, CHAR(13))
END
IF @ACA != @tempACA --ACA
BEGIN
SET @text += CONCAT('Updated ACA From: ', @tempACA, ' To: ', @ACA, CHAR(13))
END
IF @PersonalNotes != @tempPersonalNotes --PersonalNotes
BEGIN
SET @text += CONCAT('Updated PersonalNotes From: ', @tempPersonalNotes, ' To: ', @PersonalNotes, CHAR(13))
END
IF @Encoder != @tempEncoder --Encoder
BEGIN
SET @text += CONCAT('Updated Encoder From: ', @tempEncoder, ' To: ', @Encoder, CHAR(13))
END
IF @text != ''
BEGIN
INSERT INTO [tbl_Accounts_Log] ([itemID], [Description], [Encoder]) VALUES (@ID, SUBSTRING(@text, 1, LEN(@text) - 1), @Encoder)
END
UPDATE [tbl_Accounts] SET [AccountName] = @AccountName
,[AccountBday] = @AccountBday
,[MedicaidDate] = @MedicaidDate
,[AddressLine] = @AddressLine
,[City] = @City
,[State] = @State
,[Zipcode] = @Zipcode
,[PhoneHome] = @PhoneHome
,[Language] = @Language
,[HouseHoldIndicator] = @HouseHoldIndicator
,[Subscriber] = @Subscriber
,[CountryCode] = @CountryCode
,[NonProfitStaff] = @NonProfitStaff
,[CallAttemDateTime1] = @CallAttemDateTime1
,[Comment1] = @Comment1
,[CallAttemDateTime2] = @CallAttemDateTime2
,[Comment2] = @Comment2
,[CallAttemDateTime3] = @CallAttemDateTime3
,[Comment3] = @Comment3
,[HomeVisitAttempDate] = @HomeVisitAttempDate
,[HomeVisitComment] = @HomeVisitComment
,[Unreachable] = @Unreachable
,[ACA] = @ACA
,[PersonalNotes] = @PersonalNotes
,[Encoder] = @Encoder WHERE [ID] = @ID
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Search'
BEGIN
SELECT * FROM [vw_Accounts] 
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Find'
BEGIN
SELECT * FROM [vw_Accounts] WHERE  ID = @ID
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------

END


GO
/****** Object:  StoredProcedure [dbo].[tbl_User_Proc]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tbl_User_Proc]
@Type VARCHAR(50),
@Search VARCHAR(max) = null,
@ID int = null,
@Username varchar(max) = null,
@Password varchar(max) = null,
@Encoder int = null,
@Timestamp datetime = null
AS
BEGIN
IF @Type = 'Create'
BEGIN
INSERT INTO [tbl_User]
([Username],[Password])
VALUES
(@Username,@Password)

END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Update'
BEGIN
UPDATE [tbl_User] SET [Password] = @Password
,[Encoder] = @Encoder WHERE [ID] = @ID
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Search'
BEGIN
SELECT * FROM [tbl_User] 
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Find'
BEGIN
SELECT * FROM [tbl_User] WHERE  ID = @ID
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------
IF @Type = 'Login'
BEGIN
SELECT * FROM [tbl_User] WHERE HASHBYTES('MD5',Username) = HASHBYTES('MD5',@Username) AND HASHBYTES('MD5',[Password]) = HASHBYTES('MD5',@Password)
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------

END


GO
/****** Object:  UserDefinedFunction [dbo].[GetSubscriber]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetSubscriber](@ID INT)
RETURNS VARCHAR(5000)
AS
BEGIN
	RETURN (SELECT Subscriber FROM tbl_Subscriber WHERE ID = @ID)
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetUserName]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUserName](@ID INT)
RETURNS VARCHAR(5000)
AS
BEGIN
	RETURN (SELECT Username FROm tbl_User WHERE ID = @ID)
END
GO
/****** Object:  Table [dbo].[tbl_Accounts]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](5000) NULL,
	[AccountBday] [datetime] NULL,
	[MedicaidDate] [datetime] NULL,
	[AddressLine] [varchar](5000) NULL,
	[City] [varchar](5000) NULL,
	[State] [varchar](5000) NULL,
	[Zipcode] [varchar](5000) NULL,
	[PhoneHome] [varchar](5000) NULL,
	[Language] [varchar](5000) NULL,
	[HouseHoldIndicator] [varchar](5000) NULL,
	[Subscriber] [int] NULL,
	[CountryCode] [varchar](5000) NULL,
	[NonProfitStaff] [varchar](5000) NULL,
	[CallAttemDateTime1] [datetime] NULL,
	[Comment1] [varchar](5000) NULL,
	[CallAttemDateTime2] [datetime] NULL,
	[Comment2] [varchar](5000) NULL,
	[CallAttemDateTime3] [datetime] NULL,
	[Comment3] [varchar](5000) NULL,
	[HomeVisitAttempDate] [datetime] NULL,
	[HomeVisitComment] [varchar](5000) NULL,
	[Unreachable] [bit] NULL,
	[ACA] [bit] NULL,
	[PersonalNotes] [varchar](5000) NULL,
	[Encoder] [int] NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK__tbl_Acco__3214EC279307EC6D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Accounts_Log]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Accounts_Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[itemID] [int] NULL,
	[Description] [varchar](max) NULL,
	[Encoder] [int] NULL,
	[Timestamp] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Subscriber]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Subscriber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Subscriber] [varchar](max) NULL,
	[Encoder] [int] NULL,
	[Timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Encoder] [int] NULL,
	[Timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vw_Accounts]    Script Date: 10/09/2023 6:42:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Accounts]
AS
SELECT [ID]
      ,[AccountName]
      ,[AccountBday]
      ,[MedicaidDate]
      ,[AddressLine]
      ,[City]
      ,[State]
      ,[Zipcode]
      ,[PhoneHome]
      ,[Language]
      ,[HouseHoldIndicator]
      ,[Subscriber]
	  ,[SubscriberName] = dbo.GetSubscriber([Subscriber])
      ,[CountryCode]
      ,[NonProfitStaff]
	  ,[NonProfitStaffName] = dbo.GetUserName([NonProfitStaff])
      ,[CallAttemDateTime1]
      ,[Comment1]
      ,[CallAttemDateTime2]
      ,[Comment2]
      ,[CallAttemDateTime3]
      ,[Comment3]
      ,[HomeVisitAttempDate]
      ,[HomeVisitComment]
      ,[Unreachable]
      ,[ACA]
      ,[PersonalNotes]
      ,[Encoder]
      ,[Timestamp]
  FROM [tbl_Accounts]

GO
ALTER TABLE [dbo].[tbl_Accounts] ADD  CONSTRAINT [DF__tbl_Accou__Times__108B795B]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[tbl_Accounts_Log] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[tbl_Subscriber] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[tbl_User] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
USE [master]
GO
ALTER DATABASE [dbNonProfitAccount] SET  READ_WRITE 
GO
