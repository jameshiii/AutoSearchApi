namespace AutoSearchApi.Models
{
    public class Vehicle
    {
        public enum VehicleStatus : byte
        {
            Enroute,
            Active,
            Pending,
            Sold
        }

        public int Id {get;set;}
        public decimal Price {get;set;}
        public string Model {get;set;}
        public int Mileage {get;set;}
        public string Color {get;set;}
        public VehicleStatus Status { get; set; }
    }
}
