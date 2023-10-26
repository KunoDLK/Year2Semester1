-- Mod13 - Using Windows Ranking, CTE and Aggregate function in Partition By
-- Author: Mansha Nawaz

-- Useful Resources: 
-- Views in sql server: https://www.youtube.com/watch?v=VQpmOmZO2mo
-- Rank and Dense Rank in SQL Server: https://www.youtube.com/watch?v=5-La_uSNkKU
-- Rank and Over in SQL Server: https://www.youtube.com/watch?v=YdxyTMjpMMs
-- Partition By Row Number function: https://www.youtube.com/watch?v=cvrwOoGwgz8
-- sql server Aggregate function Over Clause: https://www.youtube.com/watch?v=0h2LZtaMXOg

-- 11 - Demonstration A - Creating Views and Windows with OVER

-- Useful Tip: Vertical Side by Side Query Windows: https://bertwagner.com/posts/splitting-it-up-easy-side-by-side-queries-in-ssms/

-- Step 1: Open a new query window to the TSQL database
USE TSQL;
GO

-- Step 2: Creating Windows with OVER

-- Setup SQL Views to support the demo

-- create a view Production.CategorizedProducts from products and catergories
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

-- create a view Sales.CategoryQtyYear from sales orders and catergories
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

-- Step 3: Using OVER with ordering
-- Rank products by price from high to low
-- Using view Production.CategorizedProducts from products and catergories
SELECT CatID, CatName, ProdName, UnitPrice,
	RANK() OVER(ORDER BY UnitPrice DESC) AS PriceRank
FROM Production.CategorizedProducts
ORDER BY PriceRank; 

-- Rank products by price in descending order in each category.
-- Note the ties.
-- Using view Production.CategorizedProducts from products and catergories
SELECT CatID, CatName, ProdName, UnitPrice,
	RANK() OVER(PARTITION BY CatID ORDER BY UnitPrice DESC) AS PriceRank
FROM Production.CategorizedProducts
ORDER BY CatID; 

-- Step 4: Use framing to create running total
-- Display a running total of quantity per product category. 
-- This uses framing to set boundaries at the start
-- of the set and the current row, for each partition
-- using view Sales.CategoryQtyYear from sales orders and catergories
SELECT Category, Qty, Orderyear,
	SUM(Qty) OVER (
		PARTITION BY category
		ORDER BY orderyear
		ROWS BETWEEN UNBOUNDED PRECEDING
		AND CURRENT ROW) AS RunningQty
FROM Sales.CategoryQtyYear;


-- Display a running total of quantity per year.
-- using view Sales.CategoryQtyYear from sales orders and catergories
SELECT Category, Qty, Orderyear,
	SUM(Qty) OVER (
		PARTITION BY orderyear
		ORDER BY Category
		ROWS BETWEEN UNBOUNDED PRECEDING
		AND CURRENT ROW) AS RunningQty
FROM Sales.CategoryQtyYear;

-- Show both side-by-side per category and per-year
-- using view Sales.CategoryQtyYear from sales orders and catergories
SELECT Category, Qty, Orderyear,
	SUM(Qty) OVER (PARTITION BY orderyear ORDER BY Category	ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningTotalByYear,
	SUM(Qty) OVER (PARTITION BY Category ORDER BY OrderYear	ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningTotalByCategory
FROM Sales.CategoryQtyYear
ORDER BY Orderyear, Category;

-- Step 5: Clean up
-- Optional: removing views in case we wish to re-run this demo.
IF OBJECT_ID('Production.CategorizedProducts','V') IS NOT NULL DROP VIEW Production.CategorizedProducts
IF OBJECT_ID('Sales.CategoryQtyYear','V') IS NOT NULL DROP VIEW Sales.CategoryQtyYear
GO
