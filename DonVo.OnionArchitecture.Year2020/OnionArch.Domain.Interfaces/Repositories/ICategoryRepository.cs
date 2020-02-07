using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryNo);
        Task<int> UpdateCategoryAsync(Category category, int categoryNo);
        Task<int> AddCategoryAsync(Category category);
        Task<int> DeleteCategoryByIdAsync(int categoryNo);
    }
}
