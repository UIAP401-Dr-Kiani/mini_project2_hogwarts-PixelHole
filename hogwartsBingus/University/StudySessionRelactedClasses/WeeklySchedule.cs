using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using hogwartsBingus.Execptions;

namespace hogwartsBingus.Base_Classes
{
    public class WeeklySchedule
    {
        public readonly List<StudySubject> Subjects = new List<StudySubject>();

        public void addSubject(StudySubject newSubject)
        {
            if (StudySessionIntersects(newSubject)) throw new StudySessionIntersectionException();

            Subjects.Add(newSubject);
        }

        public void removeSubject(StudySubject subject)
        {
            //sec check

            Subjects.Remove(subject);
        }

        private bool StudySessionIntersects(StudySubject newSubject)
        {
            foreach (var session in newSubject.sessions)
            {
                foreach (var sessionsInDay in GetSessionTimesInDay(session.StartTime.Day))
                {
                    if (session.IntersectsWith(sessionsInDay)) return true;
                }
            }

            return false;
        }

        private List<StudySessionTime> GetSessionTimesInDay(Day day)
        {
            List<StudySessionTime> times = new List<StudySessionTime>();
            
            foreach (var subject in Subjects)
            {
                foreach (var session in subject.sessions)
                {
                    if (session.StartTime.Day == day)
                    {
                        times.Add(session);
                    }
                }
            }

            return times;
        }
    }
}