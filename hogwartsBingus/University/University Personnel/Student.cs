using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public class Student : AuthorizedPerson
    {
        //public int PassedCourses { get; protected set; }
        public int Semester { get; protected set; }
        public int DormitoryNumber { get; protected set; }
        public int StudentNumber
        {
            get => base.ID;
            set => base.ID = value;
        }
        public FactionType Faction { get; protected set; }

        public Student(string firstName, string lastName, int birthYear, gender gender, Race race, LoginData login, int id) 
            : base(firstName, lastName, birthYear, gender, race, login, id)
        {
            this.Semester = 1;
            this.AuthType = AuthorizationType.Student;
            this.Faction = FactionType.None;
        }

        [JsonConstructor]
        public Student(string firstName, string lastName, int birthYear, int gender, int race,
            List<Message> messages, List<TrainTicket> tickets, int semester, int dormitoryNumber, int studentNumber, 
            int faction, LoginData login, int id, WeeklySchedule schedule, int pet, bool hasBaggage, 
            int currentLocation, int authType)
        
        : base(firstName, lastName, birthYear, gender, race, messages, tickets, login, id, schedule, pet, hasBaggage, 
            currentLocation, authType)
        {
            Semester = semester;
            DormitoryNumber = dormitoryNumber;
            Faction = (FactionType)faction;
        }

        public void SetFaction(FactionType faction)
        {
            this.Faction = faction;
        }
    }
}