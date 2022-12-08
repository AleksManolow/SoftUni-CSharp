using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get { return room; }
            private set { room = value; }
        }
        public int ResidenceDuration
        {
            get { return residenceDuration; }
            private set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get { return adultsCount; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get { return childrenCount; }
            private set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }
        public int BookingNumber
        {
            get { return bookingNumber; }
            private set { bookingNumber = value; }
        }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults:: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Total amount paid: {TotalPaid():f2} $");

            return sb.ToString().TrimEnd();
        }
        private double TotalPaid()
        {
            return Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
        }
    }
}
