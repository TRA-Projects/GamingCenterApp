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
        //==============================================
        // Gaming Device
        [Required]
        [ForeignKey("GamingDevice")]
        public int GamingDeviceId { get; set; }

        public virtual GamingDevice GamingDevice { get; set; } // navigation property


        // Visitor
        //every booking assigned to one visitor
        [Required]
        [ForeignKey("Visitor")]
        public int VisitorId { get; set; }

        public virtual Visitor Visitor { get; set; } // navigation property


        // Booking Type
        //every booking classifies to one booking type
        [Required]
        [ForeignKey("BookingType")]
        public int BookingTypeId { get; set; }

        public virtual BookingType BookingType { get; set; }// navigation property


        // Available Slot
        //every booking has one available slot
        [Required]
        [ForeignKey("AvailableSlot")]
        public int AvailableSlotId { get; set; }

        public virtual AvailableSlot AvailableSlot { get; set; } // navigation property

    }
}
