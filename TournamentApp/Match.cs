using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Match
    {
        Random random = new Random();
        Guid newGuid = Guid.NewGuid();

        string[] places = { "Big Stadium", "Middle Stadium", 
            "Small Stadium", "Main Stadium" };

        public Team? team1 { get; set; }
        public Team? team2 { get; set; }
        public DateOnly date { get; set; }
        public string? location { get; set; }
        public string? result { get; set; }
        public string? id { get; set; }
        
        public Match CreateMatch(Team team1, Team team2, DateOnly date)
        {
            this.team1 = team1;
            this.team2 = team2; 
            this.date = date;
            this.location = places[random.Next(0, places.Length)];
            this.result = random.Next(2) == 0 ? team1.name : team2.name;
            this.id = newGuid.ToString();

            return this;
        }
    }
}
