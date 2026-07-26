using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.GamingDevice
{
    public class ChangeDeviceStatusDto
    {
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }
}