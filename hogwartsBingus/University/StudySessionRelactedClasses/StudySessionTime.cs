using System;

namespace hogwartsBingus.Base_Classes
{
    public class StudySessionTime
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public StudySessionTime(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public bool IntersectsWith(StudySessionTime studySession)
        {
            if (studySession.StartTime.DayOfWeek != StartTime.DayOfWeek) return false;

            if (studySession.StartTime > StartTime && studySession.StartTime < EndTime) return true;
            if (studySession.EndTime > StartTime && studySession.EndTime < EndTime) return true;

            return false;
        }
    }
}