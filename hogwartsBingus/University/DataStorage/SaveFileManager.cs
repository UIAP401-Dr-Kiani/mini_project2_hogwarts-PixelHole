using System;
using System.Collections.Generic;
using System.IO;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Base_Classes.SaveReadyPersonnel;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.Factions;
using hogwartsBingus.Session;
using hogwartsBingus.University.DormitoryData;
using hogwartsBingus.University.StudySessionRelactedClasses;
using Newtonsoft.Json;

namespace hogwartsBingus.University.DataStorage
{
    public static class SaveFileManager
    {
        private const string
            StudentsFileName = "students.json",
            ProfessorsFileName = "professors.json",
            DumbledoreFileName = "dumbledore.json",
            StudySubjectsFileName = "studySubjects.json",
            TicketRequestsFileName = "ticketRequests.json",
            FactionsFileName = "factions.json",
            DormitoriesFileName = "Dormitories.json";

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
            WindowManager.SetLoadDialogProgress(20);
            UserManager.RequestLoad();
            WindowManager.SetSaveDialogProgress(40);
            TicketRequestHandler.RequestLoad();
            WindowManager.SetSaveDialogProgress(60);
            FactionManager.RequestLoad();   
            WindowManager.SetLoadDialogProgress(80);
            DormitoryManager.RequestLoad();
            WindowManager.SetLoadDialogProgress(100);
        }
        public static void SaveAllData(bool autoCloseDialog)
        {
            WindowManager.OpenSaveDialog(autoCloseDialog);
            SubjectManager.RequestSave();
            WindowManager.SetSaveDialogProgress(20);
            UserManager.RequestSave();
            WindowManager.SetSaveDialogProgress(40);
            TicketRequestHandler.RequestSave();
            WindowManager.SetSaveDialogProgress(60);
            FactionManager.RequestSave();
            WindowManager.SetSaveDialogProgress(80);
            DormitoryManager.RequestSave();
            WindowManager.SetSaveDialogProgress(100);
        }
        
        
        // Users
        public static void SaveUsers(List<AuthorizedPerson> users)
        {
            List<SaveReadyStudent> students = new List<SaveReadyStudent>();
            List<SaveReadyProfessor> professors = new List<SaveReadyProfessor>();

            foreach (var user in users)
            {
                if (user is Dumbledore) continue;
                if (user is Student student)
                {
                    students.Add(student.ToSaveFormat());
                    continue;
                }
                if (user is Professor professor)
                {
                    professors.Add(professor.ToSaveFormat());
                }
            }
            
            WriteToJsonFile(StudentsFileName, students);
            WriteToJsonFile(ProfessorsFileName, professors);
            WriteToJsonFile(DumbledoreFileName, new List<Dumbledore> {Dumbledore.Instance});
        }
        public static List<AuthorizedPerson> LoadUsers()
        {
            List<AuthorizedPerson> loadedUsers = new List<AuthorizedPerson>();
            List<Dumbledore> dumbledors = ReadFromJsonFile<Dumbledore>(DumbledoreFileName);

            // admin load Error handling
            if (dumbledors.Count > 1) throw new MultipleAdminsLoadedException();
            if (dumbledors.Count == 0) throw new NoAdminsLoadedException();
            
            loadedUsers.Add(dumbledors[0]);
            Dumbledore.Instance = dumbledors[0];
            
            // loading Students
            List<SaveReadyStudent> savedStudents = ReadFromJsonFile<SaveReadyStudent>(StudentsFileName);

            foreach (var savedStudent in savedStudents)
            {
                loadedUsers.Add(savedStudent.ToStudent());
            }

            // loading professors
            List<SaveReadyProfessor> savedProfessors = ReadFromJsonFile<SaveReadyProfessor>(ProfessorsFileName);

            foreach (var professor in savedProfessors)
            {
                loadedUsers.Add(professor.ToProfessor());
            }

            return loadedUsers;
        }

        
        // Study Subjects
        public static void SaveStudySubjects(List<StudySubject> subjects)
        {
            WriteToJsonFile(StudySubjectsFileName, subjects);
        }
        public static List<StudySubject> LoadStudySubjects()
        {
            return ReadFromJsonFile<StudySubject>(StudySubjectsFileName);
        }
        
        
        // Ticket Requests
        public static void SaveTicketRequests(List<TicketRequest> requests)
        {
            WriteToJsonFile(TicketRequestsFileName, requests);
        }
        public static List<TicketRequest> LoadTicketRequests()
        {
            return ReadFromJsonFile<TicketRequest>(TicketRequestsFileName);
        }
        
        
        // Factions
        public static void SaveFactions(List<Faction> factions)
        {
            WriteToJsonFile(FactionsFileName, factions);
        }
        public static List<Faction> LoadFactions()
        {
            return ReadFromJsonFile<Faction>(FactionsFileName);
        }
        
        
        // Dormitories
        public static void SaveDormitories(List<Dormitory> dormitories)
        {
            WriteToJsonFile(DormitoriesFileName, dormitories);
        }
        public static List<Dormitory> LoadDormitories()
        {
            return ReadFromJsonFile<Dormitory>(DormitoriesFileName);
        }

        // General Read/Write Handlers
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