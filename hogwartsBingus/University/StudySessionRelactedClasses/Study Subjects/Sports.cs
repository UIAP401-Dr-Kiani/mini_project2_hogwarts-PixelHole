using System.Collections.Generic;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.Base_Classes.Study_Subjects
{
    public class Sports : StudySubject
    {
        public Sports(string name, string professor, List<StudySessionTime> sessions, int capacity, int semesterIndex) : base(name, professor, sessions, capacity, semesterIndex)
        {
        }
    }
}