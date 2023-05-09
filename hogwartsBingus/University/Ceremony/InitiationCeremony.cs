using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;
using hogwartsBingus.University.DormitoryData;

namespace hogwartsBingus.University.Ceremony
{
    public static class InitiationCeremony
    {
        private static readonly List<Student> Attendees = new List<Student>();

        public static DateTime Date { get; private set; }

        public static void AddAttendee(Student user)
        {
            if (Attendees.IndexOf(user) != -1)
            {
                return;
            }
            
            Attendees.Add(user);
        }
        
        public static void RemoveAttendee(Student user)
        {
            if (Attendees.IndexOf(user) == -1)
            {
                return;
            }
            
            Attendees.Remove(user);
        }
        
        public static void RemoveAttendeeAt(int index)
        {
            if (index < 0 || index > Attendees.Count - 1)
            {
                return;
            }
            
            Attendees.RemoveAt(index);
        }

        public static void CheckForStart()
        {
            
        }

        public static void SetDate(DateTime date)
        {
            Date = date;
        }
        public static void BeginCeremony()
        {
            AssignFactionForFirstYears();
            AssignDorms();
        }

        private static void AssignFactionForFirstYears()
        {
            foreach (var attendee in Attendees)
            {
                if (attendee.Semester == 1)
                {
                    attendee.SetFaction(FactionManager.GetRandomFaction());
                }
            }
        }

        private static void AssignDorms()
        {
            for (int i = 1; i <= 8; i++)
            {
                AssignDormsForStudentsOfSemester(i);
            }
        }

        private static void AssignDormsForStudentsOfSemester(int semester)
        {
            foreach (var attendee in Attendees)
            {
                if (attendee.Semester == semester)
                {
                    DormitoryManager.GetBedNumberOfType(attendee.Faction);
                }
            }
        }
    }
}