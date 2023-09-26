USE [SoftUni]

SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'Sa%' --EXERCISE 1

SELECT FirstName, LastName FROM Employees WHERE LastName LIKE '%ei%' --EXERCISE 2

SELECT FirstName FROM Employees WHERE (DepartmentID = 3 OR DepartmentID = 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005 --EXERCISE 3

SELECT FirstName, LastName FROM Employees WHERE JobTitle NOT LIKE '%engineer%' --EXERCISE 4

SELECT [Name] FROM Towns WHERE LEN([Name]) IN (5, 6) ORDER BY [Name]; --EXERCISE 5

SELECT * FROM Towns WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%' ORDER BY [Name] --EXERCISE 6

SELECT * FROM Towns WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%' ORDER BY [Name] --EXERCISE 7

CREATE VIEW V_EmployeesHiredAfter2000 AS SELECT FirstName, LastName FROM Employees WHERE YEAR(HireDate) > 2000; --EXERCISE 8

SELECT FirstName, LastName FROM Employees WHERE LEN([LastName]) = 5 --EXERCISE 9

SELECT EmployeeID, FirstName, LastName, Salary,
       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS SalaryRank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC; -- --EXERCISE 10

WITH RankedEmployees AS (
    SELECT EmployeeID, FirstName, LastName, Salary,
           DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
)

SELECT EmployeeID, FirstName, LastName, Salary, [Rank]
FROM RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC; -- --EXERCISE 11

USE [Geography]

SELECT CountryName, IsoCode
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode; --EXERCISE 12

SELECT PeakName, RiverName, CONCAT(SUBSTRING(LOWER(P.PeakName), 1 , LEN(P.PeakName) - 1), '', LOWER(R.RiverName)) AS [Mix]
	FROM Peaks P
JOIN Rivers R ON LOWER(RIGHT(P.PeakName, 1)) = LOWER(LEFT(R.RiverName, 1))
ORDER BY [Mix] --EXERICE 13


USE [Diablo]

SELECT TOP(50) [Name], CONVERT(varchar(10), [Start], 120) AS [Start] FROM Games WHERE YEAR([Start]) IN (2011, 2012) ORDER BY [Start] --EXERCISE 14

SELECT
    Username,
    SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username; --EXERCISE 15

SELECT Username, IpAddress FROM Users WHERE IpAddress LIKE '___.1%.%.___' ORDER BY Username --EXERCISE 16

SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY [Name] ASC, [Duration] ASC, [Part of the Day] ASC; --EXERCISE 17

USE [Orders]

SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) FROM Orders --EXERCISE 18
