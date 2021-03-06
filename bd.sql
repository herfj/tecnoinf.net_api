USE [master]
GO
/****** Object:  Database [design_pro]    Script Date: 9/7/2021 4:05:47 ******/
CREATE DATABASE [design_pro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'design_pro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\design_pro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'design_pro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\design_pro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [design_pro] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [design_pro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [design_pro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [design_pro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [design_pro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [design_pro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [design_pro] SET ARITHABORT OFF 
GO
ALTER DATABASE [design_pro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [design_pro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [design_pro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [design_pro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [design_pro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [design_pro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [design_pro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [design_pro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [design_pro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [design_pro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [design_pro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [design_pro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [design_pro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [design_pro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [design_pro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [design_pro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [design_pro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [design_pro] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [design_pro] SET  MULTI_USER 
GO
ALTER DATABASE [design_pro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [design_pro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [design_pro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [design_pro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [design_pro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [design_pro] SET QUERY_STORE = OFF
GO
USE [design_pro]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Nombre] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Cuerpo] [text] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Proyecto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiquetas]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiquetas](
	[Titulo_proyecto] [varchar](50) NOT NULL,
	[Etiquetas] [varchar](20) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Etiquetas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herramientas]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herramientas](
	[Titulo_proyecto] [varchar](50) NOT NULL,
	[Herramienta] [varchar](25) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Herramientas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensajes]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensajes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Cuerpo] [text] NOT NULL,
	[Visto] [smallint] NOT NULL,
	[Emisor] [varchar](50) NOT NULL,
	[Remitente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[ID_Visual] [int] NULL,
	[ID_Portfolio] [int] NOT NULL,
	[Contenido] [text] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portfolio]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo_Proyecto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[Titulo] [varchar](50) NOT NULL,
	[Vistas] [int] NOT NULL,
	[Fecha_publicada] [date] NOT NULL,
	[Autor] [varchar](50) NOT NULL,
	[ID_Portfolio] [int] NULL,
	[Portada] [int] NOT NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[Titulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto_categorias]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto_categorias](
	[Categoria] [varchar](25) NOT NULL,
	[Titulo_proyecto] [varchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Proyecto_categorias] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguir]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguir](
	[Seguidor] [varchar](50) NOT NULL,
	[Seguido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Seguir] PRIMARY KEY CLUSTERED 
(
	[Seguido] ASC,
	[Seguidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](75) NOT NULL,
	[Ciudad] [varchar](25) NULL,
	[Pais] [varchar](50) NOT NULL,
	[Profesion] [varchar](40) NULL,
	[Fecha_nac] [date] NOT NULL,
	[Empresa] [varchar](40) NULL,
	[URL] [varchar](60) NULL,
	[ID_Visual] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valoraciones]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valoraciones](
	[Titulo_Proyecto] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Valoraciones_1] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC,
	[Titulo_Proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visual]    Script Date: 9/7/2021 4:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visual](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[Tipo] [smallint] NOT NULL,
 CONSTRAINT [PK_Visual] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Proyecto] FOREIGN KEY([Proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Proyecto]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Usuarios]
GO
ALTER TABLE [dbo].[Etiquetas]  WITH CHECK ADD  CONSTRAINT [FK_Etiquetas_Proyecto] FOREIGN KEY([Titulo_proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Etiquetas] CHECK CONSTRAINT [FK_Etiquetas_Proyecto]
GO
ALTER TABLE [dbo].[Herramientas]  WITH CHECK ADD  CONSTRAINT [FK_Herramientas_Proyecto] FOREIGN KEY([Titulo_proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Herramientas] CHECK CONSTRAINT [FK_Herramientas_Proyecto]
GO
ALTER TABLE [dbo].[Mensajes]  WITH CHECK ADD  CONSTRAINT [FK_Mensajes_Usuarios] FOREIGN KEY([Remitente])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [FK_Mensajes_Usuarios]
GO
ALTER TABLE [dbo].[Mensajes]  WITH CHECK ADD  CONSTRAINT [FK_Mensajes_Usuarios1] FOREIGN KEY([Emisor])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [FK_Mensajes_Usuarios1]
GO
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Portfolio] FOREIGN KEY([ID_Portfolio])
REFERENCES [dbo].[Portfolio] ([ID])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_Portfolio]
GO
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Visual] FOREIGN KEY([ID_Visual])
REFERENCES [dbo].[Visual] ([ID])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_Visual]
GO
ALTER TABLE [dbo].[Portfolio]  WITH CHECK ADD  CONSTRAINT [FK_Portfolio_Proyecto] FOREIGN KEY([Titulo_Proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Portfolio] CHECK CONSTRAINT [FK_Portfolio_Proyecto]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Portfolio] FOREIGN KEY([ID_Portfolio])
REFERENCES [dbo].[Portfolio] ([ID])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_Portfolio]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Usuarios] FOREIGN KEY([Autor])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_Usuarios]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Visual] FOREIGN KEY([Portada])
REFERENCES [dbo].[Visual] ([ID])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_Visual]
GO
ALTER TABLE [dbo].[Proyecto_categorias]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_categorias_Categoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categoria] ([Nombre])
GO
ALTER TABLE [dbo].[Proyecto_categorias] CHECK CONSTRAINT [FK_Proyecto_categorias_Categoria]
GO
ALTER TABLE [dbo].[Proyecto_categorias]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_categorias_Proyecto] FOREIGN KEY([Titulo_proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Proyecto_categorias] CHECK CONSTRAINT [FK_Proyecto_categorias_Proyecto]
GO
ALTER TABLE [dbo].[Seguir]  WITH CHECK ADD  CONSTRAINT [FK_Seguir_Usuarios] FOREIGN KEY([Seguido])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Seguir] CHECK CONSTRAINT [FK_Seguir_Usuarios]
GO
ALTER TABLE [dbo].[Seguir]  WITH CHECK ADD  CONSTRAINT [FK_Seguir_Usuarios1] FOREIGN KEY([Seguidor])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Seguir] CHECK CONSTRAINT [FK_Seguir_Usuarios1]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Visual] FOREIGN KEY([ID_Visual])
REFERENCES [dbo].[Visual] ([ID])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Visual]
GO
ALTER TABLE [dbo].[Valoraciones]  WITH CHECK ADD  CONSTRAINT [FK_Valoraciones_Proyecto] FOREIGN KEY([Titulo_Proyecto])
REFERENCES [dbo].[Proyecto] ([Titulo])
GO
ALTER TABLE [dbo].[Valoraciones] CHECK CONSTRAINT [FK_Valoraciones_Proyecto]
GO
ALTER TABLE [dbo].[Valoraciones]  WITH CHECK ADD  CONSTRAINT [FK_Valoraciones_Usuarios1] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Email])
GO
ALTER TABLE [dbo].[Valoraciones] CHECK CONSTRAINT [FK_Valoraciones_Usuarios1]
GO
USE [master]
GO
ALTER DATABASE [design_pro] SET  READ_WRITE 
GO
