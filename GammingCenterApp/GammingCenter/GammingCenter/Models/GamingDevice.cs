using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GammingCenter.Models
{
    public class GamingDevice
    {
        [Key]
        public int DeviceID { get; set; }         // System Generated


        [Required(ErrorMessage = "Device Name is required")]
        [MaxLength(100, ErrorMessage = "Device name cannot exceed 100 characters")]
        public string DeviceName { get; set; }
        // User input

        [Required(ErrorMessage = "Device code is required")]
        [MaxLength(50, ErrorMessage = "Device code cannot exceed 50 characters")]
        public string DeviceCode { get; set; }

        [Required(ErrorMessage = "Hourly price is required")]
        [Range(0.01, double.MaxValue)]
        [Precision(10, 2)]
        public decimal HourlyPrice { get; set; }


        public bool Status { get; set; }

        public bool IsAvailable { get; set; }
    }
}