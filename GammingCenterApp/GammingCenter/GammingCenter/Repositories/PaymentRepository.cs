using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class PaymentRepository
    {
       //constructor ID
        private GammingCenterContext context;

        
        public PaymentRepository(GammingCenterContext _context)
        {
            context = _context;
        }

        public List<Payment> GetAllPayments()
        {
            return context.Payments.ToList();
        }

        
        public Payment GetPaymentById(int id)
        {
            return context.Payments.FirstOrDefault(p => p.paymentId == id);
        }

        
        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }

       
        public void Update()
        {
            context.SaveChanges();
        }

      
    }
}