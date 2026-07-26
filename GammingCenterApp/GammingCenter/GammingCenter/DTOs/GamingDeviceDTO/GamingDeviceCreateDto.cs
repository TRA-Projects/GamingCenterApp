using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.GamingDevice
{
    public class GamingDeviceCreateDto
    {
        [Required(ErrorMessage = "Device name is required.")]
        [MaxLength(100, ErrorMessage = "Device name cannot exceed 100 characters.")]
        public string DeviceName { get; set; }

        [Required(ErrorMessage = "Device code is required.")]
        [MaxLength(50, ErrorMessage = "Device code cannot exceed 50 characters.")]
        public string DeviceCode { get; set; }

        [Required(ErrorMessage = "Hourly price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly price must be greater than 0.")]
        public decimal HourlyPrice { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Room is required.")]
        public int RoomId { get; set; }
    }
}