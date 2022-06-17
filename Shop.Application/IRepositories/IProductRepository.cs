using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.IRepositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        void UpdateProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductAsync(int id);

        Task<List<Product>> GetProductsByCategory(string categoryName);
        Task<List<Product>> GetProductsByNameAsync(string productName);
        bool Containts(Product product);
        

    }
}
