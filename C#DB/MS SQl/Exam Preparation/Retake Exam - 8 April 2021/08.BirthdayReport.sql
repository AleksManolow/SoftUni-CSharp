SELECT 
	u.Username,
	c.Name
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
JOIN Users AS u ON u.Id = r.UserId
WHERE 
	FORMAT(CAST(u.Birthdate AS DATE), 'MM-dd') = 
	FORMAT(CAST(r.OpenDate AS DATE), 'MM-dd')
ORDER BY u.Username, c.Name