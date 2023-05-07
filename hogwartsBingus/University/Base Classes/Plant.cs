using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes
{
    public class Plant
    {
        public PlantName Name { get; private set; }
        public int Count { get; private set; }

        public Location PlantLocation { get; private set; }

        public Plant(PlantName name, int count, Location plantLocations)
        {
            Name = name;
            Count = count;
            PlantLocation = plantLocations;
        }
    }
}