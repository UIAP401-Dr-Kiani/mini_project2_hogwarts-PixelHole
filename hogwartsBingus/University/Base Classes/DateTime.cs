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

        public static int GetDayIndex(Day day)
        {
            switch (day)
            {
                case Day.Saturday:
                    return 1;
                case Day.Sunday:
                    return 2;
                case Day.Monday:
                    return 3;
                case Day.Tuesday:
                    return 4;
                case Day.Wednesday:
                    return 5;
                case Day.Thursday:
                    return 6;
                case Day.Friday:
                    return 7;
            }

            return 0;
        }

        public static Day GetDayFromIndex(int index)
        {
            switch (index)
            {
                case 1 :
                    return Day.Saturday;
                case 2 :
                    return Day.Sunday;
                case 3 :
                    return Day.Monday;
                case 4 :
                    return Day.Tuesday;
                case 5 :
                    return Day.Wednesday;
                case 6 :
                    return Day.Thursday;
                case 7 :
                    return Day.Friday;
            }

            return Day.None;
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
        public static DateTime operator -(DateTime a, DateTime b)
        {
            int nHour = a.Hour - b.Hour,
                nMinute = a.minute - b.minute,
                nDay = GetDayIndex(a.Day) - GetDayIndex(b.Day);

            if (nHour < 0) nHour += 24;
            if (nMinute < 0) nMinute += 60;
            if (nDay < 0) nMinute += 6;

            DateTime c = new DateTime(GetDayFromIndex(nDay), nHour, nMinute);

            return c;
        }
        public static bool operator <(DateTime a, DateTime b)
        {
            if (GetDayIndex(a.Day) < GetDayIndex(b.Day))
            {
                return true;
            }
            if (GetDayIndex(a.Day) > GetDayIndex(b.Day)) return false;
            if (a.Hour < b.Hour || a.Hour == b.Hour && a.minute < b.minute)
            {
                return true;
            }

            return false;
        }
        public static bool operator >(DateTime a, DateTime b)
        {
            if (GetDayIndex(a.Day) > GetDayIndex(b.Day))
            {
                return true;
            }
            if (GetDayIndex(a.Day) < GetDayIndex(b.Day)) return false;
            if (a.Hour > b.Hour || a.Hour == b.Hour && a.minute > b.minute)
            {
                return true;
            }

            return false;
        }
        public static bool operator <=(DateTime a, DateTime b)
        {
            if (GetDayIndex(a.Day) <= GetDayIndex(b.Day))
            {
                return true;
            }
            if (GetDayIndex(a.Day) > GetDayIndex(b.Day)) return false;
            if (a.Hour <= b.Hour || a.Hour == b.Hour && a.minute <= b.minute)
            {
                return true;
            }

            return false;
        }
        public static bool operator >=(DateTime a, DateTime b)
        {
            if (GetDayIndex(a.Day) >= GetDayIndex(b.Day))
            {
                return true;
            }
            if (GetDayIndex(a.Day) < GetDayIndex(b.Day)) return false;
            if (a.Hour >= b.Hour || a.Hour == b.Hour && a.minute >= b.minute)
            {
                return true;
            }

            return false;
        }
        public static bool operator ==(DateTime a, DateTime b)
        {
            return GetDayIndex(a.Day) == GetDayIndex(b.Day) && a.Hour == b.Hour && a.minute == b.minute;
        }
        public static bool operator !=(DateTime a, DateTime b)
        {
            return GetDayIndex(a.Day) != GetDayIndex(b.Day) && a.Hour != b.Hour && a.minute != b.minute;
        }
    }
}