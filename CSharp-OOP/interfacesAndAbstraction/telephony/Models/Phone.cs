using System;
using System.Linq;
using Telephony;

namespace telephony.Models
{
    public abstract class Phone : ICallable
    {
        public virtual string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"";
        }
    }
}
