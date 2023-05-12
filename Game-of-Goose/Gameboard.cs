using Game_of_Goose.Factories;
using Game_of_Goose.Location;

namespace Game_of_Goose
{
    public class Gameboard
    {

        // Singleton
        private static Gameboard _instance;
        private ILocationFactory _factory = new LocationFactory();

        private int bridge = 6;

        private int end = 63;

        private int[] goose = new int[] { 5, 9, 14, 18, 23, 27, 23, 36, 41, 45, 50, 54, 59 };

        private int well = 31;

        private Gameboard()
        {
            for (int i = 1; i < 64; i++)
            {
                //TODO : Change to Switch case
                if (i == bridge)
                {
                    Locations.Add(_factory.CreateLocation(LocationType.Bridge, i));
                }
                else if (i == well)
                {
                    Locations.Add(_factory.CreateLocation(LocationType.Well, i));
                }
                else if (i == end)
                {
                    Locations.Add(_factory.CreateLocation(LocationType.End, i));
                }
                else if (goose.Contains(i))
                {
                    Locations.Add(_factory.CreateLocation(LocationType.Goose, i));
                }
                else
                {
                    Locations.Add(_factory.CreateLocation(LocationType.Default, i));
                }
            }
        }

        public List<ILocation> Locations { get; set; } = new List<ILocation>();

        public static Gameboard Instance()
        {
            if (_instance == null)
            {
                _instance = new Gameboard();
            }
            return _instance;
        }

        internal ILocation GetLocation(int locationId)
        {
            return Locations.First(x=>x.Id==locationId);
        }
        //TODO andere vakjes toevoegen
    }
}