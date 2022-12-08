using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotelRepository;
        public Controller()
        {
            this.hotelRepository = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotelRepository.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotelRepository.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (this.hotelRepository.All().FirstOrDefault(x => x.Category == category) == default)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var orderedHotels =
                this.hotelRepository.All().Where(x => x.Category == category).OrderBy(x => x.Turnover).ThenBy(x => x.FullName);


            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int bookingNumber = this.hotelRepository.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }
        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine($"{booking.BookingSummary()}");
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (nameof(DoubleBed) != roomTypeName && nameof(Studio) != roomTypeName && nameof(Apartment) != roomTypeName)
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }
            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            switch (roomTypeName)
            {
                case "DoubleBed":
                    room = new DoubleBed();
                    break;
                case "Studio":
                    room = new Studio();
                    break;
                case "Apartment":
                    room = new Apartment();
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
