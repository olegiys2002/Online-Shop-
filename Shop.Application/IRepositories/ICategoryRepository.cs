using Shop.Core.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IRepositories
{
    public interface ICategoryRepository
    {
        Category FindCategoryByName(string categoryName);
    }
}
