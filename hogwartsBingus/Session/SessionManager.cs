using System;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;

namespace hogwartsBingus.Session
{
    public static class SessionManager
    {
        private static AuthorizedPerson CurrentUser;

        public static void Login(string username, string password)
        {
            CurrentUser = UserManager.FindWithLogin(new LoginData(username, password));

            if (CurrentUser == null)
            {
                throw new LoginNotFoundException();
            }
        }
    }
}