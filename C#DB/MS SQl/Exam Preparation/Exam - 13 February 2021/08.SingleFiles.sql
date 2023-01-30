SELECT 
	f.Id,
	f.[Name],
	CONCAT(f.Size,'', 'KB') AS Size
FROM Files AS f
WHERE f.Id NOT IN (
		SELECT ParentId
		FROM Files
			WHERE ParentId IS NOT NULL
	)
ORDER BY f.Id, f.[Name], f.Size DESC