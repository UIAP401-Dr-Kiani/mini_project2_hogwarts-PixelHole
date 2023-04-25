using System;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;

namespace hogwartsBingus.Session
{
    public static class SessionManager
    {
        private static int CurrentUser;

        public static void Login(string username, string password)
        {
            CurrentUser = UserManager.FindWithLogin(new LoginData(username, password));

            if (CurrentUser == -1)
            {
                throw new LoginNotFoundException();
            }
            
            WindowManager.LaunchLandingPageOfType(UserManager.GetUserAtIndex(CurrentUser).AuthType);
        }
    }
}