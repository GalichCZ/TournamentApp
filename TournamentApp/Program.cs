
using System.Globalization;

/*
 Dobry den ! Vitam vas ve sve applikace v ramci predmetu Programovani 
 a Objektove Modelovani. 
 Tento program predstavuje "simulace" sportovniho turnaje.
 
 Pravidla: 
    Vytvorte alespon 2 tymy, ke kazdemu tymu trenera.
    Udelejte generace turnaje, pote se da vyuzivat vetsinu funkci programu
 Hlavni Moznosti:
    Vytvareni/precteni XML, TXT, CSV souboru
    Dotazovani s pomoci LINQ
    
 Snazil jsem se pojmenovat vsecny promenne a metody tak, 
 aby clovek chapal co to dela bez komentaru.
*/

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
                    case 'l':
                        Controller.DisplayTeams(tournament);
                        UIController.ReqEnter();
                        break;
                    case 'q':
                        Controller.QueryTeams(tournament);
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