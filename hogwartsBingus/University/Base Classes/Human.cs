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

        public LoginData Login { get; protected set; }

        public Race race { get; protected set; }
    }
}