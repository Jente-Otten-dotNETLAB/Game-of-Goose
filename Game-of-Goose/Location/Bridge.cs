using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class Bridge : ILocation
    {
        public Bridge(int id)
        {
            Id = id;
            Type = LocationType.Well;
        }

        public int Id { get; set; }
        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player, int diceroll)
        {
            throw new NotImplementedException();
        }
    }
}
