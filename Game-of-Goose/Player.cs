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
        public int LastDiceRoll { get; set; }
        public bool IsDirectionForward { get; set; }
        public bool IsWinner { get; set; }
        public string Message { get; set; }

        public void MovePlayer(Dice dice)
        {
            int locationId;
            if (DoesPlayerSkipTurn() is true)
            {
                Message = $"skip turn: s{Location.Id}";
                return;
            }
            if (InWell is true)
            {
                Message = $"stuck in well: s{Location.Id}";
                return;
            }
            Message = $"{dice.DiceOne}+{dice.DiceTwo}:";
            LastDiceRoll = dice.DiceTotal;
            locationId = GetLocationId(LastDiceRoll);
            locationId = IsPlayerPastEnd(locationId);
            Location = Gameboard.Instance().GetLocation(locationId);
            Message += $"s{Location.Id}";
            Location.OnPlayerLanded(this);

            IsDirectionForward = true;
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

        public int GetLocationId(int diceRoll)
        {
            int locationId;
            if (IsDirectionForward == true)
            {
                locationId = Location.Id + diceRoll;
            }
            else
            {
                locationId = Location.Id - diceRoll;
            }
            
            return locationId;
        }
    }
}