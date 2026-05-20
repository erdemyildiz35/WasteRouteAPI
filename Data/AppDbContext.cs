using Microsoft.EntityFrameworkCore;
using WasteRouteAPI.Models;

namespace WasteRouteAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WasteRoute> Routes { get; set; }
        public DbSet<CollectionPoint> CollectionPoints { get; set; }
    }
}