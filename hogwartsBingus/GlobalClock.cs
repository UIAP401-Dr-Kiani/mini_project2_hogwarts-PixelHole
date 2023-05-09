using System.Timers;
using hogwartsBingus.Base_Classes;
using Timer = System.Timers.Timer;

namespace hogwartsBingus
{
    public static class GlobalClock
    {
        public delegate void OnTimeChanged();
        public static event OnTimeChanged TimeChanged;
        public static DateTime CurrentTime { get; private set; }

        //public static void InvokeTimeChanged() => TimeChanged.Invoke();

        public static void SetInitialTime()
        {
            CurrentTime = new DateTime(1984, 1, 1, Day.Saturday, 0, 0);
        }
        
        public static void SetTime(DateTime newTime)
        {
            if (newTime == CurrentTime)
            {
                return;
            }
            CurrentTime = newTime;
            TimeChanged?.Invoke();
        }

        public static string GetCurrentTimeString()
        {
            return $"{CurrentTime.Year}/{CurrentTime.Month}/{CurrentTime.Date} {CurrentTime.DayName} " +
                   $"{CurrentTime.Hour:D2}:{CurrentTime.Minute:D2}";
        }
    }
}