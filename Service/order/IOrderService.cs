using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Service.order
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> AddOrderAsync(Order newOrder);
        Task<Order?> UpdateOrderAsync(int id, Order updatedOrder);
        Task<Order?> UpdateOrderPartialAsync(int id, string status, string address, string deliveryMethod);
        Task<Order?> DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<decimal> GetTotalAmountByCustomerIdAsync(int customerId);
    }
}