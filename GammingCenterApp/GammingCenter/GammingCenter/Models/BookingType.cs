using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class BookingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingTypeID { get; set; }  // Primary Key, System Generated


        [Required(ErrorMessage = "Booking type name is required")]
        [MaxLength(50, ErrorMessage = "Booking type name cannot exceed 50 characters")]
        public string TypeName { get; set; }


        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }



        // Navigation Property
        // One BookingType has Many Bookings
        public virtual List<Booking> Bookings { get; set; }
    }
}
