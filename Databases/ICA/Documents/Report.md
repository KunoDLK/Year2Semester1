# TSQL ICA - kleeuwkent

## SQL Server Practitioner Details: 
a) Introduction to the SQL Practitioner: 
  - The SQL Practitioner is a professional who has mastered the fundamentals of Structured Query Language (SQL), a powerful language used for managing data in relational database management systems. 
  - The SQL Practitioner is responsible for developing and maintaining databases, writing queries, and troubleshooting any issues related to the database. 
  - They must have an understanding of database design principles and be able to use their knowledge of SQL to create efficient, secure, and reliable databases.
  
b) Why you should learn SQL: 
  - Learning SQL is a great way to gain a better understanding of how databases work and how to use them effectively. 
  - With the right knowledge, you can create powerful applications that can help you manage data more efficiently and store it securely. 
  - Additionally, having an understanding of SQL will make you a more employable candidate in the tech industry.

---

## SQL Server Database Overview:

a) SQL Server Database Diagrams:
- Using the sample database "Olympics" which contains the last 120 years of Olympic winners
- Data includes information on athletes who have won medals in the Summer and Winter Olympics since 1896
- Data includes events competed in, countries represented, and medals won
- Database can be used to compare medal-winning performances across different countries, sports, and disciplines

### ERD Diagram:

![ERD Olympics](.//Images/ERD%20Olympics.png)

### Detailed Table Data:

```SQL
dbo.city:
id (PKT int, not null)
city_name (varchar(200, null)

dbo.competitor_event:
event_id (FK int, null)
competitor_id (FK int, null)
medal_id (FK int, null)

dbo.event:
id (PK. int, not null)
sport_id (FK, int, null)
event_name (varcharen, null)

dbo.games:
TO id (PK. int. not null)
games_year (int. null)
games_name (varchar(100), null)
season (varchar(100), null)

dbo.games_city:
games_id (FKI int, null)
city_id (FK, int, null)

dbo.games_competitor:
id (PKT int, not null)
games_id (FK, int, null)
person_id (FK, int, null)
age (int, null)

dbo.medal:
id (PK, int, not null)
medal_name (varchar(50), null)

dbo.noc_region:
id (PK int, not null)
noc (varchar(5), null)
region_name (varchar(200), null)

dbo.person:
id (PK int, not null)
full_name (varchar(500), null)
gender (varchar(10), null)
height (int, null)
weight (int, null)

dbo.person_region:
person_id (FK int, null)
region_id (FK int null)

dbo.sport:
id (PK int, not null)
sport_name (varchar(200), null)
```
---

## TSQL Part 1: SQL Server Coding Basics:

## TSQL03 to TSQL08: SQL Server Basics:

### Module 3: Writing SELECT Queries with single Table:

- Writing SELECT queries with single table is important for engineering jobs because it allows you to quickly and accurately retrieve data from a single source. 
- This can be especially useful when needing to analyze complex data or when needing to make decisions based on the data retrieved.
- It also helps to ensure that the data is accurate and up to date, which is essential in engineering jobs. 
- Additionally, writing SELECT queries with single table helps to increase efficiency as it eliminates the need to search through multiple sources of data.

#### Demo A1: Writing Simple SELECT Query:
---
Query:
```sql
SELECT city_name 
FROM dbo.city;
```
Output:
```
(42 rows affected)

Completion time: 2023-10-12T10:50:14.3288215+01:00
```
Return Data:

City Name | 
----------|
Barcelona | 
London    | 
Antwerpen | 
Paris     | 
Calgary   |
...       |

---
Query:
```sql
SELECT event_name, sport_id 
FROM dbo.event;
```
Output:
```
(757 rows affected)

Completion time: 2023-10-12T10:56:56.3198347+01:00
```
Return Data:

| Event Name          | Sport ID |
| ------------------- | -------- |
| Basketball          | 9        |
| Judo Men's Extra-Lightweight | 33 |
| Football            | 25       |
| Tug-Of-War         | 62       |
| Speed Skating Women's 500 metres | 54 |
|...|...|

---
Query:
```sql
SELECT games_year, games_name, season 
FROM dbo.games;
```
Output:
```
(51 rows affected)

Completion time: 2023-10-12T10:58:49.2380500+01:00
```
Return Data:
| games_year | games_name      | season  |
| ---------- | --------------- | ------- |
| 1992       | 1992 Summer     | Summer  |
| 2012       | 2012 Summer     | Summer  |
| 1920       | 1920 Summer     | Summer  |
| 1900       | 1900 Summer     | Summer  |
| 1988       | 1988 Winter     | Winter  |
|...|...|...|
---

#### Demo A2: Eliminating Duplicates with DISTINCT:

---
Query:
```sql
SELECT DISTINCT season 
FROM dbo.games;
```
Output:
```
(2 rows affected)

Completion time: 2023-10-12T11:15:02.0319216+01:00
```
Return Data:
| Season   |
| -------- |
| Summer   |
| Winter   |
---
Query:
```sql
SELECT DISTINCT sport_id 
FROM dbo.event;
```
Output:
```
(66 rows affected)

Completion time: 2023-10-12T11:18:53.8945653+01:00
```
Return Data:
| sport_id |
|----------|
| 1        |
| 2        |
| 3        |
| 4        |
| 5        |
|...|
---



  * Demo A3: Using Column and Table Aliases Lesson

  * Demo A4: Writing Simple CASE Expressions

b) Module 4: Joining and Querying Multiple Tables

  * Demo B1: How to provide data from 2 related tables with a Join

  * Demo B2: How to Query with Inner Joins

  * Demo B3: How to Query with Outer Joins

  * Demo B4: How Query with Cross Joins and Self Joins

c) Module 5: Sorting and Filtering Data

  * Demo C1: How to Sort Data

  * Demo C2: How to Filter Data with Predicates

  * Demo C3: How to Filter Data with TOP and OFFSET-FETCH

  * Demo C4: How to work with Unknown Values

d) Module 6: Working with Data Types

  * Demo D1: Working with Data Type examples

  * Demo D2: Working with Character Data

  * Demo D3: Working with Date and Time Data

e) Module 7: Using DML to Modify Data

  * Demo E1: Adding Data to Tables

  * Demo E2: Modifying and Removing Data

  * Demo E3: Generating Automatic Column Values

f) Module 8: Using Built-In Functions

  * Demo F1: Writing Queries with Built-In Functions

  * Demo F2: Using Conversion Functions

  * Demo F3: Using Logical Functions

  * Demo F4: Using Functions to Work with NULL

## TSQL Part 2: SQL Server Coding Functions and Features

2. TSQL09: Group and Aggregating Data

a) ICA Demo 1: Using Aggregate Functions

b) ICA Demo 2: Using the GROUP BY Clause

c) ICA Demo 3: Filtering Groups with HAVING 

3. TSQL10: Using Subqueries

a) ICA Demo 1: Writing Self-Contained Subqueries

b) ICA Demo 2: Writing Correlated Subqueries

c) ICA Demo 3: Using the EXISTS Predicate with Subqueries

4. TSQL11: Using Table Expressions

a) ICA Demo 1: Using Views

b) ICA Demo 2: Using Inline TVFs

c) ICA Demo 3: Using Derived Tables

d) ICADemo 4: Using CTEs

5. TSQL12: Using Views and Set Operators

a) ICA Demo 1: Writing Queries using Union Intersect Except set operators

b) ICA Demo 2: More on set operators

c) ICA Demo 3: Create inline Table-valued Function

6. TSQL13: Using Window Ranking, Offset, and Aggregate Functions

a) ICA TSQL Demo 1 - Partition By Row Number function

b) ICA TSQL Demo 2 - Windows Ranking (or Windows Rank with partition

c) ICA TSQL Demo 3 - OVER Clause (or CTE Function with Over)

d) ICA TSQL Demo 4 - Writing Aggregate function in Partition By

7. TSQL14: Pivoting and Grouping Sets

a) ICA Demo 1: Working with Grouping Sets

b) ICA Demo 2: Writing Queries with PIVOT and UNPIVOT

## TSQL Part 3: SQL Server Programming

8. TSQL15: Executing Stored Procedures

a) ICA Demo 1: T-SQL Stored Procedure

b) ICA Demo 2: TSQL Stored Procedures with Parameters

9. TSQL16: Programming with T-SQL

a) ICA Demo 1: T-SQL programming and Stored Procedure

b) ICA Demo 2: T-SQL programming with Parameters

10. TSQL Module 17: Implementing Error Handling

a) ICA Demo 1: Implementing T-SQL Error Handling

b) ICA Demo 2: Implementing Structured Exception Handling

11. TSQL Module 18: Implementing Transactions

a) ICA Demo 1: Transactions

b) ICA Demo 2: Controlling Transactions