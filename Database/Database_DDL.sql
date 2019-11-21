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

DROP TABLE IF EXISTS Teams
DROP TABLE IF EXISTS Ejercicios
DROP TABLE IF EXISTS Rutinas
DROP TABLE IF EXISTS Entrenamientos
DROP TABLE IF EXISTS Alumnos
DROP TABLE IF EXISTS Entrenadores
DROP TABLE IF EXISTS Usuarios
DROP TABLE IF EXISTS Personas

-- Creo en cascada:
-- Persona
-- Usuario
-- Alumno
-- Entrenadores
-- Entrenamiento
-- Rutina
-- Ejercicio
-- Teams

-- Creo la tabla de personas
CREATE TABLE Personas
(
	id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NOT NULL,
	dni INT NOT NULL CHECK( DNI > 0 ),
	fechaNacimiento DATETIME NOT NULL,
	UNIQUE(dni)
)

-- Creo la tabla de usuarios
CREATE TABLE Usuarios
(
	id BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	idPersona BIGINT NOT NULL FOREIGN KEY REFERENCES Personas(id),
	mail VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	UNIQUE (id, mail)
)

-- Creo la tabla Alumnos
CREATE TABLE Alumnos
(
	id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	personaId BIGINT NOT NULL FOREIGN KEY REFERENCES Personas(id),
	UNIQUE(personaId)
)

-- Creo la tabla de Entrenadores
CREATE TABLE Entrenadores
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	personaId BIGINT NOT NULL FOREIGN KEY REFERENCES Personas(id)
	UNIQUE(personaId)
)

-- Creo la tabla de entrenamientos
CREATE TABLE Entrenamientos
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	idEntrenador BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenadores(id),
	idAlumno BIGINT NOT NULL FOREIGN KEY REFERENCES Alumnos(id),
	descripcion VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	UNIQUE(descripcion, nombre, idEntrenador, idAlumno)
)

-- Creo la tabla de rutinas
CREATE TABLE Rutinas
(
	id BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	idEntrenador BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenadores(id),
	idEntrenamiento BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenamientos(id),
	descripcion VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	UNIQUE(idEntrenamiento, idEntrenador, descripcion, nombre)
)

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
	idEntrenador BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenadores(id),
	idRutina BIGINT NOT NULL FOREIGN KEY REFERENCES Rutinas(id),
)

-- Creo la tabla de Teams
CREATE TABLE Teams
(
	id BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(100) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	idEntrenador BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenadores(id),
	idEntrenamiento BIGINT NOT NULL FOREIGN KEY REFERENCES Entrenamientos(id),
	idAlumno BIGINT NOT NULL FOREIGN KEY REFERENCES Alumnos(id),
	UNIQUE(idEntrenador, idEntrenamiento, idAlumno)
)