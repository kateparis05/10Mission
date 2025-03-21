namespace _10Mission.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }          // Made nullable
        public ICollection<Bowler>? Bowlers { get; set; } // Made nullable
    }
}