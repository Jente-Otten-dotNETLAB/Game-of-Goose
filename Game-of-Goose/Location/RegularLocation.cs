namespace Game_of_Goose.Location
{
    public class RegularLocation : ILocation
    {
        public RegularLocation(int id)
        {
            Id = id;
            Name = "";
            Type = LocationType.Default;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player)
        {
            Console.WriteLine($"player landed on {Id}");
        }
    }
}