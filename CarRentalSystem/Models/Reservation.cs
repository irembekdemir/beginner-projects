namespace CarRentalSystem.Models
{
    public class Reservation
    {
        public string CustomerName { get; set; }
        public string Plate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double TotalPrice { get; set; }
    }
}