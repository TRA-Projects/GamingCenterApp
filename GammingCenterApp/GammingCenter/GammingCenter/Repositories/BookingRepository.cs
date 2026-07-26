using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class BookingRepository
    {
        //Add booking
        // Database context used to access the database
        private GammingCenterContext context;

        public BookingRepository(GammingCenterContext context)
        {
            // Dependency Injection
            this.context = context;
        }

        // Add a new booking to the database
        public void AddBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        //update booking
        // Find a booking by its ID
        public Booking GetById(int bookingId)
        {
            return context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        // Save any changes made to the database
        public void Update()
        {
            context.SaveChanges();
        }

        //========================================================
        // View Visitor Bookings

        // Get all bookings for a specific visitor
        public List<Booking> GetByVisitorId(int visitorId)
        {
            return context.Bookings
                .Where(b => b.VisitorId == visitorId)
                .ToList();
        }
    }
}
