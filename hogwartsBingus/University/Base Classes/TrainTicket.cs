namespace hogwartsBingus.Base_Classes
{
    public class TrainTicket
    {
        public int TrainNumber { get; protected set; }
        public DateTime MoveTime { get; protected set; }
        
        public Location Destination { get; protected set; }
        public Location Location { get; protected set; }

        public TrainTicket(int trainNumber, DateTime moveTime, Location destination, Location location)
        {
            TrainNumber = trainNumber;
            MoveTime = moveTime;
            Destination = destination;
            Location = location;
        }
    }
}