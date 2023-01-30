CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
		DECLARE @Count INT

		BEGIN
			SET @Count = (
			SELECT 
				COUNT(*)
			FROM Users AS u
			JOIN Commits AS c ON c.ContributorId = u.Id
			WHERE u.Username = @username
			)
		END

		RETURN @Count
END

GO 

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')
		AS [Output]