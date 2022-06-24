CREATE OR ALTER PROCEDURE [dbo].[GetAllPeople]
AS
BEGIN
	SELECT 
		Id,
		Forename,
		Surname, 
		Dob
	FROM Person
END
GO