namespace CarRentalSystem.Models
{
    public class Car
    {
        public string Plate { get; set; }
        public string BrandModel { get; set; }
        public string Type { get; set; } // SUV / Sedan / Hatchback
        public double DailyPrice { get; set; }
    }
}