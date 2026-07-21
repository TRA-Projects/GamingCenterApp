using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }


        [Required(ErrorMessage = "Room name is required")]
        [MaxLength(100, ErrorMessage = "Room name cannot exceed 100 characters")]
        public string RoomName { get; set; }


        [Required(ErrorMessage = "Room type is required")]
        [MaxLength(50, ErrorMessage = "Room type cannot exceed 50 characters")]
        public string RoomType { get; set; } 


        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100")]
        public int Capacity { get; set; }


        [Required(ErrorMessage = "Room status is required")]
        [MaxLength(30, ErrorMessage = "Room status cannot exceed 30 characters")]
        public string RoomStatus { get; set; } 
    }
}
