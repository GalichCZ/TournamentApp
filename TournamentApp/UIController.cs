using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    public class UIController
    {
        static public void StartMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Console.Title = "! ! ! TOURNAMENT APP ! ! !");
            Console.WriteLine("___________________________" +
                "\n" + "___________________________" +
                "\n" + "___________________________" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- Create Player        [p]");
            Console.WriteLine("- Create Team          [t]");
            Console.WriteLine("- Create Coach         [c]");
            Console.WriteLine("- Add Plyer to Team    [a]");
            Console.WriteLine("- Add Coach to Team    [h]");
            Console.WriteLine("- Generate Matches     [g]");
            Console.WriteLine("- Display Matches      [d]");
            Console.WriteLine("- Display Team Stats   [s]");
            Console.WriteLine("--------------------------");
            Console.WriteLine("- Download tournament stats [m]");
            Console.WriteLine("- Read tournament stats     [r]");
            Console.WriteLine("\n- Exit                 [e]");
        }

        static public void ReqEnter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress ENTER to continue");
            Console.ReadKey();
        }

        static public void ShowAll(List<Player> players)
        {
            foreach (Player player in players)
            {
                if (player == null) return;
                Console.WriteLine("\n" + player.name + " "
                    + player.surname + " "
                    + player.position + " " + player.salary + " $");
            }
        }

        static public void ShowAll(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if(team == null) return;
                Console.WriteLine("\n" + team.name + " ");
            }
        }

        static public void ShowAll(List<Coach> coaches)
        {
            foreach (Coach coach in coaches)
            {
                if(coach == null) return;
                Console.WriteLine("\n" + coach.name + " "
                    + coach.surname + " " + coach.salary + " $");
            }
        }

        static public void CommandTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(title);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
