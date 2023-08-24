using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface ICategoriesService
    {
        public List<Category> GetListCategory();
        public Category CreateCategory(Category unit);
        public bool UpdateCategory(Category unit, int userId);
        public bool DeleteCategory(int categoryId, int? userId);
    }
}
