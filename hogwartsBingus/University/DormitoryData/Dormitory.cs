using hogwartsBingus.Base_Classes;
using Newtonsoft.Json;

namespace hogwartsBingus.University.DormitoryData
{
    public class Dormitory
    {
        public string Name { get; protected set; }
        public FactionType Faction { get; protected set; }

        /*
         * as per request, every Dormitory has a custom number of floors,
         * where every floor has 5 rooms and every room has 3 beds
         */ 
        
        public int FloorCount { get; private set; }
        public int ResidentsCount { get; private set; }
        
        [JsonIgnore]
        public int Capacity => FloorCount * 15;

        [JsonIgnore]
        public bool IsFull => ResidentsCount == Capacity;
        
        [JsonIgnore]
        public int LastEmptyBed
        {
            get
            {
                if (IsFull) return -1;

                int floor = (ResidentsCount - 1) / 15 + 1,
                    room = ((ResidentsCount - 1) % 15) / 3 + 1,
                    bed = ((ResidentsCount - 1) % 15) % 3 + 1;

                return floor * 100 + room * 10 + bed;
            }
        }
        
        public Dormitory(string name, int floorCount, FactionType faction)
        {
            Name = name;
            FloorCount = floorCount;
            Faction = faction;
            ResidentsCount = 0;
        }
        
        [JsonConstructor]
        public Dormitory(string name, int floorCount, FactionType faction, int residentsCount)
        {
            Name = name;
            FloorCount = floorCount;
            Faction = faction;
            ResidentsCount = residentsCount;
        }

        public int AssignNewBew()
        {
            ResidentsCount++;
            return LastEmptyBed;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}