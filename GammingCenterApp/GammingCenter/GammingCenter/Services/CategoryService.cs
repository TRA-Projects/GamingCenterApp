using GammingCenter.DTOs.CategoryDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository categoryRepository;

        private readonly CategoryRepository repo;

        public CategoryService(CategoryRepository _repo)
        {
            repo = _repo;
        }


        //  1. Add Category:
        public int AddCategory(CreateCategoryDto dto)
        {
            Category category = new Category();
            category.categoryName = dto.categoryName;
            category.description = dto.description;

            repo.AddCategory(category);
            return category.categoryId;
        }


        // 2. Update Category
        public bool UpdateCategory(int categoryId, UpdateCategoryDto dto)
        {
            Category category = repo.GetDevicesByCategory(categoryId);
            if (category == null)
            {
                return false;
            }

            category.categoryName = dto.categoryName;
            category.description = dto.description;

            repo.UpdateCategory(category);
            return true;
        }


        // 3. Delete Category
        public bool DeleteCategory(int categoryId)
        {
            Category category = repo.GetDevicesByCategory(categoryId);
            if (category == null)
            {
                return false;
            }

            repo.DeleteCategory(category);
            return true;
        }

        // 4. View All Categories
        public List<CategoryResponseDto> GetAllCategories()
        {
            return repo.GetAllCategories()
                       .Select(category => new CategoryResponseDto
                       {
                           categoryId = category.categoryId,
                           categoryName = category.categoryName,
                           description = category.description
                       })
                       .ToList();
        }


        // 5. View Devices by Category
        public Category GetDevicesByCategory(int categoryId)
        {
            Category category = repo.GetDevicesByCategory(categoryId);
            return category;
        }

    }
}
