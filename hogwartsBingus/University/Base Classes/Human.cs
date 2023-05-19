using System;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public abstract class Human
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        [JsonIgnore]
        public string FullName
        {
            get => FirstName + " " + LastName;
            set
            {
                FirstName = value.Split(' ')[0];
                LastName = value.Split(' ')[1];
            }
        }

        public DateTime BirthYear { get; protected set; }
        
        public gender Gender { get; protected set; }
        
        public string Father { get; protected set; }

        public Race Race { get; protected set; }

        [JsonConstructor]
        protected Human(string firstName, string lastName, DateTime birthYear, gender gender, string father, Race race)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Gender = gender;
            Father = father;
            Race = race;
        }
    }
}