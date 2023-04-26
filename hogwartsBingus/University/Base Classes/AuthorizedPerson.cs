using System.Collections.Generic;
using System.Windows.Documents;
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
        
        public string CurrentLocation { get; protected set; }
        
        public AuthorizationType AuthType { get; protected set; }

        public readonly List<Message> Messages = new List<Message>();
        public readonly List<TrainTicket> Tickets = new List<TrainTicket>();

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
                if (Tickets[i].TrainNumber == trainNumber && Tickets[i].MoveTime.Compare(moveTime))
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

        public void MoveToLocation(string newLocation) => CurrentLocation = newLocation;
    }
}