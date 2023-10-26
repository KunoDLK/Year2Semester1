-- TSQL ICA Demo  Mod13 - Using CTE Views, Windows Ranking and Partition By
-- Author: [Mansha Nawaz][23.10.2022]

-- Ideally provide several useful Sets of Data (Datasets).  Collections that provide useful 
-- views of data.  
-------------------------------------------------------------------------------------------
-- Overview: providing a TSQL Portfolio to demonstrating a range of TSQL querying skills for Employability 
-- Why Learn SQL in 2022 (Analyzing Real Job Data): https://www.dataquest.io/blog/why-learn-sql/
-- SQL For Data Science: A Comprehensive Beginners Guide: https://devopscube.com/sql-for-data-science/

-- Useful Resource Recommended: 

-- WiseOwl SQL Server Exercises:  https://www.wiseowl.co.uk/sql/exercises/

-- NEW: Microsoft Developer Network (MDN) - Get started with Transact-SQL programming
-- https://learn.microsoft.com/en-us/training/modules/get-started-transact-sql-programming/

-- NEW: Microsoft Developer Network (MDN) - SQL Server Training Guides 
-- https://learn.microsoft.com/en-us/training/browse/?products=sql-server

-- NEW: Microsoft Developer Network (MDN)  Azure SQL - cloud Based MS SQL Server - chargable service 
-- Azure SQL learrning Videos: 
-- https://learn.microsoft.com/en-us/shows/azure-sql-for-beginners/

-- Microsoft Developer introduction courses - Free
-- https://learn.microsoft.com/en-us/training/browse/

-- Video Resources: 
-- Demo A: What is Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- Demo B: What is Windows Ranking: https://www.youtube.com/watch?v=5-La_uSNkKU&feature=emb_logo 
-- Demo C: What is OVER Clause in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs&feature=emb_logo

-------------------------------------------------------------------------------------------
/* Overview of ICA Demo: I will be using TSQL to answer typical business questions with data from a server database. 

The following example shows individual order records along with the grand total of 
all sales, the annual revenue for the year of the order and the total customer revenue
for the customer that placed the order.


*/
-- ICA TSQL-Mod13 - Using CTE Views, Windows Ranking and Partition By
--ICA TSQL Demo 1 - Partition By Row Number function 
--ICA TSQL Demo 2 - Windows Ranking (or Windows Rank with partion)
--ICA TSQL Demo 3 - OVER Clause (or CTE Function with Over)
--ICA TSQL Demo 4 - Writing Aggregate function in Partition By

-- Ideally utlise SQL Views and/or CTE for your Demos but use tables if you still need practice. 


-- setup Database for usage
USE AdventureWorks2019;
GO
ALTER AUTHORIZATION ON DATABASE::AdventureWorks2019 TO sa; 

-------------------------------------------------------------------------------------------
-- Setup Views
-- Overview of business questions or Task for Demo

-- The following example shows individual order records along with the grand total of 
-- all sales, the annual revenue for the year of the order and the total customer revenue
-- for the customer that placed the order.


-- ICA TSQL Demo 1 - TSQL - Partition By Row Number function 
-- Overview of business questions or Task for Demo

-- the following demo also incorprates some of the features reguested for the additonal demos 
-- to includes aggregate function, over and partition by

-- Do note we also fewer demos if you are covering the general TSQL topic 

SELECT YEAR(OrderDate), SalesOrderID, CustomerID, TotalDue,
		SUM(TotalDue) OVER() AS 'Total Business Sales', 
		SUM(TotalDue) OVER (PARTITION BY YEAR(OrderDate)) AS 'Total Annual Sales',
		SUM(TotalDue) OVER (PARTITION BY CustomerID) AS 'Total Customer Sales'
FROM Sales.SalesOrderHeader
ORDER BY CustomerID, YEAR(OrderDate)

-- ICA TSQL Demo A with comments - TSQL - Partition By Row Number function 
SELECT YEAR(OrderDate), SalesOrderID, CustomerID, TotalDue,

		SUM(TotalDue) OVER() AS 'Total Business Sales', 
-- The above expression produces a grand total across the whole data set. 
-- There is no partitioning of the data. 
-- This is why every record shows the same value for the “Total Business Sales” column.

		SUM(TotalDue) OVER (PARTITION BY YEAR(OrderDate)) AS 'Total Annual Sales',
-- The above expression instructs SQL Server to group (partition) the data by the YEAR of the orderdate
-- and produce an annual sales total. You will see that this value is the same for each common year.

		SUM(TotalDue) OVER (PARTITION BY CustomerID) AS 'Total Customer Sales'


FROM Sales.SalesOrderHeader
ORDER BY CustomerID, YEAR(OrderDate)


-- ICA TSQL Demo 2 - TSQL - Windows Ranking (or Windows Rank with partion)
-- Overview of business questions or Task for Demo


-------------------------------------------------------------------------------------------
-- ICA TSQL Demo 3 - TSQL - OVER Clause (or CTE Function with Over)
-- Overview of business questions or Task for Demo
-- 




-------------------------------------------------------------------------------------------
--ICA TSQL Demo 4 - Writing Aggregate function in Partition By
-- Overview of business questions or Task for Demo




-------------------------------------------------------------------------------------------
-- It is considered good practice to also provide the following ------------------
-- Assessment team use this section to compensate or round up  

--  optional: Examples for consderation ------------------------------------------

-- Demo A: Running Totals With The ORDER BY Sub Clause
-- The ORDER BY sub clause enables a running total to be generated.
-- The following example shows the monthly revenue for each month, along with the running
-- total for the year.

SELECT SalesOrderID, ProductID, OrderQty
    ,SUM(OrderQty) OVER(PARTITION BY SalesOrderID) AS 'Total Quantity Ordered'
    ,AVG(OrderQty) OVER(PARTITION BY SalesOrderID) AS 'Average Quantity Ordered'
    ,COUNT(OrderQty) OVER(PARTITION BY SalesOrderID) AS 'Number Of Items On Order'
    ,MIN(OrderQty) OVER(PARTITION BY SalesOrderID) AS 'Lowest Quantity Ordered'
    ,MAX(OrderQty) OVER(PARTITION BY SalesOrderID) AS 'Highest Quantity Ordered'
FROM Sales.SalesOrderDetail 
-- Note we see that the totals for each month are different and the fourth column shows 
-- the total growing through the months of the year, but the running total starts again 
-- when a new year starts.
-- If we look at December 2011, the value 14155699.525 is the total of all 12 months for 2011.
-- If we look at June 2011, the value 1074117.4188 is the total for May and June 2011.




--  optional: Examples attempted but are incomplete or generate errors  ----------
