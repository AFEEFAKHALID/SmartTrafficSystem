using Microsoft.EntityFrameworkCore;
using SmartTrafficSystem.Models;

namespace SmartTrafficSystem.Data
{
    public class TrafficDbContext : DbContext
    {
        public TrafficDbContext(DbContextOptions<TrafficDbContext> options)
            : base(options)
        {
        }

        public DbSet<Road> Roads { get; set; }
        public DbSet<Signal> Signals { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<TrafficData> TrafficData { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Road>().HasKey(r => r.RoadId);
            modelBuilder.Entity<Signal>().HasKey(s => s.SignalId);
            modelBuilder.Entity<Emergency>().HasKey(e => e.EmergencyId);
            modelBuilder.Entity<TrafficData>().HasKey(t => t.TrafficId);
            modelBuilder.Entity<Vehicle>().HasKey(v => v.VehicleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}