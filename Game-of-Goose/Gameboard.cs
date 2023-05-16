using Game_of_Goose.Factories;
using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Gameboard
    {
        // Singleton
        private static Gameboard _instance;

        public static Gameboard Instance()
        {
            if (_instance == null)
            {
                _instance = new Gameboard();
            }
            return _instance;
        }

        private ILocationFactory _factory = new LocationFactory();

        private const int bridge = 6;
        private const int end = 63;
        private const int well = 31;
        private const int inn = 19;
        private const int prison = 52;
        private const int death = 58;
        private const int maze = 42;
        private int[] goose = new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

        private Gameboard()
        {
            for (int i = 0; i < 64; i++)
            {
                if (goose.Contains(i))
                {
                    Locations.Add(_factory.CreateLocation(LocationType.Goose, i));
                }
                else
                {
                    switch (i)
                    {
                        case bridge:
                            Locations.Add(_factory.CreateLocation(LocationType.Bridge, i));
                            break;

                        case end:
                            Locations.Add(_factory.CreateLocation(LocationType.End, i));
                            break;

                        case well:
                            Locations.Add(_factory.CreateLocation(LocationType.Well, i));
                            break;

                        case (inn):
                            Locations.Add(_factory.CreateLocation(LocationType.Inn, i));
                            break;

                        case (prison):
                            Locations.Add(_factory.CreateLocation(LocationType.Prison, i));
                            break;

                        case (death):
                            Locations.Add(_factory.CreateLocation(LocationType.Death, i));
                            break;

                        case (maze):
                            Locations.Add(_factory.CreateLocation(LocationType.Maze, i));
                            break;

                        default:
                            Locations.Add(_factory.CreateLocation(LocationType.Default, i));
                            break;
                    }
                }
            }
        }

        public List<ILocation> Locations { get; set; } = new List<ILocation>();

        public ILocation GetLocation(int locationId)
        {
            return Locations.First(x => x.Id == locationId);
        }
    }
}