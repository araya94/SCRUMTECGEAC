USE [ScrumProyecto]
GO
/****** Object:  Table [dbo].[Criteri]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Criteri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKUserStory] [int] NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Criteri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HistorialEsfuerzo]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialEsfuerzo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKTarea] [int] NOT NULL,
	[FechaCambio] [date] NOT NULL,
	[HorasTrabajadas] [int] NOT NULL,
 CONSTRAINT [PK_HistorialEsfuerzo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proyecto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[DuracionSprint] [int] NULL,
	[FechaInicio] [date] NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Release]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Release](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Objetivos] [text] NOT NULL,
 CONSTRAINT [PK_Release] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Release_Proyecto]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Release_Proyecto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKProyecto] [int] NOT NULL,
	[FKRelease] [int] NOT NULL,
 CONSTRAINT [PK_Release_Proyecto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Riesgos]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Riesgos](
	[id] [int] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Descripcion Detallada] [text] NOT NULL,
	[Probabilidad] [int] NOT NULL,
	[Impacto] [varchar](500) NOT NULL,
	[Estrategia] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Riesgos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sprint]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sprint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[SprintReview] [text] NULL,
 CONSTRAINT [PK_Sprint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sprint_Release]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprint_Release](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKRelease] [int] NOT NULL,
	[FKSprint] [int] NOT NULL,
 CONSTRAINT [PK_Sprint_Release] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sprint_Riesgo]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprint_Riesgo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKRiesgos] [int] NOT NULL,
	[FKSprint] [int] NOT NULL,
 CONSTRAINT [PK_Sprint_Riesgo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stake_Proyect]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stake_Proyect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKStake] [int] NOT NULL,
	[FKProyecto] [int] NOT NULL,
 CONSTRAINT [PK_Stake_Proyect] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StakeHolder]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StakeHolder](
	[id] [int] NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Expectativa] [varchar](500) NOT NULL,
	[Interes] [varchar](500) NOT NULL,
	[email] [varchar](500) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Direccion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_StakeHolder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarea](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKUserStory] [int] NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Descripción] [text] NOT NULL,
	[DuracionEstimada] [int] NOT NULL,
	[EsfuerzoInvertido] [int] NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tarea_Usuario]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea_Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKTarea] [int] NOT NULL,
	[FKUserUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Tarea_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Usuario]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKUserStory] [int] NOT NULL,
	[FKUsuarioP] [int] NOT NULL,
 CONSTRAINT [PK_Tarea_UserS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserStory]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserStory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKProyecto] [int] NOT NULL,
	[FKSprint] [int] NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Prioridad] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NULL,
 CONSTRAINT [PK_UserStory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKRol] [int] NOT NULL,
	[nombre] [varchar](500) NOT NULL,
	[email] [varchar](500) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[contrasena] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario_Proyecto]    Script Date: 19/06/2014 21:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Proyecto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FKUsuario] [int] NOT NULL,
	[FKProyecto] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Proyecto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Criteri]  WITH CHECK ADD  CONSTRAINT [FK_Criteri_UserStory] FOREIGN KEY([FKUserStory])
REFERENCES [dbo].[UserStory] ([id])
GO
ALTER TABLE [dbo].[Criteri] CHECK CONSTRAINT [FK_Criteri_UserStory]
GO
ALTER TABLE [dbo].[HistorialEsfuerzo]  WITH CHECK ADD  CONSTRAINT [FK_HistorialEsfuerzo_Tarea] FOREIGN KEY([FKTarea])
REFERENCES [dbo].[Tarea] ([id])
GO
ALTER TABLE [dbo].[HistorialEsfuerzo] CHECK CONSTRAINT [FK_HistorialEsfuerzo_Tarea]
GO
ALTER TABLE [dbo].[Release_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Release_Proyecto_Proyecto] FOREIGN KEY([FKProyecto])
REFERENCES [dbo].[Proyecto] ([id])
GO
ALTER TABLE [dbo].[Release_Proyecto] CHECK CONSTRAINT [FK_Release_Proyecto_Proyecto]
GO
ALTER TABLE [dbo].[Release_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Release_Proyecto_Release] FOREIGN KEY([FKRelease])
REFERENCES [dbo].[Release] ([id])
GO
ALTER TABLE [dbo].[Release_Proyecto] CHECK CONSTRAINT [FK_Release_Proyecto_Release]
GO
ALTER TABLE [dbo].[Sprint_Release]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Release_Release] FOREIGN KEY([FKRelease])
REFERENCES [dbo].[Release] ([id])
GO
ALTER TABLE [dbo].[Sprint_Release] CHECK CONSTRAINT [FK_Sprint_Release_Release]
GO
ALTER TABLE [dbo].[Sprint_Release]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Release_Sprint] FOREIGN KEY([FKSprint])
REFERENCES [dbo].[Sprint] ([id])
GO
ALTER TABLE [dbo].[Sprint_Release] CHECK CONSTRAINT [FK_Sprint_Release_Sprint]
GO
ALTER TABLE [dbo].[Sprint_Riesgo]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Riesgo_Riesgos] FOREIGN KEY([FKRiesgos])
REFERENCES [dbo].[Riesgos] ([id])
GO
ALTER TABLE [dbo].[Sprint_Riesgo] CHECK CONSTRAINT [FK_Sprint_Riesgo_Riesgos]
GO
ALTER TABLE [dbo].[Sprint_Riesgo]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Riesgo_Sprint] FOREIGN KEY([FKSprint])
REFERENCES [dbo].[Sprint] ([id])
GO
ALTER TABLE [dbo].[Sprint_Riesgo] CHECK CONSTRAINT [FK_Sprint_Riesgo_Sprint]
GO
ALTER TABLE [dbo].[Stake_Proyect]  WITH CHECK ADD  CONSTRAINT [FK_Stake_Proyect_Proyecto] FOREIGN KEY([FKProyecto])
REFERENCES [dbo].[Proyecto] ([id])
GO
ALTER TABLE [dbo].[Stake_Proyect] CHECK CONSTRAINT [FK_Stake_Proyect_Proyecto]
GO
ALTER TABLE [dbo].[Stake_Proyect]  WITH CHECK ADD  CONSTRAINT [FK_Stake_Proyect_StakeHolder] FOREIGN KEY([FKStake])
REFERENCES [dbo].[StakeHolder] ([id])
GO
ALTER TABLE [dbo].[Stake_Proyect] CHECK CONSTRAINT [FK_Stake_Proyect_StakeHolder]
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_UserStory] FOREIGN KEY([FKUserStory])
REFERENCES [dbo].[UserStory] ([id])
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_UserStory]
GO
ALTER TABLE [dbo].[Tarea_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Usuario_Tarea] FOREIGN KEY([FKTarea])
REFERENCES [dbo].[Tarea] ([id])
GO
ALTER TABLE [dbo].[Tarea_Usuario] CHECK CONSTRAINT [FK_Tarea_Usuario_Tarea]
GO
ALTER TABLE [dbo].[Tarea_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Usuario_User_Usuario] FOREIGN KEY([FKUserUsuario])
REFERENCES [dbo].[User_Usuario] ([id])
GO
ALTER TABLE [dbo].[Tarea_Usuario] CHECK CONSTRAINT [FK_Tarea_Usuario_User_Usuario]
GO
ALTER TABLE [dbo].[User_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_UserS_Usuario_Proyecto] FOREIGN KEY([FKUsuarioP])
REFERENCES [dbo].[Usuario_Proyecto] ([id])
GO
ALTER TABLE [dbo].[User_Usuario] CHECK CONSTRAINT [FK_Tarea_UserS_Usuario_Proyecto]
GO
ALTER TABLE [dbo].[User_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_User_Usuario_UserStory] FOREIGN KEY([FKUserStory])
REFERENCES [dbo].[UserStory] ([id])
GO
ALTER TABLE [dbo].[User_Usuario] CHECK CONSTRAINT [FK_User_Usuario_UserStory]
GO
ALTER TABLE [dbo].[UserStory]  WITH CHECK ADD  CONSTRAINT [FK_UserStory_Proyecto] FOREIGN KEY([FKProyecto])
REFERENCES [dbo].[Proyecto] ([id])
GO
ALTER TABLE [dbo].[UserStory] CHECK CONSTRAINT [FK_UserStory_Proyecto]
GO
ALTER TABLE [dbo].[UserStory]  WITH CHECK ADD  CONSTRAINT [FK_UserStory_Sprint] FOREIGN KEY([FKSprint])
REFERENCES [dbo].[Sprint] ([id])
GO
ALTER TABLE [dbo].[UserStory] CHECK CONSTRAINT [FK_UserStory_Sprint]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([FKRol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
ALTER TABLE [dbo].[Usuario_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Proyecto_Proyecto] FOREIGN KEY([FKProyecto])
REFERENCES [dbo].[Proyecto] ([id])
GO
ALTER TABLE [dbo].[Usuario_Proyecto] CHECK CONSTRAINT [FK_Usuario_Proyecto_Proyecto]
GO
ALTER TABLE [dbo].[Usuario_Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Proyecto_Usuario] FOREIGN KEY([FKUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Usuario_Proyecto] CHECK CONSTRAINT [FK_Usuario_Proyecto_Usuario]
GO
