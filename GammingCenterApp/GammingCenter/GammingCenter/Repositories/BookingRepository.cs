using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class BookingRepository
    {
        // Database context used to access the database
        private readonly GammingCenterContext context;

        public BookingRepository(GammingCenterContext context)
        {
            // Dependency Injection
            this.context = context;
        }

        //========================================================
        // Add Booking

        public void AddBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        //========================================================
        // Get Booking By Id

        public Booking GetById(int bookingId)
        {
            return context.Bookings
                .FirstOrDefault(b => b.BookingId == bookingId);
        }

        //========================================================
        // Get All Bookings

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        //========================================================
        // Get Visitor By Id

        public Visitor GetVisitorById(int visitorId)
        {
            return context.Visitors
                .FirstOrDefault(v => v.VisitorId == visitorId);
        }

        //========================================================
        // Update Booking

        public void Update()
        {
            context.SaveChanges();
        }

        //========================================================
        // View Visitor Bookings

        public List<Booking> GetByVisitorId(int visitorId)
        {
            return context.Bookings
                .Where(b => b.VisitorId == visitorId)
                .ToList();
        }

        //========================================================
        // Calculate Total Price

        public GamingDevice GetGamingDeviceById(int deviceId)
        {
            return context.GamingDevices
                .FirstOrDefault(d => d.DeviceID == deviceId);
        }

        //========================================================
        // Check Device Availability

        public bool IsDeviceAvailable(int deviceId, int slotId)
        {
            bool isBooked = context.Bookings.Any(b =>
                b.GamingDeviceId == deviceId &&
                b.AvailableSlotId == slotId &&
                b.Status != "Cancelled");

            return !isBooked;
        }
    }
}