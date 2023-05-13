using System;

namespace hogwartsBingus.Base_Classes
{
    public class StudySessionTime
    {
        public TimeSpan StartTime { get; private set; }
        public TimeSpan Duration { get; private set; }

        public StudySessionTime(TimeSpan startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        public bool IntersectsWith(StudySessionTime newSession)
        {
            newSession.StartTime.Add(new TimeSpan(0, 0, 1, 0));
            if ((newSession.StartTime > StartTime && 
                 newSession.StartTime < StartTime + Duration)
                ||
                (newSession.StartTime + newSession.Duration > StartTime &&
                 newSession.StartTime + newSession.Duration < StartTime + Duration))
            {
                return true;
            }

            return false;
        }

        protected bool Equals(StudySessionTime other)
        {
            return StartTime.Equals(other.StartTime) && Duration.Equals(other.Duration);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StudySessionTime)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StartTime.GetHashCode() * 397) ^ Duration.GetHashCode();
            }
        }
    }
}