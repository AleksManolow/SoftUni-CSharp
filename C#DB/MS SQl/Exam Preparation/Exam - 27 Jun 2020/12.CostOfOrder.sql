CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
 
 DECLARE @totalCost DECIMAL(18, 2) = (SELECT SUM(p.Price * op.Quantity) FROM Jobs AS j
                                      LEFT JOIN Orders AS o ON j.JobId = o.JobId
									  LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
									  LEFT JOIN Parts AS p ON op.PartId = p.PartId
									 WHERE j.JobId = @JobId)

IF (@totalCost IS NULL) RETURN 0.00

RETURN @totalCost

END