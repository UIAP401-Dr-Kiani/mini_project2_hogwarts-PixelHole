namespace hogwartsBingus.Base_Classes
{
    public struct TicketRequest
    {
        public string Requester { get; private set; }
        public Location Location { get; private set; }
        public Location Destination { get; private set; }

        public TicketRequest(string requester, Location location, Location destination)
        {
            Requester = requester;
            Location = location;
            Destination = destination;
        }
    }
}