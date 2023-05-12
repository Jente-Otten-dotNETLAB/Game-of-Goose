using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class Inn : ILocation
    {
        public Inn(int id, string name)
        {
            Id = id;
            Name = "The Inn";
            Type = LocationType.Inn;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player)
        {
            player.SkipTurns = 1;
        }
    }
}
