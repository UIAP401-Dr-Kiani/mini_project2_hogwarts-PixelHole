using System.Collections.Generic;
using System.IO;

namespace hogwartsBingus.Base_Classes
{
    public class StudySubject
    {
        public string name { get; protected set; }
        public readonly List<SessionTime> sessions = new List<SessionTime>();
        public int Capacity { get; protected set; }
        public int StudentCount { get; protected set; }
        public int SemesterIndex { get; protected set; }
    }
}