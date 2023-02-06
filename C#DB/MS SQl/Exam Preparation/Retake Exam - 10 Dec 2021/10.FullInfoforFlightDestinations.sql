SELECT 
	a.AirportName,
	fd.[Start] AS DayTime,
	fd.TicketPrice,
	p.FullName,
	ac.Manufacturer,
	ac.Model
FROM
(
		SELECT *
		FROM FlightDestinations AS fd
		WHERE DATEPART(HOUR, fd.Start) BETWEEN 6 AND 20) fd
JOIN Airports AS a ON a.Id = fd.AirportId
JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
JOIN Passengers AS p ON p.Id = fd.PassengerId
WHERE fd.TicketPrice > 2500
ORDER BY ac.Model ASC