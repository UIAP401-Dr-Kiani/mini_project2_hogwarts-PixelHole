using System.Collections.Generic;
using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.University
{
    public class Train
    {
        private List<AuthorizedPerson> passengers = new List<AuthorizedPerson>();

        public DateTime MoveTime { get; protected set; }
        public DateTime StopTime { get; protected set; }

        public void AddPassenger(AuthorizedPerson passenger)
        {
            // do some checks i guess
            passengers.Add(passenger);
        }

        public void RemovePassenger(AuthorizedPerson passenger)
        {
            // checks
            passengers.Remove(passenger);
        }
    }
}