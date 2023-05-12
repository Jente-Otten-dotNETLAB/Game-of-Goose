using Game_of_Goose.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Factories
{
    public class LocationFactory : ILocationFactory
    {
        public ILocation CreateLocation(LocationType type, int id)
        {
            //TODO Vakjes aanvullen
            switch (type)
            {
                case LocationType.Default:
                    return new RegularLocation(id);
                case LocationType.Goose:
                    return new Goose(id, "");
                case LocationType.Inn:
                    return new Inn(id, "");
                //case LocationType.Prison:
                //    throw new NotImplementedException();
                //case LocationType.Well:
                //    throw new NotImplementedException();
                //case LocationType.Maze:
                //    throw new NotImplementedException();
                //case LocationType.Death:
                //    throw new NotImplementedException();
                //case LocationType.Bridge:
                //    throw new NotImplementedException();
                //case LocationType.End:
                //    throw new NotImplementedException();
                default:
                    return new RegularLocation(id);
            }
        }
    }
}
