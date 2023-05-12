using System.Collections.Generic;
using System.Windows.Documents;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Factions;

namespace hogwartsBingus.University.Excercies
{
    public abstract class Exercise
    {
        protected readonly List<Student> Attendees = new List<Student>();
        public virtual void PrepareExercise() { }

        public virtual void PerformExercise(Student attendee)
        {
            if (Attendees.Contains(attendee)) return;
            Attendees.Add(attendee);
        }

        public virtual void AwardPoints(Faction faction, int amount) { }
    }
}