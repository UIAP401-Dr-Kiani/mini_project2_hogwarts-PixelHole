using System;

namespace hogwartsBingus.Base_Classes
{
    public class Student : AuthorizedPerson
    {
        public int PassedCourses { get; protected set; }
        public int Semester { get; protected set; }
        public int DormitoryNumber { get; protected set; }
        public int StudentNumber
        {
            get => base.ID;
            set => base.ID = value;
        }

        public Student(int id, WeeklySchedule schedule, petType pet, FactionType faction, bool hasBaggage,
            AuthorizationType authType, int passedCourses, int semester, int dormitoryNumber) 
            : base(id, schedule, pet, faction, hasBaggage, authType)
        {
            PassedCourses = passedCourses;
            Semester = semester;
            DormitoryNumber = dormitoryNumber;
        }
    }
}