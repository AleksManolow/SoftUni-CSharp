SELECT 
	p.PartId,
	p.Description,
	SUM(pn.Quantity) AS [Required],
	SUM(p.StockQty) AS [In Stock],
	ISNULL(SUM(z.Quantity), 0) AS Ordered
FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN (
		SELECT 
			op.PartId,
			op.Quantity
		FROM Orders AS o
		JOIN OrderParts AS op ON op.OrderId = o.OrderId
		WHERE o.Delivered = 0
		) AS z ON z.PartId = p.PartId
	WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING SUM(pn.Quantity) > SUM(p.StockQty) + ISNULL(SUM(z.Quantity), 0)
ORDER BY p.PartId