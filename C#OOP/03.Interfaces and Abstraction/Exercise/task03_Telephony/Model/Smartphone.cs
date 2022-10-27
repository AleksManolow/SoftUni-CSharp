using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task03_Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExceptionMesseges.InvalidNumberException);
            }
            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }
        public string Brow(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExceptionMesseges.InvalidUrlException);
            }
            return $"Browsing: {url}!";
        }

        
    }
}
