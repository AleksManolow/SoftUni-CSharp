CREATE OR ALTER PROC usp_GetEmployeesFromTown (@Town NVARCHAR(50))
AS
SELECT
	e.FirstName,
	e.LastName
FROM Towns AS t
JOIN Addresses AS a ON t.TownID = a.TownID
JOIN Employees AS e ON a.AddressID = e.AddressID
WHERE t.Name = @Town

GO 

EXEC usp_GetEmployeesFromTown 'Sofia'