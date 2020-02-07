using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllCategoriesAsync();
        }

        public async Task<Category> GetCategoryById(int categoryNo)
        {
            return await _unitOfWork.Categories.GetCategoryByIdAsync(categoryNo);
        }

        public async Task<int> UpdateCategory(Category category, int categoryNo)
        {
            await _unitOfWork.Categories.UpdateCategoryAsync(category, categoryNo);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> AddCategory(Category category)
        {
            await _unitOfWork.Categories.AddCategoryAsync(category);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteCategoryById(int categoryNo)
        {
            await _unitOfWork.Categories.DeleteCategoryByIdAsync(categoryNo);
            return await _unitOfWork.CommitAsync();
        }

    }
}
