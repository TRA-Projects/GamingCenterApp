using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.PaymentDTO
{
    public class UpdatePaymentStatusDTO
    {
        [Required(ErrorMessage = "Value should not be null.")]
        [StringLength(30, ErrorMessage = "Payment status cannot exceed 30 characters.")]
        public string paymentStatus { get; set; }
    }
}
