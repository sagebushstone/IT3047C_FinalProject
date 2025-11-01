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

            modelBuilder.Entity<Trail>().HasData(
                new Trail
                {
                    TrailId = 1,
                    TrailName = "Colerain Trail",
                    State = "Ohio",
                    Park = "Mt. Airy Forest",
                    DifficultyLevel = 1,
                    Description = "The Colerain trail is an excellent beginner level trail in the beautiful Mt. Airy Forest, located on the west side of Cincinnati. As the trail is under a mile, expect an easy forest walk that can be completed in under an hour."
                }, 
                new Trail
                {
                    TrailId = 2,
                    TrailName = "Ponderosa Trail",
                    State = "Ohio",
                    Park = "Mt. Airy Forest",
                    DifficultyLevel = 3,
                    Description = "The Ponderosa trail is an intermediate level 4 mile hiking trail in the scenic Mt. Airy Forest. This trail will take you on a meandering path through a majority of the eastern half of the forest, and runs in tandem with multiple other trails located within the forest. If you are looking for a solid challenge, this may be the trail for you."
                },
                new Trail
                {
                    TrailId = 3,
                    TrailName = "B Loop Trail",
                    State = "Ohio",
                    Park = "Buttercup Valley and Parker Woods",
                    DifficultyLevel = 2,
                    Description = "Buttercup Valley and Parker Woods are a smaller nature reserve located on the west side of Cincinnati. The 1.4 mile long B Loop Trail takes you through both of the reserves, and acts as a more casual nature trail. Even so, there are still plenty of scenic twists, turns, bridges, and hills to keep the trail interesting even for more experienced hikers."
                },
                new Trail
                {
                    TrailId = 4,
                    TrailName = "Shaker Trace Outer Loop",
                    State = "Ohio",
                    Park = "Miami Whitewater Forest",
                    DifficultyLevel = 4,
                    Description = "In the gorgeous Miami Whitewater Forest located in Harrison OH, hikers are treated to multiple options for trails. The main trail is the Shaker Trace Loop, which gives hikers an option between the easier 1.4 mile inner loop, or the more challenging 7.8 mile outer loop. With either choice, you will be treated to the beautiful forest, challenging inclines, refreshing waterways all on a paved pathway. If you are looking for an excellent entry level intermediate level course that’s still easy on the knees, This trail may be for you."
                }
            );
        }
    }
}
