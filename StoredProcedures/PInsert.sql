CREATE PROCEDURE PInsert
(
    @nombre nvarchar(50),
    @apellido nvarchar(50),
	@correo nvarchar(50)
)
AS
BEGIN
	INSERT INTO [Empresa].[dbo].[tblEmpleados] (Nombres, Apellidos, Correos) 
	values (@nombre,@nombre,@correo);			   

END

-- USE [Empresa]
-- EXEC PInsert @nombre = 'nombrecualquiera', @apel