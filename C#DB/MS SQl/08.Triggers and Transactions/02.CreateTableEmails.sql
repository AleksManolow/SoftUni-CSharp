CREATE TABLE NotificationEmails
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT FOREIGN KEY REFERENCES Accounts(Id),
    [Subject] NVARCHAR(MAX),
    [Body] NVARCHAR(MAX)
)

CREATE TRIGGER tg_EmailOnAccountChange
ON Accounts FOR UPDATE
AS
DECLARE @AccountId INT = (SELECT TOP(1) Id FROM inserted)
DECLARE @OldSum MONEY = (SELECT Balance FROM deleted) 
DECLARE @NewSum MONEY = (SELECT Balance FROM inserted) 
INSERT INTO NotificationEmails(Recipient, Subject, Body) VALUES
(
    @AccountId, 
    'Balance change for account: ' +  CAST(@AccountId AS NVARCHAR(20)) ,
    'On ' + CONVERT(NVARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@OldSum AS NVARCHAR(20)) + ' to ' + CAST(@NewSum AS NVARCHAR(20)) + '.'  
)

GO