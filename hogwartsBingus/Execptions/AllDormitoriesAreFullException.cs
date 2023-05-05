using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class AllDormitoriesAreFullException : Exception
    {
        public AllDormitoriesAreFullException()
        {
        }

        public AllDormitoriesAreFullException(string message) : base(message)
        {
        }

        public AllDormitoriesAreFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AllDormitoriesAreFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}