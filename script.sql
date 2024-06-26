USE [master]
GO
/****** Object:  Database [Assigment02Solution_StudentCode]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE DATABASE [Assigment02Solution_StudentCode]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assigment02Solution_StudentCode', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Assigment02Solution_StudentCode.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assigment02Solution_StudentCode_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Assigment02Solution_StudentCode_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assigment02Solution_StudentCode].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET RECOVERY FULL 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET  MULTI_USER 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Assigment02Solution_StudentCode', N'ON'
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET QUERY_STORE = ON
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Assigment02Solution_StudentCode]
GO
/****** Object:  User [sa]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE USER [sa] FOR LOGIN [sa] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/10/2024 11:05:27 PM ******/
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
/****** Object:  Table [dbo].[Authors]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Zip] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthors]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthors](
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[BookAuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorOrder] [int] NOT NULL,
	[RoyalityPercentage] [float] NOT NULL,
 CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[PubId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Advance] [decimal](18, 2) NOT NULL,
	[Royalty] [int] NOT NULL,
	[YtdSales] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[PublishedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PubId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleDesc] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/10/2024 11:05:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Source] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PubId] [int] NOT NULL,
	[HireDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240610132026_Initial', N'5.0.12')
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [LastName], [FirstName], [Phone], [Address], [City], [State], [Zip], [EmailAddress]) VALUES (1, N'Doe1', N'John', NULL, NULL, N'Please select a city', NULL, NULL, N'john.doe@example.com')
INSERT [dbo].[Authors] ([AuthorId], [LastName], [FirstName], [Phone], [Address], [City], [State], [Zip], [EmailAddress]) VALUES (2, N'Smith', N'Jane', N'555-5678', N'456 Oak St', N'Elsewhere', N'TX', N'73301', N'jane.smith@example.com')
INSERT [dbo].[Authors] ([AuthorId], [LastName], [FirstName], [Phone], [Address], [City], [State], [Zip], [EmailAddress]) VALUES (3, N'Brown', N'Charlie', N'555-8765', N'789 Pine St', N'Anywhere', N'FL', N'33101', N'charlie.brown@example.com')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[BookAuthors] ON 

INSERT [dbo].[BookAuthors] ([BookId], [AuthorId], [BookAuthorId], [AuthorOrder], [RoyalityPercentage]) VALUES (1, 1, 1, 1, 50)
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId], [BookAuthorId], [AuthorOrder], [RoyalityPercentage]) VALUES (2, 2, 2, 1, 60)
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId], [BookAuthorId], [AuthorOrder], [RoyalityPercentage]) VALUES (3, 3, 3, 1, 70)
SET IDENTITY_INSERT [dbo].[BookAuthors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Title], [Type], [PubId], [Price], [Advance], [Royalty], [YtdSales], [Notes], [PublishedDate]) VALUES (1, N'Learning SQL', N'Tech', 1, CAST(39.99 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 10, 5000, N'Great book for beginners', CAST(N'2022-01-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Books] ([BookId], [Title], [Type], [PubId], [Price], [Advance], [Royalty], [YtdSales], [Notes], [PublishedDate]) VALUES (2, N'Mastering Python', N'Tech', 2, CAST(49.99 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), 12, 4000, N'Comprehensive guide to Python', CAST(N'2021-05-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Books] ([BookId], [Title], [Type], [PubId], [Price], [Advance], [Royalty], [YtdSales], [Notes], [PublishedDate]) VALUES (3, N'Data Science for All', N'Tech', 3, CAST(59.99 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), 15, 3000, N'Introductory book on data science', CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PubId], [PublisherName], [City], [State], [Country]) VALUES (1, N'Pearson Education', N'Boston', N'MA', N'USA')
INSERT [dbo].[Publishers] ([PubId], [PublisherName], [City], [State], [Country]) VALUES (2, N'McGraw-Hill Education', N'New York', N'NY', N'USA')
INSERT [dbo].[Publishers] ([PubId], [PublisherName], [City], [State], [Country]) VALUES (3, N'Wiley', N'Hoboken', N'NJ', N'USA')
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleDesc]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleDesc]) VALUES (2, N'Editor')
INSERT [dbo].[Roles] ([RoleId], [RoleDesc]) VALUES (3, N'Author')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (1, N'admin@example.com', N'password123', N'Internal', N'Alice', N'M.', N'Admin1', 1, 2, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (2, N'editor@example.com', N'password123', N'Internal', N'Bob', N'L.', N'Editor', 2, 2, CAST(N'2021-02-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (3, N'author@example.com', N'password123', N'Internal', N'Charlie', N'D.', N'Author', 3, 3, CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (4, N'user1@example.com', N'password123', N'Internal', N'David', N'A.', N'User', 3, 1, CAST(N'2021-04-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (5, N'user2@example.com', N'password123', N'Internal', N'Eva', N'B.', N'User', 2, 2, CAST(N'2020-05-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (6, N'user3@example.com', N'password123', N'Internal', N'Frank', N'C.', N'User', 1, 3, CAST(N'2019-06-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (7, N'user4@example.com', N'password123', N'Internal', N'Grace', N'D.', N'User', 3, 1, CAST(N'2021-07-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (8, N'user5@example.com', N'password123', N'Internal', N'Hannah', N'E.', N'User', 2, 2, CAST(N'2020-08-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (9, N'user6@example.com', N'password123', N'Internal', N'Isaac', N'F.', N'User', 1, 3, CAST(N'2019-09-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([UserId], [EmailAddress], [Password], [Source], [FirstName], [MiddleName], [LastName], [RoleId], [PubId], [HireDate]) VALUES (10, N'user7@example.com', N'password123', N'Internal', N'Jack', N'G.', N'User', 3, 1, CAST(N'2021-10-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_BookAuthors_AuthorId]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookAuthors_AuthorId] ON [dbo].[BookAuthors]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_PubId]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_PubId] ON [dbo].[Books]
(
	[PubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_PubId]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_PubId] ON [dbo].[Users]
(
	[PubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/10/2024 11:05:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Authors_AuthorId]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Books_BookId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers_PubId] FOREIGN KEY([PubId])
REFERENCES [dbo].[Publishers] ([PubId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers_PubId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Publishers_PubId] FOREIGN KEY([PubId])
REFERENCES [dbo].[Publishers] ([PubId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Publishers_PubId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Assigment02Solution_StudentCode] SET  READ_WRITE 
GO
