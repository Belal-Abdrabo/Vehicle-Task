using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_app
{
    public class Motorcycle : BaseVehicle
    {
        public bool HasSidecar { get; set; }

        public override bool IsValid(out string errorMessage)
        {
            if (!ValidateBase(out errorMessage))
                return false;
            errorMessage = string.Empty;
            return true;
        }
        public override decimal Rental()
        {
            return HasSidecar ? 120 : 80;
        }
        public override string ToString()
        {
            return base.ToString() + $", HasSidecar: {HasSidecar}";
        }
    }
}
