using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.AvailableSlotDTO
{
    public class AvailableSlotInputDTO
    {

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 24, ErrorMessage = "Duration must be between 1 and 24 hours")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Slot date is required")]
        
        public DateTime SlotDate { get; set; }

    }

    public class AvailableSlotOutputDTO
    {

        public int SlotId { get; set; }


        public int Duration { get; set; }


        public bool IsAvailable { get; set; }


        public DateTime SlotDate { get; set; }

    }


}
