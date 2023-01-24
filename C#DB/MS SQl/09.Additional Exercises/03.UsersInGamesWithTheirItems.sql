SELECT 
	 u.Username,
	 g.Name AS [Game],
	 COUNT(i.Name) AS [Items Count],
	 ISNULL(SUM(i.[Price]), 0) AS [Items Price]
FROM UsersGames AS ug
JOIN Users AS u ON  u.Id = ug.UserId 
JOIN Games AS g ON  g.Id = ug.GameId
JOIN UserGameItems AS usi ON  usi.UserGameId = ug.Id
JOIN Items AS i ON  i.Id = usi.ItemId 
GROUP BY u.[Username], g.[Name]
HAVING COUNT(i.[Name]) >= 10
ORDER BY [Items Count] DESC,  [Items Price] DESC, u.[Username]
