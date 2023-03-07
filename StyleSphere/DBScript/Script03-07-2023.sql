USE [master]
GO
/****** Object:  Database [db_StyleSphere]    Script Date: 3/7/2023 9:51:24 AM ******/
CREATE DATABASE [db_StyleSphere]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_StyleSphere', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_StyleSphere.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_StyleSphere_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_StyleSphere_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_StyleSphere] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_StyleSphere].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_StyleSphere] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_StyleSphere] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_StyleSphere] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_StyleSphere] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_StyleSphere] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_StyleSphere] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_StyleSphere] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_StyleSphere] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_StyleSphere] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_StyleSphere] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_StyleSphere] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_StyleSphere] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_StyleSphere] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_StyleSphere] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_StyleSphere] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_StyleSphere] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_StyleSphere] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_StyleSphere] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_StyleSphere] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_StyleSphere] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_StyleSphere] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_StyleSphere] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_StyleSphere] SET RECOVERY FULL 
GO
ALTER DATABASE [db_StyleSphere] SET  MULTI_USER 
GO
ALTER DATABASE [db_StyleSphere] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_StyleSphere] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_StyleSphere] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_StyleSphere] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_StyleSphere] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_StyleSphere] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_StyleSphere', N'ON'
GO
ALTER DATABASE [db_StyleSphere] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_StyleSphere] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_StyleSphere]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/7/2023 9:51:24 AM ******/
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
/****** Object:  Table [dbo].[tbl_Categories]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](150) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
	[ShowOnTop] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ColorMaster]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ColorMaster](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_ColorMaster] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ContactNo] [varchar](15) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Favorites]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Favorites](
	[FavoriteID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Favorites] PRIMARY KEY CLUSTERED 
(
	[FavoriteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderData]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderData](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ShippingAddress] [varchar](250) NOT NULL,
	[BillingAddress] [varchar](250) NOT NULL,
	[TrackingID] [varchar](50) NOT NULL,
	[NetAmount] [numeric](10, 2) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_OrderData] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderDetail]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderDetail](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductMappingID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[Total] [numeric](10, 2) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Product]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[MfgDate] [date] NOT NULL,
	[ThumbnailImage] [varchar](max) NOT NULL,
	[Image1] [varchar](max) NOT NULL,
	[Image2] [varchar](max) NULL,
	[Image3] [varchar](max) NULL,
	[Description] [varchar](max) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ProductMapping]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProductMapping](
	[ProductMappingID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[SizeID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_ProductMapping] PRIMARY KEY CLUSTERED 
(
	[ProductMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Rating]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Rating](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Rating] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SizeMaster]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SizeMaster](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[EUSize] [int] NOT NULL,
	[USSize] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_SizeMaster] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SubCategories]    Script Date: 3/7/2023 9:51:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SubCategories](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryName] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_SubCategories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Categories] ON 
GO
INSERT [dbo].[tbl_Categories] ([CategoryID], [CategoryName], [Description], [ActiveStatus], [ShowOnTop]) VALUES (1, N'Shoes', N'Men', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_Categories] OFF
GO
ALTER TABLE [dbo].[tbl_Categories] ADD  CONSTRAINT [DF_tbl_Categories_ShowOnTop]  DEFAULT ((0)) FOR [ShowOnTop]
GO
ALTER TABLE [dbo].[tbl_Favorites]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Favorites_tbl_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tbl_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[tbl_Favorites] CHECK CONSTRAINT [FK_tbl_Favorites_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Favorites]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Favorites_tbl_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tbl_Product] ([ProductID])
GO
ALTER TABLE [dbo].[tbl_Favorites] CHECK CONSTRAINT [FK_tbl_Favorites_tbl_Product]
GO
ALTER TABLE [dbo].[tbl_OrderData]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OrderData_tbl_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tbl_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[tbl_OrderData] CHECK CONSTRAINT [FK_tbl_OrderData_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OrderDetail_tbl_OrderData] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tbl_OrderData] ([OrderID])
GO
ALTER TABLE [dbo].[tbl_OrderDetail] CHECK CONSTRAINT [FK_tbl_OrderDetail_tbl_OrderData]
GO
ALTER TABLE [dbo].[tbl_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OrderDetail_tbl_ProductMapping] FOREIGN KEY([ProductMappingID])
REFERENCES [dbo].[tbl_ProductMapping] ([ProductMappingID])
GO
ALTER TABLE [dbo].[tbl_OrderDetail] CHECK CONSTRAINT [FK_tbl_OrderDetail_tbl_ProductMapping]
GO
ALTER TABLE [dbo].[tbl_Product]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Product_tbl_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tbl_Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[tbl_Product] CHECK CONSTRAINT [FK_tbl_Product_tbl_Categories]
GO
ALTER TABLE [dbo].[tbl_Product]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Product_tbl_SubCategories] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[tbl_SubCategories] ([SubCategoryID])
GO
ALTER TABLE [dbo].[tbl_Product] CHECK CONSTRAINT [FK_tbl_Product_tbl_SubCategories]
GO
ALTER TABLE [dbo].[tbl_ProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ProductMapping_tbl_ColorMaster] FOREIGN KEY([ColorID])
REFERENCES [dbo].[tbl_ColorMaster] ([ColorID])
GO
ALTER TABLE [dbo].[tbl_ProductMapping] CHECK CONSTRAINT [FK_tbl_ProductMapping_tbl_ColorMaster]
GO
ALTER TABLE [dbo].[tbl_ProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ProductMapping_tbl_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tbl_Product] ([ProductID])
GO
ALTER TABLE [dbo].[tbl_ProductMapping] CHECK CONSTRAINT [FK_tbl_ProductMapping_tbl_Product]
GO
ALTER TABLE [dbo].[tbl_ProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ProductMapping_tbl_SizeMaster] FOREIGN KEY([SizeID])
REFERENCES [dbo].[tbl_SizeMaster] ([SizeID])
GO
ALTER TABLE [dbo].[tbl_ProductMapping] CHECK CONSTRAINT [FK_tbl_ProductMapping_tbl_SizeMaster]
GO
ALTER TABLE [dbo].[tbl_Rating]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Rating_tbl_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tbl_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[tbl_Rating] CHECK CONSTRAINT [FK_tbl_Rating_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Rating]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Rating_tbl_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tbl_Product] ([ProductID])
GO
ALTER TABLE [dbo].[tbl_Rating] CHECK CONSTRAINT [FK_tbl_Rating_tbl_Product]
GO
ALTER TABLE [dbo].[tbl_SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SubCategories_tbl_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tbl_Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[tbl_SubCategories] CHECK CONSTRAINT [FK_tbl_SubCategories_tbl_Categories]
GO
USE [master]
GO
ALTER DATABASE [db_StyleSphere] SET  READ_WRITE 
GO
