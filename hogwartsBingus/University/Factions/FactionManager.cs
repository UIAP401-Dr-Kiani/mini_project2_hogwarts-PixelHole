using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.Factions
{
    public static class FactionManager
    {
        private static Faction Slytherin = new Faction(FactionType.Slytherin),
                        Griffindor = new Faction(FactionType.Gryffindor),
                        Hufflepuf = new Faction(FactionType.Hufflepuff),
                        Ravenclaw = new Faction(FactionType.Raveclaw);

        private static Random random = new Random();
        
        public static FactionType GetRandomFaction()
        {
            int factionIndex = random.Next(0, 4);
            switch (factionIndex)
            {
                case 0 :
                    return FactionType.Slytherin;
                case 1 :
                    return FactionType.Gryffindor;
                case 2 :
                    return FactionType.Hufflepuff;
                case 3 :
                    return FactionType.Raveclaw;
            }

            return FactionType.None;
        }
    }
}