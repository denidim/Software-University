using System;

namespace Telephony
{
    public class InvalidUrlNameException : Exception
    {
        private const string Invalid_URL_exeption_message = "Invalid URL!";
        public InvalidUrlNameException()
            : base(Invalid_URL_exeption_message)
        {

        }
    }
}
