namespace Game_of_Goose
{
    public class Game
    {
        public Game(List<Player> players)
        {
            Players = players;
            FinalLocation = 63;
            GameEnded = false;
            Winner = null;
        }

        public List<Player> Players { get; set; }
        public int FinalLocation { get; set; }
        public bool GameEnded { get; set; }
        public Player? Winner { get; set; }

        public void PlayGame()
        {
            int turnId = 1;
            while (GameEnded is false)
            {
                Console.Write("\n[Press ENTER to start the next turn]");
                Console.WriteLine();
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                Turn turn = new Turn(turnId, Players);
                turn.PlayTurn();
                turnId += 1;
                GameEnded = CheckForWinner();
            }
            Console.Write("\n[Press ENTER to FINISH GAME]");
            Console.WriteLine();
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            AnnounceWinner();
        }

        private void AnnounceWinner()
        {
            string spaces = new string(' ', 50);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"\n\n\n{spaces}The Winner is {Winner.Name}\n\n\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool CheckForWinner()
        {
            foreach (var player in Players)
            {
                if (player.Location.Id == 63)
                {
                    player.IsWinner = true;

                    GameEnded = true;
                    if (Winner == null)
                    {
                        Winner = player;
                    }

                    return true;
                }
            }
            return false;
        }
    }
}