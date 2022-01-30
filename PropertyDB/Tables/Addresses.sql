CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Address1] TEXT NULL, 
    [Address2] TEXT NULL, 
    [City] TEXT NULL, 
    [Country] TEXT NULL, 
    [County] TEXT NULL, 
    [District] TEXT NULL, 
    [State] TEXT NULL, 
    [Zip] INT NULL, 
    [ZipPlus4] INT NULL
)
