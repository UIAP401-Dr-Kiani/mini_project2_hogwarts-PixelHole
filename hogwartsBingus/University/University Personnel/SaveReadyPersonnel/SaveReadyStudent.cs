using System;
using System.Collections.Generic;
using hogwartsBingus.DataStorage;
using hogwartsBingus.University.StudySessionRelactedClasses;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes.SaveReadyPersonnel
{
    public class SaveReadyStudent : SaveReadyAuthorizedPerson
    {
        public int Semester { get; protected set; }
        public int DormitoryNumber { get; protected set; }
        public FactionType Faction { get; protected set; }

        [JsonConstructor]
        public SaveReadyStudent(string firstName,
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
            List<TrainTicket> tickets,
            int semester,
            int dormitoryNumber,
            FactionType faction) : base(firstName,
            lastName,
            birthYear,
            gender,
            father,
            race,
            subjectNames,
            login,
            id,
            pet,
            hasBaggage,
            currentLocation,
            messages,
            tickets)
        {
            Semester = semester;
            DormitoryNumber = dormitoryNumber;
            Faction = faction;
        }

        public Student ToStudent()
        {
            List<StudySubject> subjects = new List<StudySubject>();

            foreach (var subjectName in subjectNames)
            {
                subjects.Add(SubjectManager.GetSubjectByName(subjectName));
            }
            
            return new Student(FirstName, LastName, BirthYear, Gender, Father, Race, Messages, Tickets, Semester,
                DormitoryNumber,
                ID, Faction, Login, ID, new WeeklySchedule(subjects), Pet, HasBaggage, CurrentLocation, AuthorizationType.Student);
        }
    }
}