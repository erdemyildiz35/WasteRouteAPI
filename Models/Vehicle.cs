namespace WasteRouteAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Truck, Van, etc.
        public string Status { get; set; } = "Available"; // Available, OnRoute, Maintenance
        public int Capacity { get; set; } // kg cinsinden
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}