using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class NoAdminsLoadedException : Exception
    {
        public NoAdminsLoadedException()
        {
        }

        public NoAdminsLoadedException(string message) : base(message)
        {
        }

        public NoAdminsLoadedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoAdminsLoadedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}