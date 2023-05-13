using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class FactionNotFoundException : Exception
    {
        public FactionNotFoundException()
        {
        }

        public FactionNotFoundException(string message) : base(message)
        {
        }

        public FactionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FactionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}