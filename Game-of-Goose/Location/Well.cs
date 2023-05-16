using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class Well : ILocation
    {
        public Well(int id)
        {
            Id = id;
            Type = LocationType.Well;
            PlayerInWell = null;
        }

        public int Id { get; set; }

        public LocationType Type { get; private set; }
        public Player? PlayerInWell { get; set; }


        public void OnPlayerLanded(Player player)
        {
            if (PlayerInWell != null)
            {
                PlayerInWell.InWell = false;
                PlayerInWell = null;
            }
            PlayerInWell = player;
            player.InWell = true;
            player.Message += ":well";
        }
    }
}


