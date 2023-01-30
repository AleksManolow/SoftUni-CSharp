CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
			SELECT 
			f.Id,
			f.[Name],
			CONCAT(f.Size,'','KB') AS Size
		FROM Files AS f
		WHERE f.[Name] LIKE CONCAT('%','',@fileExtension)
END

GO

EXEC usp_SearchForFiles 'txt'