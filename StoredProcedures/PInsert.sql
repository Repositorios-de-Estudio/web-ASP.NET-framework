CREATE PROCEDURE PInsert
(
    @nombre nvarchar(50),
    @apellido nvarchar(50)
)
AS
BEGIN
	INSERT INTO [Empresa].[dbo].[tblEmpleados] (Nombres, Apellidos) 
	values (@nombre,@nombre);			   

END

-- USE [Empresa]
-- EXEC PInsert @nombre = 'nombrecualquiera', @apellido = 'apellidocualquiera';