using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.University;

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

            try
            {
                WindowManager.LaunchLandingPageOfType(CurrentUser.AuthType);
            }
            catch (Exception e)
            {
                throw new AuthorizedPersonTypeNotFoundException();
            }
        }

        public static string[] GetGeneralUserInfo()
        {
            if (CurrentUser is Student)
            {
                return new[]
                {
                    CurrentUser.FullName, CurrentUser.BirthYear.ToString(),
                    Enum.GetName(typeof(gender), CurrentUser.Gender),
                    Enum.GetName(typeof(Race), CurrentUser.Race),
                    CurrentUser.Father?.FullName,
                    CurrentUser.ID.ToString(), Enum.GetName(typeof(petType), CurrentUser.Pet),
                    Enum.GetName(typeof(FactionType), (CurrentUser as Student).Faction),
                    (CurrentUser as Student).DormitoryNumber.ToString(),
                };
            }
            
            if (CurrentUser is Professor)
            {
                return new[]
                {
                    CurrentUser.FullName, CurrentUser.BirthYear.ToString(),
                    Enum.GetName(typeof(gender), CurrentUser.Gender),
                    Enum.GetName(typeof(Race), CurrentUser.Race),
                    CurrentUser.Father?.FullName,
                    CurrentUser.ID.ToString(), Enum.GetName(typeof(petType), CurrentUser.Pet),
                };
            }

            if (CurrentUser is Dumbledore)
            {
                return new []{"Albus Dumbledore"};
            }

            throw new AuthorizedPersonTypeNotFoundException("Authorization type not correct");
        }

        public static List<Message> GetMessageList() => CurrentUser.Messages;
        public static List<TrainTicket> GetTickets() => CurrentUser.Tickets;
        public static AuthorizationType UserType => CurrentUser.AuthType;
        public static Location UserLocation => CurrentUser.CurrentLocation;

        public static void RequestTransport(TrainTicket ticket)
        {
            TransportManager.RequestTransport(ticket, CurrentUser);
        }
    }
}