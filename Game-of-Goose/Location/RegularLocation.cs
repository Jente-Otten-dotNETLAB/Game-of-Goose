namespace Game_of_Goose.Location
{
    public class RegularLocation : ILocation
    {
        public RegularLocation(int id)
        {
            Id = id;
            Type = LocationType.Default;
        }

        public int Id { get; set; }
        public LocationType Type { get; private set; }


        public void OnPlayerLanded(Player player)
        {
        }
    }
}