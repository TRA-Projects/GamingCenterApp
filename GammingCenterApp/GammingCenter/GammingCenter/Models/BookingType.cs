using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class BookingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingTypeID { get; set; }  // Primary Key, System Generated


        [Required]
        [MaxLength]
        public string TypeName { get; set; }


        [MaxLength]
        public string Description { get; set; }



        // Navigation Property
        // One BookingType has Many Bookings
        public virtual List<Booking> Bookings { get; set; }
    }
}
