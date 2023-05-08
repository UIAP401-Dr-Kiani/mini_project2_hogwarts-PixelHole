using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class WindowAlreadyOpenException : Exception
    {
        public WindowAlreadyOpenException()
        {
        }

        public WindowAlreadyOpenException(string message) : base(message)
        {
        }

        public WindowAlreadyOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WindowAlreadyOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}