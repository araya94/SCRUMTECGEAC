USE [ScrumProyecto]
GO
/****** Object:  StoredProcedure [dbo].[autentificacion]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[Buscar]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscar]
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
/****** Object:  StoredProcedure [dbo].[buscarProyectos]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[buscarRoles]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[CargarProyectosUsuario]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[CargarReleases]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CargarReleases]
@IDProyecto int
as
begin
begin try
begin transaction

Select * from dbo.Release R
inner join dbo.Release_Proyecto RP on RP.FKProyecto = @IDProyecto
where R.id = RP.FKRelease
commit transaction
end try
begin catch
select ERROR_NUMBER() as ErrorNumber;
return -1;
rollback transaction
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[CargarSprints]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CargarSprints]
@IDRelease int
as
begin
	begin try
		begin transaction

		Select * from dbo.Sprint S
			inner join dbo.Sprint_Release SR on SR.FKRelease = @IDRelease
			where S.id = SR.FKSprint
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[CargarUserStories]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CargarUserStories]
@IDSprint int
as
begin
	begin try
		begin transaction

		Select * from dbo.UserStory US
			where US.FKSprint = @IDSprint
		
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[insertarProyecto]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[insertarUserStory]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertarUserStory]
@FKProyecto int,
@nombre varchar(100),
@descripcion varchar(500),
@prioridad varchar(100)
as
BEGIN
IF NOT EXISTS (SELECT nombre FROM UserStory
WHERE nombre = @nombre)
BEGIN
insert UserStory(FKProyecto,nombre, descripcion ,prioridad)
values(@FKProyecto, @nombre, @descripcion ,@prioridad)
END
ELSE return -1;
END
GO
/****** Object:  StoredProcedure [dbo].[insertarUsuario]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_USERSTORIE]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARESFUERZO_TAREA]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARFKSPRI_USER]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARREVIEW_SPRINT]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZARTIEMPOSPRINT_PROYECTO]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_USER_SPRIN]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_BUSCAR_USER_SPRIN]
@sprint int
as
begin
	begin try
			Select T.Id,T.Nombre from UserStory T, Proyecto P, Sprint_Release SR,Release_Proyecto RP
			where SR.FKSprint = 7
			and SR.FKRelease = RP.FKRelease
			and RP.FKProyecto = T.FKProyecto
			and P.id = RP.FKProyecto
			and T.FKSprint is NULL
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
	end catch
end





GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_USER_SPRINT]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_BUSCAR_USER_SPRINT]
@sprint int
as
begin
begin try
Select T.Id,T.Nombre from UserStory T, Proyecto P, Sprint_Release SR,Release_Proyecto RP
			where SR.FKSprint = @sprint
			and SR.FKRelease = RP.FKRelease
			and RP.FKProyecto = T.FKProyecto
			and P.id = RP.FKProyecto
			and T.FKSprint is NULL
end try
begin catch
select ERROR_NUMBER() as ErrorNumber;
return -1;
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCARESFUERZO_TAREA]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_BUSCARESTIMADO_TAREA]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_BUSCARNOMBRE_PROYECTO]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_USERSORY_x_ID_SPRING]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_USERSORY_x_ID_SPRING]

	 @ID_USER INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
		Delete from Tarea_Usuario
		where FKUserUsuario = (select id from User_Usuario where FKUserStory = @ID_USER)
		Delete from HistorialEsfuerzo
		where FKTarea = (select id from Tarea where FKUserStory = @ID_USER )
		Delete from User_Usuario
		where FKUserStory = @ID_USER
		Delete from Tarea
		where FKUserStory = @ID_USER
		Delete from Criteri
		where FKUserStory = @ID_USER
		Delete from UserStory
		where id = @ID_USER
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_CRITERIO]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_RELEASE]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INGRESAR_RELEASE]

	@idProyecto int,
	 @NOMBRE VARCHAR(500), 
	 @OBJETIVO TEXT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	
	INSERT INTO dbo.Release VALUES (@NOMBRE,@OBJETIVO)
	INSERT INTO dbo.Release_Proyecto  VALUES (@idProyecto, (Select Max(Id) from dbo.Release))
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGRESAR_TAREA]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ASOCIACIONUSER]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_INSERTAR_ASOCIACIONUSER]
@userS int,
@usuario int
as
begin 
begin try
		begin transaction
			insert User_Usuario(FKUserStory,FKUsuarioP)
			values(@userS,@usuario)
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_SPRINT]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_INSERTAR_SPRINT]
@nombre varchar(500),
@descripcion text,
@release int
as
begin 
begin try
		begin transaction
			insert Sprint(Nombre,Descripcion)
			values(@nombre,@descripcion)
			
			insert Sprint_Release(FKRelease,FKSprint)
			values(@release,(select max(Id) from Sprint))
			
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_CRITERIO_x_ID]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_CRITERIO_x_ID]

	 @ID_CRITERIO INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT *
	FROM dbo.Criteri criteri
	WHERE criteri.id = @ID_CRITERIO
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_CRITERIO_x_USERSTORY]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_CRITERIO_x_USERSTORY]

	 @FK_USER_STORIE INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT *
	FROM dbo.Criteri criteri
	WHERE criteri.FKUserStory = @FK_USER_STORIE
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TAREA_x_ID]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_TAREA_x_ID]

	 @ID_TAREA INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT *
	FROM dbo.Tarea tarea
	WHERE tarea.id = @ID_TAREA
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TAREA_x_USERSORY]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_TAREA_x_USERSORY]

	 @FK_USER_STORIE INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT *
	FROM dbo.Tarea tarea
	WHERE tarea.FKUserStory = @FK_USER_STORIE
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USERSORY_x_ID]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_USERSORY_x_ID]

	 @ID INT

AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT usu.id,usu.FKProyecto, usu.FKSprint, usu.Nombre,usu.Prioridad,usu.Descripcion
	FROM dbo.UserStory usu 
	WHERE usu.id = @ID
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USERSORY_x_ID_PROYECTO]    Script Date: 22/06/2014 1:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_OBTENER_USERSORY_x_ID_PROYECTO]
	 @ID_PROYECTO INT
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	
	SET NOCOUNT ON;
	
	SELECT usu.id, usu.FKProyecto, usu.FKSprint, usu.Nombre,usu.Prioridad
	FROM dbo.UserStory usu 
	WHERE usu.FKProyecto = @ID_PROYECTO
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrorNumber;
	RETURN -1;
	ROLLBACK TRANSACTION
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USERSORY_x_ID_SPRING]    Script Date: 22/06/2014 1:44:25 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_TOTALHORAS]    Script Date: 22/06/2014 1:44:25 ******/
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
