using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO;
using Shop.Application.IServices;
using Shop.Core.Models.Orders;
using КурсовойИнтернетМагазин.ViewModels.OrderViewModel;

namespace КурсовойИнтернетМагазин.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> GetListOfOrders()
        {
            List<OrderDTO> orderDTOs = await _orderService.GetOrders();
            ListOfOrdersViewModel listOfOrdersViewModel = new ListOfOrdersViewModel();
            listOfOrdersViewModel.OrderDTOs = orderDTOs;
            return View(listOfOrdersViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> NewOrder(OrderViewModel orderViewModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Console.WriteLine("Тест");
            if (ModelState.IsValid)
            {
                OrderDTO orderDTO = new OrderDTO();
                orderDTO = orderViewModel.Order;
                await _orderService.NewOrder(orderDTO);
                return RedirectToAction("GetListOfOrders");
            }
            return View();

        }
        public IActionResult NewOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult AllOrders()
        {
            ListOfOrdersViewModel listOfOrdersViewModel = new ListOfOrdersViewModel();
            List<OrderDTO> ordersDTOs = _orderService.GetAllOrders();
            listOfOrdersViewModel.OrderDTOs = ordersDTOs;
            return View(listOfOrdersViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(string id)
        {
            await _orderService.ConfirmOrder(id);
            return RedirectToAction("AllOrders", "Order");
        }
        [HttpPost]
        public async Task<IActionResult> RejectOrder(string id)
        {
            await _orderService.RejectOrder(id);
            return RedirectToAction("AllOrders", "Order");
        }
    }
}

