namespace Game_of_Goose.Location
{
    public class Goose : ILocation
    {
        public Goose(int id)
        {
            Id = id;
            Type = LocationType.Goose;

        }

        public int Id { get; set; }
        public LocationType Type { get; private set; }


        public void OnPlayerLanded(Player player)
        {
            int locationId = player.GetLocationId(player.LastDiceRoll);
            locationId = player.IsPlayerPastEnd(locationId);
            
            player.Location = Gameboard.Instance().GetLocation(locationId);
           
            player.Message += $"->{player.Location.Id}";
            player.Location.OnPlayerLanded(player);
        }
    }
}