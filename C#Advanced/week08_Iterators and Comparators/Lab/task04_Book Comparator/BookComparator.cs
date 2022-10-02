using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator:IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Year.CompareTo(y.Year);
            if (result == 0)
            {
                result = y.Title.CompareTo(x.Title);
            }
            return result;
        }
    }
}
