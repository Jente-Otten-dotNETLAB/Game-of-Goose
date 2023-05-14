namespace Game_of_Goose.Location
{
    public interface ILocation
    {
        int Id { get; set; }
        LocationType Type { get; }

        void OnPlayerLanded(Player player);
    }
}