using Microsoft.AspNetCore.Mvc;
using RoofstockExercise.Models;
using System.Diagnostics;
using Newtonsoft.Json;

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
        [ActionName("SaveListing")]
        public IActionResult Index(PropertyListing listing)
        {
            Console.WriteLine("TEST");
            Console.WriteLine(listing.YearBuilt);
            Console.WriteLine(listing.Address?.Address1);
            Console.WriteLine(listing.ListPrice);
            Console.WriteLine(listing.MonthlyRent);
            Console.WriteLine(listing.GrossYield);
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
    }
}