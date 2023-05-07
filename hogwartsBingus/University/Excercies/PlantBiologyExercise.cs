using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;

namespace hogwartsBingus.University.Excercies
{
    public class PlantBiologyExercise : IExercise
    {
        private Random random = new Random();
        
        private Student Performer;
        private List<Plant> Targets = new List<Plant>();
        private int TargetCount;
        public PlantBiologyExercise(Student performer)
        {
            Performer = performer;
        }

        public void PrepareExercise()
        {
            TargetCount = random.Next(1, 10);
            GenerateTargetList();
        }

        public void PerformExercise()
        {
            
        }

        public void AwardPoints(Faction faction, int amount)
        {
            FactionManager.AwardPointsToFaction(Performer.Faction, EvaluatePoints());
        }

        private int EvaluatePoints()
        {
            // implement later
            return 1;
        }

        private void GenerateTargetList()
        {
            for (int i = 0; i < TargetCount; i++)
            {
                Targets.Add(PlantManager.GenerateRandomPlant(1,10));
            }
        }
        public void SearchLocation(Location location)
        {
            List<Plant> foundPlants = PlantManager.SearchForPlantsAtLocation(location);
        }
    }
}