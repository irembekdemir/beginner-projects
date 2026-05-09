using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public class RentalService
    {
        private List<Car> cars = new List<Car>();
        private List<Reservation> reservations = new List<Reservation>();

        public RentalService()
        {
            // Sample cars
            cars.Add(new Car { Plate = "06ABC123", BrandModel = "Toyota Corolla", DailyPrice = 1500 });
            cars.Add(new Car { Plate = "34XYZ789", BrandModel = "Honda Civic", DailyPrice = 1700 });
        }

        public List<string> GetAvailableCars(DateTime start, DateTime end)
        {
            List<string> available = new List<string>();

            foreach (var car in cars)
            {
                if (IsCarAvailable(car.Plate, start, end))
                {
                    available.Add(car.Plate + " - " + car.BrandModel);
                }
            }

            return available;
        }

        public bool IsCarAvailable(string plate, DateTime start, DateTime end)
        {
            foreach (var r in reservations)
            {
                if (r.Plate == plate)
                {
                    bool overlap =
                        start <= r.EndDate &&
                        end >= r.StartDate;

                    if (overlap)
                        return false;
                }
            }

            return true;
        }

        public double GetDailyPrice(string plate)
        {
            foreach (var car in cars)
            {
                if (car.Plate == plate)
                    return car.DailyPrice;
            }

            return 0;
        }

        public void AddReservation(string customer, string plate, DateTime start, DateTime end)
        {
            string conflict = GetConflictReason(plate, start, end);

            if (conflict != "No conflict")
            {
                Console.WriteLine("ERROR: " + conflict);
                return;
            }

            double price = CalculateReservationPrice(plate, start, end);

            reservations.Add(new Reservation
            {
                CustomerName = customer,
                Plate = plate,
                StartDate = start,
                EndDate = end,
                TotalPrice = price
            });

            Console.WriteLine("Reservation created successfully. Price: " + price);
        }

        public double CalculateReservationPrice(string plate, DateTime start, DateTime end)
        {
            double dailyPrice = GetDailyPrice(plate);
            int days = (end - start).Days;

            return days * dailyPrice;
        }

        public void CancelReservation(string plate)
        {
            reservations.RemoveAll(r => r.Plate == plate);
            Console.WriteLine("Reservation cancelled.");
        }

        public double TotalIncome()
        {
            double total = 0;

            foreach (var r in reservations)
            {
                total += r.TotalPrice;
            }

            return total;
        }

        public List<string> GetCustomerReservations(string customer)
        {
            List<string> result = new List<string>();

            foreach (var r in reservations)
            {
                if (r.CustomerName == customer)
                {
                    result.Add($"{r.Plate} ({r.StartDate.ToShortDateString()} - {r.EndDate.ToShortDateString()})");
                }
            }

            return result;
        }

        public string MostRentedCar()
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var r in reservations)
            {
                if (count.ContainsKey(r.Plate))
                    count[r.Plate]++;
                else
                    count[r.Plate] = 1;
            }

            string best = "";
            int max = 0;

            foreach (var item in count)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    best = item.Key;
                }
            }

            return best;
        }
    }

    public string GetConflictReason(string plate, DateTime start, DateTime end)
    {
        foreach (var r in reservations)
        {
            if (r.Plate == plate)
            {
                bool overlap =
                    start <= r.EndDate &&
                    end >= r.StartDate;

                if (overlap)
                {
                    return $"Conflict with reservation: {r.StartDate} - {r.EndDate} by {r.CustomerName}";
                }
            }
        }

        return "No conflict";
    }
}