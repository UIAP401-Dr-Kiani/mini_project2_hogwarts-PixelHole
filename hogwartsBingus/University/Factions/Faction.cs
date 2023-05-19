using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using Newtonsoft.Json;

namespace hogwartsBingus.Factions
{
    public class Faction
    {
        public FactionType Type { get; private set; }
        public int Points { get; private set; }
        public int MemberCount { get; private set; }
        public readonly List<string> QuidditchPlayers = new List<string>();

        public Faction(FactionType factionType)
        {
            Type = factionType;
        }

        [JsonConstructor]
        public Faction(FactionType type, int points, int memberCount, List<string> quidditchPlayers)
        {
            Type = type;
            Points = points;
            MemberCount = memberCount;
            QuidditchPlayers = quidditchPlayers;
        }
        public void AwardPoints(int amount)
        {
            Points += amount;
        }
    }
}