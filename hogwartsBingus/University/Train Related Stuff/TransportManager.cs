using System;
using System.Collections.Generic;
using System.Windows.Documents;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.Session;

namespace hogwartsBingus.University
{
    public static class TransportManager
    {
        private static Random random = new Random();
        public static void RequestTransport(TrainTicket ticket, AuthorizedPerson passenger)
        {
            passenger.MoveToLocation(ticket.Destination);
            passenger.RemoveTicket(ticket);
        }

        public static TrainTicket GenerateTicket(DateTime moveTime, Location location, Location Destination)
        {
            int trainNumber = (int)random.Next(10000, 99999);
            TrainTicket ticket = new TrainTicket(trainNumber, moveTime, Destination, location);
            return ticket;
        }
    }
}