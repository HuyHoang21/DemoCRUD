CREATE DATABASE LoginDB
Use LoginDB
CREATE TABLE [User](
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(128),
	LastName NVARCHAR(128),
	UserName VARCHAR(64)
)
CREATE TABLE [Account] (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(64) UNIQUE,
	Password BINARY(64),
)

-- CREATE TRIGGER sampleTrigger
--     ON [User]
--     FOR DELETE
-- AS
--     DECLARE @maxID int;

--     SELECT @maxID = MAX(Id)
--     FROM [User];

--     DBCC CHECKIDENT ([User], RESEED, @maxID);
-- GO