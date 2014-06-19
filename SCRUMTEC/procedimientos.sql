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
		update Tarea
		set EsfuerzoInvertido = @tiempo
		where id = @sprint
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

create procedure insertarProyecto
@nombre varchar(100),
@descripcion varchar(100),
@id_usuario int
as
BEGIN 
   IF NOT EXISTS (SELECT nombre FROM Proyecto
                   WHERE nombre = @nombre)
   BEGIN
       insert Proyecto(nombre,descripcion)
	   values(@nombre,@descripcion)

	   insert Usuario_Proyecto(FKUsuario, FKProyecto)
	   values(@id_usuario,(select max(Id) from Proyecto))
   END
   ELSE return -1;
END 


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