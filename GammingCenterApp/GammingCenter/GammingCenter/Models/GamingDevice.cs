using GammingCenter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GamingDevice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceID { get; set; }
    // Primary Key, System Generated


    [Required(ErrorMessage = "Device name is required.")]
    [MaxLength(100, ErrorMessage = "Device name cannot exceed 100 characters.")]
    public string DeviceName { get; set; }
    // Required, Max 100 characters


    [Required(ErrorMessage = "Device code is required.")]
    [MaxLength(50, ErrorMessage = "Device code cannot exceed 50 characters.")]
    public string DeviceCode { get; set; }
    // Required, Max 50 characters


    [Required(ErrorMessage = "Hourly price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Hourly price must be greater than 0.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal HourlyPrice { get; set; }
    // Required, Greater than 0, Decimal(10,2)


    public bool Status { get; set; }

    public bool IsAvailable { get; set; }



    // Navigation Property
    // foreign key — every Devise must belong to a category
    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    // foreign key — every Devise must belong to a Room
    [Required]
    [ForeignKey("Room")]
    public int RoomId { get; set; }
    public virtual Room Room { get; set; }




}