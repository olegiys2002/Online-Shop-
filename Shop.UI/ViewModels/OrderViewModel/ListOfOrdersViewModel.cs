using Shop.Domain.DTO;

namespace ShopUI.ViewModels.OrderViewModel
{
    public class ListOfOrdersViewModel
    {
        public List<OrderDTO> OrderDTOs { get; set; } = new();

        public string IsAccept { get; set; } = "Заказ не подтвержен";

    }
}
