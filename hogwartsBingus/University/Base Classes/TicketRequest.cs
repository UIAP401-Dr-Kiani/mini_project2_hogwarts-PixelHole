using System;

namespace hogwartsBingus.Base_Classes
{
    public struct TicketRequest
    {
        public string Requester { get; private set; }
        public Location Location { get; private set; }
        public Location Destination { get; private set; }
        public DateTime Time { get; private set; }

        public TicketRequest(string requester, Location location, Location destination, DateTime time)
        {
            Requester = requester;
            Location = location;
            Destination = destination;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Requester} : {Location} → {Destination}";
        }
    }
}