using System;
using System.Collections.Generic;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using DateTime = hogwartsBingus.Base_Classes.DateTime;

namespace hogwartsBingus.University
{
    public class Train
    {
        private List<int> passengers = new List<int>();
        public DateTime MoveTime { get; protected set; }
        public DateTime StopTime { get; protected set; }
        
        public int TrainNumber { get; protected set; }

        public string Location { get; protected set; }
        public string Destination { get; protected set; }

        public Train(DateTime moveTime, string location, string destination)
        {
            MoveTime = moveTime;
            Location = location;
            Destination = destination;
        }

        public void AddPassenger(int passenger)
        {
            if (passengers.IndexOf(passenger) != -1)
            {
                return;
            }
            passengers.Add(passenger);
        }

        public void RemovePassenger(int passenger)
        {
            // checks
            passengers.Remove(passenger);
        }

        public void Move()
        {
            foreach (var passenger in passengers)
            {
                AuthorizedPerson person = UserManager.GetUserAtIndex(passenger);
                person.MoveToLocation(Destination);
                person.RemoveTicketForTrain(TrainNumber, MoveTime);
            }

            Location = Destination;
        }
    }
}