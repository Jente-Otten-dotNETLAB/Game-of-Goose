using System.Security.Cryptography;

namespace Game_of_Goose
{
    public class GameHelper
    {
        public int GetPlayerAmount()
        {
            Console.WriteLine("how many players are playing?");
            int numberOfPlayers = 0;
            bool succes = false;
            while (succes is false)
            {
                Console.WriteLine("please enter a number between 2 and 4");
                bool TryParse = int.TryParse(Console.ReadLine(), out numberOfPlayers);
                if ((numberOfPlayers >= 2) && (numberOfPlayers <= 4))
                { succes = true; }
            }
            return numberOfPlayers;
        }
        public List<Player> CreatePlayers(int numberOfPlayers)
        {
            List<Player> list = new();
            for (int i = 1; i < numberOfPlayers + 1; i++)
            {
                Console.WriteLine("how is player " + i + " called?");
                string name = Console.ReadLine();
                if (name.Length >= 20)
                {
                    name = name.Substring(0, 20);
                }
                Console.WriteLine();
                list.Add(new Player(i, name));
            }
            return list;
        }
        
        public Game CreateGame()
        {
            var getal = GetPlayerAmount();
            var players = CreatePlayers(getal);
            var game = new Game(players);
            return game;
        }
        public void StartGame()
        {
            var game = CreateGame();
            game.PlayGame();
        }




    }
}