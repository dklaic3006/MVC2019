USE [master]
GO
/****** Object:  Database [WebShop]    Script Date: 14.4.2019. 10:35:51 ******/
CREATE DATABASE [WebShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebShop', FILENAME = N'E:\Code\MVC2019\WebShop\App_Data\WebShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebShop_log', FILENAME = N'E:\Code\MVC2019\WebShop\App_Data\WebShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebShop] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebShop] SET  MULTI_USER 
GO
ALTER DATABASE [WebShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebShop] SET QUERY_STORE = OFF
GO
USE [WebShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [WebShop]
GO
/****** Object:  Table [dbo].[Kategorije]    Script Date: 14.4.2019. 10:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorije](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategorijeProizvodi]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategorijeProizvodi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProizvodId] [int] NOT NULL,
	[KategorijaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnici]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[AdresaDostave] [nvarchar](250) NOT NULL,
	[Kontakt] [varchar](50) NOT NULL,
	[Napomena] [nvarchar](max) NULL,
 CONSTRAINT [PK__Korisnic__3214EC077FFCA92F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MjereProizvoda]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MjereProizvoda](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzbe]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzbe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikId] [int] NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[DatumKreiranja] [datetime] NOT NULL,
	[DatumVrijemeDostave] [datetime] NOT NULL,
	[JeDostavljeno] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NarudzbeDetalji]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NarudzbeDetalji](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NarudzbaId] [int] NULL,
	[ProizvodId] [int] NULL,
	[Kolicina] [decimal](18, 2) NOT NULL,
	[JedCijena] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvodi]    Script Date: 14.4.2019. 10:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvodi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MjeraProizvodaId] [smallint] NOT NULL,
	[VrijemeKreiranja] [datetime] NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Dostupan] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Korisnici] ON 

INSERT [dbo].[Korisnici] ([Id], [Ime], [Prezime], [Email], [AdresaDostave], [Kontakt], [Napomena]) VALUES (1, N'Antun', N'Antić', N'aantic@net.hr', N'Krbavska 15, Osijek', N'0994561239', N'nema')
SET IDENTITY_INSERT [dbo].[Korisnici] OFF
SET IDENTITY_INSERT [dbo].[MjereProizvoda] ON 

INSERT [dbo].[MjereProizvoda] ([Id], [Naziv]) VALUES (1, N'gram')
INSERT [dbo].[MjereProizvoda] ([Id], [Naziv]) VALUES (2, N'metar')
INSERT [dbo].[MjereProizvoda] ([Id], [Naziv]) VALUES (3, N'litra')
INSERT [dbo].[MjereProizvoda] ([Id], [Naziv]) VALUES (4, N'komad')
SET IDENTITY_INSERT [dbo].[MjereProizvoda] OFF
SET IDENTITY_INSERT [dbo].[Proizvodi] ON 

INSERT [dbo].[Proizvodi] ([Id], [MjeraProizvodaId], [VrijemeKreiranja], [Naziv], [Cijena], [Dostupan]) VALUES (3, 1, CAST(N'2019-04-13T00:00:00.000' AS DateTime), N'Šecer', CAST(4.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Proizvodi] ([Id], [MjeraProizvodaId], [VrijemeKreiranja], [Naziv], [Cijena], [Dostupan]) VALUES (4, 1, CAST(N'2019-04-13T00:00:00.000' AS DateTime), N'Kava', CAST(5.50 AS Decimal(18, 2)), 1)
INSERT [dbo].[Proizvodi] ([Id], [MjeraProizvodaId], [VrijemeKreiranja], [Naziv], [Cijena], [Dostupan]) VALUES (7, 1, CAST(N'2019-04-13T00:00:00.000' AS DateTime), N'Brašno', CAST(6.99 AS Decimal(18, 2)), 1)
INSERT [dbo].[Proizvodi] ([Id], [MjeraProizvodaId], [VrijemeKreiranja], [Naziv], [Cijena], [Dostupan]) VALUES (8, 2, CAST(N'2019-04-13T00:00:00.000' AS DateTime), N'Platno', CAST(12.36 AS Decimal(18, 2)), 1)
INSERT [dbo].[Proizvodi] ([Id], [MjeraProizvodaId], [VrijemeKreiranja], [Naziv], [Cijena], [Dostupan]) VALUES (9, 3, CAST(N'2019-04-13T00:00:00.000' AS DateTime), N'Šampon', CAST(16.99 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Proizvodi] OFF
ALTER TABLE [dbo].[KategorijeProizvodi]  WITH CHECK ADD FOREIGN KEY([KategorijaId])
REFERENCES [dbo].[Kategorije] ([Id])
GO
ALTER TABLE [dbo].[KategorijeProizvodi]  WITH CHECK ADD FOREIGN KEY([ProizvodId])
REFERENCES [dbo].[Proizvodi] ([Id])
GO
ALTER TABLE [dbo].[Narudzbe]  WITH CHECK ADD  CONSTRAINT [FK__Narudzbe__Korisn__2A4B4B5E] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[Narudzbe] CHECK CONSTRAINT [FK__Narudzbe__Korisn__2A4B4B5E]
GO
ALTER TABLE [dbo].[NarudzbeDetalji]  WITH CHECK ADD FOREIGN KEY([NarudzbaId])
REFERENCES [dbo].[Narudzbe] ([Id])
GO
ALTER TABLE [dbo].[NarudzbeDetalji]  WITH CHECK ADD FOREIGN KEY([ProizvodId])
REFERENCES [dbo].[Proizvodi] ([Id])
GO
ALTER TABLE [dbo].[Proizvodi]  WITH CHECK ADD FOREIGN KEY([MjeraProizvodaId])
REFERENCES [dbo].[MjereProizvoda] ([Id])
GO
USE [master]
GO
ALTER DATABASE [WebShop] SET  READ_WRITE 
GO
