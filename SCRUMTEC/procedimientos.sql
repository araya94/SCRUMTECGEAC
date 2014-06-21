/*create procedure buscarRoles
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

create procedure SP_TOTALHORAS
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

create procedure SP_INSERTAR_ASOCIACIONUSER
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

create procedure insertarUsuario
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

create procedure autentificacion
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

create procedure SP_INSERTAR_SPRINT
@nombre varchar(500),
@descripcion varchar(500),
@release int
as
begin
	begin try
		begin transaction
			insert Sprint(Nombre,Descripcion)
			values(@nombre,@descripcion)

			insert Sprint_Release(FKRelease,FKSprint)
			values(@release,(select max(Id) from Sprint))

			return (select max(Id) from Sprint) /*Retorna el id del sprint creado actual */
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end

create procedure SP_BUSCARNOMBRE_PROYECTO
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

create procedure SP_ACTUALIZARTIEMPOSPRINT_PROYECTO
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


create procedure SP_BUSCARESTIMADO_TAREA
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

create procedure SP_BUSCARESFUERZO_TAREA
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

create procedure SP_ACTUALIZARESFUERZO_TAREA
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

create procedure SP_ACTUALIZARREVIEW_SPRINT
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

create procedure SP_ACTUALIZARFKSPRI_USER
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

create procedure SP_BUSCAR_USER_SPRIN
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

create procedure CargarProyectosUsuario
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


create procedure insertarUserStory
@FKProyecto int,
@FKSprint int,
@nombre varchar(100),
@prioridad varchar(100)
as
BEGIN
IF NOT EXISTS (SELECT nombre FROM UserStory
WHERE nombre = @nombre)
BEGIN
insert UserStory(FKProyecto,FKSprint,nombre,prioridad)
values(@FKProyecto, @FKSprint, @nombre,@prioridad)
END
ELSE return -1;
END
*/

/**
create procedure insertarUserStory
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
*/

/*--------------------------------------------- ESTEBAN -----------------------------------------------------------

create procedure SP_ACTUALIZAR_USERSTORIE
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

create procedure SP_INGRESAR_CRITERIO

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

create procedure SP_INGRESAR_TAREA

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

create procedure SP_OBTENER_USERSORY_x_ID_SPRING

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

--------------------------------------------------


create procedure CargarReleases
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

create procedure CargarSprints
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

create procedure CargarUserStories
@IDSprint int
as
begin
	begin try
		begin transaction

		Select * from dbo.UserStory US
			inner join dbo.UserS_Sprint USS on USS.FKSprint = @IDSprint
			where US.id = USS.FKUserS
		commit transaction
	end try
	begin catch
		select ERROR_NUMBER() as ErrorNumber;
		return -1;
		rollback transaction
	end catch
end

// Le puse lo de la fecha
create procedure insertarProyecto
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