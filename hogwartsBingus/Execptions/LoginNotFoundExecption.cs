using System;

namespace hogwartsBingus.Execptions
{
    [Serializable]
    public class LoginNotFoundException : Exception
    {
        public LoginNotFoundException() { }

        public LoginNotFoundException(string message) : base(message) { }

        public LoginNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}