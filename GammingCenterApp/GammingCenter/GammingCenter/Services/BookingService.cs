using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class BookingService
    {
        //Crate booking
        // Repository object used to access booking data
        private BookingRepository bookingRepo;

        public BookingService(BookingRepository bookingRepo)
        {
            // Dependency Injection
            this.bookingRepo = bookingRepo;
        }

        // Business Logic for creating a booking
        public void CreateBooking(BookingDTO dto)
        {
            Booking booking = new Booking();

            booking.VisitorId = dto.VisitorId;
            booking.GamingDeviceId = dto.GamingDeviceId;
            booking.BookingTypeId = dto.BookingTypeId;
            booking.AvailableSlotId = dto.AvailableSlotId;
            booking.PlayerNumber = dto.PlayerNumber;
            booking.TotalPrice = dto.TotalPrice;

            // Set booking date automatically
            booking.BookingDate = DateTime.Now;

            // Set default booking status
            booking.Status = "Pending";

            // Save booking using Repository
            bookingRepo.AddBooking(booking);
        }
        //========================================================

    }
}
