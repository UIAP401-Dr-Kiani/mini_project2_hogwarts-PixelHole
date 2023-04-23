using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes
{
    public class WeeklySchedule
    {
        public readonly List<StudySubject> Subjects = new List<StudySubject>();

        /*public bool Finilized
        {
            get => Finilized;
            set
            {
                if (!Finilized && value)
                {
                    Finilized = value;
                }
            }
        }*/

        public WeeklySchedule(List<StudySubject> subjects)
        {
            subjects.ForEach(Subjects.Add);
        }

        public void addSubject(StudySubject newSubject)
        {
            // sec check
            //dupe check
            //intersection check
            
            Subjects.Add(newSubject);
        }

        public void removeSubject(StudySubject subject)
        {
            //sec check

            Subjects.Remove(subject);
        }
    }
}