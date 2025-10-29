using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProject.Models
{
    public class HikingContext : DbContext
    {
        public HikingContext(DbContextOptions<HikingContext> options) : base(options) { }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<Gear> Gears { get; set; }
    }
}
