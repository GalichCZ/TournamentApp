using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    public class Coach
    {
        Guid newGuid = Guid.NewGuid();

        public string? name { get; set; }
        public string? surname { get; set; }
        public int salary { get; set; }
        public string? id { get; set; }

        public Coach CreateCoach(string name, string surname, int salary) 
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.id = newGuid.ToString(); 

            return this;
        }
    }
}
