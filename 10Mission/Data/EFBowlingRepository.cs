using _10Mission.Models;
using Microsoft.EntityFrameworkCore;

namespace _10Mission.Data
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private EFBowlingContext _context;
        
        public EFBowlingRepository(EFBowlingContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Bowler> GetBowlersWithTeam(string[] teamNames)
        {
            return _context.Bowlers
                .Include(b => b.Team)
                .Where(b => teamNames.Contains(b.Team.TeamName))
                .ToList();
        }
    }
}