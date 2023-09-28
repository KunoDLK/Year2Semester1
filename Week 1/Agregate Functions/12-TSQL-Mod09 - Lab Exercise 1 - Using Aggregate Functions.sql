---------------------------------------------------------------------
-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: Mansha Nawaz

-- TSQL-Mod09 - Lab Exercise 1 - Using Aggregate Functions

---------------------------------------------------------------------
-- Task 2
-- Write a SELECT statement that will return groups of customers that made a purchase. 
-- The SELECT clause should include the custid column from the Sales.Orders table and 
-- the contactname column from the Sales.Customers table. Group by both columns and 
-- filter only the orders from the sales employee whose empid equals five.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------
-- Step 1: use the appropriate database - TSQL
---------------------------------------------------------------------
USE TSQL;
-- make sure you work on the correct Database sample. 
ALTER AUTHORIZATION ON DATABASE::TSQL TO sa;
-- The sample Databases are defaulted to your Module Leaders server/passowrd. 
-- first time users will need to reassign access (authorisation) to the
-- default System Adiministator - the person logged in which will be you! 
GO

-- Step 2: view the data from the appropriate table: Sales.Orders and Sales.Customers  
-- note the relationship: each Customer can have many Orders. Order belongs to one customer. 

-- Step 3: Join tables on key Orders.custid and Customers.custid

-- Step 4: Group By custid and contactname

-- Step 5: provide for empid = 5





---------------------------------------------------------------------
-- Task 3 -- error
---------------------------------------------------------------------
-- You  should use your solution from task 2. 
-- Copy the T-SQL statement in task 2 and modify it to include the city column 
-- from the Sales.Customers table in the SELECT clause. 
-- Execute the query. You will get an error. What is the error message? Why?
-- What column is cannot be aggregated and thereby generating an error? 
---------------------------------------------------------------------

-- module leader model solution using alias table names: orders o and cusstomer c
SELECT
	o.custid, c.contactname, c.city
FROM Sales.Orders AS o
INNER JOIN Sales.Customers AS c ON c.custid = o.custid
WHERE o.empid = 5
GROUP BY o.custid, c.contactname;



-- Task 3 -- error corrected
-- Correct the query so that it will execute properly.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 



---------------------------------------------------------------------
-- Task 4 
-- Write a SELECT statement that will return groups of rows based on the custid 
-- column and a calculated column orderyear representing the order year based on 
-- the orderdate column from the Sales.Orders table. 
-- Filter the results to include only the orders from the sales employee whose empid equal five.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------

---------------------------------------------------------------------
-- Task 5 
-- 
-- Write a SELECT statement to retrieve groups of rows based on the categoryname column in
-- the Production.Categories table. Filter the results to include only the product categories
-- that were ordered in the year 2008.
-- Provide your TSQL Solution (even if with errors) and review the model solution. 
---------------------------------------------------------------------


----------------------------------------------------------
