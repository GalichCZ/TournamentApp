﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class UIController
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
                Console.WriteLine("\n" + player.name + " "
                    + player.surname + " "
                    + player.position + " " + player.salary + " $");
            }
        }

        static public void ShowAll(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                Console.WriteLine("\n" + team.name + " ");
            }
        }

        static public void ShowAll(List<Coach> coaches)
        {
            foreach (Coach coach in coaches)
            {
                Console.WriteLine("\n" + coach.name + " "
                    + coach.surname + " " + coach.salary + " $");
            }
        }
    }
}