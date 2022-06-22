using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Data;
using Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.IRepositories;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }
         
        public async Task DeleteProductAsync(int id)
        {
            Product product = await _context.Products.FindAsync(id);
        
            _context.Products.Remove(product);
            
        }

        public async Task<Product> GetProductAsync(int id)
        {
            Product? product = await _context.Products.Include(prod=>prod.Img).
                                                       Include(prod=>prod.Category).
                                                       SingleOrDefaultAsync(prod=>prod.Id==id);
            return product;
        }

        
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include(w => w.Category).Include(w => w.Img).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(string categoryName)
        {
            List<Product> products = await _context.Products.Include(w => w.Category)
                                                            .Include(w => w.Img)
                                                            .Where(product=>product.Category.Name == categoryName)
                                                            .ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            List<Product> products = await _context.Products.Include(w => w.Category)
                                                            .Include(w => w.Img)
                                                            .Where(product => product.Name == productName)
                                                            .ToListAsync();
            return products;
        }



        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public bool Containts(Product product)
        {
            return _context.Products.Contains(product);
        }

     
    }
}
