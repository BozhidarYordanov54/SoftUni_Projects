CREATE DATABASE [Minions2023]

USE [Minions2023]

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70),
)


INSERT INTO [Towns]([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')


INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM[Minions]
SELECT * FROM[Towns]

TRUNCATE TABLE [Minions]

CREATE TABLE[People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO[People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
('Gosho', NULL, NULL, 'm', '1977-11-05'),
('Maria', 1.65, 42.2, 'f', '1998-06-27'),
('Viki', NULL, NULL, 'f', '1989-02-02'),
('Vancho', 1.69, 77.8, 'm', '1999-03-03')

SELECT * FROM[People]

CREATE TABLE[Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY,
	CHECK(DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATE,
	[IsDeleted] CHAR(1),
	CHECK([IsDeleted] = 't' OR [IsDeleted] = 'f')
)

INSERT INTO[Users] ([Username], [Password], [LastLoginTime] ,[IsDeleted])
	VALUES
('BioMetrix_54', '123456789', '2023-02-22', 'f'),
('SLAMFiTO', '000000', '2022-05-10', 'f'),
('midas', '6873215', '2023-01-30', 't'),
('tujara', '987651', '2023-07-05', 't'),
('Vankata', '198654', '2023-03-04', 'f')

SELECT * FROM[Users]