using Shop.Domain.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.IRepositories
{
    public interface ICartRepository
    {
        public Task AddToCartAsync(CartItem cartItem);
        public void DeleteFromCart(CartItem cartItem);
        public Task<List<CartItem>> GetAllItemsAsync(string cartId);
        public Task<CartItem> GetCartItemAsync(int productId,string cartId);

    }
}
