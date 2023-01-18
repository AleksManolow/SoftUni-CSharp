CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS 

BEGIN TRANSACTION

IF NOT EXISTS (SELECT Id FROM Accounts WHERE Id = @AccountId)
    BEGIN
        ROLLBACK
        RAISERROR('Account is not existing', 16,1)
    END

IF   @MoneyAmount < 0
BEGIN
        ROLLBACK
        RAISERROR('Negative amount', 16,1)
END

UPDATE Accounts SET Balance += @MoneyAmount WHERE Id = @AccountId

COMMIT

GO

EXEC dbo.usp_DepositMoney -1, -200.60