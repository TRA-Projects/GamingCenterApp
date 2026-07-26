namespace GammingCenter.DTOs.PaymentDTO
{
    public class PaymentOutputDTO
    {

        public int paymentId { get; set; }
        public decimal amount { get; set; }
        public string paymentMethod { get; set; }
        public string paymentStatus { get; set; }
        public int bookingId { get; set; }
    }
}
