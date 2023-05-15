using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class Death : ILocation
    {
        public Death(int id)
        {
            Id = id;
            Type = LocationType.Death;
        }

        public int Id { get; set; }

        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player)
        {
            player.Location = Gameboard.Instance().GetLocation(0);
        }
    }
}
