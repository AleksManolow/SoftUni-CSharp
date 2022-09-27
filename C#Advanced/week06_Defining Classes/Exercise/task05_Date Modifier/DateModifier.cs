using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int CalculateDifference(string firstDate, string secoundDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime secound = DateTime.Parse(secoundDate);

            TimeSpan difference = first - secound;



            return Math.Abs(difference.Days); 
        }
    }
}
