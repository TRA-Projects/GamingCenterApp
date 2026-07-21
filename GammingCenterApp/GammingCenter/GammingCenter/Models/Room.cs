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

        [Required]
        [MaxLength(100)]
        public string RoomName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomType { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(30)]
        public string RoomStatus { get; set; }
    }
}
