using System;
using System.Linq;
using telephony.Models;

namespace Telephony.Models
{
    public class Smarthphone : Phone, IBrowseble
    {
        public override string Call(string number)
        {
            base.Call(number);

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(Char.IsDigit))
            {
                throw new InvalidUrlNameException();
            }
            return $"Browsing: {url}!";
        }
    }
}
