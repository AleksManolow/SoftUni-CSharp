CREATE OR ALTER PROC usp_GetTownsStartingWith(@String NVARCHAR(50))
AS 
SELECT
	[Name]
FROM Towns
WHERE LOWER(SUBSTRING([Name], 1, LEN(@String))) = LOWER(@String)
GO

EXEC usp_GetTownsStartingWith 'b'