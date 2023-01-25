SELECT c.[CountryName],
    ct.[ContinentName],
    ISNULL(COUNT(r.[Id]), 0) AS [RiversCount],
    ISNULL(SUM(r.[Length]), 0) AS [TotalLength]
FROM [Countries] c
INNER JOIN [Continents] ct ON c.[ContinentCode] = ct.[ContinentCode]
LEFT JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode] 
LEFT JOIN [Rivers] r ON r.[Id] = cr.[RiverId] 
GROUP BY c.[CountryName], ct.[ContinentName]
ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.[CountryName]