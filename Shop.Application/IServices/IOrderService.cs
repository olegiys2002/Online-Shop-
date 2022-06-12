﻿using Shop.Application.DTO;
using Shop.Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IOrderService
    {
   
        Task NewOrder(OrderDTO orderDTO);
        Task<List<OrderDTO>> GetOrders();
        Task ConfirmOrder(string id);
        Task RejectOrder(string id);
        List<OrderDTO> GetAllOrders();
        OrderDTO ToOrderDTO(Order order);
        Task<Order> ToOrderAsync(OrderDTO orderDTO);
        OrderDetailsDTO ToOrderDetailsDTO(OrderDetails orderDetails);
        Task<OrderDetails> CartToOrderDetails(CartItemDTO cartItemDTO);
        string GetOrderId();

    }
}
