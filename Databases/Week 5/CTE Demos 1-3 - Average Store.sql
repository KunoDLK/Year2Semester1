-- CTE Demos 1-5 - M.Nawaz

-- Main demos of interest are [1-3]
-- Still working on demos [4-5]

-- CTE Demos 1 
-- creating test table orders for the Demo. 
USE [CTE-Orders]
GO

INSERT INTO [dbo].[orders]
           ([id]
           ,[date]
           ,[customer_id]
           ,[store]
           ,[employee_id]
           ,[amount])
     VALUES
           (<id, int,>
           ,<date, date,>
           ,<customer_id, real,>
           ,<store, nchar(10),>
           ,<employee_id, int,>
           ,<amount, smallmoney,>)
GO

-- inserting test data into demo table Orders
USE [CTE-Orders]
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (101, CAST(N'2021-07-01' AS Date), 234, N'Pheonix   ', 11, 198.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (102, CAST(N'2021-07-01' AS Date), 675, N'Pegasus   ', 13, 799.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (103, CAST(N'2021-07-01' AS Date), 456, N'Pegasus   ', 14, 698.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (104, CAST(N'2021-07-01' AS Date), 980, N'Orion     ', 15, 99.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (105, CAST(N'2021-07-02' AS Date), 594, N'Orion     ', 16, 1045.4500)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (106, CAST(N'2021-07-02' AS Date), 435, N'Pegasus   ', 11, 599.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (107, CAST(N'2021-07-02' AS Date), 246, N'Rigel     ', 14, 678.8900)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (108, CAST(N'2021-07-03' AS Date), 256, N'Pheonix   ', 12, 458.8000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (109, CAST(N'2021-07-03' AS Date), 785, N'Pheonix   ', 12, 99.0000)
GO
INSERT [dbo].[orders] ([id], [date], [customer_id], [store], [employee_id], [amount]) VALUES (111, CAST(N'2021-07-03' AS Date), 443, N'Orion     ', 16, 325.5000)
GO

-- CTE Demos 1
-- In our first Demo, we want to compare the total amount of each order with the 
-- average order amount at the corresponding store.
-- We can start by calculating the average order amount for each store using a CTE 
-- and adding this column to the output of the main query:

use [CTE-Orders]

-- calc average store amount
SELECT store, AVG(amount) AS average_order
   FROM orders
   GROUP BY store

-- CTE avg_per_store presented on each order.  
WITH avg_per_store AS
  (SELECT store, AVG(amount) AS average_order
   FROM orders
   GROUP BY store)
SELECT o.id, o.store, o.amount, avg.average_order AS avg_for_store
FROM orders o
JOIN avg_per_store avg
ON o.store = avg.store;

-- CTE Demo 2
--Here, we’ll compare different stores. Specifically, we want to see how the average order amount 
-- for each store compares to the minimum and the maximum of the average order amount among all stores.
--As in our first Demo above, we’ll start by calculating the average order amount for each store using a CTE. 
-- Then, we’ll define two more CTEs:
--•	To calculate the minimum of the average order amount among all stores.
--•	To calculate the maximum of the average order amount among all stores.

-- each stores average order and compare to all stores min avg order and all stores max avg order

WITH avg_per_store AS (
    SELECT store, AVG(amount) AS average_order
    FROM orders
    GROUP BY store),
    min_order_store AS (
    SELECT MIN (average_order) AS min_avg_order_store
    FROM avg_per_store),
    max_order_store AS (
    SELECT MAX (average_order) AS max_avg_order_store
    FROM avg_per_store)
SELECT avg.store, avg.average_order, min.min_avg_order_store,
max.max_avg_order_store
FROM avg_per_store avg
CROSS JOIN min_order_store min
CROSS JOIN max_order_store max;


-- CTE Demo 3
-- In our next example, we’ll continue with comparing the performance of our stores 
-- but with a few different metrics. Let’s say our company considers orders below 
-- $200 to be small and orders equal or above $200 to be big. 
-- Now, we want to calculate how many big orders and small orders each store had.

-- To address this task using WITH clauses, we need two common table expressions:
--•	To get the number of big orders for each store.
--•	To get the number of small orders for each store.

WITH stores AS
   (SELECT store
    FROM orders
    GROUP BY store),
  big AS
  (SELECT store, COUNT(*) AS big_orders
   FROM orders
   WHERE amount >= 200.00
   GROUP BY store),
  small AS
  (SELECT store, COUNT(*) AS small_orders
   FROM orders
   WHERE amount < 200.00
   GROUP BY store)
SELECT s.store, b.big_orders, sm.small_orders
FROM stores s
FULL JOIN big b
ON s.store = b.store
FULL JOIN small sm
ON s.store = sm.store;



