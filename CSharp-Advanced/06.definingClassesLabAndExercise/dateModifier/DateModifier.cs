using System;
namespace dateModifier
{
    public class DateModifier
    {
        public static int CalculateDateDifferenceBtwDates(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);

            DateTime dateTwo = DateTime.Parse(secondDate);

            int days = Math.Abs((dateOne - dateTwo).Days);

            return days;
        }
    }
}
