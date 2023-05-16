namespace Game_of_Goose
{
    public class Game
    {
        public Game(List<Player> players)
        {
            Players = players;
            FinalLocation = 63;
            GameEnded = false;
        }

        public List<Player> Players { get; set; }
        public int FinalLocation { get; set; }
        public bool GameEnded { get; set; }

        public void PlayGame()
        {
            int turnId = 1;
            while (GameEnded is false)
            {
                Console.Write("\n[Press ENTER to continue the next round]");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                }
                Turn turn = new Turn(turnId, Players);
                turn.PlayTurn();
                turnId += 1;
                GameEnded = CheckForWinner();
            }
        }

        public bool CheckForWinner()
        {
            foreach (var player in Players)
            {
                if (player.Location.Id == 63)
                {
                    player.IsWinner = true;
                    GameEnded = true;
                    return true;
                }
            }
            return false;
        }
    }
}