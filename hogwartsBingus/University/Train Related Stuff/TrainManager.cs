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
    public static class TrainManager
    {
        static TrainManager()
        {
            GlobalClock.TimeChanged += CheckForMoveTime;
        }
        
        private static List<Train> Trains = new List<Train>();
        
        public static void AddTrain(Train train)
        {
            // check
            Trains.Add(train);
        }

        public static void AddTrain(DateTime moveTime, string location, string destination)
        {
            Trains.Add(new Train(moveTime, location, destination));
        }

        public static void RemoveTrain(Train train)
        {
            // check
            Trains.Remove(train);
        }

        public static void StartTrain(int index)
        {
            Trains[index].Move();
        }

        public static void BoardPersonOnTrain(int userIndex, int trainIndex)
        {
            Train train = Trains[trainIndex];
            if (!UserManager.GetUserAtIndex(userIndex).HasTicketForTrain(train.TrainNumber, train.MoveTime))
            {
                throw new PassengerDoesntHaveTicketException();
                return;
            }
            Trains[trainIndex].AddPassenger(userIndex);
        }

        public static void UnboardPersonFromTrain(int userIndex, int trainIndex)
        {
            Trains[trainIndex].RemovePassenger(userIndex);
        }

        private static void CheckForMoveTime()
        {
            foreach (var train in Trains)
            {
                if (train.MoveTime == GlobalClock.CurrentTime)
                {
                    train.Move();
                    Trains.Remove(train);
                }
            }
        }

        public static TrainTicket FindTicket(string Location, string Destination)
        {
            foreach (var train in Trains)
            {
                if (train.Location == Location && train.Destination == Destination)
                {
                    return new TrainTicket(train.TrainNumber, train.MoveTime, train.Destination, train.Location);
                }
            }

            return null;
        }

        public static void RemoveUsedTrains()
        {
            
        }
    }
}