using System.Collections.Generic;
using System.IO;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using Newtonsoft.Json;

namespace hogwartsBingus.DataStorage
{
    public static class SaveFileManager
    {
        private const string 
            StudentsFileName = "students.json",
            ProfessorsFileName = "professor.json",
            DumbledoreFileName = "dumbledore.json";
        
        /*
         * in order to save Users, you either have to write a custom json deserializer that can detect different
         * inheritors of the AuthorizedPerson.cs class, otherwise it will load all instances as default base class
         * or you can write to different files and then load from them,
         * i chose the latter
         * enjoy the spaghetti code
         */
        
        public static void SaveUsers(List<AuthorizedPerson> Users)
        {
            List<Student> students = new List<Student>();
            List<Professor> professors = new List<Professor>();

            foreach (var user in Users)
            {
                if (user is Student)
                {
                    students.Add(user as Student);
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
            
            List<Student> students = ReadFromJsonFile<Student>(StudentsFileName);
            List<Professor> professors = ReadFromJsonFile<Professor>(ProfessorsFileName);

            

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

            return loadedData;
        }
    }
}