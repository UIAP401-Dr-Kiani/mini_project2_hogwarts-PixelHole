using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes.SaveReadyPersonnel;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public class Professor : AuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        public Professor(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race, LoginData login,
            int id, bool canTeachAtMultipleClasses)
            : base(firstName, lastName, birthYear, gender, father, race, login, id)
        {
            AuthType = AuthorizationType.Professor;
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }
        
        [JsonConstructor]
        public Professor(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race,
            List<Message> messages, List<TrainTicket> tickets, bool canTeachAtMultipleClasses,LoginData login, int id, 
            WeeklySchedule schedule, petType pet, bool hasBaggage, Location currentLocation, AuthorizationType authType)
        
            : base(firstName, lastName, birthYear, gender, father, race, messages, tickets, login, id, schedule, pet, hasBaggage, 
                currentLocation, authType)
        {
            AuthType = AuthorizationType.Professor;
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }

        public SaveReadyProfessor ToSaveFormat()
        {
            List<string> subjectNames = new List<string>();
            
            foreach (var subject in Schedule.Subjects)
            {
                subjectNames.Add(subject.Name);
            }
            
            return new SaveReadyProfessor(FirstName, LastName, BirthYear, Gender, Father, Race, subjectNames,
                Login, ID, Pet, HasBaggage, CurrentLocation, Messages, Tickets, CanTeachAtMultipleClasses);
        }
    }
}