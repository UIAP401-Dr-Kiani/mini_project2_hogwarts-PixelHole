using System;
using System.Collections.Generic;
using System.Linq;
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

        public WeeklySchedule Schedule { get; protected set; } = new WeeklySchedule();
        public petType Pet { get; protected set; }

        public bool HasBaggage { get; protected set; }
        public Location CurrentLocation { get; protected set; }
        public AuthorizationType AuthType { get; protected set; }

        
        public readonly List<Message> Messages;
        public readonly List<TrainTicket> Tickets;

        protected AuthorizedPerson(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race,
            LoginData login, int id) : base(firstName, lastName, birthYear, gender, father, race)
        {
            Messages = new List<Message>();
            Tickets = new List<TrainTicket>();
            Login = login;
            ID = id;
        }

        [JsonConstructor]
        protected AuthorizedPerson(string firstName, string lastName, DateTime birthYear, gender gender, string fahter, Race race,
            List<Message> messages, List<TrainTicket> tickets, LoginData login, int id, 
            WeeklySchedule schedule, petType pet, bool hasBaggage, Location currentLocation, AuthorizationType authType)
            : base(firstName, lastName, birthYear, gender, fahter,race)
        {
            Messages = messages;
            Tickets = tickets;
            Login = login;
            ID = id;
            Schedule = schedule;
            Pet = pet;
            HasBaggage = hasBaggage;
            CurrentLocation = currentLocation;
            AuthType = authType;
        }
        
        

        public void AddMessage(Message message)
        {
            if (Messages.Contains(message)) return;
            Messages.Add(message);
        }
        public void RemoveMessage(Message message)
        {
            if (!Messages.Contains(message)) return;
            Messages.Remove(message);
        }
        public void UpdateMessages(List<Message> messages)
        {
            Messages.Clear();
            messages.ForEach(message => Messages.Add(message));
        }
        public void AddTicket(TrainTicket ticket)
        {
            if (Tickets.Contains(ticket)) return;
            Tickets.Add(ticket);
        }
        public void RemoveTicket(TrainTicket ticket)
        {
            if (!Tickets.Contains(ticket)) return;
            Tickets.Remove(ticket);
        }
        public Message FindMessageWithTitle(string title)
        {
            try
            {
                return Messages.Find(message => message.Title == title);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
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
        public void MoveToLocation(Location newLocation) => CurrentLocation = newLocation;

        public override string ToString()
        {
            return FullName;
        }
        public void SetWeeklySchedule(WeeklySchedule newSchedule)
        {
            Schedule = newSchedule;
        }
    }
}