using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            rooms.Add(room);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms;
        }

        public IRoom Select(string type)
        {
            return rooms.FirstOrDefault(r => r.GetType().Name == type);
        }
    }
}
