using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking)
        {
            bookings.Add(booking);
        }

        public IReadOnlyCollection<IBooking> All()
        {
           return bookings;
        }

        public IBooking Select(string number)
        {
            return bookings.FirstOrDefault(b => b.BookingNumber == int.Parse(number));
        }
    }
}
