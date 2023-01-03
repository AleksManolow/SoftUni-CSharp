CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[GEnder] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate])
	VALUES
	('Gosho', 'f', '1998-10-21'),
	('Pesho', 'm', '2001-08-24'),
	('Ivan', 'f', '1998-12-12'),
	('Stancho', 'm', '1983-09-17'),
	('Blagoi', 'f', '1994-07-17')

SELECT * FROM [People]