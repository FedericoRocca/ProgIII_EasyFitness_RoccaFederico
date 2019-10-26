-- Me conecto a la base de datos
USE [EasyFitness]
GO

-- Vacio la tabla de ejercicios
delete from [dbo].[Ejercicios]

-- Vacio la tabla de alumnos
delete from [dbo].[Alumnos]

-- Vacio la tabla de usuarios
delete from [dbo].[Users]

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

-- Insert de datos en tabla de Usuarios
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user1@gmail.com', N'user1')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user2@gmail.com', N'user2')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user3@gmail.com', N'user3')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user4@gmail.com', N'user4')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user5@gmail.com', N'user5')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user6@gmail.com', N'user6')
GO
INSERT [dbo].[Users] ([Mail], [Password]) VALUES (N'user7@gmail.com', N'user7')
GO
