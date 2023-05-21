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
        // ReSharper disable once InconsistentNaming
        private static AuthorizedPerson CurrentUser;
        
        public static void Login(string username, string password)
        {
            CurrentUser = UserManager.GetUserAtIndex(UserManager.FindWithLogin(new LoginData(username, password)));

            if (CurrentUser == null)
            {
                throw new LoginNotFoundException();
            }

            WindowManager.LaunchLandingPage();
        }
        public static void Logout()
        {
            CurrentUser = null;
            WindowManager.LaunchLoginPage();
        }

        
        // Get User Data
        public static string[] GetGeneralUserInfo()
        {
            return UserManager.GetGeneralUserInfoAt(UserManager.FindWithName(CurrentUser.FullName));
        }
        public static FactionType? GetUserFaction() => (CurrentUser as Student)?.Faction;
        public static List<Message> GetMessageList() => CurrentUser.Messages;
        public static Message GetMessageWithTitle(string title) => CurrentUser.FindMessageWithTitle(title);
        public static List<TrainTicket> GetTickets() => CurrentUser.Tickets;
        public static AuthorizationType GetUserType() => CurrentUser.AuthType;
        public static Location GetUserLocation() => CurrentUser.CurrentLocation;
        public static WeeklySchedule GetWeeklySchedule() => CurrentUser.Schedule;
        public static int GetUserID() => CurrentUser.ID;
        public static int? GetBedNumber() => (CurrentUser as Student)?.DormitoryNumber;
        public static bool? GetCanTeachAtMultipleLocations() => (CurrentUser as Professor)?.CanTeachAtMultipleClasses;
        
        // Set User Data
        public static void RequestTransport(TrainTicket ticket)
        {
            TransportManager.RequestTransport(ticket, CurrentUser);
        }
        public static void RequestSetFaction(FactionType factionType)
        {
            if (!(CurrentUser is Student student)) throw new InvalidAuthorizationTypeException();
            student.SetFaction(factionType);
        }
        public static void RequestSetBedNumber(int bedNumber)
        {
            if (!(CurrentUser is Student student)) throw new InvalidAuthorizationTypeException();
            student.SetBedNumber(bedNumber);
        }
        public static void RequestRemoveMessage(Message message)
        {
            CurrentUser.RemoveMessage(message);
        }
        public static void UpdateWeeklySchedule(WeeklySchedule schedule)
        {
            CurrentUser.SetWeeklySchedule(schedule);
        }
    }
}