using System;
using Newtonsoft.Json;

namespace hogwartsBingus.Base_Classes
{
    public class DateTime
    {
        
        public int Year { get; protected set; }
        public int Month { get; protected set; }
        public int Date { get; protected set; }
        public Day DayName { get; protected set; }
        public int Hour { get; protected set; }
        public int Minute { get; protected set; }

        public DateTime(Day dayName, int hour, int minute)
        {
            DayName = dayName;
            Hour = hour;
            this.Minute = minute;
        }
        public DateTime(int year, int month, int date, Day dayName, int hour, int minute)
        {
            Year = year;
            Month = month;
            Date = date;
            DayName = dayName;
            Hour = hour;
            this.Minute = minute;
        }
        
        [JsonConstructor]
        public DateTime(int year, int month, int date, int dayName, int hour, int minute)
        {
            Year = year;
            Month = month;
            Date = date;
            DayName = (Day)dayName;
            Hour = hour;
            this.Minute = minute;
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
                nMinute = a.Minute + b.Minute,
                nDay = GetDayIndex(a.DayName) + GetDayIndex(b.DayName),
                nYear = a.Year + b.Year,
                nMonth = a.Month + b.Month,
                nDate = a.Date + b.Date;

            if (nHour >= 24) nHour -= 24;
            if (nMinute >= 60) nMinute -= 60;
            if (nDay > 6) nMinute -= 6;
            if (nMonth > 13) nMinute -= 12;
            if (nDate > 30) nMinute -= 30;

            DateTime c = new DateTime(nYear, nMonth, nDate, GetDayFromIndex(nDay), nHour, nMinute);

            return c;
        }
        public static DateTime operator -(DateTime a, DateTime b)
        {
            int nHour = a.Hour - b.Hour,
                nMinute = a.Minute - b.Minute,
                nDay = GetDayIndex(a.DayName) - GetDayIndex(b.DayName),
                nYear = a.Year - b.Year,
                nMonth = a.Month - b.Month,
                nDate = a.Date - b.Date; 

            if (nHour < 0) nHour += 24;
            if (nMinute < 0) nMinute += 60;
            if (nDay < 0) nMinute += 6;
            if (nMonth < 0) nMinute += 12;
            if (nDate < 0) nDate += 30;

            DateTime c = new DateTime(nYear, nMonth, nDate, GetDayFromIndex(nDay), nHour, nMinute);

            return c;
        }
        public static bool operator <(DateTime a, DateTime b)
        {
            if (a.Year < b.Year) return true;
            if (a.Year == b.Year && a.Month < b.Month) return true;
            if (a.Month == b.Month && a.Date < b.Date) return true;
            if (GetDayIndex(a.DayName) < GetDayIndex(b.DayName)) return true;
            if (GetDayIndex(a.DayName) > GetDayIndex(b.DayName)) return false;
            if (a.Hour < b.Hour || a.Hour == b.Hour && a.Minute < b.Minute) return true;

            return false;
        }
        public static bool operator >(DateTime a, DateTime b)
        {
            if (a.Year > b.Year) return true;
            if (a.Year == b.Year && a.Month > b.Month) return true;
            if (a.Month == b.Month && a.Date > b.Date) return true;
            if (GetDayIndex(a.DayName) > GetDayIndex(b.DayName)) return true;
            if (GetDayIndex(a.DayName) < GetDayIndex(b.DayName)) return false;
            if (a.Hour > b.Hour || a.Hour == b.Hour && a.Minute > b.Minute) return true;

            return false;
        }
        public static bool operator <=(DateTime a, DateTime b)
        {
            return a < b || a == b;
            /*if (a.Year <= b.Year) return true;
            if (a.Year == b.Year && a.Month <= b.Month) return true;
            if (GetDayIndex(a.DayName) <= GetDayIndex(b.DayName)) return true;
            if (GetDayIndex(a.DayName) > GetDayIndex(b.DayName)) return false;
            if (a.Hour <= b.Hour || a.Hour == b.Hour && a.Minute <= b.Minute) return true;

            return false;*/
        }
        public static bool operator >=(DateTime a, DateTime b)
        {
            return a > b || a == b;
            /*if (a.Year >= b.Year) return true;
            if (a.Year == b.Year && a.Month >= b.Month) return true;
            if (GetDayIndex(a.DayName) >= GetDayIndex(b.DayName)) return true;
            if (GetDayIndex(a.DayName) < GetDayIndex(b.DayName)) return false;
            if (a.Hour >= b.Hour || a.Hour == b.Hour && a.Minute >= b.Minute) return true;

            return false;*/
        }
        public static bool operator ==(DateTime a, DateTime b)
        {
            return GetDayIndex(a.DayName) == GetDayIndex(b.DayName) && a.Hour == b.Hour && a.Minute == b.Minute 
                   && a.Year == b.Year && a.Month == b.Month && a.Date == b.Date;
        }
        public static bool operator !=(DateTime a, DateTime b)
        {
            return GetDayIndex(a.DayName) != GetDayIndex(b.DayName) && a.Hour != b.Hour && a.Minute != b.Minute
                && a.Year != b.Year && a.Month != b.Month && a.Date != b.Date;
        }
    }
}