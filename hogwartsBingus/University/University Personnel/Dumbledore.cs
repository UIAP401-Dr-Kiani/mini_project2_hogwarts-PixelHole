using System.Collections.Generic;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.University;

namespace hogwartsBingus.Base_Classes
{
    public sealed class Dumbledore : AuthorizedPerson
    {
        public static readonly Dumbledore Instance = new Dumbledore(
            "Albus",
            "Dumbledore",
            1881,
            gender.Male,
            Race.Half_Blood,
            new LoginData("admin", "admin"),
            1
            );

        private static readonly List<TicketRequest> TicketRequests = new List<TicketRequest>();
        
        /*
         Needs to be Public so it can be serialized by the Json convertor class. cant find another solution
         so it will be this for now
         */
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Dumbledore(string firstName,
            string lastName,
            int birthYear,
            gender gender,
            Race race,
            LoginData login,
            int id)
            : base(firstName, lastName, birthYear, gender, race, login, id)
        {
            AuthType = AuthorizationType.Dumbledore;
            FullName = "Albus Dumbledore";
        }

        public void AddTicketRequest(TicketRequest request)
        {
            if (TicketRequests.Contains(request)) throw new TicketAlreadyRequestedException();
            TicketRequests.Add(request);
        }

        public void RemoveTicketRequest(TicketRequest request)
        {
            if (!TicketRequests.Contains(request)) return;
            TicketRequests.Remove(request);
        }
        
        public void InvitePerson(int UserIndex)
        {
            // this time is for test purposes, remove in later commits
            DateTime invitationTime = new DateTime(Day.Sunday, 12, 0);
            
            Student newStudent = UserManager.GetUserAtIndex(UserIndex) as Student;
            
            Message invitation = new Message(this.FullName, newStudent.FullName, "Invitation", "You're invited!");
            
            TrainTicket ticket = TransportManager.GenerateTicket(invitationTime,
                Location.London, Location.HogwartsStation);

            if (newStudent != null)
            {
                newStudent.AddMessage(invitation);
                newStudent.AddTicket(ticket);
            }
            else
            {
                throw new AuthorizedPersonTypeNotFoundException();
            }
        }
    }
}