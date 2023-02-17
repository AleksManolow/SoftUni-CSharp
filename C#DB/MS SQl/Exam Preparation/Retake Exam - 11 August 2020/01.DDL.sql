CREATE DATABASE BAKERY

USE BAKERY

CREATE TABLE Countries(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25) NOT NULL,
	[LastName] VARCHAR(25) NOT NULL,
	[Gender] CHAR(1) CHECK([Gender] IN ('M','F')) NOT  NULL,
	[Age] INT NOT NULL,
	[PhoneNumber] VARCHAR(10) CHECK(LEN([PhoneNumber]) = 10) NOT NULL,
	[CountryId] INT FOREIGN KEY REFERENCES Countries(Id) NOT  NULL
)

CREATE TABLE Products(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE NOT NULL,
	[Description] VARCHAR(250) NOT NULL,
	[Recipe] VARCHAR(MAX) NOT NULL,
	[Price] MONEY CHECK(Price > 0) NOT NULL
)

CREATE TABLE Feedbacks(
	[Id] INT PRIMARY KEY IDENTITY,
	[Description] VARCHAR(255),
	[Rate] DECIMAL(4,2) CHECK(Rate BETWEEN 0 AND 10) NOT  NULL,
	[ProductId] INT FOREIGN KEY REFERENCES Products(Id) NOT  NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id) NOT  NULL
)

CREATE TABLE Distributors(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE NOT NULL,
	[AddressText] VARCHAR(30) NOT NULL,
	[Summary] VARCHAR(200) NOT NULL,
	[CountryId] INT FOREIGN KEY REFERENCES Countries(Id) NOT  NULL
)

CREATE TABLE Ingredients(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[Description] VARCHAR(200) NOT NULL,
	[OriginCountryId] INT FOREIGN KEY REFERENCES Countries(Id) NOT  NULL,
	[DistributorId] INT FOREIGN KEY REFERENCES Distributors(Id) NOT  NULL,
)

CREATE TABLE ProductsIngredients(
	[ProductId] INT FOREIGN KEY REFERENCES Products(Id) NOT  NULL,
	[IngredientId] INT FOREIGN KEY REFERENCES Ingredients(Id) NOT  NULL,
	PRIMARY KEY (ProductId, IngredientId)
)