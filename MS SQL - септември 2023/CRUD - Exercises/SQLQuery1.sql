SELECT * FROM [Departments] --Task 2

SELECT [Name] FROM [Departments] --Task 3

SELECT FirstName, LastName, Salary FROM [Employees] --Task 4

SELECT FirstName, MiddleName, LastName FROM [Employees] --Task 5

SELECT 
    CONCAT((FirstName), '.', (LastName), '@softuni.bg') AS "Full Email Address" --TASK 6
FROM employees;

SELECT DISTINCT Salary FROM [Employees] AS "Salary" --TASK 7

SELECT * FROM [Employees] WHERE JobTitle = 'Sales Representative'; --TASK 8

SELECT FirstName, LastName, JobTitle FROM [Employees] WHERE Salary BETWEEN 20000 AND 30000 --TASK 9

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS "Full Name" FROM [Employees] WHERE Salary IN(25000, 14000, 12500, 23600) --TASK 10

SELECT FirstName, LastName FROM employees WHERE ManagerID IS NULL; --TASK 11

SELECT FirstName, LastName, Salary FROM [Employees] Where Salary > 50000 --TASK 12

	