using Shop.Domain.Models.ProductModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Shop.Core.IServices;
using Shop.Core.DTO;

namespace Shop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosting;
        public ProductService(IUnitOfWork unitOfWork, IHostingEnvironment hosting)
        {
            _unitOfWork = unitOfWork;
            _hosting = hosting;
            
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            Product product = await ToProduct(productDTO);

            await _unitOfWork.ProductRepository.AddProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.ProductRepository.DeleteProductAsync(id);
        }

        public async Task<ProductDTO> GetProductAsync(int id)
        {
            Product product = await _unitOfWork.ProductRepository.GetProductAsync(id);
            ProductDTO productDTO =  ToProductDTO(product);
            return productDTO;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            List<Product> products = await _unitOfWork.ProductRepository.GetAllProducts();
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                var productDTO = ToProductDTO(product);

                productDTOs.Add(productDTO);

            }
            return productDTOs;
        }
        public async Task UpdateProduct(ProductDTO productDTO)
        {
            Product product = await ToProduct(productDTO);

            _unitOfWork.ProductRepository.UpdateProduct(product);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.Complete();
        }

        public async Task<List<ProductDTO>> GetProductsByCategory(string categoryName)
        {
            List<Product> products = await _unitOfWork.ProductRepository.GetProductsByCategory(categoryName);

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                var productDTO = ToProductDTO(product);

                productDTOs.Add(productDTO);

            }
            return productDTOs;
        }

        public async Task<List<ProductDTO>> GetProductsByNameAsync(string productName)
        {
            List<Product> products = await _unitOfWork.ProductRepository.GetProductsByNameAsync(productName);

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                var productDTO = ToProductDTO(product);

                productDTOs.Add(productDTO);

            }

            return productDTOs;

        }

        //public async Task<ImageModel> SaveImageAsync(IFormFile uploadFile)
        //{
        //    string path = "/images/" + uploadFile.FileName;

        //    using (var stream = new FileStream(_hosting.WebRootPath + path, FileMode.Create))
        //    {
        //        await uploadFile.CopyToAsync(stream);
        //    }
        //}

        public async Task<Product> ToProduct(ProductDTO productDTO)
        {
            Category category = _unitOfWork.CategoryRepository.FindCategoryByName(productDTO.Category.Name);

            if (category == null)
            {
                category = new Category();
                category.Name = productDTO.Category.Name;
            }

            ImageModel imageModel = new();

            IFormFile uploadFile = productDTO.Img.Image;

            string path = "/images/" + uploadFile.FileName;

            using (var stream = new FileStream(_hosting.WebRootPath + path, FileMode.Create))
            {
                await uploadFile.CopyToAsync(stream);
            }

            imageModel.Image = uploadFile;
            imageModel.Name = uploadFile.Name;
            imageModel.Path = path;

            Product product = new Product
            {
                Id = productDTO.Id,
                Cost = productDTO.Cost,
                Category = category,
                Manufacturer = productDTO.Manufacturer,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Img = imageModel
            };
            return product;
        }

        public List<ProductDTO> ProductListToProductDTO(List<Product> products)
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.Name = product.Category.Name;

                ImageDTO imageDTO = new ImageDTO();
                imageDTO.Path = product.Img.Path;

                productDTOs.Add(new ProductDTO()
                {
                    Id = product.Id,
                    Category = categoryDTO,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    Manufacturer = product.Manufacturer,
                    Img = imageDTO
                });

            }
            return productDTOs;
        }
        public ProductDTO ToProductDTO(Product product)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = product.Category.Name;

            ImageDTO imageDTO = new ImageDTO()
            {
                Name = product.Img.Name,
                Path = product.Img.Path
            };


            ProductDTO productDTO = new ProductDTO()
            {
                Id = product.Id,
                Category = categoryDTO,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                Img = imageDTO
            };

            return productDTO;
        }
    }

}