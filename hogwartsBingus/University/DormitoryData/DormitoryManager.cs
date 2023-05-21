using System.Collections.Generic;
using System.Management.Instrumentation;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using hogwartsBingus.University.DataStorage;

namespace hogwartsBingus.University.DormitoryData
{
    public static class DormitoryManager
    {
        public static List<Dormitory> Dormitories = new List<Dormitory>();

        static DormitoryManager()
        {
            
        }
        public static void AddDormitory(Dormitory dormitory)
        {
            if (GetDormitoryByName(dormitory.Name) != null) throw new InvalidDormitoryNameException();
            Dormitories.Add(dormitory);
        }
        public static void RemoveDormitory(Dormitory dormitory)
        {
            if (GetDormitoryByName(dormitory.Name) == null) throw new InstanceNotFoundException();
            Dormitories.Remove(dormitory);
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
        public static Dormitory GetDormitoryByName(string name)
        {
            return Dormitories.Find(dormitory => dormitory.Name == name);
        }

        public static void RequestSave()
        {
            SaveFileManager.SaveDormitories(Dormitories);
        }
        public static void RequestLoad()
        {
            Dormitories = SaveFileManager.LoadDormitories();
        }
    }
}