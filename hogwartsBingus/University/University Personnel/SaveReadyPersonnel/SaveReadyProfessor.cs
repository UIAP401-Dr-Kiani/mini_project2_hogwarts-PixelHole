using System;
using System.Collections.Generic;
using hogwartsBingus.DataStorage;
using hogwartsBingus.University.StudySessionRelactedClasses;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes.SaveReadyPersonnel
{
    public class SaveReadyProfessor : SaveReadyAuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        [JsonConstructor]
        public SaveReadyProfessor(string firstName,
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
            bool canTeachAtMultipleClasses) : base(firstName,
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
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }

        public Professor ToProfessor()
        {
            List<StudySubject> subjects = new List<StudySubject>();
            foreach (var subjectName in subjectNames)
            {
                subjects.Add(SubjectManager.GetSubjectByName(subjectName));
            }

            return new Professor(FirstName,
                LastName,
                BirthYear,
                Gender,
                Father,
                Race,
                Messages,
                Tickets,
                CanTeachAtMultipleClasses,
                Login,
                ID,
                new WeeklySchedule(subjects), Pet, HasBaggage, CurrentLocation, AuthorizationType.Professor);
        }
    }
}