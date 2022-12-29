USE [Empresa]
ALTER PROCEDURE [dbo].[Pselect]
AS
BEGIN
	SELECT Nombres, Apellidos, Correos FROM [Empresa].[dbo].[tblEmpleados]
END

-- USE [Empresa]
-- EXEC Pselect;