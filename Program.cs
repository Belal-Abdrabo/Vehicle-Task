using System.Numerics;
using Vehicle_app.Manager;

namespace Vehicle_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleManager manager = new VehicleManager();

            while (true)
            {
                Console.WriteLine("\n=== Vehicle Management System ===");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Show All Vehicles");
                Console.WriteLine("3. Search by Type");
                Console.WriteLine("4. Search by Brand");
                Console.WriteLine("5. Remove Vehicle");
                Console.WriteLine("6. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddVehicle(manager);
                        break;
                    case "2":
                        ShowAll(manager);
                        break;
                    case "3":
                        SearchVehicleByType(manager);
                        break;
                    case "4":
                        SearchVehicleByBrand(manager);
                        break;
                    case "5":
                        RemoveVehicle(manager);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddVehicle(VehicleManager manager)
        {
            try
            {
                Console.Write("Enter Type (Car, Truck, Motorcycle): ");
                string typeInput = Console.ReadLine().ToLower();

                if (typeInput != "car"|| typeInput != "motorcycle" || typeInput != "truck")
                {
                    Console.WriteLine("Invalid vehicle type.");
                    return;
                }
                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine();

                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                Console.Write("Enter Year: ");
                if (!int.TryParse(Console.ReadLine(), out int year))
                {
                    Console.WriteLine("Invalid year input.");
                    return;
                }

                Console.Write("Enter Max Speed (km/h): ");
                if (!int.TryParse(Console.ReadLine(), out int maxSpeed))
                {
                    Console.WriteLine("Invalid speed input.");
                    return;
                }

              
                BaseVehicle vehicle;
                switch (type)
                {
                    case VehicleTypes.Car:
                        var car = new Car
                        {
                            Brand = brand,
                            Model = model,
                            Year = year,
                            MaxSpeed = maxSpeed,
                            Type = VehicleTypes.Car
                        };

                        Console.Write("Enter Number of Doors (2–5): ");
                        if (int.TryParse(Console.ReadLine(), out int doors))
                            car.NumberOfDoors = doors;

                        Console.Write("Is it Electric? (yes/no): ");
                        car.IsElectric = Console.ReadLine()?.Trim().ToLower() == "yes";
                        vehicle = car;
                        break;

                    case VehicleTypes.Truck:
                        var truck = new Truck
                        {
                            Brand = brand,
                            Model = model,
                            Year = year,
                            MaxSpeed = maxSpeed,
                            Type = VehicleTypes.Truck
                        };

                        Console.Write("Enter Load Capacity (in tons): ");
                        if (double.TryParse(Console.ReadLine(), out double cargo))
                            truck.LoadCapacity = cargo;

                        vehicle = truck;
                        break;

                    case VehicleTypes.Motorcycle:
                        var moto = new Motorcycle
                        {
                            Brand = brand,
                            Model = model,
                            Year = year,
                            MaxSpeed = maxSpeed,
                            Type = VehicleTypes.Motorcycle
                        };

                        Console.Write("Has Sidecar? (yes/no): ");
                        moto.HasSidecar = Console.ReadLine()?.Trim().ToLower() == "yes";
                        vehicle = moto;
                        break;

                    default:
                        Console.WriteLine(" Unsupported vehicle type.");
                        return;
                }

                manager.AddVehicle(vehicle);
                Console.WriteLine("\nVehicle added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }


        static void ShowAll(VehicleManager manager)
        {
            Console.WriteLine(" All Vehicles:");
            manager.ViewAllVehicles();
        }

        static void SearchVehicleByBrand(VehicleManager manager)
        {
            Console.Write("Enter Brand to search (or leave empty): ");
            string brand = Console.ReadLine();
            manager.SearchByBrand(brand);

        }
        static void SearchVehicleByType(VehicleManager manager)
        {
            Console.Write("Enter Type to search (Car, Truck, Motorcycle) or leave empty: ");
            string type = Console.ReadLine();
            manager.SearchByType(type);
        }

        static void RemoveVehicle(VehicleManager manager)
        {
            Console.Write("Enter vehicle Id to remove: ");
            var id = Convert.ToInt32(Console.ReadLine());

            manager.RemoveVehicle(id);

        }
    }
}
