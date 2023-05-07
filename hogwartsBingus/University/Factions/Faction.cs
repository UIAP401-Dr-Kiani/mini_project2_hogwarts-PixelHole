using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.Factions
{
    public class Faction
    {
        public FactionType type { get; private set; }
        
        public static Int64 Points { get; private set; }
        
        public static readonly List<Student> quidditchPlayers = new List<Student>();

        public Faction(FactionType factionType)
        {
            type = factionType;
        }

        public void AwardPoints(int amount)
        {
            Points += amount;
        }
    }
}