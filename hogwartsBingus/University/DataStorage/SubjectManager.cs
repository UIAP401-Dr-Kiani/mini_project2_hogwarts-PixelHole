using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.University.DataStorage;
using hogwartsBingus.University.Excercies;
using hogwartsBingus.University.StudySessionRelactedClasses;

namespace hogwartsBingus.DataStorage
{
    public static class SubjectManager
    {
        private static List<StudySubject> StudySubjects;

        public delegate void OnSubjectsChanged();
        
        public static event OnSubjectsChanged SubjectsChanged;
        
        public static void AddTestSubjects()
        {
            AddStudySubject(new StudySubject("Test1", UserManager.GetUserAtIndex(1).FullName, 
                new List<StudySessionTime>()
            {
                new StudySessionTime(
                    new TimeSpan(3, 8, 0,0),
                    new TimeSpan(0, 2,0,0)
                    ),
                new StudySessionTime(
                new TimeSpan(4, 8, 0,0),
                new TimeSpan(0, 2,0,0)
                ),
                new StudySessionTime(
                new TimeSpan(3, 14, 0,0),
                new TimeSpan(0, 2,0,0)
                )
            },
                12,
                1));
            
            AddStudySubject(new StudySubject("Test2", UserManager.GetUserAtIndex(1).FullName, 
                new List<StudySessionTime>()
                {
                    new StudySessionTime(
                        new TimeSpan(3, 12, 0,0),
                        new TimeSpan(0, 2,0,0)
                    ),
                    new StudySessionTime(
                        new TimeSpan(4, 12, 0,0),
                        new TimeSpan(0, 2,0,0)
                    ),
                    new StudySessionTime(
                        new TimeSpan(5, 10, 0,0),
                        new TimeSpan(0, 2,0,0)
                    )
                },
                12,
                1));
        }

        public static void AddTimeCheckToTimeChangeEvent()
        {
            GlobalClock.TimeChanged += CheckForExerciseExpirations;
        }


        // get functions
        public static List<StudySubject> GetAllSubjects() => StudySubjects;
        public static StudySubject GetSubjectAt(int index)
        {
            if (index > StudySubjects.Count || index < 0) throw new IndexOutOfRangeException();

            return StudySubjects[index];
        }
        public static StudySubject FindSubjectByName(string name)
        {
            foreach (var subject in StudySubjects)
            {
                if (subject.Name == name) return subject;
            }

            throw new InstanceNotFoundException();
        }
        public static List<StudySubject> FindSubjectsWithProfessor(string professorName)
        {
            List<StudySubject> subjects = new List<StudySubject>();
            
            if (StudySubjects == null) return subjects;

            foreach (var subject in StudySubjects.Where(subject => subject.ProfessorName == professorName))
            {
                subjects.Add(subject);
            }

            return subjects;
        }
        
        // subject list manipulation
        public static void AddStudySubject(StudySubject subject)
        {
            if (StudySubjects.Contains(subject)) return;
            StudySubjects.Add(subject);
            SubjectsChanged?.Invoke();
        }
        public static void RemoveStudySubject(StudySubject subject)
        {
            if (!StudySubjects.Contains(subject)) return;
            StudySubjects.Remove(subject);
            SubjectsChanged?.Invoke();
        }
        public static void RemoveStudySubjectAt(int index)
        {
            StudySubjects.RemoveAt(index);
            SubjectsChanged?.Invoke();
        }
        
        
        // check for Exercise Expiration
        public static void CheckForExerciseExpirations()
        {
            foreach (var subject in StudySubjects)
            {
                foreach (var exercise in subject.Exercises)
                {
                    if (GlobalClock.CurrentTime > exercise.DeadLine)
                    {
                        subject.RemoveExercise(exercise);
                    }
                }
            }
        }
        
        
        // Save and Load Requests
        public static void RequestSave()
        {
            SaveFileManager.SaveStudySubjects(StudySubjects);
        }
        public static void RequestLoad()
        {
            StudySubjects = SaveFileManager.LoadStudySubjects();
        }
    }
}