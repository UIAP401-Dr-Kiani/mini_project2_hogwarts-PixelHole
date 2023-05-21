using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class InvalidDormitoryNameException : Exception
    {
        public InvalidDormitoryNameException()
        {
        }
        public InvalidDormitoryNameException(string message) : base(message)
        {
        }
        public InvalidDormitoryNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected InvalidDormitoryNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}