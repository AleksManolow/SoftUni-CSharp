CREATE TABLE Logs
(
    [LogId] INT PRIMARY KEY IDENTITY,
    [AccountId] INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
    [OldSum] MONEY NOT NULL,
    [NewSum] MONEY NOT NULL
)

CREATE TRIGGER tg_OnAccountsLogChangeOfSum
ON Accounts FOR UPDATE
AS
INSERT Logs (AccountId, OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance
FROM inserted AS i
JOIN deleted AS d ON d.Id = i.Id

