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
            IsDirectionForward = true;
            IsWinner = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ILocation Location { get; set; }
        public bool InWell { get; set; }
        public int SkipTurns { get; set; }
        public int lastDiceroll { get; set; }
        public bool IsDirectionForward { get; set; }
        public bool IsWinner { get; set; }

        public void MovePlayer(int diceroll)
        {
            if (DoesPlayerSkipTurn() is false && InWell is false)
            {
                lastDiceroll = diceroll;
                int locationId;
                if (IsDirectionForward == true)
                {
                    locationId = Location.Id + diceroll;
                }
                else
                {
                    locationId = Location.Id - diceroll;
                }
                locationId = IsPlayerPastEnd(locationId);
                //method is player past
                ILocation newLocation = Gameboard.Instance().GetLocation(locationId);
                Location = newLocation;
                Location.OnPlayerLanded(this);
            }
        }


        public bool DoesPlayerSkipTurn()
        {
            if (SkipTurns > 0)
            {
                SkipTurns = -1;
                return true;
            }
            return false;
        }

        public int IsPlayerPastEnd(int locationId)
        {
            if (locationId > 63)
            {
                int restOfMovement = locationId - 63;
                locationId = 63 - restOfMovement;

                IsDirectionForward = false;
            }
            return locationId;
        }   
    }
}