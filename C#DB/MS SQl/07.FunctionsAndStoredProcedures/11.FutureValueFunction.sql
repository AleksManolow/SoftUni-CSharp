CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(10, 4)
AS
BEGIN
	RETURN ROUND(@sum * (POWER((1 + @yearlyInterestRate), @numberOfYears)), 4) 
END

GO 

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)