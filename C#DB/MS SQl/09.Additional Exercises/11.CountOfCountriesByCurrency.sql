SELECT
	cu.CurrencyCode,
	cu.Description,
	COUNT(c.CountryCode) AS NumberOfCountries
FROM Currencies AS cu
LEFT JOIN Countries As c ON c.CurrencyCode = cu.CurrencyCode
GROUP BY cu.CurrencyCode, cu.Description
ORDER BY NumberOfCountries DESC,  cu.Description