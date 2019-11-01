USE [EasyFitness]
GO
SET IDENTITY_INSERT [dbo].[Ejercicios] ON 
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad]) VALUES (1, N'ejerc1', 1, N'1', 1, 1, N'1', 1)
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad]) VALUES (2, N'ejerc2', 2, N'2', 2, 2, N'2', 2)
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad]) VALUES (3, N'ejerc3', 3, N'3', 3, 3, N'3', 3)
GO
SET IDENTITY_INSERT [dbo].[Ejercicios] OFF
GO
SET IDENTITY_INSERT [dbo].[Rutinas] ON 
GO
INSERT [dbo].[Rutinas] ([id], [ejercicioId], [descripcion], [nombre]) VALUES (1, 1, N'1', N'1')
GO
INSERT [dbo].[Rutinas] ([id], [ejercicioId], [descripcion], [nombre]) VALUES (2, 2, N'2', N'2')
GO
INSERT [dbo].[Rutinas] ([id], [ejercicioId], [descripcion], [nombre]) VALUES (3, 3, N'3', N'3')
GO
SET IDENTITY_INSERT [dbo].[Rutinas] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrenamientos] ON 
GO
INSERT [dbo].[Entrenamientos] ([id], [idRutina], [descripcion], [nombre]) VALUES (1, 1, N'1', N'1')
GO
INSERT [dbo].[Entrenamientos] ([id], [idRutina], [descripcion], [nombre]) VALUES (2, 2, N'2', N'2')
GO
INSERT [dbo].[Entrenamientos] ([id], [idRutina], [descripcion], [nombre]) VALUES (3, 3, N'3', N'3')
GO
SET IDENTITY_INSERT [dbo].[Entrenamientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([id], [mail], [password]) VALUES (1, N'1', N'1')
GO
INSERT [dbo].[Usuarios] ([id], [mail], [password]) VALUES (2, N'2', N'2')
GO
INSERT [dbo].[Usuarios] ([id], [mail], [password]) VALUES (3, N'3', N'3')
GO
INSERT [dbo].[Usuarios] ([id], [mail], [password]) VALUES (4, N'4', N'4')
GO
INSERT [dbo].[Usuarios] ([id], [mail], [password]) VALUES (5, N'5', N'5')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento], [userID]) VALUES (1, N'1', N'1', 1, CAST(N'1998-01-02T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento], [userID]) VALUES (2, N'2', N'2', 2, CAST(N'1998-01-02T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento], [userID]) VALUES (3, N'3', N'3', 3, CAST(N'1998-01-02T00:00:00.000' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (1, N'1', N'1')
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (2, N'2', N'2')
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (3, N'3', N'3')
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (4, N'4', N'4')
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (5, N'5', N'5')
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion]) VALUES (6, N'6', N'6')
GO
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrenadores] ON 
GO
INSERT [dbo].[Entrenadores] ([id], [personaId], [entrenamientoId], [rutinaId], [ejercicioId], [teamId]) VALUES (1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Entrenadores] ([id], [personaId], [entrenamientoId], [rutinaId], [ejercicioId], [teamId]) VALUES (2, 2, 2, 2, 2, 2)
GO
INSERT [dbo].[Entrenadores] ([id], [personaId], [entrenamientoId], [rutinaId], [ejercicioId], [teamId]) VALUES (4, 3, 3, 3, 3, 3)
GO
SET IDENTITY_INSERT [dbo].[Entrenadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (2, 1, 1, NULL)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (4, 2, NULL, NULL)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (5, 3, NULL, 3)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (10, 2, 2, 2)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (11, 2, 1, 2)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (12, 2, 2, 1)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (13, 2, 3, 1)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (14, 2, 3, 3)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (17, 2, 3, 4)
GO
INSERT [dbo].[Alumnos] ([id], [personaId], [entrenamientoID], [teamID]) VALUES (18, 2, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
