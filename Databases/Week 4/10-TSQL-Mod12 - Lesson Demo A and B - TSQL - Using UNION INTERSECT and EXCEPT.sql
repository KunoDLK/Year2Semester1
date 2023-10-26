-- TSQL-Mod12 - Using Set Operators
-- Author: Mansha Nawaz

-- TSQL-Mod12 - 11 - Demonstration A.sql - TSQL Using UNION INTERSECT & EXCEPT

-- Youtube: SQL Intersect, Union, Union All, Minus, and Except https://www.youtube.com/watch?v=bL5UX-p1wMc
-- Youtube: Union and union all in sql server Part 17 https://www.youtube.com/watch?v=9w5uRCFOiTo


-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- TSQL- Demo - Using UNION

-- Step 2: Using UNION ALL

-- Select this query and execute it to show the use of
-- UNION ALL to return all rows from both tables
-- including duplicates
SELECT country, region, city FROM HR.Employees
UNION ALL -- 100 rows
SELECT country, region, city FROM Sales.Customers;

-- Step 3: Using UNION

-- Select this query and execute it to show the use of
-- UNION to return all rows from both tables
-- excluding duplicates
SELECT country, region, city FROM HR.Employees 
UNION 
SELECT country, region, city FROM Sales.Customers; 



-- TSQL- Demo - Using INTERSECT
-- Youtube: SQL Intersect, Union, Union All, Minus, and Except https://www.youtube.com/watch?v=bL5UX-p1wMc
-- Youtube: Union and union all in sql server Part 17 https://www.youtube.com/watch?v=9w5uRCFOiTo

-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Step 2: Using INTERSECT
-- Select this query and execute it to show the use of
-- INTERSECT to return only rows found in both tables
SELECT country, region, city FROM HR.Employees
INTERSECT -- 3 distinct rows 
SELECT country, region, city FROM Sales.Customers;


-- TSQL- Demo - Using INTERSECT
-- Youtube: SQL Intersect, Union, Union All, Minus, and Except https://www.youtube.com/watch?v=bL5UX-p1wMc
-- Youtube: Union and union all in sql server Part 17 https://www.youtube.com/watch?v=9w5uRCFOiTo

-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Step 3: Using EXCEPT
-- Return only rows from left table (Hr.Employees)
SELECT country, region, city FROM HR.Employees
EXCEPT 
SELECT country, region, city FROM Sales.Customers;

--Reverse position of tables, return only rows from Sales.Customers
SELECT country, region, city FROM Sales.Customers
EXCEPT 
SELECT country, region, city FROM HR.Employees;
