using System;
using System.Collections.Generic;
using System.Windows.Documents;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;
using DateTime = hogwartsBingus.Base_Classes.DateTime;

namespace hogwartsBingus.University
{
    public static class TransportManager
    {
        private static Random random = new Random();
        public static void RequestTransport(TrainTicket ticket, AuthorizedPerson passenger)
        {
            if (GlobalClock.CurrentTime < ticket.MoveTime && 
                GlobalClock.CurrentTime > (ticket.MoveTime - new DateTime(Day.None, 1, 0)))
            {
                passenger.MoveToLocation(ticket.Destination);
                passenger.RemoveTicket(ticket);
            }
            else
            {
                TrainTicket newTicket = GenerateTicket(ticket.MoveTime + new DateTime(Day.None, 2, 0)
                    , ticket.Location, ticket.Destination);
                passenger.RemoveTicket(ticket);
                passenger.AddTicket(newTicket);
            }
        }

        public static TrainTicket GenerateTicket(DateTime moveTime, Location location, Location Destination)
        {
            int trainNumber = (int)random.Next(10000, 99999);
            TrainTicket ticket = new TrainTicket(trainNumber, moveTime, Destination, location);
            return ticket;
        }
    }
}