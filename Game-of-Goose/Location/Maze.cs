using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Goose.Location
{
    public class Maze : ILocation
    {
        public Maze(int id)
        {
            Id = id;
            Type = LocationType.Maze;
        }

        public int Id { get; set; }

        public LocationType Type { get; private set; }

        public void OnPlayerLanded(Player player)
        {
            player.Location = Gameboard.Instance().GetLocation(39);
        }
    }
}

