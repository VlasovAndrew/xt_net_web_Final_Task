USE [master]
GO
/****** Object:  Database [SocialHouseNetwork]    Script Date: 3/9/2020 6:38:14 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  Table [dbo].[Channel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  Table [dbo].[Friends]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  Table [dbo].[Message]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[RoleName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 3/9/2020 6:38:15 PM ******/
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
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Login], [Password], [UserID]) VALUES (7, N'admin', 0xBE3EB9D360ECFD58B86297EF5CEDD6ACAFA67D6A30EDA0C322AB17297542B542, NULL)
INSERT [dbo].[Account] ([ID], [Login], [Password], [UserID]) VALUES (8, N'andrew', 0xB7AB116D4F5CD32682DC531E4C99A82F24D4655291EB6F494C81C0FB6DE689A9, 7)
INSERT [dbo].[Account] ([ID], [Login], [Password], [UserID]) VALUES (9, N'1234567', 0xC686E844DEF940B3B14E5D0794DDA4B4AF636775A1C2DF997B130085E29419C0, 8)
INSERT [dbo].[Account] ([ID], [Login], [Password], [UserID]) VALUES (10, N'rrrrrrrrrrr', 0x583707E1C77418354088A2586704BB27C33E2338FCA35013F9EDDE5A9E50BF64, 9)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Channel] ON 

INSERT [dbo].[Channel] ([ID], [Title], [Directed]) VALUES (1, N'Личные сообщения', 1)
INSERT [dbo].[Channel] ([ID], [Title], [Directed]) VALUES (2, N'Личные сообщения', 1)
INSERT [dbo].[Channel] ([ID], [Title], [Directed]) VALUES (3, N'Личные сообщения', 1)
INSERT [dbo].[Channel] ([ID], [Title], [Directed]) VALUES (4, N'Личные сообщения', 1)
INSERT [dbo].[Channel] ([ID], [Title], [Directed]) VALUES (5, N'Личные сообщения', 1)
SET IDENTITY_INSERT [dbo].[Channel] OFF
SET IDENTITY_INSERT [dbo].[Friends] ON 

INSERT [dbo].[Friends] ([ID], [FromUserID], [ToUserID]) VALUES (11, 9, 7)
INSERT [dbo].[Friends] ([ID], [FromUserID], [ToUserID]) VALUES (12, 9, 8)
INSERT [dbo].[Friends] ([ID], [FromUserID], [ToUserID]) VALUES (14, 7, 9)
INSERT [dbo].[Friends] ([ID], [FromUserID], [ToUserID]) VALUES (18, 7, 8)
SET IDENTITY_INSERT [dbo].[Friends] OFF
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (14, 4, 7, N'Привет, как твои дела? Все хорошо', CAST(N'2020-03-08T17:49:43.687' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (15, 4, 7, N'Все ', CAST(N'2020-03-08T17:50:01.763' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (17, 4, 7, N'Хороший текст, еще лучше', CAST(N'2020-03-08T18:05:32.997' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (19, 4, 7, N'Текст', CAST(N'2020-03-08T18:15:17.083' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (20, 4, 7, N'34', CAST(N'2020-03-08T18:15:31.700' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (22, 4, 7, N'', CAST(N'2020-03-08T18:16:32.113' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (23, 4, 7, N'аывава', CAST(N'2020-03-08T18:16:47.590' AS DateTime))
INSERT [dbo].[Message] ([ID], [ChannelID], [FromUserID], [MessageText], [SendingTime]) VALUES (25, 4, 7, N'Написать сообщение', CAST(N'2020-03-09T17:47:35.533' AS DateTime))
SET IDENTITY_INSERT [dbo].[Message] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [AccountID], [RoleName]) VALUES (1, 7, N'admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[UserChannel] ON 

INSERT [dbo].[UserChannel] ([ID], [ChannelID], [UserID]) VALUES (7, 4, 7)
INSERT [dbo].[UserChannel] ([ID], [ChannelID], [UserID]) VALUES (9, 5, 7)
INSERT [dbo].[UserChannel] ([ID], [ChannelID], [UserID]) VALUES (10, 5, 9)
SET IDENTITY_INSERT [dbo].[UserChannel] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [LastName], [Birthday], [City], [Street], [HouseNumber], [ApartmentNumber], [ProfilePhoto]) VALUES (7, N'Петр', N'Власов', CAST(N'2020-01-30' AS Date), N'Саратов', N'Саратовская', N'21', 100, N'Images\94c5aa56-391a-4e4e-93e3-28f1db15db03')
INSERT [dbo].[Users] ([ID], [Name], [LastName], [Birthday], [City], [Street], [HouseNumber], [ApartmentNumber], [ProfilePhoto]) VALUES (8, N'Александра', N'Иванова', CAST(N'2010-02-20' AS Date), N'Саратов', N'Саратовская', N'21', 0, NULL)
INSERT [dbo].[Users] ([ID], [Name], [LastName], [Birthday], [City], [Street], [HouseNumber], [ApartmentNumber], [ProfilePhoto]) VALUES (9, N'Иван', N'Петров', CAST(N'1990-01-12' AS Date), N'Саратов', N'Саратовская', N'123', 123, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Account__5E55825BD99556F2]    Script Date: 3/9/2020 6:38:15 PM ******/
ALTER TABLE [dbo].[Account] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[UserChannel]  WITH CHECK ADD FOREIGN KEY([ChannelID])
REFERENCES [dbo].[Channel] ([ID])
GO
ALTER TABLE [dbo].[UserChannel]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[AcoountExists]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAccount]
	@login NVARCHAR(20),
	@password VARBINARY(32), 
	@userID INT = NULL,
	@accountID INT OUTPUT
AS
BEGIN
	INSERT INTO Account VALUES (@login, @password, @userID);
	SET @accountID = SCOPE_IDENTITY(); 
END
GO
/****** Object:  StoredProcedure [dbo].[AddFriend]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddFriend]
	@userID INT,
	@friendID INT
AS
BEGIN
	INSERT INTO Friends VALUES (@userID, @friendID)
END
GO
/****** Object:  StoredProcedure [dbo].[AddRoleToAccount]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddRoleToAccount] 
	@login NVARCHAR(20),
	@role NVARCHAR(20)
AS
BEGIN
	DECLARE @accountID INT;
	SELECT @accountID = ID FROM Account WHERE Account.Login = @login;
	DECLARE @roleNumber INT;
	SELECT @roleNumber = COUNT(ID) FROM Roles WHERE Roles.AccountID = @accountID AND Roles.RoleName = @role;
	IF @roleNumber = 0
	BEGIN
		INSERT INTO Roles VALUES (@accountID, @role);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@Name NVARCHAR(20),
	@Lastname NVARCHAR(20),
	@Birthday DATE,
	@City NVARCHAR(20),
	@Street NVARCHAR(30),
	@HouseNumber NVARCHAR(10),
	@ApartmentNumber INT = 0,
	@ProfilePhoto NVARCHAR(80) = NULL,
	@userID INT OUTPUT
AS
BEGIN
	INSERT INTO Users VALUES
	(@Name, @Lastname, @Birthday, @City, @Street, @HouseNumber, @ApartmentNumber, @ProfilePhoto);
	SELECT @userID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AttachUserToAccount]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[AttachUserToChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CreateChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteMessage]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteMessage]
	@messageID INT
AS
BEGIN
	DELETE FROM Message WHERE Message.ID = @messageID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@userID INT
AS
BEGIN
	DELETE FROM Account WHERE Account.UserID = @userID;
	DELETE FROM Friends WHERE Friends.FromUserID = @userID OR Friends.ToUserID = @userID;
	DELETE FROM UserChannel WHERE UserChannel.UserID = @userID;
	DELETE FROM Message WHERE Message.FromUserID = @userID;
	DELETE FROM Users WHERE Users.ID  =@userID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByLogin]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllUsersID]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetMessageByID]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetMessagesIDFromChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetRolesByLogin]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRolesByLogin]
	@login NVARCHAR(20)
AS
BEGIN
	SELECT RoleName FROM Roles INNER JOIN Account 
	ON Roles.AccountID = Account.ID 
	WHERE Account.Login = @login;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserChannels]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserFriends]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserIDByLogin]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserIDByLogin]
	@login NVARCHAR(20), 
	@userID INT OUTPUT
AS
BEGIN
	SELECT @userID = Account.UserID FROM Account WHERE Account.Login = @login;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersFromChannel]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveFriend]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveFriend]
	@userID INT,
	@friendID INT
AS
BEGIN
	DELETE FROM Friends WHERE Friends.FromUserID = @userID AND Friends.ToUserID = @friendID;
END
GO
/****** Object:  StoredProcedure [dbo].[SendMessage]    Script Date: 3/9/2020 6:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateMessageText]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMessageText]
	@messageID INT,
	@text NVARCHAR(200)
AS
BEGIN
	UPDATE Message 
	SET MessageText = @text 
	WHERE Message.ID = @messageID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 3/9/2020 6:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@userID INT,
	@Name NVARCHAR(20),
	@Lastname NVARCHAR(20),
	@Birthday DATE,
	@City NVARCHAR(20),
	@Street NVARCHAR(30),
	@HouseNumber NVARCHAR(10),
	@ApartmentNumber INT = 0,
	@ProfilePhoto NVARCHAR(80) = NULL
AS
BEGIN
	UPDATE Users
	SET
		Name = @Name,
		LastName = @Lastname,
		Birthday = @Birthday,
		City = @City,
		Street = @Street,
		HouseNumber = @HouseNumber,
		ApartmentNumber = @ApartmentNumber,
		ProfilePhoto = @ProfilePhoto
	WHERE Users.ID = @userID;
END
GO
USE [master]
GO
ALTER DATABASE [SocialHouseNetwork] SET  READ_WRITE 
GO
