CREATE DATABASE [Exercises: Table Relations]

USE [Exercises: Table Relations]


--START OF TASK 01. One-To-One Relationship

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] VARCHAR(20)
)

INSERT INTO [Passports](PassportNumber)
	VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2');

CREATE TABLE [Persons] (
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50),
	[Salary] DECIMAL(8, 2),
	[PassportID] INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO [Persons] (FirstName, Salary, PassportID)
	VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);



SELECT * FROM [Passports]
SELECT * FROM [Persons]

ALTER TABLE Persons
ADD UNIQUE(PassportID)

--END OF TASK 01. One-To-One Relationship. RESULT -> 100/100
		
--START OF TASK 02. One-To-Many Relationship

CREATE TABLE Manufacturers(
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	[EstablishedOn] DATE
)

CREATE TABLE Models(
	[ModelID] INT PRIMARY KEY IDENTITY (101, 1),
	[Name] VARCHAR(50),
	[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers (Name, EstablishedOn)
	VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966');

INSERT INTO [Models] (Name, [ManufacturerID])
	VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3);

SELECT * FROM [Models]
SELECT * FROM [Manufacturers]

--END OF TASK 02. One-To-Many Relationship RESULT -> 100/100

--START OF TASK 03. Many-To-Many Relationship 

CREATE TABLE Exams(
	[ExamID] INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

INSERT INTO Exams (ExamID, Name)
VALUES
    (101, 'SpringMVC'),
    (102, 'Neo4j'),
    (103, 'Oracle 11g');

CREATE TABLE Students(
	[StudentID] INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

-- Insert data into the Students table
INSERT INTO Students (StudentID, Name)
VALUES
    (1, 'Mila'),
    (2, 'Toni'),
    (3, 'Ron');

CREATE TABLE StudentsExams (
    StudentID INT,
    ExamID INT,
    PRIMARY KEY (StudentID, ExamID), --COMPOSITE PRIMARY KEY
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
-- Insert data into the StudentsExams table
INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
    (1, 101), -- Mila is associated with SpringMVC
    (2, 102), -- Toni is associated with Neo4j
    (3, 101); -- Ron is associated with SpringMVC


--END OF TASK 03. Many-To-Many Relationship RESULT -> 100/100

--START OF 04. Self-Referencing

-- Create the Teachers table
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    Name VARCHAR(255),
    ManagerID INT,
    FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

-- Insert data into the Teachers table
INSERT INTO Teachers (TeacherID, Name, ManagerID)
VALUES
    (101, 'John', NULL),
    (102, 'Maya', 106),
    (103, 'Silvia', 106),
    (104, 'Ted', 105),
    (105, 'Mark', 101),
    (106, 'Greta', 101);

--END OF 04. Self-Referencing RESULT -> 100/100

--START OF 05. Online Store Database

CREATE TABLE ItemTypes(
	[ItemTypeID] INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

CREATE TABLE Items(
	[ItemID] INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	[ItemTypeID] INT,
	FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR
)

CREATE TABLE Customers(
	[CustomerID] INT PRIMARY KEY,
	[Name] NVARCHAR,
	[Birthday] DATE,
	[CityID] INT,
	FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	[OrderID] INT PRIMARY KEY,
	[CustomerID] INT,
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
	[OrderID] INT,
	[ItemID] INT,
	PRIMARY KEY (OrderID, ItemID), --COMPOSITE PRIMARY KEY
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID),
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
)

--END OF 05. Online Store Database RESULT -> 100/100

--START OF 06. University Database

CREATE TABLE Majors(
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR
)

CREATE TABLE StudentsTWO(
	[StudentID] INT PRIMARY KEY,
	[StudentNumber] INT,
	[StudentName] NVARCHAR,
	[MajorID] INT,
	FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATE,
	[PaymentAmount] DECIMAL,
	[StudentID] INT,
	FOREIGN KEY (StudentID) REFERENCES StudentsTWO(StudentID)
)

CREATE TABLE Subjects(
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] NVARCHAR
)


CREATE TABLE Agenda(
	[StudentID] INT,
	[SubjectID] INT
	PRIMARY KEY (StudentID, SubjectID), --COMPOSITE PRIMARY KEY
    FOREIGN KEY (StudentID) REFERENCES StudentsTWO(StudentID),
	FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

--END OF 06. University Database RESULT -> 100/100

SELECT MountainRange, PeakName, Elevation IN RilaPeaks
FROM Mountains
JOIN Peaks ON Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC