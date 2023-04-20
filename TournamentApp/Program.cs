
using System.Globalization;

namespace TournamentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice = ' ';

            Tournament tournament = new Tournament();

            List<Player> newPlayers = new List<Player>();
            List<Team> newTeams = new List<Team>();
            List<Coach> newCoaches = new List<Coach>();


            bool RUNNING = true;
            do
            {
                UIController.StartMenu();
                choice = Char.ToLower(Console.ReadKey().KeyChar);
                switch (choice)
                {
                    case 'p':
                        newPlayers.Add(Controller.CreatePlayer());
                        UIController.ShowAll(newPlayers);
                        UIController.ReqEnter();
                        break;
                    case 't':
                        newTeams.Add(Controller.CreateTeam());
                        UIController.ShowAll(newTeams);
                        UIController.ReqEnter();
                        break;
                    case 'a':
                        Controller.AddPlayer(newPlayers, newTeams);
                        UIController.ReqEnter();
                        break;
                    case 'c':
                        newCoaches.Add(Controller.CreateCoach());
                        UIController.ShowAll(newCoaches);
                        UIController.ReqEnter();
                        break;
                    case 'h':
                        Controller.AddCoach(newCoaches, newTeams);
                        UIController.ReqEnter();
                        break;
                    case 'g':
                        Controller.GenerateMatches(newTeams, tournament);
                        UIController.ReqEnter();
                        break;
                    case 'd':
                        Controller.DisplayMatches(tournament);
                        UIController.ReqEnter();
                        break;
                    case 's':
                        Controller.DisplayTeamStats(tournament);
                        UIController.ReqEnter();
                        break;
                    case 'm':
                        Controller.DownloadTournamentMatches(tournament);
                        UIController.ReqEnter();
                        break;
                    case 'r':
                        Controller.ReadTournamentMatches(tournament);
                        UIController.ReqEnter();
                        break;
                    case 'e':
                        RUNNING = false;
                        break;
                }
            }
            while (RUNNING);

            Console.WriteLine("\nBye bye");
        }
    }
}