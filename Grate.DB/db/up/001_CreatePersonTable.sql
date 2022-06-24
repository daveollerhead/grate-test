CREATE TABLE Person (
	Id int IDENTITY(1, 1) PRIMARY KEY,
	Forename varchar(255) NOT NULL,
	Surname varchar(255) NOT NULL,
	Dob datetime,
)