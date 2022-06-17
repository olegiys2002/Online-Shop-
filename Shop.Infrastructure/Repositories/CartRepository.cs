using Microsoft.EntityFrameworkCore;
using Shop.Core.IRepositories;
using Shop.Domain.Models.Cart;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        public ApplicationDbContext _dbContext { get; set; }
        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddToCartAsync(CartItem cartItem)
        {
            await _dbContext.CartItems.AddAsync(cartItem);
        }

        public void DeleteFromCart(CartItem cartItem)
        {
            _dbContext.CartItems.Remove(cartItem);
        }

        public async Task<List<CartItem>> GetAllItemsAsync(string cartId)
        {
            List<CartItem> cartItems = await _dbContext.CartItems.Include(products=>products.Product).
                                                                  Include(cat=>cat.Product.Category).
                                                                  Include(img=>img.Product.Img).
                                                                  Where(cartItem=>cartItem.CardId==cartId).
                                                                  ToListAsync();
            return cartItems;
        }

        public async Task<CartItem> GetCartItemAsync(int productId,string cardId)
        {
           var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(prod => prod.ProductId == productId 
                                                                         && prod.CardId == cardId);
           return cartItem;
        }
    }
}
