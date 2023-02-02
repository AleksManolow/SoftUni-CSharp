CREATE OR ALTER PROC usp_SearchByTaste(@taste NVARCHAR(30))
AS
BEGIN 
	SELECT 
		c.CigarName,
		CONCAT('$','',c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.[Length], ' ','cm') AS CigarLength,
		CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange
	FROM Cigars AS c
	JOIN Tastes AS t ON c.TastId = t.Id
	JOIN Brands AS b ON b.Id = c.BrandId
	JOIN Sizes AS s ON s.Id = c.SizeId
	WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC
END

EXEC usp_SearchByTaste 'Woody'
