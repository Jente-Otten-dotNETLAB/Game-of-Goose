using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Player
    {
        public Player(int id, string name, int startLocation=0)
        {
            Id = id;
            Name = name;
            Location = Gameboard.Instance().GetLocation(startLocation);
            InWell = false;
            SkipTurns = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ILocation Location { get; set; }
        public bool InWell { get; set; }
        public int SkipTurns { get; set; }

        public void MovePlayer(int diceroll)
        {

            int locationId = Location.Id + diceroll;
            ILocation newLocation = Gameboard.Instance().GetLocation(locationId);
            newLocation.OnPlayerLanded(this);
            Location = newLocation;

                }

        public void SetPlayerPosition(int position)
        { }
    }
}