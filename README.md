# RoofstockExercise
### Tech used
- Visual Studio 2022
- MS SQL Server Management Studio 18
- ASP.NET Core Web App (Model-View-Controller)
- SQL Server Database
- Newtonsoft.Json
- System.Data.SqlClient
- Bootstrap
- Google Chrome
- 
### How to install
1. Download the project and import to Visual Studio
2. Run `PropertyDB/PropertyDB.publish.xml` to setup the database for your local machine
3. Grab the database connection string under the properties of `PropertyDB/PropertyDB.publish.xml`, set the database field to `PropertyDB`, and set `ConnectionString` in the HomeController to that value

Example: `Data Source = MYDESKTOP;Database=PropertyDB;Integrated Security = True; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False`

4. Run the project via Visual Studio
5. 
### Work Flow
1. Installed VS Studio and MS SQL Server Management Studio
2. Generated an ASP.NET Core Web App (Model-View-Controller) 
3. Added models Address, Financial, Physical, Property, Properties, and Listing
4. Added json download and conversion to Listings (via Newtonson.Json), then passed them to the view
5. Setup table in view to display listings
6. Added save button to pass the chosen listing back to the controller
7. Generated a SQL Server Database project and added the Properties and Addresses tables
8. Published the tables to local machine and connected via MS SQL Server Management Studio
9. Used System.Data.SqlClient to connect to the database with this logic:
>> INSERT INTO Addresses(Address1, Address2, City, Country, County, District, State, Zip, ZipPlus4) VALUES(...) ; SELECT CAST(SCOPE_IDENTITY() AS INT)
>> "INSERT INTO Properties(Address, YearBuilt, ListPrice, MonthlyRent, GrossYield) VALUES(...)
10. Updated table format in view

### Potential Improvements
- Message box on Save/Failure
- Searchable table
- Sortable table
- Download table as csv/json
