-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg

-- 21 Demonstration B - Using Windows Ranking, Offset, and Aggregate Functions

-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Task 1: Using Window Rank Aggregate Functions

-- RANK demo - ranking unitprice
SELECT  productid, productname, unitprice,
        RANK() OVER ( ORDER BY unitprice DESC ) AS pricerank
FROM    Production.Products
ORDER BY pricerank ;

-- Aggregate Partician by Demo - sum of quantities as a total percentage per customer
-- Show SUM computed per partition
-- Note: no need for ORDER BY within OVER() in this example
SELECT  custid, ordermonth, qty,
        SUM(qty) OVER ( PARTITION BY custid ) AS totalpercust
FROM    Sales.CustOrders ;




-- Task 2: Setup views for demo

-- View for Catergories and their Products as Production.CategorizedProducts
IF OBJECT_ID('Production.CategorizedProducts','V') IS NOT NULL DROP VIEW Production.CategorizedProducts
GO
CREATE VIEW Production.CategorizedProducts
AS
    SELECT  Production.Categories.categoryid AS CatID,
			Production.Categories.categoryname AS CatName,
            Production.Products.productname AS ProdName,
            Production.Products.unitprice AS UnitPrice
    FROM    Production.Categories
            INNER JOIN Production.Products ON Production.Categories.categoryid=Production.Products.categoryid;
GO

-- View for Categoryies & Products - Sales.CategoryQtyYear
IF OBJECT_ID('Sales.CategoryQtyYear','V') IS NOT NULL DROP VIEW Sales.CategoryQtyYear
GO
CREATE VIEW Sales.CategoryQtyYear
AS
SELECT  c.categoryname AS Category,
        SUM(od.qty) AS Qty,
        YEAR(o.orderdate) AS Orderyear
FROM    Production.Categories AS c
        INNER JOIN Production.Products AS p ON c.categoryid=p.categoryid
        INNER JOIN Sales.OrderDetails AS od ON p.productid=od.productid
        INNER JOIN Sales.Orders AS o ON od.orderid=o.orderid
GROUP BY c.categoryname, YEAR(o.orderdate);
GO

-- View for Employees & their total sales - Sales.OrdersByEmployeeYear
IF OBJECT_ID('Sales.OrdersByEmployeeYear','V') IS NOT NULL DROP VIEW Sales.OrdersByEmployeeYear
GO
CREATE VIEW Sales.OrdersByEmployeeYear
AS
SELECT emp.empid AS employee, YEAR(ord.orderdate) AS orderyear, SUM(od.qty * od.unitprice) AS totalsales
FROM HR.Employees AS emp
	JOIN Sales.Orders AS ord ON emp.empid = ord.empid
	JOIN Sales.OrderDetails AS od ON ord.orderid = od.orderid
GROUP BY emp.empid, YEAR(ord.orderdate)
GO



-- Step 5: Side-by-side use of aggregate functions with OVER()
-- Using View for Catergories and their Products - Production.CategorizedProducts
SELECT CatID, CatName, ProdName, UnitPrice,
	SUM(UnitPrice) OVER(PARTITION BY CatID) AS Total,
	AVG(UnitPrice) OVER(PARTITION BY CatID) AS Average,
	COUNT(UnitPrice) OVER(PARTITION BY CatID) AS ProdsPerCat
FROM Production.CategorizedProducts
ORDER BY CatID; 

-- Step 6: Compare RANK with DENSE_RANK to show treatment of ties
-- Note the gaps in RANK not present in DENSE_RANK
-- Using View for Catergories and their Products - Production.CategorizedProducts
SELECT CatID, CatName, ProdName, UnitPrice,
	RANK() OVER(PARTITION BY CatID ORDER BY UnitPrice DESC) AS PriceRank,
	DENSE_RANK() OVER(PARTITION BY CatID ORDER BY UnitPrice DESC) AS DensePriceRank
FROM Production.CategorizedProducts
ORDER BY CatID; 

-- Step 7: Row_Number
-- Using View for Catergories and their Products - Production.CategorizedProducts
SELECT CatID, CatName, ProdName, UnitPrice,
	ROW_NUMBER() OVER(PARTITION BY CatID ORDER BY UnitPrice DESC) AS RowNumber
FROM Production.CategorizedProducts
ORDER BY CatID; 

-- Step 8: NTILE to create 7 groups
-- Using View for Catergories and their Products - Production.CategorizedProducts
SELECT CatID, CatName, ProdName, UnitPrice,
	NTILE(7) OVER(PARTITION BY CatID ORDER BY UnitPrice DESC) AS NT
FROM Production.CategorizedProducts
ORDER BY CatID, NT; 



-- Step 9: Offset Functions
-- LAG to compare one year's sales to last. 
-- Note partitioning by employee
-- Usibg view for Employees & their total sales - Sales.OrdersByEmployeeYear
SELECT employee, orderyear, totalsales AS currentsales,
      LAG(totalsales, 1,0) OVER (PARTITION BY employee ORDER BY orderyear) AS previousyearsales
  FROM Sales.OrdersByEmployeeYear
ORDER BY employee, orderyear;
GO


--Step 10: Use FIRST_VALUE to compare current row to first in partition
-- Usibg view for Employees & their total sales - Sales.OrdersByEmployeeYear
SELECT employee
      ,orderyear
      ,totalsales AS currentsales,
      (totalsales - FIRST_VALUE(totalsales) OVER (PARTITION BY employee ORDER BY orderyear)) AS salesdiffsincefirstyear
  FROM TSQL.Sales.OrdersByEmployeeYear
ORDER BY employee, orderyear;
GO

-- Step 11: Clean up
IF OBJECT_ID('Production.CategorizedProducts','V') IS NOT NULL DROP VIEW Production.CategorizedProducts
IF OBJECT_ID('Sales.CategoryQtyYear','V') IS NOT NULL DROP VIEW Sales.CategoryQtyYear
IF OBJECT_ID('Sales.OrdersByEmployeeYear','V') IS NOT NULL DROP VIEW Sales.OrdersByEmployeeYear
GO

