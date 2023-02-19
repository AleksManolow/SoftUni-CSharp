SELECT TOP(5)
	b.Name,
	b.Rating,
	c.Name
FROM Boardgames AS b
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE (Rating > 7 AND LOWER(b.Name) LIKE ('%a%')) OR (Rating > 7.5 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY b.Name, b.Rating DESC

	