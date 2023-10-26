---------------------------------------------------------------------
-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg

-- LAB 13 - Exercise 2
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1
-- 
-- Define a CTE named OrderRows based on a query that retrieves the orderid, orderdate, 
-- and val columns from the Sales.OrderValues view. Add a calculated column named rowno 
-- using the ROW_NUMBER function, ordering by the orderdate and orderid columns. 
--
-- Write a SELECT statement against the CTE and use the LEFT JOIN with the same CTE to 
-- retrieve the current row and the previous row based on the rowno column. 
-- Return the orderid, orderdate, and val columns for the current row and the val column
-- from the previous row as prevval. Add a calculated column named diffprev to show the 
-- difference between the current val and previous val.
--
-- Execute the T-SQL code and reviw the results
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 2
-- 
-- Write a SELECT statement that uses the LAG function to achieve the same results as the query 
-- in the previous task. The query should not define a CTE.
--
-- Execute the written statement and review the results
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 3
-- 
-- Define a CTE named SalesMonth2007 that creates two columns: monthno (the month number of the 
-- orderdate column) and val (aggregated val column). 
-- Filter the results to include only the order year 2007 and group by monthno.
--
-- Write a SELECT statement that retrieves the monthno and val columns from the CTE 
-- and adds three calculated columns: avglast3months. 
-- This column should contain the average sales amount for last three months before the current month. 
-- (Use multiple LAG functions and divide the sum by three.) 
-- You can assume that there’s a row for each month in the CTE.diffjanuary. 
-- This column should contain the difference between the current val and the January val.
-- (Use the FIRST_VALUE function.) 
-- nextval. This column should contain the next month value of the val column.
--
-- Execute the written statement and review the results

-- Notice that the average amount for last three months is not correctly computed because the 
-- total amount for the first two months is divided by three. 
-- You will practice how to do this correctly in the next exercise.
---------------------------------------------------------------------
