using System;
using System.Globalization;
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
            CurrentTime = new DateTime(1984, 1, 1, 12, 0, 0);
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
            return CurrentTime.ToString();
        }
    }
}