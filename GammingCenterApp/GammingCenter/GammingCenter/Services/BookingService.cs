using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class BookingService
    {
        // Repository object used to access booking data
        private BookingRepository bookingRepo;

        public BookingService(BookingRepository bookingRepo)
        {
            // Dependency Injection
            this.bookingRepo = bookingRepo;
        }

        //========================================================
        // Create Booking

        public void CreateBooking(CreateBookingDTO dto, int visitorId)
        {
            Booking booking = new Booking();

            booking.VisitorId = visitorId;
            booking.GamingDeviceId = dto.GamingDeviceId;
            booking.BookingTypeId = dto.BookingTypeId;
            booking.AvailableSlotId = dto.AvailableSlotId;
            booking.PlayerNumber = dto.PlayerNumber;
            booking.TotalPrice = dto.TotalPrice;

            booking.BookingDate = DateTime.Now;
            booking.Status = "Pending";

            bookingRepo.AddBooking(booking);
        }

        //========================================================
        // Update Booking

        public void UpdateBooking(int bookingId, UpdateBookingDTO dto)
        {
            Booking booking = bookingRepo.GetById(bookingId);

            if (booking == null)
                return;

            booking.GamingDeviceId = dto.GamingDeviceId;
            booking.BookingTypeId = dto.BookingTypeId;
            booking.AvailableSlotId = dto.AvailableSlotId;
            booking.PlayerNumber = dto.PlayerNumber;
            booking.TotalPrice = dto.TotalPrice;

            bookingRepo.Update();
        }

        //========================================================
        // Cancel Booking

        public void CancelBooking(int bookingId)
        {
            Booking booking = bookingRepo.GetById(bookingId);

            if (booking == null)
                return;

            booking.Status = "Cancelled";

            bookingRepo.Update();
        }

        //========================================================
        // View Booking Details

        public BookingDetailsDTO GetBookingDetails(int bookingId)
        {
            Booking booking = bookingRepo.GetById(bookingId);

            if (booking == null)
                return null;

            return new BookingDetailsDTO
            {
                BookingId = booking.BookingId,
                BookingDate = booking.BookingDate,
                VisitorId = booking.VisitorId,
                GamingDeviceId = booking.GamingDeviceId,
                BookingTypeId = booking.BookingTypeId,
                AvailableSlotId = booking.AvailableSlotId,
                PlayerNumber = booking.PlayerNumber,
                TotalPrice = booking.TotalPrice,
                Status = booking.Status
            };
        }

        //========================================================
        // View Visitor Bookings

        public List<BookingListDTO> GetVisitorBookings(int visitorId)
        {
            List<Booking> bookings = bookingRepo.GetByVisitorId(visitorId);

            return bookings.Select(b => new BookingListDTO
            {
                BookingId = b.BookingId,
                BookingDate = b.BookingDate,
                TotalPrice = b.TotalPrice,
                Status = b.Status
            }).ToList();
        }

        //========================================================
        // Calculate Total Price

        public decimal CalculateTotalPrice(int gamingDeviceId, int hours)
        {
            GamingDevice device = bookingRepo.GetGamingDeviceById(gamingDeviceId);

            if (device == null)
                return 0;

            return device.HourlyPrice * hours;
        }

        //========================================================
        // Check Device Availability

        public bool CheckDeviceAvailability(int deviceId, int slotId)
        {
            return bookingRepo.IsDeviceAvailable(deviceId, slotId);
        }
    }
}