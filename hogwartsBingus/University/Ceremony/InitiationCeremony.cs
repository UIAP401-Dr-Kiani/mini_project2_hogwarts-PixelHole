using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;

namespace hogwartsBingus.University.Ceremony
{
    public static class InitiationCeremony
    {
        private static readonly List<Student> Attendees = new List<Student>();



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

        public static void BeginCeremony()
        {
            AssignFactionForFirstYears();
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
            
        }
    }
}