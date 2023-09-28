---------------------------------------------------------------------
-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: Mansha Nawaz

-- LAB 09 - Exercise 4
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1: top 10 customers by total sales
-- 
-- Write a SELECT statement to retrieve the top 10 customers by total sales amount that 
-- spent more than $10,000 in terms of sales amount. Display the custid column from the 
-- Orders table and a calculated column that contains the total sales amount based on 
-- the qty and unitprice columns from the Sales.OrderDetails table. Use the alias totalsalesamount 
-- for the calculated column.
--
-- Execute the written statement and compare the results
---------------------------------------------------------------------

SELECT TOP (10) 
	o.custid, 
	SUM(d.qty * d.unitprice) AS totalsalesamount 
FROM Sales.Orders AS o
INNER JOIN Sales.OrderDetails AS d ON d.orderid = o.orderid
GROUP BY o.custid
HAVING SUM(d.qty * d.unitprice) > 10000
ORDER BY totalsalesamount DESC;

---------------------------------------------------------------------
-- Task 2: Total sales order and the employee processing the order.  
-- 
-- Write a SELECT statement against the Sales.Orders and Sales.OrderDetails tables and display 
-- the empid column and a calculated column representing the total sales amount. 
-- Filter the result to group only the rows with an order year 2008.
--
-- Execute the written statement and compare the results
---------------------------------------------------------------------
SELECT
	o.orderid,
	o.empid,
	SUM(d.qty * d.unitprice) as totalsalesamount
FROM Sales.Orders AS o
INNER JOIN Sales.OrderDetails AS d ON d.orderid = o.orderid
WHERE o.orderdate >= '20080101' AND o.orderdate < '20090101'
GROUP BY o.orderid, o.empid;

---------------------------------------------------------------------
-- Task 3: Total Sales higher than a value 
-- 
-- Copy the T-SQL statement in task 2 and modify it to apply an additional filter to retrieve 
-- only the rows that have a sales amount higher than $10,000.
-- Execute the written statement and compare the results that you got with the recommended result  
-- Apply an additional filter to show only employees with empid equal number 3.
-- Execute the written statement and review the results
-- Did you apply the predicate logic in the WHERE or in the HAVING clause? Which do you think is better? 
-- Why?
---------------------------------------------------------------------


-- Task 3: Solution with add having clause
-- The HAVING clause includes one or more conditions that should be TRUE for groups of records. 
-- It is like the WHERE clause of the GROUP BY clause.
SELECT
	o.orderid,
	o.empid,
	SUM(d.qty * d.unitprice) as totalsalesamount
FROM Sales.Orders AS o
INNER JOIN Sales.OrderDetails AS d ON d.orderid = o.orderid
WHERE o.orderdate >= '20080101' AND o.orderdate < '20090101'
GROUP BY o.orderid, o.empid
HAVING SUM(d.qty * d.unitprice) >= 10000;

-- Task 3: Solution with add predicate
-- A predicate is an expression that evaluates to TRUE, FALSE, or UNKNOWN. 
-- Predicates are used in the search condition of WHERE clauses and HAVING
SELECT
	o.orderid,
	o.empid,
	SUM(d.qty * d.unitprice) as totalsalesamount
FROM Sales.Orders AS o
INNER JOIN Sales.OrderDetails AS d ON d.orderid = o.orderid
WHERE 
	o.orderdate >= '20080101' AND o.orderdate <= '20090101'
	AND o.empid = 3
GROUP BY o.orderid, o.empid
HAVING SUM(d.qty * d.unitprice) >= 10000;


---------------------------------------------------------------------
-- Task 4
-- 
-- Write a SELECT statement to retrieve all customers who placed more than 25 orders 
-- and add information about the date of the last order and the total sales amount. 
-- Display the custid column from the Sales.Orders table and two calculated columns: 
-- lastorderdate based on the orderdate column and totalsalesamount based on the qty 
-- and unitprice columns in the Sales.OrderDetails table.
--
-- Execute the written statement and compare the results
---------------------------------------------------------------------
SELECT
	o.custid, 
	MAX(orderdate) AS lastorderdate, 
	SUM(d.qty * d.unitprice) AS totalsalesamount
FROM Sales.Orders AS o
INNER JOIN Sales.OrderDetails AS d ON d.orderid = o.orderid
GROUP BY o.custid 
HAVING COUNT(DISTINCT o.orderid) > 25;

