using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.BookingType
{
    public class BookingTypeUpdateDto
    {
        [Required(ErrorMessage = "Booking type name is required")]
        [MaxLength(50, ErrorMessage = "Booking type name cannot exceed 50 characters")]
        public string TypeName { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }
    }
}