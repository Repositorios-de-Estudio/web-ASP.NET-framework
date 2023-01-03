CREATE PROCEDURE Pselect
AS
BEGIN
	SELECT Nombres, Apellidos, Correos FROM [Empresa].[dbo].[tblEmpleados]
END
GO

-- USE [Empresa]
-- EXEC Pselect;
