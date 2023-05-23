using System;
using System.Collections.Generic;
using System.Linq;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.University.Excercies;
using Newtonsoft.Json;

namespace hogwartsBingus.University.StudySessionRelactedClasses
{
    public class StudySubject
    {
        public string Name { get; }
        public readonly List<StudySessionTime> Sessions = new List<StudySessionTime>();
        public readonly List<Exercise> Exercises = new List<Exercise>();
        public int Capacity { get; }
        public int StudentCount { get; }
        public int SemesterIndex { get; }
        
        public string ProfessorName { get; protected set; }
        
        public StudySubject(){}
        public StudySubject(string name,
            string professorName,
            List<StudySessionTime> sessions,
            int capacity,
            int semesterIndex)
        {
            Name = name;
            ProfessorName = professorName;
            Sessions = sessions;
            Capacity = capacity;
            SemesterIndex = semesterIndex;
        }
        
        [JsonConstructor]
        public StudySubject(string name, string professorName, List<StudySessionTime> sessions, List<Exercise> exercises,
            int capacity, int semesterIndex)
        {
            Name = name;
            ProfessorName = professorName;
            Sessions = sessions;
            Exercises = exercises;
            Capacity = capacity;
            SemesterIndex = semesterIndex;
        }

        
        // Session management
        public void AddSession(StudySessionTime sessionTime)
        {
            if (Sessions.Contains(sessionTime)) return;

            if (Sessions.Any(session => session.IntersectsWith(sessionTime)))
            {
                return;
            }
            
            Sessions.Add(sessionTime);
        }
        public void RemoveSession(StudySessionTime sessionTime)
        {
            Sessions.Remove(sessionTime);
        }
        public void EditSession(StudySessionTime oldSession, StudySessionTime newSession)
        {
            if (!Sessions.Contains(oldSession)) return;

            Sessions[Sessions.IndexOf(oldSession)] = newSession;
        }
        public StudySessionTime FindSessionWithString(string stringFormat)
        {
            return Sessions.Find(session => session.ToString() == stringFormat);
        }
        
        
        // Exercise management
        public void AddExercise(Exercise exercise)
        {
            if (Exercises.Contains(exercise)) return;
            Exercises.Add(exercise);
        }
        public void RemoveExerciseByName(string name)
        {
            RemoveExercise(GetExerciseWithName(name));
        }
        public void RemoveExercise(Exercise exercise)
        {
            if (!Exercises.Contains(exercise)) return;
            Exercises.Remove(exercise);
        }
        public void EditExercise(Exercise oldExercise, Exercise newExercise)
        {
            if (!Exercises.Contains(oldExercise)) return;
            Exercises[Exercises.IndexOf(oldExercise)] = newExercise;
        }
        public Exercise GetExerciseAt(int index) => Exercises[index];
        public Exercise GetExerciseWithName(string name) => Exercises.Find(exercise => exercise.Name == name);

        public override string ToString()
        {
            return Name;
        }
        protected bool Equals(StudySubject other)
        {
            return Equals(Sessions, other.Sessions) && Name == other.Name && Capacity == other.Capacity && StudentCount == other.StudentCount && SemesterIndex == other.SemesterIndex;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Sessions != null ? Sessions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Capacity;
                hashCode = (hashCode * 397) ^ StudentCount;
                hashCode = (hashCode * 397) ^ SemesterIndex;
                return hashCode;
            }
        }
    }
}