using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes
{
    public class Dormitory
    {
        public static readonly List<int> Residents = new List<int>();

        public FactionType Type { get; protected set; }

        public int LastEmptyBed
        {
            get;
            protected set; }
    }
}