using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes.SaveReadyPersonnel;
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

        public Student(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race, LoginData login, int id) 
            : base(firstName, lastName, birthYear, gender, father, race, login, id)
        {
            Semester = 1;
            AuthType = AuthorizationType.Student;
            Faction = FactionType.None;
        }

        [JsonConstructor]
        public Student(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race,
            List<Message> messages, List<TrainTicket> tickets, int semester, int dormitoryNumber, int studentNumber, 
            FactionType faction, LoginData login, int id, WeeklySchedule schedule, petType pet, bool hasBaggage, 
            Location currentLocation, AuthorizationType authType)
        
        : base(firstName, lastName, birthYear, gender, father, race, messages, tickets, login, id, schedule, pet, hasBaggage, 
            currentLocation, authType)
        {
            Semester = semester;
            DormitoryNumber = dormitoryNumber;
            Faction = faction;
        }

        public void SetFaction(FactionType faction)
        {
            if (Faction != FactionType.None) return;
            Faction = faction;
        }
        
        public void SetBedNumber(int bedNumber)
        {
            if (DormitoryNumber != 0) return;
            DormitoryNumber = bedNumber;
        }

        public void SetWeeklySchedule(WeeklySchedule newSchedule)
        {
            Schedule = newSchedule;
        }

        public SaveReadyStudent ToSaveFormat()
        {
            List<string> subjectNames = new List<string>();
            foreach (var subject in Schedule.Subjects) subjectNames.Add(subject.Name);

            return new SaveReadyStudent(FirstName, LastName, BirthYear, Gender, Father, Race, subjectNames, Login, ID, Pet,
                HasBaggage, CurrentLocation, Messages, Tickets, Semester, DormitoryNumber, Faction);
        }
    }
}