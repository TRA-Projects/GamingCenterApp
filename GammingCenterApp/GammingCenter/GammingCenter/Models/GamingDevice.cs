using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GammingCenter.Models
{
    public class GamingDevice
    {
        [Required]
        [Key]
        public int DeviceID { get; set; } //System Generated

        [Required]
        [MaxLength(100)]
        public string DeviceName { get; set; } //user input

        [Required]
        [MaxLength(50)]
        public string DeviceCode { get; set; } 

        [Required]
        [Range(0.01, double.MaxValue)]
        [Precision(10, 2)]
        public decimal HourlyPrice { get; set; } 

       
        public bool Status { get; set; } 

        public bool IsAvailable { get; set; } 


    }
}
