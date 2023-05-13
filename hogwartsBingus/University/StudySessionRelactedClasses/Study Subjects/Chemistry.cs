using System.Collections.Generic;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.Base_Classes.Study_Subjects
{
    public class Chemistry : StudySubject
    {
        public Chemistry(string name, Professor professor, List<StudySessionTime> sessions, int capacity, int semesterIndex) : base(name, professor, sessions, capacity, semesterIndex)
        {
        }
    }
}