using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Team
    {
        Guid newGuid = Guid.NewGuid();

        public string? name { get; set; }
        public Coach? coach { get; set; }
        public List<Player>? players { get; set; }
        public int totalMatches { get; set; }
        public int salaryRoof { get; set; }
        public int wins { get; set; }
        public int loses { get; set; }
        public int points { get; set; }
        public string? id { get; set; }

        public Team CreateTeam(string name)
        {
            this.name = name;
            this.id = newGuid.ToString();
            this.salaryRoof = 1000000;
            return this;
        }

        public void AddPlayer (Player player)
        {
            if(players == null)
            {
                players = new List<Player> ();
            }
            players.Add (player);
        }

        public void AddCoach (Coach coach)
        {
            this.coach = coach;
        }

        public void DeletePlayer (Player player)
        {
            if (players.Contains(player))
            {
                players.Remove(player);
            }
            else Console.WriteLine("You have not this player");
        }

        public void DisplayInfo ()
        {
            Console.WriteLine("Name: " + name + "\n" + "Coach: " + coach.name + 
                "\n" + "Total matches: " + totalMatches + "\n" + "Wins: " + wins + 
                "\n" + "Loses: " + loses + "\n" + "Points: " + points + "\n");
        }

        public void UpdateResults (string result)
        {
            totalMatches++;
            if (result == name)
            {
                wins++;
                points += 2;
            }
            else 
            {
                loses++;
                points += 0;
            }
        }
    }
}
