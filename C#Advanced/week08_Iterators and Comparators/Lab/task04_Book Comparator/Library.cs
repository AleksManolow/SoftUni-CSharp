using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }
        public IEnumerator<Book> GetEnumerator()
        {
            for (int index = 0; index < books.Count; index++)
            {
                yield return books.OrderBy(book => book.Title).OrderByDescending(book => book.Year).ToList()[index];
            }
            
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    }
}
