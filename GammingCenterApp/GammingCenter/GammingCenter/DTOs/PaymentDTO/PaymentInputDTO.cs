using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.PaymentDTO
{
    public class PaymentInputDTO
    {


        [Required(ErrorMessage = "Value should not be null.")]
        [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
        public string paymentMethod { get; set; }

        [Required(ErrorMessage = "Value should not be null.")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public int bookingId { get; set; }






    }
}
