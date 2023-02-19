UPDATE PlayersRanges 
	SET PlayersMax = PlayersMax + 1
WHERE Id = 1

UPDATE Boardgames
	SET Name = CONCAT(Name, 'V2')
WHERE YearPublished >= 2020