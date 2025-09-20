using API.Data;
using API.Models;
using API.Service.order;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service
{
    public class OrderService : IOrderService
    {
        private readonly UserDBContext _dbContext;

        public OrderService(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.Customer)

                .FirstOrDefaultAsync(o => o.OrderID == id) ?? throw new InvalidOperationException($"Order with ID {id} not found.");
            return order;
        }

        public async Task<bool> AddOrderAsync(Order newOrder)
        {
            _dbContext.Orders.Add(newOrder);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Order?> UpdateOrderAsync(int id, Order updatedOrder)
        {
            var existingOrder = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (existingOrder == null)
                return null;

            existingOrder.CustomerID = updatedOrder.CustomerID;
            existingOrder.OrderCode = updatedOrder.OrderCode;
            existingOrder.TotalAmount = updatedOrder.TotalAmount;
            existingOrder.OrderDate = updatedOrder.OrderDate;
            existingOrder.DeliveryMethod = updatedOrder.DeliveryMethod;
            existingOrder.PaymentMethod = updatedOrder.PaymentMethod;
            existingOrder.Address = updatedOrder.Address;
            existingOrder.Status = updatedOrder.Status;

            existingOrder.OrderItems.Clear();
            foreach (var item in updatedOrder.OrderItems)
            {
                existingOrder.OrderItems.Add(new OrderItem
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
            }

            _dbContext.Orders.Update(existingOrder);
            await _dbContext.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order?> DeleteOrderAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
                return null;

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Orders
                .Where(o => o.CustomerID == customerId)
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalAmountByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Orders
                .Where(o => o.CustomerID == customerId)
                .SumAsync(o => o.TotalAmount);
        }
        public async Task<Order?> UpdateOrderPartialAsync(int id, string status, string address, string deliveryMethod)
        {
            var existingOrder = await _dbContext.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (existingOrder == null)
                return null;

            existingOrder.Status = status;
            existingOrder.Address = address;
            existingOrder.DeliveryMethod = deliveryMethod;

            _dbContext.Orders.Update(existingOrder);
            await _dbContext.SaveChangesAsync();
            return existingOrder;
        }
    }
}