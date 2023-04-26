using hogwartsBingus.DataStorage;
using hogwartsBingus.University;

namespace hogwartsBingus.Base_Classes
{
    public class Dumbledore : AuthorizedPerson
    {
        public Dumbledore(int id, WeeklySchedule schedule, petType pet, FactionType faction, bool hasBaggage,
            AuthorizationType authType) 
            : base(id, schedule, pet, faction, hasBaggage, authType)
        {
        }

        public void AddUser()
        {
            
        }

        public void RemoveUser()
        {
            
        }
        
        public void InvitePerson(int UserIndex)
        {
            DateTime invitationTime = new DateTime(Day.Sunday, 12, 0);
            Message invitaion = new Message("invition",invitationTime);
            TrainTicket ticket = TrainManager.FindTicket("London", "Hogwarts");

            if (ticket == null)
            {
                TrainManager.AddTrain(invitationTime, "London", "Hogwarts");
                ticket = TrainManager.FindTicket("London", "Hogwarts");
            }
            
            UserManager.GetUserAtIndex(UserIndex).AddMessage(invitaion);
            UserManager.GetUserAtIndex(UserIndex).AddTicket(ticket);
        }
    }
}