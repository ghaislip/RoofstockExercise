CREATE TABLE [dbo].[Properties]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Address] INT NOT NULL, 
    [YearBuilt] INT NULL, 
    [ListPrice] DECIMAL NULL, 
    [MonthyRent] DECIMAL NULL, 
    [GrossYield] DECIMAL NULL
)
