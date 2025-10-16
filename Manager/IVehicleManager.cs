using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app.Manager
{
    internal interface IVehicleManager
    {
        void AddVehicle(BaseVehicle vehicle);
        void RemoveVehicle(int id);
        void ViewAllVehicles();
        void SearchByBrand(string brand);
        void SearchByType(string type);
        void CalculateRentalPrices();
    }
}
