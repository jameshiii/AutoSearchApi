using static AutoSearchApi.Models.Vehicle;

namespace AutoSearchApi.ViewModels
{
    public class Vehicle
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public virtual string Status { get; }
        internal VehicleStatus VehicleStatus { get; set;}
    }
}
