using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } // user input

        [Required]
        public string Description { get; set; }


    }
}
