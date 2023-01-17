SELECT TOP 10
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS e 
WHERE Salary > (
				SELECT 
					AVG(Salary) AS AverageSalary
				FROM Employees AS esub
				WHERE esub.DepartmentID = e.DepartmentID
				GROUP BY DepartmentID	
			)
ORDER BY DepartmentID

