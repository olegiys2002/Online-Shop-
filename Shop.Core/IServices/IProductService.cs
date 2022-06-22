using Shop.Domain.DTO;
using Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.IServices
{
    public interface IProductService
    {
        Task AddProductAsync(ProductDTO product);
        Task DeleteProductAsync(int id);
        Task UpdateProduct(ProductDTO productDTO);
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductAsync(int id);
        Task<List<ProductDTO>> GetProductsByCategory(string categoryName);
        Task<List<ProductDTO>> GetProductsByNameAsync(string productName);
        Task<int> SaveChangesAsync();
        List<ProductDTO> ProductListToProductDTO(List<Product> products);
        ProductDTO ToProductDTO(Product product);
        Task<Product> ToProduct(ProductDTO productDTO);
    }
}
