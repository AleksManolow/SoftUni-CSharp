CREATE OR ALTER PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
SELECT 
	a.AirportName,
	p.FullName,
	CASE
		WHEN fd.TicketPrice < 400 THEN 'Low'
		WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		WHEN fd.TicketPrice > 1500 THEN 'High'
	END		AS LevelOfTicketPrice,
	ac.Manufacturer,
	ac.Condition,
	at.TypeName
FROM Airports AS a
JOIN FlightDestinations AS fd ON fd.AirportId = a.Id
JOIN Passengers AS p ON p.Id = fd.PassengerId
JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
JOIN AircraftTypes AS at ON at.Id = ac.TypeId
WHERE AirportName = @airportName
ORDER BY ac.Manufacturer, p.FullName

GO 

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'