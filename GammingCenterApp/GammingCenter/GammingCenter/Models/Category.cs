using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; }// system generated 

        [Required]
        [MaxLength(100)]
        public string categoryName { get; set; } // user input
        
        [MaxLength(100)]
        public string description { get; set; } // user input 



        // reverse navigation - one Category contains many GamingDevices
        public List<GamingDevice> GamingDevices { get; set; } = new List<GamingDevice>();
    }
}
