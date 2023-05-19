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
            int locationId = player.CheckNewLocationBasedOnRoll(player.LastDice);
            player.Location = Gameboard.Instance().GetLocation(locationId);
           
            player.Message += $"->s{player.Location.Id}";
            player.Location.OnPlayerLanded(player);
        }
    }
}