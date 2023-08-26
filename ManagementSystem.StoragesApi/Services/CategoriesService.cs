using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoriesService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<Category> GetListCategory()
        {
            List<Category> categories = new List<Category>();
            categories = _unitOfWork.CategoryRepository.GetMany(c => c.Status == ActiveStatus.Active).ToList();
            return categories;
        }

        public Category CreateCategory(Category category)
        {
            try
            {
                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return category;
            } catch (Exception ex)
            {
                return null;
            }
            
        }
        public bool UpdateCategory(Category category, int userId)
        {
            category.ModifyDate = DateTime.Now;
            category.ModifyBy = userId;
            try
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCategory(int categoryId, int? userId)
        {
            Category category = _unitOfWork.CategoryRepository.GetByID(categoryId);
            category.Status -= ActiveStatus.Inactive;
            category.ModifyDate = DateTime.Now;
            category.ModifyBy = userId;
            try
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
