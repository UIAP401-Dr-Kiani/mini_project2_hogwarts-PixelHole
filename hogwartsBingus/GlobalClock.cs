using hogwartsBingus.Base_Classes;

namespace hogwartsBingus
{
    public static class GlobalClock
    {
        public delegate void OnTimeChanged();
        public static event OnTimeChanged TimeChanged;
        
        public static DateTime CurrentTime { get; private set; }

        //public static void InvokeTimeChanged() => TimeChanged.Invoke();
        
        public static void SetTime(DateTime newTime)
        {
            if (newTime == CurrentTime)
            {
                return;
            }
            CurrentTime = newTime;
            TimeChanged.Invoke();
        }
    }
}