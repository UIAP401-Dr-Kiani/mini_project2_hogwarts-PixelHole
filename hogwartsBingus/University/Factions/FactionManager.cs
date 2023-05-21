using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using hogwartsBingus.University.DataStorage;

namespace hogwartsBingus.Factions
{
    public static class FactionManager
    {
        private static Faction Slytherin = new Faction(FactionType.Slytherin),
                        Griffindor = new Faction(FactionType.Gryffindor),
                        Hufflepuf = new Faction(FactionType.Hufflepuff),
                        Ravenclaw = new Faction(FactionType.Raveclaw);

        private static Random random = new Random();

        public static int GetFactionPoints(FactionType faction)
        {
            switch (faction)
            {
                case FactionType.Gryffindor :
                    return Griffindor.Points;
                case FactionType.Slytherin :
                    return Slytherin.Points;
                case FactionType.Raveclaw :
                    return Ravenclaw.Points;
                case FactionType.Hufflepuff :
                    return Hufflepuf.Points;
                default:
                    throw new FactionNotFoundException();
            }
        }
        public static int GetFactionMemberCount(FactionType faction)
        {
            switch (faction)
            {
                case FactionType.Gryffindor :
                    return Griffindor.MemberCount;
                case FactionType.Slytherin :
                    return Slytherin.MemberCount;
                case FactionType.Raveclaw :
                    return Ravenclaw.MemberCount;
                case FactionType.Hufflepuff :
                    return Hufflepuf.MemberCount;
                default:
                    throw new FactionNotFoundException();
            }
        }
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

        public static void AddMemberToFaction(FactionType factionType)
        {
            switch (factionType)
            {
                case FactionType.Gryffindor :
                    Griffindor.AddMember();
                    break;
                case FactionType.Hufflepuff :
                    Hufflepuf.AddMember();
                    break;
                case FactionType.Raveclaw :
                    Ravenclaw.AddMember();
                    break;
                case FactionType.Slytherin :
                    Slytherin.AddMember();
                    break;
                default :
                    throw new FactionNotFoundException();
            }
        }
        public static void AwardPointsToFaction(FactionType factionType, int points)
        {
            switch (factionType)
            {
                case FactionType.Slytherin :
                    Slytherin.AwardPoints(points);
                    return;
                case FactionType.Gryffindor :
                    Griffindor.AwardPoints(points);
                    return;
                case FactionType.Hufflepuff :
                    Hufflepuf.AwardPoints(points);
                    return;
                case FactionType.Raveclaw :
                    Ravenclaw.AwardPoints(points);
                    return;
                case FactionType.None:
                    return;
                default:
                    throw new FactionNotFoundException();
            }
        }

        public static void RequestSave()
        {
            SaveFileManager.SaveFactions(new List<Faction>() {Slytherin, Griffindor, Hufflepuf, Ravenclaw});
        }
        public static void RequestLoad()
        {
            List<Faction> factions = SaveFileManager.LoadFactions();

            foreach (var faction in factions)
            {
                switch (faction.Type)
                {
                    case FactionType.Gryffindor :
                        Griffindor = faction;
                        continue;
                    case FactionType.Slytherin :
                        Slytherin = faction;
                        continue;
                    case FactionType.Hufflepuff :
                        Hufflepuf = faction;
                        continue;
                    case FactionType.Raveclaw :
                        Ravenclaw = faction;
                        continue;
                    default :
                        throw new FactionNotFoundException();
                }
            }
        }
    }
}