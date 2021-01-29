using Microsoft.EntityFrameworkCore;

namespace AutoSearchApi.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        // TODO: Consider using User Preference Model to store statuses.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .ToTable("Vehicles");

            modelBuilder.Entity<Vehicle>()
                .HasKey(e => e.Id); // will automatically create an identity column for numeric types by default

            modelBuilder.Entity<Vehicle>()
                .Property(c => c.Status) // Status stored as a numeric in the database, however is converted to an enum in ef
                .HasConversion<byte>();

            base.OnModelCreating(modelBuilder);
        }
    }
}