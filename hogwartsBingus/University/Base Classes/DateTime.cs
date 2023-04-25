namespace hogwartsBingus.Base_Classes
{
    public class DateTime
    {
        public Day Day { get; protected set; }
        public int Hour { get; protected set; }
        public int minute { get; protected set; }

        public DateTime(Day day, int hour, int minute)
        {
            Day = day;
            Hour = hour;
            this.minute = minute;
        }
    }
}