﻿using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Category FindCategoryByName(string categoryName);
    }
}
