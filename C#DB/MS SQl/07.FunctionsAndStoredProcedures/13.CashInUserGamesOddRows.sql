CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(20))
RETURNS TABLE
AS
RETURN
(
SELECT SUM(x.SumCash) AS [SumCash]
FROM 
    (
        SELECT [Cash] AS [SumCash],
        ROW_NUMBER() OVER (ORDER BY [Cash] DESC ) AS [Row Number]
        FROM UsersGames AS ug
        JOIN Games AS g ON g.Id = ug.GameId
        WHERE g.[Name] = @GameName
    ) AS x
WHERE [Row Number] % 2 = 1
)


SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')