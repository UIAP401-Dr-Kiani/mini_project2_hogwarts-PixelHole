using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class UserManager
    {
        public static readonly List<AuthorizedPerson> Users = new List<AuthorizedPerson>();

        
        // manipulate Users ...
        
        public static void addUser(AuthorizedPerson newUser)
        {
            // do some security check or somethin idk
            //check if newStudent exists
            
            Users.Add(newUser);
        }
        public static void removeUser(AuthorizedPerson User)
        {
            //security check again
            Users.Remove(User);
        }

        public static void ReplaceUserAt(int index)
        {
            
        }
        
        
        //Find ...

        public static int FindWithLogin(LoginData loginData)
        {
            int result = -1;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Login.Compare(loginData))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        public static int FindWithStudentNumber(int number)
        {
            int result = -1;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].ID == number)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        
        
        // Get ...
        
        public static AuthorizedPerson GetUserAtIndex(int index)
        {
            if (index > Users.Count || index < 0) return null;
            return Users[index];
        }

        public static void RequestSave(){}
        public static void RequestLoad(){}
    }
}