CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@accountId INT,@interesRate FLOAT)
AS
SELECT
	a.Id,
	ah.FirstName,
	ah.LastName,
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(Balance, @interesRate, 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
WHERE @accountId = a.Id

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1
