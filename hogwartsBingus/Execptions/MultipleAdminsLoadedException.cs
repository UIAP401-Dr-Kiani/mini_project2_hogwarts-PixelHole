using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class MultipleAdminsLoadedException : Exception
    {
        public MultipleAdminsLoadedException()
        {
        }

        public MultipleAdminsLoadedException(string message) : base(message)
        {
        }

        public MultipleAdminsLoadedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultipleAdminsLoadedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}