using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class AuthorizedPersonTypeNotFoundException : Exception
    {
        public AuthorizedPersonTypeNotFoundException()
        {
        }

        public AuthorizedPersonTypeNotFoundException(string message) : base(message)
        {
        }

        public AuthorizedPersonTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthorizedPersonTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}