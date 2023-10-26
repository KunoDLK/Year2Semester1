---------------------------------------------------------------------
-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg

-- LAB 13 - Exercise 2 - Solutions
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

WITH OrderRows AS
(
	SELECT 
		orderid, 
		orderdate,
		ROW_NUMBER() OVER (ORDER BY orderdate, orderid) AS rowno,
		val
	FROM Sales.OrderValues
)
SELECT 
	o.orderid,
	o.orderdate,
	o.val,
	o2.val as prevval,
	o.val - o2.val as diffprev
FROM OrderRows AS o
LEFT OUTER JOIN OrderRows AS o2 ON o.rowno = o2.rowno + 1;


---------------------------------------------------------------------
-- Task 2
-- 
-- Write a SELECT statement that uses the LAG function to achieve the same results as the query 
-- in the previous task. The query should not define a CTE.
--
-- Execute the written statement and review the results
---------------------------------------------------------------------

SELECT 
	orderid, 
	orderdate,
	val,
	LAG(val) OVER (ORDER BY orderdate, orderid) AS prevval,
	val - LAG(val) OVER (ORDER BY orderdate, orderid) AS diffprev
FROM Sales.OrderValues;


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
WITH SalesMonth2007 AS
(
	SELECT
		MONTH(orderdate) AS monthno,
		SUM(val) AS val
	FROM Sales.OrderValues
	WHERE orderdate >= '20070101' AND orderdate < '20080101'
	GROUP BY MONTH(orderdate)
)
SELECT
	monthno,
	val,
	(LAG(val, 1, 0) OVER (ORDER BY monthno) + LAG(val, 2, 0) OVER (ORDER BY monthno) + LAG(val, 3, 0) OVER (ORDER BY monthno)) / 3 AS avglast3months,
	val - FIRST_VALUE(val) OVER (ORDER BY monthno ROWS UNBOUNDED PRECEDING) AS diffjanuary,
	LEAD(val) OVER (ORDER BY monthno) AS nextval
FROM SalesMonth2007;


