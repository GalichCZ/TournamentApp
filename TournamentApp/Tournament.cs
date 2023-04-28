using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    public class Tournament
    {
        public string? name { get; set; }
        public List<Match> matches { get; set; }
        public List<Team>? teams { get; set; }
        public Team? winner { get; set; }

        public void AddMatches(List<Match> matches)
        {
            this.matches = matches;
            Console.WriteLine(this.matches.Count + " matches added");
        }
        public void AddTeams(List<Team> teams)
        {
            this.teams = teams;
        }
        public void DisplayMatches()
        {
            if (matches == null)
            {
                Console.WriteLine("There is no played matches");
            }
            else
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine("\n" + match.team1.name + " : "
                        + match.team2.name + "\nWinner: " + match.result);
                }
            }
        }
        public void DisplayTeams()
        {
            if (teams == null)
            {
                Console.WriteLine("Looks like you didn't generate matches... \n " +
                    "Create teams and generate matches to see tournament stats");
            }
            else
            {
                foreach (Team team in teams)
                {
                    Console.WriteLine(team.name);
                }
            }
        }
        public void CreateMatches()
        {
            matches = new List<Match>();
            for (int i = 0; i < teams?.Count - 1; i++)
            {
                for (int j = i + 1; j < teams?.Count; j++)
                {
                    if (teams[i].name != teams[j].name)
                    {
                        Match m = new Match();
                        Match match = m.CreateMatch(teams[i], teams[j],
                            new DateOnly(2023, 4, 1 + i, new GregorianCalendar()));

                        if (match != null)
                        {
                            Console.WriteLine(match.team1?.name + " " + match.team2?.name + " " + match.result);
                            matches.Add(match);
                        }

                        teams[i].UpdateResults(match.result);
                        teams[j].UpdateResults(match.result);
                    }
                }
            }
        }

        public List<Team> QueryTeams(int? wins, int? points, int? loses)
        {
            List<Team> response = new List<Team>();
            if (wins != null)
            {
                IEnumerable<Team> query = from team in teams
                                          where team.wins >= wins
                                          select team;

                response = query.ToList();
            }
            if (points != null)
            {
                IEnumerable<Team> query = from team in teams
                                          where team.points >= points
                                          select team;

                response = query.ToList();
            }
            if(loses != null)
            {
                IEnumerable<Team> query = from team in teams
                                          where team.loses >= loses
                                          select team;

                response = query.ToList();
            }
            return response;
        }

        public List<Team> QueryTeams(string name)
        {
            IEnumerable<Team> query = from team in teams
                                      where team.name == name
                                      select team;

            return query.ToList();
        }

    }

}
