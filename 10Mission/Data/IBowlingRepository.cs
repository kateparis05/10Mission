using _10Mission.Models;

namespace _10Mission.Data
{
    public interface IBowlingRepository
    {
        IEnumerable<Bowler> GetBowlersWithTeam(string[] teamNames);
    }
}