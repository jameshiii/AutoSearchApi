using static AutoSearchApi.Models.Vehicle;

namespace AutoSearchApi.ViewModels
{
    public class Dealer2Vehicle : Vehicle
    {
        public override string Status
        {
            get
            {
                return VehicleStatus.ToString();
            }
        }
    }
}
