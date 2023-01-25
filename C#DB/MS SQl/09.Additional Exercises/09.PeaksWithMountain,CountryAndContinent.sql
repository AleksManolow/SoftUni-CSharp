SELECT 
	p.PeakName,
	m.MountainRange AS Mountain,
	cr.CountryName,
	ct.ContinentName
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId = p.MountainId
JOIN Countries AS cr ON cr.CountryCode = mc.CountryCode
JOIN Continents AS ct ON ct.ContinentCode = cr.ContinentCode
ORDER BY p.PeakName, cr.CountryName