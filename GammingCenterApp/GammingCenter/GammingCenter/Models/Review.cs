using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GammingCenter.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; } // system generated


        [Required]
        [Range(1, 5)]
        public int rating { get; set; } // user input - from 1 to 5


        public string comment { get; set; } // user input


        [Required]
        public DateTime reviewDate { get; set; } = DateTime.Now; //system generated — set to DateTime.Now


        // foreign key - links to Visitor ID
        [Required] 
        public int visitorId { get; set; } // from list -selected visitor


        // foreign key - links to GamingDevice ID
        [Required] 
        public int deviceId { get; set; } // from list - selected device



    }
}
