using Game_of_Goose.Location;

namespace Game_of_Goose.Factories
{
    public interface ILocationFactory
    {
        ILocation CreateLocation(LocationType type, int id);
    }
}