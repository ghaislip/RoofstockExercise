using Newtonsoft.Json;

namespace RoofstockExercise.Models
{
    public partial class Properties
    {
        [JsonProperty(PropertyName ="properties")]
        public Property[]? PropertyList { get; set; }
    }

    public partial class Property
    {
        [JsonProperty(PropertyName = "address")]
        public Address? Address { get; set; }

        [JsonProperty(PropertyName = "financial")]
        public Financial? Financial { get; set; }

        [JsonProperty(PropertyName = "physical")]
        public Physical? Physical { get; set; }

    }

    public partial class Address
    {
        [JsonProperty(PropertyName = "address1")]
        public string? Address1 { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string? Address2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string? City { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string? Country { get; set; }

        [JsonProperty(PropertyName = "county")]
        public string? County { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string? District { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string? State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string? Zip { get; set; }

        [JsonProperty(PropertyName = "zipPlus4")]
        public string? ZipPlus4 { get; set; }
    }

    public partial class Financial
    {
        [JsonProperty(PropertyName = "listPrice")]
        public decimal ListPrice { get; set; }

        [JsonProperty(PropertyName = "monthlyRent")]
        public decimal MonthlyRent { get; set; }
    }

    public partial class Physical
    {
        [JsonProperty(PropertyName = "yearBuilt")]
        public int YearBuilt { get; set; }
    }
}