using Microsoft.EntityFrameworkCore;
using Shop.Application.IRepositories;
using Shop.Core.Models.Orders;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = _applicationDbContext.Orders.Include(or=>or.OrderDetails)
                                                             .ThenInclude(pr=>pr.Product)
                                                             .ThenInclude(pr=>pr.Category)
                                                             .Include(or=>or.OrderDetails)
                                                             .ThenInclude(pr=>pr.Product.Img)
                                                             .ToList();
            return orders;
        }
        public async Task<List<Order>> GetOrdersOfUserAsync(string id)
        {
            List<Order> orders = await _applicationDbContext.Orders.Include(order => order.OrderDetails)
                                                                   .ThenInclude(order=>order.Product)
                                                                   .ThenInclude(product => product.Img)
                                                                   .Include(order=>order.OrderDetails)
                                                                   .ThenInclude(product=>product.Product.Category)
                                                                   .Where(order => order.UserOrder == id)
                                                                   .ToListAsync();
            return orders;
        }
        public async Task NewOrder(Order order)
        {
            await _applicationDbContext.Orders.AddAsync(order);
        }
    }
}
