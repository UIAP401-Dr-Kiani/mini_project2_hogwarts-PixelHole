using hogwartsBingus.DataStorage;
using hogwartsBingus.University;

namespace hogwartsBingus.Base_Classes
{
    public class Dumbledore : AuthorizedPerson
    {

        public void AddUser()
        {
            
        }

        public void RemoveUser()
        {
            
        }
        
        public void InvitePerson(int UserIndex)
        {
            DateTime invitationTime = new DateTime(Day.Sunday, 12, 0);
            Message invitation = new Message("invition",invitationTime);
            TrainTicket ticket = TransportManager.GenerateTicket(invitationTime, "London", "Hogwarts");

            UserManager.GetUserAtIndex(UserIndex).AddMessage(invitation);
            UserManager.GetUserAtIndex(UserIndex).AddTicket(ticket);
        }
    }
}