namespace _10Mission.Models
{
    public class Bowler
    {
        public int BowlerId { get; set; }
        public string? BowlerFirstName { get; set; }
        public string? BowlerMiddleInit { get; set; }  // Made nullable
        public string? BowlerLastName { get; set; }    // Made nullable
        public string? BowlerAddress { get; set; }     // Made nullable
        public string? BowlerCity { get; set; }        // Made nullable
        public string? BowlerState { get; set; }       // Made nullable
        public string? BowlerZip { get; set; }         // Made nullable
        public string? BowlerPhoneNumber { get; set; } // Made nullable
        
        public int TeamId { get; set; }
        public Team? Team { get; set; }                // Made nullable
    }
}