namespace Game_of_Goose
{
    public class Game
    {
        public Game(List<Player> players)
        {
            Players = players;
            FinalLocation = 63;
            DiceMinimum = 1;
            DiceMaximum = 6;
            DiceThrows = 2;
            GameEnded = false;
        }

        public List<Player> Players { get; set; }
        public int FinalLocation { get; set; }
        public int DiceMinimum { get; set; }
        public int DiceMaximum { get; set; }
        public int DiceThrows { get; set; }
        public bool GameEnded { get; set; }

        public void PlayGame()
        {
            while (GameEnded is false)
            {
                foreach (Player player in Players)
                {
                    if (player.IsWinner is false)
                    {
                        int diceroll = RollDice();
                        player.MovePlayer(diceroll);
                        if (player.Location.Id == FinalLocation)
                        {
                            GameEnded = true;
                            player.IsWinner = true;
                            break;
                        }
                    }
                }
            }
        }

        private int RollDice()
        {
            throw new NotImplementedException();
        }
    }
}