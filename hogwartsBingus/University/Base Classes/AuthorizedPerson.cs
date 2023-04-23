using System.Collections.Generic;
using hogwartsBingus.Factions;

namespace hogwartsBingus.Base_Classes
{
    public abstract class AuthorizedPerson : Human
    {
        //public int RoomNumber { get; protected set; }

        public int ID { get; protected set; }

        public WeeklySchedule Schedule { get; protected set; } 

        public petType Pet { get; protected set; }
        
        public FactionType Faction { get; protected set; }
        
        public bool HasBaggage { get; protected set; }
        
        public AuthorizationType AuthType { get; protected set; }

        public readonly List<Message> Messages = new List<Message>();

        protected AuthorizedPerson(int id, WeeklySchedule schedule, petType pet, FactionType faction,
            bool hasBaggage, AuthorizationType authType)
        {
            ID = id;
            Schedule = schedule;
            Pet = pet;
            Faction = faction;
            HasBaggage = hasBaggage;
            AuthType = authType;
        }
    }
}