using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;

namespace hogwartsBingus.University.Excercies
{
    public class PlantBiologyExercise : Exercise
    {
        public PlantBiologyExercise()
        {
        }

        public PlantBiologyExercise(string name, string description, DateTime deadLine) : base(name, description, deadLine)
        {
        }

        public PlantBiologyExercise(string name, string description, DateTime deadLine, List<int> attendees) 
            : base(attendees ,name, description, deadLine)
        {
        }

        public override void PrepareExercise()
        {
            
        }
        public override void StudentFinishedExercise(int attendee)
        {
            base.StudentFinishedExercise(attendee);
        }
        public override void AwardPoints(FactionType faction, int amount)
        {
            FactionManager.AwardPointsToFaction(faction, amount);
        }

        protected override int EvaluatePoints()
        {
            // implement later
            return 1;
        }
        
        public void SearchLocation(Location location)
        {
            List<Plant> foundPlants = PlantManager.SearchForPlantsAtLocation(location);
        }
    }
}