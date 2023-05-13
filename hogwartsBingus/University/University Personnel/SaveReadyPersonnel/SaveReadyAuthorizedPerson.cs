using System.Collections.Generic;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes.SaveReadyPersonnel
{
    public class SaveReadyAuthorizedPerson : Human
    {
        public LoginData Login { get; protected set; }
        public int ID { get; protected set; }

        public List<string> subjectNames;
        public petType Pet { get; protected set; }

        public bool HasBaggage { get; protected set; }
        public Location CurrentLocation { get; protected set; }
        public AuthorizationType AuthType { get; protected set; }

        public List<Message> Messages = new List<Message>();
        public List<TrainTicket> Tickets = new List<TrainTicket>();

        public SaveReadyAuthorizedPerson(string firstName,
            string lastName,
            int birthYear,
            gender gender,
            Race race,
            List<string> subjectNames,
            LoginData login,
            int id,
            petType pet,
            bool hasBaggage,
            Location currentLocation,
            AuthorizationType authType)
            :
            base(firstName,
            lastName,
            birthYear,
            gender,
            race)
        {
            this.subjectNames = subjectNames;
            Login = login;
            ID = id;
            Pet = pet;
            HasBaggage = hasBaggage;
            CurrentLocation = currentLocation;
            AuthType = authType;
        }
    }
}