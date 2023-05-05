using System;
using System.Runtime.Serialization;

namespace hogwartsBingus.Execptions
{
    public class StudySessionIntersectionException : Exception
    {
        public StudySessionIntersectionException()
        {
        }

        public StudySessionIntersectionException(string message) : base(message)
        {
        }

        public StudySessionIntersectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudySessionIntersectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}