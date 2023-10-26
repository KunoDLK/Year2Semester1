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

-- Do note we also fewer demos if you are covering the general TSQL topic in a more detailed demonstration.  

-- setup Database for usage
USE [db];
GO
ALTER AUTHORIZATION ON DATABASE::[DB] TO sa; 

-------------------------------------------------------------------------------------------
-- Setup Views
-- Overview of business questions or Task for Demo




-- ICA TSQL Demo 1 - TSQL - Partition By Row Number function 
-- Overview of business questions or Task for Demo




-- ICA TSQL Demo 2 - TSQL - Windows Ranking (or Windows Rank with partion)
-- Overview of business questions or Task for Demo




-------------------------------------------------------------------------------------------
-- ICA TSQL Demo 3 - TSQL - OVER Clause (or CTE Function with Over)
-- Overview of business questions or Task for Demo


-------------------------------------------------------------------------------------------
--ICA TSQL Demo 4 - Writing Aggregate function in Partition By
-- Overview of business questions or Task for Demo


-------------------------------------------------------------------------------------------
-- It is considered good practice to also provide the following ------------------
-- Assessment team use this section to compensate or round up  

--  optional: Examples for consderation ------------------------------------------



--  optional: Examples attempted but are incomplete or generate errors  ----------
