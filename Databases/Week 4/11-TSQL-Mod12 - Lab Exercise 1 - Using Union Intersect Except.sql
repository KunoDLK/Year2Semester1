---------------------------------------------------------------------
-- TSQL-Mod12 - Using Set Operators
-- Author: Mansha Nawaz

-- LAB 12 - Exercise 1
---------------------------------------------------------------------

USE TSQL;
GO


---------------------------------------------------------------------
-- Task 1 
-- 
-- Write a SELECT statement to return the productid and productname columns from the Production.Products table. 
-- Filter the results to include only products that have a categoryid value 4.

-- Execute the written statement and review the results.
-- Remember the number of rows in the result.
---------------------------------------------------------------------


---------------------------------------------------------------------
-- Task 2 
-- 
-- Write a SELECT statement to return the productid and productname columns from the Production.Products table. 
-- Filter the results to include only products that have a total sales amount of more than $50,000. 
-- For the total sales amount, you will need to query the Sales.OrderDetails table and aggregate all order line 
-- values (qty * unitprice) for each product.
--
-- Execute the written statement and review the results.
-- Remember the number of rows in the result.
---------------------------------------------------------------------




---------------------------------------------------------------------
-- Task 3
-- 
-- Write a SELECT statement that uses the UNION operator to retrieve the productid and productname columns 
-- from the T-SQL statements in task 1 and task 2.
--
-- Execute the written statement and compare the results that you got with the desired results.
--
-- What is the total number of rows in the result? 
-- If you compare this number with an aggregate value of the number of rows from task 1 and task 2.
-- is there any difference? 
--
-- Copy the T-SQL statement and modify it to use the UNION ALL operator. 
--
-- Execute the written statement and review to ensure you obtain the desired results. 
--
-- What is the total number of rows in the result? 
-- What is the difference between the UNION and UNION ALL operators?
---------------------------------------------------------------------

-- union example



-- Note how many rows are returned? 12


-- union all example


-- Note how many rows are returned?  14




---------------------------------------------------------------------
-- Task 4 
-- 
-- Use the solution from Task 3 and Write a SELECT statement that uses the INTERSECT operator to retrieve the productid 
-- and productname columns from the T-SQL statements in task 3.

-- intersect example


-- Note how many rows are returned? 2


---------------------------------------------------------------------
-- Task 5 
-- 
-- Use the solution from Task 3 and Write a SELECT statement that uses the EXCEPT operator to retrieve the productid 
-- and productname columns from the T-SQL statements in task 3.

-- EXCEPT example


-- Note how many rows are returned?  8



---------------------------------------------------------------------
-- Task 6
-- 
-- Write a SELECT statement to retrieve the custid and contactname columns from the Sales.Customers table. 
-- Display the top 10 customers by sales amount for June 2008 and display the top 10 customers by 
-- sales amount for February 2008 (Hint: Write two SELECT statements each joining Sales.Customers 
-- and ?Sales.OrderValues and use the appropriate set operator.)
--
-- Execute the T-SQL code and review the results that you got with the desired results 
-- shown in Lab Exercise taskfdone earlier. 
---------------------------------------------------------------------

-- note the following wont relturn any results since the order dates are all June 2008 
-- and none in July 2008

