CREATE TABLE [dbo].[Properties]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Address] INT NOT NULL, 
    [YearBuilt] INT NULL, 
    [ListPrice] DECIMAL(17, 2) NULL, 
    [MonthlyRent] DECIMAL(17, 2) NULL, 
    [GrossYield] DECIMAL(17, 2) NULL
)
