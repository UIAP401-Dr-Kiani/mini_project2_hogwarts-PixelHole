using System.Collections.Generic;
using hogwartsBingus.Factions;

namespace hogwartsBingus.Base_Classes
{
    public class AuthorizedPerson : Human
    {
        public int RoomNUmber { get; protected set; }
        
        //study subject schedule

        public petType Pet { get; protected set; }
        
        public FactionType Faction { get; protected set; }
        
        public bool HasBaggage { get; protected set; }
        
        public AuthorizationType AuthType { get; protected set; }

        public readonly List<Message> Messages = new List<Message>();
    }
}