using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose
{
    public class Round
    {
        public Round(List<Turn> turns, int roundNumber)
        {
            Turns = turns;
            RoundNumber = roundNumber;
        }

        public List<Turn> Turns { get; set; }
        public int RoundNumber { get; set; }
    }
}
