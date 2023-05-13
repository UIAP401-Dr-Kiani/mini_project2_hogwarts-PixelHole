using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Base_Classes.SaveReadyPersonnel;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;
using hogwartsBingus.University.StudySessionRelactedClasses;
using Newtonsoft.Json;

namespace hogwartsBingus.DataStorage
{
    public static class SaveFileManager
    {
        private const string
            StudentsFileName = "students.json",
            ProfessorsFileName = "professor.json",
            DumbledoreFileName = "dumbledore.json",
            StudySubjectsFileName = "studySubjects.json";
        
        /*
         * in order to save Users, you either have to write a custom json deserializer that can detect different
         * inheritors of the AuthorizedPerson.cs class, otherwise it will load all instances as default base class
         * or you can write to different files and then load from them,
         * i chose the latter
         * enjoy the spaghetti code
         */
        public static void LoadAllData(bool autoCloseDialog)
        {
            WindowManager.OpenLoadDialog(autoCloseDialog);
            SubjectManager.RequestLoad();
            WindowManager.SetLoadDialogProgress(50);
            UserManager.RequestLoad();
            WindowManager.SetLoadDialogProgress(100);
        }
        public static void SaveAllData(bool autoCloseDialog)
        {
            WindowManager.OpenSaveDialog(autoCloseDialog);
            SubjectManager.RequestSave();
            WindowManager.SetSaveDialogProgress(50);
            UserManager.RequestSave();
            WindowManager.SetSaveDialogProgress(100);
        }
        public static void SaveUsers(List<AuthorizedPerson> Users)
        {
            List<SaveReadyStudent> students = new List<SaveReadyStudent>();
            List<Professor> professors = new List<Professor>();

            foreach (var user in Users)
            {
                if (user is Student)
                {
                    students.Add((user as Student).ToSaveFormat());
                    continue;
                }

                if (user is Professor)
                {
                    professors.Add(user as Professor);
                }
            }
            
            WriteToJsonFile(StudentsFileName, students);
            WriteToJsonFile(ProfessorsFileName, professors);
            WriteToJsonFile(DumbledoreFileName, new List<Dumbledore> {Dumbledore.Instance});
        }
        public static List<AuthorizedPerson> LoadUsers()
        {
            List<AuthorizedPerson> loadedUsers = new List<AuthorizedPerson>();
            
            List<Dumbledore> dumbledores = ReadFromJsonFile<Dumbledore>(DumbledoreFileName);

            if (dumbledores.Count > 1) throw new MultipleAdminsLoadedException();

            if (dumbledores.Count == 0) throw new NoAdminsLoadedException();
            
            List<SaveReadyStudent> savedStudents = ReadFromJsonFile<SaveReadyStudent>(StudentsFileName);
            List<Student> students = new List<Student>();

            foreach (var savedStudent in savedStudents)
            {
                students.Add(savedStudent.ToStudent());
            }
            
            List<Professor> professors = ReadFromJsonFile<Professor>(ProfessorsFileName);

            /* the weekly schedule loaded from this method is in a separate space in memory
             * so when comparing the contents (aka subjects) to ones loaded from another file
             * it will not see them as equal. so in order to make them equal i have to reference
             * it to the subjects that where loaded from file
             * this is done by updating the WeeklySchedule instance of every student
             */
            
            foreach (var student in students)
            {
                WeeklySchedule memorySchedule = new WeeklySchedule();
                if (student.Schedule == null) continue;
                
                foreach (var subject in student.Schedule.Subjects)
                {
                    memorySchedule.AddSubject(SubjectManager.GetSubjectByName(subject.Name));
                }

                student.SetWeeklySchedule(memorySchedule);
            }

            foreach (var student in students)
            {
                loadedUsers.Add(student);
            }

            foreach (var professor in professors)
            {
                loadedUsers.Add(professor);
            }
            
            loadedUsers.Add(dumbledores[0]);

            return loadedUsers;
        }

        public static void SaveStudySubjects(List<StudySubject> subjects)
        {
            WriteToJsonFile(StudySubjectsFileName, subjects);
        }

        public static List<StudySubject> LoadStudySubjects()
        {
            return ReadFromJsonFile<StudySubject>(StudySubjectsFileName);
        }
        private static void WriteToJsonFile<T>(string fileName, List<T> Data)
        {
            StreamWriter writer = new StreamWriter(fileName);
            
            writer.Write(JsonConvert.SerializeObject(Data, Formatting.Indented));
            
            writer.Close();
        }
        private static List<T> ReadFromJsonFile<T>(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            var loadedData = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
            
            reader.Close();

            return loadedData;
        }
    }
}