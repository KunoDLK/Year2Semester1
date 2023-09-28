-- TSQL-Mod09 - Grouping and Aggregating Data
-- Author: Mansha Nawaz

-- 21-TSQL-Mod09 - Lecture Demo B - Using the GROUP BY Clause - AW2019

-- Step 1: Using GROUP BY
-- Change to AdventureWorks database

USE AdventureWorks2019;
-- also works with Advetureworks2016
GO

-- Step 2a: Using GROUP BY
-- Select this query and execute it to
-- show orders by Sales Person from low to high count
-- (this is the source data before groups created)

-- step 1:Review the table data
SELECT SalesPersonID 
FROM Sales.SalesOrderHeader;

-- step 2: Select a particular set of records. 
SELECT SalesPersonID 
FROM Sales.SalesOrderHeader
Where SalesPersonID = 279
-- We now know there are 429 sales order records for personid 279

-- step 3: Count the number of records for each salesperson.
--         This is the solution to this exercise!    
SELECT SalesPersonID, COUNT(*) AS Total_Orders
FROM Sales.SalesOrderHeader
GROUP BY SalesPersonID
ORDER BY Total_Orders asc;

-- step 4: check how many sales orders salesperson 279 has. 
-- This validates our check in step 2!
SELECT SalesPersonID, COUNT(*) AS Total_Orders
FROM Sales.SalesOrderHeader
Where SalesPersonID = 279
GROUP BY SalesPersonID
ORDER BY Total_Orders asc;


-- Step 2b: Select this query and execute it to
-- show customer orders per customer and per year 
-- for Sales Person 285 (per previous query)
SELECT CustomerID, YEAR(OrderDate) AS [year], COUNT(*) AS Total_Orders
FROM Sales.SalesOrderHeader
WHERE SalesPersonID = 285
GROUP BY CustomerID, YEAR(OrderDate);

-- Step 3: Workflow of grouping
-- Source queries for workflow slide:
SELECT SalesOrderID, SalesPersonID, CustomerID
FROM Sales.SalesOrderHeader;

SELECT SalesOrderID, SalesPersonID, CustomerID
FROM Sales.SalesOrderHeader
WHERE CustomerID IN (29777, 30010);

SELECT SalesPersonID, COUNT(*)
FROM Sales.SalesOrderHeader
WHERE CustomerID IN (29777, 30010)
GROUP BY SalesPersonID;

-- Step 4a: Using Aggregates with GROUP BY
-- Show an aggregate on the column used to group
SELECT CustomerID, COUNT(*) AS Total_Orders
FROM Sales.SalesOrderHeader
GROUP BY CustomerID;

-- Step 4b: Show an aggregate on a column not in GROUP BY list
SELECT ProductID, MAX(OrderQty) AS largest_order
FROM Sales.SalesOrderDetail
GROUP BY productid;