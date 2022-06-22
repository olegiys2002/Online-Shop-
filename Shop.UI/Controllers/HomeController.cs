using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ShopUI.Models;
using ShopUI.ViewModels.Home;
using Shop.Domain.IServices;

namespace ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> HomePage()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.productDTOs = await _productService.GetAllProducts();
            return View(homePageViewModel);
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}