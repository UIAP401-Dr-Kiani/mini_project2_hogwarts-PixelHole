using System;

namespace hogwartsBingus.Base_Classes
{
    public class Student : AuthorizedPerson
    {
        public int PassedCourses { get; protected set; }
        public int Semester { get; protected set; }
        public int DormitoryNunmber { get; protected set; }
    }
}