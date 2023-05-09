using System;
using System.Collections.Generic;
using System.Linq;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class PlantManager
    {
        public static readonly List<Plant> Plants = new List<Plant>();

        private static Random random = new Random();

        private static Location[] ViablePlantLocations = new[]
        {
            Location.DarkForest, Location.RiverSide, Location.HogwartsUniversity, Location.HogsMead
        };

        // plant list manipulation
        
        public static void AddPlant(Plant plant)
        {
            if (Plants.Contains(plant)) return;
            Plants.Add(plant);
        }

        public static void RemovePlant(Plant plant)
        {
            if (!Plants.Contains(plant)) return;
            Plants.Remove(plant);
        }

        public static void RemovePlantAt(int index)
        {
            if (index < 0 || index > Plants.Count) return;
            Plants.RemoveAt(index);
        }

        public static void PopulateWorld()
        {
            int populateLevel = random.Next(10, 30);
            Plants.Clear();
            
            for (int i = 0; i < populateLevel; i++)
            {
                AddPlant(GenerateRandomPlant(1, 100));
            }
        }

        public static List<Plant> SearchForPlantsAtLocation(Location location)
        {
            List<Plant> res = new List<Plant>();
            
            foreach (var plant in Plants)
            {
                if (plant.PlantLocation == location)
                {
                    res.Add(plant);
                }
            }

            return res;
        }
        
        private static PlantName GetRandomPlantName()
        {
            return (PlantName)Enum.Parse(typeof(PlantName), 
                Enum.GetName(typeof(PlantName), random.Next(0, 10)) ?? string.Empty);
        }

        private static Location GetRandomPlantLocations()
        {
            int index = random.Next(0, ViablePlantLocations.Length);
            return ViablePlantLocations[index];
        }

        public static Plant GenerateRandomPlant(int minCount, int maxCount)
        {
            return new Plant(GetRandomPlantName(), random.Next(minCount, maxCount), GetRandomPlantLocations());
        }
    }
}