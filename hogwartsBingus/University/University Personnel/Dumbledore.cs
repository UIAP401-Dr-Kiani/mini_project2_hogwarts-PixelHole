using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.University;

namespace hogwartsBingus.Base_Classes
{
    public sealed class Dumbledore : AuthorizedPerson
    {
        public static readonly Dumbledore Instance = new Dumbledore();
        public void AddUser()
        {
            
        }

        public void RemoveUser()
        {
            
        }
        
        public void InvitePerson(int UserIndex)
        {
            // this time is for test purposes, remove in later commits
            DateTime invitationTime = new DateTime(Day.Sunday, 12, 0);
            
            Message invitation = new Message("invition",invitationTime);
            
            TrainTicket ticket = TransportManager.GenerateTicket(invitationTime,
                Location.London, Location.HogwartsStation);

            Student newStudent = UserManager.GetUserAtIndex(UserIndex) as Student;

            if (newStudent != null)
            {
                newStudent.AddMessage(invitation);
                newStudent.AddTicket(ticket);
            }
            else
            {
                throw new AuthorizedPersonNotStudentException();
            }
        }
    }
}