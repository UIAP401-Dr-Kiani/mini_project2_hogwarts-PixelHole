using System.Collections.Generic;
using System.IO;
using System.Text;
using hogwartsBingus.Base_Classes;
using Newtonsoft.Json;

namespace hogwartsBingus.DataStorage
{
    public static class UserManager
    {
        public static readonly List<AuthorizedPerson> Users = new List<AuthorizedPerson>();

        
        // manipulate Users ...
        
        public static void AddUser(AuthorizedPerson newUser)
        {
            if (Users.Contains(newUser)) return;
            Users.Add(newUser);
        }

        public static void AddUsers(params AuthorizedPerson[] users)
        {
            foreach (var user in users)
            {
                AddUser(user);
            }
        }
        public static void RemoveUser(AuthorizedPerson User)
        {
            if (!Users.Contains(User)) return;
            Users.Remove(User);
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

        public static int FindDumbledore()
        {
            return Users.IndexOf(Dumbledore.Instance);
        }
        public static int FindWithName(string name)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].FullName.ToLower() == name.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }
        public static int FindWithID(int number)
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

        public static FactionType? GetFactionAt(int index) => (Users[index] as Student)?.Faction;

        public static void RequestSave()
        {
            SaveFileManager.SaveUsers(Users);
        }

        public static void RequestLoad()
        {
            List<AuthorizedPerson> loadedUsers = SaveFileManager.LoadUsers();
            foreach (var loadedUser in loadedUsers)
            {
                AddUser(loadedUser);
            }
        }
    }
}