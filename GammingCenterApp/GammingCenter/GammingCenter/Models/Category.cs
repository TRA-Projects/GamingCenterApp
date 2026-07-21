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
       

    }
}
