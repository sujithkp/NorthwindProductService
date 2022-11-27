select 
	orderid, 
	(select count(orderid) from [order details] od where od.OrderID = od1.OrderID ) 
from [order details] od1
order by
	(select count(orderid) from [Order Details] od2 where od2.OrderID = od1.OrderId) desc;


select productid, count(productid) from [order details] od group by productid order by count(productid) desc;


select productid, (select count(*) from [order details] od1 where od.ProductID = od1.ProductID) 
from [order details] od
group by ProductID
order by  (select count(*) from [order details] od1 where od.ProductID = od1.ProductID) desc


SELECT [t].[ProductId], [p].[ProductName] AS [Name], [t].[count] AS [Count]
FROM (
    SELECT [o].[ProductID] AS [ProductId], COUNT(*) AS [count], COUNT(*) AS [c]
    FROM [Order Details] AS [o]
    GROUP BY [o].[ProductID]
) AS [t]
INNER JOIN [Products] AS [p] ON [t].[ProductId] = [p].[ProductID]
ORDER BY [t].[c] DESC




