namespace WasteRouteAPI.Models
{
    public class WasteRoute
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public string Status { get; set; } = "Planned";
        public DateTime PlannedDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}