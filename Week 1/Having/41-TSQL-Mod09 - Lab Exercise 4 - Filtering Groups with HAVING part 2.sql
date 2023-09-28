---------------------------------------------------------------------
-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: Mansha Nawaz

-- TSQL-Mod09 - Lab Exercise 4 - Filtering Groups with HAVING
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
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 2: Total sales order and the employee processing the order.  
-- 
-- Write a SELECT statement against the Sales.Orders and Sales.OrderDetails tables and display 
-- the empid column and a calculated column representing the total sales amount. 
-- Filter the result to group only the rows with an order year 2008.
--
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 3: Total Sales higher than a value 
-- 
-- Copy the T-SQL statement in task 2 and modify it to apply an additional filter to retrieve 
-- only the rows that have a sales amount higher than $10,000.
-- Execute the written statement and compare the results that you got with the recommended result  
-- Apply an additional filter to show only employees with empid equal number 3.
--
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
-- 
-- Did you apply the predicate logic in the WHERE or in the HAVING clause? 
-- Which do you think is better? -- Why?
---------------------------------------------------------------------

-- -- Task 3: - with add having clause
-- The HAVING clause includes one or more conditions that should be TRUE for groups of records. 
-- It is like the WHERE clause of the GROUP BY clause.




-- Task 3: Solution with add predicate
-- A predicate is an expression that evaluates to TRUE, FALSE, or UNKNOWN. 
-- Predicates are used in the search condition of WHERE clauses and HAVING



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



