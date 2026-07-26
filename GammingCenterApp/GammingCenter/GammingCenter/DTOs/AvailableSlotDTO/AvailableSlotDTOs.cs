using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.AvailableSlotDTO
{
    public class AvailableSlotDTOs
    {
        [Required]
        [Range(1, 24)]
        public int Duration { get; set; }

        [Required]
        public DateTime SlotDate { get; set; }
    }
}
