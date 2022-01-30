using Microsoft.AspNetCore.Mvc;
using RoofstockExercise.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace RoofstockExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<PropertyListing>? Listings;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var properties = GetProperties();
            Listings = ConvertToListings(properties);
            return View(Listings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveListing(PropertyListing listing)
        {
            Console.WriteLine("TEST");
            Console.WriteLine(listing.YearBuilt);
            Console.WriteLine(listing.Address?.Address1);
            Console.WriteLine(listing.ListPrice);
            Console.WriteLine(listing.MonthlyRent);
            Console.WriteLine(listing.GrossYield);

            using(SqlConnection connection = new SqlConnection("Data Source=DESKTOP-273GM3L;Database=PropertyDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"))
            {
                connection.Open();

                var values = SetupValuesQuery(listing);
                var sql = CreateAddressQuery(values);
                SqlCommand cmd = new SqlCommand(sql, connection);
                Console.WriteLine("Insert called:\n" + sql);
                cmd.ExecuteNonQuery();

                sql = GetAddressIdQuery(values);
                Console.WriteLine("Get called:\n" + sql);
                cmd.ExecuteNonQuery();


                connection.Close();
            }

            return RedirectToAction("Index");
        }

        private static async Task<Properties?> GetProperties()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://samplerspubcontent.blob.core.windows.net/public/properties.json");
            return JsonConvert.DeserializeObject<Properties>(response);
        }

        private static List<PropertyListing> ConvertToListings(Task<Properties?> properties)
        {
            var list = new List<PropertyListing>();
            if (properties?.Result?.PropertyList != null)
            {
                foreach (var property in properties.Result.PropertyList)
                {
                    var temp = new PropertyListing
                    {
                        Address = property.Address,
                        YearBuilt = property.Physical?.YearBuilt,
                    };

                    if (property.Financial?.MonthlyRent != null && property.Financial?.ListPrice != null && property.Financial?.ListPrice != 0)
                    {
                        temp.MonthlyRent = Math.Round(property.Financial.MonthlyRent,2);
                        temp.ListPrice = Math.Round(property.Financial.ListPrice,2);
                        var gross = temp.MonthlyRent * 12 / temp.ListPrice;
                        if (gross != null) temp.GrossYield = Math.Round((decimal)gross,2);
                    }
                    
                    list.Add(temp);
                }
            }
            return list;
        }

        private static string SetupValuesQuery(PropertyListing listing)
        {
            // Ugly way of doing this but it works
            if (listing.Address?.Address1 == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.Address1 + "\',"; }

            if (listing.Address?.Address2 == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.Address2 + "\',"; }

            if (listing.Address?.City == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.City + "\',"; }

            if (listing.Address?.Country == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.Country + "\',"; }

            if (listing.Address?.County == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.County + "\',"; }

            if (listing.Address?.District == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.District + "\',"; }

            if (listing.Address?.State == null) { sql += "NULL,"; }
            else { sql += "\'" + listing.Address.State + "\',"; }

            if (listing.Address?.Zip == null) { sql += "NULL,"; }
            else { sql += listing.Address.Zip + ","; }

            if (listing.Address?.ZipPlus4 == null) { sql += "NULL)"; }
            else { sql += listing.Address.ZipPlus4 + ")"; }

            return sql;
        }

        private static string CreateAddressQuery(string values)
        {
            return "INSERT INTO Addresses(Address1, Address2, City, Country, County, District, State, Zip, ZipPlus4) VALUES(" + values;
        }

        private static string GetAddressIdQuery(string values)
        {
            var sql = "SELECT Id FROM Addresses WHERE ";
            return sql;
        }
    }
}