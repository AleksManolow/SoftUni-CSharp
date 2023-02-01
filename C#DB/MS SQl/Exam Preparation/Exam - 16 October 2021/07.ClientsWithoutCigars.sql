SELECT 
	cl.Id,
	CONCAT(cl.FirstName, ' ', cl.LastName) AS ClientName,
	cl.Email
FROM Clients AS cl
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = cl.Id
LEFT JOIN Cigars AS ci ON ci.Id = cc.CigarId
WHERE ci.Id IS NULL
ORDER BY ClientName
