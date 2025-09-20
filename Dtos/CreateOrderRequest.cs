using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dtos
{
    public class CreateOrderRequest
    {
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public string? DeliveryMethod { get; set; }
        public string? PaymentMethod { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }

    public class OrderItemRequest
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}