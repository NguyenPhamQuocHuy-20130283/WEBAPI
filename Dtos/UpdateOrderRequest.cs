using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dtos
{
    public class UpdateOrderRequest
    {
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public string? DeliveryMethod { get; set; }
        public string? PaymentMethod { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
    }

    public class UpdateOrderStatusRequest
    {
        public string Status { get; set; }
        public string Address { get; set; }
        public string DeliveryMethod { get; set; }
    }

}