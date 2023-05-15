using Game_of_Goose.Location;

namespace Game_of_Goose.Factories
{
    public class LocationFactory : ILocationFactory
    {
        public ILocation CreateLocation(LocationType type, int id)
        {
            switch (type)
            {
                case LocationType.Default:
                    return new RegularLocation(id);
                case LocationType.Goose:
                    return new Goose(id);
                case LocationType.Inn:
                    return new Inn(id);
                case LocationType.Prison:
                    return new Prison(id);
                case LocationType.Well:
                    return new Well(id);
                case LocationType.Maze:
                    return new Maze(id);
                case LocationType.Death:
                   return new Death(id);
                case LocationType.Bridge:
                    return new Bridge(id);
                case LocationType.End:
                    return new End(id);
                default:
                    return new RegularLocation(id);
            }
        }
    }
}