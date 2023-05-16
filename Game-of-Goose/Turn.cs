using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Turn
    {
        public Turn(int id, List<Player> players)
        {
            Id = id;
            Players = players;
        }

        public int Id { get; set; }
        public List<Player> Players { get; set; }
        public Dice Dice { get; set; }



        public void PlayTurn()
        {
            foreach (var player in Players)
            {
            Dice dice = new Dice();
                if (player.Location.Id == 0 && dice.DiceTotal ==9)
                {
                    if (dice.DiceOne == 6 || dice.DiceOne ==3)
                    {
                        player.Location = Gameboard.Instance().GetLocation(53);
                        player.Message += "-> s53";
                    }
                    else
                    {
                        player.Location = Gameboard.Instance().GetLocation(26);
                        player.Message += "-> s26";
                    }
                    return;
                }
                player.MovePlayer(dice);
                if (player.Location.Id == 63)
                {
                    player.IsWinner = true;
                }
            }
         
            LogTurn();
        }

        public void LogTurn()
        {
            string line = new string('-', 100);
            string spaces = new string(' ', 50);

            string names = "";
            string turnId = spaces + "Turn " + Id + ": ";
            string Movement = "";
            foreach (var player in Players)
            {

                names += player.Name + new string(' ', 25 - player.Name.Length);
                Movement += player.Message + new string(' ', 25 - player.Message.Length);
               
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(turnId);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(line);
            Console.WriteLine(names);
            Console.WriteLine(Movement);
        }




    }
}