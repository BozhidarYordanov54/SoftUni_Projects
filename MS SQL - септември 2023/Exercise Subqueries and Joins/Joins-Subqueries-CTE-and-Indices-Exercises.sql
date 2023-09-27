USE [SoftUni_Database]

SELECT TOP (5)
    e.EmployeeId,
    e.JobTitle,
    a.AddressId,
    a.AddressText
FROM
    Employees e
JOIN
    Addresses a ON e.AddressId = a.AddressId
ORDER BY
    a.AddressId ASC; --EXERCISE 1

SELECT TOP (50) e.FirstName,
                e.LastName,
                t.Name,
                a.AddressText
FROM Employees AS e
     JOIN Addresses AS a ON e.AddressID = a.AddressID
     JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName,
         e.LastName; --EXERCISE 2

SELECT e.EmployeeID, 
	   e.FirstName, 
	   e.LastName, 
	   d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID ASC --EXERCISE 3

SELECT TOP(5) e.EmployeeID,
			  e.FirstName,
			  e.Salary,
			  d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC --EXERCISE 4

SELECT TOP(3) e.EmployeeID,
			  e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID ASC --EXERCISE 5

SELECT e.FirstName,
	   e.Lastname,
	   e.HireDate,
	   d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate ASC --EXERCISE 6

SELECT TOP(5) e.EmployeeID,
			  e.FirstName,
			  p.[Name] AS ProjectName
FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC --EXERCISE 7

SELECT e.EmployeeID,
       e.FirstName,
       CASE
           WHEN p.StartDate > '2005'
           THEN NULL
           ELSE p.Name
       END AS ProjectName
FROM Employees AS e
     JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24;  --EXERCISE 8




