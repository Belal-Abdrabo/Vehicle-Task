using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app
{
    public class Truck: BaseVehicle
    {
        public double LoadCapacity { get; set; }

        public override decimal Rental()
        {
            return 200 + ((decimal)LoadCapacity * 50);
        }
        public override bool IsValid(out string errorMessage)
        {
            if (LoadCapacity <= 0)
            {
                errorMessage = "Truck must have a positive load capacity.";
                return false;
            }
            if (!ValidateBase(out errorMessage))
                return false;

            errorMessage = string.Empty;
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $", LoadCapacity: {LoadCapacity} tons";
        }
    }
}
