using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace TournamentApp
{
    internal class Controller
    {
        static public Player CreatePlayer()
        {
            UIController.CommandTitle("Player Creation");

            Player player = new Player();

            string name = TypeHandlers.CheckEmptyString("Name");

            string surname = TypeHandlers.CheckEmptyString("Surname");
            
            int salary = TypeHandlers.CheckForNotDigit("Salary");

            char position = ' ';
            while (position != 'D' && position != 'F' && position!='G')
            {
                Console.Write("Write Position(F, D or G): ");
                position = Char.ToUpper(Console.ReadKey().KeyChar);
                if(position != 'D' && position != 'F' && position != 'G')
                {
                    Console.WriteLine("\nYou must choose between G - Goalie, " +
                        "F - Forward or D - Defenseman\n");
                }
            }
            

            return player.CreatePlayer(name, surname, salary, position);
        }

        static public Team CreateTeam()
        {
            UIController.CommandTitle("Team Creation");

            Team team = new Team();

            string name = TypeHandlers.CheckEmptyString("Team name");

            return team.CreateTeam(name);
        }

        static public Coach CreateCoach()
        {
            UIController.CommandTitle("Coach Creation");

            Coach coach = new Coach();

            string name = TypeHandlers.CheckEmptyString("Name");

            string surname = TypeHandlers.CheckEmptyString("Surname");

            int salary = TypeHandlers.CheckForNotDigit("Salary");

            return coach.CreateCoach(name, surname, salary);
        }

        static public void AddCoach(List<Coach> coaches, List<Team> teams)
        {
            UIController.CommandTitle("Adding Coach to Team");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTeams: ");
            int indexTeam = 0;
            foreach (Team t in teams)
            {
                indexTeam+=1;
                Console.WriteLine("\n" + indexTeam + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCoaches: ");
            int indexCoach = 0;
            foreach (Coach c in coaches)
            {
                indexCoach+=1;
                Console.WriteLine("\n" + indexCoach + ": " + c.name + " "
                    + c.surname + " " + c.salary);
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nChoose team to add Coach(number): ");
            int team = TypeHandlers.CheckForNotDigit("Number");

            Console.Write("\nChoose Coach to add(number): ");
            int coach = TypeHandlers.CheckForNotDigit("Number");

            teams[team - 1].AddCoach(coaches[coach - 1]);
            coaches.RemoveAt(coach - 1);
        }

        static public void AddPlayer(List<Player> players, List<Team> teams)
        {
            UIController.CommandTitle("Adding Player to Team");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTeams: ");
            int indexTeam = 0;
            foreach (Team t in teams)
            {
                indexTeam +=1;
                Console.WriteLine("\n" + indexTeam + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlayers: ");
            int indexPlayer = 0;
            foreach (Player p in players)
            {
                indexPlayer +=1;
                Console.WriteLine("\n" + indexPlayer + ": " + p.name + " "
                    + p.surname + " " + p.position + " " + p.salary);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nChoose team to add Player(number): ");
            int team = TypeHandlers.CheckForNotDigit("Number");

            Console.Write("\nChoose Player to add(number): ");
            int player = TypeHandlers.CheckForNotDigit("Number");

            teams[team - 1].AddPlayer(players[player - 1]);
            players.RemoveAt(player - 1);

        }

        static public void GenerateMatches(List<Team> teams, Tournament tournament)
        {
            UIController.CommandTitle("Generating Matches");

            bool noCoach = false;

            foreach(Team t in teams)
            {
                if (t.coach == null) 
                {
                    Console.WriteLine($"This {t.name} has no coach !");
                    noCoach = true;
                }
            }

            if (!noCoach)
            {
                tournament.AddTeams(teams);
                tournament.CreateMatches();

                Console.WriteLine("\nMatches Generated");
            }
            else Console.WriteLine("Add coaches to all Teams !");
        }

        static public void DisplayMatches(Tournament tournament)
        {
            UIController.CommandTitle("Displaying Matches");

            tournament.DisplayMatches();
        }

        static public void DisplayTeamStats(Tournament tournament)
        {
            UIController.CommandTitle("Displaying Teams Stats");

            Console.WriteLine("NAME  |  COACH  |  TM  |  W  |  L  |  P");
            Console.WriteLine("_______________________________________");

            foreach (Team team in tournament.teams)
            {
                team.DisplayInfo();
            }
        }

        static public void DownloadTournamentStats(Tournament tournament)
        {
            string desktopPath =
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) 
                + @"\stats.txt";
            string currentPath = Directory.GetCurrentDirectory();

            Console.WriteLine("Where you want to save file ?");
            Console.WriteLine("1: Desktop");
            Console.WriteLine("2: Current path");

            char choicePath = Console.ReadKey().KeyChar;

            Console.WriteLine("What file do you want to save ?");
            Console.WriteLine("1: CSV");
            Console.WriteLine("2: TXT");

            char choiceFormat = Console.ReadKey().KeyChar;

            if(choiceFormat == '1')
            {
            
            }
            else 
            {
                using (StreamWriter sw = 
                    File.CreateText(choicePath == '1' ? desktopPath 
                    : currentPath))
                {
                    foreach(Match m in tournament.matches)
                    {
                        sw.WriteLine(m.id + " : " + m.team1.name + " : "
                            + m.team2.name + " - " + m.result);
                    }

                }
            }
        }
    }
}
