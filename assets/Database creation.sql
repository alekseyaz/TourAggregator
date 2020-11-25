USE master;
GO

DECLARE @someNVarChar nvarchar(15)
IF (EXISTS (SELECT * FROM master.sys.databases WHERE NAME = 'TourDB2'))
BEGIN 
	SET @someNVarChar = N'База есть!'
	PRINT @someNVarChar

	ALTER DATABASE TourDB
	SET SINGLE_USER --SET MULTI_USER --READ_ONLY --SET OFFLINE
	WITH ROLLBACK IMMEDIATE; -- Перевести базу данных в автономный режим, выполнить отмену всех открытых транзакций и закрыть сеансы

	PRINT 'Удалим ее!'
	DROP DATABASE TourDB

END
ELSE
BEGIN
	SET @someNVarChar = N'Базы нет!'
	PRINT @someNVarChar
END

--1. Создать базу данных интернет магазина InternetShopDB.

CREATE DATABASE TourDB               
COLLATE Cyrillic_General_CI_AS
GO

USE TourDB
GO


CREATE TABLE Citys
(
	ID int NOT NULL IDENTITY,
	[Name] nvarchar(50) NOT NULL,
)  
GO

CREATE TABLE Countrys
(
	ID int NOT NULL IDENTITY,
	[Name] nvarchar(50) NOT NULL,
)  
GO

CREATE TABLE Hotels
(
	ID int NOT NULL IDENTITY,
	[Name] nvarchar(50) NOT NULL,
	[Address] nvarchar(50) NOT NULL,
	YearBuilt date NOT NULL
)  
GO

CREATE TABLE TourProviders
(
	ID int NOT NULL IDENTITY,
	[Name] nvarchar(50) NOT NULL,
)  
GO

CREATE TABLE Tours
(
	ID int NOT NULL IDENTITY,
	TourProviderID int NULL,  
	HotelID int NULL,
	CityID int NULL,
	CountryID int NULL,
	TypeRoom int NOT NULL,
	DateDeparture date NOT NULL,
	DateArrival date NOT NULL,
	NumberNights int NOT NULL,
	PricePerNight  money NOT NULL,
	MaximumTourists int NOT NULL
)  
GO

----------------

ALTER TABLE Citys ADD 
	CONSTRAINT PK_Citys PRIMARY KEY(ID) 
GO

ALTER TABLE Countrys ADD 
	CONSTRAINT PK_Countrys PRIMARY KEY(ID) 
GO

ALTER TABLE Hotels ADD 
	CONSTRAINT PK_Hotels PRIMARY KEY(ID) 
GO

ALTER TABLE TourProviders ADD 
	CONSTRAINT PK_TourProviders PRIMARY KEY(ID)
GO

ALTER TABLE Tours ADD
	CONSTRAINT PK_Tours PRIMARY KEY(ID) 
GO

ALTER TABLE Tours ADD CONSTRAINT
	FK_Tours_TourProviders FOREIGN KEY(TourProviderID) 
	REFERENCES TourProviders(ID)
	ON DELETE SET NULL 
GO

ALTER TABLE Tours ADD CONSTRAINT
	FK_Tours_Citys FOREIGN KEY(CityID) 
	REFERENCES Citys(ID)
	ON DELETE SET NULL  
GO

ALTER TABLE Tours ADD CONSTRAINT
	FK_Tours_Countrys FOREIGN KEY(CountryID) 
	REFERENCES Countrys(ID)
	ON DELETE SET NULL  
GO

ALTER TABLE Tours ADD CONSTRAINT
	FK_Tours_Hotels FOREIGN KEY(HotelID) 
	REFERENCES Hotels(ID)
	ON DELETE SET NULL  
GO



--------------------
INSERT Citys 
([Name])
VALUES
('Москва'),
('Стамбул'),
('Валенсия')
GO

INSERT Countrys 
([Name])
VALUES
('Россия'),
('Турция'),
('Испания')
GO

INSERT Hotels 
([Name], [Address], YearBuilt)
VALUES
('Плаза','Часовая улица, 28к3',DATEADD(DAY, -85, GETDATE())),
('Маза','Ленинградский проспект, 72к1',DATEADD(DAY, -45, GETDATE())),
('НоуНейм','улица Черняховского, 10',DATEADD(DAY, -35, GETDATE()))
GO

INSERT TourProviders 
([Name])
VALUES
('Tui'),
('Another provider')
GO

INSERT Tours 
(TourProviderID, HotelID, CityID, CountryID, TypeRoom, DateDeparture, DateArrival, NumberNights, PricePerNight, MaximumTourists)
VALUES
(1,1,1,1,1, DATEADD(DAY, -26, GETDATE()),DATEADD(DAY, -85, GETDATE()), 3, 150.50, 1),
(2,2,2,2,2, DATEADD(DAY, -32, GETDATE()),DATEADD(DAY, -45, GETDATE()), 5, 200, 2),
(2,1,2,1,1, DATEADD(DAY, -11, GETDATE()),DATEADD(DAY, -35, GETDATE()), 7, 300, 2)
GO