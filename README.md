# RoofstockExercise
### Tech used
- Visual Studio 2022
- MS SQL Server Management Studio 18
- ASP.NET Core Web App (Model-View-Controller)
- SQL Server Database
- Newtonsoft.Json
- System.Data.SqlClient
- Google Chrome
### How to install
1. Download the project and import to Visual Studio
2. Run `PropertyDB/PropertyDB.publish.xml` to setup the database for your local machine
3. Grab the database connection string under the properties of `PropertyDB/PropertyDB.publish.xml`, add the database field to `PropertyDB`, and set `SqlConnection` in the HomeController to that value

Example: `Data Source = MYDESKTOP;Database=PropertyDB;Integrated Security = True; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False`

4. Run the project via Visual Studio
### Work Flow
