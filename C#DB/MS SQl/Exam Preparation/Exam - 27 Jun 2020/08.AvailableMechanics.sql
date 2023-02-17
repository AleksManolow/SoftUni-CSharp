SELECT
	CONCAT(m.FirstName, ' ', m.LastName) AS Available
FROM Mechanics AS m
WHERE m.MechanicId NOT IN(
	SELECT MechanicId
	FROM Jobs AS j
	WHERE j.Status = 'In Progress'
	)
ORDER BY m.MechanicId