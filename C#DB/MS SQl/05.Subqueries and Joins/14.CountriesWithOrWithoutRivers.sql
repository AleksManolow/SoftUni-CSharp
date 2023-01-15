SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM CountriesRivers  AS cr
RIGHT JOIN Countries AS c ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName
