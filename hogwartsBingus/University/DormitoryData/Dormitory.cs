using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes
{
    public class Dormitory
    {
        public FactionType Type { get; protected set; }

        /*
         * as per request, every Dormitory has a custom number of floors,
         * where every floor has 5 rooms and every room has 3 beds
         */ 
        
        public int FloorCount { get; private set; }
        public int ResidentsCount { get; private set; }
        public int Capacity => FloorCount * 15;
        public int LastEmptyBed
        {
            get
            {
                if (ResidentsCount == Capacity) return -1;

                int floor = (ResidentsCount - 1) / 15 + 1,
                    room = ((ResidentsCount - 1) % 15) / 3 + 1,
                    bed = ((ResidentsCount - 1) % 15) % 3 + 1;

                return floor * 100 + room * 10 + bed;
            }
        }

        public Dormitory(int floorCount)
        {
            this.FloorCount = floorCount;
            ResidentsCount = 0;
            
        }

        public int AssignNewBew()
        {
            ResidentsCount++;
            return LastEmptyBed;
        }
    }
}