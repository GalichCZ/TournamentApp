using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Tournament
    {
        public string? name { get; set; }
        public List<Match>? matches { get; set; }
        public List<Team>? teams { get; set; }
        public Team? winner { get; set; }
        
        public void AddMatch (Match match)
        {
            if(matches == null)
            {
                matches = new List<Match>();
            }
            matches.Add (match);
        }
        public void AddTeams (List<Team> teams)
        {
            this.teams = teams;
        }

        public void DisplayMatches()
        {
            foreach(Match match in matches)
            {
                Console.WriteLine(match);
            }
        }

        public void DisplayTeams()
        {
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }
        }


    }

}
