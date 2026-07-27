using GammingCenter.DTOs.PaymentDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class PaymentService
    {
        private PaymentRepository paymentRepo;
        private BookingRepository bookingRepo;


        public PaymentService(PaymentRepository _paymentRepo, BookingRepository _bookingRepo)
        {
            paymentRepo = _paymentRepo;
            bookingRepo = _bookingRepo;
        }



        //================================== Make Payment=============================//
        public int MakePayment(PaymentInputDTO dto)
        {
            Booking booking = bookingRepo.GetById(dto.bookingId);

            if (booking == null)
            {
                return 0;
            }


            Payment payment = new Payment();

            payment.amount = booking.TotalPrice;
            payment.paymentMethod = dto.paymentMethod;
            payment.paymentStatus = "Pending";
            payment.bookingId = booking.BookingId;


            paymentRepo.Add(payment);

            return payment.paymentId;
        }




        //=========================== View Payment Details=====================//
        public PaymentOutputDTO GetPaymentDetails(int id)
        {
            Payment payment = paymentRepo.GetPaymentById(id);

            if (payment == null)
            {
                return null;
            }


            PaymentOutputDTO output = new PaymentOutputDTO();

            output.paymentId = payment.paymentId;
            output.amount = payment.amount;
            output.paymentMethod = payment.paymentMethod;
            output.paymentStatus = payment.paymentStatus;
            output.bookingId = payment.bookingId;


            return output;
        }





        // ============================= Update Payment Status =====================//
        public bool UpdatePaymentStatus(int id, UpdatePaymentStatusDTO dto)
        {
            Payment payment = paymentRepo.GetPaymentById(id);

            if (payment == null)
            {
                return false;
            }


            payment.paymentStatus = dto.paymentStatus;

            paymentRepo.Update();

            return true;
        }





        //================================== Print Invoice / Receipt ======================//
        public PaymentOutputDTO PrintInvoice(int id)
        {
            Payment payment = paymentRepo.GetPaymentById(id);

            if (payment == null)
            {
                return null;
            }


            PaymentOutputDTO output = new PaymentOutputDTO();

            output.paymentId = payment.paymentId;
            output.amount = payment.amount;
            output.paymentMethod = payment.paymentMethod;
            output.paymentStatus = payment.paymentStatus;
            output.bookingId = payment.bookingId;


            return output;
        }
    }
}