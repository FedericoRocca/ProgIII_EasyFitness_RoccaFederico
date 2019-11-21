SET IDENTITY_INSERT [dbo].[Personas] ON 
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento]) VALUES (1, N'Nombre 1', N'Apellido 1', 123, CAST(N'1998-01-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento]) VALUES (2, N'Nombre 2', N'Apellido 2', 234, CAST(N'1998-01-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Personas] ([id], [nombre], [apellido], [dni], [fechaNacimiento]) VALUES (3, N'Nombre 3', N'Apellido 3', 345, CAST(N'1998-01-02T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([id], [idPersona], [mail], [password]) VALUES (1, 1, N'mail1@mail.com', N'password1')
GO
INSERT [dbo].[Usuarios] ([id], [idPersona], [mail], [password]) VALUES (2, 2, N'mail2@mail2.com', N'password2')
GO
INSERT [dbo].[Usuarios] ([id], [idPersona], [mail], [password]) VALUES (3, 3, N'mail3@mail3.com', N'password3')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 
GO
INSERT [dbo].[Alumnos] ([id], [personaId]) VALUES (1, 1)
GO
INSERT [dbo].[Alumnos] ([id], [personaId]) VALUES (2, 2)
GO
INSERT [dbo].[Alumnos] ([id], [personaId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrenadores] ON 
GO
INSERT [dbo].[Entrenadores] ([id], [personaId]) VALUES (1, 1)
GO
INSERT [dbo].[Entrenadores] ([id], [personaId]) VALUES (2, 2)
GO
INSERT [dbo].[Entrenadores] ([id], [personaId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Entrenadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrenamientos] ON 
GO
INSERT [dbo].[Entrenamientos] ([id], [idEntrenador], [idAlumno], [descripcion], [nombre]) VALUES (1, 1, 1, N'Descripcion 1', N'Entrenamiento 1')
GO
INSERT [dbo].[Entrenamientos] ([id], [idEntrenador], [idAlumno], [descripcion], [nombre]) VALUES (2, 2, 2, N'Descripcion 2', N'Entrenamiento 2')
GO
INSERT [dbo].[Entrenamientos] ([id], [idEntrenador], [idAlumno], [descripcion], [nombre]) VALUES (3, 3, 3, N'Descripcion 3', N'Entrenamiento 3')
GO
INSERT [dbo].[Entrenamientos] ([id], [idEntrenador], [idAlumno], [descripcion], [nombre]) VALUES (4, 1, 1, N'Descripcion 4', N'Entrenamiento 4')
GO
INSERT [dbo].[Entrenamientos] ([id], [idEntrenador], [idAlumno], [descripcion], [nombre]) VALUES (5, 1, 3, N'Descripcion 5', N'Entrenamiento 5')
GO
SET IDENTITY_INSERT [dbo].[Entrenamientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion], [idEntrenador], [idEntrenamiento], [idAlumno]) VALUES (1, N'Team 1', N'Descripcion 1', 1, 1, 1)
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion], [idEntrenador], [idEntrenamiento], [idAlumno]) VALUES (3, N'Team 2', N'Descripcion 2', 2, 2, 2)
GO
INSERT [dbo].[Teams] ([id], [nombre], [descripcion], [idEntrenador], [idEntrenamiento], [idAlumno]) VALUES (4, N'Team 3', N'Descripcion 3', 3, 3, 3)
GO
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Rutinas] ON 
GO
INSERT [dbo].[Rutinas] ([id], [idEntrenador], [idEntrenamiento], [descripcion], [nombre]) VALUES (1, 1, 1, N'Descripcion 1', N'Nombre 1')
GO
INSERT [dbo].[Rutinas] ([id], [idEntrenador], [idEntrenamiento], [descripcion], [nombre]) VALUES (2, 2, 2, N'Descripcion 2', N'Nombre 2')
GO
INSERT [dbo].[Rutinas] ([id], [idEntrenador], [idEntrenamiento], [descripcion], [nombre]) VALUES (4, 1, 3, N'Descripcion 4', N'Nombre 4')
GO
INSERT [dbo].[Rutinas] ([id], [idEntrenador], [idEntrenamiento], [descripcion], [nombre]) VALUES (3, 3, 3, N'Descripcion 3', N'Nombre 3')
GO
SET IDENTITY_INSERT [dbo].[Rutinas] OFF
GO
SET IDENTITY_INSERT [dbo].[Ejercicios] ON 
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad], [idEntrenador], [idRutina]) VALUES (1, N'Nombre 1', N'Tipo 1', N'URL 1', 1, 1, N'Comentarios 1', 1, 1, 1)
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad], [idEntrenador], [idRutina]) VALUES (3, N'Nombre 2', N'Tipo 2', N'URL 2', 2, 2, N'Comentarios 2', 2, 2, 2)
GO
INSERT [dbo].[Ejercicios] ([id], [nombre], [tipo], [urlEjemplo], [tiempo], [repeticiones], [comentarios], [intensidad], [idEntrenador], [idRutina]) VALUES (5, N'Nombre 3', N'Tipo 3', N'URL 3', 3, 3, N'Comentarios 3', 3, 3, 3)
GO
SET IDENTITY_INSERT [dbo].[Ejercicios] OFF
GO