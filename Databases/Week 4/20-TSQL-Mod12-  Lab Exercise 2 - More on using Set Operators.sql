---------------------------------------------------------------------
-- TSQL-Mod12 - Using Set Operators
-- Author: Mansha Nawaz

-- LAB 12 - Exercise 3
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1
-- 
-- Write a SELECT statement to retrieve the custid column from the Sales.Orders table. 
-- Filter the results to include only customers that bought more than 20 different products 
-- (based on the productid column from the Sales.OrderDetails table).
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 2
-- 
-- Write a SELECT statement to retrieve the custid column from the Sales.Orders table. 
-- Filter the results to include only customers from the country USA and exclude all customers 
-- from the previous (task 1) result. (Hint: Use the EXCEPT operator and the previous query.)
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------




---------------------------------------------------------------------
-- Task 3
-- 
-- Write a SELECT statement to retrieve the custid column from the Sales.Orders table. 
-- Filter only customers that have a total sales value greater than $10,000. 
-- Calculate the sales value using the qty and unitprice columns from the Sales.OrderDetails table.
--
-- Execute the written statement and review the results 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 4
-- 
-- Copy the T-SQL statement from task 2. Add the INTERSECT operator at the end of the statement. 
-- After the INTERSECT operator, add the T-SQL statement from task 3.
--
-- Execute the T-SQL statement and review the results 
-- Notice the total number of rows in the result.
--
-- Can you explain in business terms which customers are part of the result? 
---------------------------------------------------------------------



---------------------------------------------------------------------
-- Task 5
-- 
-- Copy the T-SQL statement from the previous task and add parentheses around the first two SELECT statements (from the beginning until the INTERSECT operator).
--
-- Execute the T-SQL statement and compare the results that you got with the recommended result shown in the file 75 - Lab Exercise 3 - Task 5 Result.txt. Notice the total number of rows in the result.
--
-- Is the result different than the result from task 4? Please explain why. 
--
-- What is the precedence among the set operators?
---------------------------------------------------------------------

