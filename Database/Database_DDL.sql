-- Me conecto a Master
USE MASTER
GO

-- Dropeo la base de datos solo si existe
DROP DATABASE IF EXISTS EasyFitness;
GO

-- Creo la base de datos y me conecto
CREATE DATABASE EasyFitness
GO

USE EasyFitness
GO

-- Creo la tabla de Ejercicios
CREATE TABLE [dbo].[Ejercicios](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Tipo] [int] NOT NULL,
	[UrlEjemplo] [varchar](500) NULL,
	[Tiempo] [int] NULL,
	[Repeticiones] [int] NULL,
	[Comentarios] [varchar](500) NOT NULL
) ON [PRIMARY]
GO

-- Creo la tabla de usuarios
CREATE TABLE [dbo].[Users](
	[Mail] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO