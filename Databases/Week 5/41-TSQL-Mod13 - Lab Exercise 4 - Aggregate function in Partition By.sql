---------------------------------------------------------------------
-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg

-- LAB 13 - Exercise 3 
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1
-- 
-- Write a SELECT statement to retrieve the custid, orderid, orderdate, and val columns from the
-- Sales.OrderValues view. 
-- Add a calculated column named percoftotalcust that contains a percentage value of each 
-- order sales amount compared to the total sales amount for that customer. 
--
-- Execute the written statement and review the results
---------------------------------------------------------------------




---------------------------------------------------------------------
-- Task 2
-- 
-- Copy the previous SELECT statement and modify it by adding a new calculated column named runval. 
-- This column should contain a running sales total for each customer based on order date, 
-- using orderid as the tiebreaker.
--
-- Execute the written statement and review the results
---------------------------------------------------------------------





---------------------------------------------------------------------
-- Task 3
-- 
-- Copy the SalesMonth2008 CTE in the last task in exercise 2. Write a SELECT statement to retrieve
-- the monthno and val columns. Add two calculated columns:
--  avglast3months. This column should contain the average sales amount for last three months before
-- the current month using a window aggregate function. You can assume that there are no missing months.
--  ytdval. This column should contain the cumulative sales value up to the current month.
--
-- Execute the written statement and review the results
---------------------------------------------------------------------




