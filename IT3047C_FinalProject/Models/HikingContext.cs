using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProject.Models
{
    public class HikingContext : DbContext
    {
        public HikingContext(DbContextOptions<HikingContext> options) : base(options) { }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<Gear> Gears { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gear>().HasData(
                new Gear
                {
                    GearId = 1,
                    GearName = "Backpack",
                    Weight = 0.4,
                    Cost = 100,
                    RecommendedQuantity = 1
                },
                new Gear
                {
                    GearId = 2,
                    GearName = "Hiking Shoes",
                    Weight = 0.5,
                    Cost = 150,
                    RecommendedQuantity = 1
                },
                new Gear
                {
                    GearId = 3,
                    GearName = "Trekking Poles",
                    Weight = 0.5,
                    Cost = 100,
                    RecommendedQuantity = 2
                },
                new Gear
                {
                    GearId = 4,
                    GearName = "2l Water Bottle",
                    Weight = 0.3,
                    Cost = 50,
                    RecommendedQuantity = 1
                },
                new Gear
                {
                    GearId = 5,
                    GearName = "Hat",
                    Weight = 0.1,
                    Cost = 30,
                    RecommendedQuantity = 1
                }
            );
        }
    }
}
