using Microsoft.AspNetCore.Mvc;
using Shop.Domain.DTO;
using ShopUI.ViewModels.ShoppingCartViewModel;
using Shop.Domain.IServices;

namespace ShopUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserService _userService;
        public ShoppingCartController(IShoppingCartService shoppingCartService,IUserService userService)
        {
          
            _shoppingCartService = shoppingCartService;
            _userService = userService;
        }
        public async Task<IActionResult> Cart()
        {
            List<CartItemDTO> cartItemDTOs = await _shoppingCartService.GetAllCartItemsforUserAsync();
            double totalPrice = await _shoppingCartService.GetTotalAsync();
            CartShopViewModel cartShopViewModel = new CartShopViewModel();
            cartShopViewModel.CartItemDTOs = cartItemDTOs;
            cartShopViewModel.Total = totalPrice;
            return View(cartShopViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            await _shoppingCartService.AddToCartAsync(productId);
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int productId)
        {
            await _shoppingCartService.DeleteFromCartAsync(productId);
            return RedirectToAction("Cart");
        }

    }
}
