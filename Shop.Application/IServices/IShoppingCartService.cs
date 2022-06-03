using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync(int id);
        Task DeleteFromCartAsync(int id);
        Task<List<CartItemDTO>> GetAllCartItemsforUserAsync();
        Task<double> GetTotalAsync();

    }
}
