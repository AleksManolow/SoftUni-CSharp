CREATE OR ALTER PROC usp_GetHoldersFullName
AS
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM AccountHolders

GO 

EXEC dbo.usp_GetHoldersFullName