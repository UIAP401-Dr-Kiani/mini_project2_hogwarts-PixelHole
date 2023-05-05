using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.University.DormitoryData
{
    public static class DormitoryManager
    {
        public static readonly List<Dormitory> Dormitories = new List<Dormitory>();

        static DormitoryManager()
        {
            Dormitories.Add(new Dormitory(6));
        }
    }
}