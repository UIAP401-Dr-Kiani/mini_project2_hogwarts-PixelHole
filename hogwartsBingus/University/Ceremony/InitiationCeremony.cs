using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;

namespace hogwartsBingus.University.Ceremony
{
    public static class InitiationCeremony
    {
        private static readonly List<AuthorizedPerson> Attendees = new List<AuthorizedPerson>();



        public static void AddAttendee(AuthorizedPerson userIndex)
        {
            if (Attendees.IndexOf(userIndex) != -1)
            {
                return;
            }
            
            Attendees.Add(userIndex);
        }
        
        public static void RemoveAttendee(AuthorizedPerson userIndex)
        {
            if (Attendees.IndexOf(userIndex) == -1)
            {
                return;
            }
            
            Attendees.Remove(userIndex);
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
            
        }

        private static void TransformAllToStudent()
        {
            foreach (var attendee in Attendees)
            {
                Student newStudent = (Student)attendee;
                //UserManager.;
                
            }
        }
        
        private static void AssignFactionForAll()
        {
            foreach (var attendee in Attendees)
            {
                
            }
        }
    }
}