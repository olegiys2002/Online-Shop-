using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.IRepositories
{
    public interface ICategoryRepository
    {
        Category FindCategoryByName(string categoryName);
    }
}
