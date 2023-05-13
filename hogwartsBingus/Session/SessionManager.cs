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

            WindowManager.LaunchLandingPageOfType(CurrentUser.AuthType);
        }

        public static string[] GetGeneralUserInfo()
        {
            if (CurrentUser is Student student)
            {
                return new[]
                {
                    student.FullName, student.BirthYear.ToString(),
                    Enum.GetName(typeof(gender), student.Gender),
                    Enum.GetName(typeof(Race), student.Race),
                    student.Father?.FullName,
                    student.ID.ToString(), Enum.GetName(typeof(petType), student.Pet),
                    Enum.GetName(typeof(FactionType), student.Faction),
                    student.DormitoryNumber.ToString(),
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

            throw new InvalidAuthorizationTypeException("Authorization type not correct");
        }

        public static FactionType? GetUserFaction() => (CurrentUser as Student)?.Faction;
        public static List<Message> GetMessageList() => CurrentUser.Messages;
        public static List<TrainTicket> GetTickets() => CurrentUser.Tickets;
        public static AuthorizationType GetUserType() => CurrentUser.AuthType;
        public static Location GetUserLocation() => CurrentUser.CurrentLocation;
        public static WeeklySchedule GetWeeklySchedule() => (CurrentUser as Student)?.Schedule;
        public static int GetUserID() => CurrentUser.ID;
        public static void RequestTransport(TrainTicket ticket)
        {
            TransportManager.RequestTransport(ticket, CurrentUser);
        }
        public static void AttemptToSetFaction(FactionType factionType)
        {
            if (!(CurrentUser is Student student)) throw new InvalidAuthorizationTypeException();
            student.SetFaction(factionType);
        }
        public static void AttemptToSetBedNumber(int bedNumber)
        {
            if (!(CurrentUser is Student student)) throw new InvalidAuthorizationTypeException();
            student.SetBedNumber(bedNumber);
        }
        public static void UpdateWeeklySchedule(WeeklySchedule schedule)
        {
            (CurrentUser as Student)?.SetWeeklySchedule(schedule);
        }
    }
}