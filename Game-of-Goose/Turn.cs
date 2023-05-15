using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Turn
    {
        public Turn(Player player)
        {
            Player = player;
            Dice = new Dice();
            StartLocation = player.Location;
            EndLocation = null;
            Narration = new string[3]
                {
                $"{player.Name} is at {player.Location.Id}",
                $"{player.Name} rolled a {Dice.DiceOne} and a {Dice.DiceTwo}",
                ""
            };
        }

        public Player Player { get; set; }
        public Dice Dice { get; set; }
        public ILocation StartLocation { get; set; }
        public ILocation? EndLocation { get; set; }
        public string[] Narration { get; set; } = new string[3];

        public void LogTurn()
        {
            Console.WriteLine(Narration[1]);
            Console.WriteLine(Narration[2]);
            Console.WriteLine(Narration[3]);
        }

        public void PlayTurn()
        {
            Player.MovePlayer(Dice.DiceOne + Dice.DiceTwo);
            Narration[3] = $"{Player.Name} ends it's turn at {Player.Location.Id}, the {Player.Location.Type}";
        }

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
    }
}