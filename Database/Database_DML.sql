-- Me conecto a la base de datos
USE [EasyFitness]
GO

-- Vacio la tabla de ejercicios
TRUNCATE TABLE [dbo].[Ejercicios]

-- Insert de datos en tabla de Ejercicios
SET IDENTITY_INSERT [dbo].[Ejercicios] ON 
GO
INSERT [dbo].[Ejercicios] ([ID], [Nombre], [Tipo], [UrlEjemplo], [Tiempo], [Repeticiones], [Comentarios]) VALUES (1, N'Burpees', 1, N'2', NULL, 10, N'Burpees, opción sin salto')
GO
INSERT [dbo].[Ejercicios] ([ID], [Nombre], [Tipo], [UrlEjemplo], [Tiempo], [Repeticiones], [Comentarios]) VALUES (2, N'Flexiones', 2, N'3', NULL, 20, N'Flexiones clásicas')
GO
INSERT [dbo].[Ejercicios] ([ID], [Nombre], [Tipo], [UrlEjemplo], [Tiempo], [Repeticiones], [Comentarios]) VALUES (3, N'Correr en cinta', 3, N'4', 10, NULL, N'Cinta, velocidad 4.8')
GO
SET IDENTITY_INSERT [dbo].[Ejercicios] OFF
GO

-- Vacio la tabla de usuarios
TRUNCATE TABLE [dbo].[Users]

-- Insert de datos en tabla de Usuarios
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'prueba@gmail.com', N'Prueba')
GO