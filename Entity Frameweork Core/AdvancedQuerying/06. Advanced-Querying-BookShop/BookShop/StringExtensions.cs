using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public static class StringExtensions
    {
        public static bool MyContains(this string[] source,string toCheck,bool bCaseInsensitive)
        {
            foreach (var item in source)
            {
                var result =  item.IndexOf(toCheck, bCaseInsensitive 
                    ? StringComparison.OrdinalIgnoreCase 
                    : StringComparison.Ordinal) >= 0;

                if(result == false) return false;

            }

            return true;
        }
    }
}

