using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class BookingRepository
    {
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
    }
}
