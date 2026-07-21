using GammingCenter.Models;
using Microsoft.EntityFrameworkCore;
namespace GammingCenter
{
    public class GammingCenterContext :DbContext
    {
        public GammingCenterContext(DbContextOptions<GammingCenterContext> options)
           : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<GamingDevice> GamingDevices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AvailableSlot> AvailableSlots { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }


    }
}
