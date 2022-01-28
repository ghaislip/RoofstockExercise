namespace RoofstockExercise.Models
{ 
    public class PropertyListing
    {
        public Address? Address { get; set; }

        public int? YearBuilt { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? MonthlyRent { get; set; }

        public decimal? GrossYield { get; set; }
    }
}
