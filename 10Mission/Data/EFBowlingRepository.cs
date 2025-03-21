using _10Mission.Models;
using Microsoft.EntityFrameworkCore;

namespace _10Mission.Data
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private readonly EfBowlingContext _context;
        
        public EFBowlingRepository(EfBowlingContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Bowler> GetBowlersWithTeam(string[] teamNames)
        {
            try
            {
                var bowlersWithTeams = _context.Bowlers
                    .Include(b => b.Team)
                    .Where(b => b.Team != null && teamNames.Contains(b.Team.TeamName))
                    .ToList();
                    
                return bowlersWithTeams;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBowlersWithTeam: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return new List<Bowler>();
            }
        }
    }
}