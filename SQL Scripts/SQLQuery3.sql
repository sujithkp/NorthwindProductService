select 
	orderid, 
	(select count(orderid) from [order details] od where od.OrderID = od1.OrderID ) 
from [order details] od1
order by
	(select count(orderid) from [Order Details] od2 where od2.OrderID = od1.OrderId) desc
