SELECT
	c.LastName,
	AVG(s.Length) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS cig ON cig.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = cig.SizeId
GROUP BY c.LastName
ORDER BY AVG(s.[Length]) DESC