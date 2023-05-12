namespace Game_of_Goose.Location
{
    public class Goose : ILocation
    {
        public Goose(int id, string message)
        {
            Id = id;
            Name = "Goose";
            this.message = "You've reached a goose, you can move one location over!";
            Type = LocationType.Goose;
            
        }

        public int Id { get; set; }
        public string message { get; }
        public string Name { get;set; }
        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player)
        {
            throw new NotImplementedException();
        }
    }
}