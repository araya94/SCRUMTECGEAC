USE [master]
GO
/****** Object:  Database [ScrumProyecto]    Script Date: 19/06/2014 21:42:31 ******/
CREATE DATABASE [ScrumProyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScrumProyecto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ScrumProyecto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ScrumProyecto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ScrumProyecto_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ScrumProyecto] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScrumProyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScrumProyecto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScrumProyecto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScrumProyecto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScrumProyecto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScrumProyecto] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScrumProyecto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScrumProyecto] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ScrumProyecto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScrumProyecto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScrumProyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScrumProyecto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScrumProyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScrumProyecto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScrumProyecto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScrumProyecto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScrumProyecto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScrumProyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScrumProyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScrumProyecto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScrumProyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScrumProyecto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScrumProyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScrumProyecto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScrumProyecto] SET RECOVERY FULL 
GO
ALTER DATABASE [ScrumProyecto] SET  MULTI_USER 
GO
ALTER DATABASE [ScrumProyecto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScrumProyecto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScrumProyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScrumProyecto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ScrumProyecto', N'ON'
GO
USE [ScrumProyecto]
GO
/****** Object:  StoredProcedure [dbo].[autentificacion]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[autentificacion]
@usuario varchar(30),
@contraseña varchar(30)
as
begin
begin try
		Select * From Usuario 
		where usuario like @usuario +'%'
		and contrasena like @contraseña +'%'
end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch 
end
GO
/****** Object:  StoredProcedure [dbo].[buscarProyectos]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscarProyectos]
as
begin
	begin try
			Select * from Proyecto
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[buscarRoles]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[buscarRoles]
as
begin
	begin try
			Select * from Rol
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[CargarProyectosUsuario]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[CargarProyectosUsuario]
                @IDUsuario int
                as
                begin
                begin try
		            begin transaction

			            Select * from dbo.Proyecto P
				            inner join dbo.Usuario_Proyecto UP on UP.FKUsuario = @IDUsuario
					            where P.id = UP.FKProyecto
		            commit transaction
	            end try
	            begin catch
		            select ERROR_NUMBER() as ErrorNumber;
		            return -1;
		            rollback transaction
	            end catch 
            end
GO
/****** Object:  StoredProcedure [dbo].[insertarProyecto]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertarProyecto]
@nombre varchar(100),
@descripcion varchar(100),
@id_usuario int
as
BEGIN 
   IF NOT EXISTS (SELECT nombre FROM Proyecto
                   WHERE nombre = @nombre)
   BEGIN
       insert Proyecto(nombre,descripcion,FechaInicio)
	   values(@nombre,@descripcion,getdate())

	   insert Usuario_Proyecto(FKUsuario, FKProyecto)
	   values(@id_usuario,(select max(Id) from Proyecto))
   END
   ELSE return -1;
END 
GO
/****** Object:  StoredProcedure [dbo].[insertarUsuario]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertarUsuario]
@usuario varchar(100),
@contrasena varchar(100),
@nombre varchar(500),
@email varchar(500),
@proyecto int,
@rol int
as
begin 
begin try
		begin transaction
			insert Usuario(FKRol,nombre,email,usuario,contrasena)
			values(@rol,@nombre,@email,@usuario,@contrasena)
			
			insert Usuario_Proyecto(FKUsuario,FKProyecto)
			values((select max(Id) from Usuario),@proyecto)
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_USERSTORIE]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ACTUALIZAR_USERSTORIE]
	 @ID INT, 
	 @NOMBRE VARCHAR(50),
	 @PRIORIDAD VARCHAR(500)
AS

BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	SET NOCOUNT ON;

	UPDATE dbo.UserStory  
	SET  Nombre=@NOMBRE,Prioridad = @PRIORIDAD
	WHERE id = @ID
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	select ERROR_NUMBER() as ErrorNumber;
	return -1;
	rollback transaction
END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARESFUERZO_TAREA]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ACTUALIZARESFUERZO_TAREA]
@tiempo int,
@sprint int
as
begin
begin try

	DECLARE @HorasTrabajadas int;

	SET @HorasTrabajadas = @tiempo - (Select EsfuerzoInvertido 
							from Tarea 
							where id = @sprint)

	update Tarea
	set EsfuerzoInvertido = @tiempo
	where id = @sprint

	insert HistorialEsfuerzo(FKTarea,FechaCambio,HorasTrabajadas)
	values(@sprint,getdate(),@HorasTrabajadas)
end try
begin catch
select ERROR_NUMBER() as ErrorNumber;
return -1;
rollback transaction
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARFKSPRI_USER]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_ACTUALIZARFKSPRI_USER]
@sprint int,
@user int
as
begin 
	begin try
		update UserStory
		set FKSprint = @sprint
		where id = @user
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end



GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARREVIEW_SPRINT]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ACTUALIZARREVIEW_SPRINT]
@descrip text,
@idSprint int
as
begin 
	begin try
		update Sprint
		set SprintReview = @descrip
		where id = @idSprint
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARTIEMPOSPRINT_PROYECTO]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ACTUALIZARTIEMPOSPRINT_PROYECTO]
@tiempo int,
@proyecto int
as
begin
	begin try
		update Proyecto
		set DuracionSprint = @tiempo
		where id = @proyecto
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end

GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_USER_SPRIN]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_BUSCAR_USER_SPRIN]
@sprint int
as
begin
	begin try
			Select T.Id,T.Nombre from UserStory T, Proyecto P, Sprint_Release SR,Release_Proyecto RP
			where SR.FKSprint = @sprint 
			and SR.FKRelease = RP.FKRelease
			and RP.FKProyecto = T.FKProyecto
			and T.FKSprint = null
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end





GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCARESFUERZO_TAREA]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_BUSCARESFUERZO_TAREA]
@tarea int
as
begin
	begin try
			Select T.id,T.EsfuerzoInvertido from Tarea T
			where  @tarea = T.id 
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end





GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCARESTIMADO_TAREA]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BUSCARESTIMADO_TAREA]
@tarea int
as
begin
begin try
Select T.id,T.DuracionEstimada from Tarea T
where  @tarea = T.id
end try
begin catch
select ERROR_NUMBER() as ErrorNumber;
return -1;
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCARNOMBRE_PROYECTO]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BUSCARNOMBRE_PROYECTO]
@proyecto int
as
begin
	begin try
			Select * from Proyecto P
			where  @proyecto = P.id 
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end


GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_CRITERIO]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_INGRESAR_CRITERIO]

	 @FK_USERSTORY INT,
	 @NOMBRE VARCHAR(500), 
	 @DESCRIPCION TEXT,
	 @ESTADO BIT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	
	INSERT INTO dbo.Criteri VALUES (@FK_USERSTORY,@NOMBRE,@DESCRIPCION,@ESTADO)
	
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_TAREA]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_INGRESAR_TAREA]

	 @FK_USERSTORY INT, 
	 @NOMBRE VARCHAR(500),
	 @DESCRIPCION TEXT,
	 @DURACIONESTIMADA INT,
	 @DURACIONINVERTIDA INT


AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.Tarea VALUES (@FK_USERSTORY, @NOMBRE, @DESCRIPCION,@DURACIONESTIMADA,@DURACIONINVERTIDA) 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_SPRINT]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_INSERTAR_SPRINT]
@nombre varchar(500),
@descripcion text,
@releas int
as
begin 
begin try
		begin transaction
			insert Sprint(Nombre,Descripcion)
			values(@nombre,@descripcion)
			
			insert Sprint_Release(FKRelease,FKSprint)
			values(@releas,(select max(Id) from Sprint))
			
			return (select max(Id) from Sprint)
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USERSORY_x_ID_SPRING]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_OBTENER_USERSORY_x_ID_SPRING]

	 @ID_SPRING INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT usu.FKSprint,usu.Nombre,usu.Prioridad
	FROM dbo.UserStory usu 
	WHERE usu.FKSprint = @ID_SPRING
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TOTALHORAS]    Script Date: 19/06/2014 21:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_TOTALHORAS]
@proyecto int
as
begin 
	begin try
		select sum(T.DuracionEstimada)
		from Tarea T, UserStory US
		where T.FKUserStory = US.id
		and US.FKProyecto = @proyecto
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch 
end
GO
/****** Object:  Table [dbo].[Criteri]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[HistorialEsfuerzo]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Proyecto]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Release]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Release_Proyecto]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Riesgos]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Sprint]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Sprint_Release]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Sprint_Riesgo]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Stake_Proyect]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[StakeHolder]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Tarea]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Tarea_Usuario]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[User_Usuario]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[UserStory]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/06/2014 21:42:32 ******/
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
/****** Object:  Table [dbo].[Usuario_Proyecto]    Script Date: 19/06/2014 21:42:32 ******/
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
USE [master]
GO
ALTER DATABASE [ScrumProyecto] SET  READ_WRITE 
GO
