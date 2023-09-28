---------------------------------------------------------------------
-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: Mansha Nawaz

-- LAB 09 - Exercise 2
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1 
-- Write a SELECT statement to retrieve the orderid column from the Sales.Orders table
-- and the total sales amount per orderid. 
-- (Hint: Multiply the qty and unitprice columns from the Sales.OrderDetails table.) 
-- Use the alias salesmount for the calculated column. Sort the result by the 
-- total sales amount in descending order.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------
SELECT O.OrderID, SUM(OD.Qty * OD.UnitPrice) AS SalesAmount
FROM Sales.Orders AS O
INNER JOIN Sales.OrderDetails AS OD ON O.OrderID = OD.OrderID
GROUP BY O.OrderID
ORDER BY SalesAmount DESC;

---------------------------------------------------------------------
-- Task 2
-- 
-- Copy the T-SQL statement in task 1 and modify it to include the total number of order lines 
-- for each order and the average order line sales amount value within the order. 
-- Use the aliases nooforderlines and avgsalesamountperorderline, respectively.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------
SELECT O.OrderID, SUM(OD.Qty * OD.UnitPrice) AS SalesAmount, COUNT(*) AS NoOfOrderLines, AVG(OD.Qty * OD.UnitPrice) AS AvgSalesAmountPerOrderLine
FROM Sales.Orders AS O
INNER JOIN Sales.OrderDetails AS OD ON O.OrderID = OD.OrderID
GROUP BY O.OrderID
ORDER BY SalesAmount DESC


---------------------------------------------------------------------
-- Task 3
-- 
-- Write a select statement to retrieve the total sales amount for each month. The SELECT clause should 
-- include a calculated column named yearmonthno (YYYYMM notation) based on the orderdate column 
-- in the Sales.Orders table and a total sales amount (multiply the qty and unitprice columns 
-- from the Sales.OrderDetails table). 
-- Order the result by the yearmonthno calculated column.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------
SELECT YEAR(O.OrderDate) * 100 + MONTH(O.OrderDate) AS YearMonthNo, SUM(OD.Qty * OD.UnitPrice) AS SalesAmount
FROM Sales.Orders AS O
INNER JOIN Sales.OrderDetails AS OD ON O.OrderID = OD.OrderID
GROUP BY YEAR(O.OrderDate) * 100 + MONTH(O.OrderDate)
ORDER BY YearMonthNo


---------------------------------------------------------------------
-- Task 4
-- 
-- Write a select statement to retrieve all the customers (including those that did not place any orders) 
-- and their total sales amount, maximum sales amount per order line, and number of order lines. 
--
-- The SELECT clause should include the custid and contactname columns from the Sales.Customers table 
-- and four calculated columns based on appropriate aggregate functions:
--  totalsalesamount, representing the total sales amount per order
--  maxsalesamountperorderline, representing the maximum sales amount per order line
--  numberofrows, representing the number of rows (use * in the COUNT function)
--  numberoforderlines, representing the number of order lines (use the orderid column in 
-- the COUNT function)
--
-- Order the result by the totalsalesamount column.

-- Provide your TSQL Solution (even if with errors) and review the model solution. 

-- Notice that the custid 22 and 57 rows have a NULL in the columns with the SUM and 
-- MAX aggregate functions. What are their values in the COUNT columns? 
-- Why are they different?
---------------------------------------------------------------------
SELECT C.CustID, C.ContactName, 
SUM(OD.Qty * OD.UnitPrice) AS TotalSalesAmount, 
MAX(OD.Qty * OD.UnitPrice) AS MaxSalesAmountPerOrderLine, 
COUNT(*) AS NumberOfRows, 
COUNT(O.OrderID) AS NumberOfOrderLines
FROM Sales.Customers AS C
LEFT OUTER JOIN Sales.Orders AS O ON C.CustID = O.CustID
LEFT OUTER JOIN Sales.OrderDetails AS OD ON O.OrderID = OD.OrderID
GROUP BY C.CustID, C.ContactName
ORDER BY TotalSalesAmount DESC;
