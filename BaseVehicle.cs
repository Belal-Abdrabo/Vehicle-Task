using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app
{
    public abstract class BaseVehicle
    {
        private static int _nextId = 1;
        public int Id { get; } = _nextId++;

        public required string Brand { get; set; }
        public required VehicleTypes Type { get; set; }

        public required string Model { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }

        public abstract decimal Rental();
        protected bool ValidateBase(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(Brand) ||
                string.IsNullOrWhiteSpace(Model) ||
                Year < 1960 || Year > DateTime.Now.Year + 1 ||
                MaxSpeed <= 0)
            {
                errorMessage = "Invalid base vehicle data.";
                return false;
            }

            if (!Enum.IsDefined(typeof(VehicleTypes), Type))
            {
                errorMessage = "Invalid or undefined vehicle type.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
        public virtual bool IsValid(out string errorMessage)
        {
            return ValidateBase(out errorMessage);
        }


        public override string ToString()
        {
            return $"Vehicle Details =>  Vehicle type :{Type} , Vehicle ID :{Id} Brand {Brand} , Model {Model},Year : {Year} , MaxSpeed : {MaxSpeed} ";
        }
    }
}
