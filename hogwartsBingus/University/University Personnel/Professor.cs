namespace hogwartsBingus.Base_Classes
{
    public class Professor : AuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        public Professor(int id, WeeklySchedule schedule, petType pet, bool hasBaggage, 
            AuthorizationType authType, bool canTeachAtMultipleClasses)
            : base(id, schedule, pet, hasBaggage, authType)
        {
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }
    }
}