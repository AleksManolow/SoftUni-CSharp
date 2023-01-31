SELECT 
	Description,
	FORMAT(CAST(OpenDate AS DATE), 'dd-MM-yyyy') AS OpenDate
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, Description

