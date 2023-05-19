using System;
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

        public List<Message> Messages;
        public List<TrainTicket> Tickets;

        public SaveReadyAuthorizedPerson(string firstName,
            string lastName,
            DateTime birthYear,
            gender gender,
            string father,
            Race race,
            List<string> subjectNames,
            LoginData login,
            int id,
            petType pet,
            bool hasBaggage,
            Location currentLocation,
            List<Message> messages, 
            List<TrainTicket> tickets)
            :
            base(firstName,
            lastName,
            birthYear,
            gender,
            father,
            race)
        {
            this.subjectNames = subjectNames;
            Login = login;
            ID = id;
            Pet = pet;
            HasBaggage = hasBaggage;
            CurrentLocation = currentLocation;
            Messages = messages;
            Tickets = tickets;
        }
    }
}