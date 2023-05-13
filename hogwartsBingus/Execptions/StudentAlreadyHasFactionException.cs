using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class StudentAlreadyHasFactionException : Exception
    {
        public StudentAlreadyHasFactionException()
        {
        }

        public StudentAlreadyHasFactionException(string message) : base(message)
        {
        }

        public StudentAlreadyHasFactionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudentAlreadyHasFactionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}