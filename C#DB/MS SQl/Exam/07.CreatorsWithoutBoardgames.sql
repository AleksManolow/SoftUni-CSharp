SELECT
	Id,
	CONCAT(FirstName, ' ', LastName) AS CreatorName,
	Email
FROM Creators
WHERE NOT Id IN (SELECT
					CreatorId
				 FROM CreatorsBoardgames
				 GROUP BY CreatorId)
ORDER BY CreatorName
