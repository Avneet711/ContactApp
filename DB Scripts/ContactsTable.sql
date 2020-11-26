IF NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'Contacts')
BEGIN
	CREATE TABLE Contacts
	(
	ContactId INT IDENTITY(1,1),
	FirstName VARCHAR(200) NOT NULL,
	LastName VARCHAR(200),
	Email VARCHAR(200) NOT NULL UNIQUE,
	PhoneNumber BIGINT,
	ContactStatus BIT
	)
END