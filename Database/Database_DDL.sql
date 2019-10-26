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
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nombre] [varchar](100) NOT NULL,
	[Tipo] [int] NOT NULL,
	[UrlEjemplo] [varchar](500) NULL,
	[Tiempo] [int] NULL,
	[Repeticiones] [int] NULL,
	[Comentarios] [varchar](500) NOT NULL
) ON [PRIMARY]
GO

-- Creo la tabla de rutinas
CREATE TABLE dbo.Rutinas
	(
	ID bigint NOT NULL PRIMARY KEY IDENTITY (1,1),
	EjerciciosID bigint NOT NULL FOREIGN KEY references Ejercicios(ID),
	Nombre varchar(100) NOT NULL,
	Descripcion varbinary(200) NOT NULL,
	Tipo varchar(50) NOT NULL
	)  ON [PRIMARY]
GO

-- Creo la tabla de entrenamientos
CREATE TABLE dbo.Entrenamientos
	(
	ID bigint NOT NULL PRIMARY KEY IDENTITY (1,1),
	RutinasID bigint NOT NULL FOREIGN KEY references Rutinas(ID),
	Nombre varchar(100) NOT NULL,
	Descripcion varbinary(200) NOT NULL,
	Tipo varchar(50) NOT NULL
	)  ON [PRIMARY]
GO

-- Creo la tabla de personas
CREATE TABLE dbo.Personas
	(
	ID bigint NOT NULL IDENTITY (1,1) PRIMARY KEY,
	Nombre varchar(100) NOT NULL,
	Apellido varchar(100) NOT NULL,
	DNI int NOT NULL
	)  ON [PRIMARY]
GO

-- Creo la tabla de usuarios
CREATE TABLE [dbo].[Users](
	[ID] bigint NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	[PersonaID] bigint NOT NULL FOREIGN KEY references Personas (ID),
	[Mail] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

-- Creo la tabla de alumnos
CREATE TABLE dbo.Alumnos
	(
	ID bigint NOT NULL IDENTITY (1,1) PRIMARY KEY,
	EntrenamientoID bigint NULL,
	UsuarioID bigint NOT NULL FOREIGN KEY references Users(ID)
	)  ON [PRIMARY]
GO

-- Creo la tabla de entrenadores
CREATE TABLE dbo.Entrenadores
	(
	ID bigint NOT NULL IDENTITY (1,1) PRIMARY KEY,
	TeamAdminID bigint NULL,
	EntrenamientoAdminID bigint NULL,
	AlumnoID bigint NOT NULL FOREIGN KEY references Alumnos(ID)
	)  ON [PRIMARY]
GO

-- Creo la tabla de teams
CREATE TABLE dbo.Teams
	(
	ID bigint NOT NULL IDENTITY (1,1),
	Nombre varchar(100) NOT NULL,
	Descripcion varchar(200) NULL,
	Alumno bigint NULL FOREIGN KEY references Alumnos (ID),
	Entrenador bigint NULL FOREIGN KEY references Entrenadores (ID)
	)  ON [PRIMARY]

