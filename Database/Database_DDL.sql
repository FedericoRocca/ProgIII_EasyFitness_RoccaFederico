-- No tiene uso en el caso de Azure, ya que no podés usar la master
-- -- Me conecto a Master
-- USE MASTER
-- GO
-- 
-- -- Dropeo la base de datos solo si existe
-- DROP DATABASE IF EXISTS EasyFitness_DB;
-- GO
-- 
-- -- Creo la base de datos y me conecto
-- CREATE DATABASE EasyFitness_DB
-- GO
-- 
-- USE EasyFitness
-- GO

DROP TABLE IF EXISTS Alumnos
DROP TABLE IF EXISTS Entrenadores
DROP TABLE IF EXISTS Personas
DROP TABLE IF EXISTS Usuarios
DROP TABLE IF EXISTS Entrenamientos
DROP TABLE IF EXISTS Rutinas
DROP TABLE IF EXISTS Ejercicios
DROP TABLE IF EXISTS Teams


-- Creo la tabla de ejercicios
CREATE TABLE Ejercicios
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(100) NOT NULL,
	tipo VARCHAR(50) NOT NULL,
	urlEjemplo VARCHAR(100) NOT NULL,
	tiempo INT NULL,
	repeticiones INT NULL,
	comentarios VARCHAR(100) NOT NULL,
	intensidad SMALLINT NOT NULL,
)

-- Creo la tabla de rutinas
CREATE TABLE Rutinas
(
	id BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	ejercicioId BIGINT NOT NULL FOREIGN KEY (ejercicioId) REFERENCES Ejercicios(id),
	descripcion VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	UNIQUE(ejercicioId, descripcion, nombre)
)

-- Creo la tabla de entrenamientos
CREATE TABLE Entrenamientos
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	idRutina BIGINT NOT NULL FOREIGN KEY (idRutina) REFERENCES Rutinas(id),
	descripcion VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	UNIQUE(idRutina, descripcion, nombre)
)

-- Creo la tabla de usuarios
CREATE TABLE Usuarios
(
	id BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	mail VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	UNIQUE (id, mail)
)

-- Creo la tabla de personas
CREATE TABLE Personas
(
	id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NOT NULL,
	dni INT NOT NULL CHECK( DNI > 0 ),
	fechaNacimiento DATETIME NOT NULL,
	userID BIGINT NOT NULL FOREIGN KEY (userID) REFERENCES Usuarios(id),
	UNIQUE(dni)
)

-- Creo la tabla de Teams
CREATE TABLE Teams
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(100) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	UNIQUE(nombre, descripcion)
)

-- Creo la tabla Alumnos
CREATE TABLE Alumnos
(
	id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	personaId BIGINT NOT NULL FOREIGN KEY (personaId) REFERENCES Personas(id),
	entrenamientoID BIGINT NULL FOREIGN KEY (entrenamientoID) REFERENCES Entrenamientos(ID),
	teamID BIGINT NULL FOREIGN KEY (teamID) REFERENCES Teams(ID),
	UNIQUE(entrenamientoID, teamID)
)

CREATE TABLE Entrenadores
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	personaId BIGINT NOT NULL FOREIGN KEY (personaId) REFERENCES Personas(id),
	entrenamientoId BIGINT NULL FOREIGN KEY (entrenamientoId) REFERENCES Entrenamientos(id),
	rutinaId BIGINT NULL FOREIGN KEY (rutinaId) REFERENCES Rutinas(id),
	ejercicioId BIGINT NULL FOREIGN KEY (ejercicioId) REFERENCES Ejercicios(id),
	teamId BIGINT NULL FOREIGN KEY (teamId) REFERENCES Teams(id),
	UNIQUE(entrenamientoId, rutinaId, ejercicioId, teamId)
)