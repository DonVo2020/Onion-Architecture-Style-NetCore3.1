using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int categoryNo);
        Task<int> UpdateCategory(Category category, int categoryNo);
        Task<int> AddCategory(Category category);
        Task<int> DeleteCategoryById(int categoryNo);
    }
}
