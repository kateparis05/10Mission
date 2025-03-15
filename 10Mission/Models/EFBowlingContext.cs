using Microsoft.EntityFrameworkCore;

namespace _10Mission.Models
{
    public class EFBowlingContext : DbContext
    {
        public EFBowlingContext(DbContextOptions<EFBowlingContext> options) : base(options) { }
        
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}