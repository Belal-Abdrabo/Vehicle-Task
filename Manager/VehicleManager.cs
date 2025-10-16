using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app.Manager
{
    public class VehicleManager : IVehicleManager
    {

        private List<BaseVehicle> vehicles;
        public VehicleManager()
        {
            vehicles = new List<BaseVehicle>();
        }
        public void AddVehicle(BaseVehicle vehicle)
        {
            if(vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null");
            }
            if(vehicles.Any(v => v.Id == vehicle.Id))
            {
                throw new ArgumentException($"A vehicle with ID {vehicle.Id} already exists.");
            }
            if (!vehicle.IsValid(out string errorMessage))
            {
                throw new ArgumentException($"Vehicle is not valid: {errorMessage}");
            }
            vehicles.Add(vehicle);

        }

        public void CalculateRentalPrices()
        {
            foreach(var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle ID: {vehicle.Id}, Rental Price: {vehicle.Rental():C}");
            }
        }

        public void RemoveVehicle(int id)
        {
            if(vehicles.Any(v => v.Id == id))
            {
                var vehicleToRemove = vehicles.First(v => v.Id == id);
                vehicles.Remove(vehicleToRemove);
            }
            else
            {
                throw new ArgumentException($"No vehicle found with ID {id}");
            }
        }

        public void SearchByBrand(string brand)
        {
            if(string.IsNullOrWhiteSpace(brand))
            {
                Console.WriteLine("Brand cannot be empty.");
                return;
            }
            foreach (var vehicle in vehicles.Where(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(vehicle);
            }
        }

        public void SearchByType(string type)
        {
            if(string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Type cannot be empty.");
                return;
            }
            foreach (var vehicle in vehicles.Where(v => v.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(vehicle);
            }
        }

        public void ViewAllVehicles()
        {
            if(vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available.");
                return;
            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
