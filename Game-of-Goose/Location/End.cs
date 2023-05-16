using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class End : ILocation
    {
        public End(int id)
        {
            Id = id;
            Type = LocationType.End;
        }

        public int Id { get; set; }

        public LocationType Type { get; private set; }


        public void OnPlayerLanded(Player player)
        {
            player.IsWinner = true;
            player.Message += ":Winner";

        }
    }
}
