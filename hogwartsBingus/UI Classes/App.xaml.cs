using System;
using System.Windows;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Session;
using hogwartsBingus.University;
using hogwartsBingus.University.DataStorage;

namespace hogwartsBingus.UI_Classes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void OnAppStartup(object sender, StartupEventArgs e)
        {
            GlobalClock.SetInitialTime();
            //addTestData();
            //SubjectManager.AddTestSubjects();
            //SaveFileManager.SaveAllData(false);
            SaveFileManager.LoadAllData(false);
            
            SubjectManager.AddTimeCheckToTimeChangeEvent();
            
            
            
            WindowManager.AppStartup();
        }

        private void addTestData()
        {
            Student testStudent = new Student(
                "Kaka",
                "Siah",
                1979,
                gender.Male,
                Race.Half_Blood,
                new LoginData("nima", "123"),
                12356343
            );
            Professor testProfessor = new Professor(
                "doc",
                "oc",
                1953,
                gender.Male,
                Race.Pure_Blood,
                new LoginData("doc", "1234"),
                14643232,
                true
            );
            
            UserManager.AddUsers(testStudent, testProfessor, Dumbledore.Instance);

            UserManager.Users[0].AddMessage(new Message("Who", "cares", "lol0","lolololololoolololololollol"));
            UserManager.Users[0].AddMessage(new Message("Who", "cares", "lol1","lolololololollol"));
            
            UserManager.Users[0].AddTicket(TransportManager.GenerateTicket(
                GlobalClock.CurrentTime.AddMinutes(30), 
                Location.London, Location.HogwartsUniversity));
            
            UserManager.Users[0].AddTicket(TransportManager.GenerateTicket(
                GlobalClock.CurrentTime.AddMinutes(30), 
                Location.HogwartsUniversity, Location.London));

            //UserManager.RequestSave();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            SaveFileManager.SaveAllData(true);
        }
    }
}