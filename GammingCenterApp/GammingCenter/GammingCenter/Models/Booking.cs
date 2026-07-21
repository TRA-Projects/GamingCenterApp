using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Booking Date is required")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Player Number is required")]
        [Range(1, 20)]
        public int PlayerNumber { get; set; }

        [Required(ErrorMessage ="Total price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(30)]
        public string Status { get; set; }

       
    }
}
