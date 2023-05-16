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
               
                else
                {
                    player.MovePlayer(dice);
                }
            }
         
            LogTurn();
        }

        public void LogTurn()
        {
            string line = new string('-', 100);
            string spaces = new string(' ', 50);
            string ExtraSpacerInCaseOfNewLine = new string(' ', 25);
            string names = "";
            string turnId = spaces + "Turn " + Id + ": ";
            string Movement = "";
            foreach (var player in Players)
            {

                names += player.Name + new string(' ', 25 - player.Name.Length);
                if (player.Message.Length >= 25)
                {
                    
                    Movement += player.Message + "\n" + ExtraSpacerInCaseOfNewLine;
                }
                else
                {
                Movement += player.Message + new string(' ', 25 - player.Message.Length);
                }
                ExtraSpacerInCaseOfNewLine += new string(' ', 25);
                player.Message = "";
                
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