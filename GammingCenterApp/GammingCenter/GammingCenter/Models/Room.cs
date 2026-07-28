using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(30)]
        public string RoomStatus { get; set; } = "Available";        //Available, Occupied, Reserved, Maintenance 


        //Navigation Properties
        public virtual List<Competition> Competitions { get; set; } = new List<Competition>();

        public virtual List<GamingDevice> GamingDevices { get; set; } = new List<GamingDevice>();

    }
}
