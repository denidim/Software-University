using System;
using System.Linq;
using telephony.Models;

namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            base.Call(number);
            return $"Dialing... {number}";

        }

    }
}
