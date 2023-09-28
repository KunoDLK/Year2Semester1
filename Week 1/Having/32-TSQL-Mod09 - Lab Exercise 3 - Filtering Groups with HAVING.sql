---------------------------------------------------------------------
-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: [insert name][student#][date]

-- TSQL-Mod09 - Lab Exercise 3 - Filtering Groups with HAVING
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1: 
-- A junior analyst prepared a T-SQL statement to retrieve the number of orders 
-- and the number of customers for each order year. 

-- Observe the provided T-SQL statement and execute it:
-- Observe the result and notice that the number of orders is the same as the number of customers. Why?
-- Correct the T-SQL statement to show the correct number of customers that placed an order for each year.
-- Execute the written statement and review the results. 
---------------------------------------------------------------------

-- Step 1:select sales order - and identify the fields of interest.  
SELECT orderid, custid, orderdate, YEAR(orderdate)  
FROM Sales.Orders 
-- Step 2: count the number of orders and customers 
SELECT
	YEAR(orderdate) AS orderyear, 
	COUNT(orderid) AS nooforders, 
	COUNT(custid) AS noofcustomers
FROM Sales.Orders 
GROUP BY YEAR(orderdate);

---------------------------------------------------------------------
-- Task 2
-- Write a SELECT statement to retrieve the number of customers based on the first letter of the 
-- values in the contactname column from the Sales.Customers table. Add an additional column to 
-- show the total number of orders placed by each group of customers. Use the aliases firstletter, 
-- noofcustomers and nooforders. Order the result by the firstletter column.
-- Execute the written statement and review the model solution. 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 3
-- 
-- Copy the T-SQL statement in exercise 1, task 4, and modify to include the following information 
-- about for each product category: total sales amount, number of orders, and average sales amount per order. 
-- Use the aliases totalsalesamount, nooforders, and avgsalesamountperorder, respectively.
--
-- Execute the written statement and review the model solution. 
---------------------------------------------------------------------


