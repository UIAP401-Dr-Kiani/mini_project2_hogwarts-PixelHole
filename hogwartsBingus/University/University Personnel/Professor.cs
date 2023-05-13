using System.Collections.Generic;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public class Professor : AuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        public Professor(string firstName, string lastName, int birthYear, gender gender, Race race, LoginData login,
            int id, bool canTeachAtMultipleClasses)
            : base(firstName, lastName, birthYear, gender, race, login, id)
        {
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }
        
        [JsonConstructor]
        public Professor(string firstName, string lastName, int birthYear, gender gender, Race race,
            List<Message> messages, List<TrainTicket> tickets, LoginData login, int id, WeeklySchedule schedule, 
            petType pet, bool hasBaggage, Location currentLocation, AuthorizationType authType)
        
            : base(firstName, lastName, birthYear, gender, race, messages, tickets, login, id, schedule, pet, hasBaggage, 
                currentLocation, authType)
        {
            
        }
    }
}