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
    }
}
