using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.University.Excercies;
using Newtonsoft.Json;

namespace hogwartsBingus.University.StudySessionRelactedClasses
{
    public class StudySubject
    {
        public string Name { get; }
        public readonly List<StudySessionTime> Sessions;
        public readonly List<Exercise> Exercises = new List<Exercise>();
        public int Capacity { get; }
        public int StudentCount { get; }
        public int SemesterIndex { get; }
        
        public Professor Professor { get; protected set; }
        
        public StudySubject(string name,
            Professor professor,
            List<StudySessionTime> sessions,
            int capacity,
            int semesterIndex)
        {
            Name = name;
            Professor = professor;
            Sessions = sessions;
            Capacity = capacity;
            SemesterIndex = semesterIndex;
        }
        
        [JsonConstructor]
        public StudySubject(string name, Professor professor, List<StudySessionTime> sessions, List<Exercise> exercises,
            int capacity, int semesterIndex)
        {
            Name = name;
            Professor = professor;
            Sessions = sessions;
            Exercises = exercises;
            Capacity = capacity;
            SemesterIndex = semesterIndex;
        }

        public void AddExercise(Exercise exercise)
        {
            if (Exercises.Contains(exercise)) return;
            Exercises.Add(exercise);
        }
        public void RemoveExercise(Exercise exercise)
        {
            if (!Exercises.Contains(exercise)) return;
            Exercises.Remove(exercise);
        }
        public Exercise GetExerciseAt(int index) => Exercises[index];
        public Exercise GetExerciseWithName(string name) => Exercises.Find(exercise => exercise.Name == name);
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