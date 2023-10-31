CREATE DATABASE [TouristAgency]

USE [TouristAgency]

CREATE TABLE Countries (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	CountryId INT NOT NULL,
	FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Rooms (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Type VARCHAR(50) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
)

CREATE TABLE Hotels (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[DestinationId] INT NOT NULL,
	FOREIGN KEY (DestinationId) REFERENCES Destinations(Id)
)

CREATE TABLE Tourists (
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT NOT NULL,
	FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)

CREATE TABLE Bookings (
	Id INT IDENTITY(1,1) PRIMARY KEY,
    ArrivalDate DATETIME2 NOT NULL,
    DepartureDate DATETIME2 NOT NULL,
    AdultsCount INT NOT NULL CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
    ChildrenCount INT NOT NULL CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
    TouristId INT NOT NULL,
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms (
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    PRIMARY KEY (HotelId, RoomId),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);

INSERT INTO Tourists (Name, PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
	('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
	('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);


UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate <= '2023-12-31';

UPDATE Tourists
SET Email = NULL
WHERE Name LIKE '%MA%';

DELETE FROM Bookings
WHERE TouristId IN (SELECT Id FROM Tourists WHERE Name LIKE '%Smith%');

DELETE FROM Tourists
WHERE Name LIKE '%Smith%';

SELECT
    FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
    b.AdultsCount,
    b.ChildrenCount
FROM
    Bookings AS b
JOIN
    Rooms AS r
    ON b.RoomId = r.Id
ORDER BY
    r.Price DESC,
    b.ArrivalDate ASC;

SELECT
    h.Id,
    h.[Name]
FROM
    Hotels AS h
INNER JOIN
    HotelsRooms AS hr ON h.Id = hr.HotelId
INNER JOIN
    Rooms AS r ON hr.RoomId = r.Id AND r.Type = 'VIP Apartment'
LEFT JOIN
    Bookings AS b ON h.Id = b.HotelId
GROUP BY
    h.Id, h.[Name]
ORDER BY
    COUNT(b.Id) DESC;


SELECT
    t.Id,
    t.Name,
    t.PhoneNumber
FROM
    Tourists AS t
WHERE
    t.Id NOT IN (
        SELECT DISTINCT TouristId
        FROM Bookings
    )
ORDER BY
    t.Name ASC;

SELECT TOP 10
    H.[Name] AS HotelName,
    D.[Name] AS DestinationName,
    C.[Name] AS CountryName
FROM Bookings B
JOIN Hotels H ON B.HotelId = H.Id
JOIN Destinations D ON H.DestinationId = D.Id
JOIN Countries C ON D.CountryId = C.Id
WHERE B.ArrivalDate < '2023-12-31' 
    AND H.Id % 2 = 1
ORDER BY C.[Name], B.ArrivalDate; --TASK 8

SELECT
    H.[Name] AS HotelName,
    R.Price AS RoomPrice
FROM Tourists T
JOIN Bookings B ON T.Id = B.TouristId
JOIN Hotels H ON B.HotelId = H.Id
JOIN Rooms R ON B.RoomId = R.Id
WHERE T.[Name] NOT LIKE '%EZ'
ORDER BY R.Price DESC; --TASK 9

SELECT
    H.[Name] AS HotelName,
    SUM(R.Price * DATEDIFF(day, B.ArrivalDate, B.DepartureDate)) AS TotalRevenue
FROM Bookings B
JOIN Hotels H ON B.HotelId = H.Id
JOIN Rooms R ON B.RoomId = R.Id
GROUP BY H.[Name]
ORDER BY TotalRevenue DESC; --TASK 10

CREATE FUNCTION udf_RoomsWithTourists (@RoomType VARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @TotalTourists INT

    SELECT @TotalTourists = SUM(b.AdultsCount + b.ChildrenCount)
    FROM Bookings AS b
    INNER JOIN Rooms AS r ON b.RoomId = r.Id
    WHERE r.[Type] = @RoomType

    RETURN @TotalTourists
END




CREATE PROCEDURE usp_SearchByCountry
    @Country NVARCHAR(50)
AS
BEGIN
    SELECT
        t.Name AS TouristName,
        t.PhoneNumber,
        t.Email,
        COUNT(b.Id) AS CountOfBookings
    FROM Tourists AS t
    INNER JOIN Bookings AS b ON t.Id = b.TouristId
    INNER JOIN Countries AS c ON t.CountryId = c.Id
    WHERE c.Name = @Country
    GROUP BY t.Name, t.PhoneNumber, t.Email
    ORDER BY t.Name ASC, CountOfBookings DESC
END


SELECT dbo.udf_RoomsWithTourists('Double Room')

