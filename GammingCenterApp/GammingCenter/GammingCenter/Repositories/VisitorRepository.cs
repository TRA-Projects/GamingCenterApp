using GammingCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GammingCenter.Repositories
{
    public class VisitorRepository
    {
        private GammingCenterContext context;

        public VisitorRepository(GammingCenterContext _context)
        {
            context = _context;
        }



        // Register Visitor:
        public void RegisterVisitor(Visitor visitor)
        {
            context.Visitors.Add(visitor);
            context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            return context.Visitors.Any(v => v.Email == email);
        }



        // Login Visitor:
        public Visitor Login(string email)
        {
            return context.Visitors.FirstOrDefault(v => v.Email == email);
        }

        public Visitor GetById(int id)
        {
            return context.Visitors.FirstOrDefault(v => v.VisitorId == id);
        }



        // Update Profile:
        public void Update()
        {
            context.SaveChanges();
        }



        // View Booking History:
        public Visitor GetBookingHistory(int visitorId)
        {
            return context.Visitors
                .Include(v => v.bookings)
                  .ThenInclude(b => b.BookingType)
                .FirstOrDefault(v => v.VisitorId == visitorId);
        }



        // View Competition History:
        public List<Competition> GetCompetitionHistory()
        {
            return context.Competitions.ToList();
        }


    }
}
