using System;

namespace Telephony
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string Invalid_phone_number_message = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(Invalid_phone_number_message)
        {

        }
    }
}
