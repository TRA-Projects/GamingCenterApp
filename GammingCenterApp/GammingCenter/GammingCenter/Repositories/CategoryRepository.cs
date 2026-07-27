using GammingCenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GammingCenter.Repositories
{
    public class CategoryRepository
    {
        private readonly GammingCenterContext Context;

        public CategoryRepository(GammingCenterContext _Context)
        {
            Context = _Context;
        }


        // Add Category:
        public void AddCategory(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }


        // Update Category:
        public void UpdateCategory(Category category)
        {
            Context.Categories.Update(category);
            Context.SaveChanges();
        }


        // Delete Category:
        public void DeleteCategory(Category category)
        {
            Context.Categories.Remove(category);
            Context.SaveChanges();
        }


        // View All Categories:
        public List<Category> GetAllCategories()
        {
            return Context.Categories.ToList();
        }


        // View Devices by Category:
        public Category GetDevicesByCategory(int CategoryId)
        {
            return Context.Categories
                .Include(c => c.GamingDevices) // 
                .FirstOrDefault(c => c.categoryId == CategoryId);
        }

    }
}
