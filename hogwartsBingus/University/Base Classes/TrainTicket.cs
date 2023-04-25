namespace hogwartsBingus.Base_Classes
{
    public class TrainTicket
    {
        public int TrainNumber { get; protected set; }
        public DateTime MoveTime { get; protected set; }
        
        public string Destination { get; protected set; }
        public string Location { get; protected set; }

        public TrainTicket(int trainNumber, DateTime moveTime, string destination, string location)
        {
            TrainNumber = trainNumber;
            MoveTime = moveTime;
            Destination = destination;
            Location = location;
        }
    }
}