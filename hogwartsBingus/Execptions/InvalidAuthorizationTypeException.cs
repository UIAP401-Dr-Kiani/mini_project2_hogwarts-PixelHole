using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class InvalidAuthorizationTypeException : Exception
    {
        public InvalidAuthorizationTypeException()
        {
        }

        public InvalidAuthorizationTypeException(string message) : base(message)
        {
        }

        public InvalidAuthorizationTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAuthorizationTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}