-- TSQL-Mod10 - Using Subqueries
-- Author: Mansha Nawaz TU

-- TSQL-Mod10 - 11 - Demonstration A.sql - TSQL Scalar subqueres

-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Step 2: Scalar subqueres:
-- Select this query and execute it to
-- obtain most recent order in the sales.order table
SELECT MAX(orderid) AS lastorder
FROM Sales.Orders;

-- ICA Demo Hint: Look for 1:many related tables. 
-- A sales.order has many sales.orderdetails 
-- eg an order will have many ordered products  

-- Step 3: Select this query and execute it to
-- find details in Sales.OrderDetails for most recent orderin sales.order
SELECT orderid, productid, unitprice, qty
FROM Sales.OrderDetails
WHERE orderid = 
	(SELECT MAX(orderid) AS lastorder
	FROM Sales.Orders);
-- lastorder should be 11077

-- Step 3: Produced in Design Query Editor
-- find details in Sales.OrderDetails for most recent order 
SELECT  Sales.OrderDetails.orderid, Sales.OrderDetails.productid, Sales.OrderDetails.unitprice, Sales.OrderDetails.qty
FROM     Sales.OrderDetails INNER JOIN
               Sales.Orders ON Sales.OrderDetails.orderid = Sales.Orders.orderid
WHERE   (Sales.OrderDetails.orderid =
                   (SELECT  MAX(orderid) AS lastorder
                   FROM     Sales.Orders AS Orders_1))


-- Step 4: THIS WILL FAIL, since
-- subquery returns more than 
-- 1 value
SELECT orderid, productid, unitprice, qty
FROM Sales.OrderDetails
WHERE orderid = 
	(SELECT orderid AS O
	FROM Sales.Orders
	WHERE empid =2);

-- Step 5: Multi-valued subqueries 
-- Select this query and execute it to	
-- return order info for customers in Mexico
SELECT custid, orderid
FROM Sales.orders
WHERE custid IN (
	SELECT custid
	FROM Sales.Customers
	WHERE country = N'Mexico');
-- (the N actually stands for National language character set).

-- Step 6a: Same result expressed as a join:
SELECT Customers.custid, Orders.orderid
FROM Sales.Customers JOIN Sales.Orders 
ON Customers.custid = Orders.custid
WHERE country = N'Mexico';

-- Step 6b: Same result expressed as a join using aliases
SELECT c.custid, o.orderid
FROM Sales.Customers AS c JOIN Sales.Orders AS o
ON c.custid = o.custid
WHERE c.country = N'Mexico';

