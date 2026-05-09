using CarRentalSystem.Services;

class Program
{
    static void Main()
    {
        RentalService service = new RentalService();

        while (true)
        {
            Console.WriteLine("\n--- CAR RENTAL SYSTEM ---");
            Console.WriteLine("1 - Show available cars");
            Console.WriteLine("2 - Add reservation");
            Console.WriteLine("3 - Cancel reservation");
            Console.WriteLine("4 - Total income");
            Console.WriteLine("5 - Customer reservations");
            Console.WriteLine("6 - Most rented car");
            Console.WriteLine("0 - Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Start date: ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.Write("End date: ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                var list = service.GetAvailableCars(start, end);

                foreach (var car in list)
                    Console.WriteLine(car);
            }

            else if (choice == "2")
            {
                Console.Write("Customer: ");
                string customer = Console.ReadLine();

                Console.Write("Plate: ");
                string plate = Console.ReadLine();

                Console.Write("Start date: ");
                DateTime start = DateTime.Parse(Console.ReadLine());

                Console.Write("End date: ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                service.AddReservation(customer, plate, start, end);
            }

            else if (choice == "3")
            {
                Console.Write("Plate to cancel: ");
                string plate = Console.ReadLine();

                service.CancelReservation(plate);
            }

            else if (choice == "4")
            {
                Console.WriteLine("Total income: " + service.TotalIncome());
            }

            else if (choice == "5")
            {
                Console.Write("Customer name: ");
                string customer = Console.ReadLine();

                var list = service.GetCustomerReservations(customer);

                foreach (var item in list)
                    Console.WriteLine(item);
            }

            else if (choice == "6")
            {
                Console.WriteLine("Most rented car: " + service.MostRentedCar());
            }

            else if (choice == "0")
            {
                break;
            }
        }
    }
}