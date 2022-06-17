using Shop.Core.DTO;

namespace ShopUI.ViewModels.Product
{
    public class ListOfProductsViewModel
    {
        public string Title { get; set; } = " Список продуктов";
        public List<ProductDTO> productDTOs { get; set; } = new List<ProductDTO>();
    }
}
