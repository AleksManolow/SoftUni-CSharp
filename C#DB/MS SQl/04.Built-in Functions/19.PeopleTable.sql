SELECT
	[Name],
	[BirthDate],
	DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, [BirthDate], GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, [BirthDate], GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, [BirthDate], GETDATE()) AS [Age in Minutes]
FROM [People]