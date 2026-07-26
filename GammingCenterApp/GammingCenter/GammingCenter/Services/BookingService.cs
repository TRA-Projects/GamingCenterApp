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
        //update booking

        // Business Logic for updating a booking
        public void UpdateBooking(int bookingId, BookingDTO dto)
        {
            // Retrieve booking from database
            Booking booking = bookingRepo.GetById(bookingId);

            // Check if booking exists
            if (booking == null)
            {
                return;
            }

            // Update booking information
            booking.VisitorId = dto.VisitorId;
            booking.GamingDeviceId = dto.GamingDeviceId;
            booking.BookingTypeId = dto.BookingTypeId;
            booking.AvailableSlotId = dto.AvailableSlotId;
            booking.PlayerNumber = dto.PlayerNumber;
            booking.TotalPrice = dto.TotalPrice;

            // Save changes
            bookingRepo.Update();
        }

        //========================================================
        // Cancel Booking

        // Business Logic for cancelling a booking
        public void CancelBooking(int bookingId)
        {
            // Retrieve booking from database
            Booking booking = bookingRepo.GetById(bookingId);


            // Check if booking exists
            if (booking == null)
            {
                return;
            }


            // Change booking status instead of deleting it
            booking.Status = "Cancelled";


            // Save changes
            bookingRepo.Update();
        }

        //========================================================
        // View Booking Details

        // Business Logic for viewing booking details
        public Booking GetBookingDetails(int bookingId)
        {
            // Get booking from database
            Booking booking = bookingRepo.GetById(bookingId);


            // Check if booking exists
            if (booking == null)
            {
                return null;
            }


            // Return booking details
            return booking;
        }

    }
}
