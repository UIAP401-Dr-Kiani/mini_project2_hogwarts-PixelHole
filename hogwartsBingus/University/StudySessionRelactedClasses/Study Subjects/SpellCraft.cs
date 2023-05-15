using System.Collections.Generic;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.Base_Classes.Study_Subjects
{
    public class SpellCraft : StudySubject
    {
        public SpellCraft(string name, string professorName, List<StudySessionTime> sessions, int capacity, int semesterIndex) : base(name, professorName, sessions, capacity, semesterIndex)
        {
        }
    }
}