using GammingCenter.Models;
using GammingCenter.Repositories;
using static GammingCenter.DTOs.PaymentDTO.PaymentDTO;

namespace GammingCenter.Services
{
    public class PaymentService
    {
        private PaymentRepository repo;

        public PaymentService(PaymentRepository _repo)
        {
            repo = _repo;
        }
        // ====== View All Payments ======
        public List<PaymentOutputDTO> GetAllPayments()
        {
            return repo.GetAllPayments()
                       .Select(p => new PaymentOutputDTO
                       {
                           PaymentId = p.paymentId,
                           Amount = p.amount,
                           PaymentMethod = p.paymentMethod,
                           PaymentStatus = p.paymentStatus,
                           BookingId = p.bookingId
                       })
                       .ToList();
        }


        // ====== View Payment Details by id ======
        public PaymentOutputDTO GetPaymentById(int id)
        {
            Payment payment = repo.GetPaymentById(id);

            if (payment == null)
                return null;

            PaymentOutputDTO dto = new PaymentOutputDTO();

            dto.PaymentId = payment.paymentId;
            dto.Amount = payment.amount;
            dto.PaymentMethod = payment.paymentMethod;
            dto.PaymentStatus = payment.paymentStatus;
            dto.BookingId = payment.bookingId;

            return dto;
        }

        // ==== Make Payment ====
        public int MakePayment(PaymentInputDTO dto)
        {
            Payment payment = new Payment();

            payment.amount = dto.amount;
            payment.paymentMethod = dto.paymentMethod;
            payment.bookingId = dto.bookingId;

            payment.paymentStatus = "Paid";

            repo.Add(payment);

            return payment.paymentId;
        }


        // === Update Payment Status ===
        public bool UpdatePaymentStatus(int id, string status)
        {
            Payment payment = repo.GetPaymentById(id);

            if (payment == null)
                return false;

            payment.paymentStatus = status;

            repo.Update();

            return true;
        }







    }
}
