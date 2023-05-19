using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using hogwartsBingus.Execptions;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.Base_Classes
{
    public class WeeklySchedule
    {
        public readonly List<StudySubject> Subjects = new List<StudySubject>();

        public WeeklySchedule(){}

        public WeeklySchedule(List<StudySubject> newSubjects)
        {
            foreach (var subject in newSubjects)
            {
                AddSubject(subject, false);
            }
        }
        public void AddSubject(StudySubject newSubject, bool CheckForIntersection)
        {
            if (Subjects.Contains(newSubject)) return;
            if (CheckForIntersection)
            {
                if (SubjectIntersects(newSubject)) throw new StudySessionIntersectionException();
            }
            
            Subjects.Add(newSubject);
        }

        public void RemoveSubject(StudySubject subject)
        {
            if (!Subjects.Contains(subject)) throw new InstanceNotFoundException();
            Subjects.Remove(subject);
        }

        private bool SubjectIntersects(StudySubject newSubject)
        {
            foreach (var session in newSubject.Sessions)
            {
                if (SessionIntersects(session))
                {
                    return true;
                }
            }

            return false;
        }

        private bool SessionIntersects(StudySessionTime newSession)
        {
            foreach (var subject in Subjects)
            {
                foreach (var session in subject.Sessions.Where(session => newSession.StartTime.Days == session.StartTime.Days))
                {
                    if (session.IntersectsWith(newSession))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}