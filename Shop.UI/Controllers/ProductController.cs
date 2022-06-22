using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.DTO;
using Shop.Domain.IServices;
using ShopUI.ViewModels.Product;

namespace ShopUI.Controllers
{
    public class ProductController : Controller
    {
        
        IProductService _productServise;
        public ProductController(IProductService productService)
        {
            _productServise = productService;
        }
   
        [Authorize(Roles ="admin")]

        [HttpGet]
        public IActionResult AddProduct()
        {            
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> EditProduct(int productId)
        {
            EditProductViewModel editProductViewModel = new EditProductViewModel();
            editProductViewModel.productDTO = await _productServise.GetProductAsync(productId);

            return View(editProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductDTO productDTO = editProductViewModel.productDTO;
                await _productServise.UpdateProduct(productDTO);
                await _productServise.SaveChangesAsync();
                return RedirectToAction("ListOfProducts", "Product");
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel addOrEditProduct)
        {
      
            if (ModelState.IsValid)
            {

                ProductDTO productDTO = new ProductDTO()
                {
                    Name = addOrEditProduct.Name,
                    Manufacturer = addOrEditProduct.Manufacturer,
                    Cost = addOrEditProduct.Cost,
                    Description= addOrEditProduct.Description,
                    Category = addOrEditProduct.Category,
                    Img = addOrEditProduct.Image,
                };
            
                await _productServise.AddProductAsync(productDTO);              
                await _productServise.SaveChangesAsync();
                return RedirectToAction("ListOfProducts", "Product");
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> ListOfProducts()
        {
            ListOfProductsViewModel listOfProductsView = new();
            listOfProductsView.productDTOs = await _productServise.GetAllProducts();
            return View(listOfProductsView);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
                await _productServise.DeleteProductAsync(id);
                await _productServise.SaveChangesAsync();   
                return RedirectToAction("ListOfProducts", "Product");
        }

        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            List<ProductDTO> productDTOs = await _productServise.GetProductsByCategory(categoryName);
            ListOfProductsViewModel listOfProductsViewModel = new ListOfProductsViewModel();
            listOfProductsViewModel.productDTOs = productDTOs;
            listOfProductsViewModel.Title = categoryName;
            return View(listOfProductsViewModel);
        }

        public async Task<IActionResult> GetProductsByName(string searchString)
        {
            List<ProductDTO> productDTOs = await _productServise.GetProductsByNameAsync(searchString);
            ListOfProductsViewModel listOfProductsViewModel = new ListOfProductsViewModel();
            if (productDTOs.Count == 0)
            {
                listOfProductsViewModel.Title = "По вашему запросу ничего не найдено";
            }
            else
            {
                listOfProductsViewModel.productDTOs = productDTOs;
                listOfProductsViewModel.Title = searchString;
            }
            return View(listOfProductsViewModel);
        }

    
    }
     
}
