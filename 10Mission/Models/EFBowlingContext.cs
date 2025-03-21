using Microsoft.EntityFrameworkCore;

namespace _10Mission.Models
{
    public class EfBowlingContext(DbContextOptions<EfBowlingContext> options) : DbContext(options)
    {
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Bowler and Team
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamId);
                
            // Optional: If you need to prevent NULL values from causing issues
            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerMiddleInit)
                .IsRequired(false);
        }
    }
}