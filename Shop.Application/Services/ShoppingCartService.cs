
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Core.DTO;
using Shop.Core.IServices;
using Shop.Domain.Models.Cart;
using Shop.Domain.Models.ProductModels;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
   
        IUnitOfWork _unitOfWork;
        IProductService _productService;
        IHttpContextAccessor _contextAccessor;
        private const string CartIdSession = "CartSession";
        public ShoppingCartService(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor,IProductService productService)
        {
     
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _productService = productService;
     
        }

        public string GetCartId()
        {
            if (_contextAccessor.HttpContext.Session.GetString(CartIdSession) == null)
            {
                if (_contextAccessor.HttpContext.User.Identity.Name == null)
                {
                    Guid guid = Guid.NewGuid();
                    _contextAccessor.HttpContext.Session.SetString(CartIdSession, guid.ToString());
                }
                else
                {
                    string userIdentityName = _contextAccessor.HttpContext.User.Identity.Name;
                    _contextAccessor.HttpContext.Session.SetString(CartIdSession, userIdentityName);
                }
            }
            return _contextAccessor.HttpContext.Session.GetString(CartIdSession);
        }
        public async Task AddToCartAsync(int id)
        {
            string sessionString = GetCartId();
            Product product = await _unitOfWork.ProductRepository.GetProductAsync(id);
            var cartItem = await _unitOfWork.CartRepository.GetCartItemAsync(id, sessionString);
            if (cartItem == null)
            {
               
                 cartItem = new CartItem()
                {
                    ItemId = Guid.NewGuid().ToString(),
                    CardId = sessionString,
                    DataCreated = DateTime.Now,
                    Quentity = 1,
                    Product = product
                };
                await _unitOfWork.CartRepository.AddToCartAsync(cartItem);
            }
          
            else
            {
                cartItem.Quentity++;
            }
            
            await _unitOfWork.Complete();
        }
        public async Task DeleteFromCartAsync(int id)
        {
            var sessionString = GetCartId();
            var cartItemToDelete = await _unitOfWork.CartRepository.GetCartItemAsync(id,sessionString);
            _unitOfWork.CartRepository.DeleteFromCart(cartItemToDelete);
            await _unitOfWork.Complete();


        }

        public async Task<List<CartItemDTO>> GetAllCartItemsforUserAsync()
        {
           string currentUserSession = GetCartId();
           List<CartItem> listOfCartItems =await  _unitOfWork.CartRepository.GetAllItemsAsync(currentUserSession);
           List<CartItemDTO> cartItemDTOs = new();

           foreach(var cartItem in listOfCartItems)
           {
                CartItemDTO cartItemDTO = ToCartItemDTO(cartItem);
                cartItemDTOs.Add(cartItemDTO);

           }
            return cartItemDTOs;
        }
        public async Task<double> GetTotalAsync()
        {
            double total = 0;
            string currentUserSession = GetCartId();
            List<CartItem> listOfCartItems = await _unitOfWork.CartRepository.GetAllItemsAsync(currentUserSession);
            foreach(var items in listOfCartItems)
            {
                total += items.Quentity * items.Product.Cost;
            }
            return total;
        }

        public CartItemDTO ToCartItemDTO(CartItem cartItem)
        {
            Product product = cartItem.Product;
            ProductDTO productDTO = _productService.ToProductDTO(product);
            CartItemDTO cartItemDTO = new CartItemDTO()
            { 
                Product = productDTO,
                ProductId = productDTO.Id,
                Quentity = cartItem.Quentity
            };
            return cartItemDTO;
        }

        public async Task EmptyCartAsync()
        {
            string currentUserSession = GetCartId();
            List<CartItem> listOfCartItems = await _unitOfWork.CartRepository.GetAllItemsAsync(currentUserSession);
            foreach (var items in listOfCartItems)
            {
                _unitOfWork.CartRepository.DeleteFromCart(items);
            }
            await _unitOfWork.Complete();
        }
    }
}
