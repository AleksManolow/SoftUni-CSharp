SELECT
	mc.CountryCode,
	m.MountainRange,
	e.PeakName,
	e.Elevation
FROM Peaks AS e
JOIN Mountains AS m ON e.MountainId = m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE e.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY e.Elevation DESC