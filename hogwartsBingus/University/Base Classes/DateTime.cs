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

        public bool Compare(DateTime check) => Day == check.Day && Hour == check.Hour && minute == check.minute;

        public static int GetDayIndex(Day day)
        {
            switch (day)
            {
                case Day.Saturday:
                    return 0;
                case Day.Sunday:
                    return 1;
                case Day.Monday:
                    return 2;
                case Day.Tuesday:
                    return 3;
                case Day.Wednesday:
                    return 4;
                case Day.Thursday:
                    return 5;
                case Day.Friday:
                    return 6;
            }

            return -1;
        }

        public static Day GetDayFromIndex(int index)
        {
            switch (index)
            {
                case 0 :
                    return Day.Saturday;
                case 1 :
                    return Day.Sunday;
                case 2 :
                    return Day.Monday;
                case 3 :
                    return Day.Tuesday;
                case 4 :
                    return Day.Wednesday;
                case 5 :
                    return Day.Thursday;
                case 6 :
                    return Day.Friday;
            }

            return Day.Friday;
        }
        public static DateTime operator +(DateTime a, DateTime b)
        {
            int nHour = a.Hour + b.Hour,
                nMinute = a.minute + b.minute,
                nDay = GetDayIndex(a.Day) + GetDayIndex(b.Day);

            if (nHour >= 24) nHour -= 24;
            if (nMinute >= 60) nMinute -= 60;
            if (nDay > 6) nMinute -= 6;

            DateTime c = new DateTime(GetDayFromIndex(nDay), nHour, nMinute);

            return c;
        }
    }
}