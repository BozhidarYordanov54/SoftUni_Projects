CREATE DATABASE Accounting

USE Accounting

CREATE TABLE Countries(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE [Addresses](
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT NOT NULL,
	FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Vendors(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL,
	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

CREATE TABLE Clients(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL,
	FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(35) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CategoryId INT NOT NULL,
    VendorId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (VendorId) REFERENCES Vendors(Id)
);

CREATE TABLE Invoices (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Number INT UNIQUE NOT NULL,
    IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
	Currency NVARCHAR(5) NOT NULL,
    ClientId INT NOT NULL,
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE ProductsClients (
    ProductId INT NOT NULL,
    ClientId INT NOT NULL,
    PRIMARY KEY (ProductId, ClientId),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

--END OF TASK 1


INSERT INTO Products (Name, Price, CategoryId, VendorId)
VALUES
    ('SCANIA Oil Filter XD01', 78.69, 1, 1),
    ('MAN Air Filter XD01', 97.38, 1, 5),
    ('DAF Light Bulb 05FG87', 55.00, 2, 13),
    ('ADR Shoes 47-47.5', 49.85, 3, 5),
    ('Anti-slip pads S', 5.87, 5, 7);


INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
    (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
    (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
    (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19);

--END OF TASK 2


UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate BETWEEN '2022-11-01' AND '2022-12-01';

UPDATE [Addresses]
SET StreetName = N'Industriestr',
    StreetNumber = 79,
    PostCode = 2353,
    City = 'Guntramsdorf',
    CountryId = (SELECT Id FROM Countries WHERE Name = 'Austria')
WHERE City = 'Guntramsdorf' AND CountryId = (SELECT Id FROM Countries WHERE Name = 'Austria');


UPDATE Clients
SET AddressId = (SELECT Id FROM [Addresses] WHERE City = 'Guntramsdorf' AND CountryId = (SELECT Id FROM Countries WHERE Name = 'Austria'))
WHERE Name LIKE '%CO%';

--END OF TASK 3

DELETE FROM ProductsClients
WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%');

DELETE FROM Invoices
WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%');

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%';

--END OF TASK 4

SELECT Number, Currency FROM Invoices
ORDER BY Amount DESC, DueDate ASC

--END OF TASK 5

SELECT P.Id, P.Name, P.Price, C.Name
FROM Products AS P
JOIN Categories AS C ON P.CategoryID = C.Id
WHERE C.Name IN('ADR', 'Others')
ORDER BY P.Price DESC;

--END OF TASK 6

SELECT c.Id, c.Name AS Client, a.StreetName + ' ' + ISNULL(CONVERT(NVARCHAR(10), a.StreetNumber), '') + ', ' + a.City + ', ' + CONVERT(NVARCHAR(10), a.PostCode) + ', ' + co.Name AS Address
FROM Clients c
INNER JOIN Addresses a ON c.AddressId = a.Id
LEFT JOIN ProductsClients pc ON c.Id = pc.ClientId
LEFT JOIN Countries co ON a.CountryId = co.Id
WHERE pc.ProductId IS NULL
ORDER BY Client ASC;

--END OF TASK 7

SELECT TOP 7
    i.Number,
    i.Amount,
    c.Name AS Client
FROM Invoices i
INNER JOIN Clients c ON i.ClientId = c.Id
WHERE 
    (i.IssueDate < '2023-01-01' AND i.Currency = 'EUR') OR
    (i.Amount > 500.00 AND LEFT(c.NumberVAT, 2) = 'DE')
ORDER BY 
    i.Number ASC,
    i.Amount DESC;

--END OF TASK 8

WITH ClientMostExpensiveProduct AS (
    SELECT
        c.Name AS Client,
        p.Price,
        c.NumberVAT AS [VAT Number],
        ROW_NUMBER() OVER (PARTITION BY c.Id ORDER BY p.Price DESC) AS RowNum
    FROM Clients c
    JOIN ProductsClients pc ON c.Id = pc.ClientId
    JOIN Products p ON pc.ProductId = p.Id
    WHERE c.Name NOT LIKE '%KG'
)

SELECT Client, Price, [VAT Number]
FROM ClientMostExpensiveProduct
WHERE RowNum = 1
ORDER BY Price DESC;


--09. Clients with VAT