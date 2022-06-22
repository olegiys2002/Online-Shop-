using Shop.Domain.DTO;

namespace ShopUI.ViewModels.Home
{
    public class HomePageViewModel
    {
        public string Title { get; set; } = " Добро пожаловать в наш магазин!";
        public List<ProductDTO> productDTOs { get; set; } = new List<ProductDTO>();
    }
}
