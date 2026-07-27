using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.PaymentDTO
{
    public class PaymentDTO
    {

        public class PaymentInputDTO
        {

            [Required(ErrorMessage = "Value should not be null.")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0.")]
            public decimal amount { get; set; }

            [Required(ErrorMessage = "Value should not be null.")]
            [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
            public string paymentMethod { get; set; }

            [Required(ErrorMessage = "Value should not be null.")]
            [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
            public int bookingId { get; set; }
        }

        public class PaymentOutputDTO
        {
            public int PaymentId { get; set; }

            public decimal Amount { get; set; }

            public string PaymentMethod { get; set; }

            public string PaymentStatus { get; set; }

            public int BookingId { get; set; }
        }
    }

}
