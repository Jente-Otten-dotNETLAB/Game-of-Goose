using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose
{
    public class Dice
    {
        Random r = new Random();
        public Dice()
        {
            DiceOne = r.Next(1,6);
            DiceTwo = r.Next(1,6);
            DiceTotal = DiceOne+DiceTwo;
        }
        

        public int DiceOne { get; set; }
        public int DiceTwo { get; set; }
        public int DiceTotal { get; set; }
        
        
    }
}
