using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class UserManager
    {
        public static readonly List<AuthorizedPerson> Users = new List<AuthorizedPerson>();

        public static void addUser(Student newUser)
        {
            // do some security check or somethin idk
            //check if newStudent exists
            
            Users.Add(newUser);
        }

        public static void removeUser(Student User)
        {
            //security check again
            Users.Remove(User);
        }
        
        //Find ...

        public static AuthorizedPerson FindWithLogin(LoginData loginData)
        {
            AuthorizedPerson result = null;
            
            foreach (var user in Users)
            {
                if (user.Login == loginData)
                {
                    result = user;
                    break;
                }
            }

            return result;
        }
        public static AuthorizedPerson FindWithStudentNumber(int number)
        {
            AuthorizedPerson result = null;
            
            foreach (var user in Users)
            {
                if (user.ID == number)
                {
                    result = user;
                    break;
                }
            }

            return result;
        }

        public static void RequestSave(){}
        public static void RequestLoad(){}
    }
}