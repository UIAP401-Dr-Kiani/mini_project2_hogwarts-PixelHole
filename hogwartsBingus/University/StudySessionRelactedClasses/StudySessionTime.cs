namespace hogwartsBingus.Base_Classes
{
    public class StudySessionTime
    {
        public Day Day { get; protected set; }
        public int Hour { get; protected set; }
        public int minute { get; protected set; }

        public StudySessionTime(Day day, int hour, int minute)
        {
            this.Day = day;
            this.Hour = hour;
            this.minute = minute;
        }
    }
}