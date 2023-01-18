CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
SELECT 
	ah.FirstName,
	ah.LastName
FROM AccountHolders AS ah
LEFT JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY FirstName, LastName
HAVING SUM(a.Balance) > @number
ORDER BY FirstName, LastName

GO 

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 20000


