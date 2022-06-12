using Microsoft.AspNetCore.Http;
using Shop.Application.DTO;
using Shop.Application.IServices;
using Shop.Core.Models.Orders;
using Shop.Core.Models.ProductModels;
using System.Text;


namespace Shop.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;

        private const string OrderSessionKey = "OrderId";
        private string CurrentOrderId { get; set; }
        public OrderService(IHttpContextAccessor httpContextAccessor,
                            IUnitOfWork unitOfWork,
                            IShoppingCartService shoppingCartService, 
                            IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }
        public async Task ConfirmOrder(string id)
        {
            Order order = await _unitOfWork.OrderRepository.FindOrderById(id);
            order.IsAccept = true;
            _unitOfWork.OrderRepository.UpdateOrder(order);
            await _unitOfWork.Complete();
        }

        public string GetOrderId()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString(OrderSessionKey) == null)
            {
                if (_httpContextAccessor.HttpContext.User.Identity.Name == null)
                {
                    Guid guid = Guid.NewGuid();
                    _httpContextAccessor.HttpContext.Session.SetString(OrderSessionKey, guid.ToString());
                }
                else
                {
                    _httpContextAccessor.HttpContext.Session.SetString(OrderSessionKey, _httpContextAccessor.HttpContext.User.Identity.Name);
                }
            }
            return _httpContextAccessor.HttpContext.Session.GetString(OrderSessionKey);
        }
        public async Task NewOrder(OrderDTO orderDTO)
        {

            Order order = await ToOrderAsync(orderDTO);

            await _unitOfWork.OrderRepository.NewOrder(order);
            await _shoppingCartService.EmptyCartAsync();
            await _unitOfWork.Complete();
        }
        public List<OrderDTO> GetAllOrders()
        {
            List<Order> orders = _unitOfWork.OrderRepository.GetAllOrders();
            List<OrderDTO> orderDTOs = new();
            foreach(var order in orders)
            {
                OrderDTO orderDTO = ToOrderDTO(order);
                orderDTOs.Add(orderDTO);
            }
            return orderDTOs;
        }
        public async Task<List<OrderDTO>> GetOrders()
        {
            CurrentOrderId = GetOrderId();
            List<Order> orders = await _unitOfWork.OrderRepository.GetOrdersOfUserAsync(CurrentOrderId);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
           
            foreach (var order in orders)
            {
                OrderDTO orderDTO = ToOrderDTO(order);
                orderDTOs.Add(orderDTO);
               
            }
            return orderDTOs;
        }

        public OrderDTO ToOrderDTO(Order order)
        {
            List<OrderDetailsDTO> orderDetailsDTOs = new();
            foreach (var orderDetails in order.OrderDetails)
            {
                OrderDetailsDTO orderDetailsDTO = ToOrderDetailsDTO(orderDetails);
                orderDetailsDTOs.Add(orderDetailsDTO);
            }
            OrderDTO orderDTO = new()
            {
                OrderId = order.OrderId,
                IsAccept = order.IsAccept,
                FirstName = order.FirstName,
                LastName = order.LastName,
                OrderDate = order.OrderDate,
                Phone = order.Phone,
                OrderDetails = orderDetailsDTOs
            };
            return orderDTO;

        }

        public async Task<Order> ToOrderAsync(OrderDTO orderDTO)
        {
            CurrentOrderId = GetOrderId();
            Guid guidId = Guid.NewGuid();

            List<CartItemDTO> usersCart = await _shoppingCartService.GetAllCartItemsforUserAsync();
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            foreach (var cartItemDTO in usersCart)
            {
                OrderDetails details = await CartToOrderDetails(cartItemDTO);
                orderDetails.Add(details);
            }

            double total = await _shoppingCartService.GetTotalAsync();

            Order order = new Order()
            {
                FirstName = orderDTO.FirstName,
                LastName = orderDTO.LastName,
                Address = orderDTO.Address,
                Email = orderDTO.Email,
                Phone = orderDTO.Phone,
                OrderId = guidId.ToString(),
                OrderDate = DateTime.Now,
                UserOrder = CurrentOrderId,
                InStock = false,
                IsAccept = false,
                Total = total,
                OrderDetails = orderDetails
            };
 
            return order;

        }
        public OrderDetailsDTO ToOrderDetailsDTO(OrderDetails orderDetails)
        {
            Product product = orderDetails.Product;
            OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO() 
            {
                Product = _productService.ToProductDTO(product),
                Quantity = orderDetails.Quantity
            };
            return orderDetailsDTO;

        }

        public async Task<OrderDetails> CartToOrderDetails(CartItemDTO cartItemDTO)
        {
            ProductDTO productDTO = cartItemDTO.Product;
            Product  product = await  _unitOfWork.ProductRepository.GetProductAsync(productDTO.Id);
            OrderDetails orderDetails = new OrderDetails()
            {
                Product = product,
                Quantity = cartItemDTO.Quentity,
                ProductId = cartItemDTO.ProductId,
            };

            return orderDetails;
        }
        
        public async Task RejectOrder(string id)
        {
            Order order = await _unitOfWork.OrderRepository.FindOrderById(id);
            _unitOfWork.OrderRepository.DeleteOrder(order);
            await _unitOfWork.Complete();
        }


    }
}
