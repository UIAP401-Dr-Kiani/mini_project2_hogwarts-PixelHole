using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public abstract class Human
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public string FullName
        {
            get => FirstName + " " + LastName;
            set
            {
                FirstName = value.Split(' ')[0];
                LastName = value.Split(' ')[1];
            }
        }

        public int BirthYear { get; protected set; }
        
        public gender Gender { get; protected set; }
        
        public Human Father { get; protected set; }

        public Race Race { get; protected set; }

        protected Human(string firstName, string lastName, int birthYear, gender gender, Race race)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Gender = gender;
            Race = race;
        }
        
        [JsonConstructor]
        protected Human(string firstName, string lastName, int birthYear, int gender, int race)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            Gender = (gender)gender;
            Race = (Race)race;
        }
    }
}