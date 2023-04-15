using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    public class Player
    {
        Guid newGuid = Guid.NewGuid();

        public string? name { get; set; }
        public string? surname { get; set; }
        public int salary { get; set; }
        public char position { get; set; }
        public string? id { get; set; }

        public Player CreatePlayer(string name, string surname, int salary, char position) 
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.position = position;
            this.id = newGuid.ToString();

            return this;
        }
    }
}
