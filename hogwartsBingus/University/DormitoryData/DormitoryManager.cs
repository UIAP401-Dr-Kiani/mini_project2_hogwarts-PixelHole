using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;

namespace hogwartsBingus.University.DormitoryData
{
    public static class DormitoryManager
    {
        public static readonly List<Dormitory> Dormitories = new List<Dormitory>();

        static DormitoryManager()
        {
            //this is for Test purposes, remove later ↓
            Dormitories.Add(new Dormitory(6, FactionType.Gryffindor));
            Dormitories.Add(new Dormitory(8, FactionType.Slytherin));
            Dormitories.Add(new Dormitory(6, FactionType.Raveclaw));
            Dormitories.Add(new Dormitory(6, FactionType.Hufflepuff));
        }

        public static int GetBedNumberOfType(FactionType faction)
        {
            foreach (var dormitory in Dormitories)
            {
                if (!dormitory.IsFull && dormitory.Faction == faction)
                {
                    dormitory.AssignNewBew();
                    return dormitory.LastEmptyBed;
                }
            }

            throw new AllDormitoriesAreFullException();
        }
    }
}