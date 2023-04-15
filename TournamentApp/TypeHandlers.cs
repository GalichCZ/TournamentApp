using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    public class TypeHandlers
    {
        public static string CheckEmptyString(string inputName)
        {
            string input = "";
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write($"\nWrite {inputName}: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"{inputName} cannot be empty. Please try again.");
                }
            }
            return input;
        }

        public static int CheckForNotDigit(string inputName)
        {
            int number = 0;

            while (number == 0)
            {
                Console.Write($"Write {inputName}: ");
                string input = Console.ReadLine();
                bool isNotDigit = false;
                foreach (char c in input)
                {
                    if (!Char.IsDigit(c))
                    {
                        isNotDigit = true;
                        break;
                    }
                }
                if (isNotDigit) Console.WriteLine($"{inputName} must contain only numbers: 10, 100, 400, etc.");
                else number = int.Parse(input);
            }

            return number;
        }
    }
}
