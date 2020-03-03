USE [master]
GO
/****** Object:  Database [SocialHouseNetwork]    Script Date: 3/3/2020 9:35:06 PM ******/
CREATE DATABASE [SocialHouseNetwork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SocialNetwork', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SocialNetwork.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SocialNetwork_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SocialNetwork_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SocialHouseNetwork] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialHouseNetwork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialHouseNetwork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialHouseNetwork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialHouseNetwork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialHouseNetwork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialHouseNetwork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SocialHouseNetwork] SET  MULTI_USER 
GO
ALTER DATABASE [SocialHouseNetwork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialHouseNetwork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialHouseNetwork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialHouseNetwork] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SocialHouseNetwork] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SocialHouseNetwork] SET QUERY_STORE = OFF
GO
USE [SocialHouseNetwork]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [varbinary](32) NOT NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Channel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Channel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Directed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friends]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friends](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FromUserID] [int] NOT NULL,
	[ToUserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChannelID] [int] NULL,
	[FromUserID] [int] NULL,
	[MessageText] [nvarchar](200) NULL,
	[SendingTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChannel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChannelID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Birthday] [date] NOT NULL,
	[City] [nvarchar](20) NOT NULL,
	[Street] [nvarchar](30) NOT NULL,
	[HouseNumber] [nvarchar](10) NOT NULL,
	[ApartmentNumber] [int] NOT NULL,
	[ProfilePhoto] [nvarchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([FromUserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD FOREIGN KEY([ToUserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([ChannelID])
REFERENCES [dbo].[Channel] ([ID])
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD FOREIGN KEY([FromUserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserChannel]  WITH CHECK ADD FOREIGN KEY([ChannelID])
REFERENCES [dbo].[Channel] ([ID])
GO
ALTER TABLE [dbo].[UserChannel]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[AcoountExists]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AcoountExists]
	@login NVARCHAR(20),
	@exits BIT OUTPUT
AS
BEGIN
	SELECT @exits = COUNT(ID) FROM Account WHERE Account.Login = @login;
END
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAccount]
	@login NVARCHAR(20),
	@password VARBINARY(32), 
	@userID INT,
	@accountID INT OUTPUT
AS
BEGIN
	INSERT INTO Account VALUES (@login, @password, @userID);
	SET @accountID = SCOPE_IDENTITY(); 
END
GO
/****** Object:  StoredProcedure [dbo].[AttachUserToAccount]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttachUserToAccount]
	@login NVARCHAR(20), 
	@userID INT
AS
BEGIN
	UPDATE Account 
	SET 
		UserID = @userID
	WHERE
		Account.Login = @login;
END
GO
/****** Object:  StoredProcedure [dbo].[AttachUserToChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttachUserToChannel]
	@userID INT,
	@channelID INT
AS
BEGIN
	DECLARE @rowExists INT; 
	SELECT 
		@rowExists = COUNT(ID) FROM UserChannel 
	WHERE 
		UserChannel.ChannelID = @channelID AND
		UserChannel.UserID = @userID;
	IF @rowExists = 0
	BEGIN
		INSERT INTO UserChannel (ChannelID, UserID) VALUES 
			(@channelID, @userID);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CreateChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateChannel]
	@channelTitle NVARCHAR(100),
	@directed BIT,
	@channelID INT OUTPUT
AS
BEGIN
	INSERT INTO Channel (Title, Directed) VALUES (@channelTitle, @directed);
	SET @channelID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByLogin]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountByLogin]
	@login NVARCHAR(20)
AS
BEGIN
	SELECT ID, Password, UserID FROM Account WHERE Account.Login = @login
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsersID]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsersID]
AS
BEGIN
	SELECT ID FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[GetChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetChannel]
	@channelID INT
AS
BEGIN
	SELECT Title, Directed FROM Channel WHERE Channel.ID = @channelID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessageByID]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMessageByID]
	@messageID INT
AS
BEGIN
	SELECT ChannelID, FromUserID, MessageText, SendingTime FROM Message WHERE Message.ID = @messageID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessagesIDFromChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMessagesIDFromChannel]
	@channelID INT
AS
BEGIN
	SELECT ID FROM Message WHERE Message.ChannelID = @channelID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByID]
	@userID INT
AS
BEGIN
	SELECT Name, Lastname, Birthday, City, Street, HouseNumber, ApartmentNumber, ProfilePhoto FROM 
	Users WHERE Users.ID = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserChannels]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserChannels]
	@userID INT
AS
BEGIN
	SELECT ChannelID FROM UserChannel WHERE UserChannel.UserID = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserFriends]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserFriends]
	@userID INT
AS
BEGIN
	SELECT ToUserID FROM Friends WHERE FromUserID = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserIDByLogin]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserIDByLogin]
	@login NVARCHAR(20), 
	@userID INT OUTPUT
AS
BEGIN
	SELECT @userID = ID FROM Account WHERE Account.Login = @login;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersFromChannel]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsersFromChannel]
	@channelID INT
AS
BEGIN
	SELECT UserID FROM UserChannel WHERE UserChannel.ChannelID = @channelID
END
GO
/****** Object:  StoredProcedure [dbo].[SendMessage]    Script Date: 3/3/2020 9:35:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SendMessage]
	@channelID INT,
	@fromUserID INT,
	@messageText NVARCHAR(200),
	@sendingTime DATETIME,
	@messageID INT OUTPUT
AS
BEGIN
	INSERT INTO Message VALUES
	(@channelID, @fromUserID, @messageText, @sendingTime);
	SET @messageID = SCOPE_IDENTITY();
END
GO
USE [master]
GO
ALTER DATABASE [SocialHouseNetwork] SET  READ_WRITE 
GO
