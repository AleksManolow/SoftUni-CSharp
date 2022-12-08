using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;
        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }
        public void AddNew(IHotel hotel)
        {
            hotels.Add(hotel);
        }
        public IReadOnlyCollection<IHotel> All()
        {
            return hotels;
        }
        public IHotel Select(string name)
        {
            return hotels.FirstOrDefault(h => h.FullName == name);
        }
    }
}
