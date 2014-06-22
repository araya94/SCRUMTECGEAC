/* Script para resetear la base 
Crea el usuario admi admi por defecto
*/

EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'ALTER TABLE ? DISABLE TRIGGER ALL'
GO

EXEC sp_MSForEachTable

'BEGIN TRY
   TRUNCATE TABLE ?
END TRY

BEGIN CATCH
   DELETE FROM ?
END CATCH;'

EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
GO

EXEC sp_MSForEachTable 'ALTER TABLE ? ENABLE TRIGGER ALL'
GO

DBCC CHECKIDENT (Criteri, RESEED, 0)
DBCC CHECKIDENT (HistorialEsfuerzo, RESEED, 0)
DBCC CHECKIDENT (Proyecto, RESEED, 0)
DBCC CHECKIDENT (Release, RESEED, 0)
DBCC CHECKIDENT (Release_Proyecto, RESEED, 0)
DBCC CHECKIDENT (Rol, RESEED, 0)
DBCC CHECKIDENT (Sprint, RESEED, 0)
DBCC CHECKIDENT (Sprint_Release, RESEED, 0)
DBCC CHECKIDENT (Sprint_Riesgo, RESEED, 0)
DBCC CHECKIDENT (Tarea, RESEED, 0)
DBCC CHECKIDENT (Tarea_Usuario, RESEED, 0)
DBCC CHECKIDENT (User_Usuario, RESEED, 0)
DBCC CHECKIDENT (UserStory, RESEED, 0)
DBCC CHECKIDENT (Usuario, RESEED, 0)
DBCC CHECKIDENT (Usuario_Proyecto, RESEED, 0)

insert Rol(Nombre)
values('sysAdmin'),('ProductoOwner'),('ScrumMaster'),('Developer'),('Tester')

insert Usuario(FKRol,nombre,contrasena,usuario,email)
values(1,'admi','admi','admi','admi')