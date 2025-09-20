using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }  // Khóa chính
        public int OrderID { get; set; }  // Khóa ngoại tham chiếu tới Order

        public int ProductID { get; set; }  // Khóa ngoại tham chiếu tới Product
        public int Quantity { get; set; }  // Số lượng sản phẩm
        public decimal UnitPrice { get; set; }  // Giá đơn vị của sản phẩm
        [JsonIgnore]
        public Order Order { get; set; }  // Liên kết tới đối tượng Order

        public Product Product { get; set; }  // Liên kết tới đối tượng Product

    }
}