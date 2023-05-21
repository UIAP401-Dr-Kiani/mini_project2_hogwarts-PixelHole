using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using hogwartsBingus.University.DataStorage;
using hogwartsBingus.University.StudySessionRelactedClasses;

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
        public static void RemoveSubjectFromUsers(StudySubject subject)
        {
            foreach (var user in Users)
            {
                try
                {
                    user.Schedule.RemoveSubject(subject);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
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
        public static string[] GetGeneralUserInfoAt(int index)
        {
            AuthorizedPerson user = GetUserAtIndex(index);

            switch (user.AuthType)
            {
                case AuthorizationType.Student :
                    Student student = user as Student;
                    
                    return new[]
                    {
                        student.FullName, student.BirthYear.ToString(),
                        Enum.GetName(typeof(gender), student.Gender),
                        Enum.GetName(typeof(Race), student.Race),
                        student.Father,
                        student.ID.ToString(), Enum.GetName(typeof(petType), student.Pet),
                        Enum.GetName(typeof(FactionType), student.Faction),
                        student.DormitoryNumber.ToString(), student.CurrentLocation.ToString()
                    };
                
                case AuthorizationType.Professor :
                    return new[]
                    {
                        user.FullName, user.BirthYear.ToString(), user.Gender.ToString(), user.Race.ToString(),
                        user.Father, user.ID.ToString(), user.Pet.ToString(),
                        (user as Professor)?.CanTeachAtMultipleClasses.ToString(), user.CurrentLocation.ToString()
                    };
                
                case AuthorizationType.Dumbledore :
                    
                    return new[]
                    {
                        user.FullName, user.BirthYear.ToString(),
                        Enum.GetName(typeof(gender), user.Gender),
                        Enum.GetName(typeof(Race), user.Race),
                        user.Father,
                        user.ID.ToString(), Enum.GetName(typeof(petType), user.Pet),
                    };
                
                default :
                    throw new InvalidAuthorizationTypeException("Authorization type not correct");
            }
        }
        public static AuthorizationType GetAuthTypeAt(int index)
        {
            if (index < 0 || index > Users.Count) throw new IndexOutOfRangeException();
            return Users[index].AuthType;
        }

        // Saving and loading
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