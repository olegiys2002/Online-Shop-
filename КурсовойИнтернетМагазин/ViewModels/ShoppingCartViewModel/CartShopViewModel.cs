using Shop.Application.DTO;
using Shop.Core.Models.User;

namespace КурсовойИнтернетМагазин.ViewModels.ShoppingCartViewModel
{
    public class CartShopViewModel
    {
        public List<CartItemDTO> CartItemDTOs { get; set; } = new();
        public double Total { get; set; }
    }
}
