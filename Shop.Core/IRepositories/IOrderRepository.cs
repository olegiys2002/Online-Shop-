using Shop.Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.IRepositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Task<List<Order>> GetOrdersOfUserAsync(string id);
        Task<Order> FindOrderById(string orderId);
        Task NewOrder(Order order);

    }
}
