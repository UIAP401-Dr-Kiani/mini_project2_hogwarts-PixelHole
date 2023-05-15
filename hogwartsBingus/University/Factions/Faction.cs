using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.Factions
{
    public class Faction
    {
        public FactionType type { get; private set; }
        public Int64 Points { get; private set; }
        public int MemberCount { get; private set; }
        public readonly List<string> quidditchPlayers = new List<string>();

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