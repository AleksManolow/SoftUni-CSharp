SELECT 
	c.CountryCode,
	COUNT(mc.MountainId) AS MountainRanges
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN ('Bulgaria', 'Russia', 'United States')
GROUP BY c.CountryCode