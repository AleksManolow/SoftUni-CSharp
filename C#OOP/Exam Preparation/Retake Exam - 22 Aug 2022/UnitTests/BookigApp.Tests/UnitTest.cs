using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Numerics;
using System.Reflection;

namespace BookigApp.Tests
{
    public class Tests
    {
        [Test]
        public void ValidateCtorAndProp()
        {
            Room room = new Room(5, 20);
            Assert.IsNotNull(room);
            Assert.Throws<ArgumentException>(() => new Room(-1, 12));
            Assert.Throws<ArgumentException>(() => new Room(5, -12));


            Hotel hotel = new Hotel("Flamingo", 5);
            Assert.IsNotNull(room);
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 5)); 
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 4)); 
            Assert.Throws<ArgumentException>(() => new Hotel("Flamingo", 12)); 
            Assert.Throws<ArgumentException>(() => new Hotel("Flamingo", 0));

            var type = typeof(Hotel);
            PropertyInfo propertyInfo1 = type.GetProperty("Rooms");
            Assert.That(propertyInfo1.CanWrite == false);
            PropertyInfo propertyInfo2 = type.GetProperty("Bookings");
            Assert.That(propertyInfo2.CanWrite == false);
        }
        [Test]
        public void ValidateMethodAdd()
        {
            Hotel hotel = new Hotel("Flamingo", 5);
            Room room1 = new Room(4, 20);
            Room room2 = new Room(5, 18);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Assert.AreEqual(2, hotel.Rooms.Count);
        }
        [Test]
        public void ValidateMethodBookRoom() 
        {
            Hotel hotel = new Hotel("Flamingo", 5);
            Room room1 = new Room(3, 20);
            Room room2 = new Room(2, 18);
            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 4, 80));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 5, 80));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, -1, 80));

            hotel.BookRoom(2, 1, 2, 80);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(40, hotel.Turnover);
        }

    }
}