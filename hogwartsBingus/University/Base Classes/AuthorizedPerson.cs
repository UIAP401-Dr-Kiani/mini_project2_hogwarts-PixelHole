using System.Collections.Generic;
using System.Windows.Documents;
using hogwartsBingus.Factions;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public class AuthorizedPerson : Human
    {
        //public int RoomNumber { get; protected set; }

        public LoginData Login { get; protected set; }
        public int ID { get; protected set; }

        public WeeklySchedule Schedule { get; protected set; }
        public petType Pet { get; protected set; }

        public bool HasBaggage { get; protected set; }
        public Location CurrentLocation { get; protected set; }
        public AuthorizationType AuthType { get; protected set; }

        public List<Message> Messages = new List<Message>();
        public List<TrainTicket> Tickets = new List<TrainTicket>();

        protected AuthorizedPerson(string firstName, string lastName, int birthYear, gender gender, Race race,
            LoginData login, int id) : base(firstName, lastName, birthYear, gender, race)
        {
            Login = login;
            ID = id;
        }

        [JsonConstructor]
        protected AuthorizedPerson(string firstName, string lastName, int birthYear, int gender, int race,
            List<Message> messages, List<TrainTicket> tickets, LoginData login, int id, 
            WeeklySchedule schedule, int pet, bool hasBaggage, int currentLocation, int authType)
            : base(firstName, lastName, birthYear, gender, race)
        {
            Messages = messages;
            Tickets = tickets;
            Login = login;
            ID = id;
            Schedule = schedule;
            Pet = (petType)pet;
            HasBaggage = hasBaggage;
            CurrentLocation = (Location)currentLocation;
            AuthType = (AuthorizationType)authType;
        }
        
        

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        public void RemoveMessage(Message message)
        {
            Messages.Remove(message);
        }
        public void AddTicket(TrainTicket ticket)
        {
            Tickets.Add(ticket);
        }
        public void RemoveTicket(TrainTicket ticket)
        {
            Tickets.Remove(ticket);
        }

        public void RemoveTicketForTrain(int trainNumber, DateTime moveTime)
        {
            Tickets.RemoveAt(FindTicketForTrain(trainNumber, moveTime));
        }

        public int FindTicketForTrain(int trainNumber, DateTime moveTime)
        {
            for (int i = 0; i < Tickets.Count ; i++)
            {
                if (Tickets[i].TrainNumber == trainNumber && Tickets[i].MoveTime == moveTime)
                {
                    return i;
                }
            }

            return -1;
        }
        public bool HasTicketForTrain(int trainNumber, DateTime moveTime)
        {
            return FindTicketForTrain(trainNumber, moveTime) != -1;
        }

        public void MoveToLocation(Location newLocation) => CurrentLocation = newLocation;
    }
}