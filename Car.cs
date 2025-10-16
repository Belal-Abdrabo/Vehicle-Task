using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app
{
    public class Car : BaseVehicle
    {
        public int NumberOfDoors { get; set; }

        public bool IsElectric { get; set; }

        public override bool IsValid(out string errorMessage)
        {
            if (!ValidateBase(out errorMessage))
                return false;

            if (NumberOfDoors < 2 || NumberOfDoors > 5)
            {
                errorMessage = "Number of doors must be between 2 and 5.";
                return false;
            }
            errorMessage = string.Empty;
            return true;

        }

        public override decimal Rental()
        {
            return (MaxSpeed / 100) * 50m;
        }
        public override string ToString()
        {
            return base.ToString() + $", IsElectric: {IsElectric} , and number of doors is {NumberOfDoors}";
        }
    }
}
