using Shop.Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IRepositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Task<List<Order>> GetOrdersOfUserAsync(string id);
        Task NewOrder(Order order);

    }
}
