CREATE PROCEDURE Pselect
AS
BEGIN
	SELECT Nombres, Apellidos FROM [Empresa].[dbo].[tblEmpleados]
END


-- EXEC Pselect;