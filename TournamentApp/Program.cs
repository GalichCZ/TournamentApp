
using System.Globalization;

namespace TournamentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice = ' ';

            List<Player> newPlayers = new List<Player>();
            List<Team> newTeams = new List<Team>();
            List<Coach> newCoaches = new List<Coach>();


            bool RUNNING = true;
            do
            {
                UIController.StartMenu();
                choice = Console.ReadKey().KeyChar;
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
                        Controller.GenerateMatches(newTeams);
                        UIController.ReqEnter();
                        break;
                    case 'd':
                        Controller.DisplayMatches();
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