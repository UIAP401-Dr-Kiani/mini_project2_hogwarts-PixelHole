namespace hogwartsBingus.Base_Classes
{
    public class Dumbledore : AuthorizedPerson
    {
        public Dumbledore(int id, WeeklySchedule schedule, petType pet, FactionType faction, bool hasBaggage,
            AuthorizationType authType) 
            : base(id, schedule, pet, faction, hasBaggage, authType)
        {
        }
    }
}