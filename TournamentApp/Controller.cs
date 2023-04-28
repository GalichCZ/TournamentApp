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
    public class Controller
    {
        static public Player CreatePlayer()
        {
            UIController.CommandTitle("Player Creation");

            Player player = new Player();

            Console.WriteLine("\n" + @"Type 'exit' to get back");

            string name = TypeHandlers.CheckEmptyString("Name");

            if (name == "exit") return null;

            string surname = TypeHandlers.CheckEmptyString("Surname");

            if (surname == "exit") return null;

            int salary = TypeHandlers.CheckForNotDigit("Salary");

            if (salary == 0) return null;

            char position = ' ';
            while (position != 'D' && position != 'F' && position != 'G')
            {
                Console.Write("Write Position(F, D or G): ");
                position = Char.ToUpper(Console.ReadKey().KeyChar);
                if (position != 'D' && position != 'F' && position != 'G')
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

            Console.WriteLine("\n" + @"Type 'exit' to get back");

            string name = TypeHandlers.CheckEmptyString("Team name");

            if (name == "exit") return null;

            return team.CreateTeam(name);
        }

        static public Coach CreateCoach()
        {
            UIController.CommandTitle("Coach Creation");

            Coach coach = new Coach();

            Console.WriteLine("\n" + @"Type 'exit' to get back");

            string name = TypeHandlers.CheckEmptyString("Name");
            if (name == "exit") return null;

            string surname = TypeHandlers.CheckEmptyString("Surname");
            if (surname == "exit") return null;

            int salary = TypeHandlers.CheckForNotDigit("Salary");
            if (salary == 0) return null;

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
                indexTeam += 1;
                Console.WriteLine("\n" + indexTeam + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCoaches: ");
            int indexCoach = 0;
            foreach (Coach c in coaches)
            {
                indexCoach += 1;
                Console.WriteLine("\n" + indexCoach + ": " + c.name + " "
                    + c.surname + " " + c.salary);
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n" + @"Type 'exit' to get back");

            Console.Write("\nChoose team to add Coach(number): ");
            int team = TypeHandlers.CheckForNotDigit("Number");
            if (team == 0) return;

            Console.Write("\nChoose Coach to add(number): ");
            int coach = TypeHandlers.CheckForNotDigit("Number");
            if (coach == 0) return;

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
                indexTeam += 1;
                Console.WriteLine("\n" + indexTeam + ": " + t.name + " "
                    + t.salaryRoof + " $ " + t.coach?.name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPlayers: ");
            int indexPlayer = 0;
            foreach (Player p in players)
            {
                indexPlayer += 1;
                Console.WriteLine("\n" + indexPlayer + ": " + p.name + " "
                    + p.surname + " " + p.position + " " + p.salary);
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n" + @"Type 'exit' to get back");

            Console.Write("\nChoose team to add Player(number): ");
            int team = TypeHandlers.CheckForNotDigit("Number");
            if (team == 0) return;

            Console.Write("\nChoose Player to add(number): ");
            int player = TypeHandlers.CheckForNotDigit("Number");
            if (player == 0) return;

            teams[team - 1].AddPlayer(players[player - 1]);
            players.RemoveAt(player - 1);

        }

        static public void GenerateMatches(List<Team> teams, Tournament tournament)
        {
            UIController.CommandTitle("Generating Matches");
            if (teams.Count == 0) UIController.ErrorHandler("No matches !");
            else
            {
                bool noCoach = false;

                foreach (Team t in teams)
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
        }

        static public void DisplayMatches(Tournament tournament)
        {
            UIController.CommandTitle("Displaying Matches");

            tournament.DisplayMatches();
        }

        static public void DisplayTeams(Tournament tournament)
        {
            UIController.CommandTitle("Displaying Teams");

            tournament.DisplayTeams();
        }

        static public void DisplayTeamStats(Tournament tournament)
        {
            UIController.CommandTitle("Displaying Teams Stats");

            Console.WriteLine("NAME  |  COACH  |  TM  |  W  |  L  |  P");
            Console.WriteLine("_______________________________________");

            if (tournament.teams == null)
            {
                Console.WriteLine("You didn't generate any matches.");
            }
            else
            {
                foreach (Team team in tournament.teams)
                {
                    team.DisplayInfo();
                }
            }
        }

        static public void DownloadTournamentMatches(Tournament tournament)
        {
            UIController.CommandTitle("Downloading Tournament stats");

            string desktopPath =
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string currentPath = Directory.GetCurrentDirectory();

            Console.WriteLine("Where you want to save file ?");
            Console.WriteLine("1: Desktop");
            Console.WriteLine("2: Current path");

            char choicePath = ' ';
            while (choicePath != '1' && choicePath != '2')
            {
                choicePath = Console.ReadKey().KeyChar;
                if (choicePath != '1' && choicePath != '2')
                {
                    Console.WriteLine("You might choose between 1 or 2");
                }
            }

            string chosenPath = choicePath == '1' ? desktopPath : currentPath;

            Console.WriteLine("What file do you want to save ?");
            Console.WriteLine("1: CSV");
            Console.WriteLine("2: TXT");
            Console.WriteLine("3: XML");

            char choiceFormat = ' ';

            while (choiceFormat != '1' && choiceFormat != '2' && choiceFormat != '3')
            {
                choiceFormat = Console.ReadKey().KeyChar;
                if (choiceFormat != '1' && choiceFormat != '2' && choiceFormat != '3')
                {
                    Console.WriteLine("You might choose 1, 2 or 3");
                }
            }

            string fileName = TypeHandlers.CheckEmptyString("File name");

            if (choiceFormat == '1')
            {
                FileHandler.DownloadFileCsv(tournament.matches, chosenPath, fileName);
            }
            else if (choiceFormat == '2')
            {
                FileHandler.DownloadFileTxt(tournament.matches, chosenPath, fileName);
            }
            else
            {
                FileHandler.DownloadFileXml(tournament.matches, chosenPath, fileName);
            }
        }

        static public void ReadTournamentMatches(Tournament tournament)
        {
            UIController.CommandTitle("Reading Tournament stats");

            Console.WriteLine("What file do you want to read ?");
            Console.WriteLine("1: CSV");
            Console.WriteLine("2: XML");
            Console.WriteLine("3: TXT");

            char choiceFormat = ' ';

            while (choiceFormat != '1' && choiceFormat != '2' && choiceFormat != '3')
            {
                choiceFormat = Console.ReadKey().KeyChar;
                if (choiceFormat != '1' && choiceFormat != '2' && choiceFormat != '3')
                {
                    Console.WriteLine("You might choose 1, 2 or 3");
                }
            }

            string path = TypeHandlers.CheckEmptyString("Path to file");

            if (choiceFormat == '1')
            {
                List<Match> matches = FileHandler.ReadFileCsv(path);
                if (matches == null) return;
                tournament.AddMatches(matches);
            }
            else if (choiceFormat == '2')
            {
                FileHandler.ReadFileXml(path);
            }
            else
            {
                FileHandler.ReadFileTxt(path);
            }

        }

        static public void QueryTeams(Tournament tournament)
        {
            UIController.CommandTitle("Query team");

            if (tournament.teams == null)
            {
                Console.WriteLine("You didn't generate matches.");
                return;
            }

            Console.WriteLine("Do you wnat query team by: ");
            Console.WriteLine("1.Team name");
            Console.WriteLine("2.Wins");
            Console.WriteLine("3.Points");
            Console.WriteLine("4.Loses");

            int choice = TypeHandlers.CheckForNotDigit("Choice");
            List<Team> teams = new List<Team>();

            if (choice == 1)
            {
                string name = TypeHandlers.CheckEmptyString("team name");
                teams = tournament.QueryTeams(name);
            }

            if (choice == 2)
            {
                int wins = TypeHandlers.CheckForNotDigit("wins more or equal to ...");
                teams = tournament.QueryTeams(wins, null, null);
            }

            if (choice == 3)
            {
                int points = TypeHandlers.CheckForNotDigit("points more or equal to ...");
                teams = tournament.QueryTeams(null, points, null);
            }

            if (choice == 4)
            {
                int loses = TypeHandlers.CheckForNotDigit("loses more or equal to ...");
                teams = tournament.QueryTeams(null, null, loses);
            }

            if (teams.Count() == 0)
            {
                Console.WriteLine("There is no matches with this parameters");
            }
            else
            {
                foreach (Team team in teams)
                {
                    Console.WriteLine(team.name);
                }
            }
        }
    }
}
