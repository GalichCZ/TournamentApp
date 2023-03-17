using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp
{
    internal class Match
    {
        public Team? team1 { get; set; }
        public Team? team2 { get; set; }
        public DateOnly dateOnly { get; set; }
        public string? location { get; set; }
        public string? result { get; set; }
        public int id { get; set; }
        

    }
}
