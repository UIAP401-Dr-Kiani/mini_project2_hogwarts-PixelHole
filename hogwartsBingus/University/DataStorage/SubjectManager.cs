using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class SubjectManager
    {
        public static readonly List<StudySubject> StudySubjects = new List<StudySubject>();

        public static void AddStudySubject(StudySubject subject)
        {
            if (StudySubjects.Contains(subject)) return;
            StudySubjects.Add(subject);
        }

        public static void RemoveStudySubject(StudySubject subject)
        {
            if (!StudySubjects.Contains(subject)) return;
            StudySubjects.Remove(subject);
        }

        public static void RemoveStudySubjectAt(int index)
        {
            StudySubjects.RemoveAt(index);
        }
        private static void RequestSave()
        {
            
        }

        private static void RequestLoad()
        {
            
        }
    }
}