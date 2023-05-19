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
                new DateTime(1980, 10,1),
                gender.Male,
                "Alex",
                Race.Half_Blood,
                new LoginData("nima", "123"),
                12356343
            );
            Professor testProfessor = new Professor(
                "doc",
                "oc",
                new DateTime(1980, 1,16),
                gender.Male,
                "Tom",
                Race.Pure_Blood,
                new LoginData("doc", "1234"),
                14643232,
                true
            );
            
            UserManager.AddUsers(testStudent, testProfessor, Dumbledore.Instance);

            //UserManager.RequestSave();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            SaveFileManager.SaveAllData(true);
        }
    }
}