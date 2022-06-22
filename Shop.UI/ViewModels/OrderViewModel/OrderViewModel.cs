using Shop.Domain.DTO;

namespace ShopUI.ViewModels.OrderViewModel
{
    public class OrderViewModel
    {
        public OrderDTO Order { get; set; } = new();
    }
}
