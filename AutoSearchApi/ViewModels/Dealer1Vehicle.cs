using System.Collections.Generic;
using static AutoSearchApi.Models.Vehicle;

namespace AutoSearchApi.ViewModels
{
    public class Dealer1Vehicle : Vehicle
    {
        static readonly Dictionary<VehicleStatus, string> statusLookup = new Dictionary<VehicleStatus, string>
        {
            { VehicleStatus.Active, "For Sale" },
            { VehicleStatus.Enroute, "Enroute" },
            { VehicleStatus.Pending, "Pending" },
            { VehicleStatus.Sold, "Sold" }
        };

        public override string Status
        {
            get
            {
                return statusLookup[VehicleStatus];
            }
        }
    }
}
