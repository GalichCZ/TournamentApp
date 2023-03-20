using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Controller
    {
        static public Player CreatePlayer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player Creation");

            Console.ForegroundColor = ConsoleColor.White;
            Player player = new Player();

            Console.Write("\nWrite Name: ");
            string name = Console.ReadLine();

            Console.Write("Write Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Write Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Console.Write("Write Position(F, D or G): ");
            char position = Console.ReadKey().KeyChar;

            return player.CreatePlayer(name, surname, salary, position);
        }

        static public Team CreateTeam()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Team Creation");

            Console.ForegroundColor = ConsoleColor.White;
            Team team = new Team();

            Console.Write("\nWrite Name: ");
            string name = Console.ReadLine();

            return team.CreateTeam(name);
        }

        static public Coach CreateCoach()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Coach Creation");
            
            Console.ForegroundColor = ConsoleColor.White;
            Coach coach = new Coach();

            Console.Write("\nWrite Name: ");
            string name = Console.ReadLine();

            Console.Write("\nWrite Surname: ");
            string surname = Console.ReadLine();

            Console.Write("\nWrite Salary: ");
            int salary = int.Parse(Console.ReadLine());

            return coach.CreateCoach(name, surname, salary);
        }

        static public void AddCoach(List<Coach> coaches, List<Team> teams)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Adding Coach to Team");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTeams: ");
            foreach (Team t in teams)
            {
                int i = 1;
                Console.WriteLine("\n" + i + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCoaches: ");
            foreach (Coach c in coaches)
            {
                int i = 1;
                Console.WriteLine("\n" + i + ": " + c.name + " "
                    + c.surname + " " + c.salary);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nChoose team to add Coach(number): ");
            short team = Int16.Parse(Console.ReadLine());

            Console.Write("\nChoose Coach to add(number): ");
            short coach = Int16.Parse(Console.ReadLine());

            teams[team - 1].AddCoach(coaches[coach - 1]);
            coaches.RemoveAt(coach - 1);
        }

        static public void AddPlayer(List<Player> players, List<Team> teams)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Adding Player to Team");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTeams: ");
            foreach (Team t in teams)
            {
                int i = 1;
                Console.WriteLine("\n" + i + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlayers: ");
            foreach (Player p in players)
            {
                int i = 1;
                Console.WriteLine("\n" + i + ": " + p.name + " "
                    + p.surname + " " + p.position + " " + p.salary);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nChoose team to add Player(number): ");
            short team = Int16.Parse(Console.ReadLine());

            Console.Write("\nChoose Player to add(number): ");
            short player = Int16.Parse(Console.ReadLine());

            teams[team - 1].AddPlayer(players[player - 1]);
            players.RemoveAt(player - 1);

        }

        static public void GenerateMatches(List<Team> teams)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Generating Matches");

            Tournament t = new Tournament();
            Console.ForegroundColor = ConsoleColor.White;

            t.AddTeams(teams);
            t.CreateMatches();

            Console.WriteLine("\nMatches Generated");
        }

        static public void DisplayMatches()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Displaying Matches");

            Tournament t = new Tournament();
            Console.ForegroundColor = ConsoleColor.White;

            t.DisplayMatches();
        }
    }
}
