namespace hogwartsBingus.Base_Classes
{
    public class StudySessionTime : DateTime
    {
        public StudySessionTime(Day day, int hour, int minute) : base(day, hour, minute)
        {
        }
    }
}