using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    [Table("AvailableSlots")]
    public class AvailableSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlotId { get; set; }


        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 24, ErrorMessage = "Duration must be between 1 and 24 hours")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Availability status is required")]
        public bool IsAvailable { get; set; } = true;


        [Required(ErrorMessage = "Slot date is required")]
        [DataType(DataType.Date)]
        public DateTime SlotDate { get; set; }

        // Navigation Properties
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
