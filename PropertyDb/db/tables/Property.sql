CREATE TABLE [dbo].[Property]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Address] NCHAR(30) NOT NULL, 
    [YearBuilt] INT NOT NULL, 
    [ListPrice] INT NOT NULL, 
    [MonthlyRent] INT NOT NULL, 
    [GrossYield] INT NOT NULL
)
