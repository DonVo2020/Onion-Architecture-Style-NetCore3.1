using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await CreditContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryNo)
        {
            return await CreditContext.Category.SingleOrDefaultAsync(m => m.CategoryNo == categoryNo);
        }

        public async Task<int> UpdateCategoryAsync(Category category, int categoryNo)
        {
            var updateCategory = await CreditContext.Category.SingleOrDefaultAsync(m => m.CategoryNo == categoryNo);

            if (updateCategory != null)
            {
                updateCategory.CategoryNo = category.CategoryNo;
                updateCategory.CategoryDesc = category.CategoryDesc;
                updateCategory.CategoryCode = category.CategoryCode;

                CreditContext.Update(updateCategory);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            category.CategoryNo = 0;

            var result = await (from a in CreditContext.Category
                                where a.CategoryDesc == category.CategoryDesc && a.CategoryCode == category.CategoryCode                                     
                                select a).SingleOrDefaultAsync();
            if (result == null)
            {
                var add = CreditContext.Category.Add(category);
                if (add != null)
                {
                    return 1;
                }
            }

            return -1;
        }

        public async Task<int> DeleteCategoryByIdAsync(int categoryNo)
        {
            var deleteCategory= await (from a in CreditContext.Category
                                      where a.CategoryNo == categoryNo
                                      select a).SingleOrDefaultAsync();

            if (deleteCategory != null)
            {
                var deleted = CreditContext.Remove(deleteCategory);
                if (deleted != null)
                {
                    return 1;
                }
            }

            return -1;
        }
        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
