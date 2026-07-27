using GammingCenter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GamingDevice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceID { get; set; } // Primary Key, System Generated



    [Required]
    [MaxLength]
    public string DeviceName { get; set; }


    [Required]
    [MaxLength]
    public string DeviceCode { get; set; }
   

    [Required]
    [Range(0.01, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal HourlyPrice { get; set; }
 

    [Required]
    [MaxLength(20)]
    public string Status { get; set; }

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