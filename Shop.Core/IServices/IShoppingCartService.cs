using Shop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.IServices
{
    public interface IShoppingCartService
    {
        string GetCartId();
        Task AddToCartAsync(int id);
        Task DeleteFromCartAsync(int id);
        Task<List<CartItemDTO>> GetAllCartItemsforUserAsync();
        Task<double> GetTotalAsync();
        Task EmptyCartAsync();

    }
}
