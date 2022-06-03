using Shop.Application.IRepositories;
using Shop.Core.Models.ProductModels;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category FindCategoryByName(string categoryName)
        {
            Category? category = _context.Categories.FirstOrDefault(category => category.Name == categoryName);
            return category;
        }
    }
}
