using Shop.Core.DTO;
using Shop.Domain.Models.User;

namespace ShopUI.ViewModels.ShoppingCartViewModel
{
    public class CartShopViewModel
    {
        public List<CartItemDTO> CartItemDTOs { get; set; } = new();
        public double Total { get; set; }
    }
}
