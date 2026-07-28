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


        [Required]
        [Range(1, 24)]
        public int Duration { get; set; }


        [Required]
        public bool IsAvailable { get; set; } = true;


        [Required]
     
        public DateTime SlotDate { get; set; }

        // Navigation Properties
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();

        
    }
}
