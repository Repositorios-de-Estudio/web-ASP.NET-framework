CREATE PROCEDURE PDelete
(
    @id int
)
AS
BEGIN
	DELETE FROM [Empresa].[dbo].[tblEmpleados] WHERE @ID = id;  
END

-- USE [Empresa]
-- EXEC PIDelete @id = 1;