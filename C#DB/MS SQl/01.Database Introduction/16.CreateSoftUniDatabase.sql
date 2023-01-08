CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50),
)

CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[AddressText] NVARCHAR(50),
	[TownId] INT FOREIGN  KEY REFERENCES [Towns]([Id]),
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(50),
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY,
	[FirstName] NVARCHAR(50),
	[MiddleName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[JobTitle] NVARCHAR(50) DEFAULT('Programmer'),
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
	[HireDate] DATE,
	[Salary] DECIMAL (5, 2) DEFAULT(1260.50),
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)