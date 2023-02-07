CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN 
	DECLARE @RESULT INT 

	BEGIN

	SET @RESULT = (SELECT
	COUNT(*)
	FROM Passengers AS p
	JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
	WHERE p.Email = @email)

	END
	RETURN @RESULT
END

GO 

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')