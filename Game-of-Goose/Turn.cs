using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Turn
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int[] Diceroll { get; set; }

        public int StartLocation { get; set; }
        public ILocation EndLocation { get; set; }

        public string[] print()
        {
            string[] print = new string[3];
            print[0] = $"{Diceroll[1]}+{Diceroll[2]}: {StartLocation} ->";
            print[1] = $"{EndLocation.Type}.";

            return print;
        }

        public override string ToString()
        {
            // hoe moet een beurt er uit zien?
            //            naam 1                   naam 2                naam 3                naam 4
            //Turn TurnId
            //    roll1 + roll2 Location1 -> Location2                  3 + 5: 8               4+2: 6->12
            //                                                                                 The bridge
            //[PRESS ENTER TO PLAY TURN {turnId + 1}]

            // het verschil nog maken tussen een beurt en een ronde

            // een ronde is een beurt voor elke speler
            // een beurt is een beurt voor 1 speler
            // een ronde is dus een lijst van beurten
            // een beurt is een lijst van worpen
            // een worp is een lijst van dobbelstenen
            // een dobbelsteen is een getal

            return base.ToString();
        }
    }
}