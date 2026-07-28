using GammingCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace GammingCenter.Repositories
{
    public class AuthRepository
    {
        private readonly GammingCenterContext _context;

        public AuthRepository(GammingCenterContext context)
        {
            _context = context;
        }

        public Visitor GetVisitorByEmail(string email)
        {
            return _context.Visitors
                .FirstOrDefault(v => v.Email == email);
        }

        public void AddVisitor(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            _context.SaveChanges();
        }
    }
}