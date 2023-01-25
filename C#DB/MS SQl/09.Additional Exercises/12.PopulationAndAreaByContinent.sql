SELECT 
	ct.ContinentName,
	SUM(CAST((cn.AreaInSqKm) AS BIGINT)) AS CountriesArea,
	SUM(CAST((cn.[Population]) AS BIGINT)) AS CountriesPopulation
FROM Continents AS ct
JOIN Countries AS cn ON cn.ContinentCode = ct.ContinentCode
GROUP BY ct.ContinentName
ORDER BY CountriesPopulation DESC
