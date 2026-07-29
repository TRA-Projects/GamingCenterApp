using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class BookingService
    {
        // Repository object used to access booking data
        private readonly BookingRepository bookingRepo;

        // Email service
        private readonly EmailService emailService;

        public BookingService(
            BookingRepository bookingRepo,
            EmailService emailService)
        {
            // Dependency Injection
            this.bookingRepo = bookingRepo;
            this.emailService = emailService;
        }

        //========================================================
        // Create Booking

        public async Task CreateBooking(CreateBookingDTO dto, int visitorId)
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

            // Get Visitor Information
            Visitor visitor = bookingRepo.GetVisitorById(visitorId);

            if (visitor != null)
            {
                await emailService.SendEmailAsync(
                    visitor.Email,
                    "Booking Confirmation",
                    $"Hello {visitor.VisitorName},\n\n" +
                    $"Your booking has been created successfully.\n\n" +
                    $"Booking ID : {booking.BookingId}\n" +
                    $"Booking Date : {booking.BookingDate}\n" +
                    $"Players : {booking.PlayerNumber}\n" +
                    $"Total Price : {booking.TotalPrice}\n" +
                    $"Status : {booking.Status}\n\n" +
                    $"Thank you for choosing Gaming Center."
                );
            }
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
        // View All Bookings

        public List<BookingListDTO> GetAllBookings()
        {
            List<Booking> bookings = bookingRepo.GetAll();

            return bookings.Select(b => new BookingListDTO
            {
                BookingId = b.BookingId,
                BookingDate = b.BookingDate,
                TotalPrice = b.TotalPrice,
                Status = b.Status
            }).ToList();
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