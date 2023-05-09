using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class TicketAlreadyRequestedException : Exception
    {
        public TicketAlreadyRequestedException()
        {
        }

        public TicketAlreadyRequestedException(string message) : base(message)
        {
        }

        public TicketAlreadyRequestedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicketAlreadyRequestedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}