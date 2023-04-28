using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes
{
    public class Dormitory
    {
        public static readonly List<Student> Residents = new List<Student>();

        public FactionType Type { get; protected set; }

        public int LastEmptyBed
        {
            get;
            protected set; 
        }

        public void AddResident(Student userIndex)
        {
            if (Residents.IndexOf(userIndex) != -1)
            {
                return;
            }
            Residents.Add(userIndex);
        }

        public void RemoveResident(Student userIndex)
        {
            if (Residents.IndexOf(userIndex) == -1)
            {
                return;
            }
            Residents.Remove(userIndex);
        }

        public void RemoveResidentAt(int index)
        {
            if (index < 0 || index >= Residents.Count)
            {
                return;
            }
            Residents.RemoveAt(index);
        }
    }
}