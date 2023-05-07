using System;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using DateTime = hogwartsBingus.Base_Classes.DateTime;

namespace hogwartsBingus.Session
{
    public static class SessionManager
    {
        private static AuthorizedPerson CurrentUser;
        
        public static void Login(string username, string password)
        {
            CurrentUser = UserManager.GetUserAtIndex(UserManager.FindWithLogin(new LoginData(username, password)));

            if (CurrentUser == null)
            {
                throw new LoginNotFoundException();
            }

            if (CurrentUser == null) return;
            WindowManager.LaunchLandingPageOfType(CurrentUser.AuthType);
        }
    }
}