using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Service;
using API.Service.order;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Order
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var GettingOrderItems = order.OrderItems.Select(item => new OrderItem
            {
                ProductID = item.ProductID,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
            }).ToList();

            var newOrder = new API.Models.Order
            {
                OrderCode = OrderCodeGenerator.GenerateOrderCode(),
                CustomerID = order.CustomerID,
                OrderDate = DateTime.Now,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                DeliveryMethod = order.DeliveryMethod,
                PaymentMethod = order.PaymentMethod,
                Address = order.Address,
                OrderItems = GettingOrderItems
            };

            var result = await _orderService.AddOrderAsync(newOrder);

            if (result)
            {
                return Ok(new
                {
                    message = "Order created successfully.",
                    order = newOrder
                });
            }

            return BadRequest("Failed to create order.");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound("Order not found.");
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderRequest order)
        {
            var updatedOrder = await _orderService.GetOrderByIdAsync(id);
            if (updatedOrder == null)
                return BadRequest("Order with " + id + " not found.");


            updatedOrder = new API.Models.Order
            {
                OrderCode = order.OrderCode,
                CustomerID = order.CustomerID,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                Status = order.Status,
                DeliveryMethod = order.DeliveryMethod,
                PaymentMethod = order.PaymentMethod,
                Address = order.Address,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                }).ToList()
            };


            var result = await _orderService.UpdateOrderAsync(id, updatedOrder);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (result == null) return
                NotFound("Order not found.");
            return Ok("Order with id " + id + " deleted.");

        }

        [HttpGet("user/{CustomerID}")]
        public async Task<IActionResult> GetOrdersByCustomerID(int CustomerID)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(CustomerID);
            return Ok(orders);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOrderPartial([FromRoute] int id, [FromBody] UpdateOrderStatusRequest order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.UpdateOrderPartialAsync(id, order.Status, order.Address, order.DeliveryMethod);
            if (result != null)
                return Ok(result);
            return BadRequest("Failed to update order.");
        }

    }
}