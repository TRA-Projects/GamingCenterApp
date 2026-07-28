using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.BookingDTO
{
    public class CreateBookingDTO
    {
        [Required(ErrorMessage = "Gaming device is required")]
        public int GamingDeviceId { get; set; }

        [Required(ErrorMessage = "Booking type is required")]
        public int BookingTypeId { get; set; }

        [Required(ErrorMessage = "Available slot is required")]
        public int AvailableSlotId { get; set; }

        [Required(ErrorMessage = "Player number is required")]
        [Range(1, 20, ErrorMessage = "Player number must be between 1 and 20")]
        public int PlayerNumber { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than zero")]
        public decimal TotalPrice { get; set; }
    }
}