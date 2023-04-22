using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.Factions
{
    public static class Hufflepuf
    {
        private static FactionType type = FactionType.Hufflepuff;

        public static Int64 Points;

        public static readonly List<Student> Members = new List<Student>();
        public static readonly List<Student> quidditchPlayers = new List<Student>();
    }
}