using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Player
    {
        public Player(int id, string name, int startLocation = 0)
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
        public int lastDiceroll { get; set; }
        public bool IsDirectionForward { get; set; }

        public void MovePlayer(int diceroll)
        {

            if (DoesPlayerSkipTurn() is false)
            {
                lastDiceroll = diceroll;
                int locationId = Location.Id + diceroll;
                ILocation newLocation = Gameboard.Instance().GetLocation(locationId);
                Location = newLocation;
                Location.OnPlayerLanded(this);
            }
        }

        public void SetPlayerPosition(int position)
        { }

        public bool DoesPlayerSkipTurn()
        {
            if (SkipTurns > 0)
            {
                SkipTurns = -1;
                return true;
            }
            return false;
        }
        public bool IsPlayerPastEnd(int locationId)
        {
            if (locationId > 63)
            {
//aantal achterwaarts te gaan = 63 - originele locatie.id 
            }

        }
    }
}