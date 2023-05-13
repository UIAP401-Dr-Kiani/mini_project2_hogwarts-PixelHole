using System;
using System.Collections.Generic;
using System.Windows.Documents;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Factions;
using Newtonsoft.Json;

namespace hogwartsBingus.University.Excercies
{
    public class Exercise
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DeadLine { get; protected set; }
        public readonly List<int> Attendees = new List<int>();

        protected Exercise()
        {
            
        }
        protected Exercise(string name, string description, DateTime deadLine)
        {
            Name = name;
            Description = description;
            DeadLine = deadLine;
        }

        [JsonConstructor]
        protected Exercise(List<int> attendees, string name, string description, DateTime deadLine)
        {
            Name = name;
            Description = description;
            DeadLine = deadLine;
            Attendees = attendees;
        }

        public virtual void PrepareExercise()
        {
            
        }
        public virtual void StudentFinishedExercise(int attendee)
        {
            if (Attendees.Contains(attendee)) return;
            Attendees.Add(attendee);
            
            FactionType? nullableFaction = UserManager.GetFactionAt(UserManager.FindWithID(attendee));
            FactionType faction = nullableFaction ?? FactionType.None;

            AwardPoints(faction , EvaluatePoints());
        }
        public virtual void AwardPoints(FactionType faction, int amount) { }

        protected virtual int EvaluatePoints()
        {
            return 0;
        }

        public bool StudentHasDoneExercise(int id) => Attendees.Contains(id);

        /// <summary>
        /// returns an overview of the exercise
        /// </summary>
        /// <returns></returns>
        public virtual string[] GetExerciseOverview()
        {
            return new[] { Name, Description };
        }
        public override string ToString()
        {
            return Name;
        }
    }
}