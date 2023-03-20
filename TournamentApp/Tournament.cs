using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Tournament
    {
        Match m = new Match();

        public string? name { get; set; }
        public List<Match>? matches { get; set; }
        public List<Team>? teams { get; set; }
        public Team? winner { get; set; }
        
        public void AddMatches (List<Match> matches)
        {
            this.matches = matches;
            Console.WriteLine(this.matches.Count + " add");
        }
        public void AddTeams (List<Team> teams)
        {
            this.teams = teams;
        }
        public void DisplayMatches()
        {
            if (this.matches == null)
            {
                Console.WriteLine("There is no played matches");
            }
            else
            {
                foreach(Match match in this.matches)
                {
                    Console.WriteLine("\n"+match?.team1?.name + " : " 
                        + match?.team2?.name + " - Winner: " + match?.result);
                }
            }
        }
        public void DisplayTeams()
        {
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }
        }
        public void CreateMatches()
        {
            List<Match> matches = new List<Match>();
            for (int i = 0; i < teams?.Count-1; i++) 
            {
                for(int j = 1; j < teams?.Count; j++)
                {
                    if (teams[i].name != teams[j].name)
                    {
                        Match match = m.CreateMatch(teams[i], teams[j],
                            new DateOnly(2023, 4, 1 + i, new GregorianCalendar()));
                        
                        matches.Add(match);

                        teams[i].UpdateResults(match.result);
                        teams[j].UpdateResults(match.result); 
                    }
                }
            }
            this.AddMatches(matches);
        }

    }

}
