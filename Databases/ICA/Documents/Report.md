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
Query Without DISTINCT:
```sql
SELECT season 
FROM dbo.games;
```
Output:
```
(51 rows affected)

Completion time: 2023-10-19T09:21:56.9049219+01:00
```
Return Data:
| Season   |
| -------- |
| Summer   |
| Summer   |
| Summer   |
| Summer   |
| Winter   |
---
Query With DISTINCT:
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
Query Without DISTINCT:
```sql
SELECT sport_id 
FROM dbo.event;
```
Output:
```
(66 rows affected)

Completion time: 2023-10-12T11:18:53.8945653+01:00
```
Return Data:
| sport_id |
| -------- |
| 54       |
| 54       |
| 18       |
| 18       |
| 18       |
|...       |
---
Query With DISTINCT:
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

#### Demo A3: Using Column and Table Aliases Lesson
---
Query:
```sql
SELECT c.city_name, gc.games_id, p.full_name, m.medal_name
FROM dbo.city AS c
INNER JOIN dbo.games_city AS gc ON c.id = gc.city_id
INNER JOIN dbo.games_competitor AS gcp ON gc.games_id = gcp.games_id
INNER JOIN dbo.person AS p ON gcp.person_id = p.id
INNER JOIN dbo.competitor_event AS ce ON gcp.person_id = ce.competitor_id
INNER JOIN dbo.medal AS m ON ce.medal_id = m.id;
```
Output:
```
(265018 rows affected)

Completion time: 2023-10-19T09:30:38.5251880+01:00
```
Return Data:
| City Name | Games ID | Full Name | Medal Name |
|-----------|----------|-----------|------------|
| Barcelona | 1        | A Dijiang | NA         |
| London    | 2        | A Lamusi  | NA         |
| Antwerpen | 3        | Gunnar Nielsen Aaby | NA         |
| Paris     | 4        | Edgar Lindenau Aabye | Gold       |
| Calgary   | 5        | Christine Jacoba Aaftink | NA         |
| Albertville | 6        | Christine Jacoba Aaftink | NA         |
| Lillehammer | 7        | Christine Jacoba Aaftink | NA         |
|...|...|...|...|
---

#### Demo A4: Writing Simple CASE Expressions
---
Query:
```sql
SELECT 
    CASE 
        WHEN medal_id = 1 THEN 'Gold'
        WHEN medal_id = 2 THEN 'Silver'
        WHEN medal_id = 3 THEN 'Bronze'
        ELSE 'No Medal'
    END AS Medal
FROM dbo.competitor_event;
```
Output:
```
(260971 rows affected)

Completion time: 2023-10-19T09:35:30.7045404+01:00
```
Return Data:
| Medal |
|------|
| No Medal |
| No Medal |
| No Medal |
| Gold |
| No Medal |
|...|
---

### Module 4: Joining and Querying Multiple Tables

#### Demo B1: How to provide data from 2 related tables with a Join
---
Query:
```sql
SELECT g.games_year, g.games_name, g.season, ce.event_id
FROM dbo.games g
JOIN dbo.competitor_event ce ON g.id = ce.event_id 
```
Output:
```
(59920 rows affected)

Completion time: 2023-10-19T09:55:03.0229889+01:00
```
Return Data:
| games_year | games_name  | season  | event_id |
| ---------- | ----------- | ------- | -------- |
| 1992       | 1992 Summer | Summer  | 1        |
| 2012       | 2012 Summer | Summer  | 2        |
| 1920       | 1920 Summer | Summer  | 3        |
| 1900       | 1900 Summer | Summer  | 4        |
| 1988       | 1988 Winter | Winter  | 5        |
|...|...|...|...|
---
#### Demo B2: How to Query with Inner Joins
---
Query:
```sql
SELECT c.city_name, g.games_year
FROM dbo.city c
INNER JOIN dbo.games_city gc ON c.id = gc.city_id
INNER JOIN dbo.games g ON gc.games_id = g.id
```
Output:
```
(52 rows affected)

Completion time: 2023-10-19T09:40:29.7298306+01:00
```
Return Data:
| City Name | Games Year |
|-----------|------------|
| Barcelona | 1992       |
| London    | 2012       |
| Antwerpen | 1920       |
| Paris     | 1900       |
| Calgary   | 1988       |
|...|...|
---
#### Demo B3: How to Query with Outer Joins
---
Query:
```sql
SELECT gcp.age, p.full_name
FROM dbo.games_competitor AS gcp
LEFT OUTER JOIN dbo.person AS p ON p.id = gcp.person_id
```
Output:
```
(180252 rows affected)

Completion time: 2023-10-19T09:59:59.4151085+01:00
```
Return Data:
| age | full_name        |
|-----|------------------|
| 24  | A Dijiang        |
| 23  | A Lamusi         |
| 24  | Gunnar Nielsen Aaby |
| 34  | Edgar Lindenau Aabye |
| 21  | Christine Jacoba Aaftink |
|...|...|
---
#### Demo B4: How Query with Cross Joins and Self Joins
---
Query:
```sql
SELECT c.id, c.city_name, g.id, g.games_year, g.games_name, g.season
FROM dbo.city c
CROSS JOIN dbo.games g;
```
Output:
```
(2142 rows affected)

Completion time: 2023-10-19T10:08:22.9105966+01:00
```
Return Data:
| id | games_year | games_name  | season |
|----|------------|-------------|--------|
| 51 | 1896       | 1896 Summer | Summer |
| 4  | 1900       | 1900 Summer | Summer |
| 44 | 1904       | 1904 Summer | Summer |
| 45 | 1906       | 1906 Summer | Summer |
| 47 | 1908       | 1908 Summer | Summer |
|...|....|....|....|....|
---
### Module 5: Sorting and Filtering Data

#### Demo C1: How to Sort Data
---
Query:
```sql
SELECT p.full_name ,p.gender ,p.height ,p.weight
FROM dbo.person as p
order by weight desc
```
Output:
```
(128854 rows affected)

Completion time: 2023-10-26T10:28:33.0633471+01:00
```
Return Data:
| full_name                    | gender | height | weight |
|------------------------------|--------|--------|--------|
| Ricardo Blas, Jr.            | M      | 183    | 214    |
| Aytami Ruano Vega            | M      | 200    | 198    |
| Marek Galiski                | M      | 200    | 190    |
| Christopher J. \"Chris\"\" Taylor\" | M      | 196    | 182    |
| Valentyn Rusliakov           | M      | 187    | 180    |
| ...                          | ...    | ...    | ...    |

---
#### Demo C2: How to Filter Data with Predicates
---
Query:
```sql
SELECT p.full_name, p.gender, p.height, p.weight
FROM dbo.person AS p
WHERE p.gender = 'M' AND p.height > 180 AND p.weight < 80;
```
Output:
```
(10515 rows affected)

Completion time: 2023-10-26T10:25:47.4424267+01:00
```
Return Data:
| full_name             | gender | height | weight |
|-----------------------|--------|--------|--------|
| Per Knut Aaland       | M      | 188    | 75     |
| John Aalberg          | M      | 183    | 72     |
| Jorma Ilmari Aalto    | M      | 182    | 77     |
| Pepijn Aardewijn      | M      | 189    | 72     |
| Mika Lauri Aarnikka   | M      | 187    | 76     |
| ...                   | ...    | ...    | ...    |

---
#### Demo C3: How to Filter Data with TOP and OFFSET-FETCH
---
Query:
```sql
SELECT TOP(10) p.full_name, p.gender, p.height, p.weight
FROM dbo.person AS p
ORDER BY p.full_name;
```
```sql
SELECT p.full_name, p.gender, p.height, p.weight
FROM dbo.person AS p
ORDER BY p.full_name
OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;
```
Output:
```
(10 rows affected)

Completion time: 2023-10-26T10:32:41.8330498+01:00
```
```
(10 rows affected)

Completion time: 2023-10-26T10:31:44.3769641+01:00
```
Return Data:
| full_name                                 | gender | height | weight |
|-------------------------------------------|--------|--------|--------|
| A Dijiang                                 | M      | 180    | 80     |
| A Lamusi                                  | M      | 170    | 60     |
| A. Aanantha Sambu Mayavo                  | M      | 0      | 0      |
| A. J. Tyronne Benildus \"Benny\"\" Fernando\" | M      | 179    | 70     |
| A. Joshua \"Josh\"\" West\"                | M      | 207    | 105    |
| A. W. Nancy \"Nan\"\" Rae\"                | F      | 156    | 53     |
| Aa Bela Joaquim                           | F      | 0      | 0      |
| Aadam Ismaeel Khamis                      | M      | 172    | 67     |
| Aadjijatmiko Finarsih H.                  | F      | 0      | 0      |
| Aadolf Fredrik Svanstrm                   | M      | 179    | 70     |
| ...                                       | ...    | ...    | ...    |

| full_name                  | gender | height | weight |
|----------------------------|--------|--------|--------|
| Aafke Hament               | F      | 181    | 64     |
| Aage Albert Leidersdorff   | M      | 168    | 0      |
| Aage Avaldorff Meyer       | M      | 0      | 0      |
| Aage Berntsen              | M      | 0      | 0      |
| Aage Birch                 | M      | 172    | 70     |
| Aage Brge Poulsen          | M      | 185    | 68     |
| Aage Carl Christian Lassen | M      | 181    | 62     |
| Aage Emil Brix             | M      | 0      | 0      |
| Aage Emil Kirkegaard       | M      | 0      | 0      |
| Aage Ernst Larsen          | M      | 0      | 0      |
| ...                        | ...    | ...    | ...    |
---
#### Demo C4: How to work with Unknown Values
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### Module 6: Working with Data Types

#### Demo D1: Working with Data Type examples
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo D2: Working with Character Data
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo D3: Working with Date and Time Data
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### Module 7: Using DML to Modify Data

#### Demo E1: Adding Data to Tables
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo E2: Modifying and Removing Data
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo E3: Generating Automatic Column Values
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### Module 8: Using Built-In Functions

#### Demo F1: Writing Queries with Built-In Functions
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo F2: Using Conversion Functions
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo F3: Using Logical Functions
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### Demo F4: Using Functions to Work with NULL
---
Query:
```sql

```
Output:
```

```
Return Data:

---
## TSQL Part 2: SQL Server Coding Functions and Features

### TSQL09: Group and Aggregating Data

#### ICA Demo 1: Using Aggregate Functions
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Using the GROUP BY Clause
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 3: Filtering Groups with HAVING 
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL10: Using Subqueries

#### ICA Demo 1: Writing Self-Contained Subqueries
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Writing Correlated Subqueries
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 3: Using the EXISTS Predicate with Subqueries
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL11: Using Table Expressions

#### ICA Demo 1: Using Views
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Using Inline TVFs
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 3: Using Derived Tables
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICADemo 4: Using CTEs
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL12: Using Views and Set Operators

#### ICA Demo 1: Writing Queries using Union Intersect Except set operators
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: More on set operators
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 3: Create inline Table-valued Function
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL13: Using Window Ranking, Offset, and Aggregate Functions

#### ICA TSQL Demo 1 - Partition By Row Number function
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA TSQL Demo 2 - Windows Ranking (or Windows Rank with partition)
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA TSQL Demo 3 - OVER Clause (or CTE Function with Over)
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA TSQL Demo 4 - Writing Aggregate function in Partition By
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL14: Pivoting and Grouping Sets

#### ICA Demo 1: Working with Grouping Sets
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Writing Queries with PIVOT and UNPIVOT
---
Query:
```sql

```
Output:
```

```
Return Data:

---
## TSQL Part 3: SQL Server Programming

### TSQL15: Executing Stored Procedures

#### ICA Demo 1: T-SQL Stored Procedure
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: TSQL Stored Procedures with Parameters
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL16: Programming with T-SQL

#### ICA Demo 1: T-SQL programming and Stored Procedure
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: T-SQL programming with Parameters
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL Module 17: Implementing Error Handling

#### ICA Demo 1: Implementing T-SQL Error Handling
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Implementing Structured Exception Handling
---
Query:
```sql

```
Output:
```

```
Return Data:

---
### TSQL Module 18: Implementing Transactions

#### ICA Demo 1: Transactions
---
Query:
```sql

```
Output:
```

```
Return Data:

---
#### ICA Demo 2: Controlling Transactions
---
Query:
```sql

```
Output:
```

```
Return Data:

---