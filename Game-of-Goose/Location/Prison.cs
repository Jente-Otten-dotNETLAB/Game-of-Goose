using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    
    public class Prison : ILocation
    {
        public Prison(int id)
        {
            Id = id;
            Type = LocationType.Prison;
        }

        public int Id { get; set; }

        public LocationType Type { get; private set; }


        public void OnPlayerLanded(Player player)
        {
            player.Message += ":Prison";
            player.SkipTurns = 3;
        }
    }
}
