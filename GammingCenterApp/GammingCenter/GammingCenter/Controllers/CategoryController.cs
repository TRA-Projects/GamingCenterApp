using GammingCenter.DTOs.CategoryDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        // Allow Controller to Access Service
        private readonly CategoryService _service;

        // Constructor
        public CategoryController(CategoryService service)
        {
            _service = service;
        }


        // 1-Add Category

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDto dto)
        {
            int categoryId = _service.AddCategory(dto);

            return Ok("Category added successfully");
        }


        // 2-Update Category

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory([FromRoute] int categoryId, [FromBody] UpdateCategoryDto dto)
        {
            bool result = _service.UpdateCategory(categoryId, dto);

            // Check if the category exists
            if (!result)
            {
                return NotFound("Category not found");
            }

            return Ok("Category updated successfully");
        }


        // 3-Delete Category Method

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory([FromRoute] int categoryId)
        {
            bool result = _service.DeleteCategory(categoryId);

            // Validate input
            if (!result)
            {
                return NotFound("Category not found");
            }

            return Ok("Category deleted successfully");
        }


        // 4-View All Categories Method

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            List<CategoryResponseDto> categories = _service.GetAllCategories();

            return Ok(categories);
        }


        // 5-View Devices by Category Method

        [HttpGet("{categoryId}/devices")]
        public IActionResult GetDevicesByCategory([FromRoute] int categoryId)
        {
            Category category = _service.GetDevicesByCategory(categoryId);

            // Validate input
            if (category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }
    }
}
