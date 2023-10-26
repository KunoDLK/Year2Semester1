---------------------------------------------------------------------
-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg


-- LAB 13 - Exercise 1
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1
-- 
-- Write a SELECT statement to retrieve the orderid, orderdate, and val columns 
-- as well as a calculated column named rowno from the view Sales.OrderValues. 
-- Use the ROW_NUMBER function to return rowno. Order the row numbers by the 
-- orderdate column.
--
-- Execute the written statement and review the results
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 2
-- 
-- Copy the previous T-SQL statement and modify it by including an additional 
-- column named rankno. To create rankno, use the RANK function, with the 
-- rank order based on the orderdate column.
--
-- Execute the modified statement and review the results.
-- Notice the different values in the rowno and rankno columns for some of the rows.
-- What is the difference between the RANK and ROW_NUMBER functions?
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 3
-- 
-- Write a SELECT statement to retrieve the orderid, orderdate, custid, and 
-- val columns as well as a calculated column named orderrankno from the 
-- Sales.OrderValues view. The orderrankno column should display the rank per 
-- each customer independently, based on val ordering in descending order. 
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 4
-- 
-- Write a SELECT statement to retrieve the custid and val columns from the 
-- Sales.OrderValues view. Add two calculated columns: 
--  orderyear as a year of the orderdate column, orderrankno as a rank number, 
-- partitioned by the customer and order year, and ordered by the order value 
-- in descending order. 
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 5
-- 
-- Copy the previous query and modify it to filter only orders with the first two 
-- ranks based on the orderrankno column.
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------

