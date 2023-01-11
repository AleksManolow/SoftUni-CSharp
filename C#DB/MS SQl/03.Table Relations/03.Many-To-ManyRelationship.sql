CREATE TABLE[Students](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
)

INSERT INTO[Students]([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

--SELECT * FROM [Students]

CREATE TABLE[Exams](
	[Id] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
)

INSERT INTO[Exams]([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

--SELECT * FROM [Exams]

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES[Students](Id) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES[Exams](Id) NOT NULL,
	PRIMARY KEY([StudentID], [ExamID]) --Composite Primary Key!
)

INSERT INTO [StudentsExams]([StudentID], [ExamID])
	VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--SELECT * FROM [StudentsExams]