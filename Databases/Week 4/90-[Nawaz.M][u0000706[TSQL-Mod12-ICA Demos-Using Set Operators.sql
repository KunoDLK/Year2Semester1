-- ICA TSQL-Mod12 - Using Set Operators
-- Author: [Mansha Nawaz][09.10.2022]

-- Ideally provide several useful Sets of Data (Datasets).  Collections that provide useful 
-- views of data. I have only provided one of each sut scope more for better grades.
-- my simple pattern obtains a PASS. Sever on each helps you obtain better grades. 
-------------------------------------------------------------------------------------------
-- Overview: providing a TSQL Portfolio to demonstrating a range of TSQL querying skills for Employability 
-- Why Learn SQL in 2022 (Analyzing Real Job Data): https://www.dataquest.io/blog/why-learn-sql/
-- SQL For Data Science: A Comprehensive Beginners Guide: https://devopscube.com/sql-for-data-science/

-- Useful Resource Recommended: 



-------------------------------------------------------------------------------------------
/* Overview of ICA Demo: I will be using TSQL to answer typical business questions with data from a server database. 




*/


-- ICA TSQL-Mod12 - Using Set Operators
--ICA TSQL Demo A - TSQL - Using UNION 
--ICA TSQL Demo B - TSQL - using UNION ALL
--ICA TSQL Demo C - TSQL - Using INTERSECT
--ICA TSQL Demo D - TSQL - Using EXCEPT
--ICA TSQL Demo E - TSQL - Create inline Table-valued Function


-- setup Database for usage
USE AdventureWorksLT2019;
GO
ALTER AUTHORIZATION ON DATABASE::AdventureWorksLT2019 TO sa; 

-------------------------------------------------------------------------------------------
-- Setup Views
-- Overview of business questions or Task for Demo
-- creating a customer view and employees view for the using Set Operators 

CREATE VIEW [SalesLT].[Customers]
as
select distinct firstname,lastname
from saleslt.customer
where lastname >='m'
or customerid=3;
GO

CREATE VIEW [SalesLT].[Employees]
as
select distinct firstname,lastname
from saleslt.customer
where lastname <='m'
or customerid=3;
GO

--ICA TSQL Demo A - TSQL - Using UNION 

-- Union example
-- Overview of business questions or Task for Demo
-- Combining distinct employees or distinct customers.
SELECT FirstName, LastName
FROM SalesLT.Employees
UNION
SELECT FirstName, LastName
FROM SalesLT.Customers
ORDER BY LastName;
-- 440 records returned

--ICA TSQL Demo B - TSQL - using UNION ALL
-- Overview of business questions or Task for Demo
-- combining ALL employees and customers
SELECT FirstName, LastName
FROM SalesLT.Employees
UNION ALL
SELECT FirstName, LastName
FROM SalesLT.Customers
ORDER BY LastName;
-- 441 records returned

-------------------------------------------------------------------------------------------
--ICA TSQL Demo C - TSQL - Using INTERSECT
-- Overview of business questions or Task for Demo
-- 
SELECT FirstName, LastName
FROM SalesLT.Customers
INTERSECT
SELECT FirstName, LastName
FROM SalesLT.Employees;



-------------------------------------------------------------------------------------------
--ICA TSQL Demo D - TSQL - Using EXCEPT
-- Overview of business questions or Task for Demo

-- Customers and Employees 
-- The SQL Server (Transact-SQL) EXCEPT operator is used to return all rows in the 
-- first SELECT statement that are not returned by the second SELECT statement. 
-- Each SELECT statement will define a dataset. The EXCEPT operator will retrieve 
-- all records from the first dataset and then remove from the results all records 
-- from the second dataset.

SELECT FirstName, LastName
FROM SalesLT.Customers
EXCEPT
SELECT FirstName, LastName
FROM SalesLT.Employees;
-- 103 records returned
-------------------------------------------------------------------------------------------

--ICA TSQL Demo E - TSQL - Create inline Table-valued Function

-- not attempted - see lesson demo for example 







-- It is considered good practice to also provide the following ------------------
-- Assessment team use this section to compensate or round up  

--  optional: Examples for consderation ------------------------------------------



--  optional: Examples attempted but are incomplete or generate errors  ----------
