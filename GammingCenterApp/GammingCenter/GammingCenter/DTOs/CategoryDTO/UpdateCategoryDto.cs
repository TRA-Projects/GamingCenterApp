using System.ComponentModel.DataAnnotations;

namespace GammingCenter.DTOs.CategoryDTO
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string categoryName { get; set; }


        [MaxLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string description { get; set; }
    }
}
