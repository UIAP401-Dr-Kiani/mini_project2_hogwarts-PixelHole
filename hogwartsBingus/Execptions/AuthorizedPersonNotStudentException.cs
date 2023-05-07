using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class AuthorizedPersonNotStudentException : Exception
    {
        public AuthorizedPersonNotStudentException()
        {
        }

        public AuthorizedPersonNotStudentException(string message) : base(message)
        {
        }

        public AuthorizedPersonNotStudentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthorizedPersonNotStudentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}