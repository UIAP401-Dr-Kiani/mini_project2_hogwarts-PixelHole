using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class PassengerDoesntHaveTicketException : Exception
    {
        public PassengerDoesntHaveTicketException()
        {
        }

        public PassengerDoesntHaveTicketException(string message) : base(message)
        {
        }

        public PassengerDoesntHaveTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PassengerDoesntHaveTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}