namespace WasteRouteAPI.Models
{
    public class CollectionPoint
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string WasteType { get; set; } = string.Empty; // Recycling, Organic, General
        public string Status { get; set; } = "Pending"; // Pending, Collected, Skipped
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}