SELECT
	b.Id,
	b.Name,
	b.YearPublished,
	c.Name
FROM  Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.Name = 'Strategy Games' OR c.Name = 'Wargames'
ORDER BY b.YearPublished DESC