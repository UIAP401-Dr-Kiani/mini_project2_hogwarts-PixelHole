using System;

namespace hogwartsBingus.Base_Classes
{
    public class Student : AuthorizedPerson
    {
        //public int PassedCourses { get; protected set; }
        public int Semester { get; protected set; }
        public int DormitoryNumber { get; protected set; }
        public int StudentNumber
        {
            get => base.ID;
            set => base.ID = value;
        }
        public FactionType Faction { get; protected set; }

        public Student(LoginData loginData) : base(loginData)
        {
            this.Semester = 1;
            this.AuthType = AuthorizationType.Student;
        }

        public void SetFaction(FactionType faction)
        {
            this.Faction = faction;
        }
    }
}